using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADIONSYS.ConvertFunction;
using ADIONSYS.Tool;

namespace ADIONSYS.Plugin.POS.Shipping.Inquiry
{
    public partial class EditStatus : Form
    {
        public int shippinginvid; 
        public EditStatus(int shippinginv_id)
        {
            shippinginvid = shippinginv_id;
            InitializeComponent();
            Startup();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT status_name FROM invoiceshipping.status");
                CMBoxList.DataSource = result;
                string status = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT status_name FROM invoiceshipping.status WHERE status_id = (SELECT status_id FROM invoiceshipping.shipping_status WHERE shippinginv_id = '" + shippinginvid + "')");
                CMBoxList.SelectedItem = status;

                List<string> result_mo = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT method_name FROM invoiceshipping.method");
                textmethod.DataSource = result_mo;
                string method = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT method_name FROM invoiceshipping.method WHERE method_id = (SELECT ship_method FROM invoiceshipping.shippinginv WHERE shippinginv_id = '" + shippinginvid + "')");
                
                if (method != string.Empty || method != null)
                {
                    textmethod.SelectedItem = method;
                }
                else
                {
                    textmethod.SelectedIndex = -1;
                }
                textmethodDe.Text = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT ship_details FROM invoiceshipping.shippinginv WHERE shippinginv_id = '" + shippinginvid + "'");
            }
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (Checkupload() == true && CMBoxList.Text != string.Empty )
                {
                    savelabel();
                }
                else
                {
                    vaildlabel();
                }
            }
            catch(Exception ex)
            {
                MessageInfo MessageInfo = new MessageInfo(ex.Message);
                MessageInfo.ShowDialog();
            }

        }

        private bool Checkupload()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {

                string status = CMBoxList.Text;
                string method = textmethod.Text;
                string methodda = textmethodDe.Text;
                string data = ConvertType.GetTimeStamp();
                int shipping_status_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT status_id FROM invoiceshipping.status WHERE status_name = '" + status + "'");
                int method_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT method_id FROM invoiceshipping.method WHERE method_name = '" + method + "'");
                SQLConnect.Instance.PgSQL_Command("UPDATE invoiceshipping.shipping_status SET status_id ='" + shipping_status_id + "',upload_date = '" + data  + "' WHERE shippinginv_id='" + shippinginvid + "'");
                SQLConnect.Instance.PgSQL_Command("UPDATE invoiceshipping.shippinginv SET ship_method ='" + method_id + "',ship_details = '" + methodda + "',upload_date = '"+ data  + "' WHERE shippinginv_id='" + shippinginvid + "'");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void vaildlabel()
        {
            this.LBMessageBox.Text = "Not a valid infomation!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
        }

        private void CMBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void savelabel()
        {
            this.LBMessageBox.Text = "Saved!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
        }
    }
}
