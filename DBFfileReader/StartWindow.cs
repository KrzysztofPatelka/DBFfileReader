using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.IO;
using System.Reflection.Emit;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;

namespace DBFfileReader
{
    public partial class StartWindow : Form
    {
        private string dbfFilePath;
        private string connectionString;
        private string query;
        private bool showSavePanel;

        public StartWindow()
        {
            InitializeComponent();
        }

        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogDBFfile = new OpenFileDialog
            {
                InitialDirectory = @Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                Title = "Plik DBF",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "dbf",
                Filter = "pliki dbf (*.dbf)|*.dbf",
                FilterIndex = 1,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = false,
                Multiselect = false,
            };

            if (openFileDialogDBFfile.ShowDialog() == DialogResult.OK)
            {
                dbfFilePath = @openFileDialogDBFfile.FileName;
                connectionString = $"Provider=VFPOLEDB;Data Source={dbfFilePath}";
                query = $"SELECT * FROM {Path.GetFileName(dbfFilePath)} WHERE nr_akcji LIKE '23%'";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        try
                        {
                            connection.Open();
                            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            //MessageBox.Show(dataTable.Rows.Count.ToString());
                            toolStripProgressBarLoad.Maximum = dataTable.Rows.Count;

                            foreach (DataColumn col in dataTable.Columns)
                            {
                                dataGridViewDBFfile.Columns.Add(col.ColumnName, col.ColumnName);
                                //MessageBox.Show(col.ColumnName.ToString() + " : " + col.GetType().ToString(), "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            string[] rowAdd = new string[dataTable.Columns.Count];


                            Task.Run(() =>
                            {
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    for (int i = 0; i < dataTable.Columns.Count; i++)
                                    {
                                        rowAdd[i] = row[i].ToString();
                                    }
                                    Invoke(new Action(delegate () {
                                        dataGridViewDBFfile.Rows.Add(rowAdd);
                                        toolStripProgressBarLoad.Value++;
                                    }));

                                }
                            });

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }




        }

        private void StartWindow_Load(object sender, EventArgs e)
        {
            this.Text = "DBF file reader - wersja: " + Application.ProductVersion + " (kompilacja: " + System.IO.File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location) + ")";
            toolStripStatusLabelUser.Text = "Użytkownik: " + UserPrincipal.Current.DisplayName;
            labelFilePatch.Text = string.Empty;
            dbfFilePath = string.Empty;
            connectionString = string.Empty;
            query = string.Empty;
            showSavePanel = false;
            enabledDisabledPanel();
        }

        private void enabledDisabledPanel()
        {
            if (showSavePanel)
            {
                buttonSavePanel.Text = "<";
                textBoxServer.Enabled = true;
                textBoxServer.Text = "";
                textBoxPassword.Enabled = true;
                textBoxPassword.Text = "";
                buttonTestConnectDatabase.Enabled = true;
                comboBoxDatabase.Enabled = true;
                comboBoxDatabase.Items.Clear();
                comboBoxTable.Enabled = true;
                comboBoxTable.Items.Clear();
                buttonSaveToDatabase.Enabled = true;
                this.Size = new Size(1414, this.Size.Height);
            }
            else
            {
                buttonSavePanel.Text = ">";
                textBoxServer.Enabled = false;
                textBoxServer.Text = "";
                textBoxPassword.Enabled = false;
                textBoxPassword.Text = "";
                buttonTestConnectDatabase.Enabled = false;
                comboBoxDatabase.Enabled = false;
                comboBoxDatabase.Items.Clear();
                comboBoxTable.Enabled = false;
                comboBoxTable.Items.Clear();
                buttonSaveToDatabase.Enabled = false;
                this.Size = new Size(1145, this.Size.Height);
            }
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogDBFfile = new OpenFileDialog
            {
                InitialDirectory = @Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                Title = "Plik DBF",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "dbf",
                Filter = "pliki dbf (*.dbf)|*.dbf",
                FilterIndex = 1,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = false,
                Multiselect = false,
            };
            if (openFileDialogDBFfile.ShowDialog() == DialogResult.OK)
            {
                dbfFilePath = @openFileDialogDBFfile.FileName;
                labelFilePatch.Text = dbfFilePath;
                textBoxQuery.Text = $"SELECT * FROM {Path.GetFileName(dbfFilePath)}";
            }
            if (dbfFilePath != string.Empty)
            {
                foreach (string col in dbfFile.getColumnName(dbfFilePath))
                {
                    dataGridViewDBFfile.Columns.Add(col, col);
                }
            }
        }

        private void buttonExecuteQuery_Click(object sender, EventArgs e)
        {
            dataGridViewDBFfile.Rows.Clear();
            dataGridViewDBFfile.Columns.Clear();
            DataTable dataTable = new DataTable();
            dataTable = dbfFile.getDataFromQuery(dbfFilePath, textBoxQuery.Text);
            if (dataTable != null )
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    dataGridViewDBFfile.Columns.Add(col.ColumnName, col.ColumnName);
                }
                string[] rowAdd = new string[dataTable.Columns.Count];
                toolStripProgressBarLoad.Value = 0;
                toolStripProgressBarLoad.Maximum = dataTable.Rows.Count;
                //MessageBox.Show(dataTable.Rows.Count.ToString());
                Task.Run(() =>
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            rowAdd[i] = row[i].ToString();
                        }
                        Invoke(new Action(delegate () {
                            dataGridViewDBFfile.Rows.Add(rowAdd);
                            toolStripProgressBarLoad.Value++;
                        }));
                    }
                });
            }
        }

        private void buttonSavePanel_Click(object sender, EventArgs e)
        {
            showSavePanel = !showSavePanel;
            enabledDisabledPanel();
        }

        private void buttonTestConnectDatabase_Click(object sender, EventArgs e)
        {
            if (textBoxServer.Text != "" && textBoxUser.Text != "" && textBoxPassword.Text != "")
            {
                SqlConnection sqlConnection = null;
                sqlConnection = SQLdatabase.SQLcon(textBoxServer.Text, textBoxUser.Text, textBoxPassword.Text);
                if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                    comboBoxDatabase.Items.Clear();
                    foreach (string databaseList in SQLdatabase.databaseList(textBoxServer.Text, textBoxUser.Text, textBoxPassword.Text))
                    {
                        comboBoxDatabase.Items.Add(databaseList);
                    }
                }
                else
                {
                    MessageBox.Show("Brak połaczenia z serwerem bazy danych. Sprawdź poprawność danych logowania.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Proszę uzupełnić poprawne dane: serwer bazy danych, nazwę użytkownika, hasło użytkownika.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBoxDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDatabase.GetItemText(comboBoxDatabase.SelectedItem) == "")
            {
                comboBoxTable.Items.Clear();
            }
            else
            {
                comboBoxTable.Items.Clear();
                foreach (string tableList in SQLdatabase.tableList(textBoxServer.Text, textBoxUser.Text, textBoxPassword.Text, comboBoxDatabase.GetItemText(comboBoxDatabase.SelectedItem)))
                {
                    comboBoxTable.Items.Add(tableList);
                }
            }
        }

        private void buttonSaveToDatabase_Click(object sender, EventArgs e)
        {
            if (textBoxServer.Text != "" && textBoxUser.Text != "" && textBoxPassword.Text != "" && comboBoxDatabase.GetItemText(comboBoxDatabase.SelectedItem) != "" && comboBoxTable.GetItemText(comboBoxTable.SelectedItem) != "")
            {
                if (SQLdatabase.saveToDatabase(textBoxServer.Text, textBoxUser.Text, textBoxPassword.Text, comboBoxDatabase.GetItemText(comboBoxDatabase.SelectedItem), comboBoxTable.GetItemText(comboBoxTable.SelectedItem), dataGridViewDBFfile.Rows, dataGridViewDBFfile.Columns))
                {
                    MessageBox.Show("Dane zostały poprawnie zapisane do bazy danych: " + comboBoxDatabase.GetItemText(comboBoxDatabase.SelectedItem) + "." + comboBoxTable.GetItemText(comboBoxTable.SelectedItem), "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bład zapisu do bazy danych, sprawdź ustawienia połączenia i poświadczenia logowania wraz z uprawnieniami.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Uzupełnij poprawne nastepujące dane: serwer bazy danych, nazwę użytkownika, hasło użytkownika, bazę danych oraz tabelę bazy danych.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
