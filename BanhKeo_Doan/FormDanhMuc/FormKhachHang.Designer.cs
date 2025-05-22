namespace BanhKeo_Doan
{
    partial class FormKhachHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKhachHang));
            this.txtTen = new System.Windows.Forms.TextBox();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.SuaKhachHang = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemKhachHang = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.ckbTen = new System.Windows.Forms.CheckBox();
            this.ckbsdt = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(388, 70);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(155, 21);
            this.txtTen.TabIndex = 10;
            this.txtTen.TextChanged += new System.EventHandler(this.txtTen_TextChanged);
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(212, 67);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(60, 36);
            this.simpleButton3.TabIndex = 9;
            this.simpleButton3.Text = "Xóa";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // SuaKhachHang
            // 
            this.SuaKhachHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SuaKhachHang.ImageOptions.SvgImage")));
            this.SuaKhachHang.Location = new System.Drawing.Point(122, 67);
            this.SuaKhachHang.Name = "SuaKhachHang";
            this.SuaKhachHang.Size = new System.Drawing.Size(61, 36);
            this.SuaKhachHang.TabIndex = 8;
            this.SuaKhachHang.Text = "Sửa";
            this.SuaKhachHang.Click += new System.EventHandler(this.SuaKhachHang_Click);
            // 
            // btnThemKhachHang
            // 
            this.btnThemKhachHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemKhachHang.ImageOptions.SvgImage")));
            this.btnThemKhachHang.Location = new System.Drawing.Point(32, 67);
            this.btnThemKhachHang.Name = "btnThemKhachHang";
            this.btnThemKhachHang.Size = new System.Drawing.Size(68, 36);
            this.btnThemKhachHang.TabIndex = 7;
            this.btnThemKhachHang.Text = "Thêm";
            this.btnThemKhachHang.Click += new System.EventHandler(this.btnThemKhachHang_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Danh mục khách hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(685, 70);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(147, 21);
            this.txtSDT.TabIndex = 12;
            this.txtSDT.TextChanged += new System.EventHandler(this.txtSDT_TextChanged);
            // 
            // ckbTen
            // 
            this.ckbTen.AutoSize = true;
            this.ckbTen.Location = new System.Drawing.Point(291, 73);
            this.ckbTen.Name = "ckbTen";
            this.ckbTen.Size = new System.Drawing.Size(86, 17);
            this.ckbTen.TabIndex = 14;
            this.ckbTen.Text = "Tìm theo tên";
            this.ckbTen.UseVisualStyleBackColor = true;
            this.ckbTen.CheckedChanged += new System.EventHandler(this.ckbTen_CheckedChanged);
            // 
            // ckbsdt
            // 
            this.ckbsdt.AutoSize = true;
            this.ckbsdt.Location = new System.Drawing.Point(581, 73);
            this.ckbsdt.Name = "ckbsdt";
            this.ckbsdt.Size = new System.Drawing.Size(90, 17);
            this.ckbsdt.TabIndex = 15;
            this.ckbsdt.Text = "Tìm theo SĐT";
            this.ckbsdt.UseVisualStyleBackColor = true;
            this.ckbsdt.CheckedChanged += new System.EventHandler(this.ckbsdt_CheckedChanged);
            // 
            // FormKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ckbsdt);
            this.Controls.Add(this.ckbTen);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.SuaKhachHang);
            this.Controls.Add(this.btnThemKhachHang);
            this.Controls.Add(this.label1);
            this.Name = "FormKhachHang";
            this.Size = new System.Drawing.Size(896, 112);
            this.Load += new System.EventHandler(this.FormKhachHang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTen;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton SuaKhachHang;
        private DevExpress.XtraEditors.SimpleButton btnThemKhachHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.CheckBox ckbTen;
        private System.Windows.Forms.CheckBox ckbsdt;
    }
}
