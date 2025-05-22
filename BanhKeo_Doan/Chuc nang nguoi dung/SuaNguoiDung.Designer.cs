namespace BanhKeo_Doan.Chuc_nang_nguoi_dung
{
    partial class SuaNguoiDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuaNguoiDung));
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Huy
            // 
            this.Huy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Huy.ImageOptions.SvgImage")));
            this.Huy.Location = new System.Drawing.Point(230, 207);
            this.Huy.Name = "Huy";
            this.Huy.Size = new System.Drawing.Size(126, 45);
            this.Huy.TabIndex = 32;
            this.Huy.Text = "Hủy bỏ";
            this.Huy.Click += new System.EventHandler(this.Huy_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(33, 207);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(126, 45);
            this.simpleButton1.TabIndex = 31;
            this.simpleButton1.Text = "Chấp nhận";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Chức vụ";
            // 
            // txtQuyen
            // 
            this.txtQuyen.Location = new System.Drawing.Point(103, 165);
            this.txtQuyen.Name = "txtQuyen";
            this.txtQuyen.Size = new System.Drawing.Size(273, 20);
            this.txtQuyen.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Mật khẩu";
            // 
            // txtMk
            // 
            this.txtMk.Location = new System.Drawing.Point(103, 125);
            this.txtMk.Name = "txtMk";
            this.txtMk.Size = new System.Drawing.Size(273, 20);
            this.txtMk.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tên đầy đủ";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(103, 88);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(273, 20);
            this.txtTen.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tên đăng nhập";
            // 
            // txtTk
            // 
            this.txtTk.Location = new System.Drawing.Point(103, 53);
            this.txtTk.Name = "txtTk";
            this.txtTk.Size = new System.Drawing.Size(273, 20);
            this.txtTk.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Mã người dùng";
            // 
            // txtMa
            // 
            this.txtMa.Enabled = false;
            this.txtMa.Location = new System.Drawing.Point(103, 17);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(273, 20);
            this.txtMa.TabIndex = 33;
            // 
            // SuaNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 266);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMa);
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
            this.Name = "SuaNguoiDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuaNguoiDung";
            this.Load += new System.EventHandler(this.SuaNguoiDung_Load);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMa;
    }
}