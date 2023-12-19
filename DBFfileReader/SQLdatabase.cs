using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFfileReader
{
    internal class SQLdatabase
    {
        public static SqlConnection SQLcon(string server, string user, string password)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = $"Data Source={server}; Initial Catalog=master; User Id={user}; Password={password};";
            try
            {
                sqlCon.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd (SQLdatabase.SQLcon): " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sqlCon;
        }

        public static List<string> databaseList(string server, string user, string password)
        {
            List<string> databaseList = new List<string>();
            databaseList.Add("");
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = SQLcon(server, user, password);
                string question = @"SELECT name
                                    FROM sys.databases
                                    WHERE has_dbaccess(name) = 1 AND name NOT IN ('master', 'tempdb', 'model', 'msdb');";
                SqlCommand command = new SqlCommand(question, sqlConnection);
                SqlDataReader database = command.ExecuteReader();
                while (database.Read())
                {
                    databaseList.Add(database[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd (SQLdatabase.databaseList): " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection?.Close();
            }
            return databaseList;
        }

        public static List<string> tableList(string server, string user, string password, string database)
        {
            List<string> tableList = new List<string>();
            tableList.Add("");
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = SQLcon(server, user, password);
                /*use database;

                SELECT table_name
                FROM INFORMATION_SCHEMA.TABLES
                WHERE table_type = 'BASE TABLE'

                SELECT name
                FROM sys.tables

                SELECT name
                FROM sysobjects
                WHERE xtype = 'U'

                SELECT name
                FROM sys.objects
                WHERE type_desc = 'USER_TABLE'*/
                string question = @"USE " + database + @";
                                    SELECT table_name
                                    FROM INFORMATION_SCHEMA.TABLES
                                    WHERE table_type = 'BASE TABLE'
                                    ORDER BY table_name ASC;";
                SqlCommand command = new SqlCommand(question, sqlConnection);
                SqlDataReader tablelist = command.ExecuteReader();
                while (tablelist.Read())
                {
                    tableList.Add(tablelist[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd (SQLdatabase.tableList): " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection?.Close();
            }
            return tableList;
        }

        public static bool saveToDatabase(string server, string user, string password, string database, string table, DataGridViewRowCollection rows, DataGridViewColumnCollection columns)
        {
            SqlConnection sqlConnection = null;
            sqlConnection = SQLcon(server, user, password);
            SqlTransaction trans = sqlConnection.BeginTransaction();
            try
            {
                string question = string.Empty;
                question = "INSERT INTO [" + database + "].[dbo].[" + table + "] (";
                foreach (DataGridViewColumn column in columns)
                {
                    question += column.HeaderText + ", ";
                }
                question = question.Substring(0, question.Length - 2);
                question += ") VALUES (";
                foreach (DataGridViewColumn column in columns)
                {
                    question += "@" + column.HeaderText + ", ";
                }
                question = question.Substring(0, question.Length - 2);
                question += ");";
                foreach (DataGridViewRow row in rows)
                {
                    MessageBox.Show(question);
                    using (SqlCommand cmd = new SqlCommand(question, sqlConnection, trans))
                    {
                        int i = 0;
                        foreach (DataGridViewColumn column in columns)
                        {
                            cmd.Parameters.AddWithValue("@" + column.HeaderText, row.Cells[i].Value);
                            i++;
                        }
                        i = 0;
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Błąd (SQLdatabase.saveToDatabase): " + ex, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                sqlConnection?.Close();
            }
            return true;
        }
    }
}
