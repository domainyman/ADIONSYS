namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.SupplierSet.Delete
{
    partial class DeleteSupplier
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
            this.LBMessageBox = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LBSupplier = new System.Windows.Forms.Label();
            this.LBtop = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnEnter = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.CMBoxList = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBMessageBox
            // 
            this.LBMessageBox.AutoSize = true;
            this.LBMessageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBMessageBox.ForeColor = System.Drawing.Color.White;
            this.LBMessageBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LBMessageBox.Location = new System.Drawing.Point(25, 135);
            this.LBMessageBox.Margin = new System.Windows.Forms.Padding(5);
            this.LBMessageBox.Name = "LBMessageBox";
            this.LBMessageBox.Size = new System.Drawing.Size(218, 77);
            this.LBMessageBox.TabIndex = 3;
            this.LBMessageBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LBMessageBox.Click += new System.EventHandler(this.LBMessageBox_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.69953F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.30047F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.LBSupplier, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.LBtop, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LBMessageBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.CMBoxList, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(866, 250);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // LBSupplier
            // 
            this.LBSupplier.AutoSize = true;
            this.LBSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBSupplier.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBSupplier.ForeColor = System.Drawing.Color.White;
            this.LBSupplier.Location = new System.Drawing.Point(25, 99);
            this.LBSupplier.Margin = new System.Windows.Forms.Padding(5);
            this.LBSupplier.Name = "LBSupplier";
            this.LBSupplier.Size = new System.Drawing.Size(218, 26);
            this.LBSupplier.TabIndex = 1;
            this.LBSupplier.Text = "Supplier  Name: ";
            this.LBSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBSupplier.Click += new System.EventHandler(this.LBSupplier_Click);
            // 
            // LBtop
            // 
            this.LBtop.AutoSize = true;
            this.LBtop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBtop.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBtop.ForeColor = System.Drawing.Color.White;
            this.LBtop.Image = global::ADIONSYS.Properties.Resources.icons8_reduce_64;
            this.LBtop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LBtop.Location = new System.Drawing.Point(25, 26);
            this.LBtop.Margin = new System.Windows.Forms.Padding(5);
            this.LBtop.Name = "LBtop";
            this.LBtop.Size = new System.Drawing.Size(218, 30);
            this.LBtop.TabIndex = 7;
            this.LBtop.Text = "Delete Supplier ";
            this.LBtop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LBtop.Click += new System.EventHandler(this.LBtop_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.BtnEnter, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnCancel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(251, 133);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(591, 81);
            this.tableLayoutPanel2.TabIndex = 2;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // BtnEnter
            // 
            this.BtnEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            this.BtnEnter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnEnter.FlatAppearance.BorderSize = 0;
            this.BtnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnter.Font = new System.Drawing.Font("Open Sans Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnEnter.ForeColor = System.Drawing.Color.White;
            this.BtnEnter.Location = new System.Drawing.Point(298, 3);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(290, 75);
            this.BtnEnter.TabIndex = 0;
            this.BtnEnter.Text = "Delete";
            this.BtnEnter.UseVisualStyleBackColor = false;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCancel.FlatAppearance.BorderSize = 0;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Open Sans Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(3, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(289, 75);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // CMBoxList
            // 
            this.CMBoxList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CMBoxList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CMBoxList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBoxList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMBoxList.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CMBoxList.ForeColor = System.Drawing.Color.White;
            this.CMBoxList.FormattingEnabled = true;
            this.CMBoxList.Location = new System.Drawing.Point(251, 97);
            this.CMBoxList.Name = "CMBoxList";
            this.CMBoxList.Size = new System.Drawing.Size(591, 26);
            this.CMBoxList.TabIndex = 8;
            this.CMBoxList.SelectedIndexChanged += new System.EventHandler(this.CMBoxList_SelectedIndexChanged);
            // 
            // DeleteSupplier
            // 
            this.AcceptButton = this.BtnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(866, 250);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeleteSupplier";
            this.Opacity = 0.96D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DeleteSupplier";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label LBMessageBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Label LBSupplier;
        private Label LBtop;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnEnter;
        private Button BtnCancel;
        private ComboBox CMBoxList;
    }
}