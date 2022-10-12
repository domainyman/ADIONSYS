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
    public partial class ShippingForm : Form
    {
        public int Clientid { set; get; }
        public List<string> Shipping = new List<string>();
    public ShippingForm(int Client_id)
        {

            InitializeComponent();
            Clientid = Client_id;
            ShowForm();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowForm()
        {
            List<string> result_member = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT ship_company,ship_person,ship_address,ship_tel,ship_comment FROM storagemember.member WHERE member_id = '" + Clientid + "'");
            textShipCompany.Text = result_member[0];
            textPerson.Text = result_member[1];
            textAddress.Text = result_member[2];
            textTel.Text = result_member[3];
            textComment.Text = result_member[4];
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (addlist() == true)
            {
                this.LBmessageBox.Text = "Saved!";
                this.LBmessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                this.LBmessageBox.Image = Properties.Resources.check_mark_3_24;
            }
            else
            {
                this.LBmessageBox.Text = "Not a vaild infomation!";
                this.LBmessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                this.LBmessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
            }

        }

        private bool addlist()
        {
            Shipping.Add(textShipCompany.Text);
            Shipping.Add(textPerson.Text);
            Shipping.Add(textAddress.Text);
            Shipping.Add(textTel.Text);
            Shipping.Add(textComment.Text);
            return true;
        }
    }
}
