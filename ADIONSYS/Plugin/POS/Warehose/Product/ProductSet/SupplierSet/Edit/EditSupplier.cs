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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Windows.ApplicationModel.Contacts;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.SupplierSet.Edit
{
    public partial class EditSupplier: Form
    {
        List<int> result_supplier_id;
        public EditSupplier(string text)
        {
            InitializeComponent();
            Startup();
            string name = text;
            List<string> result_info = Selectinfomation(name);
            result_supplier_id = Selectid(name);
            bool state = SelectinfomationBool(name);
            ShowForm(result_info, state);
        }

        private List<int> Selectid(string name)
        {
            List<int> result_supplier_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT supplier_id FROM productsupplier.supplier WHERE supplier_name='" + name + "'");
            return result_supplier_id;
        }

        private List<string> Selectinfomation(string name_info) 
        {
            List<string> result_Supplier_info = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT supplier_name,code,br,address,corressaddress,off_tel," +
                "off_fax,off_email,bankname,bankacc,contact,con_title,con_tel,con_email,con_othertel,comment FROM productsupplier.supplier WHERE supplier_name='" + name_info + "'");
            return result_Supplier_info;
        }

        private bool SelectinfomationBool(string name_info)
        {
            bool result_Supplier_state = SQLConnect.Instance.PgSQL_SELECTDataBool("SELECT state FROM productsupplier.supplier WHERE supplier_name='" + name_info + "'");
            return result_Supplier_state;
        }

        private void Startup()
        {
            CMBoxList.Items.Add("Activated");
            CMBoxList.Items.Add("Inactivated");
        }
        private void ShowForm(List<string> name_info,bool state)
        {
            this.textname.Text = name_info[0];
            this.textCode.Text = name_info[1];
            this.textbr.Text = name_info[2];
            this.textAddress.Text = name_info[3];
            this.textCorrespondenceAddress.Text = name_info[4];
            this.textofficetel.Text = name_info[5];
            this.textfaxnumber.Text = name_info[6];
            this.textCompanyEmail.Text = name_info[7];
            this.textBankname.Text = name_info[8];
            this.textBankAcc.Text = name_info[9];
            this.textContactname.Text = name_info[10];
            this.textContacttitle.Text = name_info[11];
            this.textContacttel.Text = name_info[12];
            this.textContactemail.Text = name_info[13];
            this.textContactotherphone.Text = name_info[14];
            this.textComment.Text = name_info[15];
            if (state == true)
            {
                CMBoxList.SelectedItem = CMBoxList.Items[0];
            }
            else if (state == false)
            {
                CMBoxList.SelectedItem = CMBoxList.Items[1];
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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
            string data = ConvertType.GetTimeStamp();

            

            if (name != string.Empty && address != string.Empty && textofficetel.Text != string.Empty && contactname != string.Empty)
            {
                try
                {
                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT supplier_name FROM productsupplier.supplier except SELECT supplier_name FROM productsupplier.supplier WHERE supplier_id='" + result_supplier_id[0] + "'");
                        if (result.Contains(name))
                        {
                            this.LBMessageBox.Text = "This supplier has existed!";
                            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                        }
                        else
                        {
                            Task SQL = Task.Run(() => SQLConnect.Instance.PgSQL_Command("UPDATE productsupplier.supplier SET supplier_name = '" + name + "', code = '" + code + "', br = '" + br + "', address = '" + address + "', corressaddress = '" + corresaddress + "', off_tel = '" + officeTel + "', off_fax = '" + fax + "', off_email = '" + companyemail + "', bankname = '" + bankname + "', bankacc = '" + bankacc + "', contact = '" + contactname + "', con_title = '" + contacttitle + "', con_tel = '" + connacttel + "', con_email = '" + contactemail + "', con_othertel = '" + contactotherphone + "', comment = '" + comment + "', created_on = '" + data + "' WHERE supplier_id = '" + result_supplier_id[0] + "'"));
                            Task.WaitAll(SQL);
                            if (CMBoxList.SelectedItem == CMBoxList.Items[0])
                            {
                                bool state = true;
                                Task SQL_State = Task.Run(() => SQLConnect.Instance.PgSQL_Command("UPDATE productsupplier.supplier SET state = '" + state + "' WHERE supplier_id = '" + result_supplier_id[0] + "'"));
                                SQL_State.Wait();
                            }
                            else if (CMBoxList.SelectedItem == CMBoxList.Items[1])
                            {
                                bool state = false;
                                Task SQL_State = Task.Run(() => SQLConnect.Instance.PgSQL_Command("UPDATE productsupplier.supplier SET state = '" + state + "' WHERE supplier_id = '" + result_supplier_id[0] + "'"));
                                SQL_State.Wait();
                            }
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
    }
}
