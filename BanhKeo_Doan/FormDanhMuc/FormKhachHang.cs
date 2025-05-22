using BanhKeo_Doan.Chuc_nang_danh_muc;
using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Khach_hang;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan
{
    public partial class FormKhachHang : DevExpress.XtraEditors.XtraUserControl
    {
        public FormKhachHang()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SuaKhachHang_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string maKH = selectedRow.Cells["MaKhachHang"].Value.ToString();
            string tenKH = selectedRow.Cells["TenKhachHang"].Value.ToString();
            string ngaysinh = selectedRow.Cells["NgaySinh"].Value.ToString();
            string diachi = selectedRow.Cells["DiaChi"].Value.ToString();
            string dt = selectedRow.Cells["Tel"].Value.ToString();
            string mst = selectedRow.Cells["MaSoThue"].Value.ToString();
            string stk = selectedRow.Cells["SoTaiKhoan"].Value.ToString();
            string tenNH = selectedRow.Cells["TenNganHang"].Value.ToString();
            string dcNH = selectedRow.Cells["DiaChiNganHang"].Value.ToString();
            string nocu = selectedRow.Cells["NoCu"].Value.ToString();

            SuaKhachHang suaKhachHang = new SuaKhachHang(maKH, tenKH, ngaysinh, diachi, dt, mst, stk, tenNH, dcNH, nocu);
            suaKhachHang.Show();
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            ThemKhachHang themKhachHang = new ThemKhachHang();
            themKhachHang.Show();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            ckbTen.Checked = true; 
            ckbsdt.Checked = false;

            txtTen.Enabled = true;
            txtSDT.Enabled = false;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string maKH = selectedRow.Cells["MaKhachHang"].Value.ToString();
            if (MessageBox.Show("Bạn có chắc muốn xóa thông tin khách hàng", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM KhachHang WHERE MaKhachHang = '" + maKH + "'";

                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    ketnoiCSDL.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                    ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM KhachHang");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thông tin khách hàng thất bại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!");
            }
        }

        private void ckbTen_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTen.Checked)
            {
                txtTen.Enabled = true;
                txtSDT.Enabled = false;
                txtSDT.Clear();
                ckbsdt.Checked = false;
            }
        }

        private void ckbsdt_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbsdt.Checked)
            {
                txtSDT.Enabled = true;
                txtTen.Enabled = false;
                txtTen.Clear();
                ckbTen.Checked = false;
            }
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM KhachHang WHERE TenKhachHang LIKE N'%" + txtTen.Text.Trim() + "%'";
            ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView(query);
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM KhachHang WHERE Tel LIKE '%" + txtSDT.Text.Trim() + "%'";
            ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView(query);
        }
    }
}
