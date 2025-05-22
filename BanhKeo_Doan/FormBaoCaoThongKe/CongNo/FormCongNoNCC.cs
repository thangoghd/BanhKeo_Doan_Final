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
    public partial class FormCongNoNCC : Form
    {
        private KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();

        public FormCongNoNCC()
        {
            InitializeComponent();

            // Set default dates to current month
            DateTime now = DateTime.Now;
            dtpFrom.Value = new DateTime(now.Year, now.Month, 1);
            dtpTo.Value = now;

            // Load NCC ComboBox
            LoadNhaCungCapComboBox();

            // Set up event handlers
            btnTimKiem.Click += BtnTimKiem_Click;
            btnInButton.Click += BtnInButton_Click;
            this.Load += FormCongNoNCC_Load;

            // Set up checkbox event handlers
            checkBoxNCC.CheckedChanged += FilterCheckBox_CheckedChanged;
            checkBoxDate.CheckedChanged += FilterCheckBox_CheckedChanged;

            // Initially disable filter controls
            cbNCC.Enabled = false;
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;
        }

        private void FormCongNoNCC_Load(object sender, EventArgs e)
        {
            // Load data when form loads
            LoadCongNoNCCData();
        }

        private void FilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Enable/disable controls based on checkbox state
            cbNCC.Enabled = checkBoxNCC.Checked;
            dtpFrom.Enabled = checkBoxDate.Checked;
            dtpTo.Enabled = checkBoxDate.Checked;
        }

        private void LoadNhaCungCapComboBox()
        {
            try
            {
                string query = "SELECT MaNhaCungCap, TenNhaCungCap FROM NhaCungCap ORDER BY TenNhaCungCap";
                DataTable dt = ketnoiCSDL.GetData(query);

                // Add a default "All" option
                DataRow allRow = dt.NewRow();
                allRow["MaNhaCungCap"] = 0;
                allRow["TenNhaCungCap"] = "-- Tất cả --";
                dt.Rows.InsertAt(allRow, 0);

                cbNCC.DataSource = dt;
                cbNCC.DisplayMember = "TenNhaCungCap";
                cbNCC.ValueMember = "MaNhaCungCap";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCongNoNCCData()
        {
            try
            {
                // Build the query based on filter conditions
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append(@"
                    SELECT 
                        NCC.MaNhaCungCap,
                        NCC.TenNhaCungCap,
                        ISNULL(NCC.NoCu, 0) AS NoDauKy,
                        ISNULL(SUM(PN.TongTien), 0) AS PhatSinhNhapHang,
                        ISNULL(SUM(PC.SoTien), 0) AS ThanhToanTrongKy,
                        ISNULL(NCC.NoCu, 0) + ISNULL(SUM(PN.TongTien), 0) - ISNULL(SUM(PC.SoTien), 0) AS NoCuoiKy
                    FROM NhaCungCap NCC
                ");

                // Date filter conditions for PhieuNhap
                if (checkBoxDate.Checked)
                {
                    queryBuilder.Append($@"
                        LEFT JOIN PhieuNhap PN ON NCC.MaNhaCungCap = PN.MaNhaCungCap 
                        AND PN.NgayNhap BETWEEN '{dtpFrom.Value.ToString("yyyy-MM-dd")}' AND '{dtpTo.Value.ToString("yyyy-MM-dd 23:59:59")}'
                        LEFT JOIN PhieuChiTraNCC PC ON NCC.MaNhaCungCap = PC.MaNhaCungCap 
                        AND PC.NgayLap BETWEEN '{dtpFrom.Value.ToString("yyyy-MM-dd")}' AND '{dtpTo.Value.ToString("yyyy-MM-dd 23:59:59")}'
                    ");
                }
                else
                {
                    queryBuilder.Append(@"
                        LEFT JOIN PhieuNhap PN ON NCC.MaNhaCungCap = PN.MaNhaCungCap
                        LEFT JOIN PhieuChiTraNCC PC ON NCC.MaNhaCungCap = PC.MaNhaCungCap
                    ");
                }

                // Supplier filter
                if (checkBoxNCC.Checked && cbNCC.SelectedValue != null && (int)cbNCC.SelectedValue != 0)
                {
                    queryBuilder.Append($@"
                        WHERE NCC.MaNhaCungCap = {cbNCC.SelectedValue}
                    ");
                }

                // Group by
                queryBuilder.Append(@"
                    GROUP BY NCC.MaNhaCungCap, NCC.TenNhaCungCap, NCC.NoCu
                    ORDER BY NCC.TenNhaCungCap
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
                dataGridView1.Columns["MaNhaCungCap"].HeaderText = "Mã NCC";
                dataGridView1.Columns["TenNhaCungCap"].HeaderText = "Tên nhà cung cấp";
                dataGridView1.Columns["NoDauKy"].HeaderText = "Nợ đầu kỳ";
                dataGridView1.Columns["PhatSinhNhapHang"].HeaderText = "Phát sinh nhập hàng";
                dataGridView1.Columns["ThanhToanTrongKy"].HeaderText = "Thanh toán trong kỳ";
                dataGridView1.Columns["NoCuoiKy"].HeaderText = "Nợ cuối kỳ";

                // Format currency columns
                dataGridView1.Columns["NoDauKy"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["PhatSinhNhapHang"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["ThanhToanTrongKy"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["NoCuoiKy"].DefaultCellStyle.Format = "N0";

                // Auto size columns
                dataGridView1.AutoResizeColumns();
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            LoadCongNoNCCData();
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
                saveFileDialog.Title = "Lưu báo cáo công nợ nhà cung cấp";
                saveFileDialog.FileName = "BaoCaoCongNoNCC_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";

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
                Paragraph title = new Paragraph("THỐNG KÊ CÔNG NỢ CÁC NHÀ CUNG CẤP", titleFont);
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

                cell = new PdfPCell(new Phrase("Tên NCC", boldFont));
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

                cell = new PdfPCell(new Phrase("Phát sinh nhập hàng", boldFont));
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

                        // Tên NCC
                        string tenNCC = row.Cells["TenNhaCungCap"].Value != null ? row.Cells["TenNhaCungCap"].Value.ToString() : "";
                        cell = new PdfPCell(new Phrase(tenNCC, normalFont));
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

                        // Phát sinh nhập hàng
                        decimal phatSinh = row.Cells["PhatSinhNhapHang"].Value != null ? Convert.ToDecimal(row.Cells["PhatSinhNhapHang"].Value) : 0;
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
