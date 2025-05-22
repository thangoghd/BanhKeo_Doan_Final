using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.Chuc_nang_danh_muc
{
    public partial class Sua_NCC : Form
    {
        private string maNCC;
        private string tenNCC;
        private string diaChi;
        private string tel;
        private string maSoThue;
        private string soTaiKhoan;
        private string tenNganHang;
        private string diaChiNganHang;
        private string noCu;
        public Sua_NCC(string maNCC, string tenNCC, string diaChi, string tel, string maSoThue, string soTaiKhoan, string tenNganHang, string diaChiNganHang, string noCu)
        {
            InitializeComponent();
            this.maNCC = maNCC;
            this.tenNCC = tenNCC;
            this.diaChi = diaChi;
            this.tel = tel;
            this.maSoThue = maSoThue;
            this.soTaiKhoan = soTaiKhoan;
            this.tenNganHang = tenNganHang;
            this.diaChiNganHang = diaChiNganHang;
            this.noCu = noCu;
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sua_NCC_Load(object sender, EventArgs e)
        {
            txtMaNCC.Text = maNCC;
            txtTenNCC.Text = tenNCC;
            txtDc.Text = diaChi;
            txtDt.Text = tel;
            txtMST.Text = maSoThue;
            txtSTK.Text = soTaiKhoan;
            txtTenNH.Text = tenNganHang;
            txtDcNH.Text = diaChiNganHang;
            txtNocu.Text = noCu;
        }

        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTenNCC.Focus();
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

            if (string.IsNullOrWhiteSpace(txtDcNH.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtDcNH.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenNH.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTenNH.Focus();
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
            return true;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;
            string query = "UPDATE NhaCungCap SET TenNhaCungCap = N'" + txtTenNCC.Text + "', DiaChi = N'" + txtDc.Text + "', Tel = '" + txtDt.Text + "', MaSoThue = '" + txtMST.Text + "', SoTaiKhoan = '" + txtSTK.Text + "', TenNganHang = N'" + txtTenNH.Text + "', DiaChiNganHang = N'" + txtDcNH.Text + "', NoCu = '" + txtNocu.Text + "' WHERE MaNhaCungCap = '" + txtMaNCC.Text + "'";
            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Sửa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM NhaCungCap");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thông tin thất bại", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void Huy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
