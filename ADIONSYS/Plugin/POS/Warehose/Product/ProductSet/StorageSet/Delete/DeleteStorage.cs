using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADIONSYS.Tool;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.StorageSet.Delete
{
    public partial class DeleteStorage : Form
    {
        public DeleteStorage()
        {
            InitializeComponent();
            Startup();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT storage_name FROM productstorage.storage");
                CMBoxList.DataSource = result;
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
            this.LBMessageBox.Text = "Storage is currently using!";
            this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.LBMessageBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
        }

        private bool DropDataBase(int sid)
        {
            bool result = false;
            int storage_id = sid;
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productstorage.storage WHERE storage_id='" + storage_id + "'");
                    string schemaname = result_hash_name;
                    string tablename = "product_code";
                    string droptablename = "\"" + schemaname + "\"" + "." + "\"" + tablename + "\"";
                    string tablenameSUM = "product_sum";
                    string droptablesumname = "\"" + schemaname + "\"" + "." + "\"" + tablenameSUM + "\"";
                    SQLConnect.Instance.PgSQL_Command("DELETE FROM productstorage.storage WHERE storage_id='" + storage_id + "'");
                    SQLConnect.Instance.PgSQL_Command("DROP TABLE IF EXISTS " + droptablename);
                    SQLConnect.Instance.PgSQL_Command("DROP TABLE IF EXISTS " + droptablesumname);
                    SQLConnect.Instance.PgSQL_Command("DROP SCHEMA IF EXISTS " + schemaname);
                    result = true;
                }
                return result;

            }
            catch (Exception ex)
            {
                MessageInfo MessageInfo = new MessageInfo(ex.Message);
                MessageInfo.ShowDialog();
                return result;
            }
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    List<int> qty_list = new List<int>();
                    string storage = CMBoxList.Text;
                    if (storage != "Summary")
                    {
                        List<int> result_storage_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT storage_id FROM productstorage.storage WHERE storage_name='" + storage + "'");
                        int storage_id = result_storage_id[0];
                        List<int> result_product_code = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT product_id FROM productlibrary.product_sum");
                        for (int i = 0; i < result_product_code.Count; i++)
                        {
                            string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id='" + result_product_code[i] + "'");
                            string droptablename = "productlibrary." + "\"" + result_hash_name + "\"";
                            List<int> result_storage = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT qty FROM "+ droptablename + " WHERE storage_id='" + storage_id + "'");
                            qty_list.Add(result_storage.Sum());
                        }
                        Console.Write(qty_list.Sum());
                        if (qty_list.Sum() > 0)
                        {
                            vaildlabel();
                        }
                        else if (qty_list.Sum() == 0)
                        {
                            List<int> result_storage_Otherid = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT storage_id FROM productstorage.storage WHERE storage_name='Summary'");
                            for (int i = 0; i < result_product_code.Count; i++)
                            {
                                string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id='" + result_product_code[i] + "'");
                                string droptablename = "productlibrary." + "\"" + result_hash_name + "\"";
                                List<int> result_storage = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT product_id FROM "+ droptablename + " WHERE storage_id='" + storage_id + "'");
                                for (int q = 0; q < result_storage.Count; q++)
                                {
                                    SQLConnect.Instance.PgSQL_Command("UPDATE "+ droptablename + " SET storage_id='" + result_storage_Otherid[0] + "' WHERE product_id='" + result_storage[q] + "'"); 
                                }
                            }
                                       
                            if (DropDataBase(storage_id) == true)
                            {
                                Startup();
                                savelabel();
                            }
                        }
                    }
                    else
                    {
                        vaildlabel();
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
