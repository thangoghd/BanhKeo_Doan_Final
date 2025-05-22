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
using DevExpress.Utils.Drawing.Helpers;

namespace BanhKeo_Doan.Chuc_nang_danh_muc
{
    public partial class SuaKhachHang : Form
    {
        private string maKH;
        private string tenKH;
        private string ngaysinh;
        private string diachi;
        private string dt;
        private string mst;
        private string stk;
        private string tenNH;
        private string dcNH;
        private string nocu;
        public SuaKhachHang(string maKH, string tenKH, string ngaysinh, string diachi, string dt, string mst, string stk, string tenNH, string dcNH, string nocu)
        {
            InitializeComponent();
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.ngaysinh = ngaysinh;
            this.diachi = diachi;
            this.dt = dt;
            this.mst = mst;
            this.stk = stk;
            this.tenNH = tenNH;
            this.dcNH = dcNH;
            this.nocu = nocu;
        }

        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtTenKh.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTenKh.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDc.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtDc.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDt.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtDt.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMST.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtMST.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSTK.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtSTK.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDcNh.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtDcNh.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenNh.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTenNh.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNocu.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtNocu.Focus();
                return false;
            }

            if (txtMST.Text.Contains(" "))
            {
                MessageBox.Show("Vui lòng không để khoảng trắng!", "Thông báo", MessageBoxButtons.OK);
                txtMST.Focus();
                return false;
            }

            if (txtSTK.Text.Contains(" "))
            {
                MessageBox.Show("Vui lòng không để khoảng trắng!", "Thông báo", MessageBoxButtons.OK);
                txtSTK.Focus();
                return false;
            }

            if (txtNocu.Text.Contains(" "))
            {
                MessageBox.Show("Vui lòng không để khoảng trắng!", "Thông báo", MessageBoxButtons.OK);
                txtNocu.Focus();
                return false;
            }
            if (!int.TryParse(txtDt.Text, out int SDT))
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ cho số điện thoại!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtDt.Focus();
                return false;
            }

            if (!long.TryParse(txtMST.Text, out long MST))
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ cho mã số thuế!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtMST.Focus();
                return false;
            }

            if (!long.TryParse(txtSTK.Text, out long STK))
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ cho số tài khoản!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtSTK.Focus();
                return false;
            }

            if (!float.TryParse(txtNocu.Text, out float Nocu))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho nợ cũ!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtNocu.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtTenKh.Text, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Tên chỉ được chứa chữ cái và khoảng trắng!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtTenKh.Focus();
                return false;
            }
            return true;
        }
        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;

            string query = "UPDATE KhachHang SET TenKhachHang = N'" + txtTenKh.Text + "', NgaySinh = '" + dtNgaysinh.Text + "', DiaChi = N'" + txtDc.Text + "', Tel = '" + txtDt.Text + "', MaSoThue = '" + txtMST.Text + "', SoTaiKhoan = '" + txtSTK.Text + "', TenNganHang = N'" + txtTenNh.Text + "', DiaChiNganHang = N'" + txtDcNh.Text + "', NoCu = '" + txtNocu.Text + "' WHERE MaKhachHang = '" + txtMaKH.Text + "'";
            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Sửa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM KhachHang");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa khách hàng thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void SuaKhachHang_Load(object sender, EventArgs e)
        {
            txtMaKH.Text = maKH;
            txtTenKh.Text = tenKH;
            dtNgaysinh.Text = ngaysinh;
            txtDc.Text = diachi;
            txtDt.Text = dt;
            txtMST.Text = mst;
            txtSTK.Text = stk;
            txtTenNh.Text = tenNH;
            txtDcNh.Text = dcNH;
            txtNocu.Text = nocu;
        }
    }
}
