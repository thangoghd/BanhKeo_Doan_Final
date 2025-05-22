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
    public partial class SuaLoaiHang : Form
    {
        private string malh;
        private string tenlh;
        private string tennh;
        public SuaLoaiHang(string malh, string tenlh, string tennh)
        {
            InitializeComponent();
            this.malh = malh;
            this.tenlh = tenlh;
            this.tennh = tennh;
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SuaLoaiHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyBanBanhKeo_DoAnDataSet2.NganhHang' table. You can move, or remove it, as needed.
            this.nganhHangTableAdapter.Fill(this.quanLyBanBanhKeo_DoAnDataSet2.NganhHang);
            txtMalh.Text = malh;
            txtLh.Text = tenlh;
            foreach (DataRowView rowView in cbNganhHang.Items)
            {
                if (rowView["TenNganhHang"].ToString() == tennh)
                {
                    cbNganhHang.SelectedValue = rowView["MaNganhHang"];
                    break;
                }
            }

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

            if (txtMalh.Text.Contains(" "))
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
            string query = "UPDATE LoaiHang SET TenLoaiHang = N'" + txtLh.Text + "',MaNganhHang = '" + cbNganhHang.SelectedValue + "' WHERE MaLoaiHang = '" + txtMalh.Text + "'";


            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Sửa loại hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT MaLoaiHang, TenLoaiHang, NganhHang.TenNganhHang FROM LoaiHang INNER JOIN NganhHang ON LoaiHang.MaNganhHang = NganhHang.MaNganhHang");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cập nhật loại hàng thất bại! Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void Huy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
