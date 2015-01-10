using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heuristics {
    public partial class frmHeu : Form {

        Controller controller = new Controller();

        public frmHeu() {
            InitializeComponent();
            MyTraceListener debugListener = new MyTraceListener(txtConsole);
            Trace.Listeners.Add(debugListener);
        }

        private void btnHeurCostruct_Click(object sender, EventArgs e) {
            bkwHeu.RunWorkerAsync(0);
        }
        private void btnVnd_Click(object sender, EventArgs e) {
            bkwHeu.RunWorkerAsync(1);
        }
        private void btnSA_Click(object sender, EventArgs e) {
            bkwHeu.RunWorkerAsync(2);
        }
        private void btnTabuSearch_Click(object sender, EventArgs e) {
            bkwHeu.RunWorkerAsync(3);
        }
        private void btnGapExact_Click(object sender, EventArgs e) {
            bkwHeu.RunWorkerAsync(6);
        }
        private void btnILS_Click(object sender, EventArgs e) {
            bkwHeu.RunWorkerAsync(4);
        }
        private void btnVNS_Click(object sender, EventArgs e) {
            bkwHeu.RunWorkerAsync(5);
        }

        // Menù
        private void esciToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        // Esegui
        private void euristicaCostruttivaToolStripMenuItem_Click(object sender, EventArgs e) {
            btnHeuCost.PerformClick();
        }
        private void vndToolStripMenuItem_Click(object sender, EventArgs e) {
            btnVND.PerformClick();
        }
        private void simulatedAnnealingToolStripMenuItem_Click(object sender, EventArgs e) {
            btnSA.PerformClick();
        }
        private void tabuSearchToolStripMenuItem_Click(object sender, EventArgs e) {
            btnTabuSearch.PerformClick();
        }
        private void iteratedLocalSearchToolStripMenuItem_Click(object sender, EventArgs e) {
            btnILS.PerformClick();
        }
        private void variableNeighborhoodSearchToolStripMenuItem_Click(object sender, EventArgs e) {
            btnVNS.PerformClick();
        }
        private void gAPExactToolStripMenuItem_Click(object sender, EventArgs e) {
            btnGapExac.PerformClick();
        }
        private void startServerToolStripMenuItem_Click(object sender, EventArgs e) {
            controller.startWSserver(txtConsole);
        }
        private void stopServerToolStripMenuItem_Click(object sender, EventArgs e) {
            controller.stopWSserver();
        }

        // ?
        private void courseSiteToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("www3.csr.unibo.it/~maniezzo/didattica/DSS/SistSuppDec.html");
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("www.edoardoros.it");
        }

        // Apertura DB e File
        private string openFile(string fileType) {
            string res = "";

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "";
            openFileDialog1.Filter = fileType + " files (*." + fileType + ")|*." + fileType + "|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                res = openFileDialog1.FileName;
                txtConsole.Clear();
            }
            return res;
        }
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e) {
            btnFile.PerformClick();
        }
        private void openDBToolStripMenuItem_Click(object sender, EventArgs e) {
            btnOpenDB.PerformClick();
        }
        private void btnOpenDB_Click(object sender, EventArgs e) {
            String dbPath = openFile("sqlite");
            if (controller.openDB(dbPath)) {
                this.EnableAll();
            }
        }
        private void btnFile_Click(object sender, EventArgs e) {
            String dbPath = openFile("txt");
            if (controller.openFile(dbPath)) {
                this.EnableAll();
            }
        }
        // BACKGROUND WORKER
        private void bkwHeu_DoWork(object sender, DoWorkEventArgs e) {
            this.Invoke(new MethodInvoker(delegate { this.DisableAll(); }));
            switch ((int)e.Argument) {
                case 0:
                    controller.heuCostruttiva();
                    break;
                case 1:
                    controller.vnd();
                    break;
                case 2:
                    controller.simulatedAnnealing();
                    break;
                case 3:
                    controller.tabuSearch();
                    break;
                case 4:
                    controller.iteratedLocalSearch();
                    break;
                case 5:
                    controller.variableNeighborhoodSearch();
                    break;
                case 6:
                    controller.gapExact();
                    break;
            }
            this.Invoke(new MethodInvoker(delegate { this.EnableAll(); }));
        }
        public void DisableAll() {
            this.btnHeuCost.Enabled = false;
            this.btnVND.Enabled = false;
            this.btnSA.Enabled = false;
            this.btnTabuSearch.Enabled = false;
            this.btnILS.Enabled = false;
            this.btnVNS.Enabled = false;
            this.btnGapExac.Enabled = false;
            this.btnOpenDB.Enabled = false;
            this.btnFile.Enabled = false;

            this.exeEsegui.Enabled = false;
            this.strumenti.Enabled = false;
        }
        public void EnableAll() {
            this.btnHeuCost.Enabled = true;
            this.btnVND.Enabled = true;
            this.btnSA.Enabled = true;
            this.btnTabuSearch.Enabled = true;
            this.btnILS.Enabled = true;
            this.btnVNS.Enabled = true;
            this.btnGapExac.Enabled = true;
            this.btnOpenDB.Enabled = true;
            this.btnFile.Enabled = true;

            this.exeEsegui.Enabled = true;
            this.strumenti.Enabled = true;
        }
    }






}
