using ADIONSYS.Plugin.POS.Warehose.Product;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductInquire;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet;
using ADIONSYS.Plugin.POS.Warehose.Management.Purchese;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using ADIONSYS.Plugin.POS.Warehose.Storage.Transfer;
using ADIONSYS.Plugin.POS.Warehose.Storage.Initialize;
using ADIONSYS.Plugin.POS.Warehose.Storage.Situation;
using ADIONSYS.Plugin.POS.Warehose.Storage.Record;

namespace ADIONSYS.Plugin.POS.Warehose
{
    public partial class WarehoseForm : Form
    {
        public WarehoseForm()
        {
            InitializeComponent();
            Hidesubmaun();
        }

        private void ShowForm(Form form)
        {
            form.TopLevel = false;
            WarehoseContainer.Panel2.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }
        private void BtnProduct_Click(object sender, EventArgs e)
        {
            if(ProductpanelGroup.Visible == false)
            {
                ShowPanel(ProductpanelGroup);
            }
            else if(ProductpanelGroup.Visible == true) 
            {
                HidePanel(ProductpanelGroup);
            }
        }

        private void Hidesubmaun()
        {
            ProductpanelGroup.Visible = false;
            StoragepanelGroup.Visible = false;
            ManagepanelGroup.Visible = false;
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

        private static void HidePanel(Panel SubMeun)
        {
            SubMeun.Visible = false;

        }

        private void Btnstorage_Click(object sender, EventArgs e)
        {
            if (StoragepanelGroup.Visible == false)
            {
                ShowPanel(StoragepanelGroup);
            }
            else if (StoragepanelGroup.Visible == true)
            {
                HidePanel(StoragepanelGroup);
            }
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            ProductSettingForm ProductSettingForm = new();
            ShowForm(ProductSettingForm);
        }

        private void BtnProductInquire_Click(object sender, EventArgs e)
        {
            ProductdetailsSearch ProductdetailsSearch = new();
            ShowForm(ProductdetailsSearch);
        }

        private void BtnManage_Click(object sender, EventArgs e)
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


        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            TransferForm TransferForm = new();
            ShowForm(TransferForm);
        }

        private void BtnWarehouseVOC_Click(object sender, EventArgs e)
        {
            PurcheseOrderForm PurcheseOrderForm = new();
            ShowForm(PurcheseOrderForm);
        }

        private void BtnTransfersituation_Click(object sender, EventArgs e)
        {

            SituationForm SituationForm = new();
            ShowForm(SituationForm);
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            RecordForm RecordForm = new();
            ShowForm(RecordForm);
        }
    }
}
