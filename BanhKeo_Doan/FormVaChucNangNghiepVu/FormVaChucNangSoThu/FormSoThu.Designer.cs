namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangSoThu
{
    partial class FormSoThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSoThu));
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSuaSoThu = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.cbLoaiThu = new System.Windows.Forms.ComboBox();
            this.btnInSoThu = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemSoThu = new DevExpress.XtraEditors.SimpleButton();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxNgay = new System.Windows.Forms.CheckBox();
            this.checkBoxLoaiThu = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(390, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 31);
            this.label8.TabIndex = 8;
            this.label8.Text = "Sổ thu";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSuaSoThu);
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Controls.Add(this.cbLoaiThu);
            this.groupBox1.Controls.Add(this.btnInSoThu);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnThemSoThu);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBoxNgay);
            this.groupBox1.Controls.Add(this.checkBoxLoaiThu);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 129);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // btnSuaSoThu
            // 
            this.btnSuaSoThu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSuaSoThu.ImageOptions.SvgImage")));
            this.btnSuaSoThu.Location = new System.Drawing.Point(244, 71);
            this.btnSuaSoThu.Name = "btnSuaSoThu";
            this.btnSuaSoThu.Size = new System.Drawing.Size(113, 50);
            this.btnSuaSoThu.TabIndex = 12;
            this.btnSuaSoThu.Text = "Sửa";
            this.btnSuaSoThu.Click += new System.EventHandler(this.btnSuaSoThu_Click);
            // 
            // btnDong
            // 
            this.btnDong.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDong.ImageOptions.SvgImage")));
            this.btnDong.Location = new System.Drawing.Point(601, 71);
            this.btnDong.Name = "simpleButton4";
            this.btnDong.Size = new System.Drawing.Size(113, 50);
            this.btnDong.TabIndex = 11;
            this.btnDong.Text = "Đóng";
            // 
            // cbLoaiThu
            // 
            this.cbLoaiThu.FormattingEnabled = true;
            this.cbLoaiThu.Location = new System.Drawing.Point(103, 30);
            this.cbLoaiThu.Name = "cbLoaiThu";
            this.cbLoaiThu.Size = new System.Drawing.Size(182, 21);
            this.cbLoaiThu.TabIndex = 10;
            // 
            // btnInSoThu
            // 
            this.btnInSoThu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnInSoThu.ImageOptions.SvgImage")));
            this.btnInSoThu.Location = new System.Drawing.Point(482, 71);
            this.btnInSoThu.Name = "btnInSoThu";
            this.btnInSoThu.Size = new System.Drawing.Size(113, 50);
            this.btnInSoThu.TabIndex = 9;
            this.btnInSoThu.Text = "In";
            this.btnInSoThu.Click += new System.EventHandler(this.btnInSoThu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.Location = new System.Drawing.Point(363, 71);
            this.btnXoa.Name = "simpleButton3";
            this.btnXoa.Size = new System.Drawing.Size(113, 50);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            // 
            // btnThemSoThu
            // 
            this.btnThemSoThu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemSoThu.ImageOptions.SvgImage")));
            this.btnThemSoThu.Location = new System.Drawing.Point(125, 71);
            this.btnThemSoThu.Name = "btnThemSoThu";
            this.btnThemSoThu.Size = new System.Drawing.Size(113, 50);
            this.btnThemSoThu.TabIndex = 7;
            this.btnThemSoThu.Text = "Thêm";
            this.btnThemSoThu.Click += new System.EventHandler(this.btnThemSoThu_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTimKiem.ImageOptions.SvgImage")));
            this.btnTimKiem.Location = new System.Drawing.Point(6, 71);
            this.btnTimKiem.Name = "simpleButton1";
            this.btnTimKiem.Size = new System.Drawing.Size(113, 50);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(626, 30);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 5;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(387, 30);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(593, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đến";
            // 
            // checkBoxNgay
            // 
            this.checkBoxNgay.AutoSize = true;
            this.checkBoxNgay.Location = new System.Drawing.Point(301, 33);
            this.checkBoxNgay.Name = "checkBoxNgay";
            this.checkBoxNgay.Size = new System.Drawing.Size(77, 17);
            this.checkBoxNgay.TabIndex = 1;
            this.checkBoxNgay.Text = "Theo ngày";
            this.checkBoxNgay.UseVisualStyleBackColor = true;
            this.checkBoxNgay.CheckedChanged += new System.EventHandler(this.checkBoxNgay_CheckedChanged);
            // 
            // checkBoxLoaiThu
            // 
            this.checkBoxLoaiThu.AutoSize = true;
            this.checkBoxLoaiThu.Location = new System.Drawing.Point(9, 33);
            this.checkBoxLoaiThu.Name = "checkBoxLoaiThu";
            this.checkBoxLoaiThu.Size = new System.Drawing.Size(88, 17);
            this.checkBoxLoaiThu.TabIndex = 0;
            this.checkBoxLoaiThu.Text = "Theo loại thu";
            this.checkBoxLoaiThu.UseVisualStyleBackColor = true;
            this.checkBoxLoaiThu.CheckedChanged += new System.EventHandler(this.checkBoxLoaiThu_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 176);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(830, 268);
            this.dataGridView1.TabIndex = 9;
            // 
            // FormSoThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormSoThu";
            this.Text = "FormSoThu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnSuaSoThu;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private System.Windows.Forms.ComboBox cbLoaiThu;
        private DevExpress.XtraEditors.SimpleButton btnInSoThu;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnThemSoThu;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxNgay;
        private System.Windows.Forms.CheckBox checkBoxLoaiThu;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}