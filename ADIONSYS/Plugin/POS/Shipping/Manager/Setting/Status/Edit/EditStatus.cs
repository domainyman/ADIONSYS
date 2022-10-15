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

namespace ADIONSYS.Plugin.POS.Shipping.Manager.Setting.Status.Edit
{
    public partial class EditStatus : Form
    {
        public EditStatus()
        {
            InitializeComponent();
            Startup();
        }

        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT status_name FROM invoiceshipping.status ORDER BY status_id");
                CMBoxList.DataSource = result;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

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

        private bool CheckTransportStatus(string name)
        {
            List<string> result_status = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT status_id FROM invoiceshipping.status WHERE status_name= '" + name + "'");
            if (result_status.Count > 0 && result_status.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBrandName.Text != string.Empty )
                {
                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        string OldStatus = CMBoxList.Text;
                        string newname = textBrandName.Text;
                        if (CheckTransportStatus(newname) == true)
                        {
                            this.LBMessageBox.Text = "This Status has existed!";
                            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                        }
                        else
                        {
                            int result_status_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT status_id FROM invoiceshipping.status WHERE status_name='" + OldStatus + "'");
                            List<int> result_product_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT shippinginv_id FROM invoiceshipping.shipping_status WHERE status_id='" + result_status_id + "'");
                            if (result_product_id.Count > 0)
                            {
                                MessageContinue MessageContinue = new MessageContinue("Status is currently using!");
                                if (MessageContinue.ShowDialog() == DialogResult.Continue)
                                {
                                    SQLConnect.Instance.PgSQL_Command("UPDATE invoiceshipping.status SET status_name='" + newname + "' WHERE status_id='" + result_status_id + "'");
                                    Startup();
                                    savelabel();
                                    textBrandName.Text = string.Empty;
                                }
                                else if (MessageContinue.ShowDialog() == DialogResult.Cancel)
                                {
                                    vaildlabel();
                                }
                            }
                            else if (result_product_id.Count == 0)
                            {
                                SQLConnect.Instance.PgSQL_Command("UPDATE invoiceshipping.status SET status_name='" + newname + "' WHERE status_id='" + result_status_id + "'");
                                Startup();
                                savelabel();
                                textBrandName.Text = string.Empty;
                            }
                        }

                    }
                    else
                    {
                        vaildlabel();
                    }
                }
                else
                {
                    this.LBMessageBox.Text = "Not a valid infomation!";
                    this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                    this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageInfo = new MessageInfo(ex.Message);
                MessageInfo.ShowDialog();
            }

        }

    }
}
