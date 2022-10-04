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
    public partial class ClientInfo : Form
    {
        public int MemberID;
        public ClientInfo(int member_id)
        {
            InitializeComponent();
            MemberID = member_id;
            ShowData();
        }

        private void ShowData()
        {
            List<string> Show = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT member_number,member_gender,birth,email,title,fax_no,tel_no,mem_comment," +
                "billing_company,billing_person,billing_address,billing_tel," +
                "ship_company,ship_person,ship_address,ship_tel,ship_comment," +
                "pay_comment,pay_terms,pay_method,customer_sc FROM storagemember.member WHERE member_id = '" + MemberID + "'");
            bool result_state = SQLConnect.Instance.PgSQL_SELECTDataBool("SELECT state FROM storagemember.member WHERE member_id='" + MemberID + "'");
            List<DateTime> result_DateTime = SQLConnect.Instance.PgSQL_SELECTDataDateTime("SELECT upload_date,created_on FROM storagemember.member WHERE member_id='" + MemberID + "'");
            LBtestMemberID.Text = MemberID.ToString();
            textname.Text = Show[0];
            CMBgender.Text = Show[1];
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
            CMBPayTerms.Text = Show[18];
            CMBPaymeth.Text = Show[19];
            textcus_sc.Text = Show[20];
            if (result_state == true)
            {
                CMBState.Text = "Activated";
            }
            else
            {
                CMBState.Text = "Inactivated";
            }
            textcreate_date.Text = result_DateTime[1].ToString();
            textupload.Text = result_DateTime[0].ToString();


        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }


}
