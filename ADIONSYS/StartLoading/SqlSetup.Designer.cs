namespace ADIONSYS.StartLoading
{
    partial class SqlSetup
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
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.Host = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.DataBaseName = new System.Windows.Forms.Label();
            this.hosttext = new System.Windows.Forms.TextBox();
            this.usernametext = new System.Windows.Forms.TextBox();
            this.passwordtext = new System.Windows.Forms.TextBox();
            this.databasenametext = new System.Windows.Forms.TextBox();
            this.porttext = new System.Windows.Forms.TextBox();
            this.buLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Exitbu = new System.Windows.Forms.Button();
            this.ConnectBu = new System.Windows.Forms.Button();
            this.Offlinebu = new System.Windows.Forms.Button();
            this.Tittle = new System.Windows.Forms.Label();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.buLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 3;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.77099F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.229F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.LayoutPanel.Controls.Add(this.Logo, 0, 0);
            this.LayoutPanel.Controls.Add(this.Host, 0, 1);
            this.LayoutPanel.Controls.Add(this.Port, 0, 2);
            this.LayoutPanel.Controls.Add(this.UserName, 0, 3);
            this.LayoutPanel.Controls.Add(this.Password, 0, 4);
            this.LayoutPanel.Controls.Add(this.DataBaseName, 0, 5);
            this.LayoutPanel.Controls.Add(this.hosttext, 1, 1);
            this.LayoutPanel.Controls.Add(this.usernametext, 1, 3);
            this.LayoutPanel.Controls.Add(this.passwordtext, 1, 4);
            this.LayoutPanel.Controls.Add(this.databasenametext, 1, 5);
            this.LayoutPanel.Controls.Add(this.porttext, 1, 2);
            this.LayoutPanel.Controls.Add(this.buLayoutPanel, 1, 6);
            this.LayoutPanel.Controls.Add(this.Tittle, 1, 0);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.MaximumSize = new System.Drawing.Size(450, 450);
            this.LayoutPanel.MinimumSize = new System.Drawing.Size(450, 450);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 8;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.55471F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.40475F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.40894F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.40894F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.40894F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.40894F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.40475F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutPanel.Size = new System.Drawing.Size(450, 450);
            this.LayoutPanel.TabIndex = 0;
            // 
            // Logo
            // 
            this.Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Logo.Image = global::ADIONSYS.Properties.Resources.ADION_Logo__white_;
            this.Logo.Location = new System.Drawing.Point(3, 3);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(111, 78);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // Host
            // 
            this.Host.AutoSize = true;
            this.Host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Host.ForeColor = System.Drawing.Color.White;
            this.Host.Location = new System.Drawing.Point(3, 87);
            this.Host.Margin = new System.Windows.Forms.Padding(3);
            this.Host.Name = "Host";
            this.Host.Size = new System.Drawing.Size(111, 51);
            this.Host.TabIndex = 1;
            this.Host.Text = "Host : ";
            this.Host.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Port
            // 
            this.Port.AutoSize = true;
            this.Port.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Port.ForeColor = System.Drawing.Color.White;
            this.Port.Location = new System.Drawing.Point(3, 144);
            this.Port.Margin = new System.Windows.Forms.Padding(3);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(111, 51);
            this.Port.TabIndex = 2;
            this.Port.Text = "Port :";
            this.Port.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserName.ForeColor = System.Drawing.Color.White;
            this.UserName.Location = new System.Drawing.Point(3, 201);
            this.UserName.Margin = new System.Windows.Forms.Padding(3);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(111, 51);
            this.UserName.TabIndex = 3;
            this.UserName.Text = "UserName :";
            this.UserName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Password.ForeColor = System.Drawing.Color.White;
            this.Password.Location = new System.Drawing.Point(3, 258);
            this.Password.Margin = new System.Windows.Forms.Padding(3);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(111, 51);
            this.Password.TabIndex = 4;
            this.Password.Text = "Password :";
            this.Password.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DataBaseName
            // 
            this.DataBaseName.AutoSize = true;
            this.DataBaseName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataBaseName.ForeColor = System.Drawing.Color.White;
            this.DataBaseName.Location = new System.Drawing.Point(3, 315);
            this.DataBaseName.Margin = new System.Windows.Forms.Padding(3);
            this.DataBaseName.Name = "DataBaseName";
            this.DataBaseName.Size = new System.Drawing.Size(111, 51);
            this.DataBaseName.TabIndex = 5;
            this.DataBaseName.Text = "DataBaseName";
            this.DataBaseName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // hosttext
            // 
            this.hosttext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.hosttext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hosttext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hosttext.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hosttext.ForeColor = System.Drawing.Color.White;
            this.hosttext.Location = new System.Drawing.Point(120, 87);
            this.hosttext.Name = "hosttext";
            this.hosttext.Size = new System.Drawing.Size(270, 24);
            this.hosttext.TabIndex = 6;
            // 
            // usernametext
            // 
            this.usernametext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.usernametext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernametext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usernametext.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usernametext.ForeColor = System.Drawing.Color.White;
            this.usernametext.Location = new System.Drawing.Point(120, 201);
            this.usernametext.Name = "usernametext";
            this.usernametext.Size = new System.Drawing.Size(270, 24);
            this.usernametext.TabIndex = 8;
            // 
            // passwordtext
            // 
            this.passwordtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.passwordtext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordtext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordtext.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordtext.ForeColor = System.Drawing.Color.White;
            this.passwordtext.Location = new System.Drawing.Point(120, 258);
            this.passwordtext.Name = "passwordtext";
            this.passwordtext.Size = new System.Drawing.Size(270, 24);
            this.passwordtext.TabIndex = 9;
            this.passwordtext.UseSystemPasswordChar = true;
            // 
            // databasenametext
            // 
            this.databasenametext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.databasenametext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.databasenametext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databasenametext.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.databasenametext.ForeColor = System.Drawing.Color.White;
            this.databasenametext.Location = new System.Drawing.Point(120, 315);
            this.databasenametext.Name = "databasenametext";
            this.databasenametext.Size = new System.Drawing.Size(270, 24);
            this.databasenametext.TabIndex = 10;
            // 
            // porttext
            // 
            this.porttext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.porttext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porttext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porttext.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.porttext.ForeColor = System.Drawing.Color.White;
            this.porttext.Location = new System.Drawing.Point(120, 144);
            this.porttext.Name = "porttext";
            this.porttext.Size = new System.Drawing.Size(270, 24);
            this.porttext.TabIndex = 7;
            // 
            // buLayoutPanel
            // 
            this.buLayoutPanel.AutoSize = true;
            this.buLayoutPanel.ColumnCount = 3;
            this.buLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.buLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.buLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.buLayoutPanel.Controls.Add(this.Exitbu, 2, 0);
            this.buLayoutPanel.Controls.Add(this.ConnectBu, 1, 0);
            this.buLayoutPanel.Controls.Add(this.Offlinebu, 0, 0);
            this.buLayoutPanel.Location = new System.Drawing.Point(120, 372);
            this.buLayoutPanel.Name = "buLayoutPanel";
            this.buLayoutPanel.RowCount = 1;
            this.buLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buLayoutPanel.Size = new System.Drawing.Size(270, 51);
            this.buLayoutPanel.TabIndex = 11;
            // 
            // Exitbu
            // 
            this.Exitbu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Exitbu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Exitbu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.Exitbu.FlatAppearance.BorderSize = 0;
            this.Exitbu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exitbu.ForeColor = System.Drawing.Color.White;
            this.Exitbu.Location = new System.Drawing.Point(183, 3);
            this.Exitbu.Name = "Exitbu";
            this.Exitbu.Size = new System.Drawing.Size(84, 45);
            this.Exitbu.TabIndex = 1;
            this.Exitbu.Text = "Exit";
            this.Exitbu.UseVisualStyleBackColor = false;
            this.Exitbu.Click += new System.EventHandler(this.Exitbu_Click);
            // 
            // ConnectBu
            // 
            this.ConnectBu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectBu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            this.ConnectBu.FlatAppearance.BorderSize = 0;
            this.ConnectBu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectBu.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConnectBu.ForeColor = System.Drawing.Color.White;
            this.ConnectBu.Location = new System.Drawing.Point(93, 3);
            this.ConnectBu.Name = "ConnectBu";
            this.ConnectBu.Size = new System.Drawing.Size(84, 45);
            this.ConnectBu.TabIndex = 0;
            this.ConnectBu.Text = "Connect";
            this.ConnectBu.UseVisualStyleBackColor = false;
            this.ConnectBu.Click += new System.EventHandler(this.ConnectBu_Click);
            // 
            // Offlinebu
            // 
            this.Offlinebu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Offlinebu.AutoSize = true;
            this.Offlinebu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Offlinebu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Offlinebu.FlatAppearance.BorderSize = 0;
            this.Offlinebu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Offlinebu.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Offlinebu.Location = new System.Drawing.Point(3, 3);
            this.Offlinebu.Name = "Offlinebu";
            this.Offlinebu.Size = new System.Drawing.Size(84, 45);
            this.Offlinebu.TabIndex = 2;
            this.Offlinebu.Text = "Offline Mode";
            this.Offlinebu.UseVisualStyleBackColor = false;
            this.Offlinebu.Click += new System.EventHandler(this.Offlinebu_Click);
            // 
            // Tittle
            // 
            this.Tittle.AutoSize = true;
            this.Tittle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tittle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Tittle.ForeColor = System.Drawing.Color.White;
            this.Tittle.Location = new System.Drawing.Point(120, 0);
            this.Tittle.Name = "Tittle";
            this.Tittle.Size = new System.Drawing.Size(270, 84);
            this.Tittle.TabIndex = 12;
            this.Tittle.Text = "Warning : System is having trouble connecting to the SQL servers .\r\n";
            this.Tittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SqlSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.LayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(450, 450);
            this.MinimumSize = new System.Drawing.Size(450, 450);
            this.Name = "SqlSetup";
            this.Opacity = 0.96D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SqlSetup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SqlSetup_FormClosed);
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.buLayoutPanel.ResumeLayout(false);
            this.buLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel LayoutPanel;
        private PictureBox Logo;
        private Label Host;
        private Label Port;
        private Label UserName;
        private Label Password;
        private Label DataBaseName;
        private TextBox hosttext;
        private TextBox usernametext;
        private TextBox passwordtext;
        private TextBox databasenametext;
        private TextBox porttext;
        private TableLayoutPanel buLayoutPanel;
        private Button ConnectBu;
        private Button Exitbu;
        private Label Tittle;
        private Button Offlinebu;
    }
}