namespace BanhKeo_Doan
{
    partial class FormLoaiChi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoaiChi));
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSuaLoaiChi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemLoaiChi = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(221, 66);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(60, 36);
            this.simpleButton3.TabIndex = 27;
            this.simpleButton3.Text = "Xóa";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // btnSuaLoaiChi
            // 
            this.btnSuaLoaiChi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSuaLoaiChi.ImageOptions.SvgImage")));
            this.btnSuaLoaiChi.Location = new System.Drawing.Point(131, 66);
            this.btnSuaLoaiChi.Name = "btnSuaLoaiChi";
            this.btnSuaLoaiChi.Size = new System.Drawing.Size(61, 36);
            this.btnSuaLoaiChi.TabIndex = 26;
            this.btnSuaLoaiChi.Text = "Sửa";
            this.btnSuaLoaiChi.Click += new System.EventHandler(this.btnSuaLoaiChi_Click);
            // 
            // btnThemLoaiChi
            // 
            this.btnThemLoaiChi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemLoaiChi.ImageOptions.SvgImage")));
            this.btnThemLoaiChi.Location = new System.Drawing.Point(41, 66);
            this.btnThemLoaiChi.Name = "btnThemLoaiChi";
            this.btnThemLoaiChi.Size = new System.Drawing.Size(68, 36);
            this.btnThemLoaiChi.TabIndex = 25;
            this.btnThemLoaiChi.Text = "Thêm";
            this.btnThemLoaiChi.Click += new System.EventHandler(this.btnThemLoaiChi_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(294, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 39);
            this.label1.TabIndex = 24;
            this.label1.Text = "Danh mục loại chi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormLoaiChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.btnSuaLoaiChi);
            this.Controls.Add(this.btnThemLoaiChi);
            this.Controls.Add(this.label1);
            this.Name = "FormLoaiChi";
            this.Size = new System.Drawing.Size(896, 112);
            this.Load += new System.EventHandler(this.FormLoaiChi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnSuaLoaiChi;
        private DevExpress.XtraEditors.SimpleButton btnThemLoaiChi;
        private System.Windows.Forms.Label label1;
    }
}
