using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADIONSYS.Tool;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.Brand.Delete
{
    public partial class DeleteBrand : Form
    {
        public DeleteBrand()
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
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    string brand = CMBoxList.Text;
                    if (CMBoxList.Text != "OTHER")
                    {
                        List<int> qtys = new List<int>();
                        List<int> result_brand_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT brand_id FROM productbrand.brand WHERE brand_name='" + brand + "'");
                        List<int> result_product_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT product_id FROM productbrand.product_brand WHERE brand_id='" + result_brand_id[0] + "'");
                        for (int i = 0; i < result_product_id.Count; i++)
                        {
                            List<int> result_product_qty = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT qty FROM productlibrary.product_sum WHERE product_id='" + result_product_id[i] + "'");
                            qtys.Add(result_product_qty[0]);
                        }
                        if (qtys.Sum() > 0)
                        {
                            vaildlabel();
                        }
                        else if (qtys.Sum() == 0)
                        {
                            List<int> result_brand_Otherid = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT brand_id FROM productbrand.brand WHERE brand_name='OTHER'");
                            Task SQLRENEW = Task.Run(() => SQLConnect.Instance.PgSQL_Command("UPDATE productbrand.product_brand SET brand_id='" + result_brand_Otherid[0] + "' WHERE brand_id='" + result_brand_id[0] + "'"));
                            SQLRENEW.Wait();
                            Task SQL = Task.Run(() => SQLConnect.Instance.PgSQL_Command("DELETE FROM productbrand.brand WHERE brand_id='" + result_brand_id[0] + "'"));
                            SQL.Wait();
                            Startup();
                            savelabel();
                        }
                    }
                    else
                    {
                        vaildlabel();
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

        private void savelabel()
        {
            this.LBMessageBox.Text = "Saved!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
        }

        private void vaildlabel()
        {
            this.LBMessageBox.Text = "Category is currently using!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
        }

        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT brand_name FROM productbrand.brand");
                CMBoxList.DataSource = result;
            }
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

        private void CMBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
