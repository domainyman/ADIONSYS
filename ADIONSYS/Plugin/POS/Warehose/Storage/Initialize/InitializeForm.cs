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
using ADIONSYS.Tool;

namespace ADIONSYS.Plugin.POS.Warehose.Storage.Initialize
{
    public partial class InitializeForm : Form
    {
        public InitializeForm()
        {
            InitializeComponent();
            Startup();
        }
        private void Startup()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT storage_name FROM productstorage.storage");
                CMBoxList.DataSource = result;
                CMBoxList.SelectedIndex = -1;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int Storage_id()
        {
            string name = CMBoxList.Text;
            List<int> result_Storage_id = SQLConnect.Instance.PgSQL_SELECTDataint("SELECT storage_id FROM productstorage.storage WHERE storage_name='" + name + "'");
            int Storage_id = result_Storage_id[0];
            return Storage_id;

        }


        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (CMBoxList.Text != string.Empty && CMBoxList.Text != "Summary")
            {
                try
                {
                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        if (UpdataProductLib() == true)
                        {
                            MessageInfo MessageInfo = new MessageInfo("Initialize Finish");
                            MessageInfo.ShowDialog();
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

        private bool UpdataProductLib()
        {
            bool done = false;
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {

                    int storage_id = Storage_id();
                    string result_storage_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productstorage.storage WHERE storage_id='" + storage_id + "'");
                    string storageschemaname = "\"" + result_storage_hash_name + "\"";
                    string tablenameSUM = "\"" + "product_sum" + "\"";
                    string droptablesumname = storageschemaname + "." + tablenameSUM ;
                    List<string> result_Product_hash = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT hash FROM productlibrary.product_sum ");
                    for (int i = 0; i < result_Product_hash.Count(); i++)
                    {
                        
                        string schemaname = "\"" + "productlibrary" + "\"";
                        string tablesName = "\"" + result_Product_hash[i] + "\"";
                        string tablefullname = schemaname + "." + tablesName;
                        List<string> result_schemanametable_hash = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT hash FROM "+ droptablesumname);
                        if (result_schemanametable_hash.Contains(result_Product_hash[i]))
                        {
                            SQLConnect.Instance.PgSQL_Command("UPDATE " + droptablesumname + " stt SET qty = (SELECT SUM(qty) FROM " + tablefullname + " WHERE storage_id='" + storage_id + "') WHERE stt.hash ='" + result_Product_hash[i] + "'");
                        }
                        else
                        {
                            //Fix it !!!!!!
                            MessageInfo MessageInfo = new MessageInfo("Product NOT Contains Database");
                            MessageInfo.ShowDialog();
                        }
                    }
                    done = true;
                    return done;
                }
                else
                {
                    return done;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageInfo = new MessageInfo(ex.Message);
                MessageInfo.ShowDialog();
                return done;
            }
        }
    }




}
