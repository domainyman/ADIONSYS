using ADIONSYS.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductInquire
{
    public partial class EditProductDetail : Form
    {
        string prod_id;
        string item_id;
        public EditProductDetail(string product_id,int row_id)
        {
            prod_id = product_id;
            item_id = row_id.ToString();
            InitializeComponent();
            Startup();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Startup()
        {
            this.CMState.Items.Add("Activated");
            this.CMState.Items.Add("Inactivated");
            List<string> result_info = Selectinfomation();
            List<decimal> result_cost_srp = Selectcost_srp();
            List<int> resultQty_Supplier_Storage_id = Selectqty_Supplier_Storageid();
            List<DateTime> result_DateTime = SelectDate();
            string SupplierName = Selectsupplier(resultQty_Supplier_Storage_id[1]);
            string StorageName = SelectStorage(resultQty_Supplier_Storage_id[2]);
            string StatusName = SelectStatus(resultQty_Supplier_Storage_id[3]);
            string ProductName = Selectsupplier();
            bool state = SelectitemBool();

            ShowForm(ProductName,result_info, result_cost_srp, resultQty_Supplier_Storage_id, SupplierName, StorageName, state, result_DateTime, StatusName);

        }
        private void ShowForm(string ProductName,List<string> name_info, List<decimal> result_cost_srp, List<int> resultQty_Supplier_Storage_id,
            string SupplierName,string StorageName,bool state, List<DateTime> result_DateTime,string StatusName)
        {
            this.textname.Text = ProductName;
            this.textSN.Text = name_info[0];
            this.textComment.Text = name_info[1];
            this.textReservationOrder.Text = name_info[2];
            this.textPurcheseorder.Text = name_info[3];
            this.textSellorder.Text = name_info[4];
            this.textCost.Text = result_cost_srp[0].ToString("N2");
            this.textquantity.Text = resultQty_Supplier_Storage_id[0].ToString();
            this.textSupplier.Text = SupplierName;
            this.textStorage.Text = StorageName;
            this.LBSystemCode.Text = item_id;
            this.textPurcheseDate.Text = result_DateTime[1].ToString("dd-MM-yyyy");
            this.textCreateDate.Text = result_DateTime[3].ToString();
            this.LBStatus_transf.Text = StatusName;

            if (result_DateTime[0].ToString() == "1111-11-11 11:11:11")
            {
                this.textReservationDate.Text = "";
            }

            if (result_DateTime[2].ToString() == "1111-11-11 11:11:11")
            {
                this.textSellDate.Text = "";
            }
            if (state == true)
            {
                this.CMState.SelectedItem = CMState.Items[0];
                this.CMState.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            }
            else if (state == false)
            {
                this.CMState.SelectedItem = CMState.Items[1];
                this.CMState.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            }

        }

        private string Selectsupplier()
        {
            string result_Product_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT name FROM productlibrary.product_sum WHERE product_id= '" + prod_id + "'");
            return result_Product_name;
        }

        private bool SelectitemBool()
        {
            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id= '" + prod_id + "'");
            string droptablename = "productlibrary." + "\"" + result_hash_name + "\"";
            string cmd = "SELECT state FROM "+ droptablename + " WHERE product_id= " + item_id + "";
            bool result_item_state = SQLConnect.Instance.PgSQL_SELECTDataBool(cmd);
            return result_item_state;
        }

        private List<string> Selectinfomation()
        {
            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id='" + prod_id + "'");
            string droptablename = "productlibrary." + "\"" + result_hash_name + "\"";
            string cmd = "SELECT sn,COALESCE(comment,'N/A') as comment,COALESCE(booking_no,'N/A') as comment,purchese_no,COALESCE(selling_no,'N/A') as selling_no FROM " + droptablename + " WHERE product_id= '" + item_id + "'";
            List<string> result_item_info = SQLConnect.Instance.PgSQL_SELECTDataString(cmd);
            return result_item_info;
        }

        private List<decimal> Selectcost_srp()
        {
            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id='" + prod_id + "'");
            string droptablename = "productlibrary." + "\"" + result_hash_name + "\"";
            string cmd = "SELECT cost FROM " + droptablename + " WHERE product_id= '" + item_id + "'";
            List<decimal> result_Cost_srp = SQLConnect.Instance.PgSQL_SELECTDataDecimal(cmd);
            return result_Cost_srp;
        }

        private List<int> Selectqty_Supplier_Storageid()
        {
            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id='" + prod_id + "'");
            string droptablename = "productlibrary." + "\"" + result_hash_name + "\"";
            string cmd = "SELECT qty,supplier_id,storage_id,status FROM " + droptablename + " WHERE product_id= '" + item_id + "'";
            List<int> resultQty_Supplier_Storage_id = SQLConnect.Instance.PgSQL_SELECTDataint(cmd);
            return resultQty_Supplier_Storage_id;
        }
        private string Selectsupplier(int name_info)
        {
            string result_supplier_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT supplier_name FROM productsupplier.supplier WHERE supplier_id='" + name_info + "'");
            return result_supplier_name;
        }

        private string SelectStorage(int name_info)
        {
            string result_Storage_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT storage_name FROM productstorage.storage WHERE storage_id='" + name_info + "'");
            return result_Storage_name;
        }

        private string SelectStatus(int name_info)
        {
            string result_Storage_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT status_name FROM productlibrary.status WHERE status_id='" + name_info + "'");
            return result_Storage_name.ToUpper();
        }

        private List<DateTime> SelectDate()
        {
            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id='" + prod_id + "'");
            string droptablename = "productlibrary." + "\"" + result_hash_name + "\"";
            string cmd = "SELECT booking_day,purchese_day,selling_day,created_on FROM " + droptablename + " WHERE product_id= '" + item_id + "'";
            List<DateTime> result_DateTime = SQLConnect.Instance.PgSQL_SELECTDataDateTime(cmd);
            return result_DateTime;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    string comment = this.textComment.Text;
                    string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id='" + prod_id + "'");
                    string droptablename = "productlibrary." + "\"" + result_hash_name + "\"";
                    Task SQLComment = Task.Run(() => SQLConnect.Instance.PgSQL_Command("UPDATE " + droptablename + " SET comment = '" + comment + "' WHERE product_id = '" + item_id + "'"));
                    SQLComment.Wait();
                    if (this.CMState.SelectedItem == this.CMState.Items[0])
                    {
                        bool state = true;
                        Task SQL_State = Task.Run(() => SQLConnect.Instance.PgSQL_Command("UPDATE " + droptablename + " SET state = '" + state + "' WHERE product_id = '" + item_id + "'"));
                        SQL_State.Wait();
                        savelabel();
                    }
                    else if (this.CMState.SelectedItem == this.CMState.Items[1])
                    {
                        bool state = false;
                        Task SQL_State = Task.Run(() => SQLConnect.Instance.PgSQL_Command("UPDATE " + droptablename + " SET state = '" + state + "' WHERE product_id = '" + item_id + "'"));
                        SQL_State.Wait();
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
