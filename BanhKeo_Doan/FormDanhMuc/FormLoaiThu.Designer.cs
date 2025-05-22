namespace BanhKeo_Doan
{
    partial class FormLoaiThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoaiThu));
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSuaLoaiThu = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemLoaiThu = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(225, 66);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(60, 36);
            this.simpleButton3.TabIndex = 23;
            this.simpleButton3.Text = "Xóa";
            this.simpleButton3.Click += new System.EventHandler(this.btnXoaLoaiThu_Click);
            // 
            // btnSuaLoaiThu
            // 
            this.btnSuaLoaiThu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSuaLoaiThu.ImageOptions.SvgImage")));
            this.btnSuaLoaiThu.Location = new System.Drawing.Point(135, 66);
            this.btnSuaLoaiThu.Name = "btnSuaLoaiThu";
            this.btnSuaLoaiThu.Size = new System.Drawing.Size(61, 36);
            this.btnSuaLoaiThu.TabIndex = 22;
            this.btnSuaLoaiThu.Text = "Sửa";
            this.btnSuaLoaiThu.Click += new System.EventHandler(this.btnSuaLoaiThu_Click);
            // 
            // btnThemLoaiThu
            // 
            this.btnThemLoaiThu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemLoaiThu.ImageOptions.SvgImage")));
            this.btnThemLoaiThu.Location = new System.Drawing.Point(45, 66);
            this.btnThemLoaiThu.Name = "btnThemLoaiThu";
            this.btnThemLoaiThu.Size = new System.Drawing.Size(68, 36);
            this.btnThemLoaiThu.TabIndex = 21;
            this.btnThemLoaiThu.Text = "Thêm";
            this.btnThemLoaiThu.Click += new System.EventHandler(this.btnThemLoaiThu_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 39);
            this.label1.TabIndex = 20;
            this.label1.Text = "Danh mục loại thu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormLoaiThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.btnSuaLoaiThu);
            this.Controls.Add(this.btnThemLoaiThu);
            this.Controls.Add(this.label1);
            this.Name = "FormLoaiThu";
            this.Size = new System.Drawing.Size(896, 112);
            this.Load += new System.EventHandler(this.FormLoaiThu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnSuaLoaiThu;
        private DevExpress.XtraEditors.SimpleButton btnThemLoaiThu;
        private System.Windows.Forms.Label label1;
    }
}
