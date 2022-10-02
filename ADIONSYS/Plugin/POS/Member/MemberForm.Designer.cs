namespace ADIONSYS.Plugin.POS.Member
{
    partial class MemberForm
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.MemberPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnInquire = new System.Windows.Forms.Button();
            this.BtnMember = new System.Windows.Forms.Button();
            this.MemberpanelGroup = new System.Windows.Forms.Panel();
            this.SubLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MemberContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.MemberPanel.SuspendLayout();
            this.MemberpanelGroup.SuspendLayout();
            this.SubLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemberContainer)).BeginInit();
            this.MemberContainer.Panel1.SuspendLayout();
            this.MemberContainer.Panel2.SuspendLayout();
            this.MemberContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::ADIONSYS.Properties.Resources.ADION_Logo__white_;
            this.pictureBox2.Location = new System.Drawing.Point(130, 98);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(418, 312);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(679, 510);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(3, 3);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(108, 34);
            this.BtnAdd.TabIndex = 6;
            this.BtnAdd.Tag = "Product Inquire";
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnEdit.FlatAppearance.BorderSize = 0;
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.ForeColor = System.Drawing.Color.White;
            this.BtnEdit.Location = new System.Drawing.Point(3, 43);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(108, 34);
            this.BtnEdit.TabIndex = 7;
            this.BtnEdit.Tag = "Setting";
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = true;
            // 
            // MemberPanel
            // 
            this.MemberPanel.AutoSize = true;
            this.MemberPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MemberPanel.ColumnCount = 1;
            this.MemberPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MemberPanel.Controls.Add(this.BtnInquire, 0, 2);
            this.MemberPanel.Controls.Add(this.BtnAdd, 0, 0);
            this.MemberPanel.Controls.Add(this.BtnEdit, 0, 1);
            this.MemberPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.MemberPanel.Location = new System.Drawing.Point(0, 0);
            this.MemberPanel.Name = "MemberPanel";
            this.MemberPanel.RowCount = 3;
            this.MemberPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MemberPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MemberPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MemberPanel.Size = new System.Drawing.Size(114, 120);
            this.MemberPanel.TabIndex = 0;
            // 
            // BtnInquire
            // 
            this.BtnInquire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnInquire.FlatAppearance.BorderSize = 0;
            this.BtnInquire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInquire.ForeColor = System.Drawing.Color.White;
            this.BtnInquire.Location = new System.Drawing.Point(3, 83);
            this.BtnInquire.Name = "BtnInquire";
            this.BtnInquire.Size = new System.Drawing.Size(108, 34);
            this.BtnInquire.TabIndex = 8;
            this.BtnInquire.Tag = "Setting";
            this.BtnInquire.Text = "Inquire";
            this.BtnInquire.UseVisualStyleBackColor = true;
            this.BtnInquire.Click += new System.EventHandler(this.BtnInquire_Click);
            // 
            // BtnMember
            // 
            this.BtnMember.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnMember.FlatAppearance.BorderSize = 0;
            this.BtnMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMember.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnMember.ForeColor = System.Drawing.Color.White;
            this.BtnMember.Image = global::ADIONSYS.Properties.Resources.icons8_community_member_85;
            this.BtnMember.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMember.Location = new System.Drawing.Point(4, 5);
            this.BtnMember.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnMember.Name = "BtnMember";
            this.BtnMember.Size = new System.Drawing.Size(113, 45);
            this.BtnMember.TabIndex = 4;
            this.BtnMember.Tag = "Product";
            this.BtnMember.Text = "Member";
            this.BtnMember.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMember.UseVisualStyleBackColor = true;
            // 
            // MemberpanelGroup
            // 
            this.MemberpanelGroup.Controls.Add(this.MemberPanel);
            this.MemberpanelGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.MemberpanelGroup.Location = new System.Drawing.Point(3, 58);
            this.MemberpanelGroup.Name = "MemberpanelGroup";
            this.MemberpanelGroup.Size = new System.Drawing.Size(114, 120);
            this.MemberpanelGroup.TabIndex = 5;
            // 
            // SubLayoutPanel
            // 
            this.SubLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SubLayoutPanel.Controls.Add(this.BtnMember);
            this.SubLayoutPanel.Controls.Add(this.MemberpanelGroup);
            this.SubLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.SubLayoutPanel.Name = "SubLayoutPanel";
            this.SubLayoutPanel.Size = new System.Drawing.Size(120, 510);
            this.SubLayoutPanel.TabIndex = 0;
            // 
            // MemberContainer
            // 
            this.MemberContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MemberContainer.IsSplitterFixed = true;
            this.MemberContainer.Location = new System.Drawing.Point(0, 0);
            this.MemberContainer.Name = "MemberContainer";
            // 
            // MemberContainer.Panel1
            // 
            this.MemberContainer.Panel1.Controls.Add(this.SubLayoutPanel);
            // 
            // MemberContainer.Panel2
            // 
            this.MemberContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MemberContainer.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.MemberContainer.Size = new System.Drawing.Size(800, 510);
            this.MemberContainer.SplitterDistance = 120;
            this.MemberContainer.SplitterWidth = 1;
            this.MemberContainer.TabIndex = 1;
            // 
            // MemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.MemberContainer);
            this.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MemberForm";
            this.Text = "MemberForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.MemberPanel.ResumeLayout(false);
            this.MemberpanelGroup.ResumeLayout(false);
            this.MemberpanelGroup.PerformLayout();
            this.SubLayoutPanel.ResumeLayout(false);
            this.MemberContainer.Panel1.ResumeLayout(false);
            this.MemberContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MemberContainer)).EndInit();
            this.MemberContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox2;
        private TableLayoutPanel tableLayoutPanel3;
        private Button BtnAdd;
        private Button BtnEdit;
        private TableLayoutPanel ProductPanel;
        private Button BtnMember;
        private Panel ProductpanelGroup;
        private FlowLayoutPanel SubLayoutPanel;
        private SplitContainer WarehoseContainer;
        private Button BtnInquire;
        private TableLayoutPanel MemberPanel;
        private Panel MemberpanelGroup;
        private SplitContainer MemberContainer;
    }
}