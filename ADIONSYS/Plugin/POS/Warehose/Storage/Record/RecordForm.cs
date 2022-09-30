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

namespace ADIONSYS.Plugin.POS.Warehose.Storage.Record
{
    public partial class RecordForm : Form
    {
        public RecordForm()
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
                SQLConnect.Instance.LoadDateView(TransferGridView, "SELECT (SELECT transfer_number FROM storagetransfer.transfer WHERE transfer_id = tst.transfer_id)," +
                    "(SELECT upper(status_name) FROM storagetransfer.status WHERE status_id = tst.status_id)," +
                    "grant_date,upload_date FROM storagetransfer.transfer_status tst ORDER BY transfer_id");
                if (((DataTable)TransferGridView.DataSource).Rows.Count > 0)
                {
                    LBTotal.Text = "Count : " + ((DataTable)TransferGridView.DataSource).Rows.Count.ToString();
                }
                else
                {
                    LBTotal.Text = "Count : 0 ";

                }

            }
        }

        private void Startup()
        {
            if (TransferGridView.ColumnCount > 0)
            {
                TransferGridView.Columns[0].HeaderText = "Transfer Number";
                TransferGridView.Columns[1].HeaderText = "Status";
                TransferGridView.Columns[2].HeaderText = "Create Date";
                TransferGridView.Columns[3].HeaderText = "Updata Date";
                

            }
            else
            {
                LBrecord.Text = "No Records Found ";
            }
        }

        private void textProduct_TextChanged(object sender, EventArgs e)
        {
            if (TransferGridView.ColumnCount > 0)
            {
                try
                {
                    string RowNameFilter = string.Format("[{0}] Like '%{1}%'", "transfer_number", textTransfer.Text);
                    ((DataTable)TransferGridView.DataSource).DefaultView.RowFilter = RowNameFilter;
                    LBTotal.Text = "Count : " + TransferGridView.Rows.Count.ToString();
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
