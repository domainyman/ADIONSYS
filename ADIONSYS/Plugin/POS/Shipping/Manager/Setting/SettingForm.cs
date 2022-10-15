using ADIONSYS.Plugin.POS.Shipping.Manager.Setting.Method.Create;
using ADIONSYS.Plugin.POS.Shipping.Manager.Setting.Method.Delete;
using ADIONSYS.Plugin.POS.Shipping.Manager.Setting.Method.Edit;
using ADIONSYS.Plugin.POS.Shipping.Manager.Setting.Status.Create;
using ADIONSYS.Plugin.POS.Shipping.Manager.Setting.Status.Delete;
using ADIONSYS.Plugin.POS.Shipping.Manager.Setting.Status.Edit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.POS.Shipping.Manager.Setting
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateStatus CreateStatus = new();
            CreateStatus.ShowDialog();

        }

        private void BtnProEdit_Click(object sender, EventArgs e)
        {
            EditMethod EditMethod = new();
            EditMethod.ShowDialog();

        }

        private void BtnStatusedit_Click(object sender, EventArgs e)
        {
            EditStatus EditStatus = new();
            EditStatus.ShowDialog();
        }

        private void BtnStatusDelete_Click(object sender, EventArgs e)
        {
            DeleteStatus DeleteStatus = new();
            DeleteStatus.ShowDialog();

        }

        private void BtnProCre_Click(object sender, EventArgs e)
        {
            CreateMethod CreateMethod = new();
            CreateMethod.ShowDialog();

        }

        private void BtnProDel_Click(object sender, EventArgs e)
        {
            DeleteMethod DeleteMethod = new();
            DeleteMethod.ShowDialog();
        }
    }
}
