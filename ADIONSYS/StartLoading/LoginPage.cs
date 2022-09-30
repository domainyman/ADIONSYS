using ADIONSYS.ConvertFunction;
using ADIONSYS.Tool;
using System.Xml.Linq;

namespace ADIONSYS.StartLoading
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }


        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MiniSizebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void Topexitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            if (Usernametextbox.Text.Equals(string.Empty) || Passwordtextbox.Text.Equals(string.Empty))
            {
                Loglb.Text = "Please enter the username or password!";
            }
            else
            {
                if (Usernametextbox.Text.Equals(ApplicationSetting.Default.Admin_User) && Passwordtextbox.Text.Equals(ApplicationSetting.Default.Admain_Password))
                {
                    ApplicationSetting.Default.User = Usernametextbox.Text;
                    ApplicationSetting.Default.Location = "OFFLINE";
                    ApplicationSetting.Default.Save();
                    MainPage MainPage = new MainPage();
                    MainPage.Show();
                    //MessageBox.Show("Go to Admin Page", "Message", MessageBoxButtons.OK);
                    this.Close();
                }
                else if(CheckUserAccount()==true)
                {
                    ApplicationSetting.Default.User = Usernametextbox.Text;
                    ApplicationSetting.Default.Save();
                    MainPage MainPage = new MainPage();
                    MainPage.Show();
                    //MessageBox.Show("Go to Admin Page", "Message", MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    Loglb.Text = "Not a valid username or password!";
                }
            }
        }

        private bool CheckUserAccount()
        {
            try
            {
                if (SQLConnect.Instance.ConnectState() == true)
                {
                    string user = Usernametextbox.Text;
                    string password = Passwordtextbox.Text;
                    string data = ConvertType.GetTimeStamp();
                    List<string> result = SQLConnect.Instance.PgSQL_SELECTDataString("SELECT password FROM username.accounts WHERE username='" + user + "'");
                    if (password == result[0])
                    {
                        SQLConnect.Instance.PgSQL_Command("UPDATE username.accounts SET last_login ='" + data+ "' WHERE username ='" + user + "'");
                        string Location_result = SQLConnect.Instance.PgSQL_SELECTDataStringsinglel("SELECT storage_name FROM productstorage.storage WHERE storage_id = (SELECT location_id FROM username.accounts WHERE username='" + user + "')");
                        ApplicationSetting.Default.Location = Location_result;
                        ApplicationSetting.Default.Save();
                        return true;
                    }
                    else
                    {
                        Loglb.Text = "Not a valid username or password!";
                        return false;
                    }
                }
                else
                {
                    Loglb.Text = "Network Error!";
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageInfo MessageInfo = new MessageInfo(ex.Message);
                MessageInfo.ShowDialog();
                return false;
            }
        }

    }
}
