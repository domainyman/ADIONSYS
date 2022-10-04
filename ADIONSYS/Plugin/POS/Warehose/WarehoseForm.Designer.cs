namespace ADIONSYS.Plugin.POS.Warehose
{
    partial class WarehoseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WarehoseContainer = new System.Windows.Forms.SplitContainer();
            this.SubLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnProduct = new System.Windows.Forms.Button();
            this.ProductpanelGroup = new System.Windows.Forms.Panel();
            this.ProductPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnProductInquire = new System.Windows.Forms.Button();
            this.BtnSetting = new System.Windows.Forms.Button();
            this.BtnManagement = new System.Windows.Forms.Button();
            this.ManagepanelGroup = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnStockIn = new System.Windows.Forms.Button();
            this.Btnstorage = new System.Windows.Forms.Button();
            this.StoragepanelGroup = new System.Windows.Forms.Panel();
            this.StoragePanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnRecord = new System.Windows.Forms.Button();
            this.BtnTransfersituation = new System.Windows.Forms.Button();
            this.BtnTransfer = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.WarehoseContainer)).BeginInit();
            this.WarehoseContainer.Panel1.SuspendLayout();
            this.WarehoseContainer.Panel2.SuspendLayout();
            this.WarehoseContainer.SuspendLayout();
            this.SubLayoutPanel.SuspendLayout();
            this.ProductpanelGroup.SuspendLayout();
            this.ProductPanel.SuspendLayout();
            this.ManagepanelGroup.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.StoragepanelGroup.SuspendLayout();
            this.StoragePanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // WarehoseContainer
            // 
            this.WarehoseContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WarehoseContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.WarehoseContainer.IsSplitterFixed = true;
            this.WarehoseContainer.Location = new System.Drawing.Point(0, 0);
            this.WarehoseContainer.Name = "WarehoseContainer";
            // 
            // WarehoseContainer.Panel1
            // 
            this.WarehoseContainer.Panel1.Controls.Add(this.SubLayoutPanel);
            // 
            // WarehoseContainer.Panel2
            // 
            this.WarehoseContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.WarehoseContainer.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.WarehoseContainer.Size = new System.Drawing.Size(823, 547);
            this.WarehoseContainer.SplitterDistance = 120;
            this.WarehoseContainer.SplitterWidth = 1;
            this.WarehoseContainer.TabIndex = 0;
            // 
            // SubLayoutPanel
            // 
            this.SubLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SubLayoutPanel.Controls.Add(this.BtnProduct);
            this.SubLayoutPanel.Controls.Add(this.ProductpanelGroup);
            this.SubLayoutPanel.Controls.Add(this.BtnManagement);
            this.SubLayoutPanel.Controls.Add(this.ManagepanelGroup);
            this.SubLayoutPanel.Controls.Add(this.Btnstorage);
            this.SubLayoutPanel.Controls.Add(this.StoragepanelGroup);
            this.SubLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.SubLayoutPanel.Name = "SubLayoutPanel";
            this.SubLayoutPanel.Size = new System.Drawing.Size(120, 547);
            this.SubLayoutPanel.TabIndex = 0;
            // 
            // BtnProduct
            // 
            this.BtnProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnProduct.FlatAppearance.BorderSize = 0;
            this.BtnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProduct.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnProduct.ForeColor = System.Drawing.Color.White;
            this.BtnProduct.Image = global::ADIONSYS.Properties.Resources.package_24;
            this.BtnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnProduct.Location = new System.Drawing.Point(4, 4);
            this.BtnProduct.Margin = new System.Windows.Forms.Padding(4);
            this.BtnProduct.Name = "BtnProduct";
            this.BtnProduct.Size = new System.Drawing.Size(113, 40);
            this.BtnProduct.TabIndex = 4;
            this.BtnProduct.Tag = "Product";
            this.BtnProduct.Text = "Product";
            this.BtnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProduct.UseVisualStyleBackColor = true;
            this.BtnProduct.Click += new System.EventHandler(this.BtnProduct_Click);
            // 
            // ProductpanelGroup
            // 
            this.ProductpanelGroup.Controls.Add(this.ProductPanel);
            this.ProductpanelGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProductpanelGroup.Location = new System.Drawing.Point(3, 51);
            this.ProductpanelGroup.Name = "ProductpanelGroup";
            this.ProductpanelGroup.Size = new System.Drawing.Size(114, 80);
            this.ProductpanelGroup.TabIndex = 5;
            // 
            // ProductPanel
            // 
            this.ProductPanel.AutoSize = true;
            this.ProductPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProductPanel.ColumnCount = 1;
            this.ProductPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductPanel.Controls.Add(this.BtnProductInquire, 0, 0);
            this.ProductPanel.Controls.Add(this.BtnSetting, 0, 1);
            this.ProductPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.ProductPanel.Location = new System.Drawing.Point(0, 0);
            this.ProductPanel.Name = "ProductPanel";
            this.ProductPanel.RowCount = 2;
            this.ProductPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ProductPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ProductPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ProductPanel.Size = new System.Drawing.Size(114, 80);
            this.ProductPanel.TabIndex = 0;
            // 
            // BtnProductInquire
            // 
            this.BtnProductInquire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnProductInquire.FlatAppearance.BorderSize = 0;
            this.BtnProductInquire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProductInquire.ForeColor = System.Drawing.Color.White;
            this.BtnProductInquire.Location = new System.Drawing.Point(3, 3);
            this.BtnProductInquire.Name = "BtnProductInquire";
            this.BtnProductInquire.Size = new System.Drawing.Size(108, 34);
            this.BtnProductInquire.TabIndex = 6;
            this.BtnProductInquire.Tag = "Product Inquire";
            this.BtnProductInquire.Text = "Product Inquire";
            this.BtnProductInquire.UseVisualStyleBackColor = true;
            this.BtnProductInquire.Click += new System.EventHandler(this.BtnProductInquire_Click);
            // 
            // BtnSetting
            // 
            this.BtnSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSetting.FlatAppearance.BorderSize = 0;
            this.BtnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSetting.ForeColor = System.Drawing.Color.White;
            this.BtnSetting.Location = new System.Drawing.Point(3, 43);
            this.BtnSetting.Name = "BtnSetting";
            this.BtnSetting.Size = new System.Drawing.Size(108, 34);
            this.BtnSetting.TabIndex = 7;
            this.BtnSetting.Tag = "Setting";
            this.BtnSetting.Text = "Setting";
            this.BtnSetting.UseVisualStyleBackColor = true;
            this.BtnSetting.Click += new System.EventHandler(this.BtnSetting_Click);
            // 
            // BtnManagement
            // 
            this.BtnManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnManagement.FlatAppearance.BorderSize = 0;
            this.BtnManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnManagement.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnManagement.ForeColor = System.Drawing.Color.White;
            this.BtnManagement.Image = global::ADIONSYS.Properties.Resources.icons8_manage_64;
            this.BtnManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnManagement.Location = new System.Drawing.Point(4, 138);
            this.BtnManagement.Margin = new System.Windows.Forms.Padding(4);
            this.BtnManagement.Name = "BtnManagement";
            this.BtnManagement.Size = new System.Drawing.Size(113, 40);
            this.BtnManagement.TabIndex = 8;
            this.BtnManagement.Tag = "Storage";
            this.BtnManagement.Text = "Management";
            this.BtnManagement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnManagement.UseVisualStyleBackColor = true;
            this.BtnManagement.Click += new System.EventHandler(this.BtnManage_Click);
            // 
            // ManagepanelGroup
            // 
            this.ManagepanelGroup.Controls.Add(this.tableLayoutPanel1);
            this.ManagepanelGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.ManagepanelGroup.Location = new System.Drawing.Point(3, 185);
            this.ManagepanelGroup.Name = "ManagepanelGroup";
            this.ManagepanelGroup.Size = new System.Drawing.Size(114, 40);
            this.ManagepanelGroup.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.BtnStockIn, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(114, 40);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // BtnStockIn
            // 
            this.BtnStockIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnStockIn.FlatAppearance.BorderSize = 0;
            this.BtnStockIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStockIn.ForeColor = System.Drawing.Color.White;
            this.BtnStockIn.Location = new System.Drawing.Point(3, 3);
            this.BtnStockIn.Name = "BtnStockIn";
            this.BtnStockIn.Size = new System.Drawing.Size(108, 34);
            this.BtnStockIn.TabIndex = 6;
            this.BtnStockIn.Tag = "Stock - In";
            this.BtnStockIn.Text = "Warehousing";
            this.BtnStockIn.UseVisualStyleBackColor = true;
            this.BtnStockIn.Click += new System.EventHandler(this.BtnWarehouseVOC_Click);
            // 
            // Btnstorage
            // 
            this.Btnstorage.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btnstorage.FlatAppearance.BorderSize = 0;
            this.Btnstorage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnstorage.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btnstorage.ForeColor = System.Drawing.Color.White;
            this.Btnstorage.Image = global::ADIONSYS.Properties.Resources.icons8_transfer_24;
            this.Btnstorage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btnstorage.Location = new System.Drawing.Point(4, 232);
            this.Btnstorage.Margin = new System.Windows.Forms.Padding(4);
            this.Btnstorage.Name = "Btnstorage";
            this.Btnstorage.Size = new System.Drawing.Size(113, 40);
            this.Btnstorage.TabIndex = 6;
            this.Btnstorage.Tag = "Storage";
            this.Btnstorage.Text = "Storage";
            this.Btnstorage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btnstorage.UseVisualStyleBackColor = true;
            this.Btnstorage.Click += new System.EventHandler(this.Btnstorage_Click);
            // 
            // StoragepanelGroup
            // 
            this.StoragepanelGroup.Controls.Add(this.StoragePanel);
            this.StoragepanelGroup.Location = new System.Drawing.Point(3, 279);
            this.StoragepanelGroup.Name = "StoragepanelGroup";
            this.StoragepanelGroup.Size = new System.Drawing.Size(114, 120);
            this.StoragepanelGroup.TabIndex = 7;
            // 
            // StoragePanel
            // 
            this.StoragePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StoragePanel.ColumnCount = 1;
            this.StoragePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StoragePanel.Controls.Add(this.BtnRecord, 0, 2);
            this.StoragePanel.Controls.Add(this.BtnTransfersituation, 0, 1);
            this.StoragePanel.Controls.Add(this.BtnTransfer, 0, 0);
            this.StoragePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StoragePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.StoragePanel.Location = new System.Drawing.Point(0, 0);
            this.StoragePanel.Name = "StoragePanel";
            this.StoragePanel.RowCount = 3;
            this.StoragePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.StoragePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.StoragePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.StoragePanel.Size = new System.Drawing.Size(114, 120);
            this.StoragePanel.TabIndex = 1;
            // 
            // BtnRecord
            // 
            this.BtnRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRecord.FlatAppearance.BorderSize = 0;
            this.BtnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRecord.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRecord.ForeColor = System.Drawing.Color.White;
            this.BtnRecord.Location = new System.Drawing.Point(3, 83);
            this.BtnRecord.Name = "BtnRecord";
            this.BtnRecord.Size = new System.Drawing.Size(108, 34);
            this.BtnRecord.TabIndex = 8;
            this.BtnRecord.Tag = "Initialize";
            this.BtnRecord.Text = "Record";
            this.BtnRecord.UseVisualStyleBackColor = true;
            this.BtnRecord.Click += new System.EventHandler(this.BtnRecord_Click);
            // 
            // BtnTransfersituation
            // 
            this.BtnTransfersituation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnTransfersituation.FlatAppearance.BorderSize = 0;
            this.BtnTransfersituation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTransfersituation.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnTransfersituation.ForeColor = System.Drawing.Color.White;
            this.BtnTransfersituation.Location = new System.Drawing.Point(3, 43);
            this.BtnTransfersituation.Name = "BtnTransfersituation";
            this.BtnTransfersituation.Size = new System.Drawing.Size(108, 34);
            this.BtnTransfersituation.TabIndex = 7;
            this.BtnTransfersituation.Tag = "Initialize";
            this.BtnTransfersituation.Text = "Situation";
            this.BtnTransfersituation.UseVisualStyleBackColor = true;
            this.BtnTransfersituation.Click += new System.EventHandler(this.BtnTransfersituation_Click);
            // 
            // BtnTransfer
            // 
            this.BtnTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnTransfer.FlatAppearance.BorderSize = 0;
            this.BtnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTransfer.ForeColor = System.Drawing.Color.White;
            this.BtnTransfer.Location = new System.Drawing.Point(3, 3);
            this.BtnTransfer.Name = "BtnTransfer";
            this.BtnTransfer.Size = new System.Drawing.Size(108, 34);
            this.BtnTransfer.TabIndex = 0;
            this.BtnTransfer.Tag = "Transfer";
            this.BtnTransfer.Text = "Transfer";
            this.BtnTransfer.UseVisualStyleBackColor = true;
            this.BtnTransfer.Click += new System.EventHandler(this.BtnTransfer_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel3.Controls.Add(this.pictureBox2, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(702, 547);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::ADIONSYS.Properties.Resources.ADION_Logo__white_;
            this.pictureBox2.Location = new System.Drawing.Point(134, 105);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(432, 335);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // WarehoseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(823, 547);
            this.Controls.Add(this.WarehoseContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WarehoseForm";
            this.WarehoseContainer.Panel1.ResumeLayout(false);
            this.WarehoseContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WarehoseContainer)).EndInit();
            this.WarehoseContainer.ResumeLayout(false);
            this.SubLayoutPanel.ResumeLayout(false);
            this.ProductpanelGroup.ResumeLayout(false);
            this.ProductpanelGroup.PerformLayout();
            this.ProductPanel.ResumeLayout(false);
            this.ManagepanelGroup.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.StoragepanelGroup.ResumeLayout(false);
            this.StoragePanel.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private SplitContainer WarehoseContainer;
        private Button BtnProduct;
        private FlowLayoutPanel SubLayoutPanel;
        private Panel ProductpanelGroup;
        private TableLayoutPanel ProductPanel;
        private Button BtnProductInquire;
        private Button Btnstorage;
        private Button BtnSetting;
        private Panel StoragepanelGroup;
        private TableLayoutPanel StoragePanel;
        private Button BtnTransfer;
        private Panel ManagepanelGroup;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel3;
        private PictureBox pictureBox2;
        private Button BtnManagement;
        private Button BtnStockOut;
        private Button BtnStockIn;
        private Button BtnTransfersituation;
        private Button BtnRecord;
    }
}