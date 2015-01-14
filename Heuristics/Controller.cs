using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using GAP2014;

namespace Heuristics {
    class Controller {
        Persist Per;
        GeneralizedAssignment GAP;
        private string dbPath;
        GAPexact GAPexe;
        private GAPServer server;
        int maxIter = 20000;
        private Boolean started = false;

        public Controller() {
            this.GAP = new GeneralizedAssignment();
            this.Per = new Persist(GAP);
            this.GAPexe = new GAPexact(GAP);
        }

        public void heuCostruttiva() {
            GAP.simpleContruct();
            Trace.WriteLine("Costruttiva terminata, costo " + GAP.zub);
            Per.salvaSoluzione(dbPath, "Euristica Costrutttiva");
        }

        public void vnd() {
            GAP.opt10();
            Trace.WriteLine("opt10 terminata, costo " + GAP.zub);
            GAP.opt11();
            Trace.WriteLine("opt11 terminata, costo " + GAP.zub);
            Per.salvaSoluzione(dbPath, "Variable Neighborhood Descent");
        }

        public void tabuSearch() {
            int tTenureMistery = 10;
            GAP.tabuSearch(tTenureMistery, maxIter);
            Trace.WriteLine("tabuSearch terminato, costo " + GAP.zub);
            Per.salvaSoluzione(dbPath, "Tabu Search");
        }

        public void iteratedLocalSearch() {
            double zubold = GAP.zub;
            GAP.IterateLocalSearch(maxIter);
            Trace.WriteLine("Iterated local search, costo: " + GAP.zub);
            if (GAP.zub < zubold)
                Per.salvaSoluzione(dbPath, "Iterated Local Search");
        }

        public void gapExact() {
            GAPexe = new GAPexact(GAP);
            GAPexe.GAPexactCBC(false);
            // se è a false calcola il lowerbound --> polinomiale
            GAPexe.GAPexactCBC(true);
            // se è a true calcola l'intera --> esponenziale
        }

        public void simulatedAnnealing() {
            double zubold = GAP.zub;
            GAP.simulatedAnnealing(10, 1000, 50000, 0.95);
            Trace.WriteLine("Simulated annealing terminato, costo " + GAP.zub);
            if (GAP.zub < zubold) {
                Per.salvaSoluzione(dbPath, "Simulated Annealing");
            }
        }

        public void variableNeighborhoodSearch() {
            double zubold = GAP.zub;
            GAP.variableNeighborhoodSearch(10000);
            Trace.WriteLine("Variable Neigh Search terminata, costo: " + GAP.zub);
            if (GAP.zub < zubold) {
                Per.salvaSoluzione(dbPath, "Variable Neighborhood Search");
            }
        }

        public bool openDB(String dbPath) {
            Per = new Persist(GAP);
            this.dbPath = dbPath;
            Per.usingFile = false;
            Trace.WriteLine("Apro la connessione con " + dbPath);
            return Per.openDB(dbPath);
        }

        public bool openFile(String dbPath) {
            Per = new Persist(GAP);
            this.dbPath = dbPath;
            Trace.WriteLine("Apro il file: " + dbPath);
            Per.usingFile = true;
            return Per.openFile(dbPath);
        }

        public void startWSserver(System.Windows.Forms.TextBox txtSocket) {
            if (!started) {
                TraceListener socketListener = new MyTraceListener(txtSocket);
                server = new GAPServer(socketListener, dbPath, 8100);
                server.cliMagString = Per.getCliMag(dbPath);
                server.soluzione = Per.getSolution(dbPath);
                server.startServer();
                started = true;
            }
        }

        public void stopWSserver() {
            server.stopServer();
            started = false;
        }
    }
}