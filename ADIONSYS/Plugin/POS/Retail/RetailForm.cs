using ADIONSYS.ConvertFunction;
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
    public partial class RetailForm : Form
    {
        public RetailForm()
        {
            InitializeComponent();
            LoadingForm();
        }

        private void LoadingForm()
        {
            SetupClient();
            ShowTime();
            ShowStorage();
            ShowUser();
        }

        private void SetupClient()
        {
            if (SQLConnect.Instance.ConnectState() == true)
            {
                List<string> resultClient = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT member_number FROM storagemember.member");
                CMBClient.DataSource = resultClient;
                CMBClient.SelectedIndex = -1;
            }
        }

        private void ShowTime ()
        {
            textDate.Text = ConvertType.GetTimeStamp();
        }

        private void ShowStorage()
        {
            textStorage.Text = ApplicationSetting.Default.Location;
        }
        private void ShowUser()
        {
            textsalesman.Text = ApplicationSetting.Default.User;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private void Btnclientinfo_Click(object sender, EventArgs e)
        {
            if(CMBClient.Text != string.Empty && CheckClient_Name() == true && SQLConnect.Instance.ConnectState() == true)
            {
                int result_member_id = SQLConnect.Instance.PgSQL_SELECTDataintsingle("SELECT member_id FROM storagemember.member WHERE member_number='" + CMBClient.Text + "'");
                ClientInfo ClientInfo = new(result_member_id);
                ClientInfo.ShowDialog();
            }
        }

        private bool CheckClient_Name()
        {
            bool done = false;
            if (CMBClient.Text != string.Empty && SQLConnect.Instance.ConnectState() == true )
            {
                List<string> resultClient = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT member_number FROM storagemember.member");
                if(resultClient.Contains(CMBClient.Text))
                {
                    done = true;
                    
                }
            }
            return done;

        }
    }
}
