namespace BanhKeo_Doan
{
    partial class FormNganhHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNganhHang));
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSuaNganhHang = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemNganhHang = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(228, 67);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(60, 36);
            this.simpleButton3.TabIndex = 9;
            this.simpleButton3.Text = "Xóa";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // btnSuaNganhHang
            // 
            this.btnSuaNganhHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSuaNganhHang.ImageOptions.SvgImage")));
            this.btnSuaNganhHang.Location = new System.Drawing.Point(138, 67);
            this.btnSuaNganhHang.Name = "btnSuaNganhHang";
            this.btnSuaNganhHang.Size = new System.Drawing.Size(61, 36);
            this.btnSuaNganhHang.TabIndex = 8;
            this.btnSuaNganhHang.Text = "Sửa";
            this.btnSuaNganhHang.Click += new System.EventHandler(this.btnSuaNganhHang_Click);
            // 
            // btnThemNganhHang
            // 
            this.btnThemNganhHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemNganhHang.ImageOptions.SvgImage")));
            this.btnThemNganhHang.Location = new System.Drawing.Point(48, 67);
            this.btnThemNganhHang.Name = "btnThemNganhHang";
            this.btnThemNganhHang.Size = new System.Drawing.Size(68, 36);
            this.btnThemNganhHang.TabIndex = 7;
            this.btnThemNganhHang.Text = "Thêm";
            this.btnThemNganhHang.Click += new System.EventHandler(this.btnThemNganhHang_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(301, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Danh mục ngành hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormNganhHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.btnSuaNganhHang);
            this.Controls.Add(this.btnThemNganhHang);
            this.Controls.Add(this.label1);
            this.Name = "FormNganhHang";
            this.Size = new System.Drawing.Size(896, 112);
            this.Load += new System.EventHandler(this.FormNganhHang_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnSuaNganhHang;
        private DevExpress.XtraEditors.SimpleButton btnThemNganhHang;
        private System.Windows.Forms.Label label1;
    }
}
