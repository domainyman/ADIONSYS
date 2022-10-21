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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ADIONSYS.Plugin.POS.Shipping.Inquiry
{
    public partial class TransportSearch : Form
    {
        public TransportSearch()
        {
            InitializeComponent();
            Loadtable();
            Startup();
            SetupStatus();
        }

        private void Loadtable()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                SQLConnect.Instance.LoadDateView(ProductGridView, "SELECT (SELECT status_name FROM invoiceshipping.status WHERE status_id = shsta.status_id),invsh.invoice, invsh.ship_number, invsh.ship_company, invsh.comment,shsta.upload_date, invsh.created_on FROM invoiceshipping.shippinginv invsh INNER JOIN invoiceshipping.shipping_status shsta ON invsh.shippinginv_id = shsta.shippinginv_id ORDER BY shsta.grant_date");
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
                ProductGridView.Columns[0].HeaderText = "Status";
                ProductGridView.Columns[0].FillWeight = 100;
                ProductGridView.Columns[1].HeaderText = "INVOICE Number";
                ProductGridView.Columns[2].HeaderText = "Transport Number";
                ProductGridView.Columns[3].HeaderText = "Transport Name";
                ProductGridView.Columns[4].HeaderText = "Description";
                ProductGridView.Columns[5].HeaderText = "Updata Time";
                ProductGridView.Columns[6].HeaderText = "Create Time";

            }
            else
            {
                LBrecord.Text = "No Records Found ";
            }
        }

        private void textTransportNumber_TextChanged(object sender, EventArgs e)
        {
            if (ProductGridView.ColumnCount > 0)
            {
                try
                {
                    string RowNameFilter = string.Format("[{0}] Like '%{1}%' OR [{2}] Like '%{3}%'", "invoice", textTransportNumber.Text, "ship_number", textTransportNumber.Text);
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

        private void CMBClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductGridView.ColumnCount > 0)
            {
                try
                {
                    string RowNameFilter = string.Format("[{0}] Like '%{1}%'", "status_name", CMBstatus.Text);
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

        private void SetupStatus()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> resultClient = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT status_name FROM invoiceshipping.status");
                CMBstatus.DataSource = resultClient;
                CMBstatus.SelectedIndex = -1;
            }
        }

        private void ProductGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow Row = ProductGridView.Rows[e.RowIndex];
                    string tp_inv = Row.Cells[2].Value.ToString();
                    ShippingDetails ShippingDetails = new ShippingDetails(tp_inv);
                    if (ShippingDetails.ShowDialog() == DialogResult.Cancel)
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
