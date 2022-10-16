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




    }
}
