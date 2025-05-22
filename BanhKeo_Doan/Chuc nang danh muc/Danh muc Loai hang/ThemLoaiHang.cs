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

namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Loai_hang
{
    public partial class ThemLoaiHang : Form
    {
        public ThemLoaiHang()
        {
            InitializeComponent();
        }

        private void ThemLoaiHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyBanBanhKeo_DoAnDataSet1.NganhHang' table. You can move, or remove it, as needed.
            this.nganhHangTableAdapter.Fill(this.quanLyBanBanhKeo_DoAnDataSet1.NganhHang);

        }

        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtMalh.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtMalh.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLh.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtLh.Focus();
                return false;
            }

            if(txtMalh.Text.Contains(" "))
            {
                MessageBox.Show("Vui lòng không để khoảng trắng!", "Thông báo", MessageBoxButtons.OK);
                txtMalh.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtLh.Text, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Tên chỉ được chứa chữ cái và khoảng trắng!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtLh.Focus();
                return false;
            }
            return true;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;
            string query = "INSERT INTO LoaiHang (MaLoaiHang, TenLoaiHang, MaNganhHang) VALUES ('" + txtMalh.Text + "', N'" + txtLh.Text + "', " + cbNganhHang.SelectedValue + ")";


            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Thêm loại hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT MaLoaiHang, TenLoaiHang, NganhHang.TenNganhHang FROM LoaiHang INNER JOIN NganhHang ON LoaiHang.MaNganhHang = NganhHang.MaNganhHang");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm loại hàng thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
