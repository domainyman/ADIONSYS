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
using Windows.ApplicationModel.Contacts;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.StorageSet.Edit
{
    public partial class EditStorage : Form
    {
        List<int> result_storage_id;
        public EditStorage(string text)
        {
            InitializeComponent();
            Startup();
            string name = text;
            result_storage_id = Selectid(name);
            List<string> result_info = Selectinfomation(name);
            bool state = SelectinfomationBool(name);
            ShowForm(result_info, state);
        }
        private void Startup()
        {
            CMBoxList.Items.Add("Activated");
            CMBoxList.Items.Add("Inactivated");
        }

        private List<int> Selectid(string text)
        {
            List<int> result_storage_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT storage_id FROM productstorage.storage WHERE storage_name='" + text + "'");
            return result_storage_id;
        }

        private List<string> Selectinfomation(string name_info)
        {
            List<string> result_storage_info = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT storage_name,code,address,off_tel," +
                "off_fax,off_email,comment FROM productstorage.storage WHERE storage_id='" + result_storage_id[0] + "'");
            return result_storage_info;
        }

        private bool SelectinfomationBool(string name_info)
        {
            bool result_storage_state = SQLConnect.Instance.PgSQL_SELECTDataBool("SELECT state FROM productstorage.storage WHERE storage_id='" + result_storage_id[0] + "'");
            return result_storage_state;
        }


        private void ShowForm(List<string> name_info, bool state)
        {
            this.textname.Text = name_info[0];
            this.textCode.Text = name_info[1];
            this.textAddress.Text = name_info[2];
            this.textofficetel.Text = name_info[3];
            this.textfaxnumber.Text = name_info[4];
            this.textCompanyEmail.Text = name_info[5];
            this.textComment.Text = name_info[6];
            if (state == true)
            {
                CMBoxList.SelectedItem = CMBoxList.Items[0];
            }
            else if (state == false)
            {
                CMBoxList.SelectedItem = CMBoxList.Items[1];
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void savelabel()
        {
            this.LBMessageBox.Text = "Saved!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            this.LBMessageBox.Image = Properties.Resources.check_mark_3_24;
        }

        private void vaildlabel()
        {
            this.LBMessageBox.Text = "Not a vaild infomation!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.LBMessageBox.Image = Properties.Resources.x_mark_24;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = textname.Text;
            string code = textCode.Text;
            string address = textAddress.Text;
            string officeTel = textofficetel.Text;
            string fax = textfaxnumber.Text;
            string companyemail = textCompanyEmail.Text;
            string comment = textComment.Text;
            string data = ConvertType.GetTimeStamp();

            if (name != string.Empty && address != string.Empty && textofficetel.Text != string.Empty )
            {
                try
                {
                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT storage_name FROM productstorage.storage except SELECT storage_name FROM productstorage.storage WHERE storage_id='" + result_storage_id[0] + "'");
                        if (result.Contains(name))
                        {
                            this.LBMessageBox.Text = "This supplier has existed!";
                            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                        }
                        else
                        {
                            Task SQL = Task.Run(() => SQLConnect.Instance.PgSQL_Command("UPDATE productstorage.storage SET storage_name = '" + name + 
                                "', code = '" + code + 
                                "', address = '" + address + 
                                "', off_tel = '" + officeTel + 
                                "', off_fax = '" + fax + 
                                "', off_email = '" + companyemail + 
                                "', comment = '" + comment + 
                                "', created_on = '" + data +
                                "' WHERE storage_id = '" + result_storage_id[0] + "'"));
                            Task.WaitAll(SQL);
                            if (CMBoxList.SelectedItem == CMBoxList.Items[0])
                            {
                                bool state = true;
                                SQLConnect.Instance.PgSQL_Command("UPDATE productstorage.storage SET state = '" + state + "' WHERE storage_id = '" + result_storage_id[0] + "'");
                                savelabel();
                            }
                            else if (CMBoxList.SelectedItem == CMBoxList.Items[1])
                            {
                                bool state = false;
                                SQLConnect.Instance.PgSQL_Command("UPDATE productstorage.storage SET state = '" + state + "' WHERE storage_id = '" + result_storage_id[0] + "'");
                                savelabel();
                            }
                            
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
                    //this.Close();
                }
            }
            else
            {
                MessageInfo MessageInfo = new MessageInfo("Not a valid Data!");
                MessageInfo.ShowDialog();

            }
        }
    }
}
