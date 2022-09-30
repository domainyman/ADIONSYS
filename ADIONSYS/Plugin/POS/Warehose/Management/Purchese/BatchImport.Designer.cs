namespace ADIONSYS.Plugin.POS.Warehose.Management.Purchese
{
    partial class BatchImport
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
            this.LBTop = new System.Windows.Forms.Label();
            this.textSN = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnImport = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LBMark = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.LBTop, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textSN, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.LBMark, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 455);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LBTop
            // 
            this.LBTop.AutoSize = true;
            this.LBTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBTop.Image = global::ADIONSYS.Properties.Resources.icons8_insert_49;
            this.LBTop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LBTop.Location = new System.Drawing.Point(3, 23);
            this.LBTop.Margin = new System.Windows.Forms.Padding(3);
            this.LBTop.Name = "LBTop";
            this.LBTop.Size = new System.Drawing.Size(294, 29);
            this.LBTop.TabIndex = 0;
            this.LBTop.Text = "Batch Import";
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
            this.textSN.Location = new System.Drawing.Point(3, 58);
            this.textSN.Multiline = true;
            this.textSN.Name = "textSN";
            this.textSN.PlaceholderText = "Enter One Serial Number Per Line.";
            this.textSN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textSN.Size = new System.Drawing.Size(294, 332);
            this.textSN.TabIndex = 1;
            this.textSN.WordWrap = false;
            this.textSN.TextChanged += new System.EventHandler(this.textSN_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.BtnImport, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnCancel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 416);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(294, 36);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // BtnImport
            // 
            this.BtnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BtnImport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnImport.FlatAppearance.BorderSize = 0;
            this.BtnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnImport.Location = new System.Drawing.Point(197, 3);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(94, 30);
            this.BtnImport.TabIndex = 4;
            this.BtnImport.Text = "Batch Import";
            this.BtnImport.UseVisualStyleBackColor = false;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCancel.FlatAppearance.BorderSize = 0;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Location = new System.Drawing.Point(97, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(94, 30);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LBMark
            // 
            this.LBMark.AutoSize = true;
            this.LBMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBMark.Font = new System.Drawing.Font("Open Sans", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBMark.Location = new System.Drawing.Point(3, 396);
            this.LBMark.Margin = new System.Windows.Forms.Padding(3);
            this.LBMark.Name = "LBMark";
            this.LBMark.Size = new System.Drawing.Size(294, 14);
            this.LBMark.TabIndex = 3;
            this.LBMark.Text = "Enter One Serial Number Per Line.";
            this.LBMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BatchImport
            // 
            this.AcceptButton = this.BtnImport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(300, 455);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BatchImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BatchImport";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label LBTop;
        private TextBox textSN;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnImport;
        private Button BtnCancel;
        private Label LBMark;
    }
}