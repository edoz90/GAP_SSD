using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Heuristics;

namespace GAP2014 {
    class GAPexact {
        GeneralizedAssignment GAP;
        int nClient, nWarehouse;
        double[,] cost;
        int[,] req;
        int[] cap;
        int[] solution;

        public GAPexact(GeneralizedAssignment GAP) {
            this.GAP = GAP;
            nClient = GAP.n;
            nWarehouse = GAP.m;
            cost = GAP.c;
            req = GAP.req;
            cap = GAP.cap;
            solution = GAP.sol;
        }

        /// <summary>
        /// COMPUTE THE LOWER BOUND OF THE GAP USING CBC
        /// </summary>
        /// <returns></returns>
        public int[] GAPexactCBC(bool isBinary) {
            Trace.WriteLine(Environment.NewLine + "[GAPexactCBC] starting, going for " + (isBinary ? "optimality" : "lower bound"));

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            WrapperCS.Wrapper wrapper = new WrapperCS.Wrapper();

            int colCount = nClient * nWarehouse; // colonne della matrice (senza RHS)
            int rowCount = nClient + nWarehouse; // righe della matrice (senza vincoli semplici del tipo "var>0", che vengono messi nei bounds)

            double[] objectCoeffs;

            double[] collb;
            double[] colub;

            double[] rowlb; // LIMITE INFERIORE RHS ( se equazione == rhsUppValues; altrimenti limite inferiore di soddisfacimento vincoli)
            double[] rowub;

            string idxInteger; // Indice delle variabili sottoposte a 

            int[] matrixBegin; // Indice iniziale dei coefficienti per ogni colonna. L'elemento ulteriore alla fine è uguale a nonZeroCount
            int[] matrixCount; // numero di coefficienti non-zero per ogni colonna
            int[] matrixIndex; // indici di riga per ogni coefficiente (0 < x < rowCount)
            double[] matrixValues; // coefficienti

            int index = 0;

            //COEFFICIENT
            index = 0;
            objectCoeffs = new double[colCount];
            for (int war = 0; war < nWarehouse; war++) {
                for (int cli = 0; cli < nClient; cli++) {
                    objectCoeffs[index++] = cost[war, cli];
                }
            }

            //RHS UPPER
            index = 0;
            rowub = new double[rowCount];
            rowlb = new double[rowCount];
            rowlb.Initialize();
            //VINCOLI ASSEGNAMENTO CLIENTI
            for (int i = 0; i < req.GetLength(1); i++) {
                rowub[index] = 1;
                rowlb[index] = 1;
                index++;
            }
            //VINCOLI CAPACITA' MAGAZZINI
            for (int i = 0; i < cap.Length; i++) {
                rowub[index++] = cap[i];
            }
            //MATRIX COUNT
            matrixCount = new int[colCount];
            idxInteger = "";
            for (int i = 0; i < colCount; i++) {
                matrixCount[i] = 2;

                //IDX INTEGER
                idxInteger += "1";
            }
            //MATRIX VALUES
            matrixValues = new double[colCount * 2];
            index = 0;
            for (int war = 0; war < nWarehouse; war++) {
                for (int cli = 0; cli < nClient; cli++) {
                    matrixValues[index++] = 1.0;
                    matrixValues[index++] = req[war, cli];
                }
            }
            //MATRIX INDEX
            index = 0;
            matrixIndex = new int[colCount * 2];
            for (int war = 0; war < nWarehouse; war++) {
                for (int cli = 0; cli < nClient; cli++) {
                    matrixIndex[index++] = cli;
                    matrixIndex[index++] = nClient + war;
                }
            }
            //MATRIX BEGIN
            matrixBegin = new int[colCount + 1];
            for (int i = 0; i < matrixBegin.Length; i++) {
                matrixBegin[i] = i * 2;
            }
            //LOWER BOUND
            collb = new double[colCount];
            for (int i = 0; i < colCount; i++)
                collb[i] = 0.0;
            //UPPER BOUND
            colub = new double[colCount];
            for (int i = 0; i < colCount; i++)
                colub[i] = 1.0;

            IntPtr model = wrapper.NewModel();

            //wrapper.SetMaximumSeconds(model, 200.0);
            wrapper.SetOptimizationDirection(model, 1);
            wrapper.LoadProblem(model, colCount, rowCount, matrixBegin, matrixIndex, matrixValues,
                  collb, colub, objectCoeffs, rowlb, rowub);

            if (isBinary)
                wrapper.CopyInIntegerInformation(model, idxInteger);

            int res = wrapper.BranchAndBound(model);
            // SOLUTION
            double[] solutionDouble = wrapper.GetColSolution(model);
            int[] solutionInt = new int[nClient];
            int indexDouble = 0;

            for (int i = 0; i < nWarehouse; i++) {
                for (int j = 0; j < nClient; j++) {
                    // SCORRO TUTTI GLI ELEMENTI DELLA SOLUZIONE CBC E VERIFICO IL VALORE DELL'ASSEGNAMENTO 
                    // ( SE '1' MAGAZZINO ASSEGNATO A CLIENTE ALTRIMENTI '0')
                    if (Convert.ToInt32(solutionDouble[indexDouble]) == 1) {
                        // ASSEGNO AL CLIENTE SPECIFICO IL MAGAZZINO
                        solutionInt[j] = i;
                    }
                    // INCREMENTO L'INDICE DI SCORRIMENTO DELLA SOLUZIONE CBC
                    indexDouble++;
                }
            }

            stopwatch.Stop();

            // UPDATE SOLUTION
            if (solution == null)
                solution = new int[nClient];

            Array.Copy(solutionInt, solution, nClient);

            // UPDATE DATA SOLUTION
            Trace.WriteLine("Total CPU time: " + stopwatch.Elapsed);
            Trace.WriteLine("Obj. value: " + wrapper.GetObjValue(model));
            Trace.WriteLine("Num. iterations: " + wrapper.GetIterationCount(model));
            return solution;
        }
    }
}
