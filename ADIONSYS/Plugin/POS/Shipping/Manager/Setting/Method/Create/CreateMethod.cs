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

namespace ADIONSYS.Plugin.POS.Shipping.Manager.Setting.Method.Create
{
    public partial class CreateMethod : Form
    {
        public CreateMethod()
        {
            InitializeComponent();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (SQLConnect.Instance.ConnectState() == true && textStatus.Text != string.Empty)
                {
                    List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT method_name FROM invoiceshipping.method");
                    string name = textStatus.Text;

                    if (result.Contains(name))
                    {
                        this.LBMessageBox.Text = "This method has existed!";
                        this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                        this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                    }
                    else
                    {
                        SQLConnect.Instance.PgSQL_Command("INSERT INTO invoiceshipping.method(method_name) VALUES ('" + name + "')");
                        this.LBMessageBox.Text = "Saved!";
                        this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                        this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
                    }
                }
                else
                {
                    this.LBMessageBox.Text = "Not a vaild infomation!";
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
