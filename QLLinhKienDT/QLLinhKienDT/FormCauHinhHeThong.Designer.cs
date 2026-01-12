namespace QLLinhKienDT
{
    partial class FormCauHinhHeThong
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
            this.grpCaiDat = new System.Windows.Forms.GroupBox();
            this.lblVAT = new System.Windows.Forms.Label();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.lblTonMin = new System.Windows.Forms.Label();
            this.txtTonToiThieu = new System.Windows.Forms.TextBox();
            this.lblTonMax = new System.Windows.Forms.Label();
            this.txtTonToiDa = new System.Windows.Forms.TextBox();
            this.btnLuuCaiDat = new System.Windows.Forms.Button();
            this.grpCaiDat.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // grpCaiDat
            // 
            this.grpCaiDat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCaiDat.Controls.Add(this.btnLuuCaiDat);
            this.grpCaiDat.Controls.Add(this.txtTonToiDa);
            this.grpCaiDat.Controls.Add(this.lblTonMax);
            this.grpCaiDat.Controls.Add(this.txtTonToiThieu);
            this.grpCaiDat.Controls.Add(this.lblTonMin);
            this.grpCaiDat.Controls.Add(this.txtVAT);
            this.grpCaiDat.Controls.Add(this.lblVAT);
            this.grpCaiDat.Location = new System.Drawing.Point(10, 10);
            this.grpCaiDat.Name = "grpCaiDat";
            this.grpCaiDat.Size = new System.Drawing.Size(470, 150);
            this.grpCaiDat.TabIndex = 0;
            this.grpCaiDat.TabStop = false;
            this.grpCaiDat.Text = "Cài đặt thông số";
            
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.Location = new System.Drawing.Point(10, 30);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(54, 13);
            this.lblVAT.TabIndex = 0;
            this.lblVAT.Text = "VAT (%):";
            
            // 
            // txtVAT
            // 
            this.txtVAT.Location = new System.Drawing.Point(150, 25);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(150, 20);
            this.txtVAT.TabIndex = 1;
            
            // 
            // lblTonMin
            // 
            this.lblTonMin.AutoSize = true;
            this.lblTonMin.Location = new System.Drawing.Point(10, 60);
            this.lblTonMin.Name = "lblTonMin";
            this.lblTonMin.Size = new System.Drawing.Size(105, 13);
            this.lblTonMin.TabIndex = 2;
            this.lblTonMin.Text = "Tồn kho tối thiểu:";
            
            // 
            // txtTonToiThieu
            // 
            this.txtTonToiThieu.Location = new System.Drawing.Point(150, 55);
            this.txtTonToiThieu.Name = "txtTonToiThieu";
            this.txtTonToiThieu.Size = new System.Drawing.Size(150, 20);
            this.txtTonToiThieu.TabIndex = 3;
            
            // 
            // lblTonMax
            // 
            this.lblTonMax.AutoSize = true;
            this.lblTonMax.Location = new System.Drawing.Point(10, 90);
            this.lblTonMax.Name = "lblTonMax";
            this.lblTonMax.Size = new System.Drawing.Size(98, 13);
            this.lblTonMax.TabIndex = 4;
            this.lblTonMax.Text = "Tồn kho tối đa:";
            
            // 
            // txtTonToiDa
            // 
            this.txtTonToiDa.Location = new System.Drawing.Point(150, 85);
            this.txtTonToiDa.Name = "txtTonToiDa";
            this.txtTonToiDa.Size = new System.Drawing.Size(150, 20);
            this.txtTonToiDa.TabIndex = 5;
            
            // 
            // btnLuuCaiDat
            // 
            this.btnLuuCaiDat.Location = new System.Drawing.Point(330, 55);
            this.btnLuuCaiDat.Name = "btnLuuCaiDat";
            this.btnLuuCaiDat.Size = new System.Drawing.Size(100, 25);
            this.btnLuuCaiDat.TabIndex = 6;
            this.btnLuuCaiDat.Text = "Lưu cài đặt";
            this.btnLuuCaiDat.UseVisualStyleBackColor = true;
            this.btnLuuCaiDat.Click += new System.EventHandler(this.btnLuuCaiDat_Click);
            
            // 
            // FormCauHinhHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 200);
            this.Controls.Add(this.grpCaiDat);
            this.Name = "FormCauHinhHeThong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình hệ thống";
            this.Load += new System.EventHandler(this.FormCauHinhHeThong_Load);
            this.grpCaiDat.ResumeLayout(false);
            this.grpCaiDat.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpCaiDat;
        private System.Windows.Forms.Button btnLuuCaiDat;
        private System.Windows.Forms.TextBox txtTonToiDa;
        private System.Windows.Forms.Label lblTonMax;
        private System.Windows.Forms.TextBox txtTonToiThieu;
        private System.Windows.Forms.Label lblTonMin;
        private System.Windows.Forms.TextBox txtVAT;
        private System.Windows.Forms.Label lblVAT;
    }
}
