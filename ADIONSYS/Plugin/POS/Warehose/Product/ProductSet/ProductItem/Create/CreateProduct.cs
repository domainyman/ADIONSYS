using ADIONSYS.ConvertFunction;
using ADIONSYS.Tool;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.Brand.Create;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.CategorySet.Create;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.SupplierSet.Create;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Windows.ApplicationModel.Contacts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.ProductItem.Create
{
    public partial class CreateProduct : Form
    {
        public CreateProduct()
        {
            InitializeComponent();
            Startup();
        }

        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> Categoryresult = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT category_name FROM productcategory.category");
                CMBProductCategory.DataSource = Categoryresult;
                CMBProductCategory.SelectedIndex = -1;
                List<string> Brandresult = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT brand_name FROM productbrand.brand");
                CMBBrand.DataSource = Brandresult;
                CMBBrand.SelectedIndex = -1;
                List<string> Supplierresult = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT supplier_name FROM productsupplier.supplier");
                CMBSupplier.DataSource = Supplierresult;
                CMBSupplier.SelectedIndex = -1;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT name FROM productlibrary.product_sum");
                        string name = textname.Text;
                        string model = textmodel.Text;
                        string Cost = textCost.Text.Replace(",", "");
                        if(Cost== string.Empty)
                        {
                            Cost = "0";
                        }
                        string Srp = textSRP.Text.Replace(",", "");
                        if (Srp == string.Empty)
                        {
                            Srp = "0";
                        }
                        int qty = 0;
                        string Barcode_1 = textBarcode_1.Text;
                        string Barcode_2 = textBarcode_2.Text;
                        string Barcode_3 = textBarcode_3.Text;
                        string Comment = textComment.Text;
                        bool state = true;
                        string data = ConvertType.GetTimeStamp();
                        string ProductCategory = CMBProductCategory.Text;
                        string Brand = CMBBrand.Text;
                        string Supplier = CMBSupplier.Text;
                        List<string> HashList = ConvertType.Hash(1,2);
                        string Hash = HashList[0].ToLower();
                        string schemasname = "productlibrary.";
                        if (result.Contains(name))
                        {
                            this.LBMessageBox.Text = "This Product has existed!";
                            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                        }
                        else
                        {
                            SQLConnect.Instance.PgSQL_Command("INSERT INTO productlibrary.product_sum(name," +
                                "model," +
                                "ean_0," +
                                "ean_1," +
                                "ean_2," +
                                "cost," +
                                "srp," +
                                "qty," +
                                "state," +
                                "comment," +
                                "hash," +
                                "created_on) VALUES('" + name + "','" + model + "','" + Barcode_1 + "','" + Barcode_2 + "','" + Barcode_3 + "','" + Cost + "'," +
                                "'" + Srp + "','" + qty + "','" + state + "','" + Comment + "','" + Hash + "','" + data + "')");
                            
                            List<int> result_productsum_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT product_id FROM productlibrary.product_sum WHERE name='" + name + "'");
                            List<int> result_category_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT category_id FROM productcategory.category WHERE category_name='" + ProductCategory + "'");
                            SQLConnect.Instance.PgSQL_Command("INSERT INTO productcategory.product_category(product_id,category_id,grant_date) VALUES ('" + result_productsum_id[0] + "','" + result_category_id[0] + "','" + data + "')");
                            List<int> result_Brand_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT brand_id FROM productbrand.brand WHERE brand_name='" + Brand + "'");
                            SQLConnect.Instance.PgSQL_Command("INSERT INTO productbrand.product_brand(product_id,brand_id,grant_date) VALUES ('" + result_productsum_id[0] + "','" + result_Brand_id[0] + "','" + data + "')");
                            List<int> result_Supplier_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT supplier_id FROM productsupplier.supplier WHERE supplier_name='" + Supplier + "'");
                            SQLConnect.Instance.PgSQL_Command("UPDATE productlibrary.product_sum SET supplier_id = '"+ result_Supplier_id[0] + "' WHERE product_id = '" + result_productsum_id[0] + "'");
                            SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS " + schemasname +"\""+ Hash + "\"(" +
                                "product_id bigserial," +
                                "sn VARCHAR ( 50 ) NOT NULL," +
                                "cost decimal NOT NULL," +
                                "qty INT NOT NULL," +
                                "supplier_id INT NOT NULL," +
                                "storage_id INT NOT NULL," +
                                "inv_id INT NOT NULL," +
                                "status INT NOT NULL," +
                                "state boolean NOT NULL," +
                                "comment VARCHAR ( 50 )," +
                                "booking_no VARCHAR ( 50 )," +
                                "booking_day TIMESTAMP ," +
                                "purchese_no VARCHAR ( 50 ) NOT NULL," +
                                "purchese_day DATE NOT NULL," +
                                "selling_no VARCHAR ( 50 )," +
                                "selling_day TIMESTAMP," +
                                "created_on TIMESTAMP NOT NULL," +
                                "PRIMARY KEY(product_id)," +
                                "FOREIGN KEY (supplier_id) REFERENCES productsupplier.supplier (supplier_id)," +
                                "FOREIGN KEY (inv_id) REFERENCES tableinvoice.invoicenum (invoice_id)," +
                                "FOREIGN KEY (status) REFERENCES productlibrary.status (status_id)," +
                                "FOREIGN KEY (storage_id) REFERENCES productstorage.storage (storage_id))");
                            
                            this.LBMessageBox.Text = "Saved!";
                            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
                            ClearText();
                        }
                    }
                    else
                    {
                        this.LBMessageBox.Text = "Not a vaild infomation!";
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
            else
            {
                this.LBMessageBox.Text = "Not a vaild infomation!";
                this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
            }
        }


        private void ClearText()
        {
            Startup();
            textname.Text = string.Empty;
            textmodel.Text = string.Empty;
            textCost.Text = string.Empty;
            textSRP.Text = string.Empty;
            textComment.Text = string.Empty;
            textBarcode_1.Text = string.Empty;
            textBarcode_2.Text = string.Empty;
            textBarcode_3.Text = string.Empty;


        }
        private void BtnCreatePro_Category_Click(object sender, EventArgs e)
        {
            CreateCategory CreateCategory = new CreateCategory();
            if(CreateCategory.ShowDialog() == DialogResult.Cancel )
            {
                Startup();
            }
        }

        private void BtnCreatePro_Brand_Click(object sender, EventArgs e)
        {
            CreateBrand CreateBrand = new CreateBrand();
            if (CreateBrand.ShowDialog() == DialogResult.Cancel)
            {
                Startup();
            }
        }

        private void BtnCreatePro_Supplier_Click(object sender, EventArgs e)
        {
            CreateSupplier CreateSupplier = new CreateSupplier();
            if (CreateSupplier.ShowDialog() == DialogResult.Cancel)
            {
                Startup();
            }
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
