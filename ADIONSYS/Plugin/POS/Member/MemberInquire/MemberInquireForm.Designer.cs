namespace ADIONSYS.Plugin.POS.Member.MemberInquire
{
    partial class MemberInquireForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnAddMeth = new System.Windows.Forms.Button();
            this.LBProduct = new System.Windows.Forms.Label();
            this.textProduct = new System.Windows.Forms.TextBox();
            this.LBAdd = new System.Windows.Forms.Label();
            this.MemberGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.LBrecord = new System.Windows.Forms.Label();
            this.LBTotal = new System.Windows.Forms.Label();
            this.LBMark = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemberGridView)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.MemberGridView, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.LBMark, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1016, 617);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(23, 26);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(970, 39);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::ADIONSYS.Properties.Resources.icons8_detail_64;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Member Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.Controls.Add(this.BtnAddMeth, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.LBProduct, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.textProduct, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.LBAdd, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(23, 88);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(970, 51);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // BtnAddMeth
            // 
            this.BtnAddMeth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAddMeth.FlatAppearance.BorderSize = 0;
            this.BtnAddMeth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddMeth.Image = global::ADIONSYS.Properties.Resources.icons8_add_30;
            this.BtnAddMeth.Location = new System.Drawing.Point(783, 3);
            this.BtnAddMeth.Name = "BtnAddMeth";
            this.BtnAddMeth.Size = new System.Drawing.Size(34, 45);
            this.BtnAddMeth.TabIndex = 72;
            this.BtnAddMeth.UseVisualStyleBackColor = true;
            this.BtnAddMeth.Click += new System.EventHandler(this.BtnAddMeth_Click);
            // 
            // LBProduct
            // 
            this.LBProduct.AutoSize = true;
            this.LBProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBProduct.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBProduct.ForeColor = System.Drawing.Color.White;
            this.LBProduct.Image = global::ADIONSYS.Properties.Resources.icons8_search_64;
            this.LBProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LBProduct.Location = new System.Drawing.Point(2, 2);
            this.LBProduct.Margin = new System.Windows.Forms.Padding(2);
            this.LBProduct.Name = "LBProduct";
            this.LBProduct.Size = new System.Drawing.Size(146, 47);
            this.LBProduct.TabIndex = 0;
            this.LBProduct.Text = "Member Search :";
            this.LBProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textProduct
            // 
            this.textProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textProduct.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textProduct.ForeColor = System.Drawing.Color.White;
            this.textProduct.Location = new System.Drawing.Point(155, 11);
            this.textProduct.Margin = new System.Windows.Forms.Padding(5, 11, 5, 6);
            this.textProduct.Name = "textProduct";
            this.textProduct.PlaceholderText = "Member Name";
            this.textProduct.Size = new System.Drawing.Size(470, 25);
            this.textProduct.TabIndex = 1;
            this.textProduct.TextChanged += new System.EventHandler(this.textProduct_TextChanged);
            // 
            // LBAdd
            // 
            this.LBAdd.AutoSize = true;
            this.LBAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBAdd.Location = new System.Drawing.Point(635, 5);
            this.LBAdd.Margin = new System.Windows.Forms.Padding(5);
            this.LBAdd.Name = "LBAdd";
            this.LBAdd.Size = new System.Drawing.Size(140, 41);
            this.LBAdd.TabIndex = 2;
            this.LBAdd.Text = "Create New Member : ";
            this.LBAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MemberGridView
            // 
            this.MemberGridView.AllowUserToAddRows = false;
            this.MemberGridView.AllowUserToDeleteRows = false;
            this.MemberGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(89)))), ((int)(((byte)(115)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(135)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.MemberGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.MemberGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MemberGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(64)))), ((int)(((byte)(79)))));
            this.MemberGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MemberGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.MemberGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(64)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(64)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MemberGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.MemberGridView.ColumnHeadersHeight = 45;
            this.MemberGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(75)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(135)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MemberGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.MemberGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.MemberGridView.EnableHeadersVisualStyles = false;
            this.MemberGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.MemberGridView.Location = new System.Drawing.Point(23, 173);
            this.MemberGridView.MultiSelect = false;
            this.MemberGridView.Name = "MemberGridView";
            this.MemberGridView.ReadOnly = true;
            this.MemberGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(120)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(120)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MemberGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.MemberGridView.RowHeadersVisible = false;
            this.MemberGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.MemberGridView.RowTemplate.Height = 25;
            this.MemberGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MemberGridView.Size = new System.Drawing.Size(970, 344);
            this.MemberGridView.StandardTab = true;
            this.MemberGridView.TabIndex = 5;
            this.MemberGridView.VirtualMode = true;
            this.MemberGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MemberGridView_CellMouseClick);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel5.Controls.Add(this.LBrecord, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.LBTotal, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(23, 523);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(970, 34);
            this.tableLayoutPanel5.TabIndex = 6;
            // 
            // LBrecord
            // 
            this.LBrecord.AutoSize = true;
            this.LBrecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBrecord.Location = new System.Drawing.Point(153, 3);
            this.LBrecord.Margin = new System.Windows.Forms.Padding(3);
            this.LBrecord.Name = "LBrecord";
            this.LBrecord.Size = new System.Drawing.Size(664, 28);
            this.LBrecord.TabIndex = 2;
            this.LBrecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBTotal
            // 
            this.LBTotal.AutoSize = true;
            this.LBTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBTotal.ForeColor = System.Drawing.Color.White;
            this.LBTotal.Location = new System.Drawing.Point(3, 3);
            this.LBTotal.Margin = new System.Windows.Forms.Padding(3);
            this.LBTotal.Name = "LBTotal";
            this.LBTotal.Size = new System.Drawing.Size(144, 28);
            this.LBTotal.TabIndex = 0;
            this.LBTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LBMark
            // 
            this.LBMark.AutoSize = true;
            this.LBMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBMark.ForeColor = System.Drawing.Color.White;
            this.LBMark.Location = new System.Drawing.Point(23, 145);
            this.LBMark.Margin = new System.Windows.Forms.Padding(3);
            this.LBMark.Name = "LBMark";
            this.LBMark.Size = new System.Drawing.Size(970, 22);
            this.LBMark.TabIndex = 7;
            this.LBMark.Text = "Click To Select";
            // 
            // MemberInquireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1016, 617);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MemberInquireForm";
            this.Text = "MemberInquireForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemberGridView)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel4;
        private Label LBProduct;
        private TextBox textProduct;
        private DataGridView ProductGridView;
        private TableLayoutPanel tableLayoutPanel5;
        private Label LBrecord;
        private Label LBTotal;
        private Label LBMark;
        private DataGridView MemberGridView;
        private Label LBAdd;
        private Button BtnAddMeth;
    }
}