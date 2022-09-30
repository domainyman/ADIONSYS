using ADIONSYS.Plugin.Setting.Password;
using ADIONSYS.Plugin.Setting.Upload;
using ADIONSYS.StartLoading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.Setting
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void TopLabel_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void CollapseMenu()
        {
            if (this.SettingContainer.SplitterDistance == 120)
            {
                this.SettingContainer.SplitterDistance = 40;
                foreach (Button meunButton in SettingPanel.Controls.OfType<Button>())
                {
                    meunButton.Text = String.Empty;
                    meunButton.ImageAlign = ContentAlignment.MiddleCenter;
                    meunButton.Padding = new Padding(0);
                    TopLabel.Text = String.Empty;
                }
            }
            else if (this.SettingContainer.SplitterDistance == 40)
            {
                this.SettingContainer.SplitterDistance = 120;
                foreach (Button meunButton in SettingPanel.Controls.OfType<Button>())
                {
                    meunButton.Text = meunButton.Tag.ToString();
                    meunButton.ImageAlign = ContentAlignment.MiddleLeft;
                    meunButton.TextAlign = ContentAlignment.MiddleRight;
                    meunButton.Padding = new Padding(0);
                    TopLabel.Text = TopLabel.Tag.ToString();
                }
            }
        }

        private void ShowForm(Form form)
        {
            form.TopLevel = false;
            this.SettingContainer.Panel2.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }

        private void BtnDataBase_Click(object sender, EventArgs e)
        {
            SettingDataBase SettingDataBase = new SettingDataBase();
            ShowForm(SettingDataBase);
        }

        private void BtnPassword_Click(object sender, EventArgs e)
        {
            SettingAdmin SettingAdmin = new SettingAdmin();
            ShowForm(SettingAdmin);
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            UploadForm UploadForm = new UploadForm();
            ShowForm(UploadForm);
        }
    }
}
