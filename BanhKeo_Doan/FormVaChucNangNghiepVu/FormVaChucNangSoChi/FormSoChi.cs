using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BanhKeo_Doan.KetNoiCSDL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using IText = iTextSharp.text;
using System.IO;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangSoChi
{
    public partial class FormSoChi : Form
    {
        private KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();

        public FormSoChi()
        {
            InitializeComponent();
            this.Load += FormSoChi_Load;

            // Đăng ký sự kiện cho các checkbox
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
        }

        // Sự kiện Load của form
        private void FormSoChi_Load(object sender, EventArgs e)
        {
            // Load dữ liệu Sổ Chi khi form được mở
            LoadSoChiData();

            // Load dữ liệu Loại Chi vào comboBox1 để phục vụ tìm kiếm
            LoadLoaiChiComboBox();

            // Thiết lập trạng thái ban đầu cho các control tìm kiếm
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;

            // Thiết lập ngày mặc định cho dateTimePicker
            dateTimePicker1.Value = DateTime.Now.AddDays(-30); // Mặc định 30 ngày trước
            dateTimePicker2.Value = DateTime.Now;
        }

        // Phương thức load dữ liệu Sổ Chi
        public void LoadSoChiData()
        {
            string query = @"SELECT sc.MaSoChi, sc.NgayLap, lc.TenLoaiChi, sc.SoTien, 
                           sc.NguoiNhan, sc.DienGiai, sc.SoChungTu, sc.HTTT 
                           FROM SoChi sc 
                           LEFT JOIN LoaiChi lc ON sc.MaLoaiChi = lc.MaLoaiChi";

            dataGridView1.DataSource = ketnoiCSDL.GetData(query);

            // Định dạng DataGridView
            FormatDataGridView();
        }

        // Phương thức load dữ liệu Loại Chi vào comboBox1
        private void LoadLoaiChiComboBox()
        {
            string query = "SELECT MaLoaiChi, TenLoaiChi FROM LoaiChi";
            DataTable dt = ketnoiCSDL.GetData(query);

            // Thêm một hàng "Tất cả" vào đầu DataTable
            DataRow allRow = dt.NewRow();
            allRow["MaLoaiChi"] = 0;
            allRow["TenLoaiChi"] = "Tất cả";
            dt.Rows.InsertAt(allRow, 0);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TenLoaiChi";
            comboBox1.ValueMember = "MaLoaiChi";
        }

        // Sự kiện khi nhấn nút Thêm
        private void btnThemSoChi_Click(object sender, EventArgs e)
        {
            ThemSoChi themSoChi = new ThemSoChi();
            themSoChi.Show();
        }

        // Sự kiện khi nhấn nút Sửa
        private void btnSuaSoChi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // Lấy dòng chứa ô được chọn
                DataGridViewCell cell = dataGridView1.SelectedCells[0];
                DataGridViewRow row = dataGridView1.Rows[cell.RowIndex];
                string maSoChi = row.Cells["MaSoChi"].Value.ToString();

                // Tạo form sửa sổ chi và truyền mã sổ chi cần sửa
                SuaSoChi suaSoChi = new SuaSoChi(maSoChi);
                suaSoChi.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ô để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Sự kiện khi nhấn nút Xóa
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    // Lấy dòng chứa ô được chọn
                    DataGridViewCell cell = dataGridView1.SelectedCells[0];
                    DataGridViewRow row = dataGridView1.Rows[cell.RowIndex];
                    string maSoChi = row.Cells["MaSoChi"].Value.ToString();

                    // Hiển thị hộp thoại xác nhận
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sổ chi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Tạo câu lệnh SQL để xóa dữ liệu
                        string query = $"DELETE FROM SoChi WHERE MaSoChi = '{maSoChi}'";

                        // Thực thi câu lệnh SQL
                        ketnoiCSDL.ExecuteNonQuery(query);

                        // Hiển thị thông báo thành công
                        MessageBox.Show("Xóa sổ chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật lại dữ liệu
                        LoadSoChiData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ô để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Sự kiện khi nhấn nút In
        private void btnInButton_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ô nào được chọn không
            if (dataGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    // Lấy dòng chứa ô được chọn
                    DataGridViewCell cell = dataGridView1.SelectedCells[0];
                    DataGridViewRow row = dataGridView1.Rows[cell.RowIndex];
                    string maSoChi = row.Cells["MaSoChi"].Value.ToString();

                    // Lấy thông tin chi tiết của sổ chi
                    string query = $@"SELECT sc.MaSoChi, sc.NgayLap, lc.TenLoaiChi, sc.SoTien, 
                           sc.NguoiNhan, sc.DienGiai, sc.SoChungTu, sc.HTTT, sc.MaLoaiChi
                           FROM SoChi sc 
                           LEFT JOIN LoaiChi lc ON sc.MaLoaiChi = lc.MaLoaiChi
                           WHERE sc.MaSoChi = '{maSoChi}'";

                    DataTable dt = ketnoiCSDL.GetData(query);

                    if (dt.Rows.Count > 0)
                    {
                        // Hiển thị hộp thoại lưu file
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                        saveFileDialog.Title = "Lưu file PDF";
                        saveFileDialog.FileName = "SoChi_" + maSoChi + ".pdf";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Tạo file PDF
                            ExportToPdf(dt.Rows[0], saveFileDialog.FileName);

                            // Hiển thị thông báo thành công
                            MessageBox.Show("Xuất file PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Mở file PDF
                            System.Diagnostics.Process.Start(saveFileDialog.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sổ chi để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Phương thức xuất PDF sử dụng iTextSharp
        private void ExportToPdf(DataRow row, string fileName)
        {
            // Tạo document với kích thước A4
            Document document = new Document(PageSize.A4);

            try
            {
                // Tạo PdfWriter
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

                // Mở document
                document.Open();

                // Tạo font Unicode để hỗ trợ tiếng Việt font Times New Roman
                BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                IText.Font normalFont = new IText.Font(baseFont, 12);
                IText.Font boldFont = new IText.Font(baseFont, 12, IText.Font.BOLD);
                IText.Font titleFont = new IText.Font(baseFont, 18, IText.Font.BOLD);
                IText.Font headerFont = new IText.Font(baseFont, 14, IText.Font.BOLD);

                // Thêm header
                Paragraph header = new Paragraph("CÔNG TY BÁNH KẸO", headerFont);
                header.Alignment = Element.ALIGN_CENTER;
                document.Add(header);

                Paragraph title = new Paragraph("PHIẾU CHI TIỀN", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                // Thêm ngày tháng
                Paragraph date = new Paragraph("Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year, normalFont);
                date.Alignment = Element.ALIGN_RIGHT;
                document.Add(date);

                document.Add(new Paragraph(" ")); // Khoảng trắng

                // Tạo bảng thông tin phiếu chi
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1, 2 });

                // Thêm thông tin phiếu chi vào bảng
                AddRowToTable(table, "Mã sổ chi:", row["MaSoChi"].ToString(), normalFont, normalFont);
                AddRowToTable(table, "Số chứng từ:", row["SoChungTu"].ToString(), normalFont, normalFont);
                AddRowToTable(table, "Ngày lập:", Convert.ToDateTime(row["NgayLap"]).ToString("dd/MM/yyyy"), normalFont, normalFont);
                AddRowToTable(table, "Loại chi:", row["TenLoaiChi"].ToString(), normalFont, normalFont);
                AddRowToTable(table, "Số tiền:", string.Format("{0:N0} VNĐ", Convert.ToInt32(row["SoTien"])), normalFont, boldFont);
                AddRowToTable(table, "Người nhận:", row["NguoiNhan"].ToString(), normalFont, normalFont);
                AddRowToTable(table, "Diễn giải:", row["DienGiai"].ToString(), normalFont, normalFont);
                AddRowToTable(table, "Hình thức thanh toán:", row["HTTT"].ToString(), normalFont, normalFont);

                document.Add(table);

                document.Add(new Paragraph(" ")); // Khoảng trắng
                document.Add(new Paragraph(" ")); // Khoảng trắng

                // Thêm chữ ký
                PdfPTable signatureTable = new PdfPTable(2);
                signatureTable.WidthPercentage = 100;

                PdfPCell cell1 = new PdfPCell(new Phrase("Người lập phiếu", normalFont));
                cell1.Border = 0;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell1);

                PdfPCell cell2 = new PdfPCell(new Phrase("Người nhận tiền", normalFont));
                cell2.Border = 0;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell2);

                // Thêm khoảng trắng cho chữ ký
                PdfPCell blankCell1 = new PdfPCell(new Phrase("\n\n\n\n", normalFont));
                blankCell1.Border = 0;
                signatureTable.AddCell(blankCell1);

                PdfPCell blankCell2 = new PdfPCell(new Phrase("\n\n\n\n", normalFont));
                blankCell2.Border = 0;
                signatureTable.AddCell(blankCell2);

                // Thêm dòng gạch chân cho chữ ký
                PdfPCell signatureLineCell1 = new PdfPCell(new Phrase(".........................", normalFont));
                signatureLineCell1.Border = 0;
                signatureLineCell1.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(signatureLineCell1);

                PdfPCell signatureLineCell2 = new PdfPCell(new Phrase(".........................", normalFont));
                signatureLineCell2.Border = 0;
                signatureLineCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(signatureLineCell2);

                document.Add(signatureTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng document
                document.Close();
            }
        }

        // Phương thức thêm dòng vào bảng
        private void AddRowToTable(PdfPTable table, string label, string value, IText.Font labelFont, IText.Font valueFont)
        {
            PdfPCell cell1 = new PdfPCell(new Phrase(label, labelFont));
            cell1.Border = 0;
            cell1.Padding = 5;
            table.AddCell(cell1);

            PdfPCell cell2 = new PdfPCell(new Phrase(value, valueFont));
            cell2.Border = 0;
            cell2.Padding = 5;
            table.AddCell(cell2);
        }

        // Sự kiện khi nhấn nút Tìm kiếm
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Xây dựng câu lệnh SQL dựa trên các điều kiện tìm kiếm
            string query = @"SELECT sc.MaSoChi, sc.NgayLap, lc.TenLoaiChi, sc.SoTien, 
                           sc.NguoiNhan, sc.DienGiai, sc.SoChungTu, sc.HTTT 
                           FROM SoChi sc 
                           LEFT JOIN LoaiChi lc ON sc.MaLoaiChi = lc.MaLoaiChi
                           WHERE 1=1"; // 1=1 là điều kiện luôn đúng, giúp dễ dàng thêm các điều kiện AND

            // Nếu tìm theo loại chi
            if (checkBox1.Checked && comboBox1.SelectedIndex > 0) // Chỉ áp dụng khi không phải "Tất cả"
            {
                int maLoaiChi = Convert.ToInt32(comboBox1.SelectedValue);
                query += $" AND sc.MaLoaiChi = {maLoaiChi}";
            }

            // Nếu tìm theo ngày
            if (checkBox2.Checked)
            {
                DateTime tuNgay = dateTimePicker1.Value.Date;
                DateTime denNgay = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1); // Đến cuối ngày

                query += $" AND sc.NgayLap >= '{tuNgay.ToString("yyyy-MM-dd")}' AND sc.NgayLap <= '{denNgay.ToString("yyyy-MM-dd HH:mm:ss")}'";
            }

            // Thực hiện tìm kiếm
            dataGridView1.DataSource = ketnoiCSDL.GetData(query);

            // Đặt tiêu đề cột
            FormatDataGridView();

            // Hiển thị thông báo kết quả
            int rowCount = dataGridView1.Rows.Count;
            MessageBox.Show($"Tìm thấy {rowCount} kết quả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Sự kiện khi nhấn nút Đóng
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Sự kiện khi thay đổi trạng thái checkbox Theo loại chi
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Bật/tắt comboBox1 tương ứng với trạng thái checkbox
            comboBox1.Enabled = checkBox1.Checked;
        }

        // Sự kiện khi thay đổi trạng thái checkbox Theo ngày
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Bật/tắt dateTimePicker tương ứng với trạng thái checkbox
            dateTimePicker1.Enabled = checkBox2.Checked;
            dateTimePicker2.Enabled = checkBox2.Checked;
        }

        // Phương thức định dạng DataGridView
        private void FormatDataGridView()
        {
            // Đặt tiêu đề cột
            dataGridView1.Columns["MaSoChi"].HeaderText = "Mã sổ chi";
            dataGridView1.Columns["NgayLap"].HeaderText = "Ngày lập";
            dataGridView1.Columns["TenLoaiChi"].HeaderText = "Loại chi";
            dataGridView1.Columns["SoTien"].HeaderText = "Số tiền";
            dataGridView1.Columns["NguoiNhan"].HeaderText = "Người nhận";
            dataGridView1.Columns["DienGiai"].HeaderText = "Diễn giải";
            dataGridView1.Columns["SoChungTu"].HeaderText = "Số chứng từ";
            dataGridView1.Columns["HTTT"].HeaderText = "Hình thức thanh toán";

            // Định dạng hiển thị
            dataGridView1.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["SoTien"].DefaultCellStyle.Format = "N0";

            // Tự động điều chỉnh kích thước cột
            dataGridView1.AutoResizeColumns();
        }

        // Thêm phương thức Reload để có thể gọi từ các form khác
        public void ReloadSoChiData()
        {
            LoadSoChiData();
        }
    }
}