using ADIONSYS.ConvertFunction;
using ADIONSYS.Plugin.POS.Warehose.Storage.Transfer;
using ADIONSYS.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Graphics.Printing;

namespace ADIONSYS.Plugin.POS.Retail
{
    public partial class RetailForm : Form
    {

        public Dictionary<string, List<string>> SNDic = new Dictionary<string, List<string>>();
        public DataTable ConfirmdataTable = new DataTable();
        public RetailForm()
        {
            InitializeComponent();
            LoadingForm();
        }

        private void LoadingForm()
        {
            SetupClient();
            ShowTime();
            ShowStorage();
            ShowUser();
            LoadTable();
            SetupConfirmdataTable();
            
        }

        private int LoadStorage_id()
        {
            return SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT storage_id FROM productstorage.storage WHERE storage_name='" + ApplicationSetting.Default.Location + "'");
        }

        private void LoadTable()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {

                int sid = LoadStorage_id();
                string storageschemaname = "\"" + "productlibrary" + "\"";
                string tablenameSUM = "\"" + "product_sum" + "\"";
                string droptablesumname = storageschemaname + "." + tablenameSUM;
                DataTable ProductSUM = SQLConnect.Instance.LoadDateTableStorage("SELECT product_id,model,name,srp,qty,comment FROM " + droptablesumname + " WHERE state = true ORDER BY name");

                int TableRow = ProductSUM.Rows.Count;
                for (int i = 0; i < TableRow; i++)
                {
                    var product_id = Convert.ToInt64(ProductSUM.Rows[i][0]);
                    string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + product_id + "");
                    string hash_database = storageschemaname + ".\"" + result_hash_name + "\"";
                    int storage_qty = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT COALESCE(SUM(qty),0) FROM " + hash_database + " WHERE storage_id='" + sid + "' AND status = 1");
                    if (storage_qty != 0)
                    {
                        ProductSUM.Rows[i][4] = storage_qty;
                    }
                    else if (storage_qty == 0)
                    {
                        ProductSUM.Rows[i][4] = 0;
                    }
                }
                SearchGridView.DataSource = ProductSUM;
                StartupTable();
            }
        }

        private void StartupTable()
        {
            if (SearchGridView.ColumnCount > 0)
            {
                SearchGridView.Columns[0].HeaderText = "ID";
                SearchGridView.Columns[0].FillWeight = 25;
                SearchGridView.Columns[1].HeaderText = "Product Model";
                SearchGridView.Columns[1].FillWeight = 50;
                SearchGridView.Columns[2].HeaderText = "Product Name";
                SearchGridView.Columns[3].HeaderText = "SRP";
                SearchGridView.Columns[3].FillWeight = 50;
                SearchGridView.Columns[3].DefaultCellStyle.Format = "N2";


                SearchGridView.Columns[4].HeaderText = "QTY";
                SearchGridView.Columns[4].FillWeight = 50;
                SearchGridView.Columns[5].HeaderText = "Description";
            }

        }

        private void SetupClient()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> resultClient = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT member_number FROM storagemember.member");
                CMBClient.DataSource = resultClient;
                CMBClient.SelectedIndex = -1;
            }
        }

        private void ShowTime ()
        {
            textDate.Text = ConvertType.GetTimeStamp();
        }

        private void ShowStorage()
        {
            textStorage.Text = ApplicationSetting.Default.Location;
        }
        private void ShowUser()
        {
            textsalesman.Text = ApplicationSetting.Default.User;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            ClientList ClientList = new();
            ClientList.ShowDialog();
            if(ClientList.TextMsg != null && ClientList.TextMsg_id != null)
            {
                CMBClient.SelectedItem = ClientList.TextMsg;
                LBClientID.Text = ClientList.TextMsg_id.ToString();
            }

        }

        private void Btnclientinfo_Click(object sender, EventArgs e)
        {
            if(CMBClient.Text != string.Empty && CheckClient_Name() == true && SQLConnect.Instance.ConnectState() == true)
            {
                int result_member_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT member_id FROM storagemember.member WHERE member_number='" + CMBClient.Text + "'");
                ClientInfo ClientInfo = new(result_member_id);
                ClientInfo.ShowDialog();
            }
        }

        private bool CheckClient_Name()
        {
            bool done = false;
            if (CMBClient.Text != string.Empty && SQLConnect.Instance.ConnectState() == true )
            {
                List<string> resultClient = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT member_number FROM storagemember.member");
                if(resultClient.Contains(CMBClient.Text))
                {
                    done = true;
                    
                }
            }
            return done;

        }

        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CMBClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            int result_member_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT member_id FROM storagemember.member WHERE member_number='" + CMBClient.Text + "'");
            LBClientID.Text = result_member_id.ToString();
            textpayterms.Text = ShowTerms();
            textmethod.Text = ShowMethod();
        }

        private void SearchGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    textQty.Text = string.Empty;
                    DataGridViewRow Row = SearchGridView.Rows[e.RowIndex];
                    TextProduct_id.Text = Row.Cells[0].Value.ToString();
                    textpro_name.Text = Row.Cells[2].Value.ToString();
                    textsrp.Text = Row.Cells[3].Value.ToString();
                    textstock.Text = Row.Cells[4].Value.ToString();
                    textQty.Focus();
                }
                catch (Exception ex)
                {
                    MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                    MessageBox_text.ShowDialog();

                }

            }
        }

        private void SetupConfirmdataTable()
        {
            ConfirmGridView1.DataSource = ConfirmdataTable;
            //DataColumn IDColumn = ConfirmdataTable.Columns.Add("Item", typeof(int));

            //ConfirmdataTable.PrimaryKey = new DataColumn[]
            //{
            //        ConfirmdataTable.Columns["Item"]
            //};
            //IDColumn.AutoIncrement = true;
            //IDColumn.AutoIncrementSeed = 1;
            //IDColumn.AutoIncrementStep = 1;

            //ConfirmGridView1.Columns["Item"].FillWeight = 30;
            ConfirmdataTable.Columns.Add("ID", typeof(int));
            ConfirmGridView1.Columns["ID"].FillWeight = 25;
            ConfirmdataTable.Columns.Add("Product Model", typeof(string));
            ConfirmdataTable.Columns.Add("Product Name", typeof(string));
            
            ConfirmdataTable.Columns.Add("SRP", typeof(decimal));
            ConfirmdataTable.Columns.Add("QTY", typeof(int));
            ConfirmGridView1.Columns["QTY"].FillWeight = 50;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                FlatStyle = FlatStyle.Flat,
                HeaderText = "Serial Number",
                Text = "Click Here Insert",
                Name = "btn",
                UseColumnTextForButtonValue = true
            };
            ConfirmGridView1.Columns.Add(btn);
        }

        private void BtnShippingInsert_Click(object sender, EventArgs e)
        {

        }

        private int Check_qty(int prod_id)
        {
            int sid = Restorage_id();
            int product_id = prod_id;
            string storageschemaname = "\"" + "productlibrary" + "\"";
            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + product_id + "");
            string hash_database = storageschemaname + ".\"" + result_hash_name + "\"";
            int storage_qty = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT COALESCE(SUM(qty),0) FROM " + hash_database + " WHERE storage_id='" + sid + "'");
            int qty = storage_qty;
            return qty;
        }

        private bool CheckConfirmdataTableItem(int pro_id)
        {
            bool result = false;
            List<bool> bools = new List<bool>();
            if (ConfirmGridView1.RowCount > 0)
            {
                for (int i = 0; i < ConfirmGridView1.RowCount; i++)
                {
                    int produ_id = (int)ConfirmGridView1.Rows[i].Cells[1].Value;
                    if (pro_id == produ_id)
                    {
                        bools.Add(true);
                    }
                    else
                    {
                        bools.Add(false);
                    }
                }
                if (bools.Contains(true))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        private void UploadConfirmdataTablem(int pro_id, int upl_qty)
        {
            if (ConfirmGridView1.RowCount > 0)
            {
                foreach (DataGridViewRow Row_Data in ConfirmGridView1.Rows)
                {
                    int Row_id = Convert.ToInt32(Row_Data.Cells[1].Value);
                    if (Row_id == pro_id)
                    {
                        int Confint = Convert.ToInt32(Row_Data.Cells[5].Value);
                        int RenewQty = upl_qty + Confint;
                        if (RenewQty <= Check_qty(pro_id))
                        {
                            Row_Data.Cells[5].Value = RenewQty;
                        }
                        else
                        {
                            MessageInfo MessageBox_text = new MessageInfo("Shortage of Stock");
                            MessageBox_text.ShowDialog();
                        }
                    }

                }
            }
        }

        private void UploadDicSN(int product_id, int qty, int sid)
        {
            foreach (DataGridViewRow Row_Data in ConfirmGridView1.Rows)
            {
                int Row_id = Convert.ToInt32(Row_Data.Cells[1].Value);
                if (Row_id == product_id)
                {
                    string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + product_id + "");
                    int SNBaseCount = SNDic[result_hash_name].Count;
                    int renewqty = SNBaseCount + qty;
                    if (renewqty <= Check_qty(product_id))
                    {
                        string storageschemaname = "\"" + "productlibrary" + "\"";
                        string hash_database = storageschemaname + ".\"" + result_hash_name + "\"";
                        List<string> list = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT sn FROM " + hash_database + " WHERE storage_id = " + sid + " AND state = true AND status = 1 ORDER BY purchese_day ASC LIMIT " + renewqty);
                        SNDic[result_hash_name] = list;
                    }
                    else
                    {
                        MessageInfo MessageBox_text = new MessageInfo("Shortage of Stock");
                        MessageBox_text.ShowDialog();
                    }
                }

            }
        }

        private void CreateDicSN(int product_id, int qty, int sid)
        {

            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + product_id + "");
            string storageschemaname = "\"" + "productlibrary" + "\"";
            string hash_database = storageschemaname + ".\"" + result_hash_name + "\"";
            List<string> list = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT sn FROM " + hash_database + " WHERE storage_id = " + sid + " AND state = true AND status = 1 ORDER BY purchese_day ASC LIMIT " + qty);
            SNDic.Add(result_hash_name, list);
        }

        private void BtnToConfirm_Click(object sender, EventArgs e)
        {
            if (CMBClient.Text == string.Empty)
            {
                CMBClient.SelectedItem = "WALK IN";
            }
            if (textQty.Text == string.Empty)
            {
                textQty.Text = "0";
            }
            int qty = Convert.ToInt32(textQty.Text);
            if (qty <= 0)
            {
                MessageInfo MessageBox_text = new MessageInfo("QTY Input Error");
                MessageBox_text.ShowDialog();
            }
            else
            {
                if (textQty.Text != string.Empty && CMBClient.Text != string.Empty && TextProduct_id.Text != string.Empty) 
                {
                    try
                    {
                        if (SQLConnect.Instance.ConnectState() == true)
                        {
                            int storage_id = Restorage_id();
                            int user = Reuser_id();
                            int product_id = Convert.ToInt32(TextProduct_id.Text);
                            int Databaseqty = Check_qty(product_id);
                            if (Databaseqty >= qty)
                            {
                                bool include = CheckConfirmdataTableItem(product_id);
                                if (include == true)
                                {
                                    UploadConfirmdataTablem(product_id, qty);
                                    UploadDicSN(product_id, qty, storage_id);
                                }
                                else
                                {
                                    DataRow row = ConfirmdataTable.NewRow();
                                    List<string> resultProduct = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT model,name FROM productlibrary.product_sum WHERE product_id=" + product_id);
                                    decimal result_srp = SQLConnect.Instance.PgSQL_SELECTDataDecimalsingle("SELECT srp FROM productlibrary.product_sum WHERE product_id='" + product_id + "'");
                                    row[0] = product_id;
                                    row[1] = resultProduct[0];
                                    row[2] = resultProduct[1];
                                    row[3] = result_srp;
                                    row[4] = qty;
                                    ConfirmdataTable.Rows.Add(row);
                                    CreateDicSN(product_id, qty, storage_id);
                                }
                                //List<string> keyList = new List<string>(SNDic.Keys);
                                //for (int i = 0; i < keyList.Count; i++)
                                //{
                                //    Console.WriteLine(keyList[i]);
                                //    for (int j = 0; j < SNDic[keyList[i]].Count; j++)
                                //        Console.WriteLine(SNDic[keyList[i]][j]);


                                //}
                                if (ConfirmGridView1.RowCount > 0)
                                {
                                    ClearProd_table();

                                    decimal Amount = ShowAmount();
                                    decimal tax = ShowTax();
                                    decimal total = Amount + tax;
                                    texttotalamount.Text = Amount.ToString();
                                    texttotalqty.Text = ShowQty().ToString();
                                }
                            }
                            else
                            {
                                MessageInfo MessageBox_text = new MessageInfo("Shortage of Stock");
                                MessageBox_text.ShowDialog();
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                        MessageBox_text.ShowDialog();

                    }
                }
            }


        }

        private int ShowQty()
        {
            List<int> Amountqty = new();
            foreach (DataGridViewRow Row_Data in ConfirmGridView1.Rows)
            {
                int qty = (int)Row_Data.Cells[5].Value;
                Amountqty.Add(qty);

            }
            return Amountqty.Sum();
        }

        private decimal ShowTax()
        {
            decimal balance = 0;
            if (texttax.Text != string.Empty)
            {
                balance = Convert.ToDecimal(texttax.Text);
            }
            return balance;
        }

        private decimal ShowAmount()
        {
            List<decimal> Amount = new();
            foreach (DataGridViewRow Row_Data in ConfirmGridView1.Rows)
            {
                decimal srp = (decimal) Row_Data.Cells[4].Value;
                int qty = (int)Row_Data.Cells[5].Value;
                Amount.Add(srp * Convert.ToDecimal(qty));

            }
            return Amount.Sum();
        }

        private string ShowMethod()
        {
            string name = CMBClient.Text;
            return SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT pay_method FROM storagemember.member WHERE member_number='" + name + "'");
        }

        private string ShowTerms()
        {
            string name = CMBClient.Text;
            return SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT pay_terms FROM storagemember.member WHERE member_number='" + name + "'");

        }

        private void ClearProd_table()
        {
            textQty.Text = string.Empty;
            TextProduct_id.Text = string.Empty;
            textpro_name.Text = string.Empty;
            textsrp.Text = string.Empty;
            textstock.Text = string.Empty;
            textBarCode.Text = string.Empty;
        }

        private int Reuser_id()
        {
            return SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT user_id FROM username.accounts WHERE username='" + ApplicationSetting.Default.User + "'");

        }

        private int Restorage_id()
        {
            return SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT storage_id FROM productstorage.storage WHERE storage_name='" + ApplicationSetting.Default.Location + "'");

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (SearchGridView.ColumnCount > 0)
            {
                try
                {
                    string RowNameFilter = string.Format("[{0}] Like '%{1}%' OR [{2}] Like '%{3}%'", "name", textSearch.Text, "model", textSearch.Text);
                    ((DataTable)SearchGridView.DataSource).DefaultView.RowFilter = RowNameFilter;

                }
                catch (Exception ex)
                {
                    MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                    MessageBox_text.ShowDialog();
                }
            }
        }

        private void textBarCode_TextChanged(object sender, EventArgs e)
        {
            List<string> ean_0 = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT ean_0 FROM productlibrary.product_sum");
            List<string> ean_1 = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT ean_1 FROM productlibrary.product_sum");
            List<string> ean_2 = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT ean_2 FROM productlibrary.product_sum");
            if ((ean_0.Contains(textBarCode.Text) || ean_1.Contains(textBarCode.Text) || ean_2.Contains(textBarCode.Text) ) && textBarCode.Text!= string.Empty)
            {
                
                int pro_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT product_id FROM productlibrary.product_sum WHERE ean_0='" + textBarCode.Text + "' OR ean_1 ='" + textBarCode.Text + "' OR ean_2 ='" + textBarCode.Text + "'"); ;
                TextProduct_id.Text = pro_id.ToString();
                string pro_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT name FROM productlibrary.product_sum WHERE ean_0='" + textBarCode.Text + "' OR ean_1 ='" + textBarCode.Text + "' OR ean_2 ='" + textBarCode.Text + "'"); ;
                textpro_name.Text = pro_name;
                decimal pro_srp = SQLConnect.Instance.PgSQL_SELECTDataDecimalsingle("SELECT srp FROM productlibrary.product_sum WHERE ean_0='" + textBarCode.Text + "' OR ean_1 ='" + textBarCode.Text + "' OR ean_2 ='" + textBarCode.Text + "'"); ;
                textsrp.Text = pro_srp.ToString();
                int pro_qty = Prod_qty(pro_id);
                textstock.Text = pro_qty.ToString();
                textQty.Focus();

            }
        }

        private int Prod_qty(int pro_id)
        {
            
            int sid = LoadStorage_id();
            string storageschemaname = "\"" + "productlibrary" + "\"";
            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + pro_id + "");
            string hash_database = storageschemaname + ".\"" + result_hash_name + "\"";
            int storage_qty = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT COALESCE(SUM(qty),0) FROM " + hash_database + " WHERE storage_id='" + sid + "' AND status = 1");
            

            return storage_qty;
        }

        private void ConfirmGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ConfirmGridView1.Rows.Count > 0 && e.ColumnIndex == ConfirmGridView1.Columns["btn"].Index)
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                else
                {
                    int sid = Restorage_id();
                    DataGridViewRow Row = ConfirmGridView1.Rows[e.RowIndex];
                    int product_id = (int)Row.Cells[1].Value;
                    int Qty = (int)Row.Cells[5].Value;
                    string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + product_id + "");
                    string storageschemaname = "\"" + "productlibrary" + "\"";
                    string hash_database = storageschemaname + ".\"" + result_hash_name + "\"";
                    List<string> list = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT sn FROM " + hash_database + " WHERE storage_id = " + sid + " AND state = true AND status = 1 ORDER BY purchese_day ASC LIMIT " + Qty);
                    ProductSNInsert ProductSNInsert = new ProductSNInsert(Qty, product_id, list, sid);
                    if (ProductSNInsert.ShowDialog() == DialogResult.Cancel)
                    {
                        List<string> listsn = ProductSNInsert.Listsn;
                        if (listsn != null)
                        {
                            if (listsn.Any() && Qty == listsn.Count)
                            {
                                SNDic[result_hash_name] = listsn;
                            }
                            else if (Qty != listsn.Count)
                            {
                                MessageInfo MessageBox_text = new MessageInfo("Lost Serial Number!");
                                MessageBox_text.ShowDialog();
                            }
                        }
                    }
                }

            }
        }

        private void ConfirmGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            else if (ConfirmGridView1.Rows.Count > 0 && e.ColumnIndex != ConfirmGridView1.Columns["btn"].Index)
            {
                DataGridViewRow Row = ConfirmGridView1.Rows[e.RowIndex];
                int product_id = (int)Row.Cells[1].Value;
                DeleteDicSN(product_id);
                ConfirmGridView1.Rows.RemoveAt(e.RowIndex);
                ConfirmGridView1.Refresh();
            }
        }

        private void DeleteDicSN(int product_id)
        {

            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + product_id + "");
            if (SNDic.ContainsKey(result_hash_name))
            {
                SNDic.Remove(result_hash_name);
            }
        }

        private void textDeposit_TextChanged(object sender, EventArgs e)
        {
            if (texttotalamount.Text != string.Empty && textDeposit.Text != string.Empty)
            {
                if (Convert.ToDecimal(textDeposit.Text) > Convert.ToDecimal(texttotalamount.Text))
                {
                    textBalance.Text = "0";
                    textDeposit.Text = texttotalamount.Text;
                    MessageInfo MessageBox_text = new MessageInfo("Over Payment Amount!");
                    MessageBox_text.ShowDialog();
                }
                else
                {
                    decimal balance = Convert.ToDecimal(texttotalamount.Text) - Convert.ToDecimal(textDeposit.Text);
                    textBalance.Text = balance.ToString();
                }
            }
        }

        private void textDeposit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar > 8 && (int)e.KeyChar < 46) || (int)e.KeyChar > 57 || (int)e.KeyChar == 47 || (int)e.KeyChar < 8)
            {

                e.Handled = true;
            }
            else
            {
                int i = textDeposit.Text.IndexOf(".");
                if (i != -1 && (int)e.KeyChar == 46)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar > 8 && (int)e.KeyChar < 46) || (int)e.KeyChar > 57 || (int)e.KeyChar == 47 || (int)e.KeyChar < 8)
            {

                e.Handled = true;
            }
            else
            {
                int i = textDeposit.Text.IndexOf(".");
                if (i != -1 && (int)e.KeyChar == 46)
                {
                    e.Handled = true;
                }
            }
        }

        private void BtnAddDescription_Click(object sender, EventArgs e)
        {

        }
    }
}
