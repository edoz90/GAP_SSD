using Alchemy;
using Alchemy.Classes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Heuristics {
    class GAPServer {
        protected static ConcurrentDictionary<String, UserContext> OnlineConnections = new ConcurrentDictionary<String, UserContext>();
        private WebSocketServer server;
        private TraceListener trace = new MyTraceListener(null);
        public String cliMagString, soluzione;
        private String dbPath;
        private int port;

        public GAPServer(TraceListener traceListener, String dbPath, int port) {
            trace = traceListener;
            this.dbPath = dbPath;
            this.port = port;
        }

        public void startServer() {
            server = new WebSocketServer(port, System.Net.IPAddress.Any) {
                OnConnect = OnConnect,
                OnReceive = OnReceive,
                OnSend = OnSend,
                OnDisconnect = OnDisconnect,
                TimeOut = new TimeSpan(0, 5, 0)
            };
            server.Start();
            trace.WriteLine("Starting Web Socket Server.");
        }

        public void stopServer() {
            server.Stop();
            trace.WriteLine("Stopping Web Socket Server.");
        }

        public void OnConnect(UserContext aContext) {
            trace.WriteLine("Client connected from: " + aContext.ClientAddress.ToString());
            OnlineConnections.TryAdd(aContext.ClientAddress.ToString(), aContext);
        }

        public void OnReceive(UserContext aContext) {
            try {
                switch (aContext.DataFrame.ToString()) {
                    case "0":
                        trace.WriteLine("Richiesta per magazzi e clienti da [" + aContext.ClientAddress.ToString() + "].");
                        aContext.Send(cliMagString);
                        break;
                    case "1":
                        trace.WriteLine("Richiesta per soluzione da [" + aContext.ClientAddress.ToString() + "].");
                        aContext.Send(soluzione);
                        break;
                }

            } catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public void OnSend(UserContext aContext) {
            trace.WriteLine("Data Sent To : " + aContext.ClientAddress.ToString());
        }

        public void OnDisconnect(UserContext aContext) {
            trace.WriteLine("Client Disconnected : " + aContext.ClientAddress.ToString());
            UserContext conn;
            OnlineConnections.TryRemove(aContext.ClientAddress.ToString(), out conn);
        }
    }
}
