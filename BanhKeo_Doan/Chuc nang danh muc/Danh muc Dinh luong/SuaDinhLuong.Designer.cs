namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Dinh_luong
{
    partial class SuaDinhLuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuaDinhLuong));
            this.Huy = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.cbtp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMadl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbnl = new System.Windows.Forms.ComboBox();
            this.txtSl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.quanLyBanBanhKeo_DoAnDataSet8 = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet8();
            this.hangHoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hangHoaTableAdapter = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet8TableAdapters.HangHoaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangHoaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Huy
            // 
            this.Huy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Huy.ImageOptions.SvgImage")));
            this.Huy.Location = new System.Drawing.Point(306, 170);
            this.Huy.Name = "Huy";
            this.Huy.Size = new System.Drawing.Size(100, 45);
            this.Huy.TabIndex = 163;
            this.Huy.Text = "Hủy bỏ";
            this.Huy.Click += new System.EventHandler(this.Huy_Click);
            // 
            // btnThem
            // 
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Location = new System.Drawing.Point(94, 170);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 45);
            this.btnThem.TabIndex = 162;
            this.btnThem.Text = "Chấp nhận";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cbtp
            // 
            this.cbtp.DataSource = this.hangHoaBindingSource;
            this.cbtp.DisplayMember = "TenHangHoa";
            this.cbtp.Enabled = false;
            this.cbtp.FormattingEnabled = true;
            this.cbtp.Location = new System.Drawing.Point(176, 57);
            this.cbtp.Name = "cbtp";
            this.cbtp.Size = new System.Drawing.Size(310, 21);
            this.cbtp.TabIndex = 161;
            this.cbtp.ValueMember = "MaHangHoa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 160;
            this.label3.Text = "Tên hàng hóa thành phẩm";
            // 
            // txtMadl
            // 
            this.txtMadl.Enabled = false;
            this.txtMadl.Location = new System.Drawing.Point(174, 23);
            this.txtMadl.Name = "txtMadl";
            this.txtMadl.Size = new System.Drawing.Size(312, 20);
            this.txtMadl.TabIndex = 159;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 158;
            this.label1.Text = "Mã định lượng";
            // 
            // cbnl
            // 
            this.cbnl.DataSource = this.hangHoaBindingSource;
            this.cbnl.DisplayMember = "TenHangHoa";
            this.cbnl.FormattingEnabled = true;
            this.cbnl.Location = new System.Drawing.Point(175, 94);
            this.cbnl.Name = "cbnl";
            this.cbnl.Size = new System.Drawing.Size(311, 21);
            this.cbnl.TabIndex = 157;
            this.cbnl.ValueMember = "MaHangHoa";
            // 
            // txtSl
            // 
            this.txtSl.Location = new System.Drawing.Point(174, 130);
            this.txtSl.Name = "txtSl";
            this.txtSl.Size = new System.Drawing.Size(312, 20);
            this.txtSl.TabIndex = 156;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 155;
            this.label4.Text = "Số lượng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 154;
            this.label2.Text = "Tên hàng hóa nguyên liệu";
            // 
            // quanLyBanBanhKeo_DoAnDataSet8
            // 
            this.quanLyBanBanhKeo_DoAnDataSet8.DataSetName = "QuanLyBanBanhKeo_DoAnDataSet8";
            this.quanLyBanBanhKeo_DoAnDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hangHoaBindingSource
            // 
            this.hangHoaBindingSource.DataMember = "HangHoa";
            this.hangHoaBindingSource.DataSource = this.quanLyBanBanhKeo_DoAnDataSet8;
            // 
            // hangHoaTableAdapter
            // 
            this.hangHoaTableAdapter.ClearBeforeFill = true;
            // 
            // SuaDinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 229);
            this.Controls.Add(this.Huy);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbtp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMadl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbnl);
            this.Controls.Add(this.txtSl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "SuaDinhLuong";
            this.Text = "SuaDinhLuong";
            this.Load += new System.EventHandler(this.SuaDinhLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangHoaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Huy;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private System.Windows.Forms.ComboBox cbtp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMadl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbnl;
        private System.Windows.Forms.TextBox txtSl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private QuanLyBanBanhKeo_DoAnDataSet8 quanLyBanBanhKeo_DoAnDataSet8;
        private System.Windows.Forms.BindingSource hangHoaBindingSource;
        private QuanLyBanBanhKeo_DoAnDataSet8TableAdapters.HangHoaTableAdapter hangHoaTableAdapter;
    }
}