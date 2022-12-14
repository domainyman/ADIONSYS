using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ADIONSYS.Tool;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.Brand.Edit
{
    public partial class EditBrand : Form
    {
        public EditBrand()
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
                if (textBrandName.Text != string.Empty && CMBoxList.Text!= "OTHER")
                {
                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT brand_name FROM productbrand.brand");
                        string brand = CMBoxList.Text;
                        string newname = textBrandName.Text;
                        if (result.Contains(newname))
                        {
                            this.LBMessageBox.Text = "This brand has existed!";
                            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                        }
                        else
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
                                MessageContinue MessageContinue = new MessageContinue("Brand is currently using!");
                                if (MessageContinue.ShowDialog() == DialogResult.Continue)
                                {
                                    SQLConnect.Instance.PgSQL_Command("UPDATE productbrand.brand SET brand_name='" + newname + "' WHERE brand_id='" + result_brand_id[0] + "'");
                                    Startup();
                                    savelabel();
                                    textBrandName.Text = string.Empty;
                                }
                                else if (MessageContinue.ShowDialog() == DialogResult.Cancel)
                                {
                                    vaildlabel();
                                }
                            }
                            else if (qtys.Sum() == 0)
                            {
                                Task SQL = Task.Run(() => SQLConnect.Instance.PgSQL_Command("UPDATE productbrand.brand SET brand_name='" + newname + "' WHERE brand_id='" + result_brand_id[0] + "'"));
                                Task.WaitAll(SQL);
                                Startup();
                                savelabel();
                                textBrandName.Text = string.Empty;
                            }
                        }

                    }
                    else
                    {
                        vaildlabel();
                    }
                }
                else
                {
                    this.LBMessageBox.Text = "Not a valid infomation!";
                    this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                    this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
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
            this.LBMessageBox.Text = "Brand is currently using!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
        }

        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT brand_name FROM productbrand.brand");
                CMBoxList.DataSource = result;
                CMBoxList.SelectedIndex = -1;
            }
        }
    }
}
