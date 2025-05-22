namespace BanhKeo_Doan
{
    partial class FormBangGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBangGia));
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSuaBangGia = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemBangGia = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(225, 66);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(60, 36);
            this.simpleButton3.TabIndex = 21;
            this.simpleButton3.Text = "Xóa";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // btnSuaBangGia
            // 
            this.btnSuaBangGia.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSuaBangGia.ImageOptions.SvgImage")));
            this.btnSuaBangGia.Location = new System.Drawing.Point(135, 66);
            this.btnSuaBangGia.Name = "btnSuaBangGia";
            this.btnSuaBangGia.Size = new System.Drawing.Size(61, 36);
            this.btnSuaBangGia.TabIndex = 20;
            this.btnSuaBangGia.Text = "Sửa";
            this.btnSuaBangGia.Click += new System.EventHandler(this.btnSuaBangGia_Click);
            // 
            // btnThemBangGia
            // 
            this.btnThemBangGia.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemBangGia.ImageOptions.SvgImage")));
            this.btnThemBangGia.Location = new System.Drawing.Point(45, 66);
            this.btnThemBangGia.Name = "btnThemBangGia";
            this.btnThemBangGia.Size = new System.Drawing.Size(68, 36);
            this.btnThemBangGia.TabIndex = 19;
            this.btnThemBangGia.Text = "Thêm";
            this.btnThemBangGia.Click += new System.EventHandler(this.btnThemBangGia_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 39);
            this.label1.TabIndex = 18;
            this.label1.Text = "Bảng giá mặt hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormBangGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.btnSuaBangGia);
            this.Controls.Add(this.btnThemBangGia);
            this.Controls.Add(this.label1);
            this.Name = "FormBangGia";
            this.Size = new System.Drawing.Size(896, 112);
            this.Load += new System.EventHandler(this.FormBangGia_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnSuaBangGia;
        private DevExpress.XtraEditors.SimpleButton btnThemBangGia;
        private System.Windows.Forms.Label label1;
    }
}
