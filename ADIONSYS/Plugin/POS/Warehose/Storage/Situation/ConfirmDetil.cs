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

namespace ADIONSYS.Plugin.POS.Warehose.Storage.Situation
{
    public partial class ConfirmDetil : Form
    {
        public int Transfers_id;
        public ConfirmDetil(int id)
        {
            InitializeComponent();
            Transfers_id = id;
            Startup();
        }

        private void Startup()
        {
            List<string> result_Transfer_info = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT transfer_number,(SELECT storage_name FROM productstorage.storage WHERE storage_id = tr.from_storage)" +
                ",(SELECT storage_name FROM productstorage.storage WHERE storage_id = tr.to_storage)" +
                ",username,comment FROM storagetransfer.transfer tr WHERE transfer_id='" + Transfers_id + "'");
            List<DateTime> result_DateTime = SQLConnect.Instance.PgSQL_SELECTDataDateTime("SELECT created_on FROM storagetransfer.transfer WHERE transfer_id= '" + Transfers_id + "'");
            Textcodeno.Text = result_Transfer_info[0];
            LBTextFrom.Text = result_Transfer_info[1];
            LBTextFrom.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            LBTextTo.Text = result_Transfer_info[2];
            LBTextTo.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            LBusername.Text = result_Transfer_info[3];
            textComment.Text = result_Transfer_info[4];
            LBTransDate.Text = result_DateTime[0].ToString("dd-MM-yyyy");
            LBtextstatus.Text= SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT upper((SELECT status_name FROM storagetransfer.status WHERE status_id =" +
                "(SELECT status_id FROM storagetransfer.transfer_status WHERE transfer_id = '" + Transfers_id + "')))");
            LBtextstatus.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            ShowTransDetailGridView();
        }

        private void ShowTransDetailGridView()
        {
            LoadingTable();
            //if (ProductDetailGridView.ColumnCount > 0)
            //{
            //    ProductDetailGridView.Columns[0].HeaderText = "ID";
            //    ProductDetailGridView.Columns[0].FillWeight = 25;
            //    ProductDetailGridView.Columns[1].HeaderText = "Serial No";
            //    ProductDetailGridView.Columns[2].HeaderText = "Storage";
            //    ProductDetailGridView.Columns[3].HeaderText = "Supplier";
            //    ProductDetailGridView.Columns[4].HeaderText = "Cost";
            //    ProductDetailGridView.Columns[4].DefaultCellStyle.Format = "N2";
            //    ProductDetailGridView.Columns[5].HeaderText = "Qty";
            //    //Fix it
            //    ProductDetailGridView.Columns[6].HeaderText = "State";
            //}
            //else
            //{
            //    LBrecord.Text = "No Records Found ";
            //}

        }
        private void LoadingTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Status");
            dt.Columns.Add("Product ID");
            dt.Columns.Add("Product Name");
            dt.Columns.Add("QTY");
            DataTable Trans_Table = SQLConnect.Instance.LoadDateTableStorage("SELECT upper((SELECT status_name FROM storagetransfer.status WHERE status_id =" +
                "(SELECT status_id FROM storagetransfer.transfer_status WHERE transfer_id = '" + Transfers_id + "')))AS status," +
                "* FROM storagetransfer.transferitem WHERE transfer_id = (SELECT transferitem_id FROM storagetransfer.transfer WHERE transfer_id = '" + Transfers_id + "')");
            Trans_Table.Columns.Remove("transfer_id");
            Trans_Table.Columns.Remove("transfer_number");
            Trans_Table.Columns.Remove("created_on");
            Trans_Table.Columns.Remove("state");
            List<int> Product_id = ResetLoadTable(Trans_Table);
            Dictionary<int, int> Product_qty = ResetLoadProductQtyTable(Trans_Table);
            //Dictionary<int, List<string>> Product_SN = ResetLoadProductSNTable(Trans_Table);
            for (int i = 0; i < Product_id.Count; i++)
            {
                DataRow row = dt.NewRow();
                row[0] = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT upper((SELECT status_name FROM storagetransfer.status WHERE status_id =" +
                "(SELECT status_id FROM storagetransfer.transfer_status WHERE transfer_id = '" + Transfers_id + "')))");
                row[1] = Product_id[i];
                row[2] = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT name FROM productlibrary.product_sum WHERE product_id=" + Product_id[i] + "");
                row[3] = Product_qty[Product_id[i]];
                dt.Rows.Add(row);

            }

            TransDetailGridView.DataSource = dt;

        }

        private List<int> ResetLoadTable(DataTable dataTable)
        {
            List<int> Product_id = new();
            int Tab_Count = dataTable.Columns.Count;
            for (int i = 1; i < Tab_Count; i += 3)
            {
                if (dataTable.Rows[0][i] == DBNull.Value)
                {
                    break;
                }
                else
                {
                    int MyString = (int)dataTable.Rows[0][i];
                    Product_id.Add(MyString);
                }
            }
            Product_id = Product_id.Distinct().ToList();
            return Product_id;
        }

        private Dictionary<int, int> ResetLoadProductQtyTable(DataTable dataTable)
        {
            Dictionary<int, int> Product_Qty = new();
            List<int> Product_id = new();
            int Tab_Count = dataTable.Columns.Count;
            for (int i = 1; i < Tab_Count; i += 3)
            {
                if (dataTable.Rows[0][i] == DBNull.Value)
                {
                    break;
                }
                else
                {
                    int MyString = (int)dataTable.Rows[0][i];
                    Product_id.Add(MyString);
                }
            }
            foreach (var item in Product_id.GroupBy(s => s))
            {
                Product_Qty.Add(item.Key, item.Count());
            }
            return Product_Qty;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SQLConnect.Instance.PgSQL_Command("UPDATE storagetransfer.transfer_status SET status_id = 3 WHERE transfer_id = '" + Transfers_id + "'");
            //}
            //catch (Exception ex) 
            //{
            //    MessageInfo MessageInfo = new MessageInfo(ex.Message);
            //    MessageInfo.ShowDialog();
            //}
        }
    }
}
