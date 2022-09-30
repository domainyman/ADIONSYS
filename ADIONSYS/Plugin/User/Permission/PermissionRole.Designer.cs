namespace ADIONSYS.Plugin.User.Permission
{
    partial class PermissionRole
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
            this.LBPermassion = new System.Windows.Forms.Label();
            this.LBRole = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn = new System.Windows.Forms.Button();
            this.BtnPerAdd = new System.Windows.Forms.Button();
            this.BtnPerEdit = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.21941F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.48945F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.07173F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.219409F));
            this.tableLayoutPanel1.Controls.Add(this.LBPermassion, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.LBRole, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // LBPermassion
            // 
            this.LBPermassion.AutoSize = true;
            this.LBPermassion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBPermassion.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LBPermassion.ForeColor = System.Drawing.Color.White;
            this.LBPermassion.Location = new System.Drawing.Point(297, 25);
            this.LBPermassion.Margin = new System.Windows.Forms.Padding(5);
            this.LBPermassion.Name = "LBPermassion";
            this.LBPermassion.Size = new System.Drawing.Size(462, 30);
            this.LBPermassion.TabIndex = 0;
            this.LBPermassion.Text = "Permission Setting";
            this.LBPermassion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBPermassion.Click += new System.EventHandler(this.LBPermassion_Click);
            // 
            // LBRole
            // 
            this.LBRole.AutoSize = true;
            this.LBRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBRole.Font = new System.Drawing.Font("Open Sans Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LBRole.ForeColor = System.Drawing.Color.White;
            this.LBRole.Location = new System.Drawing.Point(38, 65);
            this.LBRole.Margin = new System.Windows.Forms.Padding(5);
            this.LBRole.Name = "LBRole";
            this.LBRole.Size = new System.Drawing.Size(249, 30);
            this.LBRole.TabIndex = 1;
            this.LBRole.Text = "Permission Role :";
            this.LBRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBRole.Click += new System.EventHandler(this.LBRole_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.Btn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnPerAdd, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnPerEdit, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(295, 63);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(466, 34);
            this.tableLayoutPanel2.TabIndex = 3;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // Btn
            // 
            this.Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn.FlatAppearance.BorderSize = 0;
            this.Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn.Font = new System.Drawing.Font("Open Sans Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn.ForeColor = System.Drawing.Color.White;
            this.Btn.Location = new System.Drawing.Point(3, 3);
            this.Btn.Name = "Btn";
            this.Btn.Size = new System.Drawing.Size(149, 28);
            this.Btn.TabIndex = 3;
            this.Btn.Text = "Delete";
            this.Btn.UseVisualStyleBackColor = false;
            // 
            // BtnPerAdd
            // 
            this.BtnPerAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            this.BtnPerAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnPerAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPerAdd.FlatAppearance.BorderSize = 0;
            this.BtnPerAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPerAdd.Font = new System.Drawing.Font("Open Sans Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnPerAdd.ForeColor = System.Drawing.Color.White;
            this.BtnPerAdd.Location = new System.Drawing.Point(313, 3);
            this.BtnPerAdd.Name = "BtnPerAdd";
            this.BtnPerAdd.Size = new System.Drawing.Size(150, 28);
            this.BtnPerAdd.TabIndex = 1;
            this.BtnPerAdd.Text = "Create";
            this.BtnPerAdd.UseVisualStyleBackColor = false;
            this.BtnPerAdd.Click += new System.EventHandler(this.BtnPerAdd_Click);
            // 
            // BtnPerEdit
            // 
            this.BtnPerEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.BtnPerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPerEdit.FlatAppearance.BorderSize = 0;
            this.BtnPerEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPerEdit.Font = new System.Drawing.Font("Open Sans Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnPerEdit.ForeColor = System.Drawing.Color.White;
            this.BtnPerEdit.Location = new System.Drawing.Point(158, 3);
            this.BtnPerEdit.Name = "BtnPerEdit";
            this.BtnPerEdit.Size = new System.Drawing.Size(149, 28);
            this.BtnPerEdit.TabIndex = 2;
            this.BtnPerEdit.Text = "Edit";
            this.BtnPerEdit.UseVisualStyleBackColor = false;
            this.BtnPerEdit.Click += new System.EventHandler(this.BtnPerEdit_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(295, 103);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(466, 34);
            this.tableLayoutPanel3.TabIndex = 4;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ADIONSYS.Properties.Resources.administrator_24;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(36, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(253, 34);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PermissionRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PermissionRole";
            this.Text = "PermissionRole";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label LBPermassion;
        private Label LBRole;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnPerEdit;
        private TableLayoutPanel tableLayoutPanel3;
        private PictureBox pictureBox1;
        private Button BtnPerAdd;
        private Button Btn;
    }
}