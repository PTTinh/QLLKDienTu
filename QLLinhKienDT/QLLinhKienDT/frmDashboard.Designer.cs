namespace QLLinhKienDT
{
    partial class frmDashboard
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.pnlTodayRevenue = new System.Windows.Forms.Panel();
            this.lblTodayRevenueLabel = new System.Windows.Forms.Label();
            this.lblTodayRevenue = new System.Windows.Forms.Label();
            this.pnlMonthRevenue = new System.Windows.Forms.Panel();
            this.lblMonthRevenueLabel = new System.Windows.Forms.Label();
            this.lblMonthRevenue = new System.Windows.Forms.Label();
            this.pnlTotalOrders = new System.Windows.Forms.Panel();
            this.lblTotalOrdersLabel = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.pnlTotalCustomers = new System.Windows.Forms.Panel();
            this.lblTotalCustomersLabel = new System.Windows.Forms.Label();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.lblAlertMessage = new System.Windows.Forms.Label();
            this.lblAlertCount = new System.Windows.Forms.Label();
            this.dgvLowStockAlerts = new System.Windows.Forms.DataGridView();
            this.pnlRevenueSummary = new System.Windows.Forms.Panel();
            this.pnlCategoryRevenue = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.pnlSummary.SuspendLayout();
            this.pnlTodayRevenue.SuspendLayout();
            this.pnlMonthRevenue.SuspendLayout();
            this.pnlTotalOrders.SuspendLayout();
            this.pnlTotalCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStockAlerts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(350, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRANG TỔNG QUAN";
            // 
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.pnlTodayRevenue);
            this.pnlSummary.Controls.Add(this.pnlMonthRevenue);
            this.pnlSummary.Controls.Add(this.pnlTotalOrders);
            this.pnlSummary.Controls.Add(this.pnlTotalCustomers);
            this.pnlSummary.Location = new System.Drawing.Point(20, 60);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(1010, 100);
            this.pnlSummary.TabIndex = 1;
            // 
            // pnlTodayRevenue
            // 
            this.pnlTodayRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.pnlTodayRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTodayRevenue.Controls.Add(this.lblTodayRevenueLabel);
            this.pnlTodayRevenue.Controls.Add(this.lblTodayRevenue);
            this.pnlTodayRevenue.Location = new System.Drawing.Point(10, 5);
            this.pnlTodayRevenue.Name = "pnlTodayRevenue";
            this.pnlTodayRevenue.Size = new System.Drawing.Size(230, 85);
            this.pnlTodayRevenue.TabIndex = 0;
            // 
            // lblTodayRevenueLabel
            // 
            this.lblTodayRevenueLabel.AutoSize = true;
            this.lblTodayRevenueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTodayRevenueLabel.Location = new System.Drawing.Point(10, 10);
            this.lblTodayRevenueLabel.Name = "lblTodayRevenueLabel";
            this.lblTodayRevenueLabel.Size = new System.Drawing.Size(171, 20);
            this.lblTodayRevenueLabel.TabIndex = 0;
            this.lblTodayRevenueLabel.Text = "Doanh thu hôm nay";
            // 
            // lblTodayRevenue
            // 
            this.lblTodayRevenue.AutoSize = true;
            this.lblTodayRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTodayRevenue.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTodayRevenue.Location = new System.Drawing.Point(10, 35);
            this.lblTodayRevenue.Name = "lblTodayRevenue";
            this.lblTodayRevenue.Size = new System.Drawing.Size(84, 29);
            this.lblTodayRevenue.TabIndex = 1;
            this.lblTodayRevenue.Text = "0.00 ₫";
            // 
            // pnlMonthRevenue
            // 
            this.pnlMonthRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.pnlMonthRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMonthRevenue.Controls.Add(this.lblMonthRevenueLabel);
            this.pnlMonthRevenue.Controls.Add(this.lblMonthRevenue);
            this.pnlMonthRevenue.Location = new System.Drawing.Point(260, 5);
            this.pnlMonthRevenue.Name = "pnlMonthRevenue";
            this.pnlMonthRevenue.Size = new System.Drawing.Size(230, 85);
            this.pnlMonthRevenue.TabIndex = 0;
            // 
            // lblMonthRevenueLabel
            // 
            this.lblMonthRevenueLabel.AutoSize = true;
            this.lblMonthRevenueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblMonthRevenueLabel.Location = new System.Drawing.Point(10, 10);
            this.lblMonthRevenueLabel.Name = "lblMonthRevenueLabel";
            this.lblMonthRevenueLabel.Size = new System.Drawing.Size(182, 20);
            this.lblMonthRevenueLabel.TabIndex = 0;
            this.lblMonthRevenueLabel.Text = "Doanh thu tháng này";
            // 
            // lblMonthRevenue
            // 
            this.lblMonthRevenue.AutoSize = true;
            this.lblMonthRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblMonthRevenue.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblMonthRevenue.Location = new System.Drawing.Point(10, 35);
            this.lblMonthRevenue.Name = "lblMonthRevenue";
            this.lblMonthRevenue.Size = new System.Drawing.Size(84, 29);
            this.lblMonthRevenue.TabIndex = 1;
            this.lblMonthRevenue.Text = "0.00 ₫";
            // 
            // pnlTotalOrders
            // 
            this.pnlTotalOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.pnlTotalOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotalOrders.Controls.Add(this.lblTotalOrdersLabel);
            this.pnlTotalOrders.Controls.Add(this.lblTotalOrders);
            this.pnlTotalOrders.Location = new System.Drawing.Point(510, 5);
            this.pnlTotalOrders.Name = "pnlTotalOrders";
            this.pnlTotalOrders.Size = new System.Drawing.Size(230, 85);
            this.pnlTotalOrders.TabIndex = 0;
            // 
            // lblTotalOrdersLabel
            // 
            this.lblTotalOrdersLabel.AutoSize = true;
            this.lblTotalOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrdersLabel.Location = new System.Drawing.Point(10, 10);
            this.lblTotalOrdersLabel.Name = "lblTotalOrdersLabel";
            this.lblTotalOrdersLabel.Size = new System.Drawing.Size(132, 20);
            this.lblTotalOrdersLabel.TabIndex = 0;
            this.lblTotalOrdersLabel.Text = "Tổng đơn hàng";
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalOrders.Location = new System.Drawing.Point(10, 35);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(27, 29);
            this.lblTotalOrders.TabIndex = 1;
            this.lblTotalOrders.Text = "0";
            // 
            // pnlTotalCustomers
            // 
            this.pnlTotalCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.pnlTotalCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotalCustomers.Controls.Add(this.lblTotalCustomersLabel);
            this.pnlTotalCustomers.Controls.Add(this.lblTotalCustomers);
            this.pnlTotalCustomers.Location = new System.Drawing.Point(760, 5);
            this.pnlTotalCustomers.Name = "pnlTotalCustomers";
            this.pnlTotalCustomers.Size = new System.Drawing.Size(230, 85);
            this.pnlTotalCustomers.TabIndex = 0;
            // 
            // lblTotalCustomersLabel
            // 
            this.lblTotalCustomersLabel.AutoSize = true;
            this.lblTotalCustomersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalCustomersLabel.Location = new System.Drawing.Point(10, 10);
            this.lblTotalCustomersLabel.Name = "lblTotalCustomersLabel";
            this.lblTotalCustomersLabel.Size = new System.Drawing.Size(151, 20);
            this.lblTotalCustomersLabel.TabIndex = 0;
            this.lblTotalCustomersLabel.Text = "Tổng khách hàng";
            // 
            // lblTotalCustomers
            // 
            this.lblTotalCustomers.AutoSize = true;
            this.lblTotalCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalCustomers.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTotalCustomers.Location = new System.Drawing.Point(10, 35);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(27, 29);
            this.lblTotalCustomers.TabIndex = 1;
            this.lblTotalCustomers.Text = "0";
            // 
            // lblAlertMessage
            // 
            this.lblAlertMessage.AutoSize = true;
            this.lblAlertMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblAlertMessage.ForeColor = System.Drawing.Color.Red;
            this.lblAlertMessage.Location = new System.Drawing.Point(20, 170);
            this.lblAlertMessage.Name = "lblAlertMessage";
            this.lblAlertMessage.Size = new System.Drawing.Size(257, 20);
            this.lblAlertMessage.TabIndex = 2;
            this.lblAlertMessage.Text = "⚠ Có sản phẩm tồn kho thấp!";
            // 
            // lblAlertCount
            // 
            this.lblAlertCount.Location = new System.Drawing.Point(350, 170);
            this.lblAlertCount.Name = "lblAlertCount";
            this.lblAlertCount.Size = new System.Drawing.Size(50, 20);
            this.lblAlertCount.TabIndex = 2;
            this.lblAlertCount.Text = "0";
            // 
            // dgvLowStockAlerts
            // 
            this.dgvLowStockAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowStockAlerts.Location = new System.Drawing.Point(20, 200);
            this.dgvLowStockAlerts.Name = "dgvLowStockAlerts";
            this.dgvLowStockAlerts.RowHeadersWidth = 51;
            this.dgvLowStockAlerts.RowTemplate.Height = 24;
            this.dgvLowStockAlerts.Size = new System.Drawing.Size(480, 220);
            this.dgvLowStockAlerts.TabIndex = 3;
            // 
            // pnlRevenueSummary
            // 
            this.pnlRevenueSummary.Location = new System.Drawing.Point(520, 200);
            this.pnlRevenueSummary.Name = "pnlRevenueSummary";
            this.pnlRevenueSummary.Size = new System.Drawing.Size(260, 220);
            this.pnlRevenueSummary.TabIndex = 4;
            // 
            // pnlCategoryRevenue
            // 
            this.pnlCategoryRevenue.Location = new System.Drawing.Point(800, 200);
            this.pnlCategoryRevenue.Name = "pnlCategoryRevenue";
            this.pnlCategoryRevenue.Size = new System.Drawing.Size(230, 220);
            this.pnlCategoryRevenue.TabIndex = 5;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(480, 440);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 45);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(610, 440);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 45);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 60000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1050, 500);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pnlCategoryRevenue);
            this.Controls.Add(this.pnlRevenueSummary);
            this.Controls.Add(this.dgvLowStockAlerts);
            this.Controls.Add(this.lblAlertCount);
            this.Controls.Add(this.lblAlertMessage);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.label1);
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.pnlSummary.ResumeLayout(false);
            this.pnlTodayRevenue.ResumeLayout(false);
            this.pnlTodayRevenue.PerformLayout();
            this.pnlMonthRevenue.ResumeLayout(false);
            this.pnlMonthRevenue.PerformLayout();
            this.pnlTotalOrders.ResumeLayout(false);
            this.pnlTotalOrders.PerformLayout();
            this.pnlTotalCustomers.ResumeLayout(false);
            this.pnlTotalCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStockAlerts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Panel pnlTodayRevenue;
        private System.Windows.Forms.Label lblTodayRevenueLabel;
        private System.Windows.Forms.Label lblTodayRevenue;
        private System.Windows.Forms.Panel pnlMonthRevenue;
        private System.Windows.Forms.Label lblMonthRevenueLabel;
        private System.Windows.Forms.Label lblMonthRevenue;
        private System.Windows.Forms.Panel pnlTotalOrders;
        private System.Windows.Forms.Label lblTotalOrdersLabel;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Panel pnlTotalCustomers;
        private System.Windows.Forms.Label lblTotalCustomersLabel;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.Label lblAlertMessage;
        private System.Windows.Forms.Label lblAlertCount;
        private System.Windows.Forms.DataGridView dgvLowStockAlerts;
        private System.Windows.Forms.Panel pnlRevenueSummary;
        private System.Windows.Forms.Panel pnlCategoryRevenue;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timerRefresh;
        internal System.Windows.Forms.DataVisualization.Charting.Chart chartRevenueSummary;
        internal System.Windows.Forms.DataVisualization.Charting.Chart chartCategoryRevenue;
    }
}