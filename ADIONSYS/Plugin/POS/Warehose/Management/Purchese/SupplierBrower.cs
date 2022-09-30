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
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADIONSYS.Plugin.POS.Warehose.Management.Purchese
{
    public partial class SupplierBrower : Form
    {

        public SupplierBrower()
        {
            InitializeComponent();
            ShowSupplierDetailGridView();


        }

        private void Loadtable()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                SQLConnect.Instance.LoadDateView(SupplierDetailGridView, "SELECT supplier_id,supplier_name,address,contact,con_tel FROM productsupplier.supplier ORDER BY supplier_name");
                if (((DataTable)SupplierDetailGridView.DataSource).Rows.Count > 0)
                {
                    LBCount.Text = "Count : " + ((DataTable)SupplierDetailGridView.DataSource).Rows.Count.ToString();
                }
                else
                {
                    LBCount.Text = "Count : 0 ";

                }
            }
        }
        private void ShowSupplierDetailGridView()
        {
            Loadtable();
            if (SupplierDetailGridView.ColumnCount > 0)
            {
                SupplierDetailGridView.Columns[0].HeaderText = "ID";
                SupplierDetailGridView.Columns[0].FillWeight = 25;
                SupplierDetailGridView.Columns[1].HeaderText = "Supplier Name";
                SupplierDetailGridView.Columns[2].HeaderText = "Address";
                SupplierDetailGridView.Columns[3].HeaderText = "Contact Person ";
                SupplierDetailGridView.Columns[4].HeaderText = "Contact Number";

            }
            else
            {
                LBrecord.Text = "No Records Found ";
            }

        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            if (SupplierDetailGridView.ColumnCount > 0)
            {
                try
                {
                    string RowNameFilter = string.Format("[{0}] Like '%{1}%' OR [{2}] Like '%{3}%'", "supplier_name", textSearch.Text, "address", textSearch.Text);
                    ((DataTable)SupplierDetailGridView.DataSource).DefaultView.RowFilter = RowNameFilter;
                    LBCount.Text = "Count : " + SupplierDetailGridView.Rows.Count.ToString();
                }
                catch (Exception ex)
                {
                    MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                    MessageBox_text.ShowDialog();
                }
            }
        }

        public string? TextMsg { set; get; }

        private void SupplierDetailGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow Row = SupplierDetailGridView.Rows[e.RowIndex];
                    TextMsg = Row.Cells[0].Value.ToString();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                    MessageBox_text.ShowDialog();

                }

            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            TextMsg = String.Empty;
            this.Close();
        }
    }
}
