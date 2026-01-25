namespace QuanLyBanHang
{
    partial class frmTopSanPham
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoTheoDoanhThu = new System.Windows.Forms.RadioButton();
            this.rdoTheoSoLuong = new System.Windows.Forms.RadioButton();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.nudTop = new System.Windows.Forms.NumericUpDown();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chartTopSP = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvTopSanPham = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoTheoDoanhThu);
            this.panel1.Controls.Add(this.rdoTheoSoLuong);
            this.panel1.Controls.Add(this.btnXuatExcel);
            this.panel1.Controls.Add(this.btnXem);
            this.panel1.Controls.Add(this.nudTop);
            this.panel1.Controls.Add(this.dtpDenNgay);
            this.panel1.Controls.Add(this.dtpTuNgay);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 100);
            this.panel1.TabIndex = 0;
            // 
            // rdoTheoDoanhThu
            // 
            this.rdoTheoDoanhThu.AutoSize = true;
            this.rdoTheoDoanhThu.Location = new System.Drawing.Point(222, 70);
            this.rdoTheoDoanhThu.Name = "rdoTheoDoanhThu";
            this.rdoTheoDoanhThu.Size = new System.Drawing.Size(107, 17);
            this.rdoTheoDoanhThu.TabIndex = 10;
            this.rdoTheoDoanhThu.Text = "Theo doanh thu";
            this.rdoTheoDoanhThu.UseVisualStyleBackColor = true;
            this.rdoTheoDoanhThu.CheckedChanged += new System.EventHandler(this.rdoTheoDoanhThu_CheckedChanged);
            // 
            // rdoTheoSoLuong
            // 
            this.rdoTheoSoLuong.AutoSize = true;
            this.rdoTheoSoLuong.Checked = true;
            this.rdoTheoSoLuong.Location = new System.Drawing.Point(102, 70);
            this.rdoTheoSoLuong.Name = "rdoTheoSoLuong";
            this.rdoTheoSoLuong.Size = new System.Drawing.Size(102, 17);
            this.rdoTheoSoLuong.TabIndex = 9;
            this.rdoTheoSoLuong.TabStop = true;
            this.rdoTheoSoLuong.Text = "Theo số lượng";
            this.rdoTheoSoLuong.UseVisualStyleBackColor = true;
            this.rdoTheoSoLuong.CheckedChanged += new System.EventHandler(this.rdoTheoSoLuong_CheckedChanged);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(897, 48);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(90, 23);
            this.btnXuatExcel.TabIndex = 8;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(801, 48);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(90, 23);
            this.btnXem.TabIndex = 7;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // nudTop
            // 
            this.nudTop.Location = new System.Drawing.Point(549, 50);
            this.nudTop.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudTop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTop.Name = "nudTop";
            this.nudTop.Size = new System.Drawing.Size(70, 20);
            this.nudTop.TabIndex = 6;
            this.nudTop.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(314, 50);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(110, 20);
            this.dtpDenNgay.TabIndex = 5;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(102, 50);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(110, 20);
            this.dtpTuNgay.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hiển thị Top:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top Sản phẩm bán chạy";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 100);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chartTopSP);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvTopSanPham);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 500);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 1;
            // 
            // chartTopSP
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTopSP.ChartAreas.Add(chartArea1);
            this.chartTopSP.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartTopSP.Legends.Add(legend1);
            this.chartTopSP.Location = new System.Drawing.Point(0, 0);
            this.chartTopSP.Name = "chartTopSP";
            this.chartTopSP.Size = new System.Drawing.Size(1000, 280);
            this.chartTopSP.TabIndex = 0;
            this.chartTopSP.Text = "chart1";
            // 
            // dgvTopSanPham
            // 
            this.dgvTopSanPham.AllowUserToAddRows = false;
            this.dgvTopSanPham.AllowUserToDeleteRows = false;
            this.dgvTopSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopSanPham.Location = new System.Drawing.Point(0, 0);
            this.dgvTopSanPham.Name = "dgvTopSanPham";
            this.dgvTopSanPham.ReadOnly = true;
            this.dgvTopSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopSanPham.Size = new System.Drawing.Size(1000, 216);
            this.dgvTopSanPham.TabIndex = 0;
            // 
            // frmTopSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "frmTopSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Top Sản phẩm bán chạy";
            this.Load += new System.EventHandler(this.frmTopSanPham_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTopSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTop;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.RadioButton rdoTheoDoanhThu;
        private System.Windows.Forms.RadioButton rdoTheoSoLuong;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopSP;
        private System.Windows.Forms.DataGridView dgvTopSanPham;
    }
}
