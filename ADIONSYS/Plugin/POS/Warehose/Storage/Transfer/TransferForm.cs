using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.StorageSet.Create;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADIONSYS.Tool;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Security.Cryptography;
using ADIONSYS.ConvertFunction;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.SupplierSet.Create;
using Windows.ApplicationModel.VoiceCommands;

namespace ADIONSYS.Plugin.POS.Warehose.Storage.Transfer
{
    public partial class TransferForm : Form
    {
        public DataTable ConfirmdataTable = new DataTable();
        public TransferForm()
        {
            InitializeComponent();
            Startup();
            SetupConfirmdataTable();
            
        }

        private void Startup()
        {
            SetupStorage();
            SetupToStorage();
        }



        private void SetupStorage()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> resultStorage = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT storage_name FROM productstorage.storage");
                CMBStorage.DataSource = resultStorage;
                CMBStorage.SelectedIndex = -1;
            }
        }

        private void SetupToStorage()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> resultStorage = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT storage_name FROM productstorage.storage");
                CMBTOStorage.DataSource = resultStorage;
                CMBTOStorage.SelectedIndex = -1;
            }
        }


        private int Storage_id()
        {
            string name = CMBStorage.Text;
            List<int> result_Storage_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT storage_id FROM productstorage.storage WHERE storage_name='" + name + "'");
            int Storage_id = result_Storage_id[0];
            return Storage_id;

        }


        private void BtnStorageAdd_Click(object sender, EventArgs e)
        {
            CreateStorage CreateStorage = new();
            if (CreateStorage.ShowDialog() == DialogResult.Cancel)
            {
                Startup();
            }
        }

        private void CMBStorage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {

                int sid = Storage_id();
                string storageschemaname = "\"" + "productlibrary" + "\"";
                string tablenameSUM = "\"" + "product_sum" + "\"";
                string droptablesumname = storageschemaname + "." + tablenameSUM;
                DataTable ProductSUM = SQLConnect.Instance.LoadDateTableStorage("SELECT product_id,name,model,cost,qty,comment,ean_0,ean_1,ean_2 FROM " + droptablesumname + " WHERE state = true ORDER BY name");

                if (CMBStorage.Text == "Summary")
                {
                    SearchGridView.DataSource = ProductSUM;
                }
                else
                {
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
                StartupTable();
            }
        }
        private void StartupTable()
        {
            if (SearchGridView.ColumnCount > 0)
            {
                SearchGridView.Columns[0].HeaderText = "ID";
                SearchGridView.Columns[0].FillWeight = 25;
                SearchGridView.Columns[1].HeaderText = "Product Name";
                SearchGridView.Columns[1].MinimumWidth = 200;
                SearchGridView.Columns[2].HeaderText = "Product Model";
                SearchGridView.Columns[3].HeaderText = "Cost";
                SearchGridView.Columns[3].DefaultCellStyle.Format = "N2";
                SearchGridView.Columns[4].HeaderText = "QTY";
                SearchGridView.Columns[4].MinimumWidth = 50;
                SearchGridView.Columns[5].HeaderText = "Description";
                SearchGridView.Columns[6].Visible = false;
                SearchGridView.Columns[7].Visible = false;
                SearchGridView.Columns[8].Visible = false;
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
                    LBSystemCodeShow.Text = Row.Cells[0].Value.ToString();
                    LBProductNameShow.Text = Row.Cells[1].Value.ToString();
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
            DataColumn IDColumn = ConfirmdataTable.Columns.Add("Item", typeof(int));

            ConfirmdataTable.PrimaryKey = new DataColumn[]
            {
                    ConfirmdataTable.Columns["Item"]
            };
            IDColumn.AutoIncrement = true;
            IDColumn.AutoIncrementSeed = 1;
            IDColumn.AutoIncrementStep = 1;

            ConfirmGridView1.Columns["Item"].FillWeight = 30;
            ConfirmdataTable.Columns.Add("ID", typeof(int));
            ConfirmGridView1.Columns["ID"].FillWeight = 25;
            ConfirmdataTable.Columns.Add("Product Name", typeof(string));
            ConfirmdataTable.Columns.Add("Product Model", typeof(string));
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
            int sid = Storage_id();
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
                    int produ_id = (int)ConfirmGridView1.Rows[i].Cells[2].Value;
                    if(pro_id == produ_id)
                    {
                        bools.Add(true);
                    }
                    else
                    {
                        bools.Add(false);
                    }
                }
                if(bools.Contains(true))
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

        private void UploadConfirmdataTablem(int pro_id,int upl_qty)
        {
            if (ConfirmGridView1.RowCount > 0)
            {
                foreach (DataGridViewRow Row_Data in ConfirmGridView1.Rows)
                {
                    int Row_id = Convert.ToInt32(Row_Data.Cells[2].Value);
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

        private void BtnInput_Click(object sender, EventArgs e)
        {

            if (textQty.Text != string.Empty && LBSystemCodeShow.Text != string.Empty && CMBStorage.Text != "Summary" && CMBStorage.Text != CMBTOStorage.Text && CMBTOStorage.Text != string.Empty && CMBStorage.Text != string.Empty)
            {
                try
                {
                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        int sid = Storage_id();
                        int Product_id = Convert.ToInt32(LBSystemCodeShow.Text);
                        int qty = Convert.ToInt32(textQty.Text);
                        int Databaseqty = Check_qty(Product_id);
                        if (Databaseqty >= qty)
                        {
                            bool include = CheckConfirmdataTableItem(Product_id);
                            if(include == true)
                            {
                                UploadConfirmdataTablem(Product_id, qty);
                                UploadDicSN(Product_id, qty, sid);
                            }
                            else
                            {
                                DataRow row = ConfirmdataTable.NewRow();
                                List<string> resultProduct = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT name,model FROM productlibrary.product_sum WHERE product_id=" + Product_id);

                                row[1] = Product_id;
                                row[2] = resultProduct[0];
                                row[3] = resultProduct[1];
                                row[4] = qty;
                                ConfirmdataTable.Rows.Add(row);
                                CreateDicSN(Product_id, qty, sid);

                            }

                            if (ConfirmGridView1.RowCount > 0)
                            {
                                textQty.Text = string.Empty;
                                LBSystemCodeShow.Text = string.Empty;
                                LBProductNameShow.Text = string.Empty;
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
            else
            {
                MessageInfo MessageBox_text = new MessageInfo("Not a valid Enter!");
                MessageBox_text.ShowDialog();
            }
        }

        private void CreateDicSN(int product_id,int qty,int sid)
        {
            
            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + product_id + "");
            string storageschemaname = "\"" + "productlibrary" + "\"";
            string hash_database = storageschemaname + ".\"" + result_hash_name + "\"";
            List<string> list = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT sn FROM " + hash_database + " WHERE storage_id = " + sid + " AND state = true AND status = 1 ORDER BY purchese_day ASC LIMIT " + qty);
            SNDic.Add(result_hash_name, list);
        }

        private void UploadDicSN(int product_id, int qty, int sid)
        {
            
            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + product_id + "");
            int SNBaseCount = SNDic[result_hash_name].Count;
            int renewqty = SNBaseCount + qty;
            string storageschemaname = "\"" + "productlibrary" + "\"";
            string hash_database = storageschemaname + ".\"" + result_hash_name + "\"";
            List<string> list = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT sn FROM " + hash_database + " WHERE storage_id = " + sid + " AND state = true AND status = 1 ORDER BY purchese_day ASC LIMIT " + renewqty);
            SNDic[result_hash_name] = list;
        }

        private void DeleteDicSN(int product_id)
        {
            
            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + product_id + "");
            if (SNDic.ContainsKey(result_hash_name))
            {
                SNDic.Remove(result_hash_name);
            }
        }

        private void ConfirmGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if(ConfirmGridView1.RowCount > 0)
            {
                CMBStorage.Enabled = false;
                CMBTOStorage.Enabled = false;
            }
            else if (ConfirmGridView1.RowCount == 0)
            {
                CMBStorage.Enabled = true;
                CMBTOStorage.Enabled = true;
            }
        }

        private void ConfirmGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (ConfirmGridView1.RowCount > 0)
            {
                CMBStorage.Enabled = false;
                CMBTOStorage.Enabled = false;
            }
            else if(ConfirmGridView1.RowCount == 0)
            {
                CMBStorage.Enabled = true;
                CMBTOStorage.Enabled = true;
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
                int product_id = (int)Row.Cells[2].Value;
                DeleteDicSN(product_id);
                ConfirmGridView1.Rows.RemoveAt(e.RowIndex);
                ConfirmGridView1.Refresh();
            }
        }

        public Dictionary<string, List<string>> SNDic = new Dictionary<string, List<string>>();

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
                    int sid = Storage_id();
                    DataGridViewRow Row = ConfirmGridView1.Rows[e.RowIndex];
                    int product_id = (int)Row.Cells[2].Value;
                    int Qty = (int)Row.Cells[5].Value;
                    string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + product_id + "");
                    string storageschemaname = "\"" + "productlibrary" + "\"";
                    string hash_database = storageschemaname + ".\"" + result_hash_name + "\"";
                    List<string> list = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT sn FROM " + hash_database + " WHERE storage_id = " + sid + " AND state = true AND status = 1 ORDER BY purchese_day ASC LIMIT " + Qty);
                    ProductSNInsert ProductSNInsert = new ProductSNInsert(Qty, product_id, list , sid);
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

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Initialize();

            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
            }

        }
        private void Initialize()
        {
            Startup();
            Textcodeno.Text = string.Empty;
            LBSystemCodeShow.Text = string.Empty;
            LBProductNameShow.Text = string.Empty;
            textQty.Text = string.Empty;
            textSearch.Text = string.Empty;
            CMBTOStorage.SelectedIndex = -1;
            CMBStorage.SelectedIndex = -1;
            ConfirmdataTable.Clear();
            SearchGridView.DataSource = null;
            SNDic.Clear();

        }

        private bool CheckINV(string inv)
        {
            bool done = false;
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT transfer_number FROM storagetransfer.transfer");
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

        private List<bool> CheckDicSNPCS(List<string> keyList)
        {
            List<bool> dicSNBool = new List<bool>();
            List<string> CheckList = keyList;
            for (int i = 0; i < CheckList.Count; i++)
            {
                int product_id = (int)ConfirmGridView1.Rows[i].Cells[2].Value;
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
                SQLConnect.Instance.PgSQL_Command("ALTER TABLE storagetransfer.transferitem ADD product_id_" + havepcs + " INT");
                SQLConnect.Instance.PgSQL_Command("ALTER TABLE storagetransfer.transferitem ADD item_id_" + havepcs + " INT");
                SQLConnect.Instance.PgSQL_Command("ALTER TABLE storagetransfer.transferitem ADD item_sn_" + havepcs + " VARCHAR (255)");
            }
        }

        private int CheckNeedDicItemPcs()
        {
            List<string> KeyBook = DicKeyName();
            int ValPcs = DicValList(KeyBook);
            return ValPcs;
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

        private void Possessinvoiceitemcolumn(string table, int head, int own)
        {
            int need = CheckNeedDicItemPcs();
            int itempcs = Itemcolumn(table, head, own);
            Console.WriteLine(itempcs);
            if (need > itempcs)
            {
                int addpcs = Addcolumnpcs(need, itempcs);
                Addinvoiceitemcolumn(itempcs, addpcs);
            }
        }
        private string AutoNumber()
        {
            string transfer_number = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT transfer_number FROM storagetransfer.transfer ORDER BY created_on DESC LIMIT 1");
            string result;
            if (transfer_number == null)
            {
                result = POSSettings.Default.TransferNumber;
                return result;
            }
            else
            {
                string[] sArray = transfer_number.Split('-');
                int number = int.Parse(sArray[1]);
                int retnumber = number + 1;
                result = sArray[0] + "-"+ retnumber.ToString();
                return result;
            }
            
        }

 
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SQLConnect.Instance.ConnectState() == true && ConfirmGridView1.Rows.Count > 0 )
                {
                    string codenumber = AutoNumber();
                    string Fromstorage = CMBStorage.Text;
                    int result_Fromstorage_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT storage_id FROM productstorage.storage WHERE storage_name='" + Fromstorage + "'");
                    string Tostorage = CMBTOStorage.Text;
                    int result_Tostorage_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT storage_id FROM productstorage.storage WHERE storage_name='" + Tostorage + "'");
                    string invdate = dateTimePicker.Text;
                    string username = ApplicationSetting.Default.User;
                    int status = 2;
                    bool state = true;
                    string comment = string.Empty;
                    string created_on = ConvertType.GetTimeStamp();
                    if (codenumber != string.Empty && Fromstorage != string.Empty && Tostorage != string.Empty && invdate != string.Empty && CheckINV(codenumber) == true)
                    {
                        if (CheckDicKeyGroup() == true && CheckDicSNGroup() == true)
                        {
                            Possessinvoiceitemcolumn("transferitem", 4, 3);
                            if (Addinvitem(codenumber, created_on, state) == true)
                            {
                                int result_transferitem_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT transfer_id FROM storagetransfer.transferitem WHERE transfer_number='" + codenumber + "'");
                                SQLConnect.Instance.PgSQL_Command("INSERT INTO storagetransfer.transfer(transfer_number,transferitem_id,from_storage,to_storage,username,state,comment,created_on) VALUES " +
                                    "('" + codenumber + "','" + result_transferitem_id + "','" + result_Fromstorage_id + "','" + result_Tostorage_id + "','" + username + "','" +
                                    "" +  state + "','" + comment + "','" + created_on + "')");
                                SQLConnect.Instance.PgSQL_Command("INSERT INTO storagetransfer.transfer_status (transfer_id,status_id,grant_date) VALUES ((SELECT transfer_id FROM storagetransfer.transfer WHERE transfer_number= '"+ codenumber + "'),'"+ status + "','" + created_on + "')");
                                if (Upload_item_status() == true)
                                {
                                    MessageInfo MessageBox_text = new MessageInfo("Saved");
                                    MessageBox_text.ShowDialog();
                                    Initialize();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
            }
        }

        private bool Upload_item_status()
        {
            bool done = false;
            try
            {
                int status = 2;
                List<string> DicKey = DicKeyName();
                for (int i = 0; i < DicKey.Count; i++)
                {
                    string result_hash_name = DicKey[i];
                    List<string> ListVal = SNDic[result_hash_name];
                    for (int q = 0; q < ListVal.Count; q++)
                    {
                        string schemaname = "productlibrary";
                        string droptablename = "\"" + schemaname + "\"" + "." + "\"" + result_hash_name + "\"";
                       
                        SQLConnect.Instance.PgSQL_Command("UPDATE " + droptablename + " SET status='" + status + "' WHERE sn='" + ListVal[q] + "'");
                    }
                }
                done = true;
                return done;
            }
            catch(Exception ex) 
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
            }
            
            return done;
               
        }

        private bool Addinvitem(string inv, string date, bool state)
        {
            bool step = false;
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    List<string> KeyList = DicKeyName();
                    int SumPcs = DicValList(KeyList);
                    SQLConnect.Instance.PgSQL_Command("INSERT INTO storagetransfer.transferitem(transfer_number,created_on,state) VALUES ('" + inv + "','" + date + "','" + state + "')");
                    int result_transfer_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT transfer_id FROM storagetransfer.transferitem WHERE transfer_number='" + inv + "'");
                    int DataBaseStep = 1;
                    for (int i = 0; i < KeyList.Count; i++)
                    {
                        int product_id = (int)ConfirmGridView1.Rows[i].Cells[2].Value;
                        string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + product_id + "");
                        List<string> list = SNDic[result_hash_name];

                        for (int q = 0; q < list.Count; q++)
                        {
                            string schemaname = "productlibrary";
                            string droptablename = "\"" + schemaname + "\"" + "." + "\"" + result_hash_name + "\"";
                            int item_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT product_id FROM " + droptablename + " WHERE sn='" + list[q] + "'");
                            SQLConnect.Instance.PgSQL_Command("UPDATE storagetransfer.transferitem SET product_id_" + DataBaseStep + "='" + product_id + "', item_id_" + DataBaseStep + "='" + item_id + "', item_sn_" + DataBaseStep + "='" + list[q] + "' WHERE transfer_id = '" + result_transfer_id + "'");
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

        private void TextSearch_TextChanged(object sender, EventArgs e)
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
    }
    
}
