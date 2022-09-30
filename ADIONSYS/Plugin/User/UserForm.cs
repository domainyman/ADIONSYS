using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADIONSYS.Plugin.User.AddUser;
using ADIONSYS.Plugin.User.Permission;
using ADIONSYS.Plugin.User.UserSetting;

namespace ADIONSYS.Plugin.User
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void TopLabel_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void CollapseMenu()
        {
            if (this.UserContainer.SplitterDistance == 120)
            {
                this.UserContainer.SplitterDistance = 40;
                foreach (Button meunButton in UserPanel.Controls.OfType<Button>())
                {
                    meunButton.Text = String.Empty;
                    meunButton.ImageAlign = ContentAlignment.MiddleCenter;
                    meunButton.Padding = new Padding(0);
                    TopLabel.Text = String.Empty;
                }
            }
            else if (this.UserContainer.SplitterDistance == 40)
            {
                this.UserContainer.SplitterDistance = 120;
                foreach (Button meunButton in UserPanel.Controls.OfType<Button>())
                {
                    meunButton.Text = meunButton.Tag.ToString();
                    meunButton.ImageAlign = ContentAlignment.MiddleLeft;
                    meunButton.TextAlign = ContentAlignment.MiddleRight;
                    meunButton.Padding = new Padding(0);
                    TopLabel.Text = TopLabel.Tag.ToString();
                }
            }
        }

        private void ShowForm(Form form)
        {
            form.TopLevel = false;
            this.UserContainer.Panel2.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }
        private void BtnPermission_Click(object sender, EventArgs e)
        {
            PermissionRole PermissionRole = new PermissionRole();
            ShowForm(PermissionRole);
        }

        private void BtnUserSetting_Click(object sender, EventArgs e)
        {
            UserSettingFunction UserSettingFunction = new UserSettingFunction();
            ShowForm(UserSettingFunction);
        }

        private void BtnAdduser_Click(object sender, EventArgs e)
        {
            AddUserSetting AddUserSetting = new AddUserSetting();
            ShowForm(AddUserSetting);
        }
    }
}
