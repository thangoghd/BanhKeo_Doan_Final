namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Nganh_hang
{
    partial class ThemNganhHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemNganhHang));
            this.Huy = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtManh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTennh = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Huy
            // 
            this.Huy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Huy.ImageOptions.SvgImage")));
            this.Huy.Location = new System.Drawing.Point(178, 102);
            this.Huy.Name = "Huy";
            this.Huy.Size = new System.Drawing.Size(100, 45);
            this.Huy.TabIndex = 110;
            this.Huy.Text = "Hủy bỏ";
            // 
            // btnThem
            // 
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Location = new System.Drawing.Point(33, 102);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 45);
            this.btnThem.TabIndex = 109;
            this.btnThem.Text = "Chấp nhận";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 108;
            this.label2.Text = "Mã ngành hàng";
            // 
            // txtManh
            // 
            this.txtManh.Enabled = false;
            this.txtManh.Location = new System.Drawing.Point(125, 27);
            this.txtManh.Name = "txtManh";
            this.txtManh.Size = new System.Drawing.Size(153, 20);
            this.txtManh.TabIndex = 107;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 112;
            this.label1.Text = "Tên ngành hàng";
            // 
            // txtTennh
            // 
            this.txtTennh.Location = new System.Drawing.Point(125, 59);
            this.txtTennh.Name = "txtTennh";
            this.txtTennh.Size = new System.Drawing.Size(153, 20);
            this.txtTennh.TabIndex = 111;
            // 
            // ThemNganhHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 159);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTennh);
            this.Controls.Add(this.Huy);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtManh);
            this.Name = "ThemNganhHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThemNganhHang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Huy;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtManh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTennh;
    }
}