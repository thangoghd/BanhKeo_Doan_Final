namespace BanhKeo_Doan
{
    partial class FormDVT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDVT));
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.SuaDVT = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemDVT = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(231, 65);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(60, 36);
            this.simpleButton3.TabIndex = 13;
            this.simpleButton3.Text = "Xóa";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // SuaDVT
            // 
            this.SuaDVT.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SuaDVT.ImageOptions.SvgImage")));
            this.SuaDVT.Location = new System.Drawing.Point(141, 65);
            this.SuaDVT.Name = "SuaDVT";
            this.SuaDVT.Size = new System.Drawing.Size(61, 36);
            this.SuaDVT.TabIndex = 12;
            this.SuaDVT.Text = "Sửa";
            this.SuaDVT.Click += new System.EventHandler(this.SuaDVT_Click);
            // 
            // btnThemDVT
            // 
            this.btnThemDVT.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemDVT.ImageOptions.SvgImage")));
            this.btnThemDVT.Location = new System.Drawing.Point(51, 65);
            this.btnThemDVT.Name = "btnThemDVT";
            this.btnThemDVT.Size = new System.Drawing.Size(68, 36);
            this.btnThemDVT.TabIndex = 11;
            this.btnThemDVT.Text = "Thêm";
            this.btnThemDVT.Click += new System.EventHandler(this.btnThemDVT_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(284, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "Danh mục đơn vị tính";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormDVT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.SuaDVT);
            this.Controls.Add(this.btnThemDVT);
            this.Controls.Add(this.label1);
            this.Name = "FormDVT";
            this.Size = new System.Drawing.Size(896, 112);
            this.Load += new System.EventHandler(this.FormDVT_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton SuaDVT;
        private DevExpress.XtraEditors.SimpleButton btnThemDVT;
        private System.Windows.Forms.Label label1;
    }
}
