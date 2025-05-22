namespace BanhKeo_Doan
{
    partial class FormNguoiDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNguoiDung));
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSuaNguoiDung = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemNguoiDung = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPhanQuyen = new DevExpress.XtraEditors.SimpleButton();
            this.ckbtk = new System.Windows.Forms.CheckBox();
            this.ckbTen = new System.Windows.Forms.CheckBox();
            this.txttk = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(354, 55);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(60, 36);
            this.simpleButton3.TabIndex = 19;
            this.simpleButton3.Text = "Xóa";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // btnSuaNguoiDung
            // 
            this.btnSuaNguoiDung.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSuaNguoiDung.ImageOptions.SvgImage")));
            this.btnSuaNguoiDung.Location = new System.Drawing.Point(136, 55);
            this.btnSuaNguoiDung.Name = "btnSuaNguoiDung";
            this.btnSuaNguoiDung.Size = new System.Drawing.Size(61, 36);
            this.btnSuaNguoiDung.TabIndex = 18;
            this.btnSuaNguoiDung.Text = "Sửa";
            this.btnSuaNguoiDung.Click += new System.EventHandler(this.btnSuaNguoiDung_Click);
            // 
            // btnThemNguoiDung
            // 
            this.btnThemNguoiDung.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemNguoiDung.ImageOptions.SvgImage")));
            this.btnThemNguoiDung.Location = new System.Drawing.Point(46, 55);
            this.btnThemNguoiDung.Name = "btnThemNguoiDung";
            this.btnThemNguoiDung.Size = new System.Drawing.Size(68, 36);
            this.btnThemNguoiDung.TabIndex = 17;
            this.btnThemNguoiDung.Text = "Thêm";
            this.btnThemNguoiDung.Click += new System.EventHandler(this.btnThemNguoiDung_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(301, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 39);
            this.label1.TabIndex = 16;
            this.label1.Text = "Danh mục người dùng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPhanQuyen
            // 
            this.btnPhanQuyen.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPhanQuyen.ImageOptions.SvgImage")));
            this.btnPhanQuyen.Location = new System.Drawing.Point(218, 55);
            this.btnPhanQuyen.Name = "btnPhanQuyen";
            this.btnPhanQuyen.Size = new System.Drawing.Size(121, 36);
            this.btnPhanQuyen.TabIndex = 20;
            this.btnPhanQuyen.Text = "Phân quyền";
            this.btnPhanQuyen.Click += new System.EventHandler(this.btnPhanQuyen_Click);
            // 
            // ckbtk
            // 
            this.ckbtk.AutoSize = true;
            this.ckbtk.Location = new System.Drawing.Point(495, 81);
            this.ckbtk.Name = "ckbtk";
            this.ckbtk.Size = new System.Drawing.Size(140, 17);
            this.ckbtk.TabIndex = 24;
            this.ckbtk.Text = "Tìm theo tên đăng nhập";
            this.ckbtk.UseVisualStyleBackColor = true;
            this.ckbtk.CheckedChanged += new System.EventHandler(this.ckbtk_CheckedChanged);
            // 
            // ckbTen
            // 
            this.ckbTen.AutoSize = true;
            this.ckbTen.Location = new System.Drawing.Point(495, 55);
            this.ckbTen.Name = "ckbTen";
            this.ckbTen.Size = new System.Drawing.Size(143, 17);
            this.ckbTen.TabIndex = 23;
            this.ckbTen.Text = "Tìm theo tên người dùng";
            this.ckbTen.UseVisualStyleBackColor = true;
            this.ckbTen.CheckedChanged += new System.EventHandler(this.ckbTen_CheckedChanged);
            // 
            // txttk
            // 
            this.txttk.Location = new System.Drawing.Point(644, 79);
            this.txttk.Name = "txttk";
            this.txttk.Size = new System.Drawing.Size(192, 21);
            this.txttk.TabIndex = 22;
            this.txttk.TextChanged += new System.EventHandler(this.txttk_TextChanged);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(644, 52);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(192, 21);
            this.txtTen.TabIndex = 21;
            this.txtTen.TextChanged += new System.EventHandler(this.txtTen_TextChanged);
            // 
            // FormNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ckbtk);
            this.Controls.Add(this.ckbTen);
            this.Controls.Add(this.txttk);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.btnPhanQuyen);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.btnSuaNguoiDung);
            this.Controls.Add(this.btnThemNguoiDung);
            this.Controls.Add(this.label1);
            this.Name = "FormNguoiDung";
            this.Size = new System.Drawing.Size(896, 112);
            this.Load += new System.EventHandler(this.FormNguoiDung_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnSuaNguoiDung;
        private DevExpress.XtraEditors.SimpleButton btnThemNguoiDung;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnPhanQuyen;
        private System.Windows.Forms.CheckBox ckbtk;
        private System.Windows.Forms.CheckBox ckbTen;
        private System.Windows.Forms.TextBox txttk;
        private System.Windows.Forms.TextBox txtTen;
    }
}
