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

namespace ADIONSYS.Plugin.POS.Shipping.Manager.Setting.Method.Edit
{
    public partial class EditMethod : Form
    {
        public EditMethod()
        {
            InitializeComponent();
            Startup();
        }

        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT method_name FROM invoiceshipping.method ORDER BY method_id");
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
            this.LBMessageBox.Text = "Brand is currently using!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
        }

        private bool CheckTransportMethod(string name)
        {
            List<string> result_status = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT method_id FROM invoiceshipping.method WHERE method_name = '" + name + "'");
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
                if (textBrandName.Text != string.Empty)
                {
                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        string OldStatus = CMBoxList.Text;
                        string newname = textBrandName.Text;
                        if (CheckTransportMethod(newname) == true)
                        {
                            this.LBMessageBox.Text = "This Method has existed!";
                            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                            this.LBMessageBox.Image = Properties.Resources.x_mark_24;
                        }
                        else
                        {
                            int result_Method_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT method_id FROM invoiceshipping.method WHERE method_name='" + OldStatus + "'");
                            List<int> result_shippinginv_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT shippinginv_id FROM invoiceshipping.shippinginv WHERE ship_method='" + result_Method_id + "'");
                            if (result_shippinginv_id.Count > 0)
                            {
                                MessageContinue MessageContinue = new MessageContinue("Method is currently using!");
                                if (MessageContinue.ShowDialog() == DialogResult.Continue)
                                {
                                    SQLConnect.Instance.PgSQL_Command("UPDATE invoiceshipping.method SET method_name='" + newname + "' WHERE method_id='" + result_Method_id + "'");
                                    Startup();
                                    savelabel();
                                    textBrandName.Text = string.Empty;
                                }
                                else if (MessageContinue.ShowDialog() == DialogResult.Cancel)
                                {
                                    vaildlabel();
                                }
                            }
                            else if (result_shippinginv_id.Count == 0)
                            {
                                SQLConnect.Instance.PgSQL_Command("UPDATE invoiceshipping.method SET method_name ='" + newname + "' WHERE method_id ='" + result_Method_id + "'");
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
