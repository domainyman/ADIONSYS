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

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.CategorySet.Create
{
    public partial class CreateCategory : Form
    {
        public CreateCategory()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (textCategory.Text != string.Empty && textCategory.Text !="OTHER")
            {
                try
                {
                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT category_name FROM productcategory.category");
                        string name = textCategory.Text;
                        if (result.Contains(name))
                        {
                            this.LBMessageBox.Text = "This category has existed!";
                            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                        }
                        else
                        {
                            SQLConnect.Instance.PgSQL_Command("INSERT INTO productcategory.category(category_name) VALUES ('" + name + "')");
                            this.LBMessageBox.Text = "Saved!";
                            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
                        }
                    }
                    else
                    {
                        this.LBMessageBox.Text = "Not a vaild infomation!";
                        this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                        this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                    }
                }
                catch (Exception ex)
                {
                    MessageInfo MessageInfo = new MessageInfo(ex.Message);
                    MessageInfo.ShowDialog();
                }
            }
            else
            {
                this.LBMessageBox.Text = "Not a vaild infomation!";
                this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;

            }
        }
    }
}
