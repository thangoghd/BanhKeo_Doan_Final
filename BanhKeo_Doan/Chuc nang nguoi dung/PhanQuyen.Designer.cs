namespace BanhKeo_Doan.Chuc_nang_nguoi_dung
{
    partial class PhanQuyen
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtcn = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtqh = new System.Windows.Forms.DataGridView();
            this.btnThemQ = new System.Windows.Forms.Button();
            this.btnXoaQ = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMacn = new System.Windows.Forms.TextBox();
            this.txtTencn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaqh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbnd = new System.Windows.Forms.ComboBox();
            this.nguoiDungBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyBanBanhKeo_DoAnDataSet = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSet();
            this.nguoiDungTableAdapter = new BanhKeo_Doan.QuanLyBanBanhKeo_DoAnDataSetTableAdapters.NguoiDungTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtcn)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtqh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nguoiDungBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtcn);
            this.groupBox1.Location = new System.Drawing.Point(11, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 288);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng hệ thống";
            // 
            // dtcn
            // 
            this.dtcn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtcn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtcn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtcn.Location = new System.Drawing.Point(3, 16);
            this.dtcn.Name = "dtcn";
            this.dtcn.Size = new System.Drawing.Size(344, 269);
            this.dtcn.TabIndex = 0;
            this.dtcn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtcn_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dtqh);
            this.groupBox2.Location = new System.Drawing.Point(448, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 288);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quyền hạn người dùng";
            // 
            // dtqh
            // 
            this.dtqh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtqh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtqh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtqh.Location = new System.Drawing.Point(3, 16);
            this.dtqh.Name = "dtqh";
            this.dtqh.Size = new System.Drawing.Size(344, 269);
            this.dtqh.TabIndex = 1;
            this.dtqh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtqh_CellClick);
            // 
            // btnThemQ
            // 
            this.btnThemQ.Location = new System.Drawing.Point(367, 155);
            this.btnThemQ.Name = "btnThemQ";
            this.btnThemQ.Size = new System.Drawing.Size(75, 23);
            this.btnThemQ.TabIndex = 2;
            this.btnThemQ.Text = ">>";
            this.btnThemQ.UseVisualStyleBackColor = true;
            this.btnThemQ.Click += new System.EventHandler(this.btnThemQ_Click);
            // 
            // btnXoaQ
            // 
            this.btnXoaQ.Location = new System.Drawing.Point(367, 291);
            this.btnXoaQ.Name = "btnXoaQ";
            this.btnXoaQ.Size = new System.Drawing.Size(75, 23);
            this.btnXoaQ.TabIndex = 3;
            this.btnXoaQ.Text = "<<";
            this.btnXoaQ.UseVisualStyleBackColor = true;
            this.btnXoaQ.Click += new System.EventHandler(this.btnXoaQ_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã chức năng";
            // 
            // txtMacn
            // 
            this.txtMacn.Enabled = false;
            this.txtMacn.Location = new System.Drawing.Point(94, 27);
            this.txtMacn.Name = "txtMacn";
            this.txtMacn.Size = new System.Drawing.Size(170, 20);
            this.txtMacn.TabIndex = 5;
            // 
            // txtTencn
            // 
            this.txtTencn.Enabled = false;
            this.txtTencn.Location = new System.Drawing.Point(352, 27);
            this.txtTencn.Name = "txtTencn";
            this.txtTencn.Size = new System.Drawing.Size(170, 20);
            this.txtTencn.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên chức năng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(528, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tên người dùng";
            // 
            // txtMaqh
            // 
            this.txtMaqh.Enabled = false;
            this.txtMaqh.Location = new System.Drawing.Point(610, 56);
            this.txtMaqh.Name = "txtMaqh";
            this.txtMaqh.Size = new System.Drawing.Size(170, 20);
            this.txtMaqh.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(528, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mã quyền hạn";
            // 
            // cbnd
            // 
            this.cbnd.DataSource = this.nguoiDungBindingSource;
            this.cbnd.DisplayMember = "TenNguoiDung";
            this.cbnd.FormattingEnabled = true;
            this.cbnd.Location = new System.Drawing.Point(610, 26);
            this.cbnd.Name = "cbnd";
            this.cbnd.Size = new System.Drawing.Size(169, 21);
            this.cbnd.TabIndex = 12;
            this.cbnd.ValueMember = "MaNguoiDung";
            this.cbnd.SelectedIndexChanged += new System.EventHandler(this.cbnd_SelectedIndexChanged);
            // 
            // nguoiDungBindingSource
            // 
            this.nguoiDungBindingSource.DataMember = "NguoiDung";
            this.nguoiDungBindingSource.DataSource = this.quanLyBanBanhKeo_DoAnDataSet;
            // 
            // quanLyBanBanhKeo_DoAnDataSet
            // 
            this.quanLyBanBanhKeo_DoAnDataSet.DataSetName = "QuanLyBanBanhKeo_DoAnDataSet";
            this.quanLyBanBanhKeo_DoAnDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nguoiDungTableAdapter
            // 
            this.nguoiDungTableAdapter.ClearBeforeFill = true;
            // 
            // PhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 399);
            this.Controls.Add(this.cbnd);
            this.Controls.Add(this.txtMaqh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTencn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMacn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXoaQ);
            this.Controls.Add(this.btnThemQ);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PhanQuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhanQuyen";
            this.Load += new System.EventHandler(this.PhanQuyen_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtcn)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtqh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nguoiDungBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanBanhKeo_DoAnDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtcn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtqh;
        private System.Windows.Forms.Button btnThemQ;
        private System.Windows.Forms.Button btnXoaQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMacn;
        private System.Windows.Forms.TextBox txtTencn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaqh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbnd;
        private QuanLyBanBanhKeo_DoAnDataSet quanLyBanBanhKeo_DoAnDataSet;
        private System.Windows.Forms.BindingSource nguoiDungBindingSource;
        private QuanLyBanBanhKeo_DoAnDataSetTableAdapters.NguoiDungTableAdapter nguoiDungTableAdapter;
    }
}