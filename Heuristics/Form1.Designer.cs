using System.Drawing;
namespace Heuristics
{
    partial class frmHeu
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.btnOpenDB = new System.Windows.Forms.Button();
            this.btnHeuCost = new System.Windows.Forms.Button();
            this.btnVND = new System.Windows.Forms.Button();
            this.btnSA = new System.Windows.Forms.Button();
            this.btnTabuSearch = new System.Windows.Forms.Button();
            this.btnILS = new System.Windows.Forms.Button();
            this.btnVNS = new System.Windows.Forms.Button();
            this.btnGapExac = new System.Windows.Forms.Button();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exeEsegui = new System.Windows.Forms.ToolStripMenuItem();
            this.euristicaCostruttivaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.simulatedAnnealingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabuSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iteratedLocalSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variableNeighborhoodSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gAPExactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strumenti = new System.Windows.Forms.ToolStripMenuItem();
            this.startServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.courseSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bkwHeu = new System.ComponentModel.BackgroundWorker();
            this.mnuMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.txtConsole.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.ForeColor = System.Drawing.Color.White;
            this.txtConsole.Location = new System.Drawing.Point(185, 34);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(425, 324);
            this.txtConsole.TabIndex = 0;
            // 
            // btnOpenDB
            // 
            this.btnOpenDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenDB.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnOpenDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDB.ForeColor = System.Drawing.Color.White;
            this.btnOpenDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenDB.Location = new System.Drawing.Point(23, 34);
            this.btnOpenDB.Name = "btnOpenDB";
            this.btnOpenDB.Size = new System.Drawing.Size(69, 23);
            this.btnOpenDB.TabIndex = 1;
            this.btnOpenDB.Text = "OpenDB";
            this.btnOpenDB.UseVisualStyleBackColor = true;
            this.btnOpenDB.Click += new System.EventHandler(this.btnOpenDB_Click);
            // 
            // btnHeuCost
            // 
            this.btnHeuCost.Enabled = false;
            this.btnHeuCost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeuCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeuCost.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnHeuCost.Location = new System.Drawing.Point(6, 19);
            this.btnHeuCost.Name = "btnHeuCost";
            this.btnHeuCost.Size = new System.Drawing.Size(149, 25);
            this.btnHeuCost.TabIndex = 2;
            this.btnHeuCost.Text = "Euristica Costruttiva";
            this.btnHeuCost.UseVisualStyleBackColor = true;
            this.btnHeuCost.Click += new System.EventHandler(this.btnHeurCostruct_Click);
            // 
            // btnVND
            // 
            this.btnVND.Enabled = false;
            this.btnVND.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVND.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVND.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnVND.Location = new System.Drawing.Point(6, 50);
            this.btnVND.Name = "btnVND";
            this.btnVND.Size = new System.Drawing.Size(149, 42);
            this.btnVND.TabIndex = 3;
            this.btnVND.Text = "Variable Neighborhood Descent";
            this.btnVND.UseVisualStyleBackColor = true;
            this.btnVND.Click += new System.EventHandler(this.btnVnd_Click);
            // 
            // btnSA
            // 
            this.btnSA.Enabled = false;
            this.btnSA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSA.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnSA.Location = new System.Drawing.Point(6, 19);
            this.btnSA.Name = "btnSA";
            this.btnSA.Size = new System.Drawing.Size(149, 25);
            this.btnSA.TabIndex = 4;
            this.btnSA.Text = "Simulated Annealing";
            this.btnSA.UseVisualStyleBackColor = true;
            this.btnSA.Click += new System.EventHandler(this.btnSA_Click);
            // 
            // btnTabuSearch
            // 
            this.btnTabuSearch.Enabled = false;
            this.btnTabuSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabuSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabuSearch.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnTabuSearch.Location = new System.Drawing.Point(6, 50);
            this.btnTabuSearch.Name = "btnTabuSearch";
            this.btnTabuSearch.Size = new System.Drawing.Size(149, 25);
            this.btnTabuSearch.TabIndex = 5;
            this.btnTabuSearch.Text = "Tabu Search";
            this.btnTabuSearch.UseVisualStyleBackColor = true;
            this.btnTabuSearch.Click += new System.EventHandler(this.btnTabuSearch_Click);
            // 
            // btnILS
            // 
            this.btnILS.Enabled = false;
            this.btnILS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnILS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnILS.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnILS.Location = new System.Drawing.Point(6, 81);
            this.btnILS.Name = "btnILS";
            this.btnILS.Size = new System.Drawing.Size(149, 25);
            this.btnILS.TabIndex = 6;
            this.btnILS.Text = "Iterated Local Search";
            this.btnILS.UseVisualStyleBackColor = true;
            this.btnILS.Click += new System.EventHandler(this.btnILS_Click);
            // 
            // btnVNS
            // 
            this.btnVNS.Enabled = false;
            this.btnVNS.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnVNS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVNS.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnVNS.Location = new System.Drawing.Point(6, 112);
            this.btnVNS.Name = "btnVNS";
            this.btnVNS.Size = new System.Drawing.Size(149, 42);
            this.btnVNS.TabIndex = 7;
            this.btnVNS.Text = "Variable Neighborhood Search";
            this.btnVNS.UseVisualStyleBackColor = true;
            this.btnVNS.Click += new System.EventHandler(this.btnVNS_Click);
            // 
            // btnGapExac
            // 
            this.btnGapExac.Enabled = false;
            this.btnGapExac.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGapExac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGapExac.ForeColor = System.Drawing.Color.White;
            this.btnGapExac.Location = new System.Drawing.Point(23, 335);
            this.btnGapExac.Name = "btnGapExac";
            this.btnGapExac.Size = new System.Drawing.Size(149, 23);
            this.btnGapExac.TabIndex = 8;
            this.btnGapExac.Text = "GAP Exact";
            this.btnGapExac.UseVisualStyleBackColor = true;
            this.btnGapExac.Click += new System.EventHandler(this.btnGapExact_Click);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exeEsegui,
            this.strumenti,
            this.toolStripMenuItem1});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(619, 24);
            this.mnuMain.TabIndex = 9;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDBToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.toolStripSeparator2,
            this.esciToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openDBToolStripMenuItem
            // 
            this.openDBToolStripMenuItem.Image = global::Heuristics.Properties.Resources.sistemas;
            this.openDBToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openDBToolStripMenuItem.Name = "openDBToolStripMenuItem";
            this.openDBToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openDBToolStripMenuItem.ShowShortcutKeys = false;
            this.openDBToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.openDBToolStripMenuItem.Text = "OpenDB";
            this.openDBToolStripMenuItem.Click += new System.EventHandler(this.openDBToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Image = global::Heuristics.Properties.Resources.Open;
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(139, 6);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.esciToolStripMenuItem.Text = "Esci";
            this.esciToolStripMenuItem.Click += new System.EventHandler(this.esciToolStripMenuItem_Click);
            // 
            // exeEsegui
            // 
            this.exeEsegui.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.euristicaCostruttivaToolStripMenuItem,
            this.vndToolStripMenuItem,
            this.toolStripSeparator1,
            this.simulatedAnnealingToolStripMenuItem,
            this.tabuSearchToolStripMenuItem,
            this.iteratedLocalSearchToolStripMenuItem,
            this.variableNeighborhoodSearchToolStripMenuItem,
            this.gAPExactToolStripMenuItem});
            this.exeEsegui.Enabled = false;
            this.exeEsegui.Name = "exeEsegui";
            this.exeEsegui.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.exeEsegui.Size = new System.Drawing.Size(53, 20);
            this.exeEsegui.Text = "Esegui";
            // 
            // euristicaCostruttivaToolStripMenuItem
            // 
            this.euristicaCostruttivaToolStripMenuItem.Name = "euristicaCostruttivaToolStripMenuItem";
            this.euristicaCostruttivaToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.euristicaCostruttivaToolStripMenuItem.Text = "Euristica Costruttiva";
            this.euristicaCostruttivaToolStripMenuItem.Click += new System.EventHandler(this.euristicaCostruttivaToolStripMenuItem_Click);
            // 
            // vndToolStripMenuItem
            // 
            this.vndToolStripMenuItem.Name = "vndToolStripMenuItem";
            this.vndToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.vndToolStripMenuItem.Text = "Variable Neighborhoode Descend";
            this.vndToolStripMenuItem.Click += new System.EventHandler(this.vndToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(248, 6);
            // 
            // simulatedAnnealingToolStripMenuItem
            // 
            this.simulatedAnnealingToolStripMenuItem.Name = "simulatedAnnealingToolStripMenuItem";
            this.simulatedAnnealingToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.simulatedAnnealingToolStripMenuItem.Text = "Simulated Annealing";
            this.simulatedAnnealingToolStripMenuItem.Click += new System.EventHandler(this.simulatedAnnealingToolStripMenuItem_Click);
            // 
            // tabuSearchToolStripMenuItem
            // 
            this.tabuSearchToolStripMenuItem.Name = "tabuSearchToolStripMenuItem";
            this.tabuSearchToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.tabuSearchToolStripMenuItem.Text = "Tabu Search";
            this.tabuSearchToolStripMenuItem.Click += new System.EventHandler(this.tabuSearchToolStripMenuItem_Click);
            // 
            // iteratedLocalSearchToolStripMenuItem
            // 
            this.iteratedLocalSearchToolStripMenuItem.Name = "iteratedLocalSearchToolStripMenuItem";
            this.iteratedLocalSearchToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.iteratedLocalSearchToolStripMenuItem.Text = "Iterated Local Search";
            this.iteratedLocalSearchToolStripMenuItem.Click += new System.EventHandler(this.iteratedLocalSearchToolStripMenuItem_Click);
            // 
            // variableNeighborhoodSearchToolStripMenuItem
            // 
            this.variableNeighborhoodSearchToolStripMenuItem.Name = "variableNeighborhoodSearchToolStripMenuItem";
            this.variableNeighborhoodSearchToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.variableNeighborhoodSearchToolStripMenuItem.Text = "Variable Neighborhood Search";
            this.variableNeighborhoodSearchToolStripMenuItem.Click += new System.EventHandler(this.variableNeighborhoodSearchToolStripMenuItem_Click);
            // 
            // gAPExactToolStripMenuItem
            // 
            this.gAPExactToolStripMenuItem.Name = "gAPExactToolStripMenuItem";
            this.gAPExactToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.gAPExactToolStripMenuItem.Text = "GAP Exact";
            this.gAPExactToolStripMenuItem.Click += new System.EventHandler(this.gAPExactToolStripMenuItem_Click);
            // 
            // strumenti
            // 
            this.strumenti.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startServerToolStripMenuItem,
            this.stopServerToolStripMenuItem});
            this.strumenti.Enabled = false;
            this.strumenti.Name = "strumenti";
            this.strumenti.Size = new System.Drawing.Size(71, 20);
            this.strumenti.Text = "Strumenti";
            // 
            // startServerToolStripMenuItem
            // 
            this.startServerToolStripMenuItem.Name = "startServerToolStripMenuItem";
            this.startServerToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.startServerToolStripMenuItem.Text = "Start Server";
            this.startServerToolStripMenuItem.Click += new System.EventHandler(this.startServerToolStripMenuItem_Click);
            // 
            // stopServerToolStripMenuItem
            // 
            this.stopServerToolStripMenuItem.Name = "stopServerToolStripMenuItem";
            this.stopServerToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.stopServerToolStripMenuItem.Text = "Stop Server";
            this.stopServerToolStripMenuItem.Click += new System.EventHandler(this.stopServerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.courseSiteToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // courseSiteToolStripMenuItem
            // 
            this.courseSiteToolStripMenuItem.Name = "courseSiteToolStripMenuItem";
            this.courseSiteToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.courseSiteToolStripMenuItem.Text = "Course site";
            this.courseSiteToolStripMenuItem.Click += new System.EventHandler(this.courseSiteToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnFile
            // 
            this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile.ForeColor = System.Drawing.Color.White;
            this.btnFile.Location = new System.Drawing.Point(103, 34);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(69, 23);
            this.btnFile.TabIndex = 10;
            this.btnFile.Text = "Open File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHeuCost);
            this.groupBox1.Controls.Add(this.btnVND);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(17, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eurisitiche";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSA);
            this.groupBox2.Controls.Add(this.btnTabuSearch);
            this.groupBox2.Controls.Add(this.btnILS);
            this.groupBox2.Controls.Add(this.btnVNS);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Location = new System.Drawing.Point(17, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 161);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Metaeuristiche";
            // 
            // bkwHeu
            // 
            this.bkwHeu.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwHeu_DoWork);
            // 
            // frmHeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(619, 364);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnGapExac);
            this.Controls.Add(this.btnOpenDB);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.mnuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmHeu";
            this.Text = "Generalize Assignment Problem";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Button btnOpenDB;
        private System.Windows.Forms.Button btnHeuCost;
        private System.Windows.Forms.Button btnVND;
        private System.Windows.Forms.Button btnSA;
        private System.Windows.Forms.Button btnTabuSearch;
        private System.Windows.Forms.Button btnILS;
        private System.Windows.Forms.Button btnVNS;
        private System.Windows.Forms.Button btnGapExac;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exeEsegui;
        private System.Windows.Forms.ToolStripMenuItem euristicaCostruttivaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulatedAnnealingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabuSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iteratedLocalSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variableNeighborhoodSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gAPExactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem courseSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker bkwHeu;
        private System.Windows.Forms.ToolStripMenuItem strumenti;
        private System.Windows.Forms.ToolStripMenuItem startServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopServerToolStripMenuItem;
    }
}

