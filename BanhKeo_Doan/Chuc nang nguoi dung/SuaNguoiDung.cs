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
    public partial class SuaNguoiDung : Form
    {
        private string mand;
        private string tennd;
        private string tendn;
        private string cv;
        private string mk;
        public SuaNguoiDung(string mand, string tennd, string tendn, string cv, string mk)
        {
            InitializeComponent();
            this.mand = mand;
            this.tennd = tennd;
            this.tendn = tendn;
            this.cv = cv;
            this.mk = mk;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
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

            string query = "UPDATE NguoiDung SET TenNguoiDung = N'" + txtTen.Text + "',TenDangNhap = '" + txtTk.Text + "',ChucVu = N'" + txtQuyen.Text + "',MatKhau = '" + txtMk.Text + "' WHERE MaNguoiDung = '" + txtMa.Text + "'";

            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Sửa người dùng thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM NguoiDung");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa người dùng thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SuaNguoiDung_Load(object sender, EventArgs e)
        {
            txtMa.Text = mand;
            txtTk.Text = tendn;
            txtTen.Text = tennd;
            txtQuyen.Text = cv;
            txtMk.Text = mk;
        }
    }
}
