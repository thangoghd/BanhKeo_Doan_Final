namespace BanhKeo_Doan
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMk = new System.Windows.Forms.TextBox();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.txtDn = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // txtTk
            // 
            this.txtTk.Location = new System.Drawing.Point(105, 26);
            this.txtTk.Name = "txtTk";
            this.txtTk.Size = new System.Drawing.Size(229, 20);
            this.txtTk.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu";
            // 
            // txtMk
            // 
            this.txtMk.Location = new System.Drawing.Point(105, 66);
            this.txtMk.Name = "txtMk";
            this.txtMk.PasswordChar = '*';
            this.txtMk.Size = new System.Drawing.Size(229, 20);
            this.txtMk.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(203, 115);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 40);
            this.btnThoat.TabIndex = 18;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtDn
            // 
            this.txtDn.Location = new System.Drawing.Point(51, 115);
            this.txtDn.Name = "txtDn";
            this.txtDn.Size = new System.Drawing.Size(104, 40);
            this.txtDn.TabIndex = 17;
            this.txtDn.Text = "Đăng nhập";
            this.txtDn.Click += new System.EventHandler(this.txtDn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 182);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.txtDn);
            this.Controls.Add(this.txtMk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTk);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMk;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton txtDn;
    }
}

