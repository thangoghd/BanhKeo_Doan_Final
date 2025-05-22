using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using IText = iTextSharp.text;

namespace BanhKeo_Doan.FormBaoCaoThongKe.ThuChi
{
    public partial class FormBaoCaoSoChi : Form
    {
        private KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();

        public FormBaoCaoSoChi()
        {
            InitializeComponent();
            LoadInitialData();
            SetupEventHandlers();
        }

        private void LoadInitialData()
        {
            // Set up date pickers with default values
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;

            // Trạng thái disabled khi form được khởi tạo
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;

            // Configure DataGridView
            ConfigureDataGridView();

            // Load data
            LoadSoChiData();
        }

        private void ConfigureDataGridView()
        {
            // Configure DataGridView
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Clear existing columns
            dataGridView1.Columns.Clear();

            // Add columns
            dataGridView1.Columns.Add("STT", "STT");
            dataGridView1.Columns.Add("Ngay", "Ngày");
            dataGridView1.Columns.Add("SoChungTu", "Số chứng từ");
            dataGridView1.Columns.Add("DienGiai", "Diễn giải");
            dataGridView1.Columns.Add("TenLoaiChi", "Loại chi");
            dataGridView1.Columns.Add("NguoiNhan", "Người nhận");
            dataGridView1.Columns.Add("SoTien", "Số tiền");

            // Set column properties
            dataGridView1.Columns["STT"].Width = 50;
            dataGridView1.Columns["Ngay"].Width = 100;
            dataGridView1.Columns["SoChungTu"].Width = 120;
            dataGridView1.Columns["DienGiai"].Width = 250;
            dataGridView1.Columns["TenLoaiChi"].Width = 100;
            dataGridView1.Columns["NguoiNhan"].Width = 150;
            dataGridView1.Columns["SoTien"].Width = 120;
            dataGridView1.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["SoTien"].DefaultCellStyle.Format = "N0";
        }

        private void SetupEventHandlers()
        {
            // Set up event handlers
            btnTimKiem.Click += BtnTimKiem_Click;
            btnInButton.Click += BtnInButton_Click;
            checkBoxDate.CheckedChanged += CheckBoxDate_CheckedChanged;
        }

        private void CheckBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            // Enable/disable date pickers based on checkbox state
            dtpFrom.Enabled = checkBoxDate.Checked;
            dtpTo.Enabled = checkBoxDate.Checked;
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            LoadSoChiData();
        }

        private void LoadSoChiData()
        {
            try
            {
                // Build the SQL query
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append(@"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY SC.NgayLap) AS STT,
                        CONVERT(varchar, SC.NgayLap, 103) AS Ngay,
                        SC.SoChungTu,
                        SC.DienGiai,
                        LC.TenLoaiChi,
                        SC.NguoiNhan,
                        SC.SoTien
                    FROM SoChi SC
                    INNER JOIN LoaiChi LC ON SC.MaLoaiChi = LC.MaLoaiChi
                ");

                // Add date filter if checked
                if (checkBoxDate.Checked)
                {
                    queryBuilder.Append(" WHERE SC.NgayLap BETWEEN @FromDate AND @ToDate");
                }

                queryBuilder.Append(" ORDER BY SC.NgayLap");

                // Build the SQL query with parameters
                string finalQuery = queryBuilder.ToString();

                if (checkBoxDate.Checked)
                {
                    // Create a parameterized query manually
                    finalQuery = finalQuery.Replace("@FromDate", "'" + dtpFrom.Value.Date.ToString("yyyy-MM-dd") + "'");
                    finalQuery = finalQuery.Replace("@ToDate", "'" + dtpTo.Value.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") + "'");
                }

                // Get data using the KetNoiCSDL class
                DataTable dataTable = ketnoiCSDL.GetData(finalQuery);

                // Clear existing rows
                dataGridView1.Rows.Clear();

                // Add rows to DataGridView
                decimal totalAmount = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    DataGridViewRow dgvRow = dataGridView1.Rows[rowIndex];

                    dgvRow.Cells["STT"].Value = row["STT"];
                    dgvRow.Cells["Ngay"].Value = row["Ngay"];
                    dgvRow.Cells["SoChungTu"].Value = row["SoChungTu"];
                    dgvRow.Cells["DienGiai"].Value = row["DienGiai"];
                    dgvRow.Cells["TenLoaiChi"].Value = row["TenLoaiChi"];
                    dgvRow.Cells["NguoiNhan"].Value = row["NguoiNhan"];
                    dgvRow.Cells["SoTien"].Value = row["SoTien"];

                    // Calculate total
                    totalAmount += Convert.ToDecimal(row["SoTien"]);
                }

                // Display total count and amount
                this.Text = $"Báo cáo sổ chi - {dataGridView1.Rows.Count} dòng - Tổng tiền: {totalAmount:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnInButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Show save file dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Lưu báo cáo sổ chi";
            saveFileDialog.FileName = "BaoCaoSoChi_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToPdf(saveFileDialog.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Open the PDF file
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                IText.Font italicFont = new IText.Font(baseFont, 12, IText.Font.ITALIC);
                IText.Font boldFont = new IText.Font(baseFont, 12, IText.Font.BOLD);
                IText.Font titleFont = new IText.Font(baseFont, 16, IText.Font.BOLD);
                IText.Font headerFont = new IText.Font(baseFont, 14, IText.Font.BOLD);

                // Thêm header - Tên công ty
                Paragraph companyName = new Paragraph("Công ty TNHH Đầu tư Sản xuất & XNK Hoàng Gia", headerFont);
                companyName.Alignment = Element.ALIGN_CENTER;
                document.Add(companyName);

                // Thêm tiêu đề báo cáo
                Paragraph title = new Paragraph("BÁO CÁO SỔ CHI", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                // Thêm ngày theo dõi
                string dateFilter = "";
                if (checkBoxDate.Checked)
                {
                    dateFilter = "(Từ ngày " + dtpFrom.Value.ToString("dd/MM/yyyy") + " đến ngày " + dtpTo.Value.ToString("dd/MM/yyyy") + ")";
                }

                Paragraph dateReport = new Paragraph(dateFilter, normalFont);
                dateReport.Alignment = Element.ALIGN_CENTER;
                document.Add(dateReport);

                document.Add(new Paragraph(" ")); // Khoảng trắng

                // Tạo bảng báo cáo sổ chi
                PdfPTable table = new PdfPTable(7);
                table.WidthPercentage = 100;
                float[] columnWidths = { 0.5f, 1.2f, 1.5f, 3f, 1.5f, 1.5f, 1.5f };
                table.SetWidths(columnWidths);

                // Thêm header cho bảng
                PdfPCell cell = new PdfPCell(new Phrase("STT", boldFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Padding = 5;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Ngày", boldFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Padding = 5;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Số chứng từ", boldFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Padding = 5;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Diễn giải", boldFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Padding = 5;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Loại chi", boldFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Padding = 5;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Người nhận", boldFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Padding = 5;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Số tiền", boldFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Padding = 5;
                table.AddCell(cell);

                // Thêm dữ liệu từ DataGridView vào bảng
                decimal totalAmount = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    // Skip the last row if it's the new row
                    if (dataGridView1.Rows[i].IsNewRow)
                        continue;

                    DataGridViewRow row = dataGridView1.Rows[i];

                    try
                    {
                        // STT
                        cell = new PdfPCell(new Phrase(row.Cells["STT"].Value?.ToString() ?? "", normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        table.AddCell(cell);

                        // Ngày
                        cell = new PdfPCell(new Phrase(row.Cells["Ngay"].Value?.ToString() ?? "", normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        table.AddCell(cell);

                        // Số chứng từ
                        cell = new PdfPCell(new Phrase(row.Cells["SoChungTu"].Value?.ToString() ?? "", normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        table.AddCell(cell);

                        // Diễn giải
                        cell = new PdfPCell(new Phrase(row.Cells["DienGiai"].Value?.ToString() ?? "", normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        table.AddCell(cell);

                        // Loại chi
                        cell = new PdfPCell(new Phrase(row.Cells["TenLoaiChi"].Value?.ToString() ?? "", normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        table.AddCell(cell);

                        // Người nhận
                        cell = new PdfPCell(new Phrase(row.Cells["NguoiNhan"].Value?.ToString() ?? "", normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        table.AddCell(cell);

                        // Số tiền
                        decimal amount = row.Cells["SoTien"].Value != null ? Convert.ToDecimal(row.Cells["SoTien"].Value) : 0;
                        cell = new PdfPCell(new Phrase(string.Format("{0:N0}", amount), normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        table.AddCell(cell);

                        // Cộng dồn tổng tiền
                        totalAmount += amount;
                    }
                    catch (Exception ex)
                    {
                        // Log lỗi nhưng tiếp tục xử lý các dòng khác
                        Console.WriteLine("Lỗi khi xử lý dòng " + i + ": " + ex.Message);
                    }
                }

                // Thêm dòng tổng cộng
                cell = new PdfPCell(new Phrase("", normalFont));
                cell.Colspan = 6;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.Padding = 5;
                cell.Phrase = new Phrase("Tổng cộng", boldFont);
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(string.Format("{0:N0}", totalAmount), boldFont));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.Padding = 5;
                table.AddCell(cell);

                document.Add(table);

                document.Add(new Paragraph(" ")); // Khoảng trắng
                document.Add(new Paragraph(" ")); // Khoảng trắng

                // Thêm thông tin địa chỉ ngày giờ
                PdfPTable tableAddress = new PdfPTable(2);
                tableAddress.WidthPercentage = 100;

                // Cột trống bên trái
                PdfPCell emptyCell = new PdfPCell(new Phrase("", normalFont));
                emptyCell.Border = 0;
                tableAddress.AddCell(emptyCell);

                // Thông tin về Địa chỉ, ngày tháng năm viết bằng tay (...., ngày ... tháng ... năm ...)
                PdfPCell addressCell = new PdfPCell(new Phrase("...., ngày ..... tháng ..... năm .....", italicFont));
                addressCell.Border = 0;
                addressCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                tableAddress.AddCell(addressCell);

                document.Add(tableAddress);
                document.Add(new Paragraph(" ")); // Khoảng trắng 

                // Thêm chữ ký
                PdfPTable signatureTable = new PdfPTable(2);
                signatureTable.WidthPercentage = 100;

                // Cột trống bên trái
                signatureTable.AddCell(emptyCell);

                // Người lập báo cáo ở bên phải
                PdfPCell reporterCell = new PdfPCell(new Phrase("Người lập báo cáo", boldFont));
                reporterCell.Border = 0;
                reporterCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                signatureTable.AddCell(reporterCell);

                // Thêm khoảng trắng cho chữ ký
                signatureTable.AddCell(emptyCell);

                PdfPCell blankCell = new PdfPCell(new Phrase("\n\n\n\n", normalFont));
                blankCell.Border = 0;
                signatureTable.AddCell(blankCell);

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
