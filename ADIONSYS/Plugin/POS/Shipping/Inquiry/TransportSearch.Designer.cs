namespace ADIONSYS.Plugin.POS.Shipping.Inquiry
{
    partial class TransportSearch
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
            this.LBProduct = new System.Windows.Forms.Label();
            this.textTransportNumber = new System.Windows.Forms.TextBox();
            this.LBstatus = new System.Windows.Forms.Label();
            this.CMBstatus = new System.Windows.Forms.ComboBox();
            this.ProductGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.LBrecord = new System.Windows.Forms.Label();
            this.LBTotal = new System.Windows.Forms.Label();
            this.LBMark = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGridView)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ProductGridView, 1, 5);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1038, 681);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(992, 39);
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
            this.label1.Text = "Transport Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.Controls.Add(this.LBProduct, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.textTransportNumber, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.LBstatus, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.CMBstatus, 4, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(23, 88);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(992, 51);
            this.tableLayoutPanel4.TabIndex = 4;
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
            this.LBProduct.Text = "Transport Search :";
            this.LBProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textTransportNumber
            // 
            this.textTransportNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textTransportNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTransportNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textTransportNumber.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textTransportNumber.ForeColor = System.Drawing.Color.White;
            this.textTransportNumber.Location = new System.Drawing.Point(155, 11);
            this.textTransportNumber.Margin = new System.Windows.Forms.Padding(5, 11, 5, 6);
            this.textTransportNumber.Name = "textTransportNumber";
            this.textTransportNumber.PlaceholderText = "Transport Number Or Invoice Number";
            this.textTransportNumber.Size = new System.Drawing.Size(286, 25);
            this.textTransportNumber.TabIndex = 1;
            this.textTransportNumber.TextChanged += new System.EventHandler(this.textTransportNumber_TextChanged);
            // 
            // LBstatus
            // 
            this.LBstatus.AutoSize = true;
            this.LBstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBstatus.Location = new System.Drawing.Point(551, 5);
            this.LBstatus.Margin = new System.Windows.Forms.Padding(5);
            this.LBstatus.Name = "LBstatus";
            this.LBstatus.Size = new System.Drawing.Size(90, 41);
            this.LBstatus.TabIndex = 2;
            this.LBstatus.Text = "Status : ";
            this.LBstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CMBstatus
            // 
            this.CMBstatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CMBstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CMBstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBstatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMBstatus.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CMBstatus.ForeColor = System.Drawing.Color.White;
            this.CMBstatus.FormattingEnabled = true;
            this.CMBstatus.Location = new System.Drawing.Point(649, 10);
            this.CMBstatus.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.CMBstatus.Name = "CMBstatus";
            this.CMBstatus.Size = new System.Drawing.Size(290, 26);
            this.CMBstatus.TabIndex = 74;
            this.CMBstatus.SelectedIndexChanged += new System.EventHandler(this.CMBClient_SelectedIndexChanged);
            // 
            // ProductGridView
            // 
            this.ProductGridView.AllowUserToAddRows = false;
            this.ProductGridView.AllowUserToDeleteRows = false;
            this.ProductGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(89)))), ((int)(((byte)(115)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(135)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.ProductGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ProductGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(64)))), ((int)(((byte)(79)))));
            this.ProductGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.ProductGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(64)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(64)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ProductGridView.ColumnHeadersHeight = 45;
            this.ProductGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(75)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(135)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.ProductGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ProductGridView.EnableHeadersVisualStyles = false;
            this.ProductGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.ProductGridView.Location = new System.Drawing.Point(23, 173);
            this.ProductGridView.MultiSelect = false;
            this.ProductGridView.Name = "ProductGridView";
            this.ProductGridView.ReadOnly = true;
            this.ProductGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(120)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(120)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ProductGridView.RowHeadersVisible = false;
            this.ProductGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ProductGridView.RowTemplate.Height = 25;
            this.ProductGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductGridView.Size = new System.Drawing.Size(992, 408);
            this.ProductGridView.StandardTab = true;
            this.ProductGridView.TabIndex = 5;
            this.ProductGridView.VirtualMode = true;
            this.ProductGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ProductGridView_CellMouseClick);
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
            this.tableLayoutPanel5.Location = new System.Drawing.Point(23, 587);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(992, 34);
            this.tableLayoutPanel5.TabIndex = 6;
            // 
            // LBrecord
            // 
            this.LBrecord.AutoSize = true;
            this.LBrecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBrecord.Location = new System.Drawing.Point(153, 3);
            this.LBrecord.Margin = new System.Windows.Forms.Padding(3);
            this.LBrecord.Name = "LBrecord";
            this.LBrecord.Size = new System.Drawing.Size(686, 28);
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
            this.LBMark.Size = new System.Drawing.Size(992, 22);
            this.LBMark.TabIndex = 7;
            this.LBMark.Text = "Click To Select";
            // 
            // TransportSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 681);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TransportSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TransportSearch";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGridView)).EndInit();
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
        private TextBox textTransportNumber;
        private DataGridView ProductGridView;
        private TableLayoutPanel tableLayoutPanel5;
        private Label LBrecord;
        private Label LBTotal;
        private Label LBMark;
        private Label LBstatus;
        private ComboBox CMBstatus;
    }
}