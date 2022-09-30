using ADIONSYS.Plugin.User.AddUser.AddAccount;
using ADIONSYS.Plugin.User.AddUser.DeleteAccount;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.User.AddUser
{
    public partial class AddUserSetting : Form
    {
        public AddUserSetting()
        {
            InitializeComponent();
        }


        private void BtnUserAdd_Click(object sender, EventArgs e)
        {
            AddAccountForm AddAccountForm = new AddAccountForm();
            AddAccountForm.ShowDialog();

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteAccountForm DeleteAccountForm = new DeleteAccountForm();
            DeleteAccountForm.ShowDialog();
        }
    }
}
