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
    public partial class ThemSoChi : Form
    {
        private KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
        private FormSoChi formSoChi; // Tham chiếu đến form cha

        public ThemSoChi()
        {
            InitializeComponent();
            this.Load += ThemSoChi_Load;

            // Đăng ký sự kiện cho các nút
            simpleButton1.Click += simpleButton1_Click; // Nút Chấp nhận
            Huy.Click += Huy_Click; // Nút Hủy bỏ
        }

        // Sự kiện Load của form
        private void ThemSoChi_Load(object sender, EventArgs e)
        {
            // Load dữ liệu loại chi vào comboBox1
            LoadLoaiChiComboBox();

            // Load dữ liệu hình thức thanh toán vào comboBox2
            LoadHTTTComboBox();

            // Thiết lập ngày mặc định là ngày hiện tại
            dateTimePicker1.Value = DateTime.Now;

            // Tìm form cha (FormSoChi)
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormSoChi)
                {
                    formSoChi = (FormSoChi)form;
                    break;
                }
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
                // Tạo mã sổ chi mới (có thể dùng GUID hoặc tạo theo quy tắc khác)
                string maSoChi = "SC" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // Lấy giá trị từ các control
                int maLoaiChi = Convert.ToInt32(comboBox1.SelectedValue);
                string soChungTu = textBox1.Text.Trim();
                DateTime ngayLap = dateTimePicker1.Value;
                string httt = comboBox2.SelectedItem.ToString();
                string dienGiai = textBox5.Text.Trim();
                string nguoiNhan = textBox4.Text.Trim();

                // Tạo câu lệnh SQL để thêm dữ liệu
                string query = $@"INSERT INTO SoChi (MaSoChi, NgayLap, MaLoaiChi, SoTien, NguoiNhan, DienGiai, SoChungTu, HTTT) 
                               VALUES ('{maSoChi}', '{ngayLap.ToString("yyyy-MM-dd")}', {maLoaiChi}, {soTien}, N'{nguoiNhan}', N'{dienGiai}', '{soChungTu}', N'{httt}')";

                // Thực thi câu lệnh SQL
                ketnoiCSDL.ExecuteNonQuery(query);

                // Hiển thị thông báo thành công
                MessageBox.Show("Thêm sổ chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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