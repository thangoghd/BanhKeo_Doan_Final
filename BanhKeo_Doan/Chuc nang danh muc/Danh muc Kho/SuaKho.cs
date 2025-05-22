using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Kho;

namespace BanhKeo_Doan.Chuc_nang_danh_muc
{
    public partial class SuaKho : Form
    {
        private string maKho;
        private string tenKho;
        public SuaKho(string maKho, string tenKho)
        {
            InitializeComponent();
            this.maKho = maKho;
            this.tenKho = tenKho;
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtTenkho.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTenkho.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtTenkho.Text, @"^[\p{L}\d\s]+$"))
            {
                MessageBox.Show("Tên chỉ được chứa chữ cái và khoảng trắng!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtTenkho.Focus();
                return false;
            }
            return true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;

            string query = "UPDATE Kho SET TenKho = N'" + txtTenkho.Text + "' WHERE MaKho = '" + txtMakho.Text + "'";

            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Sửa kho thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM Kho");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa kho thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void SuaKho_Load(object sender, EventArgs e)
        {
            txtMakho.Text = maKho;
            txtTenkho.Text = tenKho;
        }
    }
}
