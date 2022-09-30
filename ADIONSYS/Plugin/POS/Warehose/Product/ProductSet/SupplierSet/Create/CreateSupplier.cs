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
using System.Xml.Linq;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.SupplierSet.Create
{
    public partial class CreateSupplier : Form
    {
        public CreateSupplier()
        {
            InitializeComponent();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = textname.Text;
            string br = textbr.Text;
            string code = textCode.Text;
            string address = textAddress.Text;
            string corresaddress = textCorrespondenceAddress.Text;
            string officeTel = textofficetel.Text;
            string fax = textfaxnumber.Text;
            string companyemail = textCompanyEmail.Text;
            string bankname = textBankname.Text;
            string bankacc = textBankAcc.Text;
            string contactname = textContactname.Text;
            string connacttel = textContacttel.Text;
            string contactemail = textContactemail.Text;
            string contacttitle = textContacttitle.Text;
            string contactotherphone = textContactotherphone.Text;
            string comment = textComment.Text;
            bool state = true;
            string data = ConvertType.GetTimeStamp();
            if ( name != string.Empty && address != string.Empty && officeTel != string.Empty && contactname != string.Empty && code != string.Empty && name != "OTHER")
            {
                try
                {

                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT supplier_name FROM productsupplier.supplier");
                        if (result.Contains(name))
                        {
                            this.LBMessageBox.Text = "This supplier has existed!";
                            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                        }
                        else
                        {
                            Task SQL = Task.Run(() => SQLConnect.Instance.PgSQL_Command("INSERT INTO productsupplier.supplier(supplier_name," +
                            "code," +
                            "br," +
                            "address," +
                            "corressaddress," +
                            "off_tel," +
                            "off_fax," +
                            "off_email," +
                            "bankname," +
                            "bankacc," +
                            "contact," +
                            "con_title," +
                            "con_tel," +
                            "con_email," +
                            "con_othertel," +
                            "comment," +
                            "state," +
                            "created_on) VALUES('" + name + "','" + code + "','" + br + "','" + address + "','" + corresaddress + "','" + officeTel + "','" + fax + "','" + companyemail + "'," +
                            "'" + bankname + "','" + bankacc + "','" + contactname + "','" + contacttitle + "','" + connacttel + "','" + contactemail + "','" + contactotherphone + "'," +
                            "'" + comment + "','" + state + "','" + data + "')"));
                            Task.WaitAll(SQL);
                            savelabel();
                        }
                    }
                    else
                    {
                        vaildlabel();
                    }
                }
                catch (Exception ex)
                {
                    MessageInfo MessageInfo = new MessageInfo(ex.Message);
                    MessageInfo.ShowDialog();
                }
                finally
                {
                    ClearText();
                }
            }
            else
            {
                MessageInfo MessageInfo = new MessageInfo("Not a valid infomation!");
                MessageInfo.ShowDialog();

            }
        }

        private void savelabel()
        {
            this.LBMessageBox.Text = "Saved!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
        }

        private void vaildlabel()
        {
            this.LBMessageBox.Text = "Not a vaild infomation!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
        }

        private void ClearText()
        {
            textname.Text = string.Empty;
            textbr.Text = string.Empty;
            textCode.Text = string.Empty;
            textAddress.Text = string.Empty;
            textCorrespondenceAddress.Text = string.Empty;
            textofficetel.Text = string.Empty;
            textfaxnumber.Text = string.Empty;
            textCompanyEmail.Text = string.Empty;
            textBankname.Text = string.Empty;
            textBankAcc.Text = string.Empty;
            textContactname.Text = string.Empty;
            textContacttel.Text = string.Empty;
            textContactemail.Text = string.Empty;
            textContacttitle.Text = string.Empty;
            textContactotherphone.Text = string.Empty;
            textComment.Text = string.Empty;
        }

        private void textofficetel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textfaxnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textContacttel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textContactotherphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
