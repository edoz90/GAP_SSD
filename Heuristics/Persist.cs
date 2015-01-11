using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Heuristics {
    class Persist {
        GeneralizedAssignment GAP;
        private bool fileTxt = false;

        public Persist(GeneralizedAssignment GAP) {
            this.GAP = GAP;
        }

        public bool openDB(string dbPath) {
            SQLiteCommand command;
            string connString = "Data Source=" + dbPath + ";Versione=3;";
            SQLiteConnection conn = new SQLiteConnection(connString);
            SQLiteDataReader DR;
            int i, j;
            this.usingFile = false;

            try {
                conn.Open();
                Trace.WriteLine("Connessione aperta");

                command = new SQLiteCommand(conn);

                command.CommandText = "select count(*) from clienti";
                GAP.n = Convert.ToInt32(command.ExecuteScalar());
                Trace.WriteLine("Num clienti: " + GAP.n);
                GAP.sol = new Int32[GAP.n];
                GAP.solbest = new Int32[GAP.n];

                command.CommandText = "select count(*) from magazzini";
                GAP.m = Convert.ToInt32(command.ExecuteScalar());
                Trace.WriteLine("Num magazzini: " + GAP.m);
                GAP.cap = new Int32[GAP.m];
                GAP.req = new Int32[GAP.m, GAP.n];

                command.CommandText = "select req from clienti";
                DR = command.ExecuteReader();
                int cont = 0;
                int[] appoggio = new Int32[GAP.n];
                while (DR.Read()) {
                    appoggio[cont] = Convert.ToInt32(DR["req"]);
                    cont++;
                }
                for (int l = 0; l < GAP.m; l++) {
                    for (int k = 0; k < GAP.n; k++) {
                        GAP.req[l, k] = appoggio[k];
                    }
                }

                for (int z = 0; z < GAP.n; z++) {
                    Trace.WriteLine("client " + z + " request:" + GAP.req[0, z]);
                }
                Trace.WriteLine("");
                DR.Close();

                command.CommandText = "select cap from magazzini";
                DR = command.ExecuteReader();
                cont = 0;
                while (DR.Read()) {
                    GAP.cap[cont] = Convert.ToInt32(DR["cap"]);
                    cont++;
                }
                for (int z = 0; z < GAP.m; z++) {
                    Trace.WriteLine("store " + z + " cap:" + GAP.cap[z]);
                }
                Trace.WriteLine("");
                DR.Close();
                //cost
                GAP.c = new double[GAP.m, GAP.n];

                command.CommandText = "select mag, cli, cost from dist";
                DR = command.ExecuteReader();
                cont = 0;
                while (DR.Read()) {
                    i = Convert.ToInt32(DR["mag"]) - 1;
                    j = Convert.ToInt32(DR["cli"]) - 1;
                    GAP.c[i, j] = Convert.ToInt32(DR["cost"]);
                    cont++;
                }
                DR.Close();

                Trace.WriteLine("Letti tutti i dati");
                return true;
            } catch (Exception e) {
                if (dbPath != "") {
                    Trace.WriteLine("The file could not be read:");
                    Trace.WriteLine(e);
                }
                conn.Close();
                return false;
            }
        }

        // recupero solo la prima istanza dei dati
        public bool openFile(string dbPath) {
            StreamReader sr = null;
            String file = "";
            String[] split;
            int numIstante = 0, offset = 0;
            try {
                sr = new StreamReader(dbPath);
                string line = File.ReadLines(dbPath).First().Trim();
                file = sr.ReadToEnd().Trim();
                file = Regex.Replace(file, @"\s+", " ");
                split = file.Split(' ');
                // salvo il numero delle istante nel file
                int index = 0;
                if (line.Length == 1) {
                    numIstante = Convert.ToInt32(split[index++]);
                    offset = 3;
                } else {
                    index = 0;
                    offset = 2;
                }
                // salvo il numero dei magazzini
                GAP.m = Convert.ToInt32(split[index++]);
                Trace.WriteLine("Numero magazzini: " + GAP.m);
                // salvo il numero dei clienti
                GAP.n = Convert.ToInt32(split[index++]);
                Trace.WriteLine("Numero clienti: " + GAP.n + Environment.NewLine);
                // instanzio l'array delle richieste
                GAP.req = new Int32[GAP.m, GAP.n];
                // instanzio l'array delle soluzioni
                GAP.sol = new Int32[GAP.n];
                // instanzio l'array dei best
                GAP.solbest = new Int32[GAP.n];
                // instanzio l'array delle capacità
                GAP.cap = new Int32[GAP.m];

                int max = GAP.m * GAP.n + 3;
                index = offset;
                // istanzio la matrice dei costi
                GAP.c = new double[GAP.m, GAP.n];
                for (int i = 0; i < GAP.m && index < max; i++) {
                    for (int j = 0; j < GAP.n && index < max; j++) {
                        GAP.c[i, j] = Convert.ToInt32(split[index]);
                        //Trace.WriteLine("Mag: " + i + " cliente: " + j + " costo: " + split[index]);
                        index++;
                    }
                }
                max = index + GAP.m * GAP.n;
                // instanzio la matrice delle richieste
                for (int i = 0; i < GAP.m && index < max; i++) {
                    for (int j = 0; j < GAP.n; j++) {
                        GAP.req[i, j] += Convert.ToInt32(split[index]);
                        index++;
                    }
                }
                /*for (int i = 0; i < GAP.n; i++) {
                    Trace.WriteLine("Client " + i + " request: " + GAP.req[i]);
                }
                Trace.Write(Environment.NewLine);*/
                max = index + GAP.m;
                // Instanzio l'array delle capacità
                for (int i = 0; i < GAP.m && index < max; i++) {
                    GAP.cap[i] = Convert.ToInt32(split[index]);
                    index++;
                    //Trace.WriteLine("Store " + i + " cap:" + GAP.cap[i]);
                }
                sr.Close();
                Trace.WriteLine("Letti tutti i dati");
            } catch (Exception e) {
                if (dbPath != "") {
                    Trace.WriteLine("The file could not be read:");
                    Trace.WriteLine(e);
                }
                return false;
            }
            return true;
        }
        public bool salvaSoluzione(string dbPath, string algo) {
            if (usingFile)
                return salvaTxt(dbPath, algo);
            else
                return salvaDB(dbPath);
        }
        public bool salvaDB(string dbPath) {
            int j;
            SQLiteCommand command;
            string connString = "Data Source=" + dbPath + ";Versione=3;";
            SQLiteConnection conn = new SQLiteConnection(connString);

            try {
                conn.Open();
                Trace.WriteLine("Connessione aperta");
                command = new SQLiteCommand(conn);
                command.CommandText = "select load_extension('mod_spatialite')";
                command.ExecuteNonQuery();
                command.CommandText = "delete from soluzione";
                command.ExecuteNonQuery();

                for (j = 0; j < GAP.n; j++) {
                    command.CommandText = "insert into soluzione (mag,cli) values (" + (GAP.solbest[j] + 1) + "," + (j + 1) + ")";
                    command.ExecuteNonQuery();
                }

                // vedi RoadNet.pdf slide 11
                command.CommandText = "update soluzione "
                    + "set Geometry = "
                    + "( select makeline ( geometry ) as line from "
                    + "( select Geometry from magazzini where ( id=mag ) "
                    + "union "
                    + "select Geometry from clienti where (id=cli) "
                    + ") "
                    + ") ";
                command.ExecuteNonQuery();
                Trace.WriteLine("Salvata la soluzione");
            } catch (Exception ex) {
                Trace.WriteLine("[salvaSoluzione] error: " + ex.Message);
                return false;
            } finally {
                conn.Close();
            }
            return true;
        }
        public bool salvaTxt(string dbPath, string algo) {
            String text = "";
            string path = dbPath + ".sol";
            for (int i = 0; i < GAP.n; i++) {
                //text += (GAP.solbest[i] + 1) + ", " + (i + 1) + Environment.NewLine;
            }
            text += algo + ": " + GAP.zub + Environment.NewLine;

            try {
                if (File.Exists(path)) {
                    System.IO.File.AppendAllText(@path, text);
                } else {
                    System.IO.File.WriteAllText(@path, text);
                }
            } catch (Exception e) {
                Trace.WriteLine("Soluzione non salvata: " + e);
                return false;
            }
            Trace.WriteLine("Soluzione salvata");
            return true;
        }
        public bool usingFile {
            get { return this.fileTxt; }
            set { this.fileTxt = value; }
        }
        public String getCliMag(String dbFile) {
            String cliMag = "";
            SQLiteDataReader r;
            using (SQLiteConnection con = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;")) {
                using (SQLiteCommand com = new SQLiteCommand(con)) {
                    con.Open();

                    com.CommandText = "SELECT load_extension('mod_spatialite')";
                    com.ExecuteNonQuery();
                    com.CommandText = "SELECT COUNT(*) FROM clienti";
                    cliMag += Convert.ToInt32(com.ExecuteScalar()).ToString() + ",";
                    com.CommandText = "SELECT COUNT(*) FROM magazzini";
                    cliMag += Convert.ToInt32(com.ExecuteScalar()).ToString() + ",";
                    com.CommandText = "SELECT x(geometry) as x, y(geometry) as y FROM clienti";
                    r = com.ExecuteReader();
                    while (r.Read()) {
                        cliMag += r.GetDouble(0).ToString().Replace(',', '.') + "," + r.GetDouble(1).ToString().Replace(',', '.') + ",";
                    }
                    r.Close();
                    com.CommandText = "SELECT x(geometry) as x, y(geometry) as y FROM magazzini";
                    r = com.ExecuteReader();
                    while (r.Read()) {
                        cliMag += r.GetDouble(0).ToString().Replace(',', '.') + "," + r.GetDouble(1).ToString().Replace(',', '.') + ",";
                    }
                    r.Close();
                    con.Close();
                }
            }
            return cliMag;
        }
        public String getSolution(String dbFile) {
            String soluzione = "";
            SQLiteDataReader r;
            using (SQLiteConnection con = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;")) {
                using (SQLiteCommand com = new SQLiteCommand(con)) {
                    con.Open();

                    com.CommandText = "SELECT load_extension('mod_spatialite')";
                    com.ExecuteNonQuery();
                    com.CommandText = "SELECT COUNT(*) FROM soluzione";
                    soluzione += Convert.ToInt32(com.ExecuteScalar()).ToString() + ",";
                    com.CommandText = "SELECT mag FROM soluzione ORDER BY ROWID;";
                    r = com.ExecuteReader();
                    while (r.Read()) {
                        soluzione += r.GetInt32(0) + ",";
                    }
                    r.Close();
                    con.Close();
                }
            }
            return soluzione;
        }
    }
}
