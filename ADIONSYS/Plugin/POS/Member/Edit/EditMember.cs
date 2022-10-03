using ADIONSYS.ConvertFunction;
using ADIONSYS.Plugin.POS.Member.Add;
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
using System.Xml.Linq;

namespace ADIONSYS.Plugin.POS.Member.Edit
{
    public partial class EditMember : Form
    {
        public int MemberID;
        public EditMember(int member_id)
        {
            MemberID=member_id;
            InitializeComponent();
            Loading();
            ShowData();


        }

        private void Loading()
        {
            CMBState.Items.Add("Activated");
            CMBState.Items.Add("Inactivated");
            Paymeth();
            PayTerms();
        }

        private void ShowData()
        {
            List<string> Show = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT member_number,member_gender,birth,email,title,fax_no,tel_no,mem_comment," +
                "billing_company,billing_person,billing_address,billing_tel," +
                "ship_company,ship_person,ship_address,ship_tel,ship_comment," +
                "pay_comment,pay_terms,pay_method FROM storagemember.member WHERE member_id = '" + MemberID + "'");
            bool result_state = SQLConnect.Instance.PgSQL_SELECTDataBool("SELECT state FROM storagemember.member WHERE member_id='" + MemberID + "'");
            List<DateTime> result_DateTime = SQLConnect.Instance.PgSQL_SELECTDataDateTime("SELECT upload_date,created_on FROM storagemember.member WHERE member_id='" + MemberID + "'");
            LBtestMemberID.Text = MemberID.ToString();
            textname.Text = Show[0];
            CMBgender.SelectedItem = Show[1];
            maskedTextBoxbirth.Text = Show[2];
            textEmail.Text = Show[3];
            texttitle.Text = Show[4];
            textfaxnumber.Text = Show[5];
            texttel.Text = Show[6];
            textDescription.Text = Show[7];
            textCompany.Text = Show[8];
            textContactname.Text = Show[9];
            textAddress.Text = Show[10];
            textContacttel.Text = Show[11];
            textShipCompany.Text = Show[12];
            textShip_ContactPerson.Text = Show[13];
            textShip_Address.Text = Show[14];
            textShip_Tel.Text = Show[15];
            textShip_des.Text = Show[16];
            textPay_des.Text = Show[17];
            CMBPayTerms.SelectedItem = Show[18];
            CMBPaymeth.SelectedItem = Show[19];
            if (result_state == true)
            {
                CMBState.SelectedItem = CMBState.Items[0];
            }
            else
            {
                CMBState.SelectedItem = CMBState.Items[1];
            }
            textcreate_date.Text = result_DateTime[1].ToString();
            textupload.Text = result_DateTime[0].ToString();


        }
        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Paymeth()
        {
            List<string> Paymethresult = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT paymethod_name FROM storagemember.paymethod");
            CMBPaymeth.DataSource = Paymethresult;
            CMBPaymeth.SelectedIndex = -1;
        }

        private void PayTerms()
        {
            List<string> PayTermsresult = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT payterms_name FROM storagemember.payterms");
            CMBPayTerms.DataSource = PayTermsresult;
            CMBPayTerms.SelectedIndex = -1;
        }



        private void BtnAddMeth_Click(object sender, EventArgs e)
        {
            PaymentMethodAddForm PaymentMethodAddForm = new();
            if (PaymentMethodAddForm.ShowDialog() == DialogResult.Cancel)
            {
                Paymeth();
            }
        }

        private void BtnAddTerms_Click(object sender, EventArgs e)
        {
            PaymentTermsAddForm PaymentTermsAddForm = new();
            if (PaymentTermsAddForm.ShowDialog() == DialogResult.Cancel)
            {
                PayTerms();
            }
        }

        private void clear()
        {
            textname.Text = string.Empty;
            CMBgender.Text = string.Empty;
            maskedTextBoxbirth.Text = string.Empty;
            textEmail.Text = string.Empty;
            texttitle.Text = string.Empty;
            textfaxnumber.Text = string.Empty;
            texttel.Text = string.Empty;
            textDescription.Text = string.Empty;
            textCompany.Text = string.Empty;
            textContactname.Text = string.Empty;
            textAddress.Text = string.Empty;
            textContacttel.Text = string.Empty;
            textShipCompany.Text = string.Empty;
            textShip_ContactPerson.Text = string.Empty;
            textShip_Address.Text = string.Empty;
            textShip_Tel.Text = string.Empty;
            textShip_des.Text = string.Empty;
            textPay_des.Text = string.Empty;
            CMBPaymeth.Text = string.Empty;
            CMBPayTerms.Text = string.Empty;
            CMBgender.SelectedIndex = -1;
            Loading();
        }

        private void BtnAddMeth_Click_1(object sender, EventArgs e)
        {
            PaymentMethodAddForm PaymentMethodAddForm = new();
            if (PaymentMethodAddForm.ShowDialog() == DialogResult.Cancel)
            {
                Paymeth();
            }
        }

        private void BtnAddTerms_Click_1(object sender, EventArgs e)
        {
            PaymentTermsAddForm PaymentTermsAddForm = new();
            if (PaymentTermsAddForm.ShowDialog() == DialogResult.Cancel)
            {
                PayTerms();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = textname.Text;
            string gender = CMBgender.Text;
            string birth = maskedTextBoxbirth.Text;
            if (birth == "  /  /")
            {
                birth = string.Empty;
            }
            string email = textEmail.Text;
            string title = texttitle.Text;
            string fax = textfaxnumber.Text;
            string tel = texttel.Text;
            string des = textDescription.Text;
            string company = textCompany.Text;
            string Contactname = textContactname.Text;
            string Address = textAddress.Text;
            string Contacttel = textContacttel.Text;
            string Ship_Company = textShipCompany.Text;
            string Ship_ContactPerson = textShip_ContactPerson.Text;
            string Ship_Address = textShip_Address.Text;
            string Ship_Tel = textShip_Tel.Text;
            string Ship_des = textShip_des.Text;
            string Pay_des = textPay_des.Text;
            string Pay_Meth = CMBPaymeth.Text;
            string Pay_Terms = CMBPayTerms.Text;
            bool state = true;
            if (CMBState.SelectedItem == CMBState.Items[0])
            {
                state = true;
            }
            else if (CMBState.SelectedItem == CMBState.Items[1])
            {
                state = false;
            }
            string upload_data = ConvertType.GetTimeStamp();
            try
            {
                if (SQLConnect.Instance.ConnectState() == true && name != string.Empty)
                {
                    SQLConnect.Instance.PgSQL_Command("UPDATE storagemember.member SET member_number = '" + name + "', member_gender = '" + gender + "',birth = '" + birth + "',email='"+email + "',title='"+ title + "',fax_no='"+ fax + "',tel_no='" + tel + "',mem_comment='"+ des+ "'," +
                        "billing_company='"+ company+ "',billing_person='"+ Contactname + "',billing_address='"+ Address+ "',billing_tel='"+ Contacttel+ "'," +
                        "ship_company='"+ Ship_Company+ "',ship_person='" + Ship_ContactPerson + "',ship_address='"+ Ship_Address+ "',ship_tel='"+ Ship_Tel + "',ship_comment='"+ Ship_des + "'," +
                        "pay_comment='"+ Pay_des + "',pay_terms='"+ Pay_Terms + "',pay_method='"+ Pay_Meth + "',state='"+ state + "',upload_date= '"+upload_data+ "' WHERE member_id = '" + MemberID + "'");
                    this.LBmessageBox.Text = "Saved!";
                    this.LBmessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                    this.LBmessageBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
                    
                }
                else
                {
                    this.LBmessageBox.Text = "Not a vaild infomation!";
                    this.LBmessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                    this.LBmessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageInfo = new MessageInfo(ex.Message);
                MessageInfo.ShowDialog();
            }

            
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            bool state = false;
            MessageContinue MessageContinue = new MessageContinue("Are You Sure? " + " " + " You won't be able to revert this !");
            if (MessageContinue.ShowDialog() == DialogResult.Continue)
            {
                SQLConnect.Instance.PgSQL_Command("DELETE FROM storagemember.member WHERE member_id='" + MemberID + "'");
                this.Close();
            }

        }
    }
}
