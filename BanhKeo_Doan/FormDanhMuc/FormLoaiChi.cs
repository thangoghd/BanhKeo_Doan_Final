using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Loai_chi;
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
    public partial class FormLoaiChi : DevExpress.XtraEditors.XtraUserControl
    {
        public FormLoaiChi()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void FormLoaiChi_Load(object sender, EventArgs e)
        {

        }

        private void btnThemLoaiChi_Click(object sender, EventArgs e)
        {
            ThemLoaiChi themLoaiChi = new ThemLoaiChi();
            themLoaiChi.Show();
        }

        private void btnSuaLoaiChi_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string malc = selectedRow.Cells["MaLoaiChi"].Value.ToString();
            string tenlc = selectedRow.Cells["TenLoaiChi"].Value.ToString();

            SuaLoaiChi suaLoaiChi = new SuaLoaiChi(malc, tenlc);
            suaLoaiChi.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string malc = selectedRow.Cells["MaLoaiChi"].Value.ToString();


            if (MessageBox.Show("Bạn có chắc muốn xóa loại chi này không!", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM LoaiChi WHERE MaLoaiChi = '" + malc + "'";

                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    ketnoiCSDL.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa loại chi thành công!", "Thông báo", MessageBoxButtons.OK);
                    ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM LoaiChi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa loại chi thất bại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!");
            }
        }
    }
}
