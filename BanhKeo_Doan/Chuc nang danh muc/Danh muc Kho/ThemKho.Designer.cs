namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Kho
{
    partial class ThemKho
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemKho));
            this.Huy = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMakho = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenkho = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Huy
            // 
            this.Huy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Huy.ImageOptions.SvgImage")));
            this.Huy.Location = new System.Drawing.Point(254, 130);
            this.Huy.Name = "Huy";
            this.Huy.Size = new System.Drawing.Size(100, 45);
            this.Huy.TabIndex = 122;
            this.Huy.Text = "Hủy bỏ";
            this.Huy.Click += new System.EventHandler(this.Huy_Click);
            // 
            // btnThem
            // 
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Location = new System.Drawing.Point(43, 130);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 45);
            this.btnThem.TabIndex = 121;
            this.btnThem.Text = "Chấp nhận";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 120;
            this.label2.Text = "Mã kho";
            // 
            // txtMakho
            // 
            this.txtMakho.Enabled = false;
            this.txtMakho.Location = new System.Drawing.Point(107, 35);
            this.txtMakho.Name = "txtMakho";
            this.txtMakho.Size = new System.Drawing.Size(247, 20);
            this.txtMakho.TabIndex = 119;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 124;
            this.label1.Text = "Tên kho";
            // 
            // txtTenkho
            // 
            this.txtTenkho.Location = new System.Drawing.Point(107, 76);
            this.txtTenkho.Name = "txtTenkho";
            this.txtTenkho.Size = new System.Drawing.Size(247, 20);
            this.txtTenkho.TabIndex = 123;
            // 
            // ThemKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 198);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenkho);
            this.Controls.Add(this.Huy);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMakho);
            this.Name = "ThemKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThemKho";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Huy;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMakho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenkho;
    }
}