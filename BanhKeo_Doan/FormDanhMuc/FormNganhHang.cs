using BanhKeo_Doan.Chuc_nang_danh_muc;
using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Nganh_hang;
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
    public partial class FormNganhHang : DevExpress.XtraEditors.XtraUserControl
    {
        public FormNganhHang()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void FormNganhHang_Load(object sender, EventArgs e)
        {

        }

        private void btnSuaNganhHang_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string manh = selectedRow.Cells["MaNganhHang"].Value.ToString();
            string tennh = selectedRow.Cells["TenNganhHang"].Value.ToString();


            SuaNganhHang suaNganhHang = new SuaNganhHang(manh, tennh);
            suaNganhHang.Show();
        }

        private void btnThemNganhHang_Click(object sender, EventArgs e)
        {
            ThemNganhHang themNganhHang = new ThemNganhHang();
            themNganhHang.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string manh = selectedRow.Cells["MaNganhHang"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa ngành hàng này không!", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM NganhHang WHERE MaNganhHang = '" + manh + "'";

                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    ketnoiCSDL.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa ngành hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                    ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM NganhHang");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa ngành hàng thất bại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!");
            }
        }
    }
}
