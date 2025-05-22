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

namespace BanhKeo_Doan.Chuc_nang_danh_muc
{
    public partial class SuaNhanVien : Form
    {
        private string maNV;
        private string tenNV;
        private string ngaysinh;
        private string gioitinh;
        private string dt;
        private string soCMND;
        private string luongcb;
        private string phucap;
        private string tientn;
        public SuaNhanVien(string maNV, string tenNV, string ngaysinh, string gioitinh, string dt, string soCMND, string luongcb, string phucap, string tientn)
        {
            InitializeComponent();
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.dt = dt;
            this.soCMND = soCMND;
            this.luongcb = luongcb;
            this.phucap = phucap;
            this.tientn = tientn;
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
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;

            string query = "UPDATE NhanVien SET TenNhanVien = N'" + txtTenNV.Text + "', NgaySinh = '" + dtNgaysinh.Text + "', GioiTinh = N'" + cbGioitinh.Text + "', Tel = '" + txtDt.Text + "', SoCMND = '" + txtCMND.Text + "', LuongCoBan = '" + txtLuongcb.Text + "', PhuCap = '" + txtPhuCap.Text + "', TienTrachNhiem = '" + txtTientn.Text + "' WHERE MaNhanVien = '" + txtMaNV.Text + "'";

            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Sửa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM NhanVien");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void SuaNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = maNV;
            txtTenNV.Text = tenNV;
            dtNgaysinh.Text = ngaysinh;
            cbGioitinh.Text = gioitinh;
            txtDt.Text = dt;
            txtCMND.Text = soCMND;
            txtLuongcb.Text = luongcb;
            txtPhuCap.Text = phucap;
            txtTientn.Text = tientn;
        }
    }
}
