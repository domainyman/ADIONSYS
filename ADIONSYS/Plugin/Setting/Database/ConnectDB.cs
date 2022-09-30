using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADIONSYS.ConvertFunction;


namespace ADIONSYS.Plugin.Setting.Database
{
    public partial class ConnectDB : Form
    {
        public ConnectDB()
        {
            InitializeComponent();
            recall_data();
        }

        private void ConnectBu_Click(object sender, EventArgs e)
        {
           
            ConvertType ConvertType = new ConvertType();
            string ConnSr = ConvertType.ConnString(hosttext.Text, porttext.Text, usernametext.Text, passwordtext.Text, databasenametext.Text);
            Task.Run(() => SQLConnect.Instance.CheckConnectDataBaseAddress(ConnSr));
            SQLConnect.Instance.CheckConnectDataBaseAddress(ConnSr).Wait();
            if (ApplicationSetting.Default.ConnectionState == false)
            {
                this.LBMessageBox.Text = "Warning : System is having trouble connecting to the SQL servers .";
                this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                this.LBMessageBoxLogo.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                MessageBox.Show("Warning : System is having trouble connecting to the SQL servers .", "Message", MessageBoxButtons.OK);
            }
            else if (ApplicationSetting.Default.ConnectionState == true)
            {
                ApplicationSetting.Default.Host = hosttext.Text;
                ApplicationSetting.Default.Port = porttext.Text;
                ApplicationSetting.Default.Username = usernametext.Text;
                ApplicationSetting.Default.Password = passwordtext.Text;
                ApplicationSetting.Default.Database = databasenametext.Text;
                ApplicationSetting.Default.DataBaseAddress = ConnSr;
                ApplicationSetting.Default.Save();
                this.LBMessageBox.Text = "Database connect success";
                this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                this.LBMessageBoxLogo.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
                MessageBox.Show("Database connect success .", "Message", MessageBoxButtons.OK);
            }
        }

        private void recall_data()
        {
            hosttext.Text = ApplicationSetting.Default.Host;
            porttext.Text = ApplicationSetting.Default.Port;
            usernametext.Text = ApplicationSetting.Default.Username;
            passwordtext.Text = ApplicationSetting.Default.Password;
            databasenametext.Text = ApplicationSetting.Default.Database;
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            ConvertType ConvertType = new ConvertType();
            string ConnSr = ConvertType.ConnString(hosttext.Text, porttext.Text, usernametext.Text, passwordtext.Text, databasenametext.Text);
            bool Connect = SQLConnect.Instance.TestConnectDataBaseAddress(ConnSr);
            if (Connect == false)
            {

                this.LBMessageBox.Text = "Warning : System is having trouble connecting to the SQL servers .";
                this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                this.LBMessageBoxLogo.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
            }
            else if (Connect == true)
            {
                this.LBMessageBox.Text = "Database connect success";
                this.LBMessageBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                this.LBMessageBoxLogo.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
            }
        }

        private void Exitbu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
