using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heuristics {
    class GeneralizedAssignment {
        public int n; // numero dei clienti
        public int m; // numero dei magazzini
        public double[,] c; // matrice dei costi
        public int[,] req; // richieste
        public int[] cap; // capacità dei magazzini

        public int[] sol, solbest; // di dimensione n

        const double EPS = 0.00001;
        public double zub; // costo della miglior soluzione trovata

        System.Random rnd = new Random(550);

        /* Prende i posibili assegnamenti cliente magazzino, li ordina per costo crescente, parto dal cliente che è più vicino 
         * al magazzino fino ad arrivare a quello più indecente, e comincio a dire "questo lo faccio, quest'altro lo assegno, etc" 
         * e vado avanti così
         * Salto quando il cliente è già assegnato
         * Salto quando il magazzino è già pieno
         * Per fare questi controlli devo sapere se è stato già assegnato un cliente al magazzino e qual è l'attuale capacità residua di un magazzino */
        // costruzione, ognuno al suo deposito più vicino
        public double simpleContruct() {
            int i, ii, j;
            //capleft è la capacità residua che inizialmente sarà uguale alla lunghezza totale della capacità
            int[] capleft = new int[cap.Length], ind = new int[m];
            double[] dist = new double[m];
            Array.Copy(cap, capleft, cap.Length);

            Trace.WriteLine(Environment.NewLine + "Starting Simple Construction");
            zub = 0;
            // per ogni cliente
            for (j = 0; j < n; j++) {
                // per ogni magazzino
                for (i = 0; i < m; i++) {
                    //dist[i] = c[i, j]; // guardo quanto costa l'assegnamento del cliente corrente al magazzino
                    // altrimenti non genera una soluzione valida
                    dist[i] = req[i, j];
                    ind[i] = i; //mi servirà per ordinare, dico che al posto 0 l'inidice è 0, al posto 1 sta 1 ecc ecc 
                }
                // ordina ind secondo le chiavi dist
                Array.Sort(dist, ind);
                ii = 0;
                while (ii < m) {
                    i = ind[ii];
                    if (capleft[i] >= req[i, j]) {
                        sol[j] = i; // soluzione: a sol[j] è associato il cliente j
                        solbest[j] = i; // soluzione migliore
                        capleft[i] -= req[i, j]; // riduco la capacità
                        zub += c[i, j]; // aumento zub per incrementare il costo totale
                        break;
                    }
                    ii++;
                }
                if (ii == m)
                    System.Windows.Forms.MessageBox.Show("[SimpleConstruct] Errore. ii=" + ii);
            }
            if (checkSolution(sol) == Double.MaxValue) {
                Trace.WriteLine("[SimpleConstruct] Soluzione non ammissibile." + Environment.NewLine);
                zub = Double.MaxValue;
            }
            return zub;
        }

        // tolgo un cliente da un magazzino e lo metto in un altro
        public double opt10() {
            return opt10(c);
        }

        public double opt10(double[,] matcosti) {
            double z = 0, zcheck = 0;
            int i, isol, j;
            int[] capres = new int[cap.Length]; // array delle capacità residue
            // Ad ogni cliente scambio un magazzino e se il nuovo assegnamento ha un costo minore lo aggiungo alle soluzioni

            Array.Copy(cap, capres, cap.Length); // inizializzo array delle capcaità residue
            for (j = 0; j < n; j++) {
                capres[sol[j]] -= req[sol[j], j]; // la capacità residua del magazzino che contiene il cliente j viene decrementata dalla richiesta del cliente j
                z += matcosti[sol[j], j];
            }

            // per ogni clienti prendo il magazzino a cui è associato e lo cambio con tutti gli altri
        l0: for (j = 0; j < n; j++) {
                isol = sol[j];
                for (i = 0; i < m; i++) {
                    // se è lo stesso magazzino
                    if (i == isol) continue;
                    if (matcosti[i, j] < matcosti[isol, j] && capres[i] >= req[i, j]) {
                        // costo minore, faccio il nuovo assegnamento
                        sol[j] = i;
                        capres[i] -= req[i, j];
                        capres[isol] += req[isol, j];
                        // avendo fatto l'assegnamento il costo della soluzione viene decrementato fra la soluzione iniziale e quella attuale
                        z -= (matcosti[isol, j] - matcosti[i, j]);
                        zcheck = checkSolution(sol);
                        // se la soluzione migliore attuale è migliore della "migliore di sempre" me la salvo
                        if (z < zub && (Math.Abs(z - zcheck) <= EPS)) {
                            zub = z;
                            //solbest[j] = sol[j];
                            //Trace.WriteLine("[1-0 opt] new zub " + zub);
                            Array.Copy(sol, solbest, sol.Length); // inizializzo array delle capcaità residue
                        }
                        goto l0;
                    }
                }
            }
            zcheck = 0;
            for (j = 0; j < n; j++)
                zcheck += matcosti[sol[j], j];
            if (Math.Abs(zcheck - z) > EPS)
                System.Windows.Forms.MessageBox.Show("[1.0opt] Ahi ahi");
            return zub;
        }

        // scambio i magazzini tra due clienti
        public double opt11() {
            int j, j1, j2, temp, cap1, cap2;
            int[] capres = new int[cap.Length];
            double delta, z = 0, zcheck;

            Array.Copy(cap, capres, cap.Length);
            for (j = 0; j < n; j++) {
                capres[sol[j]] -= req[sol[j], j];
                z += c[sol[j], j];
            }
            zcheck = checkSolution(sol);

            // scambio 2 clienti
        l0: for (j1 = 0; j1 < n; j1++) {
                for (j2 = j1 + 1; j2 < n; j2++) {
                    delta = (c[sol[j1], j1] + c[sol[j2], j2]) - (c[sol[j1], j2] + c[sol[j2], j1]);
                    if (delta > 0) {
                        cap1 = capres[sol[j1]] + req[sol[j1], j1] - req[sol[j2], j2];
                        cap2 = capres[sol[j2]] + req[sol[j2], j2] - req[sol[j1], j1];
                        if (cap1 >= 0 && cap2 >= 0) {
                            // modifico le capacità residue aggiungendo la richiesta del cliente che tolgo e togliendo quella del cliente aggiunto
                            capres[sol[j1]] += req[sol[j1], j1];
                            capres[sol[j1]] -= req[sol[j2], j2];

                            capres[sol[j2]] += req[sol[j2], j2];
                            capres[sol[j2]] -= req[sol[j1], j1];
                            // scambio i due magazzini
                            temp = sol[j1];
                            sol[j1] = sol[j2];
                            sol[j2] = temp;

                            z -= delta;
                            zcheck = checkSolution(sol);
                            if (z < zub && (Math.Abs(z - zcheck) <= EPS)) {
                                zub = z;
                                Trace.WriteLine("[1-1 opt] new zub " + zub);
                                Array.Copy(sol, solbest, sol.Length); // inizializzo array delle capcaità residue
                            }
                            goto l0;
                        }
                    }
                }
            }

            zcheck = 0;
            for (j = 0; j < n; j++)
                zcheck += c[sol[j], j];
            if (Math.Abs(zcheck - z) > EPS)
                System.Windows.Forms.MessageBox.Show("[1.1opt] Ahi ahi");
            zcheck = checkSolution(sol);
            return zub;
        }

        // Simulated Annealing
        public double simulatedAnnealing(double k, double maxT, double maxIter, double alpha) {
            double z = 0, p = 0, rand = 0, T = 0;
            int i, isol, j, iter;
            int[] capres = new int[cap.Length];

            Array.Copy(cap, capres, cap.Length);
            for (j = 0; j < n; j++) {
                capres[sol[j]] -= req[sol[j], j];
                z += c[sol[j], j];
            }

            Trace.WriteLine(Environment.NewLine + "Starting simulated annealing");
            T = maxT;
            iter = 0;
        lab2: iter++;
            j = rnd.Next(0, n - 1);
            isol = sol[j];
            i = rnd.Next(0, m - 1);
            if (i == isol)
                i = (i + 1) % m;
            if (c[i, j] < c[isol, j] && capres[i] >= req[i, j]) {
                // il costo è minore, assegno il magazzino
                sol[j] = i;
                capres[i] -= req[i, j];
                capres[isol] += req[isol, j];
                // avendo fatto l'assegnamento il costo della soluzione viene decrementato fra la soluzione iniziale e quella attuale
                z -= (c[isol, j] - c[i, j]);
                if (z < zub && (Math.Abs(z - checkSolution(sol)) <= EPS)) {
                    zub = z;
                    Trace.WriteLine("[SA] new zub " + zub);
                    Array.Copy(sol, solbest, sol.Length); // inizializzo array delle capcaità residue
                }
            } else if (capres[i] >= req[i, j]) {
                p = Math.Exp(-(c[i, j] - c[isol, j]) / (k * T));
                rand = rnd.Next(100);
                // condizione di metropolis
                if (rand < p * 100) {
                    sol[j] = i;
                    capres[i] -= req[i, j];
                    capres[isol] += req[isol, j];
                    z -= (c[isol, j] - c[i, j]);
                    // commento per evitare overhead di stampa
                    //Trace.WriteLine("[SA] Scambio in peggio: p = " + p + " diff. " + (c[i, j] - c[isol, j]) + " z:" + z);
                }
            }
            // annealing condition
            if ((iter % 1000) == 0)
                T = alpha * T;
            // end condition
            if (T > 0.001)
                goto lab2;
            else if (iter < maxIter) {
                T = maxT;
                goto lab2;
            }

            double zcheck = 0;
            for (j = 0; j < n; j++)
                zcheck += c[sol[j], j];
            if (Math.Abs(zcheck - z) > EPS)
                System.Windows.Forms.MessageBox.Show("[1.0opt] Ahi ahi");
            return zub;
        }

        // Tabu Search
        public double tabuSearch(int tTenure, int maxIter) {
            double z = 0, deltaMAx;
            int i, isol, j, iter, imax, jmax;
            int[] capres = new int[cap.Length];
            int[,] TL = new int[m, n];

            Array.Copy(cap, capres, cap.Length);
            for (j = 0; j < n; j++) {
                // la capres del magazzino con cliente j viene decrementata della richiesta di j, sol[j] = cliente
                capres[sol[j]] -= req[sol[j], j];
                z += c[sol[j], j];
            }
            iter = 0;
            for (i = 0; i < m; i++) {
                for (j = 0; j < n; j++) {
                    TL[i, j] = int.MinValue;
                }
            }
            Trace.WriteLine(Environment.NewLine + "Starting Tabu Search");

        l0: deltaMAx = double.MinValue;
            jmax = 0;
            imax = sol[jmax];
            iter++;
            // per ogni cliente
            for (j = 0; j < n; j++) {
                // isol è il magazzino a cui attualmente è attaccato
                isol = sol[j];
                //per il cliente j scorro con i tutti i magazzini
                for (i = 0; i < m; i++) {
                    if (i == isol) continue;
                    // se il costo è più basso e posso servirlo
                    if ((c[isol, j] - c[i, j]) > deltaMAx && capres[i] >= req[i, j] && (TL[i, j] + tTenure) < iter) {
                        imax = i;
                        jmax = j;
                        deltaMAx = c[isol, j] - c[i, j];
                    }
                }
            }
            isol = sol[jmax];
            deltaMAx = c[isol, jmax] - c[imax, jmax];
            sol[jmax] = imax;

            capres[imax] -= req[imax, jmax];
            capres[isol] += req[isol, jmax];

            TL[imax, jmax] = iter;
            z -= deltaMAx;

            if (z < zub) {
            //if (z < zub && (Math.Abs(z - checkSolution(sol)) <= EPS)) {
                zub = z;
                Array.Copy(sol, solbest, sol.Length);
                Trace.WriteLine("[TS] New zub = " + zub);
            }

            if (iter < maxIter) {
                goto l0;
            }

            double zcheck = 0;
            for (j = 0; j < n; j++)
                zcheck += c[sol[j], j];
            if (Math.Abs(zcheck - z) > EPS)
                System.Windows.Forms.MessageBox.Show("[TS] Inconsistent Solution Value");
            return zub;
        }

        // Iterated Local Search
        public double IterateLocalSearch(int maxIter) {
            Trace.WriteLine(Environment.NewLine + "Starting Iterated Local Search");
            for (int iter = 0; iter < maxIter; iter++) {
                opt10();
                dataPerturbation();
                //iter++;
            }
            return zub;
        }

        private void dataPerturbation() {
            int i, j;
            double[,] matricePerturbata = new double[m, n];

            for (i = 0; i < m; i++) {
                for (j = 0; j < n; j++) {
                    matricePerturbata[i, j] = c[i, j] + c[i, j] * 0.7 * rnd.NextDouble();
                }
            }
            opt10(matricePerturbata);
        }

        // Variable Neighborhoode Search
        public double variableNeighborhoodSearch(int maxIter) {
            int iter;
            double z1, z2;
            iter = 0;
            Trace.WriteLine(Environment.NewLine + "Starting Variable Neighborhood Search");
            while (iter < maxIter) {
            loop: z1 = opt10();
                z2 = opt11();
                if (z2 < z1) {
                    iter = 0;
                    goto loop;
                } else { neigh21(); }
                iter++;
            }
            return zub;
        }

        // scambio due (stesso deposito) vs 1 (altro deposito)
        private void neigh21() {
            int i1 = 0, i2 = 0, j = 0, j11 = 0, j12 = 0, j21 = 0, iter = 0;
            List<int> lst1 = new List<int>(), lst2 = new List<int>();
            int[] capres = new int[cap.Length];
            double zcheck = 0;

            Array.Copy(cap, capres, cap.Length);
            for (j = 0; j < n; j++)
                capres[sol[j]] -= req[sol[j], j];

            i1 = rnd.Next(0, m);
            i2 = rnd.Next(0, m);
            if (i1 == i2)
                i2 = (i2 + 1) % m;

            for (j = 0; j < n; j++) {
                if (sol[j] == i1)
                    lst1.Add(j);
                if (sol[j] == i2)
                    lst2.Add(j);
            }

            // scelgo 2 a caso in i1 e uno a caso in i2
            iter = 0;
        loop: j11 = rnd.Next(lst1.Count);
            j12 = rnd.Next(lst1.Count);
            if (j12 == j11)
                j12 = (j12 + 1) % lst1.Count;
            j11 = lst1[j11];
            j12 = lst1[j12];
            j21 = lst2[rnd.Next(lst2.Count)];

            if (((capres[i1] + req[i1, j11] + req[i1, j12] - req[i2, j21]) >= 0) &&
                ((capres[i2] - req[i2, j11] - req[i2, j12] + req[i1, j21]) >= 0)) {
                //se non è ammissibile ripristino i precedenti valori
                int a11 = sol[j11];
                int a12 = sol[j12];
                int a21 = sol[j21];
                // aggiorno la soluzione
                sol[j11] = i2;
                sol[j12] = i2;
                sol[j21] = i1;
                zcheck = checkSolution(sol);
                if (zcheck == double.MaxValue) {
                    //ripristino i valori precedenti
                    sol[j11] = a11;
                    sol[j12] = a12;
                    sol[j21] = a21;
                }
            } else {
                iter++;
                if (iter < 50)
                    goto loop;
            }
            return;
        }

        // controllo ammissibilità soluzione
        public double checkSolution(int[] sol) {
            double cost = 0;
            int j;
            int[] capused = new int[m];

            // controllo assegnamenti
            for (j = 0; j < n; j++)
                if (sol[j] < 0 || sol[j] >= m) {
                    cost = double.MaxValue;
                    goto lend;
                } else
                    cost += c[sol[j], j];

            // controllo capacità
            for (j = 0; j < n; j++) {
                capused[sol[j]] += req[sol[j], j];
                if (capused[sol[j]] > cap[sol[j]]) {
                    cost = double.MaxValue;
                    goto lend;
                }
            }
        lend: return cost;
        }
    }
}
