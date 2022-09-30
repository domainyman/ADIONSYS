using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADIONSYS.Tool;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Diagnostics.Eventing.Reader;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using static System.Windows.Forms.AxHost;
using System.Security.Cryptography.Xml;
using ADIONSYS.ConvertFunction;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADIONSYS.Plugin.POS.Warehose.Storage.Situation
{
    public partial class TransferDetil : Form
    {
        public Dictionary<int, List<string>> SN = new();
        public int Transfer_id;
        public TransferDetil(int Trans_id)
        {
            InitializeComponent();
            Transfer_id = Trans_id;
            Startup();
        }

        private bool Startup()
        {
            bool done = false;
            if (done == false)
            {
                List<string> result_Transfer_info = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT transfer_number,(SELECT storage_name FROM productstorage.storage WHERE storage_id = tr.from_storage)" +
                    ",(SELECT storage_name FROM productstorage.storage WHERE storage_id = tr.to_storage)" +
                    ",username,comment FROM storagetransfer.transfer tr WHERE transfer_id='" + Transfer_id + "'");
                List<DateTime> result_DateTime = SQLConnect.Instance.PgSQL_SELECTDataDateTime("SELECT created_on FROM storagetransfer.transfer WHERE transfer_id= '" + Transfer_id + "'");
                Textcodeno.Text = result_Transfer_info[0];
                LBTextFrom.Text = result_Transfer_info[1];
                LBTextFrom.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                LBTextTo.Text = result_Transfer_info[2];
                LBTextTo.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                LBusername.Text = result_Transfer_info[3];
                textComment.Text = result_Transfer_info[4];
                LBtextstatus.Text = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT upper((SELECT status_name FROM storagetransfer.status WHERE status_id =" +
                    "(SELECT status_id FROM storagetransfer.transfer_status WHERE transfer_id = '" + Transfer_id + "')))");
                LBtextstatus.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                LBTransDate.Text = result_DateTime[0].ToString("dd-MM-yyyy");
                ShowTransDetailGridView();
                done = true;
            }
            return done;

        }

        private void ShowTransDetailGridView()
        {
            LoadingTable();
            if (TransDetailGridView.ColumnCount < 0)
            {
                LBrecord.Text = "No Records Found ";
            }


        }
        private void LoadingTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Status");
            dt.Columns.Add("Product ID");
            //TransDetailGridView.Columns[1].FillWeight = 50;
            dt.Columns.Add("Product Name");
            dt.Columns.Add("Quantity");
            DataTable Trans_Table = SQLConnect.Instance.LoadDateTableStorage("SELECT upper((SELECT status_name FROM storagetransfer.status WHERE status_id =" +
                "(SELECT status_id FROM storagetransfer.transfer_status WHERE transfer_id = '" + Transfer_id + "')))AS status," +
                "* FROM storagetransfer.transferitem WHERE transfer_id = (SELECT transferitem_id FROM storagetransfer.transfer WHERE transfer_id = '" + Transfer_id + "')");
            Trans_Table.Columns.Remove("transfer_id");
            Trans_Table.Columns.Remove("transfer_number");
            Trans_Table.Columns.Remove("created_on");
            Trans_Table.Columns.Remove("state");
            List<int> Product_id = ResetLoadTable(Trans_Table);
            Dictionary<int, int> Product_qty = ResetLoadProductQtyTable(Trans_Table);
            SN = ResetLoadProductSNTable(Trans_Table);
            LBTotal.Text = "Quantity : " + TotQTY(Product_qty).ToString();
            for (int i = 0; i < Product_id.Count; i++)
            {
                DataRow row = dt.NewRow();
                row[0] = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT upper((SELECT status_name FROM storagetransfer.status WHERE status_id =" +
                "(SELECT status_id FROM storagetransfer.transfer_status WHERE transfer_id = '" + Transfer_id + "')))");
                row[1] = Product_id[i];
                row[2] = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT name FROM productlibrary.product_sum WHERE product_id=" + Product_id[i] + "");
                row[3] = Product_qty[Product_id[i]];
                dt.Rows.Add(row);

            }

            TransDetailGridView.DataSource = dt;
            
        }

        private int TotQTY(Dictionary<int, int> Product_qty)
        {
            int Total = Product_qty.Sum(x => x.Value);
            return Total;
        }

        private List<int> ResetLoadTable(DataTable dataTable)
        {
            List<int> Product_id = new();
            int Tab_Count = dataTable.Columns.Count;
            for (int i = 1; i < Tab_Count; i += 3)
            {
                if (dataTable.Rows[0][i] == DBNull.Value)
                {
                    break;
                }
                else
                {
                    int MyString = (int)dataTable.Rows[0][i];
                    Product_id.Add(MyString);
                }
            }
            Product_id = Product_id.Distinct().ToList();
            return Product_id;
        }
        
        private Dictionary<int, int> ResetLoadProductQtyTable(DataTable dataTable)
        {
            Dictionary<int, int> Product_Qty = new();
            List<int> Product_id = new();
            int Tab_Count = dataTable.Columns.Count;
            for (int i = 1; i < Tab_Count; i += 3)
            {
                if (dataTable.Rows[0][i] == DBNull.Value)
                {
                    break;
                }
                else
                {
                    int MyString = (int)dataTable.Rows[0][i];
                    Product_id.Add(MyString);
                }
            }
            foreach (var item in Product_id.GroupBy(s => s))
            {
                Product_Qty.Add(item.Key,item.Count());
            }
            return Product_Qty;
        }

        private Dictionary<int, List<string>> ResetLoadProductSN_id(DataTable dataTable)
        {
            Dictionary<int, List<string>> Product_SNDic = new();

            int Tab_Count = dataTable.Columns.Count;
            for (int i = 1; i < Tab_Count; i += 3)
            {
                if (dataTable.Rows[0][i] == DBNull.Value)
                {
                    break;
                }
                else
                {
                    int Pro_id = (int)dataTable.Rows[0].Field<int>(i+1);
                    string Pro_SN = (string)dataTable.Rows[0][i + 2];
                    if (Product_SNDic.ContainsKey(Pro_id))
                    {
                        Product_SNDic[Pro_id].Add(Pro_SN);
                    }
                    else
                    {
                        Product_SNDic.Add(Pro_id, new List<string> { Pro_SN });
                    }
                }
            }
            return Product_SNDic;
        }

        private Dictionary<int, List<string>> ResetLoadProductSNTable(DataTable dataTable)
        {
            Dictionary<int, List<string>> Product_SNDic = new();

            int Tab_Count = dataTable.Columns.Count;
            for (int i = 1; i < Tab_Count; i += 3)
            {
                if (dataTable.Rows[0][i] == DBNull.Value)
                {
                    break;
                }
                else
                {
                    int Pro_id = (int)dataTable.Rows[0].Field<int>(i);
                    string Pro_SN = (string)dataTable.Rows[0][i + 2];
                    if(Product_SNDic.ContainsKey(Pro_id))
                    {
                        Product_SNDic[Pro_id].Add(Pro_SN);
                    }
                    else
                    {
                        Product_SNDic.Add(Pro_id, new List<string> { Pro_SN });
                    }
                }
            }
            return Product_SNDic;
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if (textComment.Text != string.Empty)
            {
                try
                {
                    if (SQLConnect.Instance.ConnectState() == true)
                    {
                        string Comment = textComment.Text;
                        SQLConnect.Instance.PgSQL_Command("UPDATE storagetransfer.transfer SET comment = '" + Comment + "' WHERE transfer_id = '" + Transfer_id + "'");
                        Startup();
                        if (Startup() == true)
                        {
                            MessageInfo MessageInfo = new MessageInfo("Insert Finish");
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

        private bool Upload_item(Dictionary<int, List<string>> SN)
        {
            bool done = false;
            try 
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    List<int> keyList = new List<int>(SN.Keys);
                    int status = 1;
                    for (int i = 0; i < keyList.Count; i++)
                    {
                        List<string> list = SN[keyList[i]];
                        string result_hash_name = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT hash FROM productlibrary.product_sum WHERE product_id=" + keyList[i] + "");
                        string DatabaseName = "productlibrary." + "\"" + result_hash_name + "\"";
                        SQLConnect.Instance.PgSQL_Command("UPDATE " + DatabaseName + " SET status = '" + status + "' WHERE sn = '" + list[i] + "'");
                    }
                        
                }
            }
            catch
            {

            }
            return done;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    string Code_NUM = Textcodeno.Text;
                    int transfer_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT transfer_id FROM storagetransfer.transfer WHERE transfer_number = '" + Code_NUM + "'");
                    if (CheckID_status(Code_NUM) == 2)
                    {
                        int State = 4;
                        string data = ConvertType.GetTimeStamp();
                        SQLConnect.Instance.PgSQL_Command("UPDATE storagetransfer.transfer_status SET status_id = '" + State + "',upload_date = '" + data + "' WHERE transfer_id = '" + transfer_id + "'");

                    }


                }

            }
            catch (Exception ex)
            {
                MessageInfo MessageInfo = new MessageInfo(ex.Message);
                MessageInfo.ShowDialog();
            }
        }

        private int CheckID_status(string name)
        {
            int storage_qty = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT status_id FROM storagetransfer.transfer_status WHERE transfer_id = (SELECT transfer_id FROM storagetransfer.transfer WHERE transfer_number='" + name + "')");
            return storage_qty;
        }

        private void TransDetailGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow Row = TransDetailGridView.Rows[e.RowIndex];
                    int Product_id = Convert.ToInt32(Row.Cells[1].Value);
                    List<string> list = SN[Product_id];
                    SNSituation SNSituation = new SNSituation(list.Count,Product_id, list);
                    if (SNSituation.ShowDialog() == DialogResult.Cancel)
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageInfo MessageBox_text = new MessageInfo(ex.Message);
                    MessageBox_text.ShowDialog();
                }

            }
        }
    }
}
