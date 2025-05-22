using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuChiTraNCC
{
    public partial class FormPhieuChiTraNCC : Form
    {
        private KetNoiCSDL db;

        public FormPhieuChiTraNCC()
        {
            InitializeComponent();
            db = new KetNoiCSDL();
            LoadDanhSachPhieuChiTraNCC();
            FormatDataGridView();
            LoadDanhSachNCC();

            // Thiết lập giá trị mặc định cho DateTimePicker
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;

            // Đăng ký sự kiện cho nút Tìm kiếm
            simpleButton1.Click += simpleButton1_Click;

            // Đăng ký sự kiện cho các checkbox
            checkBoxNCC.CheckedChanged += checkBoxNCC_CheckedChanged;
            checkBoxDate.CheckedChanged += checkBoxDate_CheckedChanged;

            // Thiết lập trạng thái ban đầu cho các điều khiển
            cbNCC.Enabled = checkBoxNCC.Checked;
            dtpFrom.Enabled = checkBoxDate.Checked;
            dtpTo.Enabled = checkBoxDate.Checked;
        }

        private void LoadDanhSachPhieuChiTraNCC()
        {
            try
            {
                string query = @"SELECT p.MaPhieuChiTra, p.NgayLap, p.MaNhaCungCap, ncc.TenNhaCungCap, 
                                p.SoChungTu, p.DienGiai, p.SoTien, p.HTTT, p.NguoiNhan, p.GiaoDich, 
                                p.TrangThai, p.MaNhanVien, nv.TenNhanVien
                            FROM PhieuChiTraNCC p
                            LEFT JOIN NhaCungCap ncc ON p.MaNhaCungCap = ncc.MaNhaCungCap
                            LEFT JOIN NhanVien nv ON p.MaNhanVien = nv.MaNhanVien
                            ORDER BY p.NgayLap DESC";

                DataTable dt = db.GetData(query);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            // Định dạng hiển thị cho DataGridView
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["MaPhieuChiTra"].HeaderText = "Mã phiếu chi";
                dataGridView1.Columns["NgayLap"].HeaderText = "Ngày lập";
                dataGridView1.Columns["MaNhaCungCap"].HeaderText = "Mã NCC";
                dataGridView1.Columns["TenNhaCungCap"].HeaderText = "Tên nhà cung cấp";
                dataGridView1.Columns["SoChungTu"].HeaderText = "Số chứng từ";
                dataGridView1.Columns["DienGiai"].HeaderText = "Diễn giải";
                dataGridView1.Columns["SoTien"].HeaderText = "Số tiền";
                dataGridView1.Columns["HTTT"].HeaderText = "Hình thức thanh toán";
                dataGridView1.Columns["NguoiNhan"].HeaderText = "Người nhận";
                dataGridView1.Columns["GiaoDich"].HeaderText = "Giao dịch";
                dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
                dataGridView1.Columns["MaNhanVien"].HeaderText = "Mã NV";
                dataGridView1.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";

                // Định dạng số tiền
                dataGridView1.Columns["SoTien"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Định dạng ngày tháng
                dataGridView1.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void btnThemPhieuChiTraNCC_Click(object sender, EventArgs e)
        {
            ThemPhieuChiTraNCC themPhieuChiTraNCC = new ThemPhieuChiTraNCC();
            // Sau khi form đóng, refresh lại dữ liệu
            themPhieuChiTraNCC.FormClosed += (s, args) => LoadDanhSachPhieuChiTraNCC();
            themPhieuChiTraNCC.Show();
        }

        private void btnXoaPhieuChiTraNCC_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string maPhieuChiTra = dataGridView1.CurrentRow.Cells["MaPhieuChiTra"].Value.ToString();
                string tenNCC = dataGridView1.CurrentRow.Cells["TenNhaCungCap"].Value.ToString();
                decimal soTien = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["SoTien"].Value);

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa phiếu chi trả cho nhà cung cấp '{tenNCC}' với số tiền {soTien:N0} VNĐ?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Thực hiện xóa phiếu chi trả
                        string query = $"DELETE FROM PhieuChiTraNCC WHERE MaPhieuChiTra = '{maPhieuChiTra}'";
                        int ketQua = db.ExecuteNonQuery(query);

                        if (ketQua > 0)
                        {
                            MessageBox.Show("Xóa phiếu chi trả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Cập nhật lại danh sách
                            LoadDanhSachPhieuChiTraNCC();
                        }
                        else
                        {
                            MessageBox.Show("Xóa phiếu chi trả thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa phiếu chi trả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu chi để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaPhieuChiTraNCC_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string maPhieuChiTra = dataGridView1.CurrentRow.Cells["MaPhieuChiTra"].Value.ToString();
                SuaPhieuChiTraNCC suaPhieuChiTraNCC = new SuaPhieuChiTraNCC();
                // Truyền mã phiếu chi trả vào form sửa
                suaPhieuChiTraNCC.SetMaPhieuChiTra(maPhieuChiTra);
                // Sau khi form đóng, refresh lại dữ liệu
                suaPhieuChiTraNCC.FormClosed += (s, args) => LoadDanhSachPhieuChiTraNCC();
                suaPhieuChiTraNCC.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu chi để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadDanhSachNCC()
        {
            try
            {
                string query = "SELECT MaNhaCungCap, TenNhaCungCap FROM NhaCungCap ORDER BY TenNhaCungCap";
                DataTable dt = db.GetData(query);

                // Thêm một dòng trống vào đầu để người dùng có thể chọn tất cả
                DataRow dr = dt.NewRow();
                dr["MaNhaCungCap"] = DBNull.Value; // Sử dụng DBNull.Value thay vì chuỗi rỗng
                dr["TenNhaCungCap"] = "-- Tất cả nhà cung cấp --";
                dt.Rows.InsertAt(dr, 0);

                cbNCC.DataSource = dt;
                cbNCC.DisplayMember = "TenNhaCungCap";
                cbNCC.ValueMember = "MaNhaCungCap";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxNCC_CheckedChanged(object sender, EventArgs e)
        {
            // Kích hoạt/vô hiệu hóa combobox NCC dựa trên trạng thái của checkbox
            cbNCC.Enabled = checkBoxNCC.Checked;
        }

        private void checkBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            // Kích hoạt/vô hiệu hóa các DateTimePicker dựa trên trạng thái của checkbox
            dtpFrom.Enabled = checkBoxDate.Checked;
            dtpTo.Enabled = checkBoxDate.Checked;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Xây dựng câu truy vấn cơ bản
                string query = @"SELECT p.MaPhieuChiTra, p.NgayLap, p.MaNhaCungCap, ncc.TenNhaCungCap, 
                               p.SoChungTu, p.DienGiai, p.SoTien, p.HTTT, p.NguoiNhan, p.GiaoDich, 
                               p.TrangThai, p.MaNhanVien, nv.TenNhanVien
                            FROM PhieuChiTraNCC p
                            LEFT JOIN NhaCungCap ncc ON p.MaNhaCungCap = ncc.MaNhaCungCap
                            LEFT JOIN NhanVien nv ON p.MaNhanVien = nv.MaNhanVien
                            WHERE 1=1";

                // Thêm điều kiện tìm kiếm theo NCC nếu được chọn
                if (checkBoxNCC.Checked && cbNCC.SelectedValue != null && cbNCC.SelectedValue != DBNull.Value)
                {
                    // Kiểm tra xem giá trị có phải là DBNull không
                    if (!Convert.IsDBNull(cbNCC.SelectedValue))
                    {
                        int maNCC = Convert.ToInt32(cbNCC.SelectedValue);
                        query += $" AND p.MaNhaCungCap = {maNCC}";
                    }
                }

                // Thêm điều kiện tìm kiếm theo ngày nếu được chọn
                if (checkBoxDate.Checked)
                {
                    // Định dạng ngày tháng theo chuẩn SQL Server
                    string fromDate = dtpFrom.Value.ToString("yyyy-MM-dd");
                    string toDate = dtpTo.Value.ToString("yyyy-MM-dd");
                    query += $" AND p.NgayLap BETWEEN '{fromDate}' AND '{toDate} 23:59:59'";
                }

                // Thêm sắp xếp theo ngày lập giảm dần
                query += " ORDER BY p.NgayLap DESC";

                // Thực hiện truy vấn và hiển thị kết quả
                DataTable dt = db.GetData(query);
                dataGridView1.DataSource = dt;
                FormatDataGridView(); // Định dạng lại DataGridView sau khi load dữ liệu mới

                // Thông báo kết quả tìm kiếm
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show($"Tìm thấy {dt.Rows.Count} phiếu chi trả.", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu chi trả nào phù hợp với điều kiện tìm kiếm.", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
