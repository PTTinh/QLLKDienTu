using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLLinhKienDT.Utils
{
    /// <summary>
    /// Lớp hỗ trợ áp dụng theme thống nhất cho các form
    /// </summary>
    public static class FormTheme
    {
        // Màu sắc thống nhất
        public static readonly Color BackgroundColor = Color.FromArgb(240, 240, 240);    // Xám nhạt
        public static readonly Color AccentColor = Color.FromArgb(70, 130, 180);         // Xanh dương
        public static readonly Color HeaderForeColor = SystemColors.HotTrack;            // Xanh đậm cho tiêu đề
        public static readonly Color PanelBackColor = Color.FromArgb(200, 230, 201);   // Xanh lá nhạt
        
        /// <summary>
        /// Áp dụng theme cho Form
        /// </summary>
        public static void ApplyTheme(Form form)
        {
            form.BackColor = BackgroundColor;
            form.AutoScaleMode = AutoScaleMode.Font;
            form.AutoScaleDimensions = new SizeF(8F, 16F);
            
            // Cho phép resize và maximize
            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.MaximizeBox = true;
            form.StartPosition = FormStartPosition.CenterScreen;
            
            // Áp dụng theme cho tất cả control con
            ApplyThemeToControls(form.Controls);
        }

        /// <summary>
        /// Áp dụng theme cho tất cả control trong collection
        /// </summary>
        private static void ApplyThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Áp dụng font chuẩn
                if (control.Font.Name != "Microsoft Sans Serif")
                {
                    control.Font = new Font("Microsoft Sans Serif", control.Font.Size);
                }

                // Nếu là Label title (20pt)
                if (control is Label label && label.Font.Size >= 18)
                {
                    label.ForeColor = HeaderForeColor;
                    label.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
                }

                // Nếu là Panel màu xanh lá (dashboard summary)
                if (control is Panel panel && panel.BackColor == Color.FromArgb(200, 230, 201))
                {
                    panel.BackColor = PanelBackColor;
                }

                // Đệ quy cho control con
                if (control.HasChildren)
                {
                    ApplyThemeToControls(control.Controls);
                }
            }
        }

        /// <summary>
        /// Cấu hình Anchor để support resize không bẻ layout
        /// </summary>
        public static void SetAnchorForFullResize(Control control)
        {
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        /// <summary>
        /// Cấu hình Anchor cho control bottom
        /// </summary>
        public static void SetAnchorForBottom(Control control)
        {
            control.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
    }
}
