using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADIONSYS.Tool;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.ProductItem.Delete
{
    public partial class DeleteProduct : Form
    {
        public DeleteProduct()
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
            if (CMBoxList.Text != string.Empty)
            {
                try
                {
                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        string product_name = CMBoxList.Text;
                        List<int> result_product_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT product_id FROM productlibrary.product_sum WHERE name='" + product_name + "'");
                        string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + result_product_id[0] + "");
                        string droptablename = "productlibrary." +"\"" + result_hash_name + "\"";
                        List<int> result_product_QTY = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT qty FROM productlibrary.product_sum WHERE product_id='" + result_product_id[0] + "'");
                        if (result_product_QTY[0] > 0 || result_product_QTY[0] < 0)
                        {
                            vaildlabel();
                        }
                        else if (result_product_QTY[0] == 0)
                        {
                            SQLConnect.Instance.PgSQL_Command("DELETE FROM productcategory.product_category WHERE product_id='" + result_product_id[0] + "'");
                            SQLConnect.Instance.PgSQL_Command("DELETE FROM productbrand.product_brand WHERE product_id='" + result_product_id[0] + "'");
                            
                            SQLConnect.Instance.PgSQL_Command("DELETE FROM productlibrary.product_sum WHERE product_id='" + result_product_id[0] + "'");
                            
                            SQLConnect.Instance.PgSQL_Command("DROP TABLE IF EXISTS " + droptablename);
                            
                            Startup();
                            savelabel();
                        }
                    }
                    else
                    {
                        vaildlabel();
                    }
                }
                catch (Exception ex)
                {
                    MessageInfo MessageInfo = new MessageInfo(ex.Message);
                    MessageInfo.ShowDialog();
                }
            }
            else
            {
                this.LBMessageBox.Text = "Not a vaild infomation!";
                this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
            }

        }

        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT name FROM productlibrary.product_sum");
                CMBoxList.DataSource = result;
            }
        }

        private void vaildlabel()
        {
            this.LBMessageBox.Text = "Product is currently using!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
        }
        private void savelabel()
        {
            this.LBMessageBox.Text = "Saved!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
        }
    }
}
