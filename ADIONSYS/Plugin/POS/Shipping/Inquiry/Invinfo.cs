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
using System.Xml.Linq;

namespace ADIONSYS.Plugin.POS.Shipping.Inquiry
{
    public partial class Invinfo : Form
    {
        public int invoice_id;
        public int invoiceitem_id;
        public Invinfo(string inv)
        {
            InitializeComponent();
            invoice_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT invoice_id FROM salesinvoice.salesinvoicesum  WHERE invoice_number = '" + inv + "'");
            invoiceitem_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT invoiceitem_id FROM salesinvoice.salesinvoicesum  WHERE invoice_number = '" + inv + "'");
            ShowForm();
            LoadingTable();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowForm()
        {
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    List<string> result_Details = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT deposit_pay_method,balance_pay_method,pay_terms,comment " +
                        "FROM salesinvoice.salesinvoicesum WHERE invoice_id = '" + invoice_id + "'");
                    List<int> result_inv_Details = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT client_id,username_id,storage_id,total_qty " +
                        "FROM salesinvoice.salesinvoicesum WHERE invoice_id='" + invoice_id + "'");
                    List<decimal> result_Cost_srp = SQLConnect.Instance.PgSQL_SELECTDataDecimal("SELECT total,deposit,balance " +
                        "FROM salesinvoice.salesinvoicesum WHERE invoice_id='" + invoice_id + "'");
                    List<DateTime> result_DateTime = SQLConnect.Instance.PgSQL_SELECTDataDateTime("SELECT upload_date,created_on " +
                        "FROM salesinvoice.salesinvoicesum WHERE invoice_id= '" + invoice_id + "'");
                    textupdatadate.Text = result_DateTime[0].ToString();
                    textCreateDate.Text = result_DateTime[1].ToString();
                    textClient.Text = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT member_number FROM storagemember.member WHERE member_id='" + result_inv_Details[0] + "'");
                    textInvnumber.Text = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT invoice_number FROM salesinvoice.salesinvoicesum  WHERE invoice_id='" + invoice_id + "'");
                    textInvnumber.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                    textusername.Text = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT username FROM username.accounts  WHERE user_id='" + result_inv_Details[1] + "'");
                    textstorage.Text = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT storage_name FROM productstorage.storage  WHERE storage_id='" + result_inv_Details[2] + "'");
                    textqty.Text = result_inv_Details[3].ToString();
                    textComment.Text = result_Details[3];
                    textdeposit_pay_method.Text = result_Details[0];
                    textbalance_pay_method.Text = result_Details[1];
                    textterms.Text = result_Details[2];
                    textamount.Text = result_Cost_srp[0].ToString("N2");
                    textdeposit.Text = result_Cost_srp[1].ToString("N2");
                    textbalance.Text = result_Cost_srp[2].ToString("N2");
                    LBstatus.Text = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT pay_status_name FROM salesinvoice.pay_status WHERE pay_status_id= (SELECT pay_status_id FROM salesinvoice.salesinvoice_status WHERE invoice_id='" + invoice_id + "')");
                    LBstatus.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                    ShowItem();
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();
            }

        }

        private void ShowItem()
        {


        }


        public Dictionary<int, List<string>> SN = new();

        private void LoadingTable()
        {
            DataTable ConfirmdataTable = new DataTable();
            ProductGridView.DataSource = ConfirmdataTable;
            ConfirmdataTable.Columns.Add("ID", typeof(int));
            ProductGridView.Columns["ID"].FillWeight = 25; 
            ConfirmdataTable.Columns.Add("Product Model", typeof(string));
            ConfirmdataTable.Columns.Add("Product Name", typeof(string));
            ConfirmdataTable.Columns.Add("Quantity", typeof(int));
            ProductGridView.Columns["Quantity"].FillWeight = 50;
            ConfirmdataTable.Columns.Add("SRP", typeof(decimal));
            ConfirmdataTable.Columns.Add("SN", typeof(string));
            DataTable Trans_Table = SQLConnect.Instance.LoadDateTableStorage("SELECT * FROM salesinvoice.salesinvoiceitem WHERE invoice_id = '" + invoiceitem_id + "'");
            Trans_Table.Columns.Remove("invoice_id");
            Trans_Table.Columns.Remove("invoice_number");
            Trans_Table.Columns.Remove("created_on");
            List<int> Product_id = ResetLoadTable(Trans_Table);
            Dictionary<int, int> Product_qty = ResetLoadProductQtyTable(Trans_Table);
            List<decimal> srp = SelectSrp(Trans_Table);
            List<string> sn = Selectsn(Trans_Table);
            SN = ResetLoadProductSNTable(Trans_Table);
            textqty.Text = TotQTY(Product_qty).ToString();
            for (int i = 0; i < Product_id.Count; i++)
            {
                DataRow row = ConfirmdataTable.NewRow();
                row[0] = Product_id[i];
                row[1] = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT model FROM productlibrary.product_sum WHERE product_id=" + Product_id[i] + "");
                row[2] = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT name FROM productlibrary.product_sum WHERE product_id=" + Product_id[i] + "");
                //row[3] = Product_qty[Product_id[i]];
                row[3] = "1";
                row[4] = srp[i];
                row[5] = sn[i];
                ConfirmdataTable.Rows.Add(row);

            }


        }

        private List<string> Selectsn(DataTable dataTable)
        {
            List<string> Product_sn = new();
            int Tab_Count = dataTable.Columns.Count;
            for (int i = 0; i < Tab_Count; i += 5)
            {
                if (dataTable.Rows[0][i] == DBNull.Value)
                {
                    break;
                }
                else
                {
                    string sro = (string)dataTable.Rows[0][i + 4]; ;
                    Product_sn.Add(sro);
                }
            }
            return Product_sn;
        }

        private List<decimal> SelectSrp(DataTable dataTable)
        {
            List<decimal> Product_srp = new();
            int Tab_Count = dataTable.Columns.Count;
            for (int i = 0; i < Tab_Count; i += 5)
            {
                if (dataTable.Rows[0][i] == DBNull.Value)
                {
                    break;
                }
                else
                {
                    decimal sro = (decimal)dataTable.Rows[0][i + 2]; ;
                    Product_srp.Add(sro);
                }
            }
            //Product_id = Product_id.Distinct().ToList();
            return Product_srp;
        }

        private int TotQTY(Dictionary<int, int> Product_qty)
        {
            int Total = Product_qty.Sum(x => x.Value);
            return Total;
        }

        private List<int> ResetLoadTable(DataTable dataTable)
        {
            List<int> Product_id = new();
            int Tab_Count = dataTable.Columns.Count;
            for (int i = 0; i < Tab_Count; i += 5)
            {
                if (dataTable.Rows[0][i] == DBNull.Value)
                {
                    break;
                }
                else
                {
                    int MyString = (int)dataTable.Rows[0][i];
                    Product_id.Add(MyString);
                }
            }
            //Product_id = Product_id.Distinct().ToList();
            return Product_id;
        }

        private Dictionary<int, int> ResetLoadProductQtyTable(DataTable dataTable)
        {
            Dictionary<int, int> Product_Qty = new();
            List<int> Product_id = new();
            int Tab_Count = dataTable.Columns.Count;
            for (int i = 0; i < Tab_Count; i += 5)
            {
                if (dataTable.Rows[0][i] == DBNull.Value)
                {
                    break;
                }
                else
                {
                    int MyString = (int)dataTable.Rows[0][i];
                    Product_id.Add(MyString);
                }
            }
            foreach (var item in Product_id.GroupBy(s => s))
            {
                Product_Qty.Add(item.Key, item.Count());
            }
            return Product_Qty;
        }

        private Dictionary<int, List<string>> ResetLoadProductSNTable(DataTable dataTable)
        {
            Dictionary<int, List<string>> Product_SNDic = new();

            int Tab_Count = dataTable.Columns.Count;
            for (int i = 0; i < Tab_Count; i += 5)
            {
                if (dataTable.Rows[0][i] == DBNull.Value)
                {
                    break;
                }
                else
                {
                    int Pro_id = (int)dataTable.Rows[0].Field<int>(i);
                    string Pro_SN = (string)dataTable.Rows[0][i + 4];
                    if (Product_SNDic.ContainsKey(Pro_id))
                    {
                        Product_SNDic[Pro_id].Add(Pro_SN);
                    }
                    else
                    {
                        Product_SNDic.Add(Pro_id, new List<string> { Pro_SN });
                    }
                }
            }
            return Product_SNDic;
        }
    }
}
