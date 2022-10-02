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

namespace ADIONSYS.Plugin.POS.Member.Edit
{
    public partial class EditMember : Form
    {
        public int MemberID;
        public EditMember(int member_id)
        {
            MemberID=member_id;
            InitializeComponent();
            ShowData();


        }

        private void Loading()
        {
            Paymeth();
            PayTerms();
        }

        private void ShowData()
        {
            List<string> Show = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT member_number,member_gender,birth,email FROM storagemember.member WHERE member_id = '" + MemberID + "'");
            LBtestMemberID.Text = MemberID.ToString();
            textname.Text = Show[0];
            CMBgender.Text = Show[1];
            //maskedTextBoxbirth.Text = Show[2];
            textEmail.Text = Show[3];
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


        private void btnCreate_Click(object sender, EventArgs e)
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
            string created_on = ConvertType.GetTimeStamp();
            string upload_data = ConvertType.GetTimeStamp();
            try
            {
                if (SQLConnect.Instance.ConnectState() == true && name != string.Empty)
                {
                    SQLConnect.Instance.PgSQL_Command("INSERT INTO storagemember.member" +
                        "(member_number,member_gender,birth,email,title,fax_no,tel_no,mem_comment," +
                        "billing_company,billing_person,billing_address,billing_tel," +
                        "ship_company,ship_person,ship_address,ship_tel,ship_comment," +
                        "pay_comment,pay_terms,pay_method,state,upload_date,created_on) VALUES " +
                                    "('" + name + "','" + gender + "','" + birth + "','" + email + "','" + title + "','" + fax + "','" + tel + "','" + des +
                                    "','" + company + "','" + Contactname + "','" + Address + "','" + Contacttel +
                                    "','" + Ship_Company + "','" + Ship_ContactPerson + "','" + Ship_Address + "','" + Ship_Tel + "','" + Ship_des +
                                    "','" + Pay_des + "','" + Pay_Meth + "','" + Pay_Terms + "','" + state + "','" + created_on + "','" + upload_data + "')");
                    this.LBmessageBox.Text = "Saved!";
                    this.LBmessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                    this.LBmessageBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
                    clear();
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
    }
}
