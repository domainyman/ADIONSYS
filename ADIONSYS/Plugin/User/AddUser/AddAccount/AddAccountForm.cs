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
using Microsoft.VisualBasic.ApplicationServices;

namespace ADIONSYS.Plugin.User.AddUser.AddAccount
{
    public partial class AddAccountForm : Form
    {
        public AddAccountForm()
        {
            InitializeComponent();
            StartupPerRole();
        }

        private void StartupPerRole()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT role_name FROM username.roles");
                ComboxRole.DataSource = result;
                ComboxRole.SelectedIndex = -1;


                List<string> resultstorage = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT storage_name FROM productstorage.storage");
                CMBLogcation.DataSource = resultstorage;
                CMBLogcation.SelectedIndex = -1;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private  void BtnSave_Click(object sender, EventArgs e)
        {
            if (textUsername.Text != string.Empty && textPasswd.Text != string.Empty && ComboxRole.Text != string.Empty)
            {
                try
                {
                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        string user = textUsername.Text;
                        List<string> checkusernameresult = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT username FROM username.accounts WHERE username='" + user + "'");
                        if (checkusernameresult.Contains(user))
                        {
                            this.LBmessageBox.Text = "Username already exists!";
                            this.LBmessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                            this.LBmessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                        }
                        else
                        {
                            string passwd = textPasswd.Text;
                            string data = ConvertType.GetTimeStamp();
                            string roletext = ComboxRole.Text;
                            bool state = true;
                            string storagename = CMBLogcation.Text;
                            int storage = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT storage_id FROM productstorage.storage WHERE storage_name='" + storagename + "'");
                            SQLConnect.Instance.PgSQL_Command("INSERT INTO username.accounts(username,password,location_id,state,created_on,last_login) VALUES('" + user + "','" + passwd + "','" + storage + "','" + state +"','" + data + "','" + data + "')");
                            List<int> roleidresult = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT role_id FROM username.roles WHERE role_name='" + roletext + "'");
                            List<int> useridresult = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT user_id FROM username.accounts WHERE username='" + user + "'");
                            SQLConnect.Instance.PgSQL_Command("INSERT INTO username.account_roles(user_id,role_id,grant_date) VALUES('" + useridresult[0] + "','" + roleidresult[0] + "','" + data + "')");
                            savelabel();
                        }
                    }
                    else
                    {
                        vaildlabel();
                    }
                }
                catch (Exception ex)
                {
                    MessageInfo MessageInfo = new MessageInfo(ex.Message);
                    MessageInfo.ShowDialog();
                }
                finally
                {
                    ClearText();
                }
            }
        }

        private void savelabel()
        {
            this.LBmessageBox.Text = "Saved!";
            this.LBmessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            this.LBmessageBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
        }

        private void vaildlabel()
        {
            this.LBmessageBox.Text = "Not a vaild infomation!";
            this.LBmessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.LBmessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
        }
        private void ClearText()
        {
            this.textUsername.Text = string.Empty;
            this.textPasswd.Text = string.Empty;
        }
    }
}
