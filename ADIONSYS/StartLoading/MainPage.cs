using ADIONSYS.Plugin.Logout;
using ADIONSYS.Plugin.POS;
using ADIONSYS.Plugin.Setting;
using ADIONSYS.Plugin.User;
using ADIONSYS.Tool;
using System.Runtime.InteropServices;

namespace ADIONSYS.StartLoading
{
    public partial class MainPage : Form
    {
        private int borderSize = 2;
        
        public MainPage()
        {
            InitializeComponent();
            FormSetting();
            Time();

        }

        private void FormSetting()
        {
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(46, 52, 64);
            this.LBuser.Image = Properties.Resources.manager_24;
            this.LBuser.Text = "User : " + ApplicationSetting.Default.User;
            this.LBLocation.Text = "Location : " + ApplicationSetting.Default.Location;
        }

        private void ShowForm(Form form)
        {
            form.TopLevel = false;
            MainPanel.Panel2.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }
        private void TopExitbtn_Click(object sender, EventArgs e)
        {
            ApplicationSetting.Default.User = String.Empty;
            ApplicationSetting.Default.Save();
            Application.Exit();
        }

        private void MaxSizebtn_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void MiniSizebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMeun_Click(object sender, EventArgs e)
        {
            if (this.MainPanel.SplitterDistance == 100)
            {
                this.MainPanel.SplitterDistance = 40;
                foreach (Button meunButton in MeunLayoutPanel.Controls.OfType<Button>())
                {
                    meunButton.Text = String.Empty;
                    meunButton.ImageAlign = ContentAlignment.MiddleCenter;
                    meunButton.Padding = new Padding(0);
                }
                foreach (Button subButton in SubLayoutPanel.Controls.OfType<Button>())
                {
                    subButton.Text = String.Empty;
                    subButton.ImageAlign = ContentAlignment.MiddleCenter;
                    subButton.Padding = new Padding(0);
                }
            }
            else if (this.MainPanel.SplitterDistance == 40)
            {
                this.MainPanel.SplitterDistance = 100;
                foreach (Button meunButton in MeunLayoutPanel.Controls.OfType<Button>())
                {
                    meunButton.Text = meunButton.Tag.ToString();
                    meunButton.ImageAlign = ContentAlignment.MiddleLeft;
                    meunButton.TextAlign = ContentAlignment.MiddleRight;
                    meunButton.Padding = new Padding(0);
                }
                foreach (Button subButton in SubLayoutPanel.Controls.OfType<Button>())
                {
                    subButton.Text = subButton.Tag.ToString();
                    subButton.ImageAlign = ContentAlignment.MiddleLeft;
                    subButton.TextAlign = ContentAlignment.MiddleRight;
                    subButton.Padding = new Padding(0);
                }
            }
        }

        private void Hidemeun()
        {
            if (this.MainPanel.SplitterDistance == 100)
            {
                this.MainPanel.SplitterDistance = 40;
                foreach (Button meunButton in MeunLayoutPanel.Controls.OfType<Button>())
                {
                    meunButton.Text = String.Empty;
                    meunButton.ImageAlign = ContentAlignment.MiddleCenter;
                    meunButton.Padding = new Padding(0);
                }
                foreach (Button subButton in SubLayoutPanel.Controls.OfType<Button>())
                {
                    subButton.Text = String.Empty;
                    subButton.ImageAlign = ContentAlignment.MiddleCenter;
                    subButton.Padding = new Padding(0);
                }
            }
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            Hidemeun();
            LogoutForm LogoutForm = new LogoutForm();
            ShowForm(LogoutForm);
        }

        private void BtnSetting_Click_1(object sender, EventArgs e)
        {
            Hidemeun();
            SettingForm SettingForm = new SettingForm();
            ShowForm(SettingForm);
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            Hidemeun();
            UserForm UserForm = new UserForm();
            ShowForm(UserForm);
        }

        private void BtnPlugin_Click(object sender, EventArgs e)
        {
            Hidemeun();
        }

        private Task ReConnect()
        {
            try
            {
                bool Connect = SQLConnect.Instance.TestConnectDataBaseAddress(ApplicationSetting.Default.DataBaseAddress);
                if (Connect == true)
                {
                    LBConState.Text = "Connected";
                    LBConState.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                    LBConState.Image = global::ADIONSYS.Properties.Resources.accept_database_24;
                }
                else if(Connect == false)
                {
                    LBConState.Text = "Disconnected";
                    LBConState.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                    LBConState.Image = global::ADIONSYS.Properties.Resources.delete_database_24;
                    NotifyIconDisConnect.Visible = true;
                }
                return Task.CompletedTask;

            }
            catch (Exception)
            {
                LBConState.Image = global::ADIONSYS.Properties.Resources.delete_database_24;
                LBConState.Text = "Disconnected";
                return Task.CompletedTask;
            }


        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void TimeConnect_Tick(object sender, EventArgs e)
        {
            ReConnect();    
        }

        private void Time()
        {
            TimeConnect.Enabled = true;
            TimeConnect.Start();
        }

        private void LBPOS_Click(object sender, EventArgs e)
        {
            Hidemeun();
            POSForm POSForm = new POSForm();
            ShowForm(POSForm);
        }
    }
}
