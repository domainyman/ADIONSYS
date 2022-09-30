using ADIONSYS.ConvertFunction;
using ADIONSYS.Plugin.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.User.UserSetting.ChangeUserRole
{
    public partial class ChangeUserRoleForm : Form
    {
        public ChangeUserRoleForm()
        {
            InitializeComponent();
            Startup();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                string name = ComboxUserName.Text;
                string role = ComboxNewRole.Text;
                string data = ConvertType.GetTimeStamp();
                List<int> resultuserid = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT user_id FROM username.accounts WHERE username='" + name + "'");
                List<int> resultuserroleid = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT role_id FROM username.roles WHERE role_name='" + role + "'");
                Task SQL = Task.Run(() => SQLConnect.Instance.PgSQL_Command("UPDATE username.account_roles SET role_id='" + resultuserroleid[0] + "',grant_date='" + data + "' WHERE user_id='" + resultuserid[0] + "'"));
                Task.WaitAll(SQL);
                this.LBMassegaBox.Text = "Role Changed!";
                this.LBMassegaBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                this.LBMassegaBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
            }
            else
            {
                this.LBMassegaBox.Text = "Not a vaild infomation!";
                this.LBMassegaBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                this.LBMassegaBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
            }

        }
        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT username FROM username.accounts");
                List<string> resultrolename = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT role_name FROM username.roles");
                ComboxUserName.DataSource = result;
                ComboxNewRole.DataSource = resultrolename;
            }
        }

        private void ComboxUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                string name = ComboxUserName.Text;
                List<int> resultuserid = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT user_id FROM username.accounts WHERE username='" + name + "'");
                List<int> resultuserroleid = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT role_id FROM username.account_roles WHERE user_id='" + resultuserid[0] + "'");
                List<string> resultrole = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT role_name FROM username.roles WHERE role_id='" + resultuserroleid[0] + "'");
                TextOldRole.Text = resultrole[0];
            }
        }
    }
}
