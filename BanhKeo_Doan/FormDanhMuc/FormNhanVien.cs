using BanhKeo_Doan.Chuc_nang_danh_muc;
using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Nhan_vien;
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
    public partial class FormNhanVien : DevExpress.XtraEditors.XtraUserControl
    {
        public FormNhanVien()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void btnSuaNhanVien_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();
            string maNV = selectedRow.Cells["MaNhanVien"].Value.ToString();
            string tenNV = selectedRow.Cells["TenNhanVien"].Value.ToString();
            string ngaysinh = selectedRow.Cells["NgaySinh"].Value.ToString();
            string gioitinh = selectedRow.Cells["GioiTinh"].Value.ToString();
            string dt = selectedRow.Cells["Tel"].Value.ToString();
            string soCMND = selectedRow.Cells["SoCMND"].Value.ToString();
            string luongcb = selectedRow.Cells["LuongCoBan"].Value.ToString();
            string phucap = selectedRow.Cells["PhuCap"].Value.ToString();
            string tientn = selectedRow.Cells["TienTrachNhiem"].Value.ToString();

            SuaNhanVien suaNhanVien = new SuaNhanVien(maNV, tenNV, ngaysinh, gioitinh, dt, soCMND, luongcb, phucap, tientn);
            suaNhanVien.Show();
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            ThemNhanVien themNhanVien = new ThemNhanVien();
            themNhanVien.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string maNV = selectedRow.Cells["MaNhanVien"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này không!", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM NhanVien WHERE MaNhanVien = '" + maNV + "'";

                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    ketnoiCSDL.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
                    ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM NhanVien");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!");
            }
        }
    }
}
