using ADIONSYS.Plugin.POS.Member.Add;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.POS.Member
{
    public partial class MemberForm : Form
    {
        public MemberForm()
        {
            InitializeComponent();
        }

        private void ShowForm(Form form)
        {
            form.TopLevel = false;
            this.MemberContainer.Panel2.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddMember AddMember = new();
            ShowForm(AddMember);
        }
    }
}
