using ADIONSYS.ConvertFunction;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADIONSYS.Plugin.POS.Member.Add
{
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
            Loading();
        }

        private void Loading()
        {
            Paymeth();
            PayTerms();
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
            if(PaymentMethodAddForm.ShowDialog() == DialogResult.Cancel)
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
            textcus_sc.Text = string.Empty;
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
            string scode = textcus_sc.Text;
            string gender = CMBgender.Text;
            if (gender == string.Empty)
            {
                gender = string.Empty;
            }
            string birth = maskedTextBoxbirth.Text;
            if(birth == "  /  /")
            {
                birth = string.Empty ;
            }
            string email = textEmail.Text;
            if (email == string.Empty )
            {
                email = string.Empty;
            }
            string title = texttitle.Text;
            if (title == string.Empty )
            {
                title = string.Empty;
            }
            string fax = textfaxnumber.Text;
            if (fax == string.Empty)
            {
                fax = string.Empty;
            }
            string tel = texttel.Text;
            if (tel == string.Empty)
            {
                tel = string.Empty;
            }
            string des = textDescription.Text;
            if (des == string.Empty)
            {
                des = string.Empty;
            }
            string company = textCompany.Text;
            if (company == string.Empty)
            {
                company = string.Empty;
            }
            string Contactname = textContactname.Text;
            if (Contactname == string.Empty)
            {
                Contactname = string.Empty;
            }
            string Address = textAddress.Text;
            if (Address == string.Empty)
            {
                Address = string.Empty;
            }
            string Contacttel = textContacttel.Text;
            if (Contacttel == string.Empty)
            {
                Contacttel = string.Empty;
            }
            string Ship_Company = textShipCompany.Text;
            if (Ship_Company == string.Empty)
            {
                Ship_Company = string.Empty;
            }
            string Ship_ContactPerson = textShip_ContactPerson.Text;
            if (Ship_ContactPerson == string.Empty)
            {
                Ship_ContactPerson = string.Empty;
            }
            string Ship_Address = textShip_Address.Text;
            if (Ship_Address == string.Empty)
            {
                Ship_Address = string.Empty;
            }
            string Ship_Tel = textShip_Tel.Text;
            if (Ship_Tel == string.Empty)
            {
                Ship_Tel = string.Empty;
            }
            string Ship_des = textShip_des.Text;
            if (Ship_des == string.Empty)
            {
                Ship_des = string.Empty;
            }
            string Pay_des = textPay_des.Text;
            if (Pay_des == string.Empty)
            {
                Pay_des = string.Empty;
            }
            string Pay_Meth = CMBPaymeth.Text;
            if (Pay_Meth == string.Empty)
            {
                CMBPaymeth.SelectedItem = CMBPaymeth.Items[0];
            }
            string Pay_Terms = CMBPayTerms.Text;
            if (Pay_Terms == string.Empty)
            {
                CMBPayTerms.SelectedItem = CMBPayTerms.Items[0];
            }
            bool state = true;
            string created_on = ConvertType.GetTimeStamp();
            string upload_data = ConvertType.GetTimeStamp();
            try
            {
                if (SQLConnect.Instance.ConnectState() == true && name != string.Empty && scode != string.Empty)
                {
                    SQLConnect.Instance.PgSQL_Command("INSERT INTO storagemember.member" +
                        "(customer_sc,member_number,member_gender,birth,email,title,fax_no,tel_no,mem_comment," +
                        "billing_company,billing_person,billing_address,billing_tel," +
                        "ship_company,ship_person,ship_address,ship_tel,ship_comment," +
                        "pay_comment,pay_terms,pay_method,state,upload_date,created_on) VALUES " +
                                    "('" + scode + "','" + name + "','" + gender + "','" + birth + "','" + email + "','" + title + "','" + fax + "','" + tel + "','" + des + 
                                    "','" + company + "','" + Contactname + "','" + Address + "','" + Contacttel +
                                    "','" + Ship_Company + "','" + Ship_ContactPerson + "','" + Ship_Address + "','" + Ship_Tel + "','" + Ship_des +
                                    "','" + Pay_des + "','" + Pay_Terms + "','" + Pay_Meth + "','" + state + "','" + upload_data + "','" + created_on + "')");
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

        private void textcus_sc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    List<string> PayTermsresult = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT member_number FROM storagemember.member");
                    if (PayTermsresult.Contains(textname.Text))
                    {
                        this.LBmessageBox.Text = "Customer Code already exists!";
                        this.LBmessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                        this.LBmessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                        btnCreate.Enabled = false;
                    }
                    else
                    {
                        btnCreate.Enabled = true;
                    }
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
