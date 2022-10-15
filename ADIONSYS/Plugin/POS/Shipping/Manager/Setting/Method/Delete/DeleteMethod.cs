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

namespace ADIONSYS.Plugin.POS.Shipping.Manager.Setting.Method.Delete
{
    public partial class DeleteMethod : Form
    {
        public DeleteMethod()
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
                    string Method_name = CMBoxList.Text;
                    if (Method_name != "OTHER" && Method_name != string.Empty)
                    {
                        int result_method_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT method_id FROM invoiceshipping.method WHERE method_name='" + Method_name + "'");
                        List<int> result_shippinginv_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT shippinginv_id FROM invoiceshipping.shippinginv WHERE ship_method='" + result_method_id + "'");
                        if (result_shippinginv_id.Count > 0)
                        {
                            vaildlabel();
                        }
                        else if (result_shippinginv_id.Count == 0)
                        {
                            SQLConnect.Instance.PgSQL_Command("DELETE FROM invoiceshipping.method WHERE method_name='" + Method_name + "'");
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
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT method_name FROM invoiceshipping.method");
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
            this.LBMessageBox.Text = "Method is currently using!";
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
