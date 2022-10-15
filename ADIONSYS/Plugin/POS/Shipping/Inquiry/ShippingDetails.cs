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
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ADIONSYS.Plugin.POS.Shipping.Inquiry
{
    public partial class ShippingDetails : Form
    {
        public string Tp_invoice;
        public int shippinginv_id;
        public ShippingDetails(string Tp_inv)
        {
            InitializeComponent();
            Tp_invoice = Tp_inv;
            ShowForm();
        }

        private void ShowForm()
        {
            try
            {
                List<string> resultDetails = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT invoice," +
                    "ship_details,ship_company,ship_person,ship_address,ship_tel,ship_comment,comment FROM invoiceshipping.shippinginv shippinv WHERE ship_number = '" + Tp_invoice + "'");
                shippinginv_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT shippinginv_id FROM invoiceshipping.shippinginv WHERE ship_number = '" + Tp_invoice + "'");
                List<DateTime> result_DateTime = SQLConnect.Instance.PgSQL_SELECTDataDateTime("SELECT grant_date,upload_date FROM invoiceshipping.shipping_status WHERE shippinginv_id= '" + shippinginv_id + "'");
                int shipping_status_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT status_id FROM invoiceshipping.shipping_status WHERE shippinginv_id = '" + shippinginv_id + "'");
                string status = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT status_name FROM invoiceshipping.status WHERE status_id='" + shipping_status_id + "'");
                string Method = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT method_name FROM invoiceshipping.method WHERE method_id = (SELECT ship_method FROM invoiceshipping.shippinginv WHERE ship_number = '" + Tp_invoice + "')");
                string username = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT username FROM username.accounts WHERE user_id = (SELECT username FROM invoiceshipping.shippinginv WHERE ship_number = '" + Tp_invoice + "')");
                textinvoicenum.Text = resultDetails[0];
                textUser.Text = username;
                textmethod.Text = Method;
                textMethodDetails.Text = resultDetails[1];
                textShippingCompany.Text = resultDetails[2];
                textPerson.Text = resultDetails[3];
                textship_address.Text = resultDetails[4];
                texttel.Text = resultDetails[5];
                textShippingDescription.Text = resultDetails[6];
                textComment.Text = resultDetails[7];
                textCreatedate.Text = result_DateTime[0].ToString();
                textUpdataDate.Text = result_DateTime[1].ToString();
                LBState_use.Text = status;




            }
            catch (Exception ex)
            {
                MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                MessageBox_text.ShowDialog();

            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }

        private void BtnComment_Click(object sender, EventArgs e)
        {
            CommentEdit CommentEdit = new(shippinginv_id);
            if (CommentEdit.ShowDialog() == DialogResult.Cancel)
            {
                ShowForm();
            }

        }

        private void BtnINVDetail_Click(object sender, EventArgs e)
        {

        }
    }
}
