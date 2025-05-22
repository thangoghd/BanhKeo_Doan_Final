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
    public partial class SuaSoThu : Form
    {
        private KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
        private FormSoThu formSoThu; // Tham chiếu đến form cha
        private string maSoThu; // Mã sổ thu cần sửa

        public SuaSoThu()
        {
            InitializeComponent();
            this.Load += SuaSoThu_Load;

            // Đăng ký sự kiện cho các nút
            simpleButton1.Click += simpleButton1_Click; // Nút Chấp nhận
            Huy.Click += Huy_Click; // Nút Hủy bỏ
        }

        // Sự kiện Load của form
        private void SuaSoThu_Load(object sender, EventArgs e)
        {
            // Load dữ liệu loại thu vào comboBox1
            LoadLoaiThuComboBox();

            // Load dữ liệu hình thức thanh toán vào comboBox2
            LoadHTTTComboBox();

            // Tìm form cha (FormSoThu)
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormSoThu)
                {
                    formSoThu = (FormSoThu)form;
                    break;
                }
            }

            // Kiểm tra xem có dòng hoặc ô nào được chọn trong dataGridView1 của FormSoThu không
            if (formSoThu != null)
            {
                if (formSoThu.dataGridView1.SelectedCells.Count > 0)
                {
                    DataGridViewCell cell = formSoThu.dataGridView1.SelectedCells[0];
                    DataGridViewRow row = formSoThu.dataGridView1.Rows[cell.RowIndex];
                    maSoThu = row.Cells["MaSoThu"].Value.ToString();
                    LoadSoThuInfo();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một ô để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy form Sổ Thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        // Phương thức load thông tin sổ thu cần sửa
        private void LoadSoThuInfo()
        {
            try
            {
                string query = $@"SELECT st.MaSoThu, st.NgayLap, st.MaLoaiThu, st.SoTien, 
                               st.NguoiNop, st.DienGiai, st.SoChungTu, st.HTTT 
                               FROM SoThu st 
                               WHERE st.MaSoThu = '{maSoThu}'";

                DataTable dt = ketnoiCSDL.GetData(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Hiển thị thông tin lên form
                    textBox1.Text = row["SoChungTu"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(row["NgayLap"]);
                    int soTien = Convert.ToInt32(row["SoTien"]);
                    textBox3.Text = soTien.ToString();
                    textBox5.Text = row["DienGiai"].ToString();
                    textBox4.Text = row["NguoiNop"].ToString();

                    // Chọn loại thu
                    comboBox1.SelectedValue = row["MaLoaiThu"];

                    // Chọn hình thức thanh toán
                    string httt = row["HTTT"].ToString();
                    for (int i = 0; i < comboBox2.Items.Count; i++)
                    {
                        if (comboBox2.Items[i].ToString() == httt)
                        {
                            comboBox2.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin sổ thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Phương thức load dữ liệu Loại Thu vào comboBox1
        private void LoadLoaiThuComboBox()
        {
            string query = "SELECT MaLoaiThu, TenLoaiThu FROM LoaiThu";
            DataTable dt = ketnoiCSDL.GetData(query);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TenLoaiThu";
            comboBox1.ValueMember = "MaLoaiThu";
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
                MessageBox.Show("Vui lòng chọn loại thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập số chứng từ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soTienValue;
            if (!int.TryParse(textBox3.Text, out soTienValue) || soTienValue <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ (số nguyên)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn hình thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Vui lòng nhập người nộp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy giá trị từ các control
                int maLoaiThu = Convert.ToInt32(comboBox1.SelectedValue);
                string soChungTu = textBox1.Text.Trim();
                DateTime ngayLap = dateTimePicker1.Value;
                string httt = comboBox2.SelectedItem.ToString();
                string dienGiai = textBox5.Text.Trim();
                string nguoiNop = textBox4.Text.Trim();
                // Đã kiểm tra và parse số tiền ở trên

                // Tạo câu lệnh SQL để cập nhật dữ liệu
                string query = $@"UPDATE SoThu 
                               SET NgayLap = '{ngayLap.ToString("yyyy-MM-dd")}', 
                                   MaLoaiThu = {maLoaiThu}, 
                                   SoTien = {soTienValue}, 
                                   NguoiNop = N'{nguoiNop}', 
                                   DienGiai = N'{dienGiai}', 
                                   SoChungTu = '{soChungTu}', 
                                   HTTT = N'{httt}' 
                               WHERE MaSoThu = '{maSoThu}'";

                Console.WriteLine(query); // In câu lệnh SQL để debug

                // Thực thi câu lệnh SQL
                ketnoiCSDL.ExecuteNonQuery(query);

                // Hiển thị thông báo thành công
                MessageBox.Show("Cập nhật sổ thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại dữ liệu ở form cha
                if (formSoThu != null)
                {
                    formSoThu.ReloadSoThuData();
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
