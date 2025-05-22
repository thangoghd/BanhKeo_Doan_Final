namespace BanhKeo_Doan
{
    partial class FormNCC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNCC));
            this.label1 = new System.Windows.Forms.Label();
            this.btnThemNCC = new DevExpress.XtraEditors.SimpleButton();
            this.btnSuaNCC = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.txtTimTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(281, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh mục nhà cung cấp";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnThemNCC
            // 
            this.btnThemNCC.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemNCC.ImageOptions.SvgImage")));
            this.btnThemNCC.Location = new System.Drawing.Point(28, 65);
            this.btnThemNCC.Name = "btnThemNCC";
            this.btnThemNCC.Size = new System.Drawing.Size(68, 36);
            this.btnThemNCC.TabIndex = 1;
            this.btnThemNCC.Text = "Thêm";
            this.btnThemNCC.Click += new System.EventHandler(this.btnThemNCC_Click);
            // 
            // btnSuaNCC
            // 
            this.btnSuaNCC.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSuaNCC.ImageOptions.SvgImage")));
            this.btnSuaNCC.Location = new System.Drawing.Point(118, 65);
            this.btnSuaNCC.Name = "btnSuaNCC";
            this.btnSuaNCC.Size = new System.Drawing.Size(61, 36);
            this.btnSuaNCC.TabIndex = 2;
            this.btnSuaNCC.Text = "Sửa";
            this.btnSuaNCC.Click += new System.EventHandler(this.btnSuaNCC_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(208, 65);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(60, 36);
            this.simpleButton3.TabIndex = 3;
            this.simpleButton3.Text = "Xóa";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // txtTimTen
            // 
            this.txtTimTen.Location = new System.Drawing.Point(420, 73);
            this.txtTimTen.Name = "txtTimTen";
            this.txtTimTen.Size = new System.Drawing.Size(147, 21);
            this.txtTimTen.TabIndex = 4;
            this.txtTimTen.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(314, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tìm nhà cung cấp";
            // 
            // FormNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTimTen);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.btnSuaNCC);
            this.Controls.Add(this.btnThemNCC);
            this.Controls.Add(this.label1);
            this.Name = "FormNCC";
            this.Size = new System.Drawing.Size(896, 112);
            this.Load += new System.EventHandler(this.FormNCC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnThemNCC;
        private DevExpress.XtraEditors.SimpleButton btnSuaNCC;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private System.Windows.Forms.TextBox txtTimTen;
        private System.Windows.Forms.Label label2;
    }
}
