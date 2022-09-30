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

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.SupplierSet.Delete
{
    public partial class DeleteSupplier : Form
    {
        public DeleteSupplier()
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
                    List<int> qty_list = new List<int>();
                    string supplier = CMBoxList.Text;
                    if (supplier != "OTHER")
                    {
                        List<int> result_supplier_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT supplier_id FROM productsupplier.supplier WHERE supplier_name='" + supplier + "'");
                        List<int> result_product_code = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT product_id FROM productlibrary.product_sum");
                        for (int i = 0; i < result_product_code.Count; i++)
                        {
                            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id='" + result_product_code[i] + "'");
                            string droptablename = "productlibrary." + "\"" + result_hash_name + "\"";
                            List<int> result_supplier = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT qty FROM " + droptablename + " WHERE supplier_id='" + result_supplier_id[0] + "'");
                            qty_list.Add(result_supplier.Sum());
                        }
                        if (qty_list.Sum() > 0)
                        {
                            vaildlabel();
                        }
                        else if (qty_list.Sum() == 0)
                        {
                            List<int> result_supplier_Otherid = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT supplier_id FROM productsupplier.supplier WHERE supplier_name='OTHER'");
                            for (int i = 0; i < result_product_code.Count; i++)
                            {
                                string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id='" + result_product_code[i] + "'");
                                string droptablename = "productlibrary." + "\"" + result_hash_name + "\"";
                                List<int> result_supplier = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT product_id FROM " + droptablename + " WHERE supplier_id='" + result_supplier_id[0] + "'");
                                for (int q = 0; q < result_supplier.Count; q++)
                                {
                                    SQLConnect.Instance.PgSQL_Command("UPDATE " + droptablename + " SET supplier_id='" + result_supplier_Otherid[0] + "' WHERE product_id='" + result_supplier[q] + "'");
                                    
                                }
                            }
                            List<int> result_supplier_ProductSum = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT product_id FROM productlibrary.product_sum WHERE supplier_id='" + result_supplier_id[0] + "'");
                            for(int w = 0; w < result_supplier_ProductSum.Count; w++)
                            {
                                SQLConnect.Instance.PgSQL_Command("UPDATE productlibrary.product_sum SET supplier_id='" + result_supplier_Otherid[0] + "' WHERE product_id='" + result_supplier_ProductSum[w] + "'");
                                
                            }
                            SQLConnect.Instance.PgSQL_Command("DELETE FROM productsupplier.supplier WHERE supplier_id='" + result_supplier_id[0] + "'");
                            Startup();
                            savelabel();
                        }
                    }
                    else
                    {
                        vaildlabel();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageInfo = new MessageInfo(ex.Message);
                MessageInfo.ShowDialog();
            }
        }


        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT supplier_name FROM productsupplier.supplier");
                CMBoxList.DataSource = result;
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
            this.LBMessageBox.Text = "Supplier is currently using!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LBSupplier_Click(object sender, EventArgs e)
        {

        }

        private void LBtop_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LBMessageBox_Click(object sender, EventArgs e)
        {

        }

        private void CMBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
