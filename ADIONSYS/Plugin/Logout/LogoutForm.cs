using ADIONSYS.StartLoading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.Logout
{
    public partial class LogoutForm : Form
    {
        public LogoutForm()
        {
            InitializeComponent();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            ApplicationSetting.Default.User = String.Empty;
            ApplicationSetting.Default.Save();
            Application.Restart();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            ApplicationSetting.Default.User = String.Empty;
            ApplicationSetting.Default.Save();
            Application.Exit();
        }
    }
}
