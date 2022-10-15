using ADIONSYS.Plugin.POS.Shipping.Inquiry;
using ADIONSYS.Plugin.POS.Shipping.Manager.Setting;
using ADIONSYS.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.POS.Shipping
{
    public partial class ShippinginvForm : Form
    {
        public ShippinginvForm()
        {
            InitializeComponent();
            Hidesubmaun();
        }

        private void BtnOrderInquire_Click(object sender, EventArgs e)
        {
            TransportSearch TransportSearch = new();
            ShowForm(TransportSearch);

        }

        private static void HidePanel(Panel SubMeun)
        {
            SubMeun.Visible = false;

        }



        private void Hidesubmaun()
        {
            TranpanelGroup.Visible = false;
            ManagepanelGroup.Visible = false;
        }

        private void ShowForm(Form form)
        {
            form.TopLevel = false;
            WarehoseContainer.Panel2.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }

        private void ShowPanel(Panel SubMeun)
        {
            SubMeun.Visible = true;
            foreach (Panel meun in SubLayoutPanel.Controls.OfType<Panel>())
            {
                if (meun == SubMeun)
                {
                    meun.Visible = true;
                }
                else
                {
                    meun.Visible = false;
                }
            }

        }

        private void BtnTransport_Click(object sender, EventArgs e)
        {
            if (TranpanelGroup.Visible == false)
            {
                ShowPanel(TranpanelGroup);
            }
            else if (TranpanelGroup.Visible == true)
            {
                HidePanel(TranpanelGroup);
            }
        }

        private void BtnManagement_Click(object sender, EventArgs e)
        {
            if (ManagepanelGroup.Visible == false)
            {
                ShowPanel(ManagepanelGroup);
            }
            else if (ManagepanelGroup.Visible == true)
            {
                HidePanel(ManagepanelGroup);
            }
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            SettingForm SettingForm = new();
            ShowForm(SettingForm);

        }
    }

}
