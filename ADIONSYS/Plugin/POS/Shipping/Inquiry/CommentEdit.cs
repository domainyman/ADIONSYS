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

namespace ADIONSYS.Plugin.POS.Shipping.Inquiry
{
    public partial class CommentEdit : Form
    {
        public int shipping_id;
        public CommentEdit(int shippinginv_id)
        {
            InitializeComponent();
            shipping_id = shippinginv_id;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {

                    string Description = textDescription.Text;
                    SQLConnect.Instance.PgSQL_Command("UPDATE invoiceshipping.shippinginv SET comment='" + Description + "' WHERE shippinginv_id='" + shipping_id + "'");
                    this.LBMessageBox.Text = "Saved!";
                    this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                    this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;

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

    }
}
