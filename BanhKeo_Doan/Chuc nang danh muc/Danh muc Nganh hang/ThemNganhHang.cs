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

namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Nganh_hang
{
    public partial class ThemNganhHang : Form
    {
        public ThemNganhHang()
        {
            InitializeComponent();
        }

        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtTennh.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTennh.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtTennh.Text, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Tên chỉ được chứa chữ cái và khoảng trắng!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtTennh.Focus();
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;

            string query = "INSERT INTO NganhHang (TenNganhHang) VALUES (N'" + txtTennh.Text + "')";

            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Thêm ngành hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM NganhHang");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm ngành hàng thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
