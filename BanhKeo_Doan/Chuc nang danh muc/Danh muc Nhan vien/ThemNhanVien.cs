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

namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Nhan_vien
{
    public partial class ThemNhanVien : Form
    {
        public ThemNhanVien()
        {
            InitializeComponent();
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTenNV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDt.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtDt.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbGioitinh.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                cbGioitinh.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCMND.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtCMND.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhuCap.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtPhuCap.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLuongcb.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtLuongcb.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTientn.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTientn.Focus();
                return false;
            }

            if (!int.TryParse(txtDt.Text, out int SDT))
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ cho số điện thoại!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtDt.Focus();
                return false;
            }

            if (!long.TryParse(txtCMND.Text, out long CMND))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho Số chứng minh nhân dân!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtCMND.Focus();
                return false;
            }

            if (!float.TryParse(txtPhuCap.Text, out float phucap))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho tiền phụ cấp!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtPhuCap.Focus();
                return false;
            }

            if (!float.TryParse(txtLuongcb.Text, out float luongcb))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho lương cơ bản!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtLuongcb.Focus();
                return false;
            }

            if (!float.TryParse(txtTientn.Text, out float tientn))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho tiền trách nhiệm!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtTientn.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtTenNV.Text, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Tên chỉ được chứa chữ cái và khoảng trắng!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtTenNV.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;

            string query = "INSERT INTO NhanVien (TenNhanVien, NgaySinh, GioiTinh, Tel, SoCMND, LuongCoBan, PhuCap, TienTrachNhiem) VALUES (N'" + txtTenNV.Text + "', '" + dtNgaysinh.Text + "', N'" + cbGioitinh.Text + "', '" + txtDt.Text + "', " + txtCMND.Text + ", " + txtLuongcb.Text + ", " + txtPhuCap.Text + ", " + txtTientn.Text + ")";

            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM NhanVien");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
