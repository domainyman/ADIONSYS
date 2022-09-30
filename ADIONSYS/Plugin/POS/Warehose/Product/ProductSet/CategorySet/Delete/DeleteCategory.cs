using ADIONSYS.Tool;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.CategorySet.Delete
{
    public partial class DeleteCategory : Form
    {
        public DeleteCategory()
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
                    string category = CMBoxList.Text;
                    if (category != "OTHER")
                    {
                        List<int> qtys = new List<int>();
                        List<int> result_category_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT category_id FROM productcategory.category WHERE category_name='" + category + "'");
                        List<int> result_product_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT product_id FROM productcategory.product_category WHERE category_id='" + result_category_id[0] + "'");
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
                            List<int> result_category_Otherid = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT category_id FROM productcategory.category WHERE category_name='OTHER'");
                            Task SQLRENEW = Task.Run(() => SQLConnect.Instance.PgSQL_Command("UPDATE productcategory.product_category SET category_id='" + result_category_Otherid[0] + "' WHERE category_id='" + result_category_id[0] + "'"));
                            SQLRENEW.Wait();
                            Task SQL = Task.Run(() => SQLConnect.Instance.PgSQL_Command("DELETE FROM productcategory.category WHERE category_id='" + result_category_id[0] + "'"));
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
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT category_name FROM productcategory.category");
                CMBoxList.DataSource = result;
            }
        }


    }
}
