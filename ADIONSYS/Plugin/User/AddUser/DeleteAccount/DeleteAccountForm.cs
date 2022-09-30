using ADIONSYS.ConvertFunction;
using ADIONSYS.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.User.AddUser.DeleteAccount
{
    public partial class DeleteAccountForm : Form
    {
        public DeleteAccountForm()
        {
            InitializeComponent();
            Startup();
        }

        private void Startup()
        {
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT username FROM username.accounts");
            ComboxUser.DataSource = result;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    if(ComboxUser.Text == ApplicationSetting.Default.User)
                    {
                        vaildlabel();
                    }
                    else
                    {
                        string user = ComboxUser.Text;
                        List<int> result = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT user_id FROM username.accounts WHERE username='" + user + "'");
                        Task SQL = Task.Run(() => SQLConnect.Instance.PgSQL_Command("DELETE FROM username.account_roles WHERE user_id='" + result[0] + "'"));
                        Task.WaitAll(SQL);
                        Task SQL_1 = Task.Run(() => SQLConnect.Instance.PgSQL_Command("DELETE FROM username.accounts WHERE user_id='" + result[0] + "'"));
                        Task.WaitAll(SQL_1);
                        Startup();
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
    }
}
