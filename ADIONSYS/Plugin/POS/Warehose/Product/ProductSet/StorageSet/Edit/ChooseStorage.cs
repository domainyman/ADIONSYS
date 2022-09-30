using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.StorageSet.Edit
{
    public partial class ChooseStorage : Form
    {
        public ChooseStorage()
        {
            InitializeComponent();
            Startup();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT storage_name FROM productstorage.storage");
                CMBoxList.DataSource = result;
            }
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            string name = CMBoxList.Text;
            if (name != "Summary")
            {
                EditStorage EditStorage = new EditStorage(name);
                if (EditStorage.ShowDialog() == DialogResult.Cancel)
                {
                    Startup();
                }
            }
            else
            {
                vaildlabel();
            }
        }
        private void vaildlabel()
        {
            this.LBMessageBox.Text = "Not a vaild infomation!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
        }


    }
}
