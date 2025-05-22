namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Loai_hang
{
    partial class ThemLoaiHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemLoaiHang));
            this.cbNganhHang = new System.Windows.Forms.ComboBox();
            this.nganhHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyBanBanhKeo_DoAnDataSet1 = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet1();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLh = new System.Windows.Forms.TextBox();
            this.Huy = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMalh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nganhHangTableAdapter = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet1TableAdapters.NganhHangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.nganhHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbNganhHang
            // 
            this.cbNganhHang.DataSource = this.nganhHangBindingSource;
            this.cbNganhHang.DisplayMember = "TenNganhHang";
            this.cbNganhHang.FormattingEnabled = true;
            this.cbNganhHang.Location = new System.Drawing.Point(144, 106);
            this.cbNganhHang.Name = "cbNganhHang";
            this.cbNganhHang.Size = new System.Drawing.Size(153, 21);
            this.cbNganhHang.TabIndex = 117;
            this.cbNganhHang.ValueMember = "MaNganhHang";
            // 
            // nganhHangBindingSource
            // 
            this.nganhHangBindingSource.DataMember = "NganhHang";
            this.nganhHangBindingSource.DataSource = this.quanLyBanBanhKeo_DoAnDataSet1;
            // 
            // quanLyBanBanhKeo_DoAnDataSet1
            // 
            this.quanLyBanBanhKeo_DoAnDataSet1.DataSetName = "QuanLyBanBanhKeo_DoAnDataSet1";
            this.quanLyBanBanhKeo_DoAnDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 116;
            this.label3.Text = "Tên loại hàng";
            // 
            // txtLh
            // 
            this.txtLh.Location = new System.Drawing.Point(144, 68);
            this.txtLh.Name = "txtLh";
            this.txtLh.Size = new System.Drawing.Size(153, 20);
            this.txtLh.TabIndex = 115;
            // 
            // Huy
            // 
            this.Huy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Huy.ImageOptions.SvgImage")));
            this.Huy.Location = new System.Drawing.Point(197, 153);
            this.Huy.Name = "Huy";
            this.Huy.Size = new System.Drawing.Size(100, 45);
            this.Huy.TabIndex = 114;
            this.Huy.Text = "Hủy bỏ";
            this.Huy.Click += new System.EventHandler(this.Huy_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(42, 153);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 45);
            this.simpleButton1.TabIndex = 113;
            this.simpleButton1.Text = "Chấp nhận";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 112;
            this.label2.Text = "Mã loại hàng";
            // 
            // txtMalh
            // 
            this.txtMalh.Location = new System.Drawing.Point(144, 32);
            this.txtMalh.Name = "txtMalh";
            this.txtMalh.Size = new System.Drawing.Size(153, 20);
            this.txtMalh.TabIndex = 111;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 110;
            this.label1.Text = "Ngành hàng";
            // 
            // nganhHangTableAdapter
            // 
            this.nganhHangTableAdapter.ClearBeforeFill = true;
            // 
            // ThemLoaiHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 225);
            this.Controls.Add(this.cbNganhHang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLh);
            this.Controls.Add(this.Huy);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMalh);
            this.Controls.Add(this.label1);
            this.Name = "ThemLoaiHang";
            this.Text = "ThemLoaiHang";
            this.Load += new System.EventHandler(this.ThemLoaiHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nganhHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNganhHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLh;
        private DevExpress.XtraEditors.SimpleButton Huy;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMalh;
        private System.Windows.Forms.Label label1;
        private QuanLyBanBanhKeo_DoAnDataSet1 quanLyBanBanhKeo_DoAnDataSet1;
        private System.Windows.Forms.BindingSource nganhHangBindingSource;
        private QuanLyBanBanhKeo_DoAnDataSet1TableAdapters.NganhHangTableAdapter nganhHangTableAdapter;
    }
}