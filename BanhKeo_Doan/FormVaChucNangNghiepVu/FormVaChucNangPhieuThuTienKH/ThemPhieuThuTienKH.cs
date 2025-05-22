using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuThuTienKH
{
    public partial class ThemPhieuThuTienKH : Form
    {
        private KetNoiCSDL db;

        public ThemPhieuThuTienKH()
        {
            InitializeComponent();
            db = new KetNoiCSDL();

            // Thiết lập ngày hiện tại cho DateTimePicker
            dtpNgayTra.Value = DateTime.Now;

            // Load dữ liệu cho các ComboBox
            LoadDanhSachKhachHang();
            LoadHinhThucThanhToan();
            LoadGiaoDich();
            LoadDanhSachNhanVien();

            // Tạo mã phiếu thu tiền tự động
            TaoMaPhieuThuTien();

            // Đăng ký sự kiện cho nút Chấp nhận
            simpleButton1.Click += simpleButton1_Click;
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadDanhSachKhachHang()
        {
            try
            {
                string query = "SELECT MaKhachHang, TenKhachHang FROM KhachHang ORDER BY TenKhachHang";
                DataTable dt = db.GetData(query);

                comboBoxKH.DataSource = dt;
                comboBoxKH.DisplayMember = "TenKhachHang";
                comboBoxKH.ValueMember = "MaKhachHang";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachNhanVien()
        {
            try
            {
                string query = "SELECT MaNhanVien, TenNhanVien FROM NhanVien ORDER BY TenNhanVien";
                DataTable dt = db.GetData(query);

                cbNhanVien.DataSource = dt;
                cbNhanVien.DisplayMember = "TenNhanVien";
                cbNhanVien.ValueMember = "MaNhanVien";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHinhThucThanhToan()
        {
            // Thêm các hình thức thanh toán vào ComboBox
            comboBoxHTTT.Items.Clear();
            comboBoxHTTT.Items.Add("Tiền mặt");
            comboBoxHTTT.Items.Add("Chuyển khoản");
            comboBoxHTTT.Items.Add("Thẻ tín dụng");
            comboBoxHTTT.SelectedIndex = 0; // Chọn mặc định là Tiền mặt
        }

        private void LoadGiaoDich()
        {
            // Thêm các loại giao dịch vào ComboBox
            comboBoxGiaoDich.Items.Clear();
            comboBoxGiaoDich.Items.Add("Thu tiền bán hàng");
            comboBoxGiaoDich.Items.Add("Thu tiền trả trước");
            comboBoxGiaoDich.Items.Add("Thu tiền công nợ");
            comboBoxGiaoDich.Items.Add("Thu khác");
            comboBoxGiaoDich.SelectedIndex = 0; // Chọn mặc định là Thu tiền bán hàng
        }

        private void TaoMaPhieuThuTien()
        {
            try
            {
                // Tạo mã phiếu thu tiền theo định dạng PTT-yyyyMMdd-XXX
                string ngayHienTai = DateTime.Now.ToString("yyyyMMdd");
                string prefix = "PTT-" + ngayHienTai + "-";

                // Tìm số thứ tự lớn nhất hiện tại
                string query = $"SELECT MAX(MaPhieuThuTien) FROM PhieuThuTienKH WHERE MaPhieuThuTien LIKE '{prefix}%'";
                DataTable dt = db.GetData(query);

                int soThuTu = 1;
                if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    string maLonNhat = dt.Rows[0][0].ToString();
                    string soThuTuStr = maLonNhat.Substring(maLonNhat.LastIndexOf('-') + 1);
                    if (int.TryParse(soThuTuStr, out int soThuTuHienTai))
                    {
                        soThuTu = soThuTuHienTai + 1;
                    }
                }

                // Tạo mã mới
                string maMoi = prefix + soThuTu.ToString("D3");
                txtSoChungTu.Text = maMoi;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã phiếu thu tiền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường bắt buộc
                if (comboBoxKH.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSoChungTu.Text))
                {
                    MessageBox.Show("Vui lòng nhập số chứng từ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNgayTra.Text) || !decimal.TryParse(txtNgayTra.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal soTien))
                {
                    MessageBox.Show("Vui lòng nhập số tiền hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxHTTT.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn hình thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNguoiNop.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên người nộp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxGiaoDich.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn loại giao dịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin từ các control
                string maPhieuThuTien = txtSoChungTu.Text.Trim();
                DateTime ngayLap = dtpNgayTra.Value;
                int maKhachHang = Convert.ToInt32(comboBoxKH.SelectedValue);
                string dienGiai = txtDienGiai.Text.Trim();
                string httt = comboBoxHTTT.SelectedItem.ToString();
                string nguoiNop = txtNguoiNop.Text.Trim();
                string giaoDich = comboBoxGiaoDich.SelectedItem.ToString();
                string trangThai = "Hoàn thành"; // Mặc định là Hoàn thành
                int maNhanVien = Convert.ToInt32(cbNhanVien.SelectedValue); // Giả sử mã nhân viên đang đăng nhập là 1, cần thay đổi sau

                // Kiểm tra số chứng từ đã tồn tại chưa
                string queryCheck = $"SELECT COUNT(*) FROM PhieuThuTienKH WHERE SoChungTu = '{maPhieuThuTien}'";
                DataTable dtCheck = db.GetData(queryCheck);
                int count = 0;

                if (dtCheck.Rows.Count > 0)
                {
                    count = Convert.ToInt32(dtCheck.Rows[0][0]);
                }

                if (count > 0)
                {
                    MessageBox.Show("Số chứng từ đã tồn tại! Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm phiếu thu tiền vào CSDL
                string query = $@"INSERT INTO PhieuThuTienKH (MaPhieuThuTien, NgayLap, MaKhachHang, SoChungTu, DienGiai, SoTien, HTTT, NguoiNop, GiaoDich, TrangThai, MaNhanVien)
                                VALUES ('{maPhieuThuTien}', '{ngayLap.ToString("yyyy-MM-dd HH:mm:ss")}', {maKhachHang}, '{maPhieuThuTien}', N'{dienGiai}', {soTien.ToString(CultureInfo.InvariantCulture)}, N'{httt}', N'{nguoiNop}', N'{giaoDich}', N'{trangThai}', {maNhanVien})";

                int ketQua = db.ExecuteNonQuery(query);

                if (ketQua > 0)
                {
                    MessageBox.Show("Thêm phiếu thu tiền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm phiếu thu tiền thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu thu tiền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
