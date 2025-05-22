namespace BanhKeo_Doan.Chuc_nang_danh_muc
{
    partial class SuaBangGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuaBangGia));
            this.txtNhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Huy = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtcn = new System.Windows.Forms.DateTimePicker();
            this.txtBuon = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLe = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbTen = new System.Windows.Forms.ComboBox();
            this.hangHoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyBanBanhKeo_DoAnDataSet8 = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet8();
            this.txtMabg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hangHoaTableAdapter = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet8TableAdapters.HangHoaTableAdapter();
            this.quanLyBanBanhKeo_DoAnDataSet10 = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet10();
            this.hangHoaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.hangHoaTableAdapter1 = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet10TableAdapters.HangHoaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.hangHoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangHoaBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNhap
            // 
            this.txtNhap.Location = new System.Drawing.Point(151, 129);
            this.txtNhap.Name = "txtNhap";
            this.txtNhap.Size = new System.Drawing.Size(312, 20);
            this.txtNhap.TabIndex = 130;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 129;
            this.label4.Text = "Giá nhập";
            // 
            // Huy
            // 
            this.Huy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Huy.ImageOptions.SvgImage")));
            this.Huy.Location = new System.Drawing.Point(307, 253);
            this.Huy.Name = "Huy";
            this.Huy.Size = new System.Drawing.Size(100, 45);
            this.Huy.TabIndex = 125;
            this.Huy.Text = "Hủy bỏ";
            this.Huy.Click += new System.EventHandler(this.Huy_Click);
            // 
            // btnSua
            // 
            this.btnSua.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSua.ImageOptions.SvgImage")));
            this.btnSua.Location = new System.Drawing.Point(95, 253);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 45);
            this.btnSua.TabIndex = 124;
            this.btnSua.Text = "Chấp nhận";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 123;
            this.label2.Text = "Tên hàng hóa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 131;
            this.label5.Text = "Ngày cập nhật";
            // 
            // dtcn
            // 
            this.dtcn.CustomFormat = "yyyy/MM/dd";
            this.dtcn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtcn.Location = new System.Drawing.Point(151, 22);
            this.dtcn.Name = "dtcn";
            this.dtcn.Size = new System.Drawing.Size(312, 20);
            this.dtcn.TabIndex = 132;
            // 
            // txtBuon
            // 
            this.txtBuon.Location = new System.Drawing.Point(151, 166);
            this.txtBuon.Name = "txtBuon";
            this.txtBuon.Size = new System.Drawing.Size(312, 20);
            this.txtBuon.TabIndex = 134;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 133;
            this.label6.Text = "Giá bán buôn";
            // 
            // txtLe
            // 
            this.txtLe.Location = new System.Drawing.Point(151, 206);
            this.txtLe.Name = "txtLe";
            this.txtLe.Size = new System.Drawing.Size(312, 20);
            this.txtLe.TabIndex = 136;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 135;
            this.label7.Text = "Giá bán lẻ";
            // 
            // cbTen
            // 
            this.cbTen.DataSource = this.hangHoaBindingSource1;
            this.cbTen.DisplayMember = "TenHangHoa";
            this.cbTen.FormattingEnabled = true;
            this.cbTen.Location = new System.Drawing.Point(152, 93);
            this.cbTen.Name = "cbTen";
            this.cbTen.Size = new System.Drawing.Size(311, 21);
            this.cbTen.TabIndex = 137;
            this.cbTen.ValueMember = "MaHangHoa";
            // 
            // hangHoaBindingSource
            // 
            this.hangHoaBindingSource.DataMember = "HangHoa";
            this.hangHoaBindingSource.DataSource = this.quanLyBanBanhKeo_DoAnDataSet8;
            // 
            // quanLyBanBanhKeo_DoAnDataSet8
            // 
            this.quanLyBanBanhKeo_DoAnDataSet8.DataSetName = "QuanLyBanBanhKeo_DoAnDataSet8";
            this.quanLyBanBanhKeo_DoAnDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtMabg
            // 
            this.txtMabg.Enabled = false;
            this.txtMabg.Location = new System.Drawing.Point(152, 57);
            this.txtMabg.Name = "txtMabg";
            this.txtMabg.Size = new System.Drawing.Size(312, 20);
            this.txtMabg.TabIndex = 139;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 138;
            this.label1.Text = "Mã bảng giá";
            // 
            // hangHoaTableAdapter
            // 
            this.hangHoaTableAdapter.ClearBeforeFill = true;
            // 
            // quanLyBanBanhKeo_DoAnDataSet10
            // 
            this.quanLyBanBanhKeo_DoAnDataSet10.DataSetName = "QuanLyBanBanhKeo_DoAnDataSet10";
            this.quanLyBanBanhKeo_DoAnDataSet10.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hangHoaBindingSource1
            // 
            this.hangHoaBindingSource1.DataMember = "HangHoa";
            this.hangHoaBindingSource1.DataSource = this.quanLyBanBanhKeo_DoAnDataSet10;
            // 
            // hangHoaTableAdapter1
            // 
            this.hangHoaTableAdapter1.ClearBeforeFill = true;
            // 
            // SuaBangGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 333);
            this.Controls.Add(this.txtMabg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTen);
            this.Controls.Add(this.txtLe);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBuon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtcn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNhap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Huy);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.label2);
            this.Name = "SuaBangGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuaBangGia";
            this.Load += new System.EventHandler(this.SuaBangGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hangHoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangHoaBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNhap;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton Huy;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtcn;
        private System.Windows.Forms.TextBox txtBuon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbTen;
        private System.Windows.Forms.TextBox txtMabg;
        private System.Windows.Forms.Label label1;
        private QuanLyBanBanhKeo_DoAnDataSet8 quanLyBanBanhKeo_DoAnDataSet8;
        private System.Windows.Forms.BindingSource hangHoaBindingSource;
        private QuanLyBanBanhKeo_DoAnDataSet8TableAdapters.HangHoaTableAdapter hangHoaTableAdapter;
        private QuanLyBanBanhKeo_DoAnDataSet10 quanLyBanBanhKeo_DoAnDataSet10;
        private System.Windows.Forms.BindingSource hangHoaBindingSource1;
        private QuanLyBanBanhKeo_DoAnDataSet10TableAdapters.HangHoaTableAdapter hangHoaTableAdapter1;
    }
}