using static System.Net.Mime.MediaTypeNames;
using System;
using System.Reflection;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.Loader;
using System.Xml;
using System.Collections;

namespace ADIONSYS.StartLoading
{
    public partial class Startup : Form
    {
        
        public Startup()
        {
            InitializeComponent();
            //Demo();
            Progressbar();
        }


        private void Demo()
        {
            TestDemo TestDemo = new TestDemo();
            TestDemo.CleanSetting();
        }
        private void Setup()
        {
            try
            {
                Task.Run(() => SQLConnect.Instance.StartupConnect());
                SQLConnect.Instance.StartupConnect().Wait();
                if (ApplicationSetting.Default.DataBaseAddress.Equals(string.Empty))
                {
                    CallSQLSetup();
                }
                else
                {
                    Task.Run(() => SQLConnect.Instance.CheckConnectDataBaseAddress(ApplicationSetting.Default.DataBaseAddress));
                    SQLConnect.Instance.CheckConnectDataBaseAddress(ApplicationSetting.Default.DataBaseAddress).Wait();
                    if (ApplicationSetting.Default.ConnectionState == false)
                    {
                        CallSQLSetup();
                    }
                    else if ((ApplicationSetting.Default.ConnectionState == true))
                    {
                        //MessageBox.Show("Database connect success to Loin Page .", "Message", MessageBoxButtons.OK);
                        CallLogin();
                    }
                }

            }
            catch
            {


            }
        }
        private void CallSQLSetup()
        {
            SqlSetup SqlSetup = new SqlSetup();
            SqlSetup.ShowDialog();
            if (ApplicationSetting.Default.ConnectionState == true)
            {
                CallLogin();
            }
        }

        private void CallLogin()
        {
            if (ApplicationSetting.Default.ConnectionState == true)
            {
                LoginPage LoginPage = new LoginPage();
                LoginPage.Show();
            }

        }

        private void Progressbar()
        {
            while (this.progressBar.Value < this.progressBar.Maximum)
            {
                this.progressBar.PerformStep();
            }
            if (this.progressBar.Value >= this.progressBar.Maximum)
            {
                Setup();
            }
        }

        private bool WindowCreate = true;

        protected override void OnActivated(EventArgs e)
        {
            if (WindowCreate)
            {
                base.Visible = false;
                WindowCreate = false;
            }
            base.OnActivated(e);
        }


    }
}
