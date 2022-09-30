using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ADIONSYS.Plugin.POS.Warehose.Management.Purchese
{
    public partial class ProductSNInsert : Form
    {
        public int tableRowCount;
        public int product_ID;
        public string productName;
        public List<string> list;
        public List<string> sn_list;
        public TableLayoutPanel CompLayoutPanel = new TableLayoutPanel();
        public ProductSNInsert(int tableRow,int name_id, List<string> snlist)
        {
            sn_list = snlist;
            tableRowCount = tableRow;
            product_ID = name_id;
            productName = Product_name();
            InitializeComponent();
            AddComponent();
            showsn(sn_list);
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

        private string Product_name()
        {
            string result_product_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT name FROM productlibrary.product_sum WHERE  product_id='" + product_ID + "'");
            return result_product_name;
        }


        private void AddComponent()
        {
            //Item Table
            
            int tableRow = tableRowCount + 2;
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
            label.Text = productName;
            label.Margin = new Padding(3, 3, 3, 3);
            label.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            label.Font = new Font("Open Sans", 9.75F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label.TextAlign = ContentAlignment.MiddleCenter;
            CompLayoutPanel.SetColumnSpan(label, 2);
            label.Dock = DockStyle.Fill;
            CompLayoutPanel.Controls.Add(label, 0, 0);
            //Item LABEL
            for (int j = 0; j < tableRowCount; j++)
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
                CompLayoutPanel.Controls.Add(itemlabel, 0, j+1);
            }
            //Item Textbox
            for (int j = 0; j < tableRowCount; j++)
            {
                TextBox itemText = new TextBox();
                itemText.Anchor = AnchorStyles.Left;
                itemText.BackColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                itemText.BorderStyle = BorderStyle.FixedSingle;
                itemText.Font = new Font("Open Sans", 9.75F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                itemText.ForeColor = Color.White;
                itemText.AutoSize = true;
                itemText.Name = "textsn"+ j;
                itemText.PlaceholderText = "SN";
                itemText.Parent = CompLayoutPanel;
                itemText.Margin = new Padding(3, 6, 3, 3);
                itemText.Dock = DockStyle.Fill;
                CompLayoutPanel.Controls.Add(itemText, 1 , j + 1);
            }
        }
       

        private bool CheckTextEmpty()
        {
            List<string> list = new List<string>();
            foreach (TextBox text in CompLayoutPanel.Controls.OfType<TextBox>())
            {
                string textStr = text.Text;
                list.Add(textStr);
            }
            if(list.Contains(string.Empty))
            {
                return false;
            }
            return true;    
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            BatchImport BatchImport = new BatchImport(tableRowCount);
            if(BatchImport.ShowDialog() == DialogResult.OK)
            {
                list = BatchImport.List;
                if (list != null && list.Any())
                {
                    int listCount = list.Count;
                    int count = 0;
                    Console.WriteLine(listCount);
                    foreach (TextBox text in CompLayoutPanel.Controls.OfType<TextBox>())
                    {
                        if (count == listCount)
                        {
                            break;
                        }
                        else
                        {
                            text.Text = list[count];
                            count += 1;
                        }
                    }
                }
                else
                {
                    this.LBMassageBox.Text = "Not a vaild infomation!";
                    this.LBMassageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                    this.LBMassageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                }
            }
        }
        public List<string> listsn { set; get; }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool ChexkEmpty = CheckTextEmpty();
            if (ChexkEmpty == true)
            {
                List<string> list_sn = new List<string>();
                foreach (TextBox text in CompLayoutPanel.Controls.OfType<TextBox>())
                {
                    string sn = text.Text;
                    list_sn.Add(sn);
                }
                list_sn.RemoveAll(s => s == string.Empty);
                list_sn.RemoveAll(s => s == null);
                if (list_sn.Count == tableRowCount )
                {
                    listsn = list_sn;
                    this.LBMassageBox.Text = "Save Changed!";
                    this.LBMassageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                    this.LBMassageBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
                }
                else
                {
                    this.LBMassageBox.Text = "Lost Serial Number!";
                    this.LBMassageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                    this.LBMassageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                }
            }
            else
            {
                this.LBMassageBox.Text = "Not a vaild infomation!";
                this.LBMassageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                this.LBMassageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
            }
        }

    }
}
