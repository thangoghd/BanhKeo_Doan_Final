namespace BanhKeo_Doan.Chuc_nang_nguoi_dung
{
    partial class ThemNguoiDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemNguoiDung));
            this.Huy = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuyen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTk = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Huy
            // 
            this.Huy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Huy.ImageOptions.SvgImage")));
            this.Huy.Location = new System.Drawing.Point(226, 182);
            this.Huy.Name = "Huy";
            this.Huy.Size = new System.Drawing.Size(126, 45);
            this.Huy.TabIndex = 22;
            this.Huy.Text = "Hủy bỏ";
            this.Huy.Click += new System.EventHandler(this.Huy_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(29, 182);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(126, 45);
            this.simpleButton1.TabIndex = 21;
            this.simpleButton1.Text = "Chấp nhận";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Chức vụ";
            // 
            // txtQuyen
            // 
            this.txtQuyen.Location = new System.Drawing.Point(99, 140);
            this.txtQuyen.Name = "txtQuyen";
            this.txtQuyen.Size = new System.Drawing.Size(273, 20);
            this.txtQuyen.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Mật khẩu";
            // 
            // txtMk
            // 
            this.txtMk.Location = new System.Drawing.Point(99, 100);
            this.txtMk.Name = "txtMk";
            this.txtMk.Size = new System.Drawing.Size(273, 20);
            this.txtMk.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tên đầy đủ";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(99, 63);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(273, 20);
            this.txtTen.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Tên đăng nhập";
            // 
            // txtTk
            // 
            this.txtTk.Location = new System.Drawing.Point(99, 28);
            this.txtTk.Name = "txtTk";
            this.txtTk.Size = new System.Drawing.Size(273, 20);
            this.txtTk.TabIndex = 13;
            // 
            // ThemNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 243);
            this.Controls.Add(this.Huy);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtQuyen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTk);
            this.Name = "ThemNguoiDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThemNguoiDung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Huy;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQuyen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTk;
    }
}