using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADIONSYS.Plugin.User.UserSetting.ChangeUserRole;
using ADIONSYS.Plugin.User.UserSetting.ResetPassword;

namespace ADIONSYS.Plugin.User.UserSetting
{
    public partial class UserSettingFunction : Form
    {
        public UserSettingFunction()
        {
            InitializeComponent();
        }

        private void BtnUserPasswordEdit_Click(object sender, EventArgs e)
        {
            ResetUserPasswordForm ResetPassword = new ResetUserPasswordForm();
            ResetPassword.ShowDialog();
        }

        private void BtnUserRoleEdit_Click(object sender, EventArgs e)
        {
            ChangeUserRoleForm ChangeUserRoleForm = new ChangeUserRoleForm();
            ChangeUserRoleForm.ShowDialog();
        }
    }
}
