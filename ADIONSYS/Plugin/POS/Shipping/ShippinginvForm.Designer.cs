namespace ADIONSYS.Plugin.POS.Shipping
{
    partial class ShippinginvForm
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
            System.Windows.Forms.Button BtnTransport;
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BtnSetting = new System.Windows.Forms.Button();
            this.WarehoseContainer = new System.Windows.Forms.SplitContainer();
            this.SubLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TranpanelGroup = new System.Windows.Forms.Panel();
            this.ProductPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnOrderInquire = new System.Windows.Forms.Button();
            this.BtnManagement = new System.Windows.Forms.Button();
            this.ManagepanelGroup = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            BtnTransport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehoseContainer)).BeginInit();
            this.WarehoseContainer.Panel1.SuspendLayout();
            this.WarehoseContainer.Panel2.SuspendLayout();
            this.WarehoseContainer.SuspendLayout();
            this.SubLayoutPanel.SuspendLayout();
            this.TranpanelGroup.SuspendLayout();
            this.ProductPanel.SuspendLayout();
            this.ManagepanelGroup.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnTransport
            // 
            BtnTransport.Dock = System.Windows.Forms.DockStyle.Top;
            BtnTransport.FlatAppearance.BorderSize = 0;
            BtnTransport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BtnTransport.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BtnTransport.ForeColor = System.Drawing.Color.White;
            BtnTransport.Image = global::ADIONSYS.Properties.Resources.icons8_diversity_24;
            BtnTransport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            BtnTransport.Location = new System.Drawing.Point(4, 4);
            BtnTransport.Margin = new System.Windows.Forms.Padding(4);
            BtnTransport.Name = "BtnTransport";
            BtnTransport.Size = new System.Drawing.Size(113, 40);
            BtnTransport.TabIndex = 4;
            BtnTransport.Tag = "Product";
            BtnTransport.Text = "Transport ";
            BtnTransport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            BtnTransport.UseVisualStyleBackColor = true;
            BtnTransport.Click += new System.EventHandler(this.BtnTransport_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::ADIONSYS.Properties.Resources.ADION_Logo__white_;
            this.pictureBox2.Location = new System.Drawing.Point(130, 87);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(418, 275);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // BtnSetting
            // 
            this.BtnSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSetting.FlatAppearance.BorderSize = 0;
            this.BtnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSetting.ForeColor = System.Drawing.Color.White;
            this.BtnSetting.Location = new System.Drawing.Point(3, 3);
            this.BtnSetting.Name = "BtnSetting";
            this.BtnSetting.Size = new System.Drawing.Size(108, 34);
            this.BtnSetting.TabIndex = 6;
            this.BtnSetting.Tag = "Stock - In";
            this.BtnSetting.Text = "Setting";
            this.BtnSetting.UseVisualStyleBackColor = true;
            this.BtnSetting.Click += new System.EventHandler(this.BtnSetting_Click);
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
            this.WarehoseContainer.Size = new System.Drawing.Size(800, 450);
            this.WarehoseContainer.SplitterDistance = 120;
            this.WarehoseContainer.SplitterWidth = 1;
            this.WarehoseContainer.TabIndex = 1;
            // 
            // SubLayoutPanel
            // 
            this.SubLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SubLayoutPanel.Controls.Add(BtnTransport);
            this.SubLayoutPanel.Controls.Add(this.TranpanelGroup);
            this.SubLayoutPanel.Controls.Add(this.BtnManagement);
            this.SubLayoutPanel.Controls.Add(this.ManagepanelGroup);
            this.SubLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.SubLayoutPanel.Name = "SubLayoutPanel";
            this.SubLayoutPanel.Size = new System.Drawing.Size(120, 450);
            this.SubLayoutPanel.TabIndex = 0;
            // 
            // TranpanelGroup
            // 
            this.TranpanelGroup.Controls.Add(this.ProductPanel);
            this.TranpanelGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.TranpanelGroup.Location = new System.Drawing.Point(3, 51);
            this.TranpanelGroup.Name = "TranpanelGroup";
            this.TranpanelGroup.Size = new System.Drawing.Size(114, 40);
            this.TranpanelGroup.TabIndex = 5;
            // 
            // ProductPanel
            // 
            this.ProductPanel.AutoSize = true;
            this.ProductPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProductPanel.ColumnCount = 1;
            this.ProductPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductPanel.Controls.Add(this.BtnOrderInquire, 0, 0);
            this.ProductPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.ProductPanel.Location = new System.Drawing.Point(0, 0);
            this.ProductPanel.Name = "ProductPanel";
            this.ProductPanel.RowCount = 2;
            this.ProductPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ProductPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ProductPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ProductPanel.Size = new System.Drawing.Size(114, 40);
            this.ProductPanel.TabIndex = 0;
            // 
            // BtnOrderInquire
            // 
            this.BtnOrderInquire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOrderInquire.FlatAppearance.BorderSize = 0;
            this.BtnOrderInquire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOrderInquire.ForeColor = System.Drawing.Color.White;
            this.BtnOrderInquire.Location = new System.Drawing.Point(3, 3);
            this.BtnOrderInquire.Name = "BtnOrderInquire";
            this.BtnOrderInquire.Size = new System.Drawing.Size(108, 34);
            this.BtnOrderInquire.TabIndex = 6;
            this.BtnOrderInquire.Tag = "Product Inquire";
            this.BtnOrderInquire.Text = "Inquire";
            this.BtnOrderInquire.UseVisualStyleBackColor = true;
            this.BtnOrderInquire.Click += new System.EventHandler(this.BtnOrderInquire_Click);
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
            this.BtnManagement.Location = new System.Drawing.Point(4, 98);
            this.BtnManagement.Margin = new System.Windows.Forms.Padding(4);
            this.BtnManagement.Name = "BtnManagement";
            this.BtnManagement.Size = new System.Drawing.Size(113, 40);
            this.BtnManagement.TabIndex = 8;
            this.BtnManagement.Tag = "Storage";
            this.BtnManagement.Text = "Management";
            this.BtnManagement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnManagement.UseVisualStyleBackColor = true;
            this.BtnManagement.Click += new System.EventHandler(this.BtnManagement_Click);
            // 
            // ManagepanelGroup
            // 
            this.ManagepanelGroup.Controls.Add(this.tableLayoutPanel1);
            this.ManagepanelGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.ManagepanelGroup.Location = new System.Drawing.Point(3, 145);
            this.ManagepanelGroup.Name = "ManagepanelGroup";
            this.ManagepanelGroup.Size = new System.Drawing.Size(114, 40);
            this.ManagepanelGroup.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.BtnSetting, 0, 0);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(679, 450);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // ShippinginvForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.WarehoseContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShippinginvForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShippingForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.WarehoseContainer.Panel1.ResumeLayout(false);
            this.WarehoseContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WarehoseContainer)).EndInit();
            this.WarehoseContainer.ResumeLayout(false);
            this.SubLayoutPanel.ResumeLayout(false);
            this.TranpanelGroup.ResumeLayout(false);
            this.TranpanelGroup.PerformLayout();
            this.ProductPanel.ResumeLayout(false);
            this.ManagepanelGroup.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox2;
        private Button BtnShippingMothed;
        private SplitContainer WarehoseContainer;
        private FlowLayoutPanel SubLayoutPanel;
        private Button BtnShipping;
        private Panel TranpanelGroup;
        private TableLayoutPanel ProductPanel;
        private Button BtnOrderInquire;
        private Button BtnManagement;
        private Panel ManagepanelGroup;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
        private Button BtnTransport;
        private Button BtnSetting;
    }
}