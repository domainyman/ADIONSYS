using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace ADIONSYS.Plugin.Setting.Password
{
    public partial class SettingAdmin : Form
    {
        public SettingAdmin()
        {
            InitializeComponent();
            Startup();
        }

        private void BtnResetUser_Click(object sender, EventArgs e)
        {
            Reusername Reusername = new Reusername();
            if (Reusername.ShowDialog() == DialogResult.Cancel)
            {
                Startup();
                Reusername.Dispose();
            }
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            Repassword Repassword = new Repassword();
            if (Repassword.ShowDialog() == DialogResult.Cancel)
            {
                Startup();
                Repassword.Dispose();
            }
        }

        private void Startup()
        {
            this.LBUSER.Text = ApplicationSetting.Default.Admin_User;

            string password = ApplicationSetting.Default.Admain_Password;
            char[] passwordArray = password.ToCharArray();
            char character = char.Parse("*");
            for (int i = 0; i < passwordArray.Length; i++)
            {
                passwordArray[i] = character; 
            }
            //string s = new string(passwordArray);
            this.LBPassword.Text = new string(passwordArray);
        }
    }
}
