using ADIONSYS.ConvertFunction;
using ADIONSYS.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Windows.ApplicationModel.Contacts;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.ProductItem.Edit
{
    public partial class EditProduct : Form
    {
        List<int> result_Product_id;
        public EditProduct(string text)
        {
            InitializeComponent();
            Startup();
            string name = text;
            result_Product_id = SelectProductid(name);
            List<string> result_info = Selectinfomation(name);          
            List<int> result_suplier_id = SelectSupplierid(name);
            bool state = SelectinfomationBool(name);
            List<decimal> result_cost_srp = Selectcost_srp(name);
            ShowForm(result_info, state, result_suplier_id, result_cost_srp, result_Product_id);
        }



        private void ShowForm(List<string> name_info, bool state, List<int> result_suplier_id, List<decimal> result_cost_srp, List<int> result_Product_id)
        {
            this.LBSystemCode.Text = result_Product_id[0].ToString();
            this.textname.Text = name_info[0];
            this.textmodel.Text = name_info[1];
            this.textBarcode_1.Text = name_info[2];
            this.textBarcode_2.Text = name_info[3];
            this.textBarcode_3.Text = name_info[4];
            this.textCost.Text = result_cost_srp[0].ToString("N2");
            this.textSRP.Text = result_cost_srp[1].ToString("N2"); ;
            this.textComment.Text = name_info[5];
            int supp_id = result_suplier_id[0];
            string brand_name = Selectbrand(result_Product_id[0]);
            string supp_name = Selectsupplier(supp_id);
            string category_name = SelectCategory(result_Product_id[0]);
            CMBProductCategory.Text = category_name;
            CMBBrand.SelectedItem = brand_name;
            CMBSupplier.SelectedItem = supp_name;

            if (state == true)
            {
                CMBoxList.SelectedItem = CMBoxList.Items[0];
            }
            else if (state == false)
            {
                CMBoxList.SelectedItem = CMBoxList.Items[1];
            }
        }

        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> Categoryresult = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT category_name FROM productcategory.category");
                CMBProductCategory.DataSource = Categoryresult;
                List<string> Brandresult = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT brand_name FROM productbrand.brand");
                CMBBrand.DataSource = Brandresult;
                List<string> Supplierresult = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT supplier_name FROM productsupplier.supplier");
                CMBSupplier.DataSource = Supplierresult;
                CMBoxList.Items.Add("Activated");
                CMBoxList.Items.Add("Inactivated");
            }
        }

        private List<string> Selectinfomation(string name_info)
        {
            List<string> result_Product_info = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT name,model,ean_0,ean_1,ean_2," +
                "comment FROM productlibrary.product_sum WHERE name='" + name_info + "'");
            return result_Product_info;
        }
        private List<int> SelectProductid(string name_info)
        {
            List<int> result_Product_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT product_id FROM productlibrary.product_sum WHERE name='" + name_info + "'");
            return result_Product_id;
        }
        private List<int> SelectSupplierid(string name_info)
        {
            List<int> resultsupplier_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT supplier_id FROM productlibrary.product_sum WHERE name='" + name_info + "'");
            return resultsupplier_id;
        }

        private List<int> SelectSupplierSQLid(string name_info)
        {
            List<int> resultsupplier_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT supplier_id FROM productsupplier.supplier WHERE supplier_name='" + name_info + "'");
            return resultsupplier_id;
        }

        private List<int> SelectBrandid(string name_info)
        {
            List<int> resultBrand_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT brand_id FROM productbrand.brand WHERE brand_name='" + name_info + "'");
            return resultBrand_id;
        }

        private List<int> SelectCategoryid(string name_info)
        {
            List<int> resultCategory_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT category_id FROM productcategory.category WHERE category_name='" + name_info + "'");
            return resultCategory_id;
        }
        private bool SelectinfomationBool(string name_info)
        {
            bool result_Product_state = SQLConnect.Instance.PgSQL_SELECTDataBool("SELECT state FROM productlibrary.product_sum WHERE name='" + name_info + "'");
            return result_Product_state;
        }

        private string Selectsupplier(int name_info)
        {
            string result_supplier_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT supplier_name FROM productsupplier.supplier WHERE supplier_id='" + name_info + "'");
            return result_supplier_name;
        }

        private List<decimal> Selectcost_srp(string name_info)
        {
            List<decimal> result_Cost_srp = SQLConnect.Instance.PgSQL_SELECTDataDecimal("SELECT cost,srp FROM productlibrary.product_sum WHERE name='" + name_info + "'");
            return result_Cost_srp;
        }

        private string Selectbrand(int name_info)
        {
            List<int> result_brand_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT brand_id FROM productbrand.product_brand WHERE product_id='" + name_info + "'");
            string result_brand_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT brand_name FROM productbrand.brand WHERE brand_id='" + result_brand_id[0] + "'");
            return result_brand_name;
        }

        private string SelectCategory(int name_info)
        {
            List<int> result_Category_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT category_id FROM productcategory.product_category WHERE product_id='" + name_info + "'");
            string result_Category_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT category_name FROM productcategory.category WHERE category_id='" + result_Category_id[0] + "'");
            return result_Category_name;
        }



        private void textCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar > 8 && (int)e.KeyChar < 46) || (int)e.KeyChar > 57 || (int)e.KeyChar == 47 || (int)e.KeyChar < 8)
            {
                
                e.Handled = true;
            }
            else
            {
                int i = textCost.Text.IndexOf(".");
                if (i != -1 && (int)e.KeyChar == 46)
                {
                    e.Handled = true;
                }
            }
        }

        private void textSRP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar > 8 && (int)e.KeyChar < 46) || (int)e.KeyChar > 57 || (int)e.KeyChar == 47 || (int)e.KeyChar < 8)
            {
               
                e.Handled = true;
            }
            else
            {
                int i = textSRP.Text.IndexOf(".");
                if (i != -1 && (int)e.KeyChar == 46)
                {
                    e.Handled = true;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (textname.Text != string.Empty && textmodel.Text != string.Empty && CMBProductCategory.Text != string.Empty &&
                CMBBrand.Text != string.Empty && CMBSupplier.Text != string.Empty)
            {
                try
                {
                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        string name = textname.Text;
                        string model = textmodel.Text;
                        string Cost = textCost.Text.Replace(",", "");
                        if (Cost == string.Empty)
                        {
                            Cost = "0";
                        }
                        string Srp = textSRP.Text.Replace(",", "");
                        if (Srp == string.Empty)
                        {
                            Srp = "0";
                        }
                        string Barcode_0 = textBarcode_1.Text;
                        string Barcode_1 = textBarcode_2.Text;
                        string Barcode_2 = textBarcode_3.Text;
                        string Comment = textComment.Text;
                        string data = ConvertType.GetTimeStamp();
                        string ProductCategory = CMBProductCategory.Text;
                        List<int> ProductCategory_id = SelectCategoryid(ProductCategory);
                        string Brand = CMBBrand.Text;
                        List<int> Brand_id = SelectBrandid(Brand);
                        string Supplier = CMBSupplier.Text;
                        List <int> Supplier_id = SelectSupplierSQLid(Supplier);
                        List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT name FROM productlibrary.product_sum except SELECT name FROM productlibrary.product_sum WHERE product_id='" + result_Product_id[0] + "'");
                        if (result.Contains(name))
                        {
                            this.LBMessageBox.Text = "This Product has existed!";
                            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                        }
                        else
                        {
                            SQLConnect.Instance.PgSQL_Command("UPDATE productlibrary.product_sum SET " +
                                "name = '" + name + "', " +
                                "model = '" + model + "', " +
                                "ean_0 = '" + Barcode_0 + "', " +
                                "ean_1 = '" + Barcode_1 + "', " +
                                "ean_2 = '" + Barcode_2 + "', " +
                                "cost = '" + Cost + "', " +
                                "srp = '" + Srp + "', " +
                                "comment = '" + Comment + "', " +
                                "created_on = '" + data + "' WHERE product_id = '" + result_Product_id[0] + "'");
                            
                            SQLConnect.Instance.PgSQL_Command("UPDATE productlibrary.product_sum SET supplier_id = '" + Supplier_id[0] + "' WHERE product_id = '" + result_Product_id[0] + "'");
                            SQLConnect.Instance.PgSQL_Command("UPDATE productbrand.product_brand SET brand_id = '" + Brand_id[0] + "', grant_date = '" + data + "' WHERE product_id = '" + result_Product_id[0] + "'");
                            SQLConnect.Instance.PgSQL_Command("UPDATE productcategory.product_category SET category_id = '" + ProductCategory_id[0] + "', grant_date = '" + data + "' WHERE product_id = '" + result_Product_id[0] + "'");
                            
                            if (CMBoxList.SelectedItem == CMBoxList.Items[0])
                            {
                                bool state = true;
                                SQLConnect.Instance.PgSQL_Command("UPDATE productlibrary.product_sum SET state = '" + state + "' WHERE product_id = '" + result_Product_id[0] + "'");
                                
                            }
                            else if (CMBoxList.SelectedItem == CMBoxList.Items[1])
                            {
                                bool state = false;
                                SQLConnect.Instance.PgSQL_Command("UPDATE productlibrary.product_sum SET state = '" + state + "' WHERE product_id = '" + result_Product_id[0] + "'");
                                
                            } 
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
                MessageInfo MessageInfo = new MessageInfo("Not a valid infomation!");
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
            this.LBMessageBox.Text = "Not a vaild infomation!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
        }
        private void textSRP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBarcode_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBarcode_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBarcode_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
