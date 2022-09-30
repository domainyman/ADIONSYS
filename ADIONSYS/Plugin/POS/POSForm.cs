using ADIONSYS.Plugin.POS.Retail;
using ADIONSYS.Plugin.POS.Warehose;
using ADIONSYS.Plugin.POS.Warehose.Product;
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

namespace ADIONSYS.Plugin.POS
{
    public partial class POSForm : Form
    {
        public POSForm()
        {
            InitializeComponent();
        }

        private void ShowForm(Form form)
        {
            form.TopLevel = false;
            RetailContainer.Panel2.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }

        private void LBPos_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void CollapseMenu()
        {
            if (this.RetailContainer.SplitterDistance == 120)
            {
                this.RetailContainer.SplitterDistance = 40;
                foreach (Button meunButton in SettingPanel.Controls.OfType<Button>())
                {
                    meunButton.Text = String.Empty;
                    meunButton.ImageAlign = ContentAlignment.MiddleCenter;
                    meunButton.Padding = new Padding(0);
                    LBPos.Text = String.Empty;
                }
            }
            else if (this.RetailContainer.SplitterDistance == 40)
            {
                this.RetailContainer.SplitterDistance = 120;
                foreach (Button meunButton in SettingPanel.Controls.OfType<Button>())
                {
                    meunButton.Text = meunButton.Tag.ToString();
                    meunButton.ImageAlign = ContentAlignment.MiddleLeft;
                    meunButton.TextAlign = ContentAlignment.MiddleRight;
                    meunButton.Padding = new Padding(0);
                    LBPos.Text = LBPos.Tag.ToString();
                }
            }
        }

        private void hidemeun()
        {
            if (this.RetailContainer.SplitterDistance == 120)
            {
                this.RetailContainer.SplitterDistance = 40;
                foreach (Button meunButton in SettingPanel.Controls.OfType<Button>())
                {
                    meunButton.Text = String.Empty;
                    meunButton.ImageAlign = ContentAlignment.MiddleCenter;
                    meunButton.Padding = new Padding(0);
                    LBPos.Text = String.Empty;
                }
            }
        }

        private void BtnRetail_Click(object sender, EventArgs e)
        {
            hidemeun();
            RetailForm RetailForm = new RetailForm();
            ShowForm(RetailForm);

        }

        private void BtnWarehose_Click(object sender, EventArgs e)
        {
            hidemeun();
            WarehoseForm WarehoseForm = new WarehoseForm();
            ShowForm(WarehoseForm);
        }
    }
    
}
