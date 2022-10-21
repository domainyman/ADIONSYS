using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ADIONSYS.ConvertFunction;
using ADIONSYS.Plugin.Setting.Database;
using ADIONSYS.Tool;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ADIONSYS.Plugin.Setting
{
    public partial class SettingDataBase : Form
    {
        public SettingDataBase()
        {
            InitializeComponent();
            CheckBaseState();
        }

        public void CheckBaseState()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                this.LBConnState.Text = "Connected";
                this.LBConnState.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                this.LBConnState.Image = global::ADIONSYS.Properties.Resources.accept_database_24;
            }
            else
            {
                this.LBConnState.Text = "Disconnect";
                this.LBConnState.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                this.LBConnState.Image = global::ADIONSYS.Properties.Resources.delete_database_24;
            }
            TextDataBasePath.Text = ApplicationSetting.Default.DataBaseAddress;
            TBDataBaseName.Text = ApplicationSetting.Default.Database;
        }

        private void BtnBuildDatabase_Click(object sender, EventArgs e)
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                DataBaseTable();
                PlugFolder();
                MessageInfo MessageInfo = new MessageInfo("Buil Data Table Finish");
                MessageInfo.ShowDialog();
            }
            else
            {
                MessageInfo MessageInfo = new MessageInfo("Warning : System is having trouble connecting to the SQL servers .");
                MessageInfo.ShowDialog();
            }

        }

        private void DataBaseTable()
        {
            TableUser();
            TablecProduct();
            TablecCategory();
            TablecBrand();
            TableSupplier();
            TableStorage();
            TableInvoice();
            TableStorageProduct();
            TableStorageTransfer();
            TableStorageMember();
            TableSalesinvoice();
            TableStorageShipping();
            AlterProduct();



        }

        private void TableUser()
        {
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT nspname FROM pg_catalog.pg_namespace");
            if (result.Contains("username"))
            {
                MessageInfo MessageInfo = new MessageInfo("DataBase-Username already exists .");
                MessageInfo.ShowDialog();
            }
            else
            {
                SQLConnect.Instance.PgSQL_Command("CREATE SCHEMA IF NOT EXISTS username");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS username.accounts (" +
                    "user_id bigserial PRIMARY KEY," +
                    "username VARCHAR ( 50 ) UNIQUE NOT NULL," +
                    "password VARCHAR ( 50 ) NOT NULL," +
                    "location_id int NOT NULL," +
                    "state boolean NOT NULL," +
                    "created_on TIMESTAMP NOT NULL," +
                    "last_login TIMESTAMP)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS username.roles (role_id bigserial PRIMARY KEY," +
                    "role_name VARCHAR (255) UNIQUE NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS username.account_roles (user_id INT NOT NULL," +
                    "role_id INT NOT NULL," +
                    "grant_date TIMESTAMP," +
                    "PRIMARY KEY (user_id, role_id)," +
                    "FOREIGN KEY (role_id)REFERENCES username.roles (role_id)," +
                    "FOREIGN KEY (user_id) REFERENCES username.accounts (user_id))");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO username.roles(role_name) VALUES ('administrator')");
                string user = ApplicationSetting.Default.Admin_User;
                string passwd = ApplicationSetting.Default.Admain_Password;
                bool state = true;
                string data = ConvertType.GetTimeStamp();
                string roletext = "administrator";
                SQLConnect.Instance.PgSQL_Command("INSERT INTO username.accounts(username,password,location_id,state,created_on,last_login) VALUES('" + user + "','" + passwd + "','" + "1" +"','" + state + "','" + data + "','" + data + "')");
                List<int> roleidresult = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT role_id FROM username.roles WHERE role_name='" + roletext + "'");
                List<int> useridresult = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT user_id FROM username.accounts WHERE username='" + user + "'");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO username.account_roles(user_id,role_id,grant_date) VALUES('" + useridresult[0] + "','" + roleidresult[0] + "','" + data + "')");

            }

        }
        private void TablecProduct()
        {
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT nspname FROM pg_catalog.pg_namespace");
            if (result.Contains("productlibrary"))
            {
                MessageInfo MessageInfo = new MessageInfo("DataBase-Product Library already exists .");
                MessageInfo.ShowDialog();
            }
            else
            {
                SQLConnect.Instance.PgSQL_Command("CREATE SCHEMA IF NOT EXISTS productlibrary");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS productlibrary.product_code (" +
                    "product_id bigserial PRIMARY KEY," +
                    "sn VARCHAR ( 50 ) NOT NULL," +
                    "cost decimal NOT NULL," +
                    "qty INT NOT NULL," +
                    "supplier_id INT NOT NULL," +
                    "storage_id INT NOT NULL," +
                    "inv_id INT NOT NULL," +
                    "status INT NOT NULL," +
                    "state boolean NOT NULL," +
                    "comment VARCHAR ( 50 )," +
                    "booking_no VARCHAR ( 50 )," +
                    "booking_day TIMESTAMP ," +
                    "purchese_no VARCHAR ( 50 ) NOT NULL," +
                    "purchese_day DATE NOT NULL," +
                    "selling_no VARCHAR ( 50 )," +
                    "selling_day TIMESTAMP," +
                    "created_on TIMESTAMP NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS productlibrary.product_sum (" +
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
                    "upload_date TIMESTAMP ," +
                    "created_on TIMESTAMP NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS productlibrary.status (" +
                    "status_id bigserial PRIMARY KEY," +
                    "status_name VARCHAR (50) UNIQUE NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO productlibrary.status(status_name) VALUES('normal')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO productlibrary.status(status_name) VALUES('transfer')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO productlibrary.status(status_name) VALUES('rma')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO productlibrary.status(status_name) VALUES('sold')");
            }

        }

        private void TablecCategory()
        {
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT nspname FROM pg_catalog.pg_namespace");
            if (result.Contains("productcategory"))
            {
                MessageInfo MessageInfo = new MessageInfo("DataBase-Category Library already exists .");
                MessageInfo.ShowDialog();
            }
            else
            {
                SQLConnect.Instance.PgSQL_Command("CREATE SCHEMA IF NOT EXISTS productcategory");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS productcategory.category (category_id bigserial PRIMARY KEY," +
                "category_name VARCHAR (255) UNIQUE NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS productcategory.product_category (product_id INT NOT NULL," +
                    "category_id INT NOT NULL," +
                    "grant_date TIMESTAMP," +
                    "PRIMARY KEY (product_id, category_id)," +
                    "FOREIGN KEY (category_id)REFERENCES productcategory.category (category_id)," +
                    "FOREIGN KEY (product_id) REFERENCES productlibrary.product_sum (product_id))");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO productcategory.category(category_name) VALUES('OTHER')");
            }
        }
        private void TablecBrand()
        {
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT nspname FROM pg_catalog.pg_namespace");
            if (result.Contains("productbrand"))
            {
                MessageInfo MessageInfo = new MessageInfo("DataBase-brand Library already exists .");
                MessageInfo.ShowDialog();
            }
            else
            {
                SQLConnect.Instance.PgSQL_Command("CREATE SCHEMA IF NOT EXISTS productbrand");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS productbrand.brand (brand_id bigserial PRIMARY KEY," +
                "brand_name VARCHAR (255) UNIQUE NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS productbrand.product_brand (product_id INT NOT NULL," +
                    "brand_id INT NOT NULL," +
                    "grant_date TIMESTAMP," +
                    "PRIMARY KEY (product_id, brand_id)," +
                    "FOREIGN KEY (brand_id)REFERENCES productbrand.brand (brand_id)," +
                    "FOREIGN KEY (product_id) REFERENCES productlibrary.product_sum (product_id))");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO productbrand.brand(brand_name) VALUES('OTHER')");
            }
        }

        private void TableSupplier()
        {
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT nspname FROM pg_catalog.pg_namespace");
            if (result.Contains("productsupplier"))
            {
                MessageInfo MessageInfo = new MessageInfo("DataBase-supplier Library already exists .");
                MessageInfo.ShowDialog();
            }
            else
            {
                SQLConnect.Instance.PgSQL_Command("CREATE SCHEMA IF NOT EXISTS productsupplier");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS productsupplier.supplier (supplier_id bigserial PRIMARY KEY," +
                    "supplier_name VARCHAR (255) UNIQUE NOT NULL," +
                    "code VARCHAR ( 50 ) UNIQUE NOT NULL," +
                    "br VARCHAR ( 50 )," +
                    "address VARCHAR (255) NOT NULL," +
                    "corressaddress VARCHAR (255)," +
                    "off_tel VARCHAR ( 50 ) NOT NULL," +
                    "off_fax VARCHAR ( 50 )," +
                    "off_email VARCHAR ( 50 )," +
                    "bankname VARCHAR ( 50 )," +
                    "bankacc VARCHAR ( 50 )," +
                    "contact VARCHAR ( 50 ) NOT NULL," +
                    "con_title VARCHAR ( 50 )," +
                    "con_tel VARCHAR ( 50 ), " +
                    "con_email VARCHAR ( 50 )," +
                    "con_othertel VARCHAR ( 50 )," +
                    "comment VARCHAR ( 50 )," +
                    "state boolean NOT NULL," +
                    "hash VARCHAR ( 50 ) ," +
                    "upload_date TIMESTAMP ," +
                    "created_on TIMESTAMP NOT NULL)");
                string data = ConvertType.GetTimeStamp();
                SQLConnect.Instance.PgSQL_Command("INSERT INTO productsupplier.supplier(supplier_name,code,address,off_tel,contact,state,created_on) VALUES('OTHER','OTH','N/A','000000','OTHER','true','" + data + "')");
            }
        }
        private void TableStorage()
        {
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT nspname FROM pg_catalog.pg_namespace");
            if (result.Contains("productstorage"))
            {
                MessageInfo MessageInfo = new MessageInfo("DataBase-storage Library already exists .");
                MessageInfo.ShowDialog();
            }
            else
            {
                SQLConnect.Instance.PgSQL_Command("CREATE SCHEMA IF NOT EXISTS productstorage");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS productstorage.storage (" +
                    "storage_id bigserial PRIMARY KEY," +
                    "storage_name VARCHAR (255) UNIQUE NOT NULL," +
                    "code VARCHAR ( 50 ) UNIQUE NOT NULL," +
                    "address VARCHAR (255)," +
                    "off_tel VARCHAR ( 50 )," +
                    "off_fax VARCHAR ( 50 )," +
                    "off_email VARCHAR ( 50 )," +
                    "comment VARCHAR ( 50 )," +
                    "state boolean NOT NULL," +
                    "hash VARCHAR ( 50 ) ," +
                    "upload_date TIMESTAMP ," +
                    "created_on TIMESTAMP NOT NULL)");
                string data = ConvertType.GetTimeStamp();
                SQLConnect.Instance.PgSQL_Command("INSERT INTO productstorage.storage(storage_name,code,state,hash,created_on) VALUES('Summary','Summary','true','SUMMARY','" + data + "')");
            }
        }

        private void TableInvoice()
        {
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT nspname FROM pg_catalog.pg_namespace");
            if (result.Contains("tableinvoice"))
            {
                MessageInfo MessageInfo = new MessageInfo("DataBase-Invoice Library already exists .");
                MessageInfo.ShowDialog();
            }
            else
            {
                SQLConnect.Instance.PgSQL_Command("CREATE SCHEMA IF NOT EXISTS tableinvoice");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS tableinvoice.invoicenum (invoice_id bigserial PRIMARY KEY," +
                    "invoice_num VARCHAR (255) UNIQUE NOT NULL," +
                    "invoice_item_id INT NOT NULL," +
                    "supplier_id INT NOT NULL," +
                    "storage_id INT NOT NULL," +
                    "amount decimal NOT NULL," +
                    "comment VARCHAR ( 50 )," +
                    "invoicedate DATE NOT NULL," +
                    "created_on TIMESTAMP NOT NULL," +
                    "upload_date TIMESTAMP ," +
                    "state boolean NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS tableinvoice.invoiceitem (" +
                    "invoice_id bigserial PRIMARY KEY," +
                    "invoice_num VARCHAR (255) UNIQUE NOT NULL," +
                    "created_on TIMESTAMP NOT NULL," +
                    "state boolean NOT NULL," +
                    "itemmodel_1 VARCHAR (255)," +
                    "itemname_1 VARCHAR (255)," +
                    "itemcost_1 decimal," +
                    "itempcs_1 INT)");
            }
        }

        private void TableStorageProduct()
        {
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT nspname FROM pg_catalog.pg_namespace");
            if (result.Contains("productstorage_code"))
            {
                MessageInfo MessageInfo = new MessageInfo("DataBase-StorageProduct Library already exists .");
                MessageInfo.ShowDialog();
            }
            else
            {
                SQLConnect.Instance.PgSQL_Command("CREATE SCHEMA IF NOT EXISTS productstorage_code");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS productstorage_code.storageproduct_code (product_id bigserial PRIMARY KEY," +
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
                    "upload_date TIMESTAMP ," +
                    "created_on TIMESTAMP NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS productstorage_code.storageproduct_sumcode (" +
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
                    "upload_date TIMESTAMP ," +
                    "created_on TIMESTAMP NOT NULL)");
            }
        }

        private void TableStorageTransfer()
        {
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT nspname FROM pg_catalog.pg_namespace");
            if (result.Contains("storagetransfer"))
            {
                MessageInfo MessageInfo = new MessageInfo("DataBase-StorageTransfer Library already exists .");
                MessageInfo.ShowDialog();
            }
            else
            {
                SQLConnect.Instance.PgSQL_Command("CREATE SCHEMA IF NOT EXISTS storagetransfer");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS storagetransfer.transfer (" +
                    "transfer_id bigserial PRIMARY KEY," +
                    "transfer_number VARCHAR ( 50 ) UNIQUE NOT NULL," +
                    "transferitem_id INT NOT NULL," +
                    "from_storage INT NOT NULL," +
                    "to_storage INT NOT NULL," +
                    "username VARCHAR ( 50 ) NOT NULL," +
                    "state boolean NOT NULL," +
                    "comment VARCHAR ( 50 )," +
                    "created_on TIMESTAMP NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS storagetransfer.transferitem (" +
                    "transfer_id bigserial PRIMARY KEY," +
                    "transfer_number VARCHAR (255) UNIQUE NOT NULL," +
                    "created_on TIMESTAMP NOT NULL," +
                    "state boolean NOT NULL," +
                    "product_id_1 INT ," +
                    "item_id_1 INT ," +
                    "item_sn_1 VARCHAR (255))");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS storagetransfer.status (" +
                    "status_id bigserial PRIMARY KEY," +
                    "status_name VARCHAR (255) UNIQUE NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS storagetransfer.transfer_status (" +
                    "transfer_id INT NOT NULL," +
                    "status_id INT NOT NULL," +
                    "grant_date TIMESTAMP," +
                    "upload_date TIMESTAMP," +
                    "PRIMARY KEY (transfer_id, status_id)," +
                    "FOREIGN KEY (transfer_id)REFERENCES storagetransfer.transfer (transfer_id)," +
                    "FOREIGN KEY (status_id) REFERENCES storagetransfer.status (status_id))");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO storagetransfer.status(status_name) VALUES('normal')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO storagetransfer.status(status_name) VALUES('transfer')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO storagetransfer.status(status_name) VALUES('done')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO storagetransfer.status(status_name) VALUES('cancel')");
            }
        }

        private void TableStorageMember()
        {
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT nspname FROM pg_catalog.pg_namespace");
            if (result.Contains("storagemember"))
            {
                MessageInfo MessageInfo = new MessageInfo("DataBase-Memberfer Library already exists .");
                MessageInfo.ShowDialog();
            }
            else
            {
                SQLConnect.Instance.PgSQL_Command("CREATE SCHEMA IF NOT EXISTS storagemember");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS storagemember.member (" +
                    "member_id bigserial PRIMARY KEY," +
                    "customer_sc VARCHAR ( 50 ) UNIQUE NOT NULL," +
                    "member_number VARCHAR ( 50 ) UNIQUE NOT NULL," +
                    "member_gender VARCHAR ( 50 )," +
                    "birth VARCHAR ( 50 ) ," +
                    "email VARCHAR ( 50 )," +
                    "title VARCHAR ( 50 )," +
                    "fax_no VARCHAR ( 50 )," +
                    "tel_no VARCHAR ( 50 )," +
                    "mem_comment VARCHAR ( 50 )," +
                    "billing_company VARCHAR ( 50 )," +
                    "billing_person VARCHAR ( 50 )," +
                    "billing_address VARCHAR ( 50 )," +
                    "billing_tel VARCHAR ( 50 )," +
                    "ship_company VARCHAR ( 50 )," +
                    "ship_person VARCHAR ( 50 )," +
                    "ship_address VARCHAR ( 50 )," +
                    "ship_tel VARCHAR ( 50 )," +
                    "ship_comment VARCHAR ( 50 )," +
                    "pay_comment VARCHAR ( 50 )," +
                    "pay_terms VARCHAR ( 50 )," +
                    "pay_method VARCHAR ( 50 )," +
                    "state boolean NOT NULL," +
                    "upload_date TIMESTAMP ," +
                    "created_on TIMESTAMP NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS storagemember.paymethod (" +
                    "paymethod_id bigserial PRIMARY KEY," +
                    "paymethod_name VARCHAR (255) UNIQUE NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS storagemember.payterms (" +
                    "payterms_id bigserial PRIMARY KEY," +
                    "payterms_name VARCHAR (255) UNIQUE NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO storagemember.payterms(payterms_name) VALUES('CASH ON DELIVERY')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO storagemember.paymethod(paymethod_name) VALUES('CASH')");
                string block = string.Empty;
                string data = ConvertType.GetTimeStamp();
                SQLConnect.Instance.PgSQL_Command("INSERT INTO storagemember.member(customer_sc,member_number,member_gender,birth,email,title,fax_no,tel_no,mem_comment," +
                    "billing_company,billing_person,billing_address,billing_tel," +
                    "ship_company,ship_person,ship_address,ship_tel,ship_comment," +
                    "pay_comment,pay_terms,pay_method,state,upload_date,created_on) VALUES('WALKIN','WALK IN','" + block + "','" + block + "','" + block + "','" + block + "','" + block + "','" + block + "','" + block + "'," +
                    "'" + block + "','" + block + "','" + block + "','" + block + "'," +
                    "'" + block + "','" + block + "','" + block + "','" + block + "','" + block + "'," +
                    "'" + block + "','" + "CASH ON DELIVERY" + "','" + "CASH" + "','true','" + data + "','" + data + "')");
            }
        }



        private void TableSalesinvoice()
        {
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT nspname FROM pg_catalog.pg_namespace");
            if (result.Contains("salesinvoice"))
            {
                MessageInfo MessageInfo = new MessageInfo("DataBase-Salesinvoice Library already exists .");
                MessageInfo.ShowDialog();
            }
            else
            {
                SQLConnect.Instance.PgSQL_Command("CREATE SCHEMA IF NOT EXISTS salesinvoice");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS salesinvoice.salesinvoicesum (" +
                    "invoice_id bigserial PRIMARY KEY," +
                    "invoice_number VARCHAR ( 50 ) UNIQUE NOT NULL," +
                    "invoiceitem_id INT NOT NULL," +
                    "client_id INT NOT NULL," +
                    "shipping_id INT ," +
                    "username_id INT NOT NULL," +
                    "storage_id INT NOT NULL," +
                    "total_qty INT NOT NULL," +
                    "total decimal NOT NULL," +
                    "deposit decimal NOT NULL," +
                    "balance decimal NOT NULL," +
                    "deposit_pay_method VARCHAR ( 50 ) NOT NULL," +
                    "balance_pay_method VARCHAR ( 50 ) NOT NULL," +
                    "pay_terms VARCHAR ( 50 ) NOT NULL," +
                    "comment VARCHAR ( 50 )," +
                    "upload_date TIMESTAMP ," +
                    "created_on TIMESTAMP NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS salesinvoice.salesinvoiceitem (" +
                    "invoice_id bigserial PRIMARY KEY," +
                    "invoice_number VARCHAR (255) UNIQUE NOT NULL," +
                    "created_on TIMESTAMP NOT NULL," +
                    "product_id_1 INT ," +
                    "product_cost_1 decimal ," +
                    "product_srp_1 decimal ," +
                    "item_id_1 INT ," +
                    "item_sn_1 VARCHAR (255))");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS salesinvoice.status (" +
                    "status_id bigserial PRIMARY KEY," +
                    "status_name VARCHAR (255) UNIQUE NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS salesinvoice.pay_status (" +
                    "pay_status_id bigserial PRIMARY KEY," +
                    "pay_status_name VARCHAR (255) UNIQUE NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS salesinvoice.salesinvoice_status (" +
                    "invoice_id INT NOT NULL," +
                    "status_id INT NOT NULL," +
                    "pay_status_id INT NOT NULL," +
                    "grant_date TIMESTAMP," +
                    "upload_date TIMESTAMP," +
                    "state boolean NOT NULL," +
                    "PRIMARY KEY (invoice_id, status_id, pay_status_id)," +
                    "FOREIGN KEY (invoice_id)REFERENCES salesinvoice.salesinvoicesum (invoice_id)," +
                    "FOREIGN KEY (pay_status_id)REFERENCES salesinvoice.pay_status (pay_status_id)," +
                    "FOREIGN KEY (status_id) REFERENCES salesinvoice.status (status_id))");

                SQLConnect.Instance.PgSQL_Command("INSERT INTO salesinvoice.status(status_name) VALUES('NORMAL')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO salesinvoice.status(status_name) VALUES('SIPPING')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO salesinvoice.status(status_name) VALUES('VOID')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO salesinvoice.status(status_name) VALUES('BOOKING')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO salesinvoice.pay_status(pay_status_name) VALUES('PAID ')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO salesinvoice.pay_status(pay_status_name) VALUES('UNPAID')");
            }
        }

        private void TableStorageShipping()
        {
            List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT nspname FROM pg_catalog.pg_namespace");
            if (result.Contains("invoiceshipping"))
            {
                MessageInfo MessageInfo = new MessageInfo("DataBase-Shipping Library already exists .");
                MessageInfo.ShowDialog();
            }
            else
            {
                SQLConnect.Instance.PgSQL_Command("CREATE SCHEMA IF NOT EXISTS invoiceshipping");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS invoiceshipping.shippinginv (" +
                    "shippinginv_id bigserial PRIMARY KEY," +
                    "invoice VARCHAR ( 50 ) UNIQUE NOT NULL," +
                    "username int NOT NULL," +
                    "ship_method INT ," +
                    "ship_details VARCHAR ( 50 )," +
                    "ship_number VARCHAR ( 50 ) NOT NULL," +
                    "ship_company VARCHAR ( 50 )," +
                    "ship_person VARCHAR ( 50 )," +
                    "ship_address VARCHAR ( 50 )," +
                    "ship_tel VARCHAR ( 50 )," +
                    "ship_comment VARCHAR ( 50 )," +
                    "comment VARCHAR ( 50 )," +
                    "upload_date TIMESTAMP," +
                    "created_on TIMESTAMP NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS invoiceshipping.status (" +
                    "status_id bigserial PRIMARY KEY," +
                    "status_name VARCHAR (255) UNIQUE NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS invoiceshipping.method (" +
                    "method_id bigserial PRIMARY KEY," +
                    "method_name VARCHAR (255) UNIQUE NOT NULL)");
                SQLConnect.Instance.PgSQL_Command("CREATE TABLE IF NOT EXISTS invoiceshipping.shipping_status (" +
                    "shippinginv_id INT NOT NULL," +
                    "status_id INT NOT NULL," +
                    "grant_date TIMESTAMP," +
                    "cc TIMESTAMP," +
                    "state boolean NOT NULL," +
                    "PRIMARY KEY (shippinginv_id, status_id)," +
                    "FOREIGN KEY (shippinginv_id)REFERENCES invoiceshipping.shippinginv (shippinginv_id)," +
                    "FOREIGN KEY (status_id) REFERENCES invoiceshipping.status (status_id))");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO invoiceshipping.status(status_name) VALUES('OTHER')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO invoiceshipping.status(status_name) VALUES('NORMAL')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO invoiceshipping.status(status_name) VALUES('WAIT')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO invoiceshipping.status(status_name) VALUES('TRANSFER')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO invoiceshipping.status(status_name) VALUES('DONE')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO invoiceshipping.status(status_name) VALUES('CANCEL')");
                SQLConnect.Instance.PgSQL_Command("INSERT INTO invoiceshipping.method(method_name) VALUES('OTHER')");

            }
        }
        private void AlterProduct()
        {
            Productcenum();
            Invoicenum();
            Storagecenum();
            usercenum();
            transfer();
            shipping();
        
        }

        private void Productcenum()
        {
            SQLConnect.Instance.PgSQL_Command("ALTER TABLE productlibrary.product_code ADD CONSTRAINT fk_supplier_code FOREIGN KEY (supplier_id) REFERENCES productsupplier.supplier (supplier_id)");
            SQLConnect.Instance.PgSQL_Command("ALTER TABLE productlibrary.product_code ADD CONSTRAINT fk_storage_code FOREIGN KEY (storage_id) REFERENCES productstorage.storage (storage_id)");
            SQLConnect.Instance.PgSQL_Command("ALTER TABLE productlibrary.product_sum ADD CONSTRAINT fk_supplier_sum FOREIGN KEY (supplier_id) REFERENCES productsupplier.supplier (supplier_id)");
        }

        private void Invoicenum()
        {
            SQLConnect.Instance.PgSQL_Command("ALTER TABLE tableinvoice.invoicenum ADD CONSTRAINT fk_invoiceitem_num FOREIGN KEY (invoice_item_id) REFERENCES tableinvoice.invoiceitem (invoice_id)");
            SQLConnect.Instance.PgSQL_Command("ALTER TABLE tableinvoice.invoicenum ADD CONSTRAINT fk_supplier_num FOREIGN KEY (supplier_id) REFERENCES productsupplier.supplier (supplier_id)");
            SQLConnect.Instance.PgSQL_Command("ALTER TABLE tableinvoice.invoicenum ADD CONSTRAINT fk_storage_num FOREIGN KEY (storage_id) REFERENCES productstorage.storage (storage_id)");
        }

        private void Storagecenum()
        {
            SQLConnect.Instance.PgSQL_Command("ALTER TABLE productstorage_code.storageproduct_code ADD CONSTRAINT fk_supplier_code FOREIGN KEY (supplier_id) REFERENCES productsupplier.supplier (supplier_id)");
            SQLConnect.Instance.PgSQL_Command("ALTER TABLE productstorage_code.storageproduct_code ADD CONSTRAINT fk_storage_code FOREIGN KEY (storage_id) REFERENCES productstorage.storage (storage_id)");
            SQLConnect.Instance.PgSQL_Command("ALTER TABLE productstorage_code.storageproduct_sumcode ADD CONSTRAINT fk_supplier_sum FOREIGN KEY (supplier_id) REFERENCES productsupplier.supplier (supplier_id)");
        }

        private void usercenum()
        {
            SQLConnect.Instance.PgSQL_Command("ALTER TABLE username.accounts ADD CONSTRAINT fk_username_storage FOREIGN KEY (location_id) REFERENCES productstorage.storage (storage_id)");
        }

        private void transfer()
        {
            SQLConnect.Instance.PgSQL_Command("ALTER TABLE storagetransfer.transfer ADD CONSTRAINT fk_transfer_status FOREIGN KEY (transferitem_id) REFERENCES storagetransfer.transferitem (transfer_id)");
        }

        private void shipping()
        {
            SQLConnect.Instance.PgSQL_Command("ALTER TABLE invoiceshipping.shippinginv ADD CONSTRAINT fk_shippinginv_method FOREIGN KEY (ship_method) REFERENCES invoiceshipping.method (method_id)");
        }

        private void PlugFolder()
        {
            string PathBase = AppDomain.CurrentDomain.BaseDirectory;
            string Pluginpath = Path.Combine(PathBase, "Plugins");
            bool PlugdirectoryExists = Directory.Exists(Pluginpath);
            if (PlugdirectoryExists == false)
            {
                Directory.CreateDirectory(Pluginpath);
            }

            string Tmpinpath = Path.Combine(PathBase, "Tmp");
            bool TmpdirectoryExists = Directory.Exists(Tmpinpath);
            if (TmpdirectoryExists == false)
            {
                Directory.CreateDirectory(Tmpinpath);
            }

        }

        private void BtnDatabaseintegrity_Click(object sender, EventArgs e)
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT nspname FROM pg_catalog.pg_namespace");
                if (result.Contains("username"))
                {
                    List<string> tablename = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT table_name FROM information_schema.tables WHERE table_schema = 'username'AND table_type = 'BASE TABLE'");
                    if (tablename.Contains("account_roles") && tablename.Contains("roles") && tablename.Contains("accounts"))
                    {
                        MessageBox.Show("Account DataBase Complete .", "Message", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void BtnConnectDataBase_Click(object sender, EventArgs e)
        {
            ConnectDB ConnectDB = new ConnectDB();
            ConnectDB.ShowDialog();
        }
    }
}
