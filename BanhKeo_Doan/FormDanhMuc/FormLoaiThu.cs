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
            using (var dlg = new ThemLoaiThu())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // tìm RibbonForm chính và gọi lại code load
                    var rf = this.FindForm() as RibbonForm1;
                    rf?.ReloadLoaiThuGrid();
                }
            }
        }

        private void btnSuaLoaiThu_Click(object sender, EventArgs e)
        {
            // Tìm form cha (RibbonForm1)
            var rf = this.FindForm() as RibbonForm1;
            if (rf == null || rf.dataGridView1.CurrentRow == null) return;

            try
            {
                // Lấy dữ liệu từ dòng được chọn
                int ma = Convert.ToInt32(rf.dataGridView1.CurrentRow.Cells["MaLoaiThu"].Value);
                string ten = rf.dataGridView1.CurrentRow.Cells["TenLoaiThu"].Value.ToString();

                // Hiển thị form sửa
                using (var dlg = new SuaLoaiThu(ma, ten))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        // Nếu sửa thành công, reload grid
                        rf.ReloadLoaiThuGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaLoaiThu_Click(object sender, EventArgs e)
        {
            var rf = this.FindForm() as RibbonForm1;
            if (rf == null || rf.dataGridView1.CurrentRow == null) return;

            try
            {
                int ma = Convert.ToInt32(rf.dataGridView1.CurrentRow.Cells["MaLoaiThu"].Value);
                if (MessageBox.Show(
                        $"Bạn có chắc muốn xóa loại thu mã {ma}?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    string query = $"DELETE FROM LoaiThu WHERE MaLoaiThu = {ma}";
                    new KetNoiCSDL().GetData(query);
                    rf.ReloadLoaiThuGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
