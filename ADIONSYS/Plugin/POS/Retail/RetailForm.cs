using ADIONSYS.ConvertFunction;
using ADIONSYS.Plugin.POS.Warehose.Storage.Transfer;
using ADIONSYS.Tool;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Graphics.Printing;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            StartupTable();
            SetupConfirmdataTable();
            AddComponentFirst();
            AddComponentS();


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
            ChangeTerms();
            Firstclick();



        }

        private void ChangeTerms()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> resultClient = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT payterms_name FROM storagemember.payterms");
                cmbTextTerms.DataSource = resultClient;
                if (cmbTextTerms.Text != string.Empty)
                {
                    string result_terms = ShowTerms();
                    if (result_terms != null || result_terms != string.Empty)
                    {
                        cmbTextTerms.SelectedItem = result_terms;
                    }
                }
                else
                {
                    cmbTextTerms.SelectedIndex = -1;
                }
            }
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

        }

        private void ClearAll()
        {
            ClearProd_table();
            textBarCode.Text = string.Empty;
            textQty.Text = string.Empty;
            textSearch.Text = string.Empty;
            ConfirmdataTable.Clear();
            SearchGridView.Update();
            SearchGridView.Refresh();
            LoadTable();
            SNDic.Clear();
            CommentList = string.Empty;
            textBalance.Text = string.Empty;
            texttotalqty.Text = string.Empty;
            texttotalamount.Text = "0";
            textDeposit.Text = string.Empty;
            textstatus.Text = string.Empty;
            ClearMethod_S();
            ClearMethod();
            LBClientID.Text = string.Empty;
            CMBClient.SelectedIndex = -1;
            cmbTextTerms.SelectedIndex = -1;

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
                string pro_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT name FROM productlibrary.product_sum WHERE ean_0='" + textBarCode.Text + "' OR ean_1 ='" + textBarCode.Text + "' OR ean_2 ='" + textBarCode.Text + "'");
                textpro_name.Text = pro_name;
                decimal pro_srp = SQLConnect.Instance.PgSQL_SELECTDataDecimalsingle("SELECT srp FROM productlibrary.product_sum WHERE ean_0='" + textBarCode.Text + "' OR ean_1 ='" + textBarCode.Text + "' OR ean_2 ='" + textBarCode.Text + "'");
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

        public string CommentList { set; get; }

        private void BtnAddDescription_Click(object sender, EventArgs e)
        {
            Description Description = new();
            Description.ShowDialog();
            if(Description.List != null && Description.List.Any())
            {
                CommentList = string.Join(",",Description.List.ToArray());
            }


        }

        private string AutoNumber()
        {
            string invoice_number = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT invoice_number FROM salesinvoice.salesinvoicesum ORDER BY created_on DESC LIMIT 1");
            string result;
            if (invoice_number == null || invoice_number == string.Empty)
            {
                result = POSSettings.Default.InvoiceNumber;
                return result;
            }
            else
            {
                string[] sArray = invoice_number.Split('-');
                int number = int.Parse(sArray[1]);
                int retnumber = number + 1;
                result = sArray[0] + "-" + retnumber.ToString();
                return result;
            }

        }

        private bool CheckINV(string inv)
        {
            bool done = false;
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT invoice_number FROM salesinvoice.salesinvoicesum");
                    if (result.Contains(inv))
                    {
                        return done;
                    }
                    else
                    {
                        done = true;
                        return done;
                    }
                }
                else
                {
                    return done;
                }
            }
            catch
            {
                return done;
            }
        }
        private List<string> DicKeyName()
        {
            List<string> keyList = new List<string>(this.SNDic.Keys);
            return keyList;
        }

        private List<bool> CheckDicSNPCS(List<string> keyList)
        {
            List<bool> dicSNBool = new List<bool>();
            List<string> CheckList = keyList;
            for (int i = 0; i < CheckList.Count; i++)
            {
                int product_id = (int)ConfirmGridView1.Rows[i].Cells[1].Value;
                string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + product_id + "");
                int RowCount = (int)ConfirmGridView1.Rows[i].Cells[5].Value;
                int ListCount = SNDic[result_hash_name].Count;
                if (ListCount == RowCount)
                {
                    dicSNBool.Add(true);
                }
                else
                {
                    dicSNBool.Add(false);
                }
            }
            return dicSNBool;
        }

        private bool CheckDicSNGroup()
        {
            List<string> keyList = DicKeyName();
            List<bool> SNBool = CheckDicSNPCS(keyList);
            bool CheckSN;
            if (SNBool.Contains(false))
            {
                CheckSN = false;
            }
            else
            {
                CheckSN = true;
            }
            return CheckSN;
        }

        private bool CheckDicKeyGroup()
        {
            List<string> keyList = DicKeyName();
            int keycount = keyList.Count;
            int Viewcount = ConfirmGridView1.Rows.Count;
            bool CheckDicKey;
            if (keycount == Viewcount)
            {
                CheckDicKey = true;
            }
            else
            {
                CheckDicKey = false;
            }
            return CheckDicKey;
        }

        private int DicValList(List<string> keyList)
        {
            List<int> lst = new List<int>();
            List<string> CheckList = keyList;
            for (int i = 0; i < CheckList.Count; i++)
            {
                string result_hash_name = CheckList[i];
                int ListCount = SNDic[result_hash_name].Count;
                lst.Add(ListCount);
            }
            int Sumlst = lst.Sum();
            return Sumlst;
        }

        private int Itemcolumn(string table, int head, int own)
        {
            string tablename = table;
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT column_name FROM information_schema.columns WHERE table_name = '" + tablename + "'");
            int resultCount = result.Count;
            int headle = head;
            int itemcolumn = own;
            int itempcs = (resultCount - headle) / itemcolumn;
            return itempcs;
        }

        private int Addcolumnpcs(int need, int have)
        {
            int addcolumn = need - have;
            return addcolumn;
        }

        private void Addinvoiceitemcolumn(int have, int add)
        {
            int havepcs = have;
            int addpcs = add;
            for (int i = 0; i < addpcs; i++)
            {
                havepcs++;
                SQLConnect.Instance.PgSQL_Command("ALTER TABLE salesinvoice.salesinvoiceitem ADD product_id_" + havepcs + " INT");
                SQLConnect.Instance.PgSQL_Command("ALTER TABLE salesinvoice.salesinvoiceitem ADD product_cost_" + havepcs + " decimal");
                SQLConnect.Instance.PgSQL_Command("ALTER TABLE salesinvoice.salesinvoiceitem ADD product_srp_" + havepcs + " decimal");
                SQLConnect.Instance.PgSQL_Command("ALTER TABLE salesinvoice.salesinvoiceitem ADD item_id_" + havepcs + " INT");
                SQLConnect.Instance.PgSQL_Command("ALTER TABLE salesinvoice.salesinvoiceitem ADD item_sn_" + havepcs + " VARCHAR (255)");
            }
        }

        private int CheckNeedDicItemPcs()
        {
            List<string> KeyBook = DicKeyName();
            int ValPcs = DicValList(KeyBook);
            return ValPcs;
        }

        private void Possessinvoiceitemcolumn(string table, int head, int own)
        {
            int need = CheckNeedDicItemPcs();
            int itempcs = Itemcolumn(table, head, own);
            if (need > itempcs)
            {
                int addpcs = Addcolumnpcs(need, itempcs);
                Addinvoiceitemcolumn(itempcs, addpcs);
            }
        }

        private bool Addinvitem(string inv, string date)
        {
            bool step = false;
            try
            {

              
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    List<string> KeyList = DicKeyName();
                    int SumPcs = DicValList(KeyList);
                    SQLConnect.Instance.PgSQL_Command("INSERT INTO salesinvoice.salesinvoiceitem(invoice_number,created_on) VALUES ('" + inv + "','" + date + "')");
                    int result_invoice_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT invoice_id FROM salesinvoice.salesinvoiceitem WHERE invoice_number='" + inv + "'");
                    int DataBaseStep = 1;
                    for (int i = 0; i < KeyList.Count; i++)
                    {
                        int product_id = (int)ConfirmGridView1.Rows[i].Cells[1].Value;
                        
                        string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + product_id + "");
                        List<string> list = SNDic[result_hash_name];

                        for (int q = 0; q < list.Count; q++)
                        {
                            string schemaname = "productlibrary";
                            string droptablename = "\"" + schemaname + "\"" + "." + "\"" + result_hash_name + "\"";
                            int item_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT product_id FROM " + droptablename + " WHERE sn='" + list[q] + "'");
                            decimal cost = SQLConnect.Instance.PgSQL_SELECTDataDecimalsingle("SELECT cost FROM " + droptablename + " WHERE product_id='" + item_id + "'");
                            decimal srp = SQLConnect.Instance.PgSQL_SELECTDataDecimalsingle("SELECT srp FROM productlibrary.product_sum WHERE product_id='" + product_id + "'");
                            SQLConnect.Instance.PgSQL_Command("UPDATE salesinvoice.salesinvoiceitem SET product_id_" + DataBaseStep + "='" + product_id + "',product_cost_" + DataBaseStep + "='" + cost + "',product_srp_" + DataBaseStep + "='" + srp + "', item_id_" + DataBaseStep + "='" + item_id + "', item_sn_" + DataBaseStep + "='" + list[q] + "' WHERE invoice_id = '" + result_invoice_id + "'");
                            DataBaseStep++;
                        }
                        step = true;
                    }
                    return step;
                }
                else
                {
                    return step;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageInfo = new MessageInfo(ex.Message);
                MessageInfo.ShowDialog();
            }
            return step;


        }


        private bool Upload_item_status(string inv)
        {
            bool done = false;
            string invoice = inv;
            string created_on = ConvertType.GetTimeStamp();
            try
            {
                int status = 4;
                List<string> DicKey = DicKeyName();
                for (int i = 0; i < DicKey.Count; i++)
                {
                    string result_hash_name = DicKey[i];
                    List<string> ListVal = SNDic[result_hash_name];
                    for (int q = 0; q < ListVal.Count; q++)
                    {
                        string schemaname = "productlibrary";
                        string droptablename = "\"" + schemaname + "\"" + "." + "\"" + result_hash_name + "\"";

                        SQLConnect.Instance.PgSQL_Command("UPDATE " + droptablename + " SET status='" + status + "',selling_no='"+ invoice + "',selling_day='" + created_on + "' WHERE sn='" + ListVal[q] + "'");
                    }
                }
                done = true;
                return done;
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
            }

            return done;

        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            try 
            {
                if (SQLConnect.Instance.ConnectState() == true && ConfirmGridView1.Rows.Count > 0 )
                {
                    string codenumber = AutoNumber();
                    int client_id = Convert.ToInt32(LBClientID.Text);
                    int Storage_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT storage_id FROM productstorage.storage WHERE storage_name='" + textStorage.Text + "'");
                    int salesman_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT user_id FROM username.accounts WHERE username='" + ApplicationSetting.Default.User + "'");
                    int shipping_id = 0;
                    string comment = CommentList;
                    string created_on = ConvertType.GetTimeStamp();
                    int status = 1;
                    decimal total = Convert.ToDecimal(texttotalamount.Text);
                    decimal Deposit = Convert.ToDecimal(textDeposit.Text);
                    decimal Balance = Convert.ToDecimal(textBalance.Text);
                    int qty_total = Convert.ToInt32(texttotalqty.Text);
                    string deposit_pay_method = paymethod_First();
                    string balance_pay_method = paymethod_S();
                    int pay_status_id = 0;
                    string payTerms = cmbTextTerms.Text;
                    if (CheckBShipping.Checked)
                    {
                        status = 2;
                    }
                    if(textstatus.Text == "PAID")
                    {
                        pay_status_id = 1;
                    }
                    else if(textstatus.Text == "UNPAID")
                    {
                        pay_status_id = 2;
                    }
                    bool state = true;

                    if (codenumber != string.Empty && CheckINV(codenumber) == true &&  deposit_pay_method != string.Empty  && payTerms != string.Empty && (textstatus.Text == "PAID" || textstatus.Text == "UNPAID" ))
                    {
                        
                        if (CheckDicKeyGroup() == true && CheckDicSNGroup() == true)
                        {
                            Possessinvoiceitemcolumn("salesinvoiceitem", 3, 5);
                            if (Addinvitem(codenumber, created_on) == true)
                            {

                                int result_transferitem_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT invoice_id FROM salesinvoice.salesinvoiceitem WHERE invoice_number='" + codenumber + "'");
                                SQLConnect.Instance.PgSQL_Command("INSERT INTO salesinvoice.salesinvoicesum(invoice_number,invoiceitem_id,client_id,shipping_id,username_id,storage_id,total_qty,total,deposit,balance,deposit_pay_method,balance_pay_method,pay_terms,comment,upload_date,created_on) VALUES " +
                                    "('" + codenumber + "','" + result_transferitem_id + "','" + client_id + "','" + shipping_id + "','" + salesman_id + "','" +
                                    "" + Storage_id + "','" + qty_total + "','" + total + "','" + Deposit + "','" + Balance + "','" + deposit_pay_method + "','" + balance_pay_method + "','" + payTerms + "','" + comment + "','" + created_on + "','" + created_on + "')");
                                SQLConnect.Instance.PgSQL_Command("INSERT INTO salesinvoice.salesinvoice_status (invoice_id,status_id,pay_status_id,grant_date,upload_date,state) VALUES ((SELECT invoice_id FROM salesinvoice.salesinvoicesum " +
                                    "WHERE invoice_number= '" + codenumber + "'),'" + status + "','" + pay_status_id + "','" + created_on + "','" + created_on + "','" + state +  "')");
                                if (Upload_item_status(codenumber) == true)
                                {
                                    if(ShippingTransport() == true && Insertshipping(client_id, salesman_id, codenumber) == true)
                                    {
                                        MessageInfo MessageBox_text = new MessageInfo("Saved");
                                        MessageBox_text.ShowDialog();
                                        ClearAll();
                                    }
                                    else
                                    {
                                        MessageInfo MessageBox_text = new MessageInfo("Saved Without Shipping");
                                        MessageBox_text.ShowDialog();
                                        ClearAll();
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        MessageInfo MessageBox_text = new MessageInfo("Not a vaild infomation!");
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

        private string AutoTPNumber()
        {
            string Tp_number = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT ship_number FROM invoiceshipping.shippinginv ORDER BY created_on DESC LIMIT 1");
            string result;
            if (Tp_number == null || Tp_number == string.Empty)
            {
                result = POSSettings.Default.TransportNumber;
                return result;
            }
            else
            {
                string[] sArray = Tp_number.Split('-');
                int number = int.Parse(sArray[1]);
                int retnumber = number + 1;
                result = sArray[0] + "-" + retnumber.ToString();
                return result;
            }

        }

        private bool Insertshipping(int client_id,int user,string invoice)
        {
            try 
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    string Company = string.Empty;
                    string Parson = string.Empty;
                    string Tel = string.Empty;
                    string Address = string.Empty;
                    string ship_comment = string.Empty;
                    string Ship_details = string.Empty;
                    string comment = string.Empty;
                    string Tpnumber = AutoTPNumber();
                    int status =  SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT status_id FROM invoiceshipping.status WHERE status_name = 'NORMAL'");
                    bool state = true;
                    string data = ConvertType.GetTimeStamp();
                
                    if (Shipping_info == null )
                    {
                        Company = " ";
                        Parson = " ";
                        Tel = " ";
                        Address = " ";
                        ship_comment = " ";
                        Ship_details = " ";
                        comment = " ";
                    }
                    else if(Shipping_info != null)
                    {
                        Company = Shipping_info[0];
                        Parson = Shipping_info[1];
                        Tel = Shipping_info[2];
                        Address = Shipping_info[3];
                        ship_comment = Shipping_info[4];
                        Ship_details = " ";
                        comment = " ";
                    }
                    else
                    {
                        List<string> result_member = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT ship_company,ship_person,ship_address,ship_tel,ship_comment FROM storagemember.member WHERE member_id = '" + client_id + "'");
                        Company = result_member[0];
                        Parson = result_member[1];
                        Tel = result_member[2];
                        Address = result_member[3];
                        ship_comment = result_member[4];
                        Ship_details = " ";
                        comment = " ";
                    }
                    SQLConnect.Instance.PgSQL_Command("INSERT INTO invoiceshipping.shippinginv (invoice,username,ship_details,ship_number,ship_company,ship_person,ship_address,ship_tel,ship_comment,comment,upload_date,created_on) " +
                        "VALUES ('" + invoice + "','" + user + "','" + Ship_details + "','" + Tpnumber + "','" + Company + "','" + Parson + "','" + Tel + "','" + Address + "','" + ship_comment + "','" + comment + "','" + data + "','" + data + "')");
                    SQLConnect.Instance.PgSQL_Command("INSERT INTO invoiceshipping.shipping_status (shippinginv_id,status_id,grant_date,upload_date,state) " +
                         "VALUES ((SELECT shippinginv_id FROM invoiceshipping.shippinginv WHERE invoice = '" + invoice + "'),'" + status + "','" + data + "','" + data + "','" + state + "')");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
                return false;
            }
        }

        private bool ShippingTransport()
        {
            if(CheckBShipping.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string paymethod_First()
        {
            foreach (CheckBox checkbox in PayMethod_First.Controls.OfType<CheckBox>())
            {
                if (checkbox.Checked == true)
                {
                    return checkbox.Text;
                }
            }
            return string.Empty;
        }

        private string paymethod_S()
        {
            foreach (CheckBox checkbox in PayMethod_S.Controls.OfType<CheckBox>())
            {
                if (checkbox.Checked == true)
                {
                    return checkbox.Text;
                }
            }
            return string.Empty;
        }
        private void AddComponentFirst()
        {
            List<string> result_paymethod_name = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT paymethod_name FROM storagemember.paymethod");
            int paymethodCount= result_paymethod_name.Count();
            int percent = 100 / paymethodCount;
            
            PayMethod_First.ColumnCount = paymethodCount + 1 ;
            PayMethod_First.AutoSize = true;
            for (int i = 0; i < paymethodCount; i++)
            {
                PayMethod_First.AutoSize = true;
                PayMethod_First.Anchor = AnchorStyles.Left;
            }
            for (int i = 0; i < paymethodCount; i++)
            {
                CheckBox Pay_method = new();
                Pay_method.Anchor = AnchorStyles.Left;
                Pay_method.TextAlign = ContentAlignment.MiddleLeft;
                Pay_method.Font = new Font("Open Sans", 9.75F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                Pay_method.AutoSize = true;
                Pay_method.Name = "cbme" + i;
                Pay_method.ForeColor = Color.White;
                Pay_method.Text = result_paymethod_name[i];
                Pay_method.Parent = Pay_Method_1;
                Pay_method.Margin = new Padding(3, 3, 3, 3); ;
                Pay_method.Dock = DockStyle.Fill;
                PayMethod_First.Controls.Add(Pay_method, i , 0);
                Pay_method.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            }
            CheckBox UNPay_method = new();
            UNPay_method.Anchor = AnchorStyles.Left;
            UNPay_method.TextAlign = ContentAlignment.MiddleLeft;
            UNPay_method.Font = new Font("Open Sans", 9.75F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            UNPay_method.AutoSize = true;
            UNPay_method.Name = "cbme" + paymethodCount;
            UNPay_method.ForeColor = Color.White;
            UNPay_method.Text = "UNPAY";
            UNPay_method.Parent = Pay_Method_1;
            UNPay_method.Margin = new Padding(3, 3, 3, 3); ;
            UNPay_method.Dock = DockStyle.Fill;
            PayMethod_First.Controls.Add(UNPay_method, paymethodCount, 0);
            UNPay_method.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            UNPay_method.CheckedChanged += new EventHandler(CheckBox_Depositzore);
            PayMethod_First.Enabled = false;
            


        }



        private void AddComponentS()
        {
            List<string> result_paymethod_name = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT paymethod_name FROM storagemember.paymethod");
            int paymethodCount = result_paymethod_name.Count();
            int percent = 100 / paymethodCount;

            PayMethod_S.ColumnCount = paymethodCount + 1;
            PayMethod_S.AutoSize = true;
            for (int i = 0; i < paymethodCount; i++)
            {
                PayMethod_S.AutoSize = true;
                PayMethod_S.Anchor = AnchorStyles.Left;
            }
            for (int i = 0; i < paymethodCount; i++)
            {
                CheckBox Pay_method = new();
                Pay_method.Anchor = AnchorStyles.Left;
                Pay_method.TextAlign = ContentAlignment.MiddleLeft;
                Pay_method.Font = new Font("Open Sans", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                Pay_method.AutoSize = true;
                Pay_method.Name = "cbmes" + i;
                Pay_method.ForeColor = Color.White;
                Pay_method.Text = result_paymethod_name[i];
                Pay_method.Parent = Pay_Method_1;
                Pay_method.Margin = new Padding(3, 3, 3, 3); ;
                Pay_method.Dock = DockStyle.Fill;
                PayMethod_S.Controls.Add(Pay_method, i, 0);
                Pay_method.CheckedChanged += new EventHandler(CheckBox_S_CheckedChanged);
                //fix it CheckedChanged
            }
            CheckBox UNPay_method = new();
            UNPay_method.Anchor = AnchorStyles.Left;
            UNPay_method.TextAlign = ContentAlignment.MiddleLeft;
            UNPay_method.Font = new Font("Open Sans", 9.75F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            UNPay_method.AutoSize = true;
            UNPay_method.Name = "cbmes" + paymethodCount;
            UNPay_method.ForeColor = Color.White;
            UNPay_method.Text = "UNPAY";
            UNPay_method.Parent = Pay_Method_1;
            UNPay_method.Margin = new Padding(3, 3, 3, 3); ;
            UNPay_method.Dock = DockStyle.Fill;
            PayMethod_S.Controls.Add(UNPay_method, paymethodCount, 0);
            UNPay_method.CheckedChanged += new EventHandler(CheckBox_S_CheckedChanged);
            UNPay_method.CheckedChanged += new EventHandler(CheckBox_S_Balancezore);
            PayMethod_S.Enabled = false;

        }

        private void CheckBox_S_Balancezore(object sender, EventArgs e)
        {
            CheckBox Check = (CheckBox)sender;
            if (Check.Checked)
            {
                
                textstatus.Text = "UNPAID";
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Check = (CheckBox)sender;
            foreach (CheckBox checkbox in PayMethod_First.Controls.OfType<CheckBox>())
            {

                if (checkbox.Name != Check.Name)
                {
                    checkbox.Checked = false;
                }
            }
            CheckOrderStatus();
        }

        private void CheckBox_S_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Check = (CheckBox)sender;
            foreach (CheckBox checkbox in PayMethod_S.Controls.OfType<CheckBox>())
            {

                if (checkbox.Name != Check.Name)
                {
                    checkbox.Checked = false;
                }
            }
            CheckOrderStatus();
        }

        private void CheckOrderStatus()
        {
            if (textDeposit.Text != string.Empty && CheckMethod() == true && CheckUnpayComBox()==false && PayMethod_S.Enabled == false)
            {
                textDeposit.Text = texttotalamount.Text;
                textBalance.Text = "0";
                textstatus.Text = "PAID";
            }
            else if(textDeposit.Text != string.Empty && CheckMethod() == true  && CheckMethod_S() ==true &&  CheckUnpayComBox() == false && CheckUnpay_SComBox() == false && PayMethod_S.Enabled == true)
            {
                textstatus.Text = "PAID";
            }
            else if (textDeposit.Text != string.Empty && CheckMethod() == true && CheckMethod_S() == false && CheckUnpayComBox() == false && CheckUnpay_SComBox() == false && PayMethod_S.Enabled == true)
            {
                textstatus.Text = string.Empty;
            }
        }

        private void Firstclick()
        {
            string result_pay_method = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT pay_method FROM storagemember.member WHERE member_id=" + LBClientID.Text + "");
            foreach (CheckBox checkbox in PayMethod_First.Controls.OfType<CheckBox>())
            {
                if (checkbox.Text == result_pay_method)
                {
                    checkbox.Checked = true;
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }



        private void texttotalamount_TextChanged(object sender, EventArgs e)
        {
            if (texttotalamount.Text != string.Empty || texttotalamount.Text != null)
            {
                decimal amount = Convert.ToDecimal(texttotalamount.Text);
                if(amount > 0)
                {
                    PayMethod_First.Enabled = true;

                    
                }
            }
        }

        private bool CheckUnpayComBox()
        {
            foreach (CheckBox checkbox in PayMethod_First.Controls.OfType<CheckBox>())
            {

                if (checkbox.Checked && checkbox.Text == "UNPAY")
                {
                    return true;
                }

            }
            return false;
        }

        private bool CheckUnpay_SComBox()
        {
            foreach (CheckBox checkbox in PayMethod_S.Controls.OfType<CheckBox>())
            {

                if (checkbox.Checked && checkbox.Text == "UNPAY")
                {
                    return true;
                }

            }
            return false;
        }

        private void CheckBox_Depositzore(object sender, EventArgs e)
        {
            CheckBox Check = (CheckBox)sender;
            if (Check.Checked)
            {
                textDeposit.Text = "0";
                textBalance.Text = texttotalamount.Text;
                textstatus.Text = "UNPAID";
                PayMethod_S.Enabled = false;
            }
        }

        private bool CheckMethod_S()
        {
            List<bool> bools = new List<bool>();
            foreach (CheckBox checkbox in PayMethod_S.Controls.OfType<CheckBox>())
            {

                if (checkbox.Checked)
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
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckMethod()
        {
            List<bool> bools = new List<bool>();
            foreach (CheckBox checkbox in PayMethod_First.Controls.OfType<CheckBox>())
            {

                if (checkbox.Checked)
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
                return true;
            }
            else
            {
                return false;
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
                else if (Convert.ToDecimal(textDeposit.Text) < Convert.ToDecimal(texttotalamount.Text))
                {
                    PayMethod_S.Enabled = true;
                    decimal balance = Convert.ToDecimal(texttotalamount.Text) - Convert.ToDecimal(textDeposit.Text);
                    textBalance.Text = balance.ToString();
                    CheckOrderStatus();
                }
                else if (Convert.ToDecimal(textDeposit.Text) == Convert.ToDecimal(texttotalamount.Text))
                {
                    PayMethod_S.Enabled = false;
                    decimal balance = Convert.ToDecimal(texttotalamount.Text) - Convert.ToDecimal(textDeposit.Text);
                    textBalance.Text = balance.ToString();
                    CheckOrderStatus();
                }
            }
        }

        private void PayMethod_First_EnabledChanged(object sender, EventArgs e)
        {
            if(PayMethod_First.Enabled == true)
            {
                Firstclick();
            }
        }

        private void textstatus_Click(object sender, EventArgs e)
        {

        }

        private void textBalance_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearMethod_S()
        {
            List<bool> bools = new List<bool>();
            foreach (CheckBox checkbox in PayMethod_S.Controls.OfType<CheckBox>())
            {

                checkbox.Checked = false;
            }
        }
        private void ClearMethod()
        {
            List<bool> bools = new List<bool>();
            foreach (CheckBox checkbox in PayMethod_First.Controls.OfType<CheckBox>())
            {

                checkbox.Checked = false;
            }
        }

        public List<string> Shipping_info = new List<string>();

        private void BtnShippingInsert_Click(object sender, EventArgs e)
        {
            if(LBClientID.Text != string.Empty && CMBClient.Text != string.Empty)
            {
                int Clientid = Convert.ToInt32(LBClientID.Text);

                ShippingForm ShippingForm = new(Clientid);
                if(ShippingForm.ShowDialog() == DialogResult.Cancel)
                {
                    if(ShippingForm.Shipping != null)
                    {
                        Shipping_info = ShippingForm.Shipping;
                    }
                }
            }
        }


    }
}
