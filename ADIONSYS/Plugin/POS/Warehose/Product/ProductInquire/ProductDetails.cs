using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.ProductItem.Edit;
using ADIONSYS.Tool;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Windows.Graphics.Printing;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductInquire
{
    public partial class ProductDetails : Form
    {
        string product_id;
        public ProductDetails(int row_id)
        {
            product_id = row_id.ToString();
            InitializeComponent();
            Startup();
            ShowProductDetailGridView();
        }

        private void Startup()
        {
            List<string> result_info = Selectinfomation(product_id);
            List<decimal> result_cost_srp = Selectcost_srp(product_id);
            List<int> result_suplier_id = SelectSupplierid(product_id);
            List<int> result_ProductQty = SelectProductQty(product_id);
            string supp_name = Selectsupplier(result_suplier_id[0]);
            bool state = SelectinfomationBool(product_id);
            ShowForm(result_info, result_cost_srp, result_ProductQty, state, supp_name, product_id);
        }

        private void ShowProductDetailGridView()
        {
            LoadingTable();
            if(ProductDetailGridView.ColumnCount > 0)
            {
                ProductDetailGridView.Columns[0].HeaderText = "ID";
                ProductDetailGridView.Columns[0].FillWeight = 25;
                ProductDetailGridView.Columns[1].HeaderText = "Serial No";
                ProductDetailGridView.Columns[2].HeaderText = "Storage";
                ProductDetailGridView.Columns[3].HeaderText = "Supplier";
                ProductDetailGridView.Columns[4].HeaderText = "Cost";
                ProductDetailGridView.Columns[4].DefaultCellStyle.Format = "N2";

                ProductDetailGridView.Columns[5].HeaderText = "Status";
            }
            else
            {
                LBrecord.Text = "No Records Found ";
            }

        }

        private void LoadingTable()
        {

            //Fix it
            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id='" + product_id + "'");
            string droptablename = "productlibrary." + "\"" + result_hash_name + "\"";
            string cmd = "SELECT product_id,sn,st.storage_name as storage ,su.supplier_name as Supplier,cost,upper((SELECT status_name FROM productlibrary.status WHERE status_id = li.status))" +
                "FROM " + droptablename + " li " +
                "INNER JOIN productsupplier.supplier su ON li.supplier_id=su.supplier_id " +
                "INNER JOIN productstorage.storage st ON li.storage_id = st.storage_id " +
                "ORDER BY product_id";
            SQLConnect.Instance.LoadDateView(ProductDetailGridView, cmd);
            if(((DataTable)ProductDetailGridView.DataSource).Rows.Count > 0)
            {
                LBTotal.Text = "Count : " + ((DataTable)ProductDetailGridView.DataSource).Rows.Count.ToString();
                
            }
            else
            {
                LBTotal.Text = "Count : 0 ";

            }

        }

        private void ShowForm(List<string> name_info, List<decimal> result_cost_srp, List<int> result_ProductQty, bool state,string supp_name, string product_id)
        {
            textName.Text = name_info[0];
            textModel.Text = name_info[1];
            textBarcode_1.Text = name_info[2];
            textBarcode_2.Text = name_info[3];
            textBarcode_3.Text = name_info[4];
            textqty.Text = result_ProductQty[0].ToString();
            textSupplier.Text = supp_name;
            textComment.Text = name_info[5];
            textCost.Text = result_cost_srp[0].ToString("N2"); ;
            textsrp.Text = result_cost_srp[1].ToString("N2"); ;
            if (state == true)
            {
                this.LBState_use.Text = "Activated";
                this.LBState_use.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            }
            else if (state == false)
            {
                this.LBState_use.Text = "Inactivated";
                this.LBState_use.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            }

        }

        private List<int> SelectSupplierid(string id_info)
        {
            List<int> resultsupplier_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT supplier_id FROM productlibrary.product_sum WHERE product_id='" + id_info + "'");
            return resultsupplier_id;
        }

        private List<int> SelectProductQty(string id_info)
        {
            List<int> resultProductQty = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT qty FROM productlibrary.product_sum WHERE product_id='" + id_info + "'");
            return resultProductQty;
        }

        private string Selectsupplier(int id_info)
        {
            string result_supplier_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT supplier_name FROM productsupplier.supplier WHERE supplier_id='" + id_info + "'");
            return result_supplier_name;
        }
        private List<string> Selectinfomation(string id_info)
        {
            List<string> result_Product_info = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT name,model,ean_0,ean_1,ean_2," +
                "comment FROM productlibrary.product_sum WHERE product_id='" + id_info + "'");
            return result_Product_info;
        }

        private List<decimal> Selectcost_srp(string id_info)
        {
            List<decimal> result_Cost_srp = SQLConnect.Instance.PgSQL_SELECTDataDecimal("SELECT cost,srp FROM productlibrary.product_sum WHERE product_id='" + id_info + "'");
            return result_Cost_srp;
        }

        private bool SelectinfomationBool(string id_info)
        {
            bool result_Product_state = SQLConnect.Instance.PgSQL_SELECTDataBool("SELECT state FROM productlibrary.product_sum WHERE product_id='" + id_info + "'");
            return result_Product_state;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string name = textName.Text;
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
                
            }

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (ProductDetailGridView.ColumnCount > 0)
            {
                try
                {
                    string RowNameFilter = string.Format("[{0}] Like '%{1}%'", "sn", textSearch.Text);
                    ((DataTable)ProductDetailGridView.DataSource).DefaultView.RowFilter = RowNameFilter;
                    LBTotal.Text = "Count : " + ProductDetailGridView.Rows.Count.ToString();
                }
                catch (Exception ex)
                {
                    MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                    MessageBox_text.ShowDialog();
                }
            }
        }

        private void ProductDetailGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow Row = ProductDetailGridView.Rows[e.RowIndex];
                    int row_id = Convert.ToInt32(Row.Cells[0].Value);
                    EditProductDetail EditProductDetail = new EditProductDetail(product_id,row_id);
                    if (EditProductDetail.ShowDialog() == DialogResult.Cancel)
                    {
                        ShowProductDetailGridView();
                    }
                }
                catch (Exception ex)
                {
                    MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                    MessageBox_text.ShowDialog();
                }

            }
        }
    }
}
