namespace BanhKeo_Doan.Chuc_nang_nguoi_dung
{
    partial class BackUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackUp));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDd = new System.Windows.Forms.TextBox();
            this.btnBr = new DevExpress.XtraEditors.SimpleButton();
            this.btnBu = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường dẫn lưu file";
            // 
            // txtDd
            // 
            this.txtDd.Enabled = false;
            this.txtDd.Location = new System.Drawing.Point(125, 28);
            this.txtDd.Name = "txtDd";
            this.txtDd.Size = new System.Drawing.Size(285, 20);
            this.txtDd.TabIndex = 1;
            // 
            // btnBr
            // 
            this.btnBr.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBr.ImageOptions.SvgImage")));
            this.btnBr.Location = new System.Drawing.Point(434, 19);
            this.btnBr.Name = "btnBr";
            this.btnBr.Size = new System.Drawing.Size(92, 38);
            this.btnBr.TabIndex = 2;
            this.btnBr.Text = "Brownse";
            this.btnBr.Click += new System.EventHandler(this.btnBr_Click);
            // 
            // btnBu
            // 
            this.btnBu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBu.ImageOptions.SvgImage")));
            this.btnBu.Location = new System.Drawing.Point(209, 80);
            this.btnBu.Name = "btnBu";
            this.btnBu.Size = new System.Drawing.Size(92, 38);
            this.btnBu.TabIndex = 3;
            this.btnBu.Text = "BackUp";
            this.btnBu.Click += new System.EventHandler(this.btnBu_Click);
            // 
            // BackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 130);
            this.Controls.Add(this.btnBu);
            this.Controls.Add(this.btnBr);
            this.Controls.Add(this.txtDd);
            this.Controls.Add(this.label1);
            this.Name = "BackUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackUp";
            this.Load += new System.EventHandler(this.BackUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDd;
        private DevExpress.XtraEditors.SimpleButton btnBr;
        private DevExpress.XtraEditors.SimpleButton btnBu;
    }
}