using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using IText = iTextSharp.text;
using System.IO;

namespace BanhKeo_Doan.FormBaoCaoThongKe
{
    public partial class FormCongNoKH : Form
    {
        private KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();

        public FormCongNoKH()
        {
            InitializeComponent();

            // Set default dates to current month
            DateTime now = DateTime.Now;
            dtpFrom.Value = new DateTime(now.Year, now.Month, 1);
            dtpTo.Value = now;

            // Rename checkbox and combobox labels for customer
            checkBoxNCC.Text = "Theo khách hàng";

            // Load KhachHang ComboBox
            LoadKhachHangComboBox();

            // Set up event handlers
            btnTimKiem.Click += BtnTimKiem_Click;
            btnInButton.Click += BtnInButton_Click;
            this.Load += FormCongNoKH_Load;

            // Set up checkbox event handlers
            checkBoxNCC.CheckedChanged += FilterCheckBox_CheckedChanged;
            checkBoxDate.CheckedChanged += FilterCheckBox_CheckedChanged;

            // Initially disable filter controls
            cbTenKH.Enabled = false;
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;
        }

        private void FormCongNoKH_Load(object sender, EventArgs e)
        {
            // Load data when form loads
            LoadCongNoKHData();
        }

        private void FilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Enable/disable controls based on checkbox state
            cbTenKH.Enabled = checkBoxNCC.Checked;
            dtpFrom.Enabled = checkBoxDate.Checked;
            dtpTo.Enabled = checkBoxDate.Checked;
        }

        private void LoadKhachHangComboBox()
        {
            try
            {
                string query = "SELECT MaKhachHang, TenKhachHang FROM KhachHang ORDER BY TenKhachHang";
                DataTable dt = ketnoiCSDL.GetData(query);

                // Add a default "All" option
                DataRow allRow = dt.NewRow();
                allRow["MaKhachHang"] = 0;
                allRow["TenKhachHang"] = "-- Tất cả --";
                dt.Rows.InsertAt(allRow, 0);

                cbTenKH.DataSource = dt;
                cbTenKH.DisplayMember = "TenKhachHang";
                cbTenKH.ValueMember = "MaKhachHang";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCongNoKHData()
        {
            try
            {
                // Build the query based on filter conditions
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append(@"
                    SELECT 
                        KH.MaKhachHang,
                        KH.TenKhachHang,
                        ISNULL(KH.NoCu, 0) AS NoDauKy,
                        ISNULL(SUM(HD.TongTien), 0) AS PhatSinhMuaHang,
                        ISNULL(SUM(PT.SoTien), 0) AS ThanhToanTrongKy,
                        ISNULL(KH.NoCu, 0) + ISNULL(SUM(HD.TongTien), 0) - ISNULL(SUM(PT.SoTien), 0) AS NoCuoiKy
                    FROM KhachHang KH
                ");

                // Date filter conditions for HoaDonXuatHang and PhieuThuTienKH
                if (checkBoxDate.Checked)
                {
                    queryBuilder.Append($@"
                        LEFT JOIN HoaDonXuatHang HD ON KH.MaKhachHang = HD.MaKhachHang 
                        AND HD.NgayXuat BETWEEN '{dtpFrom.Value.ToString("yyyy-MM-dd")}' AND '{dtpTo.Value.ToString("yyyy-MM-dd 23:59:59")}'
                        LEFT JOIN PhieuThuTienKH PT ON KH.MaKhachHang = PT.MaKhachHang 
                        AND PT.NgayLap BETWEEN '{dtpFrom.Value.ToString("yyyy-MM-dd")}' AND '{dtpTo.Value.ToString("yyyy-MM-dd 23:59:59")}'
                    ");
                }
                else
                {
                    queryBuilder.Append(@"
                        LEFT JOIN HoaDonXuatHang HD ON KH.MaKhachHang = HD.MaKhachHang
                        LEFT JOIN PhieuThuTienKH PT ON KH.MaKhachHang = PT.MaKhachHang
                    ");
                }

                // Customer filter
                if (checkBoxNCC.Checked && cbTenKH.SelectedValue != null && (int)cbTenKH.SelectedValue != 0)
                {
                    queryBuilder.Append($@"
                        WHERE KH.MaKhachHang = {cbTenKH.SelectedValue}
                    ");
                }

                // Group by
                queryBuilder.Append(@"
                    GROUP BY KH.MaKhachHang, KH.TenKhachHang, KH.NoCu
                    ORDER BY KH.TenKhachHang
                ");

                // Execute query and bind to DataGridView
                DataTable dt = ketnoiCSDL.GetData(queryBuilder.ToString());
                dataGridView1.DataSource = dt;

                // Format DataGridView columns
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu công nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            // Set column headers and formatting
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["MaKhachHang"].HeaderText = "Mã KH";
                dataGridView1.Columns["TenKhachHang"].HeaderText = "Tên khách hàng";
                dataGridView1.Columns["NoDauKy"].HeaderText = "Nợ đầu kỳ";
                dataGridView1.Columns["PhatSinhMuaHang"].HeaderText = "Phát sinh mua hàng";
                dataGridView1.Columns["ThanhToanTrongKy"].HeaderText = "Thanh toán trong kỳ";
                dataGridView1.Columns["NoCuoiKy"].HeaderText = "Nợ cuối kỳ";

                // Format currency columns
                dataGridView1.Columns["NoDauKy"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["PhatSinhMuaHang"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["ThanhToanTrongKy"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["NoCuoiKy"].DefaultCellStyle.Format = "N0";

                // Auto size columns
                dataGridView1.AutoResizeColumns();
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            LoadCongNoKHData();
        }

        private void BtnInButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dữ liệu không
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để in báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị hộp thoại lưu file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Lưu báo cáo công nợ khách hàng";
                saveFileDialog.FileName = "BaoCaoCongNoKH_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Tạo file PDF
                    ExportToPdf(saveFileDialog.FileName);

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Xuất báo cáo PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở file PDF
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToPdf(string fileName)
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
                IText.Font titleFont = new IText.Font(baseFont, 16, IText.Font.BOLD);
                IText.Font headerFont = new IText.Font(baseFont, 14, IText.Font.BOLD);

                // Thêm header - Tên công ty
                Paragraph companyName = new Paragraph("Công ty TNHH Đầu tư Sản xuất & XNK Hoàng Gia", headerFont);
                companyName.Alignment = Element.ALIGN_CENTER;
                document.Add(companyName);

                // Thêm tiêu đề báo cáo
                Paragraph title = new Paragraph("THỐNG KÊ CÔNG NỢ KHÁCH HÀNG", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                // Thêm ngày theo dõi
                string dateFilter = "Ngày theo dõi: ";
                if (checkBoxDate.Checked)
                {
                    dateFilter += dtpFrom.Value.ToString("dd/MM/yyyy") + " - " + dtpTo.Value.ToString("dd/MM/yyyy");
                }
                else
                {
                    dateFilter += DateTime.Now.ToString("dd/MM/yyyy");
                }

                Paragraph dateReport = new Paragraph(dateFilter, normalFont);
                dateReport.Alignment = Element.ALIGN_CENTER;
                document.Add(dateReport);

                document.Add(new Paragraph(" ")); // Khoảng trắng

                // Tạo bảng báo cáo công nợ
                PdfPTable table = new PdfPTable(6);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 0.5f, 3, 1.5f, 1.5f, 1.5f, 1.5f });

                // Thêm header cho bảng
                PdfPCell cell = new PdfPCell(new Phrase("STT", boldFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Padding = 5;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Tên khách hàng", boldFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Padding = 5;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Nợ đầu kỳ", boldFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Padding = 5;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Phát sinh mua hàng", boldFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Padding = 5;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Thanh toán trong kỳ", boldFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Padding = 5;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Nợ cuối kỳ", boldFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Padding = 5;
                table.AddCell(cell);

                // Thêm dữ liệu từ DataGridView vào bảng
                decimal totalDebt = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    // Skip the last row if it's the new row
                    if (dataGridView1.Rows[i].IsNewRow)
                        continue;

                    DataGridViewRow row = dataGridView1.Rows[i];

                    try
                    {
                        // STT
                        cell = new PdfPCell(new Phrase((i + 1).ToString(), normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        table.AddCell(cell);

                        // Tên khách hàng
                        string tenKH = row.Cells["TenKhachHang"].Value != null ? row.Cells["TenKhachHang"].Value.ToString() : "";
                        cell = new PdfPCell(new Phrase(tenKH, normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        table.AddCell(cell);

                        // Nợ đầu kỳ
                        decimal noDauKy = row.Cells["NoDauKy"].Value != null ? Convert.ToDecimal(row.Cells["NoDauKy"].Value) : 0;
                        cell = new PdfPCell(new Phrase(string.Format("{0:N0}", noDauKy), normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        table.AddCell(cell);

                        // Phát sinh mua hàng
                        decimal phatSinh = row.Cells["PhatSinhMuaHang"].Value != null ? Convert.ToDecimal(row.Cells["PhatSinhMuaHang"].Value) : 0;
                        cell = new PdfPCell(new Phrase(string.Format("{0:N0}", phatSinh), normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        table.AddCell(cell);

                        // Thanh toán trong kỳ
                        decimal thanhToan = row.Cells["ThanhToanTrongKy"].Value != null ? Convert.ToDecimal(row.Cells["ThanhToanTrongKy"].Value) : 0;
                        cell = new PdfPCell(new Phrase(string.Format("{0:N0}", thanhToan), normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        table.AddCell(cell);

                        // Nợ cuối kỳ
                        decimal noCuoiKy = row.Cells["NoCuoiKy"].Value != null ? Convert.ToDecimal(row.Cells["NoCuoiKy"].Value) : 0;
                        cell = new PdfPCell(new Phrase(string.Format("{0:N0}", noCuoiKy), normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        table.AddCell(cell);

                        // Cộng dồn tổng nợ
                        totalDebt += noCuoiKy;
                    }
                    catch (Exception ex)
                    {
                        // Log lỗi nhưng tiếp tục xử lý các dòng khác
                        Console.WriteLine("Lỗi khi xử lý dòng " + i + ": " + ex.Message);
                    }
                }

                // Thêm dòng tổng cộng
                cell = new PdfPCell(new Phrase("", normalFont));
                cell.Colspan = 5;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.Padding = 5;
                cell.Phrase = new Phrase("Tổng cộng", boldFont);
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(string.Format("{0:N0}", totalDebt), boldFont));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.Padding = 5;
                table.AddCell(cell);

                document.Add(table);

                document.Add(new Paragraph(" ")); // Khoảng trắng
                document.Add(new Paragraph(" ")); // Khoảng trắng

                // Thêm chữ ký
                PdfPTable signatureTable = new PdfPTable(3);
                signatureTable.WidthPercentage = 100;

                // Cột trống bên trái
                PdfPCell emptyCell = new PdfPCell(new Phrase("", normalFont));
                emptyCell.Border = 0;
                signatureTable.AddCell(emptyCell);

                // Người lập báo cáo ở giữa
                PdfPCell reporterCell = new PdfPCell(new Phrase("Người lập báo cáo", boldFont));
                reporterCell.Border = 0;
                reporterCell.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(reporterCell);

                // Cột trống bên phải
                signatureTable.AddCell(emptyCell);

                // Thêm khoảng trắng cho chữ ký
                signatureTable.AddCell(emptyCell);

                PdfPCell blankCell = new PdfPCell(new Phrase("\n\n\n\n", normalFont));
                blankCell.Border = 0;
                signatureTable.AddCell(blankCell);

                signatureTable.AddCell(emptyCell);

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
