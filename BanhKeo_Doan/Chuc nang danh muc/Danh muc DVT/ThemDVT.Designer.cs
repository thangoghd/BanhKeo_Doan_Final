namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_DVT
{
    partial class ThemDVT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemDVT));
            this.Huy = new DevExpress.XtraEditors.SimpleButton();
            this.btn = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMadvt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTendvt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Huy
            // 
            this.Huy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Huy.ImageOptions.SvgImage")));
            this.Huy.Location = new System.Drawing.Point(195, 129);
            this.Huy.Name = "Huy";
            this.Huy.Size = new System.Drawing.Size(100, 45);
            this.Huy.TabIndex = 106;
            this.Huy.Text = "Hủy bỏ";
            this.Huy.Click += new System.EventHandler(this.Huy_Click);
            // 
            // btn
            // 
            this.btn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn.ImageOptions.SvgImage")));
            this.btn.Location = new System.Drawing.Point(40, 129);
            this.btn.Name = "btnThem";
            this.btn.Size = new System.Drawing.Size(100, 45);
            this.btn.TabIndex = 105;
            this.btn.Text = "Chấp nhận";
            this.btn.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "Mã đơn vị tính";
            // 
            // txtMadvt
            // 
            this.txtMadvt.Enabled = false;
            this.txtMadvt.Location = new System.Drawing.Point(142, 45);
            this.txtMadvt.Name = "txtMadvt";
            this.txtMadvt.Size = new System.Drawing.Size(153, 20);
            this.txtMadvt.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 108;
            this.label1.Text = "Tên đơn vị tính";
            // 
            // txtTendvt
            // 
            this.txtTendvt.Location = new System.Drawing.Point(142, 81);
            this.txtTendvt.Name = "txtTendvt";
            this.txtTendvt.Size = new System.Drawing.Size(153, 20);
            this.txtTendvt.TabIndex = 107;
            // 
            // ThemDVT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 186);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTendvt);
            this.Controls.Add(this.Huy);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMadvt);
            this.Name = "ThemDVT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThemDVT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Huy;
        private DevExpress.XtraEditors.SimpleButton btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMadvt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTendvt;
    }
}