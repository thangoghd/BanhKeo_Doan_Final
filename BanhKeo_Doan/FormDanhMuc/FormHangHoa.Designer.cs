namespace BanhKeo_Doan
{
    partial class FormHangHoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHangHoa));
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.SuaHangHoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemHangHoa = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbten = new System.Windows.Forms.CheckBox();
            this.ckbloai = new System.Windows.Forms.CheckBox();
            this.txtten = new System.Windows.Forms.TextBox();
            this.txtloai = new System.Windows.Forms.TextBox();
            this.ckbLoc = new System.Windows.Forms.CheckBox();
            this.ckbLocnl = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(223, 55);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(60, 36);
            this.simpleButton3.TabIndex = 13;
            this.simpleButton3.Text = "Xóa";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // SuaHangHoa
            // 
            this.SuaHangHoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SuaHangHoa.ImageOptions.SvgImage")));
            this.SuaHangHoa.Location = new System.Drawing.Point(133, 55);
            this.SuaHangHoa.Name = "SuaHangHoa";
            this.SuaHangHoa.Size = new System.Drawing.Size(61, 36);
            this.SuaHangHoa.TabIndex = 12;
            this.SuaHangHoa.Text = "Sửa";
            this.SuaHangHoa.Click += new System.EventHandler(this.SuaHangHoa_Click);
            // 
            // btnThemHangHoa
            // 
            this.btnThemHangHoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemHangHoa.ImageOptions.SvgImage")));
            this.btnThemHangHoa.Location = new System.Drawing.Point(43, 55);
            this.btnThemHangHoa.Name = "btnThemHangHoa";
            this.btnThemHangHoa.Size = new System.Drawing.Size(68, 36);
            this.btnThemHangHoa.TabIndex = 11;
            this.btnThemHangHoa.Text = "Thêm";
            this.btnThemHangHoa.Click += new System.EventHandler(this.btnThemHangHoa_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(296, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "Danh mục hàng hóa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ckbten
            // 
            this.ckbten.AutoSize = true;
            this.ckbten.Location = new System.Drawing.Point(326, 74);
            this.ckbten.Name = "ckbten";
            this.ckbten.Size = new System.Drawing.Size(86, 17);
            this.ckbten.TabIndex = 14;
            this.ckbten.Text = "Tìm theo tên";
            this.ckbten.UseVisualStyleBackColor = true;
            this.ckbten.CheckedChanged += new System.EventHandler(this.ckbten_CheckedChanged);
            // 
            // ckbloai
            // 
            this.ckbloai.AutoSize = true;
            this.ckbloai.Location = new System.Drawing.Point(563, 74);
            this.ckbloai.Name = "ckbloai";
            this.ckbloai.Size = new System.Drawing.Size(86, 17);
            this.ckbloai.TabIndex = 15;
            this.ckbloai.Text = "Tìm theo loại";
            this.ckbloai.UseVisualStyleBackColor = true;
            this.ckbloai.CheckedChanged += new System.EventHandler(this.ckbloai_CheckedChanged);
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(418, 72);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(138, 21);
            this.txtten.TabIndex = 16;
            this.txtten.TextChanged += new System.EventHandler(this.txtten_TextChanged);
            // 
            // txtloai
            // 
            this.txtloai.Location = new System.Drawing.Point(655, 72);
            this.txtloai.Name = "txtloai";
            this.txtloai.Size = new System.Drawing.Size(138, 21);
            this.txtloai.TabIndex = 17;
            this.txtloai.TextChanged += new System.EventHandler(this.txtloai_TextChanged);
            // 
            // ckbLoc
            // 
            this.ckbLoc.AutoSize = true;
            this.ckbLoc.Location = new System.Drawing.Point(326, 51);
            this.ckbLoc.Name = "ckbLoc";
            this.ckbLoc.Size = new System.Drawing.Size(150, 17);
            this.ckbLoc.TabIndex = 18;
            this.ckbLoc.Text = "Lọc hàng hóa thành phẩm";
            this.ckbLoc.UseVisualStyleBackColor = true;
            this.ckbLoc.CheckedChanged += new System.EventHandler(this.ckbLoc_CheckedChanged);
            // 
            // ckbLocnl
            // 
            this.ckbLocnl.AutoSize = true;
            this.ckbLocnl.Location = new System.Drawing.Point(482, 51);
            this.ckbLocnl.Name = "ckbLocnl";
            this.ckbLocnl.Size = new System.Drawing.Size(150, 17);
            this.ckbLocnl.TabIndex = 19;
            this.ckbLocnl.Text = "Lọc hàng hóa thành phẩm";
            this.ckbLocnl.UseVisualStyleBackColor = true;
            this.ckbLocnl.CheckedChanged += new System.EventHandler(this.ckbLocnl_CheckedChanged);
            // 
            // FormHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ckbLocnl);
            this.Controls.Add(this.ckbLoc);
            this.Controls.Add(this.txtloai);
            this.Controls.Add(this.txtten);
            this.Controls.Add(this.ckbloai);
            this.Controls.Add(this.ckbten);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.SuaHangHoa);
            this.Controls.Add(this.btnThemHangHoa);
            this.Controls.Add(this.label1);
            this.Name = "FormHangHoa";
            this.Size = new System.Drawing.Size(896, 112);
            this.Load += new System.EventHandler(this.FormHangHoa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton SuaHangHoa;
        private DevExpress.XtraEditors.SimpleButton btnThemHangHoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbten;
        private System.Windows.Forms.CheckBox ckbloai;
        private System.Windows.Forms.TextBox txtten;
        private System.Windows.Forms.TextBox txtloai;
        private System.Windows.Forms.CheckBox ckbLoc;
        private System.Windows.Forms.CheckBox ckbLocnl;
    }
}
