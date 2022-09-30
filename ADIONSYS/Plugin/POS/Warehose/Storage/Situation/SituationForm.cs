using ADIONSYS.Plugin.POS.Warehose.Product.ProductInquire;
using ADIONSYS.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.POS.Warehose.Storage.Situation
{
    public partial class SituationForm : Form
    {
        public SituationForm()
        {
            InitializeComponent();
            Loadtable();
            Startup();
        }
        private void Loadtable()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                SQLConnect.Instance.LoadDateView(SituationGridView, "SELECT st.transfer_id,upper((SELECT status_name FROM storagetransfer.status WHERE status_id = str.status_id))," +
                    " st.transfer_number,(SELECT storage_name FROM productstorage.storage WHERE storage_id = st.from_storage)," +
                    "(SELECT storage_name FROM productstorage.storage WHERE storage_id = st.to_storage)," +
                    "comment,created_on FROM storagetransfer.transfer st " +
                    "INNER JOIN storagetransfer.transfer_status str " +
                    "ON st.transfer_id = str.transfer_id " +
                    "WHERE st.from_storage = (SELECT storage_id FROM productstorage.storage WHERE storage_name = '" + ApplicationSetting.Default.Location + "') ORDER BY st.transfer_number");
                SQLConnect.Instance.LoadDateView(ConfirmGridView, "SELECT st.transfer_id,upper((SELECT status_name FROM storagetransfer.status WHERE status_id = str.status_id))," +
                    " st.transfer_number,(SELECT storage_name FROM productstorage.storage WHERE storage_id = st.from_storage)," +
                    "(SELECT storage_name FROM productstorage.storage WHERE storage_id = st.to_storage)," +
                    "comment,created_on FROM storagetransfer.transfer st " +
                    "INNER JOIN storagetransfer.transfer_status str " +
                    "ON st.transfer_id = str.transfer_id " +
                    "WHERE st.to_storage = (SELECT storage_id FROM productstorage.storage WHERE storage_name = '" + ApplicationSetting.Default.Location + "') ORDER BY st.transfer_number");

            }
        }

        private void Startup()
        {
            if (SituationGridView.ColumnCount > 0)
            {
                SituationGridView.Columns[0].Visible = false;
                SituationGridView.Columns[1].HeaderText = "Status";
                SituationGridView.Columns[2].HeaderText = "Transfer Number";
                SituationGridView.Columns[3].HeaderText = "From";
                SituationGridView.Columns[4].HeaderText = "To";
                SituationGridView.Columns[5].HeaderText = "Description";
                SituationGridView.Columns[6].HeaderText = "Date";
            }
            else
            {
                LBrecord.Text = "No Records Found ";
            }

            if (ConfirmGridView.ColumnCount > 0)
            {
                ConfirmGridView.Columns[0].Visible = false;
                ConfirmGridView.Columns[1].HeaderText = "Status";
                ConfirmGridView.Columns[2].HeaderText = "Transfer Number";
                ConfirmGridView.Columns[3].HeaderText = "From";
                ConfirmGridView.Columns[4].HeaderText = "To";
                ConfirmGridView.Columns[5].HeaderText = "Description";
                ConfirmGridView.Columns[6].HeaderText = "Date";
            }
            else
            {
                LBrecord.Text = "No Records Found ";
            }
        }

        private void SituationGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow Row = SituationGridView.Rows[e.RowIndex];
                    int row_id = Convert.ToInt32(Row.Cells[0].Value);
                    TransferDetil TransferDetil = new(row_id);
                    if (TransferDetil.ShowDialog() == DialogResult.Cancel)
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

        private void ConfirmGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow Row = ConfirmGridView.Rows[e.RowIndex];
                    int row_id = Convert.ToInt32(Row.Cells[0].Value);
                    ConfirmDetil ConfirmDetil = new(row_id);
                    if (ConfirmDetil.ShowDialog() == DialogResult.Cancel)
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
