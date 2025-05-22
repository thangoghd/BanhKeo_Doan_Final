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
using iTextSharp.text;
using iTextSharp.text.pdf;
using IText = iTextSharp.text;
using System.IO;

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


            // Thiết lập trạng thái ban đầu cho các control tìm kiếm
            cbLoaiThu.Enabled = false;
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;

            // Thiết lập ngày mặc định cho dateTimePicker
            dtpFrom.Value = DateTime.Now.AddDays(-30); // Mặc định 30 ngày trước
            dtpTo.Value = DateTime.Now;
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

            cbLoaiThu.DataSource = dt;
            cbLoaiThu.DisplayMember = "TenLoaiThu";
            cbLoaiThu.ValueMember = "MaLoaiThu";
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = @"SELECT st.MaSoThu, st.NgayLap, lt.TenLoaiThu, st.SoTien, 
                           st.NguoiNop, st.DienGiai, st.SoChungTu, st.HTTT 
                           FROM SoThu st 
                           LEFT JOIN LoaiThu lt ON st.MaLoaiThu = lt.MaLoaiThu
                           WHERE 1=1";

            //Nếu tìm theo loại thu
            if (checkBoxLoaiThu.Checked && cbLoaiThu.SelectedIndex > 0) // Chỉ áp dụng khi không phải "Tất cả"
            {
                query += " AND st.MaLoaiThu = " + cbLoaiThu.SelectedValue;
            }

            //Nếu tìm theo ngày
            if (checkBoxNgay.Checked)
            {
                DateTime tuNgay = dtpFrom.Value.Date;
                DateTime denNgay = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);
                query += " AND st.NgayLap BETWEEN '" + tuNgay.ToString("yyyy-MM-dd") + "' AND '" + denNgay.ToString("yyyy-MM-dd") + "'";
            }

            //Thực hiện tìm kiếm
            DataTable dt = ketnoiCSDL.GetData(query);
            dataGridView1.DataSource = dt;

            //Định dạng DataGridView
            FormatDataGridView();

            //Hiển thị thông báo kết quả
            int rowCount = dataGridView1.Rows.Count;
            MessageBox.Show($"Tìm thấy {rowCount} kết quả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Phương thức định dạng DataGridView
        private void FormatDataGridView()
        {
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

        // Sự kiện khi nhấn nút In
        private void btnInSoThu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ô nào được chọn không
            if (dataGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    // Lấy dòng chứa ô được chọn
                    DataGridViewCell cell = dataGridView1.SelectedCells[0];
                    DataGridViewRow row = dataGridView1.Rows[cell.RowIndex];
                    string maSoThu = row.Cells["MaSoThu"].Value.ToString();

                    // Lấy thông tin chi tiết của sổ thu
                    string query = $@"SELECT st.MaSoThu, st.NgayLap, lt.TenLoaiThu, st.SoTien, 
                           st.NguoiNop, st.DienGiai, st.SoChungTu, st.HTTT, st.MaLoaiThu
                           FROM SoThu st 
                           LEFT JOIN LoaiThu lt ON st.MaLoaiThu = lt.MaLoaiThu
                           WHERE st.MaSoThu = '{maSoThu}'";

                    DataTable dt = ketnoiCSDL.GetData(query);

                    if (dt.Rows.Count > 0)
                    {
                        // Hiển thị hộp thoại lưu file
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                        saveFileDialog.Title = "Lưu file PDF";
                        saveFileDialog.FileName = "SoThu_" + maSoThu + ".pdf";

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
                MessageBox.Show("Vui lòng chọn một sổ thu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                Paragraph title = new Paragraph("PHIẾU THU TIỀN", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                // Thêm ngày tháng
                Paragraph date = new Paragraph("Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year, normalFont);
                date.Alignment = Element.ALIGN_RIGHT;
                document.Add(date);

                document.Add(new Paragraph(" ")); // Khoảng trắng

                // Tạo bảng thông tin phiếu thu
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1, 2 });

                // Thêm thông tin phiếu thu vào bảng
                AddRowToTable(table, "Mã sổ thu:", row["MaSoThu"].ToString(), normalFont, normalFont);
                AddRowToTable(table, "Số chứng từ:", row["SoChungTu"].ToString(), normalFont, normalFont);
                AddRowToTable(table, "Ngày lập:", Convert.ToDateTime(row["NgayLap"]).ToString("dd/MM/yyyy"), normalFont, normalFont);
                AddRowToTable(table, "Loại thu:", row["TenLoaiThu"].ToString(), normalFont, normalFont);
                AddRowToTable(table, "Số tiền:", string.Format("{0:N0} VNĐ", Convert.ToInt32(row["SoTien"])), normalFont, boldFont);
                AddRowToTable(table, "Người nộp:", row["NguoiNop"].ToString(), normalFont, normalFont);
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

                PdfPCell cell2 = new PdfPCell(new Phrase("Người nộp tiền", normalFont));
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

        private void checkBoxLoaiThu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLoaiThu.Checked)
            {
                cbLoaiThu.Enabled = true;
            }
            else
            {
                cbLoaiThu.Enabled = false;
            }
        }

        private void checkBoxNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNgay.Checked)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }
    }
}
