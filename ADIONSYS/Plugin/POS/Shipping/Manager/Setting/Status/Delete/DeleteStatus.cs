using System;
using ADIONSYS.Tool;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.POS.Shipping.Manager.Setting.Status.Delete
{
    public partial class DeleteStatus : Form
    {
        public DeleteStatus()
        {
            InitializeComponent();
            Startup();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    string Status_name = CMBoxList.Text;
                    if (CMBoxList.Text != "OTHER" && CMBoxList.Text != string.Empty)
                    {
                        List<int> qtys = new List<int>();
                        int result_status_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT status_id FROM invoiceshipping.status WHERE status_name='" + Status_name + "'");
                        List<int> result_shippinginv_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT shippinginv_id FROM invoiceshipping.shipping_status WHERE status_id='" + result_status_id + "'");
                        if (result_shippinginv_id.Count > 0)
                        {
                            vaildlabel();
                        }
                        else if (result_shippinginv_id.Count == 0)
                        {
                            SQLConnect.Instance.PgSQL_Command("DELETE FROM invoiceshipping.status WHERE status_name='" + Status_name + "'");
                            Startup();
                            savelabel();
                        }
                    }
                    else
                    {
                        vaildlabel();
                    }
                }
                else
                {
                    Fixinfolabel();
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageInfo = new MessageInfo(ex.Message);
                MessageInfo.ShowDialog();
            }
        }
        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT status_name FROM invoiceshipping.status");
                CMBoxList.DataSource = result;
                CMBoxList.SelectedIndex = -1; ;
            }
        }

        private void savelabel()
        {
            this.LBMessageBox.Text = "Saved!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
        }

        private void vaildlabel()
        {
            this.LBMessageBox.Text = "Status is currently using!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
        }

        private void Fixinfolabel()
        {
            this.LBMessageBox.Text = "Not a vaild infomation!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
        }


    }
}
