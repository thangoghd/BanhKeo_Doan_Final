using BanhKeo_Doan.Chuc_nang_danh_muc;
using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Kho;
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
    public partial class FormKho : DevExpress.XtraEditors.XtraUserControl
    {
        public FormKho()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void FormKho_Load(object sender, EventArgs e)
        {

        }

        private void btnSuaKho_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string maKho = selectedRow.Cells["MaKho"].Value.ToString();
            string tenKho = selectedRow.Cells["TenKho"].Value.ToString();

            SuaKho suaKho = new SuaKho(maKho, tenKho);
            suaKho.Show();
        }

        private void btnThemKho_Click(object sender, EventArgs e)
        {
            ThemKho themKho = new ThemKho();
            themKho.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string maKho = selectedRow.Cells["MaKho"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa kho này không!", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM Kho WHERE MaKho = '" + maKho + "'";

                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    ketnoiCSDL.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa kho thành công!", "Thông báo", MessageBoxButtons.OK);
                    ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM Kho");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa kho thất bại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!");
            }
        }
    }
}
