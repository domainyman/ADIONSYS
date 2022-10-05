using ADIONSYS.ConvertFunction;
using ADIONSYS.Plugin.POS.Warehose.Management.Purchese;
using ADIONSYS.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Graphics.Printing;

namespace ADIONSYS.Plugin.POS.Retail
{
    public partial class RetailForm : Form
    {
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
        }

        private void SearchGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    textQty.Text = string.Empty;
                    DataGridViewRow Row = SearchGridView.Rows[e.RowIndex];
                    //LBSystemCodeShow.Text = Row.Cells[0].Value.ToString();
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

        private void BtnShippingInsert_Click(object sender, EventArgs e)
        {

        }

        private void BtnToConfirm_Click(object sender, EventArgs e)
        {

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
                MessageInfo MessageBox_text = new MessageInfo("Found");
                MessageBox_text.ShowDialog();
            }
        }
    }
}
