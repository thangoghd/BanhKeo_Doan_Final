using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BanhKeo_Doan.KetNoiCSDL;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangSoThu
{
    public partial class FormSoThu : Form
    {
        private KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
        public FormSoThu()
        {
            InitializeComponent();

            this.Load += FormSoThu_Load;
        }

        // Sự kiện Load của form
        private void FormSoThu_Load(object sender, EventArgs e)
        {
            // Load dữ liệu Sổ Thu khi form được mở
            LoadSoThuData();

            // Load dữ liệu Loại Thu vào comboBox1 để phục vụ tìm kiếm
            LoadLoaiThuComboBox();
        }


        // Phương thức load dữ liệu Sổ Thu
        public void LoadSoThuData()
        {
            string query = @"SELECT st.MaSoThu, st.NgayLap, lt.TenLoaiThu, st.SoTien, 
                           st.NguoiNop, st.DienGiai, st.SoChungTu, st.HTTT 
                           FROM SoThu st 
                           LEFT JOIN LoaiThu lt ON st.MaLoaiThu = lt.MaLoaiThu";

            dataGridView1.DataSource = ketnoiCSDL.GetData(query);

            // Đặt tiêu đề cột
            dataGridView1.Columns["MaSoThu"].HeaderText = "Mã sổ thu";
            dataGridView1.Columns["NgayLap"].HeaderText = "Ngày lập";
            dataGridView1.Columns["TenLoaiThu"].HeaderText = "Loại thu";
            dataGridView1.Columns["SoTien"].HeaderText = "Số tiền";
            dataGridView1.Columns["NguoiNop"].HeaderText = "Người nộp";
            dataGridView1.Columns["DienGiai"].HeaderText = "Diễn giải";
            dataGridView1.Columns["SoChungTu"].HeaderText = "Số chứng từ";
            dataGridView1.Columns["HTTT"].HeaderText = "Hình thức thanh toán";

            // Định dạng hiển thị
            dataGridView1.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["SoTien"].DefaultCellStyle.Format = "N0";

            // Tự động điều chỉnh kích thước cột
            dataGridView1.AutoResizeColumns();
        }



        // Phương thức load dữ liệu Loại Thu vào comboBox1
        private void LoadLoaiThuComboBox()
        {
            string query = "SELECT MaLoaiThu, TenLoaiThu FROM LoaiThu";
            DataTable dt = ketnoiCSDL.GetData(query);

            // Thêm một dòng "Tất cả" vào đầu danh sách
            DataRow row = dt.NewRow();
            row["MaLoaiThu"] = 0;
            row["TenLoaiThu"] = "Tất cả";
            dt.Rows.InsertAt(row, 0);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TenLoaiThu";
            comboBox1.ValueMember = "MaLoaiThu";
        }

        private void btnThemSoThu_Click(object sender, EventArgs e)
        {
            ThemSoThu themSoThu = new ThemSoThu();
            themSoThu.Show();
        }

        private void btnSuaSoThu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ô nào được chọn không
            if (dataGridView1.SelectedCells.Count > 0)
            {
                SuaSoThu suaSoThu = new SuaSoThu();
                suaSoThu.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ô để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaSoThu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ô nào được chọn không
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // Lấy dòng chứa ô được chọn
                DataGridViewCell cell = dataGridView1.SelectedCells[0];
                DataGridViewRow row = dataGridView1.Rows[cell.RowIndex];
                string maSoThu = row.Cells["MaSoThu"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa sổ thu này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Tạo câu lệnh SQL để xóa bản ghi
                        string query = $"DELETE FROM SoThu WHERE MaSoThu = '{maSoThu}'";

                        // Thực thi câu lệnh SQL
                        ketnoiCSDL.ExecuteNonQuery(query);

                        // Hiển thị thông báo thành công
                        MessageBox.Show("Xóa sổ thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật lại dữ liệu
                        LoadSoThuData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ô để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Thêm phương thức Reload để có thể gọi từ các form khác
        public void ReloadSoThuData()
        {
            LoadSoThuData();
        }
    }
}
