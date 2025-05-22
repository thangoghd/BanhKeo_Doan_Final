namespace BanhKeo_Doan.Chuc_nang_danh_muc
{
    partial class SuaHangHoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuaHangHoa));
            this.label6 = new System.Windows.Forms.Label();
            this.txtMahh = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbdvt = new System.Windows.Forms.ComboBox();
            this.cbLh = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Huy = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenhh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.quanLyBanBanhKeo_DoAnDataSet5 = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet5();
            this.loaiHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loaiHangTableAdapter = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet5TableAdapters.LoaiHangTableAdapter();
            this.quanLyBanBanhKeo_DoAnDataSet6 = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet6();
            this.donViTinhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.donViTinhTableAdapter = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet6TableAdapters.DonViTinhTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donViTinhBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 154;
            this.label6.Text = "Mã hàng hóa";
            // 
            // txtMahh
            // 
            this.txtMahh.Location = new System.Drawing.Point(141, 12);
            this.txtMahh.Name = "txtMahh";
            this.txtMahh.Size = new System.Drawing.Size(312, 20);
            this.txtMahh.TabIndex = 153;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(141, 181);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(312, 79);
            this.textBox1.TabIndex = 152;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 151;
            this.label4.Text = "Mô tả";
            // 
            // cbdvt
            // 
            this.cbdvt.DataSource = this.donViTinhBindingSource;
            this.cbdvt.DisplayMember = "TenDVT";
            this.cbdvt.FormattingEnabled = true;
            this.cbdvt.Location = new System.Drawing.Point(141, 130);
            this.cbdvt.Name = "cbdvt";
            this.cbdvt.Size = new System.Drawing.Size(312, 21);
            this.cbdvt.TabIndex = 150;
            this.cbdvt.ValueMember = "MaDVT";
            // 
            // cbLh
            // 
            this.cbLh.DataSource = this.loaiHangBindingSource;
            this.cbLh.DisplayMember = "TenLoaiHang";
            this.cbLh.FormattingEnabled = true;
            this.cbLh.Location = new System.Drawing.Point(141, 88);
            this.cbLh.Name = "cbLh";
            this.cbLh.Size = new System.Drawing.Size(312, 21);
            this.cbLh.TabIndex = 149;
            this.cbLh.ValueMember = "MaLoaiHang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 148;
            this.label3.Text = "Đơn vị tính";
            // 
            // Huy
            // 
            this.Huy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Huy.ImageOptions.SvgImage")));
            this.Huy.Location = new System.Drawing.Point(299, 293);
            this.Huy.Name = "Huy";
            this.Huy.Size = new System.Drawing.Size(100, 45);
            this.Huy.TabIndex = 147;
            this.Huy.Text = "Hủy bỏ";
            this.Huy.Click += new System.EventHandler(this.Huy_Click_1);
            // 
            // btnSua
            // 
            this.btnSua.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnSua.Location = new System.Drawing.Point(87, 293);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 45);
            this.btnSua.TabIndex = 146;
            this.btnSua.Text = "Chấp nhận";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 145;
            this.label2.Text = "Tên hàng hóa";
            // 
            // txtTenhh
            // 
            this.txtTenhh.Location = new System.Drawing.Point(141, 49);
            this.txtTenhh.Name = "txtTenhh";
            this.txtTenhh.Size = new System.Drawing.Size(312, 20);
            this.txtTenhh.TabIndex = 144;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 143;
            this.label1.Text = "Loại hàng";
            // 
            // quanLyBanBanhKeo_DoAnDataSet5
            // 
            this.quanLyBanBanhKeo_DoAnDataSet5.DataSetName = "QuanLyBanBanhKeo_DoAnDataSet5";
            this.quanLyBanBanhKeo_DoAnDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // loaiHangBindingSource
            // 
            this.loaiHangBindingSource.DataMember = "LoaiHang";
            this.loaiHangBindingSource.DataSource = this.quanLyBanBanhKeo_DoAnDataSet5;
            // 
            // loaiHangTableAdapter
            // 
            this.loaiHangTableAdapter.ClearBeforeFill = true;
            // 
            // quanLyBanBanhKeo_DoAnDataSet6
            // 
            this.quanLyBanBanhKeo_DoAnDataSet6.DataSetName = "QuanLyBanBanhKeo_DoAnDataSet6";
            this.quanLyBanBanhKeo_DoAnDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // donViTinhBindingSource
            // 
            this.donViTinhBindingSource.DataMember = "DonViTinh";
            this.donViTinhBindingSource.DataSource = this.quanLyBanBanhKeo_DoAnDataSet6;
            // 
            // donViTinhTableAdapter
            // 
            this.donViTinhTableAdapter.ClearBeforeFill = true;
            // 
            // SuaHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 370);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMahh);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbdvt);
            this.Controls.Add(this.cbLh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Huy);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenhh);
            this.Controls.Add(this.label1);
            this.Name = "SuaHangHoa";
            this.Text = "SuaHangHoa";
            this.Load += new System.EventHandler(this.SuaHangHoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donViTinhBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMahh;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbdvt;
        private System.Windows.Forms.ComboBox cbLh;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton Huy;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenhh;
        private System.Windows.Forms.Label label1;
        private QuanLyBanBanhKeo_DoAnDataSet5 quanLyBanBanhKeo_DoAnDataSet5;
        private System.Windows.Forms.BindingSource loaiHangBindingSource;
        private QuanLyBanBanhKeo_DoAnDataSet5TableAdapters.LoaiHangTableAdapter loaiHangTableAdapter;
        private QuanLyBanBanhKeo_DoAnDataSet6 quanLyBanBanhKeo_DoAnDataSet6;
        private System.Windows.Forms.BindingSource donViTinhBindingSource;
        private QuanLyBanBanhKeo_DoAnDataSet6TableAdapters.DonViTinhTableAdapter donViTinhTableAdapter;
    }
}