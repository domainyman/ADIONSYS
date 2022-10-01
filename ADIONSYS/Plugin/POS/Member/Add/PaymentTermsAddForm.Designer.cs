namespace ADIONSYS.Plugin.POS.Member.Add
{
    partial class PaymentTermsAddForm
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LBPaymentMethod = new System.Windows.Forms.Label();
            this.LBtop = new System.Windows.Forms.Label();
            this.LBMessageBox = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnEnter = new System.Windows.Forms.Button();
            this.textPayT = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCancel.FlatAppearance.BorderSize = 0;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Open Sans Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(3, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(147, 87);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.03968F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.96032F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Controls.Add(this.LBPaymentMethod, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.LBtop, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LBMessageBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.textPayT, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(612, 250);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // LBPaymentMethod
            // 
            this.LBPaymentMethod.AutoSize = true;
            this.LBPaymentMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBPaymentMethod.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBPaymentMethod.ForeColor = System.Drawing.Color.White;
            this.LBPaymentMethod.Location = new System.Drawing.Point(25, 112);
            this.LBPaymentMethod.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.LBPaymentMethod.Name = "LBPaymentMethod";
            this.LBPaymentMethod.Size = new System.Drawing.Size(247, 29);
            this.LBPaymentMethod.TabIndex = 1;
            this.LBPaymentMethod.Text = "Payment Terms : ";
            this.LBPaymentMethod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBtop
            // 
            this.LBtop.AutoSize = true;
            this.LBtop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBtop.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBtop.ForeColor = System.Drawing.Color.White;
            this.LBtop.Image = global::ADIONSYS.Properties.Resources.icons8_add_30;
            this.LBtop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LBtop.Location = new System.Drawing.Point(25, 30);
            this.LBtop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.LBtop.Name = "LBtop";
            this.LBtop.Size = new System.Drawing.Size(247, 33);
            this.LBtop.TabIndex = 7;
            this.LBtop.Text = "Create Payment Terms";
            this.LBtop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LBMessageBox
            // 
            this.LBMessageBox.AutoSize = true;
            this.LBMessageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBMessageBox.ForeColor = System.Drawing.Color.White;
            this.LBMessageBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LBMessageBox.Location = new System.Drawing.Point(25, 153);
            this.LBMessageBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.LBMessageBox.Name = "LBMessageBox";
            this.LBMessageBox.Size = new System.Drawing.Size(247, 87);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(280, 150);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(307, 93);
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
            this.BtnEnter.Location = new System.Drawing.Point(156, 3);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(148, 87);
            this.BtnEnter.TabIndex = 0;
            this.BtnEnter.Text = "Create";
            this.BtnEnter.UseVisualStyleBackColor = false;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // textPayT
            // 
            this.textPayT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textPayT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPayT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textPayT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textPayT.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textPayT.ForeColor = System.Drawing.Color.White;
            this.textPayT.Location = new System.Drawing.Point(280, 112);
            this.textPayT.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.textPayT.Name = "textPayT";
            this.textPayT.PlaceholderText = "Type";
            this.textPayT.Size = new System.Drawing.Size(307, 24);
            this.textPayT.TabIndex = 9;
            // 
            // PaymentTermsAddForm
            // 
            this.AcceptButton = this.BtnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(612, 250);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PaymentTermsAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PaymentTermsAddForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnCancel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label LBPaymentMethod;
        private Label LBtop;
        private Label LBMessageBox;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnEnter;
        private TextBox textPayT;
    }
}