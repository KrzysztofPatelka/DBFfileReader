namespace DBFfileReader
{
    partial class StartWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewDBFfile = new System.Windows.Forms.DataGridView();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.statusStripStartWindow = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBarLoad = new System.Windows.Forms.ToolStripProgressBar();
            this.labelFilePatch = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonExecuteQuery = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonTestConnectDatabase = new System.Windows.Forms.Button();
            this.comboBoxDatabase = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxTable = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonSaveToDatabase = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonSavePanel = new System.Windows.Forms.Button();
            this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDBFfile)).BeginInit();
            this.statusStripStartWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDBFfile
            // 
            this.dataGridViewDBFfile.AllowUserToAddRows = false;
            this.dataGridViewDBFfile.AllowUserToDeleteRows = false;
            this.dataGridViewDBFfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewDBFfile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewDBFfile.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridViewDBFfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDBFfile.Location = new System.Drawing.Point(12, 148);
            this.dataGridViewDBFfile.Name = "dataGridViewDBFfile";
            this.dataGridViewDBFfile.ReadOnly = true;
            this.dataGridViewDBFfile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewDBFfile.Size = new System.Drawing.Size(1083, 443);
            this.dataGridViewDBFfile.TabIndex = 2;
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(15, 96);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(143, 23);
            this.buttonOpenFile.TabIndex = 3;
            this.buttonOpenFile.Text = "Otwórz plik DBF";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // statusStripStartWindow
            // 
            this.statusStripStartWindow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBarLoad,
            this.toolStripStatusLabelUser});
            this.statusStripStartWindow.Location = new System.Drawing.Point(0, 594);
            this.statusStripStartWindow.Name = "statusStripStartWindow";
            this.statusStripStartWindow.Size = new System.Drawing.Size(1398, 22);
            this.statusStripStartWindow.TabIndex = 0;
            this.statusStripStartWindow.Text = "statusStrip1";
            // 
            // toolStripProgressBarLoad
            // 
            this.toolStripProgressBarLoad.Name = "toolStripProgressBarLoad";
            this.toolStripProgressBarLoad.Size = new System.Drawing.Size(500, 16);
            // 
            // labelFilePatch
            // 
            this.labelFilePatch.AutoSize = true;
            this.labelFilePatch.Location = new System.Drawing.Point(164, 101);
            this.labelFilePatch.Name = "labelFilePatch";
            this.labelFilePatch.Size = new System.Drawing.Size(73, 13);
            this.labelFilePatch.TabIndex = 4;
            this.labelFilePatch.Text = "labelFilePatch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Zapytanie";
            // 
            // textBoxQuery
            // 
            this.textBoxQuery.Location = new System.Drawing.Point(15, 25);
            this.textBoxQuery.Multiline = true;
            this.textBoxQuery.Name = "textBoxQuery";
            this.textBoxQuery.Size = new System.Drawing.Size(1080, 65);
            this.textBoxQuery.TabIndex = 6;
            this.textBoxQuery.Text = "SELECT * FROM ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Wynik zapytania:";
            // 
            // buttonExecuteQuery
            // 
            this.buttonExecuteQuery.Location = new System.Drawing.Point(880, 96);
            this.buttonExecuteQuery.Name = "buttonExecuteQuery";
            this.buttonExecuteQuery.Size = new System.Drawing.Size(215, 23);
            this.buttonExecuteQuery.TabIndex = 8;
            this.buttonExecuteQuery.Text = "Wykonaj zapytanie";
            this.buttonExecuteQuery.UseVisualStyleBackColor = true;
            this.buttonExecuteQuery.Click += new System.EventHandler(this.buttonExecuteQuery_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1129, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Serwer bazy danych (MS SQL):";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(1129, 54);
            this.textBoxServer.MaxLength = 100;
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(259, 20);
            this.textBoxServer.TabIndex = 10;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(1129, 96);
            this.textBoxUser.MaxLength = 50;
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(259, 20);
            this.textBoxUser.TabIndex = 11;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(1129, 136);
            this.textBoxPassword.MaxLength = 50;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(259, 20);
            this.textBoxPassword.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1129, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nazwa użytkownika:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1129, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Hasło użytkownika:";
            // 
            // buttonTestConnectDatabase
            // 
            this.buttonTestConnectDatabase.Location = new System.Drawing.Point(1129, 162);
            this.buttonTestConnectDatabase.Name = "buttonTestConnectDatabase";
            this.buttonTestConnectDatabase.Size = new System.Drawing.Size(259, 23);
            this.buttonTestConnectDatabase.TabIndex = 15;
            this.buttonTestConnectDatabase.Text = "Połącz";
            this.buttonTestConnectDatabase.UseVisualStyleBackColor = true;
            this.buttonTestConnectDatabase.Click += new System.EventHandler(this.buttonTestConnectDatabase_Click);
            // 
            // comboBoxDatabase
            // 
            this.comboBoxDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDatabase.FormattingEnabled = true;
            this.comboBoxDatabase.Location = new System.Drawing.Point(1129, 207);
            this.comboBoxDatabase.Name = "comboBoxDatabase";
            this.comboBoxDatabase.Size = new System.Drawing.Size(259, 21);
            this.comboBoxDatabase.TabIndex = 16;
            this.comboBoxDatabase.SelectedIndexChanged += new System.EventHandler(this.comboBoxDatabase_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1129, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Baza danych:";
            // 
            // comboBoxTable
            // 
            this.comboBoxTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTable.FormattingEnabled = true;
            this.comboBoxTable.Location = new System.Drawing.Point(1129, 250);
            this.comboBoxTable.Name = "comboBoxTable";
            this.comboBoxTable.Size = new System.Drawing.Size(259, 21);
            this.comboBoxTable.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1129, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Tabela bazy danych:";
            // 
            // buttonSaveToDatabase
            // 
            this.buttonSaveToDatabase.Location = new System.Drawing.Point(1126, 290);
            this.buttonSaveToDatabase.Name = "buttonSaveToDatabase";
            this.buttonSaveToDatabase.Size = new System.Drawing.Size(262, 23);
            this.buttonSaveToDatabase.TabIndex = 20;
            this.buttonSaveToDatabase.Text = "Zapisz do bazy";
            this.buttonSaveToDatabase.UseVisualStyleBackColor = true;
            this.buttonSaveToDatabase.Click += new System.EventHandler(this.buttonSaveToDatabase_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(1198, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Zapisz do bazy danych";
            // 
            // buttonSavePanel
            // 
            this.buttonSavePanel.Location = new System.Drawing.Point(1101, 12);
            this.buttonSavePanel.Name = "buttonSavePanel";
            this.buttonSavePanel.Size = new System.Drawing.Size(20, 579);
            this.buttonSavePanel.TabIndex = 22;
            this.buttonSavePanel.Text = "<";
            this.buttonSavePanel.UseVisualStyleBackColor = true;
            this.buttonSavePanel.Click += new System.EventHandler(this.buttonSavePanel_Click);
            // 
            // toolStripStatusLabelUser
            // 
            this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            this.toolStripStatusLabelUser.Size = new System.Drawing.Size(135, 17);
            this.toolStripStatusLabelUser.Text = "toolStripStatusLabelUser";
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 616);
            this.Controls.Add(this.buttonSavePanel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonSaveToDatabase);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxTable);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxDatabase);
            this.Controls.Add(this.buttonTestConnectDatabase);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.textBoxServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonExecuteQuery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxQuery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelFilePatch);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.dataGridViewDBFfile);
            this.Controls.Add(this.statusStripStartWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StartWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBF file reader";
            this.Load += new System.EventHandler(this.StartWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDBFfile)).EndInit();
            this.statusStripStartWindow.ResumeLayout(false);
            this.statusStripStartWindow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewDBFfile;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.StatusStrip statusStripStartWindow;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarLoad;
        private System.Windows.Forms.Label labelFilePatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonExecuteQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonTestConnectDatabase;
        private System.Windows.Forms.ComboBox comboBoxDatabase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxTable;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonSaveToDatabase;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSavePanel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
    }
}

