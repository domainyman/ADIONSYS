using Npgsql;
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
using System.Xml.Linq;

namespace ADIONSYS.Plugin.User.Permission.PerRole
{
    public partial class PerRoleForm : Form
    {
        public PerRoleForm()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (textRole.Text != string.Empty)
            {
                try
                {
                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT role_name FROM username.roles");
                        string name = textRole.Text;
                        if (result.Contains(name))
                        {
                            this.LBmessageBox.Text = "This roles has existed!";
                            this.LBmessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                            this.LBmessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                        }
                        else
                        {
                            Task SQL = Task.Run(() => SQLConnect.Instance.PgSQL_Command("INSERT INTO username.roles(role_name) VALUES ('" + name + "')"));
                            Task.WaitAll(SQL);
                            this.LBmessageBox.Text = "Saved!";
                            this.LBmessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                            this.LBmessageBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
                        }
                    }
                    else
                    {
                        this.LBmessageBox.Text = "Not a vaild infomation!";
                        this.LBmessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                        this.LBmessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
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
}
