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


        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = textname.Text;
            string gender = CMBgender.Text;
            DateTime birth = Convert.ToDateTime(textBirth.Text);
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

        }
    }
}
