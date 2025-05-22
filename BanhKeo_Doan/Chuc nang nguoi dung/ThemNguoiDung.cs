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

namespace BanhKeo_Doan.Chuc_nang_nguoi_dung
{
    public partial class ThemNguoiDung : Form
    {
        public ThemNguoiDung()
        {
            InitializeComponent();
        }
        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtTk.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTk.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMk.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtMk.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtQuyen.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtQuyen.Focus();
                return false;
            }

            if (txtMk.Text.Contains(" "))
            {
                MessageBox.Show("Vui lòng không để khoảng trắng!", "Thông báo", MessageBoxButtons.OK);
                txtMk.Focus();
                return false;
            }

            if (txtTk.Text.Contains(" "))
            {
                MessageBox.Show("Vui lòng không để khoảng trắng!", "Thông báo", MessageBoxButtons.OK);
                txtTk.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtTen.Text, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Tên chỉ được chứa chữ cái và khoảng trắng!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }
            return true;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;

            string query = "INSERT INTO NguoiDung (TenNguoiDung, TenDangNhap, ChucVu, MatKhau) VALUES (N'" + txtTen.Text + "', '" + txtTk.Text + "', N'" + txtQuyen.Text + "', '" + txtMk.Text + "')";

            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM NguoiDung");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm người dùng thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
