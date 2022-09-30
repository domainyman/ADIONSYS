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
    public partial class SNSituation : Form
    {
        public TableLayoutPanel CompLayoutPanel = new TableLayoutPanel();
        public int Product_id;
        public int TableRowCount;
        public string Productname;
        public List<string> SN_list;
        public SNSituation(int tableRow, int name_id, List<string> snlist)
        {
            InitializeComponent();
            Product_id = name_id;
            TableRowCount = tableRow;
            SN_list = snlist;
            Productname = Product_name(Product_id);
            AddComponent();
            showsn(SN_list);


        }

        private void showsn(List<string> sn)
        {
            int count = 0;
            foreach (TextBox text in CompLayoutPanel.Controls.OfType<TextBox>())
            {
                text.Text = sn[count];
                count += 1;
            }

        }

        private string Product_name(int Product_id)
        {
            string result_product_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT name FROM productlibrary.product_sum WHERE  product_id='" + Product_id + "'");
            return result_product_name;
        }


        private void AddComponent()
        {
            //Item Table

            int tableRow = TableRowCount + 2;
            CompLayoutPanel.RowCount = tableRow;
            CompLayoutPanel.AutoScroll = true;
            CompLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            CompLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            for (int i = 0; i < tableRow; i++)
            {
                CompLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            }
            CompLayoutPanel.Dock = DockStyle.Fill;
            MainLayoutPanel.Controls.Add(CompLayoutPanel, 1, 3);
            //Item Title
            Label label = new Label();
            label.Text = Productname;
            label.Margin = new Padding(3, 3, 3, 3);
            label.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            label.Font = new Font("Open Sans", 9.75F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label.TextAlign = ContentAlignment.MiddleCenter;
            CompLayoutPanel.SetColumnSpan(label, 2);
            label.Dock = DockStyle.Fill;
            CompLayoutPanel.Controls.Add(label, 0, 0);
            //Item LABEL
            for (int j = 0; j < TableRowCount; j++)
            {
                Label itemlabel = new Label();
                itemlabel.Anchor = AnchorStyles.Left;
                itemlabel.TextAlign = ContentAlignment.MiddleLeft;
                itemlabel.Font = new Font("Open Sans", 9.75F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                itemlabel.AutoSize = true;
                itemlabel.Name = "LBSN";
                itemlabel.ForeColor = Color.White;
                itemlabel.Text = "Product SN :";
                itemlabel.Parent = CompLayoutPanel;
                itemlabel.Margin = new Padding(3, 3, 3, 3); ;
                itemlabel.Dock = DockStyle.Fill;
                CompLayoutPanel.Controls.Add(itemlabel, 0, j + 1);
            }
            //Item Textbox
            for (int j = 0; j < TableRowCount; j++)
            {
                TextBox itemText = new TextBox();
                itemText.Anchor = AnchorStyles.Left;
                itemText.BackColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                itemText.BorderStyle = BorderStyle.FixedSingle;
                itemText.Font = new Font("Open Sans", 9.75F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                itemText.ForeColor = Color.White;
                itemText.AutoSize = true;
                itemText.Name = "textsn" + j;
                itemText.PlaceholderText = "SN";
                itemText.Parent = CompLayoutPanel;
                itemText.Margin = new Padding(3, 6, 3, 3);
                itemText.Dock = DockStyle.Fill;
                CompLayoutPanel.Controls.Add(itemText, 1, j + 1);
                itemText.ReadOnly = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
