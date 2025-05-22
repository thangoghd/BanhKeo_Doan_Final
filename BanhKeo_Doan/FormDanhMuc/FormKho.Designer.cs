namespace BanhKeo_Doan
{
    partial class FormKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKho));
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSuaKho = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemKho = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(235, 65);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(60, 36);
            this.simpleButton3.TabIndex = 17;
            this.simpleButton3.Text = "Xóa";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // btnSuaKho
            // 
            this.btnSuaKho.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSuaKho.ImageOptions.SvgImage")));
            this.btnSuaKho.Location = new System.Drawing.Point(145, 65);
            this.btnSuaKho.Name = "btnSuaKho";
            this.btnSuaKho.Size = new System.Drawing.Size(61, 36);
            this.btnSuaKho.TabIndex = 16;
            this.btnSuaKho.Text = "Sửa";
            this.btnSuaKho.Click += new System.EventHandler(this.btnSuaKho_Click);
            // 
            // btnThemKho
            // 
            this.btnThemKho.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemKho.ImageOptions.SvgImage")));
            this.btnThemKho.Location = new System.Drawing.Point(55, 65);
            this.btnThemKho.Name = "btnThemKho";
            this.btnThemKho.Size = new System.Drawing.Size(68, 36);
            this.btnThemKho.TabIndex = 15;
            this.btnThemKho.Text = "Thêm";
            this.btnThemKho.Click += new System.EventHandler(this.btnThemKho_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(308, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 39);
            this.label1.TabIndex = 14;
            this.label1.Text = "Danh mục kho";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.btnSuaKho);
            this.Controls.Add(this.btnThemKho);
            this.Controls.Add(this.label1);
            this.Name = "FormKho";
            this.Size = new System.Drawing.Size(896, 112);
            this.Load += new System.EventHandler(this.FormKho_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnSuaKho;
        private DevExpress.XtraEditors.SimpleButton btnThemKho;
        private System.Windows.Forms.Label label1;
    }
}
