using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFfileReader
{
    internal class dbfFile
    {
        public static List<string> getColumnName(string dbfFilePath)
        {
            List<string> columnName = new List<string>();
            string connectionString = $"Provider=VFPOLEDB;Data Source={dbfFilePath}";
            string query = $"SELECT TOP 1 * FROM {Path.GetFileName(dbfFilePath)} ORDER BY 0";
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
                        foreach (DataColumn col in dataTable.Columns)
                        {
                            columnName.Add(col.ColumnName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd dbfFile.getColumnName: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return columnName;
        }

        public static DataTable getDataFromQuery(string dbfFilePath, string query)
        {
            //MessageBox.Show(dbfFilePath);
            //MessageBox.Show(query);
            DataTable dataTable = new DataTable();
            string connectionString = $"Provider=VFPOLEDB;Data Source={dbfFilePath}";
            //query = $"SELECT * FROM {Path.GetFileName(dbfFilePath)} WHERE nr_akcji LIKE '23%'";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd dbfFile.getDataFromQuery: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return dataTable;
        }
    }
}
