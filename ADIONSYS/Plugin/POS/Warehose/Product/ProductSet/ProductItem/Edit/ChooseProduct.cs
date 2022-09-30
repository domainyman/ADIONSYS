using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.SupplierSet.Edit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.ProductItem.Edit
{
    public partial class ChooseProduct : Form
    {
        public ChooseProduct()
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
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT name FROM productlibrary.product_sum");
                CMBoxList.DataSource = result;
            }
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            string name = CMBoxList.Text;
            if (name != string.Empty)
            { 
                EditProduct EditProduct = new EditProduct(name);
                if (EditProduct.ShowDialog() == DialogResult.Cancel)
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
