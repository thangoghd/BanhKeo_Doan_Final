namespace BanhKeo_Doan
{
    partial class FormLoaiHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoaiHang));
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSuaLoaiHang = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemLoaiHang = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(230, 65);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(60, 36);
            this.simpleButton3.TabIndex = 13;
            this.simpleButton3.Text = "Xóa";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // btnSuaLoaiHang
            // 
            this.btnSuaLoaiHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSuaLoaiHang.ImageOptions.SvgImage")));
            this.btnSuaLoaiHang.Location = new System.Drawing.Point(140, 65);
            this.btnSuaLoaiHang.Name = "btnSuaLoaiHang";
            this.btnSuaLoaiHang.Size = new System.Drawing.Size(61, 36);
            this.btnSuaLoaiHang.TabIndex = 12;
            this.btnSuaLoaiHang.Text = "Sửa";
            this.btnSuaLoaiHang.Click += new System.EventHandler(this.btnSuaLoaiHang_Click);
            // 
            // btnThemLoaiHang
            // 
            this.btnThemLoaiHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemLoaiHang.ImageOptions.SvgImage")));
            this.btnThemLoaiHang.Location = new System.Drawing.Point(50, 65);
            this.btnThemLoaiHang.Name = "btnThemLoaiHang";
            this.btnThemLoaiHang.Size = new System.Drawing.Size(68, 36);
            this.btnThemLoaiHang.TabIndex = 11;
            this.btnThemLoaiHang.Text = "Thêm";
            this.btnThemLoaiHang.Click += new System.EventHandler(this.btnThemLoaiHang_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(303, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "Danh mục loại hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormLoaiHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.btnSuaLoaiHang);
            this.Controls.Add(this.btnThemLoaiHang);
            this.Controls.Add(this.label1);
            this.Name = "FormLoaiHang";
            this.Size = new System.Drawing.Size(896, 112);
            this.Load += new System.EventHandler(this.FormLoaiHang_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnSuaLoaiHang;
        private DevExpress.XtraEditors.SimpleButton btnThemLoaiHang;
        private System.Windows.Forms.Label label1;
    }
}
