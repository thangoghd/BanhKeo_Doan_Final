using BanhKeo_Doan.Chuc_nang_danh_muc;
using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_DVT;
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
    public partial class FormDVT : DevExpress.XtraEditors.XtraUserControl
    {
        public FormDVT()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void FormDVT_Load(object sender, EventArgs e)
        {

        }

        private void SuaDVT_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string madvt = selectedRow.Cells["MaDVT"].Value.ToString();
            string tendvt = selectedRow.Cells["TenDVT"].Value.ToString();

            SuaDVT suaDVT = new SuaDVT(madvt, tendvt);
            suaDVT.Show();
        }

        private void btnThemDVT_Click(object sender, EventArgs e)
        {
            ThemDVT themDVT = new ThemDVT();
            themDVT.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string madvt = selectedRow.Cells["MaDVT"].Value.ToString();


            if (MessageBox.Show("Bạn có chắc muốn xóa đơn vị tính này không!", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM DonViTinh WHERE MaDVT = '" + madvt + "'";

                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    ketnoiCSDL.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa đơn vị tính thành công!", "Thông báo", MessageBoxButtons.OK);
                    ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM DonViTinh");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa đơn vị tính thất bại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!");
            }
        }
    }
}
