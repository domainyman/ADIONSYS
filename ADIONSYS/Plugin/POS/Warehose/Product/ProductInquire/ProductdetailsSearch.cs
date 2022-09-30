using ADIONSYS.Tool;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductInquire
{
    public partial class ProductdetailsSearch : Form
    {
        public ProductdetailsSearch()
        {
            InitializeComponent();
            Loadtable();
            Startup();
        }

        private void Loadtable()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                //Fix it
                SQLConnect.Instance.LoadDateView(ProductGridView, "SELECT product_id,name,model,qty,state FROM productlibrary.product_sum ORDER BY name");
                if (((DataTable)ProductGridView.DataSource).Rows.Count > 0)
                {
                    LBTotal.Text = "Count : " + ((DataTable)ProductGridView.DataSource).Rows.Count.ToString();
                }
                else
                {
                    LBTotal.Text = "Count : 0 ";

                }

            }
        }

        private void Startup()
        {
            if (ProductGridView.ColumnCount > 0)
            {
                ProductGridView.Columns[0].HeaderText = "ID";
                ProductGridView.Columns[0].FillWeight = 25;
                ProductGridView.Columns[1].HeaderText = "Product Name";
                ProductGridView.Columns[2].HeaderText = "Product Model";
                ProductGridView.Columns[3].HeaderText = "QTY";
                ProductGridView.Columns[4].HeaderText = "State";
            }
            else
            {
                LBrecord.Text = "No Records Found ";
            }
        }

        private void textProduct_TextChanged(object sender, EventArgs e)
        {
            if (ProductGridView.ColumnCount > 0)
            { 
                try
                {
                    string RowNameFilter = string.Format("[{0}] Like '%{1}%' OR [{2}] Like '%{3}%'", "name", textProduct.Text, "model", textProduct.Text);
                    ((DataTable)ProductGridView.DataSource).DefaultView.RowFilter = RowNameFilter;
                    LBTotal.Text = "Count : " + ProductGridView.Rows.Count.ToString();
                }
                catch (Exception ex)
                {
                    MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                    MessageBox_text.ShowDialog();
                }
            }
        }

        private void ProductGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try 
                {
                    DataGridViewRow Row = ProductGridView.Rows[e.RowIndex];
                    int row_id = Convert.ToInt32( Row.Cells[0].Value); 
                    ProductDetails ProductDetails = new ProductDetails(row_id);
                    if (ProductDetails.ShowDialog() == DialogResult.Cancel)
                    {
                        Loadtable();
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
