using BanhKeo_Doan.Chuc_nang_danh_muc;
using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Loai_hang;
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
    public partial class FormLoaiHang : DevExpress.XtraEditors.XtraUserControl
    {
        public FormLoaiHang()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void FormLoaiHang_Load(object sender, EventArgs e)
        {

        }

        private void btnSuaLoaiHang_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string malh = selectedRow.Cells["MaLoaiHang"].Value.ToString();
            string tenlh = selectedRow.Cells["TenLoaiHang"].Value.ToString();
            string tennh = selectedRow.Cells["TenNganhHang"].Value.ToString();

            SuaLoaiHang suaLoaiHang = new SuaLoaiHang(malh, tenlh, tennh);
            suaLoaiHang.Show();
        }

        private void btnThemLoaiHang_Click(object sender, EventArgs e)
        {
            ThemLoaiHang themLoaiHang = new ThemLoaiHang();
            themLoaiHang.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string malh = selectedRow.Cells["MaLoaiHang"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa loại hàng này không!", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM LoaiHang WHERE MaLoaiHang = '" + malh + "'";

                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    ketnoiCSDL.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa loại hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                    ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT MaLoaiHang, TenLoaiHang, NganhHang.TenNganhHang FROM LoaiHang INNER JOIN NganhHang ON LoaiHang.MaNganhHang = NganhHang.MaNganhHang");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa loại hàng thất bại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!");
            }
        }
    }
}
