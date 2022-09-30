using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.User.Permission.PerRole
{
    public partial class PerRoleEditForm : Form
    {
        public PerRoleEditForm()
        {
            InitializeComponent();
            StartupPerRole();
        }



        private void StartupPerRole()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT role_name FROM username.roles");
                CMBoxList.DataSource = result;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void BtnSettingCategory_Click(object sender, EventArgs e)
        {

        }


    }
}
