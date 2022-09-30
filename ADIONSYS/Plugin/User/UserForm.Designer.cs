namespace ADIONSYS.Plugin.User
{
    partial class UserForm
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
            this.UserContainer = new System.Windows.Forms.SplitContainer();
            this.UserPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnAdduser = new System.Windows.Forms.Button();
            this.BtnPermission = new System.Windows.Forms.Button();
            this.BtnUserSetting = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TopLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserContainer)).BeginInit();
            this.UserContainer.Panel1.SuspendLayout();
            this.UserContainer.SuspendLayout();
            this.UserPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.Controls.Add(this.UserContainer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // UserContainer
            // 
            this.UserContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.UserContainer.IsSplitterFixed = true;
            this.UserContainer.Location = new System.Drawing.Point(3, 43);
            this.UserContainer.Name = "UserContainer";
            // 
            // UserContainer.Panel1
            // 
            this.UserContainer.Panel1.Controls.Add(this.UserPanel);
            this.UserContainer.Size = new System.Drawing.Size(794, 404);
            this.UserContainer.SplitterDistance = 120;
            this.UserContainer.SplitterWidth = 1;
            this.UserContainer.TabIndex = 1;
            // 
            // UserPanel
            // 
            this.UserPanel.AutoSize = true;
            this.UserPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.UserPanel.ColumnCount = 1;
            this.UserPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UserPanel.Controls.Add(this.BtnAdduser, 0, 0);
            this.UserPanel.Controls.Add(this.BtnPermission, 0, 1);
            this.UserPanel.Controls.Add(this.BtnUserSetting, 0, 2);
            this.UserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserPanel.Location = new System.Drawing.Point(0, 0);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.RowCount = 10;
            this.UserPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.UserPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.UserPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.UserPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.UserPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.UserPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.UserPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.UserPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.UserPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.UserPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.UserPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.UserPanel.Size = new System.Drawing.Size(120, 404);
            this.UserPanel.TabIndex = 3;
            // 
            // BtnAdduser
            // 
            this.BtnAdduser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnAdduser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAdduser.FlatAppearance.BorderSize = 0;
            this.BtnAdduser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdduser.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAdduser.ForeColor = System.Drawing.Color.White;
            this.BtnAdduser.Image = global::ADIONSYS.Properties.Resources.add_user_241;
            this.BtnAdduser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAdduser.Location = new System.Drawing.Point(3, 3);
            this.BtnAdduser.Name = "BtnAdduser";
            this.BtnAdduser.Size = new System.Drawing.Size(114, 34);
            this.BtnAdduser.TabIndex = 2;
            this.BtnAdduser.Tag = "Account";
            this.BtnAdduser.Text = "Account";
            this.BtnAdduser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAdduser.UseVisualStyleBackColor = true;
            this.BtnAdduser.Click += new System.EventHandler(this.BtnAdduser_Click);
            // 
            // BtnPermission
            // 
            this.BtnPermission.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPermission.FlatAppearance.BorderSize = 0;
            this.BtnPermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPermission.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnPermission.ForeColor = System.Drawing.Color.White;
            this.BtnPermission.Image = global::ADIONSYS.Properties.Resources.settings_4_241;
            this.BtnPermission.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPermission.Location = new System.Drawing.Point(3, 43);
            this.BtnPermission.Name = "BtnPermission";
            this.BtnPermission.Size = new System.Drawing.Size(114, 34);
            this.BtnPermission.TabIndex = 1;
            this.BtnPermission.Tag = "Permission";
            this.BtnPermission.Text = "Permission";
            this.BtnPermission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPermission.UseVisualStyleBackColor = true;
            this.BtnPermission.Click += new System.EventHandler(this.BtnPermission_Click);
            // 
            // BtnUserSetting
            // 
            this.BtnUserSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnUserSetting.FlatAppearance.BorderSize = 0;
            this.BtnUserSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUserSetting.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnUserSetting.ForeColor = System.Drawing.Color.White;
            this.BtnUserSetting.Image = global::ADIONSYS.Properties.Resources.administrator_24;
            this.BtnUserSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUserSetting.Location = new System.Drawing.Point(3, 83);
            this.BtnUserSetting.Name = "BtnUserSetting";
            this.BtnUserSetting.Size = new System.Drawing.Size(114, 34);
            this.BtnUserSetting.TabIndex = 3;
            this.BtnUserSetting.Tag = "User Setting";
            this.BtnUserSetting.Text = "User Setting";
            this.BtnUserSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUserSetting.UseVisualStyleBackColor = true;
            this.BtnUserSetting.Click += new System.EventHandler(this.BtnUserSetting_Click);
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
            this.TopLabel.Font = new System.Drawing.Font("Open Sans Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            this.TopLabel.Tag = "User";
            this.TopLabel.Text = "User";
            this.TopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TopLabel.Click += new System.EventHandler(this.TopLabel_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.UserContainer.Panel1.ResumeLayout(false);
            this.UserContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserContainer)).EndInit();
            this.UserContainer.ResumeLayout(false);
            this.UserPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private SplitContainer UserContainer;
        private Button BtnAdduser;
        private Button BtnPermission;
        private Button BtnUserSetting;
        private TableLayoutPanel tableLayoutPanel2;
        private Label TopLabel;
        private TableLayoutPanel UserPanel;
    }
}