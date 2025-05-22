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

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangSoChi
{
    public partial class SuaSoChi : Form
    {
        private KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
        private FormSoChi formSoChi; // Tham chiếu đến form cha
        private string maSoChi; // Lưu mã sổ chi cần sửa

        public SuaSoChi()
        {
            InitializeComponent();
            this.Load += SuaSoChi_Load;

            // Đăng ký sự kiện cho các nút
            simpleButton1.Click += simpleButton1_Click; // Nút Chấp nhận
            Huy.Click += Huy_Click; // Nút Hủy bỏ
        }

        // Constructor nhận mã sổ chi cần sửa
        public SuaSoChi(string maSoChi)
        {
            InitializeComponent();
            this.maSoChi = maSoChi;
            this.Load += SuaSoChi_Load;

            // Đăng ký sự kiện cho các nút
            simpleButton1.Click += simpleButton1_Click; // Nút Chấp nhận
            Huy.Click += Huy_Click; // Nút Hủy bỏ
        }

        // Sự kiện Load của form
        private void SuaSoChi_Load(object sender, EventArgs e)
        {
            // Load dữ liệu loại chi vào comboBox1
            LoadLoaiChiComboBox();

            // Load dữ liệu hình thức thanh toán vào comboBox2
            LoadHTTTComboBox();

            // Tìm form cha (FormSoChi)
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormSoChi)
                {
                    formSoChi = (FormSoChi)form;
                    break;
                }
            }

            // Nếu có mã sổ chi, load thông tin sổ chi cần sửa
            if (!string.IsNullOrEmpty(maSoChi))
            {
                LoadSoChiInfo();
            }
            else
            {
                // Nếu không có mã sổ chi, lấy từ form cha
                if (formSoChi != null && formSoChi.dataGridView1.SelectedCells.Count > 0)
                {
                    DataGridViewCell cell = formSoChi.dataGridView1.SelectedCells[0];
                    DataGridViewRow row = formSoChi.dataGridView1.Rows[cell.RowIndex];
                    maSoChi = row.Cells["MaSoChi"].Value.ToString();
                    LoadSoChiInfo();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin sổ chi cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        // Phương thức load thông tin sổ chi cần sửa
        private void LoadSoChiInfo()
        {
            try
            {
                string query = $@"SELECT sc.MaSoChi, sc.NgayLap, sc.MaLoaiChi, sc.SoTien, 
                               sc.NguoiNhan, sc.DienGiai, sc.SoChungTu, sc.HTTT 
                               FROM SoChi sc 
                               WHERE sc.MaSoChi = '{maSoChi}'";

                DataTable dt = ketnoiCSDL.GetData(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Thiết lập giá trị cho các control
                    comboBox1.SelectedValue = row["MaLoaiChi"]; // Loại chi
                    textBox1.Text = row["SoChungTu"].ToString(); // Số chứng từ
                    dateTimePicker1.Value = Convert.ToDateTime(row["NgayLap"]); // Ngày lập
                    int soTien = Convert.ToInt32(row["SoTien"]);
                    textBox3.Text = soTien.ToString(); // Số tiền
                    comboBox2.SelectedItem = row["HTTT"].ToString(); // Hình thức thanh toán
                    textBox5.Text = row["DienGiai"].ToString(); // Diễn giải
                    textBox4.Text = row["NguoiNhan"].ToString(); // Người nhận
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin sổ chi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin sổ chi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Phương thức load dữ liệu Loại Chi vào comboBox1
        private void LoadLoaiChiComboBox()
        {
            string query = "SELECT MaLoaiChi, TenLoaiChi FROM LoaiChi";
            DataTable dt = ketnoiCSDL.GetData(query);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TenLoaiChi";
            comboBox1.ValueMember = "MaLoaiChi";
        }

        // Phương thức load dữ liệu hình thức thanh toán vào comboBox2
        private void LoadHTTTComboBox()
        {
            // Tạo danh sách các hình thức thanh toán
            List<string> httt = new List<string>
            {
                "Tiền mặt",
                "Chuyển khoản",
                "Thẻ tín dụng",
                "Khác"
            };

            comboBox2.DataSource = httt;
        }

        // Sự kiện khi nhấn nút Chấp nhận
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập vào
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại chi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập số chứng từ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal soTien;
            if (!decimal.TryParse(textBox3.Text, out soTien) || soTien <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn hình thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Vui lòng nhập người nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy giá trị từ các control
                int maLoaiChi = Convert.ToInt32(comboBox1.SelectedValue);
                string soChungTu = textBox1.Text.Trim();
                DateTime ngayLap = dateTimePicker1.Value;
                string httt = comboBox2.SelectedItem.ToString();
                string dienGiai = textBox5.Text.Trim();
                string nguoiNhan = textBox4.Text.Trim();

                // Tạo câu lệnh SQL để cập nhật dữ liệu
                string query = $@"UPDATE SoChi SET 
                               NgayLap = '{ngayLap.ToString("yyyy-MM-dd")}', 
                               MaLoaiChi = {maLoaiChi}, 
                               SoTien = {soTien}, 
                               NguoiNhan = N'{nguoiNhan}', 
                               DienGiai = N'{dienGiai}', 
                               SoChungTu = '{soChungTu}', 
                               HTTT = N'{httt}' 
                               WHERE MaSoChi = '{maSoChi}'";

                // Thực thi câu lệnh SQL
                ketnoiCSDL.ExecuteNonQuery(query);

                // Hiển thị thông báo thành công
                MessageBox.Show("Cập nhật sổ chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại dữ liệu ở form cha
                if (formSoChi != null)
                {
                    formSoChi.ReloadSoChiData();
                }

                // Đóng form
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi nhấn nút Hủy bỏ
        private void Huy_Click(object sender, EventArgs e)
        {
            // Đóng form
            this.Close();
        }
    }
}