namespace ADIONSYS.Plugin.Setting
{
    partial class SettingForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SettingContainer = new System.Windows.Forms.SplitContainer();
            this.SettingPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnApplication = new System.Windows.Forms.Button();
            this.BtnDataBase = new System.Windows.Forms.Button();
            this.BtnPassword = new System.Windows.Forms.Button();
            this.BtnUpload = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TopLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingContainer)).BeginInit();
            this.SettingContainer.Panel1.SuspendLayout();
            this.SettingContainer.SuspendLayout();
            this.SettingPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.Controls.Add(this.SettingContainer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // SettingContainer
            // 
            this.SettingContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SettingContainer.IsSplitterFixed = true;
            this.SettingContainer.Location = new System.Drawing.Point(3, 43);
            this.SettingContainer.Name = "SettingContainer";
            // 
            // SettingContainer.Panel1
            // 
            this.SettingContainer.Panel1.Controls.Add(this.SettingPanel);
            this.SettingContainer.Size = new System.Drawing.Size(794, 404);
            this.SettingContainer.SplitterDistance = 120;
            this.SettingContainer.SplitterWidth = 1;
            this.SettingContainer.TabIndex = 1;
            // 
            // SettingPanel
            // 
            this.SettingPanel.AutoSize = true;
            this.SettingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.SettingPanel.ColumnCount = 1;
            this.SettingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SettingPanel.Controls.Add(this.BtnApplication, 0, 0);
            this.SettingPanel.Controls.Add(this.BtnDataBase, 0, 1);
            this.SettingPanel.Controls.Add(this.BtnPassword, 0, 2);
            this.SettingPanel.Controls.Add(this.BtnUpload, 0, 3);
            this.SettingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingPanel.Location = new System.Drawing.Point(0, 0);
            this.SettingPanel.Name = "SettingPanel";
            this.SettingPanel.RowCount = 10;
            this.SettingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.SettingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.SettingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.SettingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.SettingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.SettingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.SettingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.SettingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.SettingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.SettingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.SettingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SettingPanel.Size = new System.Drawing.Size(120, 404);
            this.SettingPanel.TabIndex = 3;
            // 
            // BtnApplication
            // 
            this.BtnApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnApplication.FlatAppearance.BorderSize = 0;
            this.BtnApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnApplication.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnApplication.ForeColor = System.Drawing.Color.White;
            this.BtnApplication.Image = global::ADIONSYS.Properties.Resources.support_24;
            this.BtnApplication.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnApplication.Location = new System.Drawing.Point(3, 3);
            this.BtnApplication.Name = "BtnApplication";
            this.BtnApplication.Size = new System.Drawing.Size(114, 34);
            this.BtnApplication.TabIndex = 2;
            this.BtnApplication.Tag = "Application";
            this.BtnApplication.Text = "Application";
            this.BtnApplication.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnApplication.UseVisualStyleBackColor = true;
            // 
            // BtnDataBase
            // 
            this.BtnDataBase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnDataBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDataBase.FlatAppearance.BorderSize = 0;
            this.BtnDataBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDataBase.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnDataBase.ForeColor = System.Drawing.Color.White;
            this.BtnDataBase.Image = global::ADIONSYS.Properties.Resources.database_24;
            this.BtnDataBase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDataBase.Location = new System.Drawing.Point(3, 43);
            this.BtnDataBase.Name = "BtnDataBase";
            this.BtnDataBase.Size = new System.Drawing.Size(114, 34);
            this.BtnDataBase.TabIndex = 1;
            this.BtnDataBase.Tag = "DataBase";
            this.BtnDataBase.Text = "DataBase";
            this.BtnDataBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDataBase.UseVisualStyleBackColor = true;
            this.BtnDataBase.Click += new System.EventHandler(this.BtnDataBase_Click);
            // 
            // BtnPassword
            // 
            this.BtnPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPassword.FlatAppearance.BorderSize = 0;
            this.BtnPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPassword.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnPassword.ForeColor = System.Drawing.Color.White;
            this.BtnPassword.Image = global::ADIONSYS.Properties.Resources.administrator_24;
            this.BtnPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPassword.Location = new System.Drawing.Point(3, 83);
            this.BtnPassword.Name = "BtnPassword";
            this.BtnPassword.Size = new System.Drawing.Size(114, 34);
            this.BtnPassword.TabIndex = 3;
            this.BtnPassword.Tag = "Password";
            this.BtnPassword.Text = "Password";
            this.BtnPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPassword.UseVisualStyleBackColor = true;
            this.BtnPassword.Click += new System.EventHandler(this.BtnPassword_Click);
            // 
            // BtnUpload
            // 
            this.BtnUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnUpload.FlatAppearance.BorderSize = 0;
            this.BtnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpload.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnUpload.ForeColor = System.Drawing.Color.White;
            this.BtnUpload.Image = global::ADIONSYS.Properties.Resources.data_transfer_download_24;
            this.BtnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUpload.Location = new System.Drawing.Point(3, 123);
            this.BtnUpload.Name = "BtnUpload";
            this.BtnUpload.Size = new System.Drawing.Size(114, 34);
            this.BtnUpload.TabIndex = 4;
            this.BtnUpload.Tag = "Upload";
            this.BtnUpload.Text = "Upload";
            this.BtnUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUpload.UseVisualStyleBackColor = true;
            this.BtnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.TopLabel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 34);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // TopLabel
            // 
            this.TopLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TopLabel.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TopLabel.ForeColor = System.Drawing.Color.White;
            this.TopLabel.Image = global::ADIONSYS.Properties.Resources.list_view_24;
            this.TopLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TopLabel.Location = new System.Drawing.Point(3, 3);
            this.TopLabel.Margin = new System.Windows.Forms.Padding(3);
            this.TopLabel.MaximumSize = new System.Drawing.Size(100, 27);
            this.TopLabel.MinimumSize = new System.Drawing.Size(110, 27);
            this.TopLabel.Name = "TopLabel";
            this.TopLabel.Padding = new System.Windows.Forms.Padding(2);
            this.TopLabel.Size = new System.Drawing.Size(110, 27);
            this.TopLabel.TabIndex = 0;
            this.TopLabel.Tag = "Setting";
            this.TopLabel.Text = "Setting";
            this.TopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TopLabel.Click += new System.EventHandler(this.TopLabel_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.SettingContainer.Panel1.ResumeLayout(false);
            this.SettingContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingContainer)).EndInit();
            this.SettingContainer.ResumeLayout(false);
            this.SettingPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label TopLabel;
        private SplitContainer SettingContainer;
        private Button BtnApplication;
        private Button BtnDataBase;
        private Button BtnPassword;
        private Button BtnUpload;
        private TableLayoutPanel SettingPanel;
        private TableLayoutPanel tableLayoutPanel2;
    }
}