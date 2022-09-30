using ADIONSYS.ConvertFunction;
using System.Xml.Linq;

namespace ADIONSYS.StartLoading
{
    public partial class SqlSetup : Form
    {
        public SqlSetup()
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
                MessageBox.Show("Database connect success", "Message", MessageBoxButtons.OK);
                this.Close();

            }

        }
        private void Offlinebu_Click(object sender, EventArgs e)
        {
            Task SQL = Task.Run(() => SQLConnect.Instance.PgSQL_Command("CREATE DATABASE adion"));

        }

        private void recall_data()
        {
            hosttext.Text = ApplicationSetting.Default.Host;
            porttext.Text = ApplicationSetting.Default.Port;
            usernametext.Text = ApplicationSetting.Default.Username;
            passwordtext.Text = ApplicationSetting.Default.Password;
            databasenametext.Text = ApplicationSetting.Default.Database;
        }

        private void Exitbu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SqlSetup_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
