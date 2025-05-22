using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_NCC
{
    public partial class ThemNCC : Form
    {
        public ThemNCC()
        {
            InitializeComponent();
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;

            string query = "INSERT INTO NhaCungCap (TenNhaCungCap, DiaChi, Tel, MaSoThue, SoTaiKhoan, TenNganHang, DiaChiNganHang, NoCu) " +
               "VALUES (N'" + txtTenNCC.Text + "', N'" + txtDc.Text + "', '" + txtDt.Text + "', " + txtMST.Text + ", " + txtSTK.Text + ", N'" + txtTenNH.Text + "', N'" + txtDcNH.Text + "', " + txtNocu.Text + ")";
            try
            {

                // Sử dụng KetNoiCSDL để thực thi truy vấn
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);  // Gọi phương thức ExecuteNonQuery từ KetNoiCSDL
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM NhaCungCap");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtNocu_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtDcNH_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtTenNH_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtSTK_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtDt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtMST_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTenNCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMaNCC_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
