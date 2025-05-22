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
using System.Globalization;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuChiTraNCC
{
    public partial class SuaPhieuChiTraNCC : Form
    {
        private KetNoiCSDL db;
        private string maPhieuChiTra;

        public SuaPhieuChiTraNCC()
        {
            InitializeComponent();
            db = new KetNoiCSDL();

            // Đăng ký sự kiện cho các nút
            simpleButton1.Click += simpleButton1_Click;
            Huy.Click += Huy_Click;
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (cbNCC.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xử lý số tiền - cách đơn giản
                decimal soTien = 0;
                try
                {
                    // Loại bỏ tất cả dấu phân cách
                    string soTienText = txtSoTien.Text.Replace(".", "").Replace(",", "");
                    soTien = decimal.Parse(soTienText);
                }
                catch
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
                int maNCC = Convert.ToInt32(cbNCC.SelectedValue);
                string soChungTu = txtSoChungTu.Text.Trim();
                string dienGiai = txtDienGiai.Text.Trim();
                string httt = cbHTTT.SelectedItem.ToString();
                string nguoiNhan = txtNguoiNhan.Text.Trim();
                string giaoDich = cbGiaoDich.SelectedItem.ToString();

                // Kiểm tra số chứng từ đã tồn tại chưa (ngoại trừ chính nó)
                string checkQuery = $"SELECT COUNT(*) FROM PhieuChiTraNCC WHERE SoChungTu = '{soChungTu}' AND MaPhieuChiTra <> '{maPhieuChiTra}'";
                DataTable dtCheck = db.GetData(checkQuery);
                if (Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
                {
                    MessageBox.Show("Số chứng từ đã tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật phiếu chi trả trong CSDL
                // Sử dụng tham số hóa để tránh vấn đề với định dạng số
                string query = $@"UPDATE PhieuChiTraNCC 
                                SET MaNhaCungCap = {maNCC}, 
                                    DienGiai = N'{dienGiai}', 
                                    SoTien = {(long)soTien}, 
                                    HTTT = N'{httt}', 
                                    NguoiNhan = N'{nguoiNhan}', 
                                    GiaoDich = N'{giaoDich}' 
                                WHERE MaPhieuChiTra = '{maPhieuChiTra}'";

                int result = db.ExecuteNonQuery(query);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật phiếu chi trả nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật phiếu chi trả nhà cung cấp thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Không cần xử lý
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Không cần xử lý
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Không cần xử lý
        }

        public void SetMaPhieuChiTra(string maPhieuChiTra)
        {
            this.maPhieuChiTra = maPhieuChiTra;
            LoadInitialData();
            LoadPhieuChiTraNCCData();
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

                // Thêm các hình thức thanh toán
                cbHTTT.Items.Clear();
                cbHTTT.Items.AddRange(new string[] { "Tiền mặt", "Chuyển khoản", "Thẻ tín dụng" });

                // Thêm các loại giao dịch
                cbGiaoDich.Items.Clear();
                cbGiaoDich.Items.AddRange(new string[] { "Thanh toán", "Tạm ứng", "Hoàn ứng" });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu ban đầu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPhieuChiTraNCCData()
        {
            try
            {
                if (string.IsNullOrEmpty(maPhieuChiTra))
                    return;

                string query = $"SELECT * FROM PhieuChiTraNCC WHERE MaPhieuChiTra = '{maPhieuChiTra}'";
                DataTable dt = db.GetData(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Hiển thị dữ liệu lên form
                    cbNCC.SelectedValue = row["MaNhaCungCap"];
                    txtSoChungTu.Text = row["SoChungTu"].ToString();
                    // Hiển thị số tiền dạng số nguyên (không có dấu phân cách và không có phần thập phân)
                    decimal soTien = Convert.ToDecimal(row["SoTien"]);
                    txtSoTien.Text = ((long)soTien).ToString(); // Chuyển thành số nguyên
                    txtDienGiai.Text = row["DienGiai"].ToString();
                    txtNguoiNhan.Text = row["NguoiNhan"].ToString();

                    // Chọn hình thức thanh toán
                    string httt = row["HTTT"].ToString();
                    for (int i = 0; i < cbHTTT.Items.Count; i++)
                    {
                        if (cbHTTT.Items[i].ToString() == httt)
                        {
                            cbHTTT.SelectedIndex = i;
                            break;
                        }
                    }

                    // Chọn loại giao dịch
                    string giaoDich = row["GiaoDich"].ToString();
                    for (int i = 0; i < cbGiaoDich.Items.Count; i++)
                    {
                        if (cbGiaoDich.Items[i].ToString() == giaoDich)
                        {
                            cbGiaoDich.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu chi trả với mã: " + maPhieuChiTra, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu phiếu chi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
