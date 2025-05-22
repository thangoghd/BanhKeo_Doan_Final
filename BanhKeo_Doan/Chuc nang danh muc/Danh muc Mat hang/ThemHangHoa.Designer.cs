namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Mat_hang
{
    partial class ThemHangHoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemHangHoa));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMahh = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbdvt = new System.Windows.Forms.ComboBox();
            this.donViTinhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyBanBanhKeo_DoAnDataSet4 = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet4();
            this.cbLh = new System.Windows.Forms.ComboBox();
            this.loaiHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyBanBanhKeo_DoAnDataSet3 = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet3();
            this.label3 = new System.Windows.Forms.Label();
            this.Huy = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenhh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTendl = new System.Windows.Forms.ComboBox();
            this.btnSuadl = new DevExpress.XtraEditors.SimpleButton();
            this.dtDl = new System.Windows.Forms.DataGridView();
            this.btnThemdl = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoadl = new DevExpress.XtraEditors.SimpleButton();
            this.loaiHangTableAdapter = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet3TableAdapters.LoaiHangTableAdapter();
            this.donViTinhTableAdapter = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet4TableAdapters.DonViTinhTableAdapter();
            this.quanLyBanBanhKeo_DoAnDataSet11 = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet11();
            this.hangHoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hangHoaTableAdapter = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet11TableAdapters.HangHoaTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donViTinhBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet3)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangHoaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(977, 448);
            this.tabControl1.TabIndex = 131;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtMahh);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cbdvt);
            this.tabPage1.Controls.Add(this.cbLh);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.Huy);
            this.tabPage1.Controls.Add(this.btnThem);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtTenhh);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(969, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông tin hàng hóa";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(230, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 142;
            this.label6.Text = "Mã hàng hóa";
            // 
            // txtMahh
            // 
            this.txtMahh.Location = new System.Drawing.Point(335, 32);
            this.txtMahh.Name = "txtMahh";
            this.txtMahh.Size = new System.Drawing.Size(312, 20);
            this.txtMahh.TabIndex = 141;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(335, 201);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(312, 79);
            this.textBox1.TabIndex = 140;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 139;
            this.label4.Text = "Mô tả";
            // 
            // cbdvt
            // 
            this.cbdvt.DataSource = this.donViTinhBindingSource;
            this.cbdvt.DisplayMember = "TenDVT";
            this.cbdvt.FormattingEnabled = true;
            this.cbdvt.Location = new System.Drawing.Point(335, 150);
            this.cbdvt.Name = "cbdvt";
            this.cbdvt.Size = new System.Drawing.Size(312, 21);
            this.cbdvt.TabIndex = 138;
            this.cbdvt.ValueMember = "MaDVT";
            // 
            // donViTinhBindingSource
            // 
            this.donViTinhBindingSource.DataMember = "DonViTinh";
            this.donViTinhBindingSource.DataSource = this.quanLyBanBanhKeo_DoAnDataSet4;
            // 
            // quanLyBanBanhKeo_DoAnDataSet4
            // 
            this.quanLyBanBanhKeo_DoAnDataSet4.DataSetName = "QuanLyBanBanhKeo_DoAnDataSet4";
            this.quanLyBanBanhKeo_DoAnDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbLh
            // 
            this.cbLh.DataSource = this.loaiHangBindingSource;
            this.cbLh.DisplayMember = "TenLoaiHang";
            this.cbLh.FormattingEnabled = true;
            this.cbLh.Location = new System.Drawing.Point(335, 108);
            this.cbLh.Name = "cbLh";
            this.cbLh.Size = new System.Drawing.Size(312, 21);
            this.cbLh.TabIndex = 137;
            this.cbLh.ValueMember = "MaLoaiHang";
            // 
            // loaiHangBindingSource
            // 
            this.loaiHangBindingSource.DataMember = "LoaiHang";
            this.loaiHangBindingSource.DataSource = this.quanLyBanBanhKeo_DoAnDataSet3;
            // 
            // quanLyBanBanhKeo_DoAnDataSet3
            // 
            this.quanLyBanBanhKeo_DoAnDataSet3.DataSetName = "QuanLyBanBanhKeo_DoAnDataSet3";
            this.quanLyBanBanhKeo_DoAnDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 136;
            this.label3.Text = "Đơn vị tính";
            // 
            // Huy
            // 
            this.Huy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Huy.ImageOptions.SvgImage")));
            this.Huy.Location = new System.Drawing.Point(547, 303);
            this.Huy.Name = "Huy";
            this.Huy.Size = new System.Drawing.Size(100, 45);
            this.Huy.TabIndex = 135;
            this.Huy.Text = "Hủy bỏ";
            this.Huy.Click += new System.EventHandler(this.Huy_Click_1);
            // 
            // btnThem
            // 
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Location = new System.Drawing.Point(335, 303);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 45);
            this.btnThem.TabIndex = 134;
            this.btnThem.Text = "Chấp nhận";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 133;
            this.label2.Text = "Tên hàng hóa";
            // 
            // txtTenhh
            // 
            this.txtTenhh.Location = new System.Drawing.Point(335, 69);
            this.txtTenhh.Name = "txtTenhh";
            this.txtTenhh.Size = new System.Drawing.Size(312, 20);
            this.txtTenhh.TabIndex = 132;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 131;
            this.label1.Text = "Loại hàng";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.cbTendl);
            this.tabPage2.Controls.Add(this.btnSuadl);
            this.tabPage2.Controls.Add(this.dtDl);
            this.tabPage2.Controls.Add(this.btnThemdl);
            this.tabPage2.Controls.Add(this.btnXoadl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(969, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Công thức định lượng";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(365, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tên hàng hóa:";
            // 
            // cbTendl
            // 
            this.cbTendl.DataSource = this.hangHoaBindingSource;
            this.cbTendl.DisplayMember = "TenHangHoa";
            this.cbTendl.FormattingEnabled = true;
            this.cbTendl.Location = new System.Drawing.Point(448, 20);
            this.cbTendl.Name = "cbTendl";
            this.cbTendl.Size = new System.Drawing.Size(266, 21);
            this.cbTendl.TabIndex = 10;
            this.cbTendl.ValueMember = "MaHangHoa";
            this.cbTendl.SelectedIndexChanged += new System.EventHandler(this.cbTendl_SelectedIndexChanged);
            // 
            // btnSuadl
            // 
            this.btnSuadl.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSuadl.ImageOptions.SvgImage")));
            this.btnSuadl.Location = new System.Drawing.Point(127, 6);
            this.btnSuadl.Name = "btnSuadl";
            this.btnSuadl.Size = new System.Drawing.Size(113, 50);
            this.btnSuadl.TabIndex = 9;
            this.btnSuadl.Text = "Sửa";
            this.btnSuadl.Click += new System.EventHandler(this.btnSuadl_Click);
            // 
            // dtDl
            // 
            this.dtDl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtDl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDl.Location = new System.Drawing.Point(5, 73);
            this.dtDl.Name = "dtDl";
            this.dtDl.Size = new System.Drawing.Size(961, 341);
            this.dtDl.TabIndex = 5;
            // 
            // btnThemdl
            // 
            this.btnThemdl.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemdl.ImageOptions.SvgImage")));
            this.btnThemdl.Location = new System.Drawing.Point(8, 5);
            this.btnThemdl.Name = "btnThemdl";
            this.btnThemdl.Size = new System.Drawing.Size(113, 50);
            this.btnThemdl.TabIndex = 7;
            this.btnThemdl.Text = "Thêm";
            this.btnThemdl.Click += new System.EventHandler(this.btnThemdl_Click);
            // 
            // btnXoadl
            // 
            this.btnXoadl.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoadl.ImageOptions.SvgImage")));
            this.btnXoadl.Location = new System.Drawing.Point(246, 6);
            this.btnXoadl.Name = "btnXoadl";
            this.btnXoadl.Size = new System.Drawing.Size(113, 50);
            this.btnXoadl.TabIndex = 8;
            this.btnXoadl.Text = "Xóa";
            this.btnXoadl.Click += new System.EventHandler(this.btnXoadl_Click);
            // 
            // loaiHangTableAdapter
            // 
            this.loaiHangTableAdapter.ClearBeforeFill = true;
            // 
            // donViTinhTableAdapter
            // 
            this.donViTinhTableAdapter.ClearBeforeFill = true;
            // 
            // quanLyBanBanhKeo_DoAnDataSet11
            // 
            this.quanLyBanBanhKeo_DoAnDataSet11.DataSetName = "QuanLyBanBanhKeo_DoAnDataSet11";
            this.quanLyBanBanhKeo_DoAnDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hangHoaBindingSource
            // 
            this.hangHoaBindingSource.DataMember = "HangHoa";
            this.hangHoaBindingSource.DataSource = this.quanLyBanBanhKeo_DoAnDataSet11;
            // 
            // hangHoaTableAdapter
            // 
            this.hangHoaTableAdapter.ClearBeforeFill = true;
            // 
            // ThemHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 448);
            this.Controls.Add(this.tabControl1);
            this.Name = "ThemHangHoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThemHangHoa";
            this.Load += new System.EventHandler(this.ThemHangHoa_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donViTinhBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet3)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangHoaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbdvt;
        private System.Windows.Forms.ComboBox cbLh;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton Huy;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtDl;
        private DevExpress.XtraEditors.SimpleButton btnThemdl;
        private DevExpress.XtraEditors.SimpleButton btnXoadl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTendl;
        private DevExpress.XtraEditors.SimpleButton btnSuadl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMahh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenhh;
        private QuanLyBanBanhKeo_DoAnDataSet3 quanLyBanBanhKeo_DoAnDataSet3;
        private System.Windows.Forms.BindingSource loaiHangBindingSource;
        private QuanLyBanBanhKeo_DoAnDataSet3TableAdapters.LoaiHangTableAdapter loaiHangTableAdapter;
        private QuanLyBanBanhKeo_DoAnDataSet4 quanLyBanBanhKeo_DoAnDataSet4;
        private System.Windows.Forms.BindingSource donViTinhBindingSource;
        private QuanLyBanBanhKeo_DoAnDataSet4TableAdapters.DonViTinhTableAdapter donViTinhTableAdapter;
        private QuanLyBanBanhKeo_DoAnDataSet11 quanLyBanBanhKeo_DoAnDataSet11;
        private System.Windows.Forms.BindingSource hangHoaBindingSource;
        private QuanLyBanBanhKeo_DoAnDataSet11TableAdapters.HangHoaTableAdapter hangHoaTableAdapter;
    }
}