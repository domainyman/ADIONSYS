using ADIONSYS.ConvertFunction;
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
using System.Xml.Linq;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.StorageSet.Create
{
    public partial class CreateStorage : Form
    {
        public CreateStorage()
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
            string code = textCode.Text;
            string address = textAddress.Text;
            string officeTel = textofficetel.Text;
            string fax = textfaxnumber.Text;
            string companyemail = textCompanyEmail.Text;
            string comment = textComment.Text;
            bool state = true;
            string data = ConvertType.GetTimeStamp();
            string hash = ConvertType.Hashsingle();
            if (name != string.Empty && address != string.Empty && officeTel != string.Empty && textCode.Text != string.Empty && name!= "Summary")
            {
                try
                {

                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT storage_name FROM productstorage.storage");
                        if (result.Contains(name))
                        {
                            this.LBMessageBox.Text = "This storage has existed!";
                            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                        }
                        else
                        {
                            SQLConnect.Instance.PgSQL_Command("INSERT INTO productstorage.storage(storage_name," +
                            "address," +
                            "code," +
                            "off_tel," +
                            "off_fax," +
                            "off_email," +
                            "comment," +
                            "state," +
                            "hash," +
                            "created_on) VALUES('" + name +  "','" + address + "','" + code + "','" + officeTel + "','" + fax + "','" + companyemail + "'," +
                            "'" + comment + "','" + state + "','" + hash.ToLower() + "','" + data + "')");
                            int sid = supplier_id(code);
                            if (DataBaseTable(sid) == true)
                            {
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
                    MessageInfo MessageInfo = new(ex.Message);
                    MessageInfo.ShowDialog();
                }
                finally
                {
                    ClearText();
                }
            }
            else
            {
                MessageInfo MessageInfo = new("Not a valid infomation!");
                MessageInfo.ShowDialog();

            }
        }

        private int supplier_id(string name)
        {
            List<int> result_storage_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT storage_id FROM productstorage.storage WHERE code='" + name + "'");
            int sid = result_storage_id[0];
            return sid;
        }

        private bool DataBaseTable(int sid)
        {
            int storage_id = sid;
            bool done = false;
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productstorage.storage WHERE storage_id='" + storage_id + "'");
                    string schemaname = result_hash_name;
                    string tablename = "product_code";
                    string droptablename = "\""+ schemaname + "\"" + "." + "\"" + tablename + "\"";
                    string tablenameSUM = "product_sum";
                    string droptablesumname = "\"" + schemaname + "\"" + "." + "\"" + tablenameSUM + "\"";
                    SQLConnect.Instance.PgSQL_Command("CREATE SCHEMA IF NOT EXISTS "+ schemaname);
                    SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS "+ droptablename + " (" +
                        "product_id bigserial," +
                        "sn VARCHAR ( 50 ) NOT NULL," +
                        "cost decimal NOT NULL," +
                        "qty INT NOT NULL," +
                        "supplier_id INT NOT NULL," +
                        "storage_id INT NOT NULL," +
                        "inv_id INT NOT NULL," +
                        "state boolean NOT NULL," +
                        "comment VARCHAR ( 50 )," +
                        "booking_no VARCHAR ( 50 )," +
                        "booking_day TIMESTAMP ," +
                        "purchese_no VARCHAR ( 50 ) NOT NULL," +
                        "purchese_day DATE NOT NULL," +
                        "selling_no VARCHAR ( 50 )," +
                        "selling_day TIMESTAMP," +
                        "created_on TIMESTAMP NOT NULL," +
                        "PRIMARY KEY(product_id)," +
                        "FOREIGN KEY (supplier_id) REFERENCES productsupplier.supplier (supplier_id)," +
                        "FOREIGN KEY (inv_id) REFERENCES tableinvoice.invoicenum (invoice_id)," +
                        "FOREIGN KEY (storage_id) REFERENCES productstorage.storage (storage_id))");
                    SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS " + droptablesumname + " (" +
                        "product_id bigserial PRIMARY KEY," +
                        "name VARCHAR ( 50 )UNIQUE NOT NULL," +
                        "model VARCHAR ( 50 )UNIQUE NOT NULL," +
                        "ean_0 VARCHAR ( 50 ) ," +
                        "ean_1 VARCHAR ( 50 ) ," +
                        "ean_2 VARCHAR ( 50 ) ," +
                        "cost decimal," +
                        "srp decimal," +
                        "qty INT," +
                        "supplier_id INT," +
                        "state boolean NOT NULL," +
                        "comment VARCHAR ( 50 ) ," +
                        "hash VARCHAR ( 50 ) NOT NULL," +
                        "created_on TIMESTAMP NOT NULL)");
                    //string databasename = "\"productlibrary\"" + "." + "\"" + tablenameSUM + "\"";
                    //SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS " + droptablesumname + " AS TABLE " + databasename + " WITH NO DATA");


                    //SQLConnect.Instance.PgSQL_Command("CREATE TRIGGER uploadstorageproductsum AFTER INSERT ON COMPANY FOR EACH STATEMENT EXECUTE PROCEDURE auditlogfunc()");
                    done = true;
                }
                return done;
            }
            catch (Exception ex)
            {
                MessageInfo MessageInfo = new(ex.Message);
                MessageInfo.ShowDialog();
                return done;
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
            textCode.Text = string.Empty;
            textAddress.Text = string.Empty;
            textofficetel.Text = string.Empty;
            textfaxnumber.Text = string.Empty;
            textCompanyEmail.Text = string.Empty;
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
    }
}
