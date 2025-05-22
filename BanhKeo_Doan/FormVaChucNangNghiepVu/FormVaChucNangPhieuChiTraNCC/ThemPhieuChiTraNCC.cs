using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuChiTraNCC
{
    public partial class ThemPhieuChiTraNCC : Form
    {
        private KetNoiCSDL db;

        // Tạo sự kiện để thông báo khi thêm mới thành công
        public event EventHandler PhieuChiTraNCCAdded;

        public ThemPhieuChiTraNCC()
        {
            InitializeComponent();
            db = new KetNoiCSDL();
            LoadInitialData();

            // Đăng ký sự kiện cho các nút
            simpleButton1.Click += btnLuu_Click;
            Huy.Click += btnHuy_Click;
        }

        private void LoadInitialData()
        {
            try
            {
                // Load danh sách nhà cung cấp vào combobox
                string queryNCC = "SELECT MaNhaCungCap, TenNhaCungCap FROM NhaCungCap";
                DataTable dtNCC = db.GetData(queryNCC);
                cbNCC.DataSource = dtNCC;
                cbNCC.DisplayMember = "TenNhaCungCap";
                cbNCC.ValueMember = "MaNhaCungCap";

                // Load danh sách nhân viên vào combobox (nếu cần)
                string queryNV = "SELECT MaNhanVien, TenNhanVien FROM NhanVien";
                DataTable dtNV = db.GetData(queryNV);

                // Thêm các hình thức thanh toán
                cbHTTT.Items.AddRange(new string[] { "Tiền mặt", "Chuyển khoản", "Thẻ tín dụng" });
                cbHTTT.SelectedIndex = 0;

                // Thêm các loại giao dịch
                cbGiaoDich.Items.AddRange(new string[] { "Thanh toán", "Tạm ứng", "Hoàn ứng" });
                cbGiaoDich.SelectedIndex = 0;

                // Tạo mã phiếu chi tự động
                txtSoChungTu.Text = TaoSoChungTuTuDong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu ban đầu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string TaoSoChungTuTuDong()
        {
            // Tạo số chứng từ theo định dạng: PC + Năm + Tháng + Số thứ tự
            string prefix = "PC" + DateTime.Now.ToString("yyMM");

            try
            {
                string query = $"SELECT MAX(SoChungTu) AS MaxSCT FROM PhieuChiTraNCC WHERE SoChungTu LIKE '{prefix}%'";
                DataTable dt = db.GetData(query);

                if (dt.Rows.Count > 0 && dt.Rows[0]["MaxSCT"] != DBNull.Value)
                {
                    string maxSCT = dt.Rows[0]["MaxSCT"].ToString();
                    string numberPart = maxSCT.Substring(prefix.Length);
                    int number = int.Parse(numberPart) + 1;
                    return prefix + number.ToString("D3");
                }
                else
                {
                    return prefix + "001";
                }
            }
            catch
            {
                return prefix + "001";
            }
        }

        private string TaoMaPhieuChiTraTuDong()
        {
            // Tạo mã phiếu chi trả theo định dạng: PCT + Năm + Tháng + Số thứ tự
            string prefix = "PCT" + DateTime.Now.ToString("yyMM");

            try
            {
                string query = $"SELECT MAX(MaPhieuChiTra) AS MaxMa FROM PhieuChiTraNCC WHERE MaPhieuChiTra LIKE '{prefix}%'";
                DataTable dt = db.GetData(query);

                if (dt.Rows.Count > 0 && dt.Rows[0]["MaxMa"] != DBNull.Value)
                {
                    string maxMa = dt.Rows[0]["MaxMa"].ToString();
                    string numberPart = maxMa.Substring(prefix.Length);
                    int number = int.Parse(numberPart) + 1;
                    return prefix + number.ToString("D3");
                }
                else
                {
                    return prefix + "001";
                }
            }
            catch
            {
                return prefix + "001";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (cbNCC.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSoChungTu.Text))
                {
                    MessageBox.Show("Vui lòng nhập số chứng từ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSoTien.Text) || !decimal.TryParse(txtSoTien.Text, out decimal soTien))
                {
                    MessageBox.Show("Vui lòng nhập số tiền hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNguoiNhan.Text))
                {
                    MessageBox.Show("Vui lòng nhập người nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy giá trị từ form
                string maPhieuChiTra = TaoMaPhieuChiTraTuDong();
                DateTime ngayLap = DateTime.Now;
                int maNCC = Convert.ToInt32(cbNCC.SelectedValue);
                string soChungTu = txtSoChungTu.Text.Trim();
                string dienGiai = txtDienGiai.Text.Trim();
                string httt = cbHTTT.SelectedItem.ToString();
                string nguoiNhan = txtNguoiNhan.Text.Trim();
                string giaoDich = cbGiaoDich.SelectedItem.ToString();
                string trangThai = "Đã thanh toán";
                int maNV = 1; // Mã nhân viên mặc định, cần thay đổi theo người đăng nhập

                // Kiểm tra số chứng từ đã tồn tại chưa
                string checkQuery = $"SELECT COUNT(*) FROM PhieuChiTraNCC WHERE SoChungTu = '{soChungTu}'";
                DataTable dtCheck = db.GetData(checkQuery);
                if (Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
                {
                    MessageBox.Show("Số chứng từ đã tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm phiếu chi trả vào CSDL
                string query = $@"INSERT INTO PhieuChiTraNCC (MaPhieuChiTra, NgayLap, MaNhaCungCap, SoChungTu, 
                                DienGiai, SoTien, HTTT, NguoiNhan, GiaoDich, TrangThai, MaNhanVien) 
                                VALUES ('{maPhieuChiTra}', '{ngayLap:yyyy-MM-dd}', {maNCC}, '{soChungTu}', 
                                N'{dienGiai}', {soTien}, N'{httt}', N'{nguoiNhan}', N'{giaoDich}', N'{trangThai}', {maNV})";

                int result = db.ExecuteNonQuery(query);

                if (result > 0)
                {
                    MessageBox.Show("Thêm phiếu chi trả nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Kích hoạt sự kiện thông báo đã thêm thành công
                    PhieuChiTraNCCAdded?.Invoke(this, EventArgs.Empty);

                    // Đóng form
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm phiếu chi trả nhà cung cấp thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
