using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.User.UserSetting.ResetPassword
{
    public partial class ResetUserPasswordForm : Form
    {
        public ResetUserPasswordForm()
        {
            InitializeComponent();
            StartupUser();
        }

        private void StartupUser()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT username FROM username.accounts");
                this.ComboxUserName.DataSource = result;
            }
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (textoldpassword.Text != string.Empty && textnewpassword.Text != string.Empty && textRePassword.Text != string.Empty && ComboxUserName.Text != string.Empty)
            {
                try
                {

                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        string name = this.ComboxUserName.Text;
                        List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT password FROM username.accounts WHERE username='" + name + "'");
                        if (textoldpassword.Text == result[0])
                        {
                            if (textnewpassword.Text == textRePassword.Text)
                            {
                                string password = textRePassword.Text;
                                Task SQL = Task.Run(() => SQLConnect.Instance.PgSQL_Command("UPDATE username.accounts SET password='" + password + "' WHERE username='" + name + "'"));
                                Task.WaitAll(SQL);
                                this.LBMassegaBox.Text = "Password Changed!";
                                this.LBMassegaBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                                this.LBMassegaBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
                            }
                        }
                        else
                        {
                            this.LBMassegaBox.Text = "Not a vaild infomation!";
                            this.LBMassegaBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                            this.LBMassegaBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                        }

                    }
                }
                catch
                {

                }
            }
        }
    }
}
