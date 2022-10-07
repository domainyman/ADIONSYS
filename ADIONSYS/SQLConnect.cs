using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using Npgsql.Internal;
using System.Data;
using System.Net;
using ADIONSYS.ConvertFunction;
using ADIONSYS.Tool;
using System.Xml.Linq;
using Windows.Storage.Streams;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ADIONSYS
{
    internal class SQLConnect
    {
        private static SQLConnect? instance;

        public static SQLConnect Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLConnect();
                }
                return instance;
            }
        }


        public Task StartupConnect()
        {
            if (ApplicationSetting.Default.DataBaseAddress == string.Empty)
            {
                ApplicationSetting.Default.ConnectionState = false;
                ApplicationSetting.Default.Save();
                return Task.CompletedTask;
            }
            else
            {
                ApplicationSetting.Default.ConnectionState = true;
                ApplicationSetting.Default.Save();
                return Task.CompletedTask;
            }
        }

        public Task CheckConnectDataBaseAddress(string Address)
        {
            try
            {
                NpgsqlConnection ChecknpgsqlConnection = new NpgsqlConnection(Address);
                ChecknpgsqlConnection.Open();
                if (ChecknpgsqlConnection.State == ConnectionState.Open)
                {
                    ApplicationSetting.Default.ConnectionState = true;
                    ApplicationSetting.Default.Save();
                    ChecknpgsqlConnection.Close();
                    //MessageBox.Show("Database connect success", "Message", MessageBoxButtons.OK);
                    return Task.CompletedTask;
                }
                else
                {
                    ApplicationSetting.Default.ConnectionState = false;
                    ApplicationSetting.Default.Save();
                    ChecknpgsqlConnection.Close();
                    //MessageBox.Show("Warning : System is having trouble connecting to the SQL servers .", "Message",MessageBoxButtons.OK);
                    return Task.CompletedTask;
                }
            }
            catch (Exception)
            {
                ApplicationSetting.Default.ConnectionState = false;
                ApplicationSetting.Default.Save();
                //MessageBox.Show("Warning : System is having trouble connecting to the SQL servers .", "Message", MessageBoxButtons.OK);
                return Task.CompletedTask;
            }
        }

        public bool TestConnectDataBaseAddress(string Address)
        {
            try
            {
                NpgsqlConnection TestnpgsqlConnection = new NpgsqlConnection(Address);
                TestnpgsqlConnection.Open();
                if (TestnpgsqlConnection.State == ConnectionState.Open)
                {
                    TestnpgsqlConnection.Close();
                    TestnpgsqlConnection.Dispose();
                    return true;
                }
                else
                {
                    TestnpgsqlConnection.Close();
                    TestnpgsqlConnection.Dispose();
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool ConnectState()
        {
            try
            {
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(ApplicationSetting.Default.DataBaseAddress);
                npgsqlConnection.Open();
                if (npgsqlConnection.State == ConnectionState.Open)
                {
                    npgsqlConnection.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
                return false;
            }
        }

        public void PgSQL_ResetTableID(string column,string table,string schemas)
        {
            try
            {
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(ApplicationSetting.Default.DataBaseAddress);
                npgsqlConnection.Open();
                if (npgsqlConnection.State == ConnectionState.Open)
                {
                    string columnname = schemas + "." + table + "_" + column + "_seq";
                    string tablefullname = schemas + "." + table;
                    string Cmd = "SELECT setval('"+ columnname+ "', (SELECT max("+ column+") from "+ tablefullname+")); ";
                    NpgsqlCommand command = new NpgsqlCommand(Cmd, npgsqlConnection);
                    command.ExecuteNonQuery();
                    npgsqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
            }
            

        }

        public Task PgSQL_Command(string Cmd)
        {
            try
            {
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(ApplicationSetting.Default.DataBaseAddress);
                npgsqlConnection.Open();
                if (npgsqlConnection.State == ConnectionState.Open)
                {
                    NpgsqlCommand command = new NpgsqlCommand(Cmd, npgsqlConnection);
                    command.ExecuteNonQuery();
                    npgsqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
            }
            return Task.CompletedTask;

        }
        public List<string> PgSQL_SELECTDataString(string Cmd)
        {
            List<string> result = new List<string>();
            try
            {
                
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(ApplicationSetting.Default.DataBaseAddress);
                npgsqlConnection.Open();
                if (npgsqlConnection.State == ConnectionState.Open)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(Cmd, npgsqlConnection);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result.Add(reader.GetString(i));
                            }
                        }
                    }
                    npgsqlConnection.Close();
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
                return result;
            }
        }

        public string PgSQL_SELECTDataStringsinglel(string Cmd)
        {
            string result = string.Empty;
            try
            {
                //string result;
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(ApplicationSetting.Default.DataBaseAddress);
                npgsqlConnection.Open();
                if (npgsqlConnection.State == ConnectionState.Open)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(Cmd, npgsqlConnection);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result = reader.GetString(i);
                            }
                        }
                    }
                    npgsqlConnection.Close();
                    return result;

                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
                return result;
            }
        }

        public List<int> PgSQL_SELECTDataint(string Cmd)
        {
            List<int> result = new List<int>();
            try
            {
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(ApplicationSetting.Default.DataBaseAddress);
                npgsqlConnection.Open();
                if (npgsqlConnection.State == ConnectionState.Open)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(Cmd, npgsqlConnection);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result.Add(reader.GetInt32(i));
                            }
                        }
                    }
                    npgsqlConnection.Close();
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
                return result;
            }
        }

        public int PgSQL_SELECTDataintsingle(string Cmd)
        {
            int result = 0;
            try
            {
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(ApplicationSetting.Default.DataBaseAddress);
                npgsqlConnection.Open();
                if (npgsqlConnection.State == ConnectionState.Open)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(Cmd, npgsqlConnection);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result = reader.GetInt32(i);
                            }
                        }
                    }
                    npgsqlConnection.Close();
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
                return result;

            }
        }

        public List<decimal> PgSQL_SELECTDataDecimal(string Cmd)
        {
            List<decimal> result = new List<decimal>();
            try
            {
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(ApplicationSetting.Default.DataBaseAddress);
                npgsqlConnection.Open();
                if (npgsqlConnection.State == ConnectionState.Open)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(Cmd, npgsqlConnection);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result.Add(reader.GetDecimal(i));
                            }
                        }
                    }
                    npgsqlConnection.Close();
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
                return result;
            }
        }


        public decimal PgSQL_SELECTDataDecimalsingle(string Cmd)
        {
            decimal result = 0;
            try
            {
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(ApplicationSetting.Default.DataBaseAddress);
                npgsqlConnection.Open();
                if (npgsqlConnection.State == ConnectionState.Open)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(Cmd, npgsqlConnection);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result = reader.GetDecimal(i);
                            }
                        }
                    }
                    npgsqlConnection.Close();
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
                return result;
            }
        }

        public List<DateTime> PgSQL_SELECTDataDateTime(string Cmd)
        {
            List<DateTime> result = new List<DateTime>();
            try
            {

                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(ApplicationSetting.Default.DataBaseAddress);
                npgsqlConnection.Open();
                if (npgsqlConnection.State == ConnectionState.Open)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(Cmd, npgsqlConnection);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result.Add(reader.GetDateTime(i));
                            }
                        }
                    }
                    npgsqlConnection.Close();
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
                return result;
            }
        }

        public bool PgSQL_SELECTDataBool(string Cmd)
        {
            bool result = new bool();
            try
            {
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(ApplicationSetting.Default.DataBaseAddress);
                npgsqlConnection.Open();
                if (npgsqlConnection.State == ConnectionState.Open)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(Cmd, npgsqlConnection);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result = (reader.GetBoolean(i));
                            }
                        }
                    }
                    npgsqlConnection.Close();
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
                return result;
            }
        }

        public void LoadDateView(DataGridView dataGridView,string Cmd)
        {
            try
            {
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(ApplicationSetting.Default.DataBaseAddress);
                npgsqlConnection.Open();
                if (npgsqlConnection.State == ConnectionState.Open)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(Cmd, npgsqlConnection);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView.DataSource = dataTable;
                    }
                    else
                    {
                        DataTable dataTable = new DataTable();
                        //DataRow row = dataTable.NewRow();
                        //dataGridView.Rows.Add(row);
                        
                        dataGridView.DataSource = dataTable;


                    }
                    npgsqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
            }
        }

        public DataTable LoadDateTableStorage(string Cmd)
        {
            DataTable dataTable = new DataTable();
            try
            {
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(ApplicationSetting.Default.DataBaseAddress);
                npgsqlConnection.Open();
                if (npgsqlConnection.State == ConnectionState.Open)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(Cmd, npgsqlConnection);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dataTable.Load(reader);
                    }                 
                    npgsqlConnection.Close();
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
                return dataTable;
            }
        }

    }
}
