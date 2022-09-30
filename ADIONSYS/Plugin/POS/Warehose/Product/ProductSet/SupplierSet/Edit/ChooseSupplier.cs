using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.SupplierSet.Edit
{
    public partial class ChooseSupplier : Form
    {
        public ChooseSupplier()
        {
            InitializeComponent();
            Startup();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            string name = CMBoxList.Text;
            if (name != "OTHER" && name !=string.Empty)
            {
                EditSupplier EditSupplier = new EditSupplier(name);
                if (EditSupplier.ShowDialog() == DialogResult.Cancel)
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

        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT supplier_name FROM productsupplier.supplier");
                CMBoxList.DataSource = result;
            }
        }

        private void CMBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LBCategory_Click(object sender, EventArgs e)
        {

        }

        private void LBtop_Click(object sender, EventArgs e)
        {

        }

        private void LBMessageBox_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
