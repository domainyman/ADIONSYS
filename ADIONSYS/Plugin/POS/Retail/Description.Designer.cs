namespace ADIONSYS.Plugin.POS.Retail
{
    partial class Description
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
            this.label1 = new System.Windows.Forms.Label();
            this.LBTop = new System.Windows.Forms.Label();
            this.textSN = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnImport = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.LBTop, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textSN, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(735, 415);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(23, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(689, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Content :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBTop
            // 
            this.LBTop.AutoSize = true;
            this.LBTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBTop.Image = global::ADIONSYS.Properties.Resources.icons8_detail_64;
            this.LBTop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LBTop.Location = new System.Drawing.Point(23, 23);
            this.LBTop.Margin = new System.Windows.Forms.Padding(3);
            this.LBTop.Name = "LBTop";
            this.LBTop.Size = new System.Drawing.Size(689, 34);
            this.LBTop.TabIndex = 0;
            this.LBTop.Text = "Description :";
            this.LBTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textSN
            // 
            this.textSN.AcceptsReturn = true;
            this.textSN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textSN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSN.ForeColor = System.Drawing.Color.White;
            this.textSN.Location = new System.Drawing.Point(23, 133);
            this.textSN.Multiline = true;
            this.textSN.Name = "textSN";
            this.textSN.PlaceholderText = "Enter Content Per Line.";
            this.textSN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textSN.Size = new System.Drawing.Size(689, 196);
            this.textSN.TabIndex = 2;
            this.textSN.WordWrap = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.BtnImport, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnCancel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(23, 349);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(689, 63);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // BtnImport
            // 
            this.BtnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            this.BtnImport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnImport.FlatAppearance.BorderSize = 0;
            this.BtnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnImport.Location = new System.Drawing.Point(592, 3);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(94, 57);
            this.BtnImport.TabIndex = 4;
            this.BtnImport.Text = "Import";
            this.BtnImport.UseVisualStyleBackColor = false;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCancel.FlatAppearance.BorderSize = 0;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Location = new System.Drawing.Point(492, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(94, 57);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            // 
            // Description
            // 
            this.AcceptButton = this.BtnImport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(735, 415);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Description";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Description";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label LBTop;
        private Label label1;
        private TextBox textSN;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnImport;
        private Button BtnCancel;
    }
}