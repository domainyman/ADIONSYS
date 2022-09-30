using ADIONSYS.Plugin.User.Permission.PerRole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.User.Permission
{
    public partial class PermissionRole : Form
    {
        public PermissionRole()
        {
            InitializeComponent();
        }

        private void BtnPerEdit_Click(object sender, EventArgs e)
        {
            PerRoleEditForm PerRoleEditForm = new PerRoleEditForm();
            PerRoleEditForm.ShowDialog();
        }

        private void BtnPerAdd_Click(object sender, EventArgs e)
        {
            PerRoleForm PerRoleForm = new PerRoleForm();
            PerRoleForm.ShowDialog();
        }

        private void LBPermassion_Click(object sender, EventArgs e)
        {

        }

        private void LBRole_Click(object sender, EventArgs e)
        {

        }

        private void LBUserRole_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnUserRoleEdit_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
