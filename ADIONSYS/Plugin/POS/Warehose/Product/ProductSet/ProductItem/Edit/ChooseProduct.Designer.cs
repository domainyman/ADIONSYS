namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.ProductItem.Edit
{
    partial class ChooseProduct
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
            this.CMBoxList = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LBCategory = new System.Windows.Forms.Label();
            this.LBtop = new System.Windows.Forms.Label();
            this.LBMessageBox = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnEnter = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
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
            this.CMBoxList.Location = new System.Drawing.Point(287, 97);
            this.CMBoxList.Name = "CMBoxList";
            this.CMBoxList.Size = new System.Drawing.Size(565, 26);
            this.CMBoxList.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.58621F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.4138F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.LBCategory, 1, 3);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(876, 259);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // LBCategory
            // 
            this.LBCategory.AutoSize = true;
            this.LBCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBCategory.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBCategory.ForeColor = System.Drawing.Color.White;
            this.LBCategory.Location = new System.Drawing.Point(25, 99);
            this.LBCategory.Margin = new System.Windows.Forms.Padding(5);
            this.LBCategory.Name = "LBCategory";
            this.LBCategory.Size = new System.Drawing.Size(254, 26);
            this.LBCategory.TabIndex = 1;
            this.LBCategory.Text = "Product  Name: ";
            this.LBCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBtop
            // 
            this.LBtop.AutoSize = true;
            this.LBtop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBtop.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBtop.ForeColor = System.Drawing.Color.White;
            this.LBtop.Image = global::ADIONSYS.Properties.Resources.icons8_edit_30;
            this.LBtop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LBtop.Location = new System.Drawing.Point(25, 26);
            this.LBtop.Margin = new System.Windows.Forms.Padding(5);
            this.LBtop.Name = "LBtop";
            this.LBtop.Size = new System.Drawing.Size(254, 30);
            this.LBtop.TabIndex = 7;
            this.LBtop.Text = "Edit Product Infomation";
            this.LBtop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.LBMessageBox.Size = new System.Drawing.Size(254, 77);
            this.LBMessageBox.TabIndex = 3;
            this.LBMessageBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.BtnEnter, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnCancel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(287, 133);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(565, 81);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // BtnEnter
            // 
            this.BtnEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            this.BtnEnter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnEnter.FlatAppearance.BorderSize = 0;
            this.BtnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnter.Font = new System.Drawing.Font("Open Sans Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnEnter.ForeColor = System.Drawing.Color.White;
            this.BtnEnter.Location = new System.Drawing.Point(285, 3);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(277, 75);
            this.BtnEnter.TabIndex = 0;
            this.BtnEnter.Text = "Edit";
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
            this.BtnCancel.Size = new System.Drawing.Size(276, 75);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // ChooseProduct
            // 
            this.AcceptButton = this.BtnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(876, 259);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChooseProduct";
            this.Opacity = 0.96D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditProduct";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox CMBoxList;
        private TableLayoutPanel tableLayoutPanel1;
        private Label LBCategory;
        private Label LBtop;
        private Label LBMessageBox;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnEnter;
        private Button BtnCancel;
    }
}