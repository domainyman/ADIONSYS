using ADIONSYS.Plugin.POS.Member.Add;
using ADIONSYS.Plugin.POS.Member.Edit;
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

namespace ADIONSYS.Plugin.POS.Member.MemberInquire
{
    public partial class MemberInquireForm : Form
    {
        public MemberInquireForm()
        {
            InitializeComponent();
            Loadtable();
            Startup();
        }

        private void Loadtable()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                SQLConnect.Instance.LoadDateView(MemberGridView, "SELECT member_id,member_number,birth,email,tel_no,mem_comment FROM storagemember.member ORDER BY member_id");
                if (((DataTable)MemberGridView.DataSource).Rows.Count > 0)
                {
                    LBTotal.Text = "Count : " + ((DataTable)MemberGridView.DataSource).Rows.Count.ToString();
                }
                else
                {
                    LBTotal.Text = "Count : 0 ";

                }

            }
        }

        private void Startup()
        {
            if (MemberGridView.ColumnCount > 0)
            {
                MemberGridView.Columns[0].HeaderText = "ID";
                MemberGridView.Columns[0].FillWeight = 40;
                MemberGridView.Columns[1].HeaderText = "Name";
                MemberGridView.Columns[2].HeaderText = "Date of Birth";
                MemberGridView.Columns[3].HeaderText = "Email";
                MemberGridView.Columns[4].HeaderText = "Tel_no";
                MemberGridView.Columns[5].HeaderText = "Description";
            }
            else
            {
                LBrecord.Text = "No Records Found ";
            }
        }

        private void textProduct_TextChanged(object sender, EventArgs e)
        {
            if (MemberGridView.ColumnCount > 0)
            {
                try
                {
                    string RowNameFilter = string.Format("[{0}] Like '%{1}%'", "member_number", textProduct.Text);
                    ((DataTable)MemberGridView.DataSource).DefaultView.RowFilter = RowNameFilter;
                    LBTotal.Text = "Count : " + MemberGridView.Rows.Count.ToString();
                }
                catch (Exception ex)
                {
                    MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                    MessageBox_text.ShowDialog();
                }
            }
        }


        private void MemberGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow Row = MemberGridView.Rows[e.RowIndex];
                    int row_id = Convert.ToInt32(Row.Cells[0].Value);
                    EditMember EditMember = new EditMember(row_id);
                    if (EditMember.ShowDialog() == DialogResult.Cancel)
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

        private void BtnAddMeth_Click(object sender, EventArgs e)
        {
            AddMember AddMember = new();
            if (AddMember.ShowDialog() == DialogResult.Cancel)
            {
                Loadtable();
            }

        }
    }
}
