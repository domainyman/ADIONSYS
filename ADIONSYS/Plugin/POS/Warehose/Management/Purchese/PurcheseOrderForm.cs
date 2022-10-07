using ADIONSYS.ConvertFunction;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.CategorySet.Create;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.ProductItem.Create;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.SupplierSet.Create;
using ADIONSYS.Tool;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Windows.Media.AppBroadcasting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADIONSYS.Plugin.POS.Warehose.Management.Purchese
{
    public partial class PurcheseOrderForm : Form
    {
        public DataTable ConfirmdataTable = new DataTable();
        public Dictionary<string, List<string>> SNDic = new Dictionary<string, List<string>>();


        public PurcheseOrderForm()
        {
            InitializeComponent();
            Startup();
            Loadtable();

        }



        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> resultSupplier = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT supplier_name FROM productsupplier.supplier");
                CMBSupplier.DataSource = resultSupplier;
                CMBSupplier.SelectedIndex = -1;
                List<string> resultStorage = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT storage_name FROM productstorage.storage");
                CMBStorage.DataSource = resultStorage;
                CMBStorage.SelectedIndex = -1;
            }
        }

        private void Loadtable()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                //Fix it
                SQLConnect.Instance.LoadDateView(SearchGridView, "SELECT product_id,name,model,cost,qty,comment,ean_0,ean_1,ean_2 FROM productlibrary.product_sum ORDER BY name");
                StartupTable();
            }
        }

        private void LoadRefSerachtable()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                //Fix it
                SQLConnect.Instance.LoadDateView(SearchGridView, "SELECT product_id,name,model,cost,qty,comment,ean_0,ean_1,ean_2 FROM productlibrary.product_sum ORDER BY name");
            }
        }

        private void StartupTable()
        {
            if (SearchGridView.ColumnCount > 0)
            {
                SearchGridView.Columns[0].HeaderText = "ID";
                SearchGridView.Columns[0].FillWeight = 25;
                SearchGridView.Columns[1].HeaderText = "Product Name";
                SearchGridView.Columns[2].HeaderText = "Product Model";
                SearchGridView.Columns[3].HeaderText = "Cost";
                SearchGridView.Columns[3].DefaultCellStyle.Format = "N2";
                SearchGridView.Columns[4].HeaderText = "QTY";
                SearchGridView.Columns[5].HeaderText = "Comment";
                SearchGridView.Columns[6].Visible = false;
                SearchGridView.Columns[7].Visible = false;
                SearchGridView.Columns[8].Visible = false;

                SetupConfirmdataTable();

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
            ConfirmdataTable.Columns.Add("Cost", typeof(decimal));
            ConfirmdataTable.Columns.Add("QTY", typeof(int));

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.FlatStyle = FlatStyle.Flat;
            btn.HeaderText = "Serial Number";
            btn.Text = "Click Here Insert";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            ConfirmGridView1.Columns.Add(btn);
        }

        private void BtnInput_Click(object sender, EventArgs e)
        {
            if (textCost.Text != string.Empty && textQty.Text != string.Empty && LBSystemCodeShow.Text != string.Empty)
            {
                try
                {
                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        DataRow row = ConfirmdataTable.NewRow();
                        int Product_id = Convert.ToInt32(LBSystemCodeShow.Text);
                        List<string> resultProduct = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT name,model FROM productlibrary.product_sum WHERE product_id=" + Product_id);

                        row[1] = Product_id;
                        row[2] = resultProduct[0];
                        row[3] = resultProduct[1];
                        row[4] = Convert.ToDecimal(textCost.Text);
                        row[5] = Convert.ToInt32(textQty.Text);
                        ConfirmdataTable.Rows.Add(row);
                        if (ConfirmGridView1.RowCount > 0)
                        {
                            DataRow lastRow = ConfirmdataTable.AsEnumerable().Last();
                            int pkid = Convert.ToInt32(lastRow[0].ToString());
                            string Model = (string)lastRow[3];
                            int qty = Convert.ToInt32(lastRow[5].ToString());

                            List<string> resultSN = RandomSN(Model, qty, 13);
                            while(CheckDubble(resultSN, Product_id) == false)
                            {
                                resultSN = RandomSN(Model, qty, 13);
                            }
                            if (CheckDubble(resultSN, Product_id) == true)
                            {
                                string keygroup = pkid + "_" + Model;
                                int resultSNCount = resultSN.Count;
                                if (SNDic.ContainsKey(keygroup))
                                {
                                    for (int i = 0; i < resultSNCount; i++)
                                    {
                                        SNDic[keygroup].Add(resultSN[i]);
                                    }
                                }
                                else
                                {
                                    SNDic.Add(keygroup, resultSN);
                                }
                                textCost.Text = string.Empty;
                                textQty.Text = string.Empty;
                                LBSystemCodeShow.Text = string.Empty;
                                LBProductNameShow.Text = string.Empty;
                                ShowAmount();
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
            else
            {
                MessageInfo MessageBox_text = new MessageInfo("Not a valid Enter!");
                MessageBox_text.ShowDialog();
            }
        }


        private List<string> RandomSN(string model, int pcs, int length)
        {
            Random Random = new Random();
            List<string> ListSN = new List<string>();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < pcs; i++)
            {
                string sn = model+'-'+ new string(Enumerable.Repeat(chars, length).Select(s => s[Random.Next(chars.Length)]).ToArray());

                ListSN.Add(sn);
            }
            return ListSN;
        }

        private bool CheckDubble(List<string> ListSN,int prod_id)
        {
            bool Check = false;
            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + prod_id + "");
            string databasename = "productlibrary." + "\"" + result_hash_name + "\"";
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT sn FROM " + databasename );
            List<string> CheckSN = ListSN;
            if (Check == false)
            {
                if (CheckSN.Intersect(result).Any())
                {

                }
                else
                {
                    Check = true;
                }
            }
            return Check;
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            CreateSupplier CreateSupplier = new CreateSupplier();
            if (CreateSupplier.ShowDialog() == DialogResult.Cancel)
            {
                Startup();
            }
        }


        private void BtnSupplierBrowser_Click(object sender, EventArgs e)
        {
            SupplierBrower SupplierBrower = new SupplierBrower();
            SupplierBrower.ShowDialog();
            string supplier_id = SupplierBrower.TextMsg;
            if (supplier_id != string.Empty)
            {
                ComboShowSuppliername(supplier_id);
            }
        }

        private void ComboShowSuppliername(string supplier_id)
        {
            string result_supplier_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT supplier_name FROM productsupplier.supplier WHERE supplier_id='" + supplier_id + "'");
            CMBSupplier.SelectedItem = result_supplier_name;
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (SearchGridView.ColumnCount > 0)
            {
                try
                {
                    string RowNameFilter = string.Format("[{0}] Like '%{1}%' OR [{2}] Like '%{3}%' OR [{4}] Like '%{5}%' OR [{6}] Like '%{7}%' OR [{8}] Like '%{9}%'" +
                        "", "name", textSearch.Text, "model", textSearch.Text, "ean_0", textSearch.Text, "ean_1", textSearch.Text, "ean_2", textSearch.Text);
                    ((DataTable)SearchGridView.DataSource).DefaultView.RowFilter = RowNameFilter;

                }
                catch (Exception ex)
                {
                    MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                    MessageBox_text.ShowDialog();
                }
            }
        }


        private void BtnProductAdd_Click(object sender, EventArgs e)
        {
            CreateProduct CreateProduct = new CreateProduct();
            if (CreateProduct.ShowDialog() == DialogResult.Cancel)
            {
                Startup();
                LoadRefSerachtable();
            }

        }

        private void SearchGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    textCost.Text = string.Empty;
                    textQty.Text = string.Empty;
                    DataGridViewRow Row = SearchGridView.Rows[e.RowIndex];
                    LBSystemCodeShow.Text = Row.Cells[0].Value.ToString();
                    LBProductNameShow.Text = Row.Cells[1].Value.ToString();
                    textCost.Focus();
                }
                catch (Exception ex)
                {
                    MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                    MessageBox_text.ShowDialog();

                }

            }
        }


        private void textCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar > 8 && (int)e.KeyChar < 46) || (int)e.KeyChar > 57 || (int)e.KeyChar == 47 || (int)e.KeyChar < 8)
            {
                //MessageBox.Show("不能輸入非法字符");
                e.Handled = true;
            }
            else
            {
                int i = textCost.Text.IndexOf(".");
                if (i != -1 && (int)e.KeyChar == 46)
                {
                    e.Handled = true;
                }
            }
        }

        private void textQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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
                string q1_rowid = Convert.ToString((int)Row.Cells[1].Value);
                
                string q4_model = (string)Row.Cells[4].Value;
                string name = q1_rowid + "_" + q4_model;
                if (SNDic.ContainsKey(name))
                {
                    SNDic.Remove(name);
                }
                ConfirmGridView1.Rows.RemoveAt(e.RowIndex);
                ConfirmGridView1.Refresh();
            }
            ShowAmount();
        }

        private void Initialize()
        {
            Startup();
            LoadRefSerachtable();
            textinvoice.Text = string.Empty;
            LBSystemCodeShow.Text = string.Empty;
            LBProductNameShow.Text = string.Empty;
            textCost.Text = string.Empty;
            textQty.Text = string.Empty;
            textSearch.Text = string.Empty;
            LBAmount.Text = string.Empty;
            ConfirmdataTable.Clear();
            SNDic.Clear();

        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Initialize();

                //ConfirmdataTable.Reset();
                //ConfirmGridView1.Columns.Clear();
                //SetupConfirmdataTable();
                //ConfirmdataTable.Columns["Item"].AutoIncrementSeed = 1;
                //List<string> keyList = new List<string>(this.SNDic.Keys);

                //for (int i = 0; i < keyList.Count; i++)
                //{
                //    Console.WriteLine(keyList[i]);

                //    Console.WriteLine(SNDic[keyList[i]].Count);

                //}

            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
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
                int RowCount = (int)ConfirmGridView1.Rows[i].Cells[6].Value;
                int pkid = (int)ConfirmGridView1.Rows[i].Cells[1].Value;
                string Model = (string)ConfirmGridView1.Rows[i].Cells[4].Value;
                string keygroup = pkid + "_" + Model;
                int ListCount = SNDic[keygroup].Count;
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

        private void BtnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (SQLConnect.Instance.ConnectState() == true && ConfirmGridView1.Rows.Count > 0 && textinvoice.Text != string.Empty )
                {
                    string suppliername = CMBSupplier.Text;
                    string storageLocation = CMBStorage.Text;
                    string invoicenumber = textinvoice.Text;
                    string invoicedate = dateTimePicker1.Text;
                    string created_on = ConvertType.GetTimeStamp();
                    string comment = string.Empty;

                    string amount = TotalAmount().ToString();
                    bool state = true;
                    int baseqty = 1;
                    if (suppliername != string.Empty && storageLocation != string.Empty && invoicenumber != string.Empty && invoicedate != string.Empty && CheckINV(invoicenumber) == true  && storageLocation != "Summary" )
                    {
                        if (CheckDicKeyGroup() == true && CheckDicSNGroup() == true)
                        {
                            possessinvoiceitemcolumn("invoiceitem", 4, 4);
                            if (Addinvitem(invoicenumber, created_on, state) == true)
                            {
                                List<int> result_invoice_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT invoice_id FROM tableinvoice.invoiceitem WHERE invoice_num='" + invoicenumber + "'");
                                
                                List<int> result_Supplier_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT supplier_id FROM productsupplier.supplier WHERE supplier_name='" + suppliername + "'");
                                List<int> result_Storage_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT storage_id FROM productstorage.storage WHERE storage_name='" + storageLocation + "'");
                                SQLConnect.Instance.PgSQL_Command("INSERT INTO tableinvoice.invoicenum(invoice_num,invoice_item_id,supplier_id,storage_id,amount,comment,invoicedate,created_on,state) VALUES " +
                                    "('" + invoicenumber + "','" + result_invoice_id[0] + "','" + result_Supplier_id[0] + "','" + result_Storage_id[0] + "','" + amount + "','" + comment + "','" + invoicedate + "','" + created_on + "','" + state + "')");
                                List<int> result_invoiceSUM_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT invoice_id FROM tableinvoice.invoicenum WHERE invoice_num='" + invoicenumber + "'");
                                if (Injproductlib(result_Supplier_id[0], result_Storage_id[0], state, invoicenumber, invoicedate, created_on, baseqty, result_invoiceSUM_id[0]) == true)
                                {
                                    if (UpdataProductLib() == true)
                                    {
                                        MessageInfo MessageBox_text = new MessageInfo("Saved");
                                        MessageBox_text.ShowDialog();
                                        Initialize();
                                    }
                                }
                            }
                            else
                            {
                                SQLConnect.Instance.PgSQL_Command("DELETE FROM tableinvoice.invoiceitem WHERE invoice_num='" + invoicenumber + "'");
                                MessageInfo MessageBox_text = new MessageInfo("An error occurred");
                                MessageBox_text.ShowDialog();
                            }

                        }
                        else
                        {
                            MessageInfo MessageBox_text = new MessageInfo("Lost Serial Number");
                            MessageBox_text.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageInfo MessageBox_text = new MessageInfo("Not a vaild infomation!");
                        MessageBox_text.ShowDialog();
                    }
                }
                else
                {
                    MessageInfo MessageBox_text = new MessageInfo("Not a vaild infomation!");
                    MessageBox_text.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageInfo = new MessageInfo(ex.Message);
                MessageInfo.ShowDialog();
            }
        }

        private bool UpdataProductLib()
        {
            bool done = false;
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    int Count = Dicitem();
                    for (int i = 0; i < Count; i++)
                    {
                        string name = (string)ConfirmGridView1.Rows[i].Cells[3].Value;
                        List<int> result_Product_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT product_id FROM productlibrary.product_sum WHERE name='" + name + "'");
                        string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + result_Product_id[0] + "");
                        string databasename = "productlibrary." + "\"" + result_hash_name + "\"";
                        string costcmd = "SELECT cost FROM " + databasename;
                        string spplierid = "select supplier_id from " + databasename +" order by created_on desc limit 1";
                        List<int> spplierresult = SQLConnect.Instance.PgSQL_SELECTDataint(spplierid);
                        int spplier_id = spplierresult[0];
                        List<decimal> result_Cost_srp = SQLConnect.Instance.PgSQL_SELECTDataDecimal(costcmd);
                        decimal AveragecostPcs = result_Cost_srp.Count();
                        decimal AveragecostSum = result_Cost_srp.Sum();
                        List<int> qtyresult = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT qty FROM " + databasename);
                        int Productqty = qtyresult.Count();
                        if (AveragecostPcs > 0)
                        {
                            decimal Averagecost = AveragecostSum / AveragecostPcs;
                            SQLConnect.Instance.PgSQL_Command("UPDATE productlibrary.product_sum SET cost = '" + Averagecost + "' WHERE product_id = " + result_Product_id[0] + "");
                            SQLConnect.Instance.PgSQL_Command("UPDATE productlibrary.product_sum SET qty = '" + Productqty + "' WHERE product_id = " + result_Product_id[0] + "");
                            SQLConnect.Instance.PgSQL_Command("UPDATE productlibrary.product_sum SET supplier_id = '" + spplier_id + "' WHERE product_id = " + result_Product_id[0] + "");
                        }
                    }
                    done = true;
                    return done;
                }
                else
                {
                    return done;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageInfo = new MessageInfo(ex.Message);
                MessageInfo.ShowDialog();
                return done;
            }
        }

        private bool CheckINV(string inv)
        {
            bool done = false;
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT invoice_num FROM tableinvoice.invoicenum");
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
        private bool Injproductlib(int suppli_id,int stora_id,bool state,string inv_nmb,string inv_date,string date,int baseqty,int invid)
        {
            bool done = false;
            try
            {

                if (SQLConnect.Instance.ConnectState() == true)
                {
                    int DicCount = Dicitem();

                    for (int i = 0; i < DicCount; i++)
                    {
                        int q1_rowid = (int)ConfirmGridView1.Rows[i].Cells[1].Value;
                        int prodlib_id = (int)ConfirmGridView1.Rows[i].Cells[2].Value;
                        string model = (string)ConfirmGridView1.Rows[i].Cells[4].Value;
                        string name = (string)ConfirmGridView1.Rows[i].Cells[3].Value;
                        decimal cost = (decimal)ConfirmGridView1.Rows[i].Cells[5].Value;
                        int qty = baseqty;
                        string DicName = q1_rowid + "_" + model;
                        string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + prodlib_id + "");
                        string DatabaseName = "productlibrary." + "\"" + result_hash_name + "\"";
                        string NullNA = string.Empty;
                        string Nulldata = "1111-11-11 11:11:11";
                        string comment = string.Empty;
                        int status = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT status_id FROM productlibrary.status WHERE status_name='normal'"); ;
                        List<string> list = SNDic[DicName];
                        for (int j = 0; j < list.Count; j++)
                        {
                            SQLConnect.Instance.PgSQL_Command("INSERT INTO " + DatabaseName + "(sn, cost,qty,supplier_id,storage_id,inv_id,status,state,comment,booking_no,booking_day,purchese_no,purchese_day,selling_no,selling_day,created_on) VALUES" +
                                " ('" + list[j] + "','" +
                                "" + cost + "','" +
                                "" + qty + "','" +
                                "" + suppli_id + "','" +
                                "" + stora_id + "','" +
                                "" + invid + "','" +
                                "" + status + "','" +
                                "" + state + "','" +
                                "" + comment + "','" +
                                "" + NullNA + "','" +
                                "" + Nulldata + "','" +
                                "" + inv_nmb + "','" +
                                "" + inv_date + "','" +
                                "" + NullNA + "','" +
                                "" + Nulldata + "','" +
                                "" + date + "')");
                        }
                        
                    }
                    done = true;
                    return done;
                }
                else
                {
                    return done;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageInfo = new MessageInfo(ex.Message);
                MessageInfo.ShowDialog();
                return done;
            }


        }

        private decimal TotalAmount()
        {
            List<decimal> AmountList = new List<decimal>();
            int Count = Dicitem();
            for (int i = 0; i < Count; i++)
            {
                decimal cost = (decimal)ConfirmGridView1.Rows[i].Cells[5].Value;
                decimal qty = Convert.ToDecimal((int)ConfirmGridView1.Rows[i].Cells[6].Value);
                decimal amount = cost * qty;
                AmountList.Add(amount);
            }
            decimal Amount = AmountList.Sum();
            return Amount;
        }

        private bool Addinvitem(string inv, string date,bool state)
        {
            bool step = false;
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    int Count = Dicitem()+1;
                    SQLConnect.Instance.PgSQL_Command("INSERT INTO tableinvoice.invoiceitem(invoice_num,created_on,state) VALUES ('" + inv + "','" + date + "','" + state + "')");
                    List<int> result_invoice_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT invoice_id FROM tableinvoice.invoiceitem WHERE invoice_num='" + inv + "'");
                    for (int i = 1; i < Count; i++)
                    {
                        int j = i - 1;
                        string model = (string)ConfirmGridView1.Rows[j].Cells[4].Value;
                        string name = (string)ConfirmGridView1.Rows[j].Cells[3].Value;
                        decimal cost = (decimal)ConfirmGridView1.Rows[j].Cells[5].Value;
                        int qty = (int)ConfirmGridView1.Rows[j].Cells[6].Value;
                        SQLConnect.Instance.PgSQL_Command("UPDATE tableinvoice.invoiceitem SET itemmodel_" + i + "='" + model + "', itemname_" + i + "='" + name + "', itemcost_" + i + "='" + cost + "', itempcs_" + i + "='" + qty + "' WHERE invoice_id = '" + result_invoice_id[0] + "'");
                        step = true;
                    }
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


        private int itemcolumn(string table,int head,int own)
        {
            string tablename = table;
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT column_name FROM information_schema.columns WHERE table_name = '" + tablename +"'");
            int resultCount = result.Count;
            int headle = head;
            int itemcolumn = own;
            int itempcs = (resultCount - headle)/itemcolumn;
            return itempcs;
        }

        private int addcolumnpcs(int need,int have)
        {
            int addcolumn = need - have;
            return addcolumn;
        }

        private void addinvoiceitemcolumn(int have,int add)
        {
            int havepcs = have;
            int addpcs = add;
            for (int i = 0; i < addpcs; i++) 
            {
                havepcs++;
                SQLConnect.Instance.PgSQL_Command("ALTER TABLE tableinvoice.invoiceitem ADD itemmodel_" + havepcs + " VARCHAR (255)");
                SQLConnect.Instance.PgSQL_Command("ALTER TABLE tableinvoice.invoiceitem ADD itemname_" + havepcs + " VARCHAR (255)");
                SQLConnect.Instance.PgSQL_Command("ALTER TABLE tableinvoice.invoiceitem ADD itemcost_" + havepcs + " decimal");
                SQLConnect.Instance.PgSQL_Command("ALTER TABLE tableinvoice.invoiceitem ADD itempcs_" + havepcs + " INT");
            }
        }

        private void possessinvoiceitemcolumn(string table, int head, int own)
        {
            int need = Dicitem();
            int itempcs = itemcolumn(table, head, own);
            Console.WriteLine(itempcs);
            if (need > itempcs)
            {
                int addpcs = addcolumnpcs(need, itempcs);
                addinvoiceitemcolumn(itempcs, addpcs);
            }
        }

        private int Dicitem()
        {
            int Dictitempcs = DicKeyName().Count();
            return Dictitempcs;
        }

        private void ShowAmount()
        {
            decimal Amount = TotalAmount();
            LBAmount.Text = Amount.ToString("N2");
        }


        private void textinvoice_Leave(object sender, EventArgs e)
        {
            string name = textinvoice.Text;
            if (CheckINV(name) == false)
            {
                MessageInfo MessageInfo = new MessageInfo("Number Repeat ");
                MessageInfo.ShowDialog();
                BtnSave.Enabled = false;
            }
            else
            {
                BtnSave.Enabled = true;
            }
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
                    //DataGridViewRow Row = ConfirmGridView1.Rows[ConfirmGridView1.SelectedRows[0].Index];
                    DataGridViewRow Row = ConfirmGridView1.Rows[e.RowIndex];

                    int rowid = (int)Row.Cells[1].Value;
                    string model = (string)Row.Cells[4].Value;
                    string name = rowid + "_" + model;
                    List<string> list = SNDic[name];
                    int row_id = (int)Row.Cells[2].Value;
                    int Qty = (int)Row.Cells[6].Value;
                    ProductSNInsert ProductSNInsert = new ProductSNInsert(Qty, row_id, list);
                    if (ProductSNInsert.ShowDialog() == DialogResult.Cancel)
                    {
                        List<string> listsn = ProductSNInsert.listsn;
                        if (listsn != null)
                        {
                            if (listsn.Any() && Qty == listsn.Count)
                            {
                                SNDic[name] = listsn;
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
    }
}

//Dictionary<int, List<int>> Dic = ChangeItemStatus_and_storageID(SQLToDTData(Transfers_id));
//List<int> keyList = new List<int>(Dic.Keys);
//for (int i = 0; i < keyList.Count; i++)
//{
//    Console.WriteLine(keyList[i]);
//    Console.WriteLine(Dic[keyList[i]].Count);


//}
//var flattenedList = Dic.Values.SelectMany(x => x).ToList();
//for (int i = 0; i < flattenedList.Count; i++)
//{
//    Console.WriteLine(flattenedList[i]);

//}
