using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Loai_thu;
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
    public partial class FormLoaiThu : DevExpress.XtraEditors.XtraUserControl
    {
        public FormLoaiThu()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void FormLoaiThu_Load(object sender, EventArgs e)
        {
            
        }

        private void btnThemLoaiThu_Click(object sender, EventArgs e)
        {
            ThemLoaiThu themLoaiThu = new ThemLoaiThu();
            themLoaiThu.Show();
        }

        private void btnSuaLoaiThu_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string malt = selectedRow.Cells["MaLoaiThu"].Value.ToString();
            string tenlt = selectedRow.Cells["TenLoaiThu"].Value.ToString();

            SuaLoaiThu suaLoaiThu = new SuaLoaiThu(malt, tenlt);
            suaLoaiThu.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string malt = selectedRow.Cells["MaLoaiThu"].Value.ToString();


            if (MessageBox.Show("Bạn có chắc muốn xóa loại thu này không!", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM LoaiThu WHERE MaLoaiThu = '" + malt + "'";

                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    ketnoiCSDL.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa loại thu thành công!", "Thông báo", MessageBoxButtons.OK);
                    ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM LoaiThu");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa loại thu thất bại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!");
            }
        }
    }
}
