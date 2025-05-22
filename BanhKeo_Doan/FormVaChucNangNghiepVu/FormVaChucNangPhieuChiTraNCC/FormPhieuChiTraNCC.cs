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
using BanhKeo_Doan;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuChiTraNCC
{
    public partial class FormPhieuChiTraNCC : Form
    {
        private KetNoiCSDL db;

        DocTienBangChu reader = new DocTienBangChu();

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

            // Đăng ký sự kiện cho nút In
            btnInButton.Click += btnInButton_Click;

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

        private void btnInButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    // Lấy mã phiếu chi trả được chọn
                    string maPhieuChiTra = dataGridView1.CurrentRow.Cells["MaPhieuChiTra"].Value.ToString();

                    // Truy vấn dữ liệu chi tiết của phiếu chi trả
                    string query = $@"SELECT p.MaPhieuChiTra, p.NgayLap, p.MaNhaCungCap, ncc.TenNhaCungCap, 
                                   ncc.DiaChi, p.SoChungTu, p.DienGiai, p.SoTien, p.HTTT, p.NguoiNhan, 
                                   p.GiaoDich, p.TrangThai, p.MaNhanVien, nv.TenNhanVien
                                FROM PhieuChiTraNCC p
                                LEFT JOIN NhaCungCap ncc ON p.MaNhaCungCap = ncc.MaNhaCungCap
                                LEFT JOIN NhanVien nv ON p.MaNhanVien = nv.MaNhanVien
                                WHERE p.MaPhieuChiTra = '{maPhieuChiTra}'";

                    DataTable dt = db.GetData(query);

                    if (dt.Rows.Count > 0)
                    {
                        // Hiển thị hộp thoại SaveFileDialog để người dùng chọn nơi lưu file PDF
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                        saveFileDialog.Title = "Lưu phiếu chi trả NCC";
                        saveFileDialog.FileName = $"PhieuChiTraNCC_{maPhieuChiTra}_{DateTime.Now.ToString("yyyyMMdd")}";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Xuất phiếu chi trả ra file PDF
                            ExportToPdf(dt.Rows[0], saveFileDialog.FileName);

                            // Hỏi người dùng có muốn mở file PDF vừa tạo không
                            DialogResult result = MessageBox.Show(
                                "Phiếu chi trả đã được xuất thành công! Bạn có muốn mở file không?",
                                "Thông báo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);

                            if (result == DialogResult.Yes)
                            {
                                System.Diagnostics.Process.Start(saveFileDialog.FileName);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin phiếu chi trả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất phiếu chi trả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu chi để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                Font normalFont = new Font(baseFont, 12);
                Font italicFont = new Font(baseFont, 10, 2);
                Font boldFont = new Font(baseFont, 12, 1); // 1 = Font.BOLD
                Font titleFont = new Font(baseFont, 18, 1); // 1 = Font.BOLD
                Font headerFont = new Font(baseFont, 14, 1); // 1 = Font.BOLD
                Font smallFont = new Font(baseFont, 10);

                // Tạo bảng cho header với 3 cột
                PdfPTable headerTable = new PdfPTable(3);
                headerTable.WidthPercentage = 100;
                headerTable.SetWidths(new float[] { 2, 1, 1 });

                // Cột trái: Thông tin đơn vị
                PdfPCell leftHeaderCell = new PdfPCell();
                leftHeaderCell.Border = 0;
                Paragraph para = new Paragraph();
                para.Add(new Chunk("Đơn vị: ", boldFont));
                para.Add(new Chunk(Constants.TEN_CONG_TY, normalFont));
                leftHeaderCell.AddElement(para);
                leftHeaderCell.AddElement(new Paragraph("33 Quang Trung, Hồng Bàng, Hải Phòng", normalFont));
                headerTable.AddCell(leftHeaderCell);

                // Cột giữa: Thông tin Số chứng từ
                PdfPCell centerHeaderCell = new PdfPCell();
                centerHeaderCell.Border = 0;
                centerHeaderCell.AddElement(new Paragraph("Quyển: ", normalFont));
                centerHeaderCell.AddElement(new Paragraph(row["SoChungTu"].ToString(), normalFont));
                headerTable.AddCell(centerHeaderCell);

                // Cột phải: Thông tin mẫu phiếu
                PdfPCell rightHeaderCell = new PdfPCell();
                rightHeaderCell.Border = 0;
                rightHeaderCell.AddElement(new Paragraph("Mẫu số C31-BB", smallFont));
                rightHeaderCell.AddElement(new Paragraph("QĐ số: 19/2006/QĐ-BTC", smallFont));
                rightHeaderCell.AddElement(new Paragraph("Ngày 30 tháng 3 năm 2006", smallFont));
                rightHeaderCell.AddElement(new Paragraph("của Bộ trưởng BTC", smallFont));
                rightHeaderCell.VerticalAlignment = Element.ALIGN_CENTER;
                headerTable.AddCell(rightHeaderCell);
                document.Add(headerTable);

                // Tiêu đề PHIẾU CHI
                Paragraph title = new Paragraph("PHIẾU CHI", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                // Thêm ngày tháng
                DateTime ngayLap = Convert.ToDateTime(row["NgayLap"]);
                Paragraph date = new Paragraph("Ngày " + ngayLap.Day + " tháng " + ngayLap.Month + " năm " + ngayLap.Year, italicFont);
                date.Alignment = Element.ALIGN_CENTER;
                document.Add(date);

                document.Add(new Paragraph(" ")); // Khoảng trắng

                // Thông tin người nhận tiền và lý do chi
                Paragraph nguoiNhan = new Paragraph("Họ tên người nhận tiền: " + row["NguoiNhan"].ToString(), normalFont);
                document.Add(nguoiNhan);

                Paragraph diaChi = new Paragraph("Địa chỉ: " + (row["DiaChi"] != DBNull.Value ? row["DiaChi"].ToString() : ""), normalFont);
                document.Add(diaChi);

                Paragraph lyDoChi = new Paragraph("Lý do chi: " + row["DienGiai"].ToString(), normalFont);
                document.Add(lyDoChi);

                document.Add(new Paragraph(" ")); // Khoảng trắng

                // Số tiền
                decimal soTien = Convert.ToDecimal(row["SoTien"]);
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1.5f, 3.5f }); // tùy chỉnh tỉ lệ

                // Cột trái: Số tiền
                PdfPCell left = new PdfPCell(new Phrase("Số tiền: " + string.Format("{0:N0}", soTien), boldFont));
                left.Border = 0;
                table.AddCell(left);

                // Cột phải: Viết bằng chữ
                PdfPCell right = new PdfPCell(new Phrase("(Viết bằng chữ: " + reader.Doc(soTien) + ")", italicFont));
                right.Border = 0;
                table.AddCell(right);

                document.Add(table);


                document.Add(new Paragraph(" ")); // Khoảng trắng

                // Kèm theo chứng từ
                Paragraph kemTheo = new Paragraph("Kèm theo: ....................... chứng từ kế toán", normalFont);
                document.Add(kemTheo);

                document.Add(new Paragraph(" ")); // Khoảng trắng
                document.Add(new Paragraph(" ")); // Khoảng trắng

                // Thêm chữ ký
                PdfPTable signatureTable = new PdfPTable(5);
                signatureTable.WidthPercentage = 100;

                // Tiêu đề các ô chữ ký
                string[] signatureTitles = { "Người lập", "Người nhận", "Thủ quỹ", "Kế toán trưởng", "Giám đốc" };
                string[] signatureNotes = { "(Ký, họ tên)", "(Ký, họ tên)", "(Ký, họ tên)", "(Ký, họ tên)", "(Ký, họ tên, đóng dấu)" };

                for (int i = 0; i < signatureTitles.Length; i++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;

                    Paragraph title1 = new Paragraph(signatureTitles[i], boldFont);
                    title1.Alignment = Element.ALIGN_CENTER;
                    cell.AddElement(title1);

                    Paragraph note = new Paragraph(signatureNotes[i], italicFont);
                    note.Alignment = Element.ALIGN_CENTER;
                    cell.AddElement(note);

                    signatureTable.AddCell(cell);
                }

                // Thêm khoảng trắng cho chữ ký
                for (int i = 0; i < 5; i++)
                {
                    PdfPCell blankCell = new PdfPCell(new Phrase("\n\n\n\n", normalFont));
                    blankCell.Border = 0;
                    signatureTable.AddCell(blankCell);
                }

                // Thêm các ô trống còn lại
                for (int i = 0; i < 3; i++)
                {
                    PdfPCell emptyCell = new PdfPCell(new Phrase("", normalFont));
                    emptyCell.Border = 0;
                    signatureTable.AddCell(emptyCell);
                }

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
    }
}
