namespace BanhKeo_Doan
{
    partial class FormNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhanVien));
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSuaNhanVien = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemNhanVien = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(221, 65);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(60, 36);
            this.simpleButton3.TabIndex = 9;
            this.simpleButton3.Text = "Xóa";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // btnSuaNhanVien
            // 
            this.btnSuaNhanVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSuaNhanVien.ImageOptions.SvgImage")));
            this.btnSuaNhanVien.Location = new System.Drawing.Point(131, 65);
            this.btnSuaNhanVien.Name = "btnSuaNhanVien";
            this.btnSuaNhanVien.Size = new System.Drawing.Size(61, 36);
            this.btnSuaNhanVien.TabIndex = 8;
            this.btnSuaNhanVien.Text = "Sửa";
            this.btnSuaNhanVien.Click += new System.EventHandler(this.btnSuaNhanVien_Click);
            // 
            // btnThemNhanVien
            // 
            this.btnThemNhanVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemNhanVien.ImageOptions.SvgImage")));
            this.btnThemNhanVien.Location = new System.Drawing.Point(41, 65);
            this.btnThemNhanVien.Name = "btnThemNhanVien";
            this.btnThemNhanVien.Size = new System.Drawing.Size(68, 36);
            this.btnThemNhanVien.TabIndex = 7;
            this.btnThemNhanVien.Text = "Thêm";
            this.btnThemNhanVien.Click += new System.EventHandler(this.btnThemNhanVien_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(294, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Danh mục nhân viên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.btnSuaNhanVien);
            this.Controls.Add(this.btnThemNhanVien);
            this.Controls.Add(this.label1);
            this.Name = "FormNhanVien";
            this.Size = new System.Drawing.Size(896, 112);
            this.Load += new System.EventHandler(this.FormNhanVien_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnSuaNhanVien;
        private DevExpress.XtraEditors.SimpleButton btnThemNhanVien;
        private System.Windows.Forms.Label label1;
    }
}
