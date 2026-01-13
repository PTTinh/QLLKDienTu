namespace QLLinhKienDT
{
    partial class frmBaoCaoSanPhamBanChay
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();
            this.btnTopProducts = new System.Windows.Forms.Button();
            this.btnByCategory = new System.Windows.Forms.Button();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlChart = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(200, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO SẢN PHẨM BÁN CHẠY";
            // 
            // dgvTopProducts
            // 
            this.dgvTopProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopProducts.Location = new System.Drawing.Point(30, 90);
            this.dgvTopProducts.Name = "dgvTopProducts";
            this.dgvTopProducts.RowHeadersWidth = 51;
            this.dgvTopProducts.RowTemplate.Height = 24;
            this.dgvTopProducts.Size = new System.Drawing.Size(630, 320);
            this.dgvTopProducts.TabIndex = 1;
            // 
            // btnTopProducts
            // 
            this.btnTopProducts.Location = new System.Drawing.Point(30, 430);
            this.btnTopProducts.Name = "btnTopProducts";
            this.btnTopProducts.Size = new System.Drawing.Size(140, 45);
            this.btnTopProducts.TabIndex = 2;
            this.btnTopProducts.Text = "Top 10 Sản phẩm";
            this.btnTopProducts.UseVisualStyleBackColor = true;
            this.btnTopProducts.Click += new System.EventHandler(this.btnTopProducts_Click);
            // 
            // btnByCategory
            // 
            this.btnByCategory.Location = new System.Drawing.Point(180, 430);
            this.btnByCategory.Name = "btnByCategory";
            this.btnByCategory.Size = new System.Drawing.Size(140, 45);
            this.btnByCategory.TabIndex = 2;
            this.btnByCategory.Text = "Theo danh mục";
            this.btnByCategory.UseVisualStyleBackColor = true;
            this.btnByCategory.Click += new System.EventHandler(this.btnByCategory_Click);
            // 
            // btnExportReport
            // 
            this.btnExportReport.Location = new System.Drawing.Point(330, 430);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(140, 45);
            this.btnExportReport.TabIndex = 2;
            this.btnExportReport.Text = "Xuất báo cáo";
            this.btnExportReport.UseVisualStyleBackColor = true;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(480, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 45);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlChart
            // 
            this.pnlChart.Location = new System.Drawing.Point(680, 90);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(350, 320);
            this.pnlChart.TabIndex = 3;
            // 
            // frmBaoCaoSanPhamBanChay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1050, 490);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExportReport);
            this.Controls.Add(this.btnByCategory);
            this.Controls.Add(this.btnTopProducts);
            this.Controls.Add(this.dgvTopProducts);
            this.Controls.Add(this.label1);
            this.Name = "frmBaoCaoSanPhamBanChay";
            this.Text = "Báo cáo sản phẩm bán chạy";
            this.Load += new System.EventHandler(this.frmBaoCaoSanPhamBanChay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTopProducts;
        private System.Windows.Forms.Button btnTopProducts;
        private System.Windows.Forms.Button btnByCategory;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlChart;
        internal System.Windows.Forms.DataVisualization.Charting.Chart chartTopProducts;
    }
}