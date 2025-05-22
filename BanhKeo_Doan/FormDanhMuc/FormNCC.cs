using BanhKeo_Doan.Chuc_nang_danh_muc;
using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_NCC;
using BanhKeo_Doan.Chuc_nang_nguoi_dung;
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
    public partial class FormNCC : DevExpress.XtraEditors.XtraUserControl
    {
        public FormNCC()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();
            string maNCC = selectedRow.Cells["MaNhaCungCap"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM NhaCungCap WHERE MaNhaCungCap = '" + maNCC + "'";
                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    ketnoiCSDL.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK);
                    ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM NhaCungCap");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa nhà cung cấp thất bại", "Lỗi", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!");
            }
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string maNCC = selectedRow.Cells["MaNhaCungCap"].Value.ToString();
            string tenNCC = selectedRow.Cells["TenNhaCungCap"].Value.ToString();
            string diaChi = selectedRow.Cells["DiaChi"].Value.ToString();
            string tel = selectedRow.Cells["Tel"].Value.ToString();
            string maSoThue = selectedRow.Cells["MaSoThue"].Value.ToString();
            string soTaiKhoan = selectedRow.Cells["SoTaiKhoan"].Value.ToString();
            string tenNganHang = selectedRow.Cells["TenNganHang"].Value.ToString();
            string diaChiNganHang = selectedRow.Cells["DiaChiNganHang"].Value.ToString();
            string noCu = selectedRow.Cells["NoCu"].Value.ToString();
            Sua_NCC suaNCC = new Sua_NCC(maNCC, tenNCC, diaChi, tel, maSoThue, soTaiKhoan, tenNganHang, diaChiNganHang, noCu);
            suaNCC.Show();
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            ThemNCC themNCC = new ThemNCC();
            themNCC.Show();
        }

        private void FormNCC_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM NhaCungCap WHERE TenNhaCungCap LIKE N'%" + txtTimTen.Text.Trim() + "%'";
            ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView(query);
        }
    }
}
