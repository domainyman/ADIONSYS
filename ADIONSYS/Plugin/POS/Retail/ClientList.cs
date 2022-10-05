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

namespace ADIONSYS.Plugin.POS.Retail
{
    public partial class ClientList : Form
    {
        public ClientList()
        {
            InitializeComponent();
            ShowClientDetailGridView();
        }

        private void Loadtable()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                SQLConnect.Instance.LoadDateView(ClientDetailGridView, "SELECT member_id,customer_sc,member_number,tel_no,email FROM storagemember.member ORDER BY member_number");
                if (((DataTable)ClientDetailGridView.DataSource).Rows.Count > 0)
                {
                    LBTotal.Text = "Count : " + ((DataTable)ClientDetailGridView.DataSource).Rows.Count.ToString();
                }
                else
                {
                    LBTotal.Text = "Count : 0 ";

                }
            }
        }

        private void ShowClientDetailGridView()
        {
            Loadtable();
            if (ClientDetailGridView.ColumnCount > 0)
            {
                ClientDetailGridView.Columns[0].HeaderText = "ID";
                ClientDetailGridView.Columns[0].FillWeight = 40;
                ClientDetailGridView.Columns[1].HeaderText = "Customer Code";
                ClientDetailGridView.Columns[2].HeaderText = "Name";
                ClientDetailGridView.Columns[3].HeaderText = "Telphone";
                ClientDetailGridView.Columns[4].HeaderText = "Email";

            }
            else
            {
                LBrecord.Text = "No Records Found ";
            }

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (ClientDetailGridView.ColumnCount > 0)
            {
                try
                {
                    string RowNameFilter = string.Format("[{0}] Like '%{1}%'", "member_number", textSearch.Text);
                    ((DataTable)ClientDetailGridView.DataSource).DefaultView.RowFilter = RowNameFilter;
                    LBTotal.Text = "Count : " + ClientDetailGridView.Rows.Count.ToString();
                }
                catch (Exception ex)
                {
                    MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                    MessageBox_text.ShowDialog();
                }
            }
        }
        public string? TextMsg { set; get; }
        public int? TextMsg_id { set; get; }
        private void ClientDetailGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow Row = ClientDetailGridView.Rows[e.RowIndex];
                    TextMsg = Row.Cells[2].Value.ToString();
                    TextMsg_id = Convert.ToInt32( Row.Cells[0].Value);
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
