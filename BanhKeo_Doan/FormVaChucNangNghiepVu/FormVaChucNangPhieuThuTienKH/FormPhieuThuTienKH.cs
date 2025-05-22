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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuThuTienKH
{
    public partial class FormPhieuThuTienKH : Form
    {
        private KetNoiCSDL db;

        public FormPhieuThuTienKH()
        {
            InitializeComponent();
            db = new KetNoiCSDL();

            // Load dữ liệu khi form được khởi tạo
            LoadDanhSachPhieuThuTienKH();

            txtPhieuThu.Enabled = checkBoxPhieuThu.Checked;
            txtNameKH.Enabled = checkBoxKH.Checked;
            dtpFrom.Enabled = checkBoxDate.Checked;
            dtpTo.Enabled = checkBoxDate.Checked;
        }

        private void btnThemPhieuThuTienKH_Click(object sender, EventArgs e)
        {
            ThemPhieuThuTienKH themPhieuThuTienKH = new ThemPhieuThuTienKH();
            themPhieuThuTienKH.FormClosed += (s, args) => LoadDanhSachPhieuThuTienKH();
            themPhieuThuTienKH.Show();
        }

        private void btnSuaPhieuThuTienKH_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn phiếu thu tiền nào chưa
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu thu tiền cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewCell cell = dataGridView1.SelectedCells[0];
            DataGridViewRow row = dataGridView1.Rows[cell.RowIndex];
            string maPhieuThuTien = row.Cells["MaPhieuThuTien"].Value.ToString();

            // Mở form sửa phiếu thu tiền
            SuaPhieuThuTienKH suaPhieuThuTienKH = new SuaPhieuThuTienKH(maPhieuThuTien);
            suaPhieuThuTienKH.FormClosed += (s, args) => LoadDanhSachPhieuThuTienKH();
            suaPhieuThuTienKH.Show();
        }

        private void LoadDanhSachPhieuThuTienKH()
        {
            try
            {
                string query = @"SELECT p.MaPhieuThuTien, p.NgayLap, p.MaKhachHang, kh.TenKhachHang, 
                                 p.SoChungTu, p.DienGiai, p.SoTien, p.HTTT, p.NguoiNop, p.GiaoDich, 
                                 p.TrangThai, p.MaNhanVien, nv.TenNhanVien
                                 FROM PhieuThuTienKH p
                                 LEFT JOIN KhachHang kh ON p.MaKhachHang = kh.MaKhachHang
                                 LEFT JOIN NhanVien nv ON p.MaNhanVien = nv.MaNhanVien
                                 ORDER BY p.NgayLap DESC";

                DataTable dt = db.GetData(query);
                dataGridView1.DataSource = dt;

                // Định dạng lại các cột
                if (dataGridView1.Columns.Contains("SoTien"))
                {
                    dataGridView1.Columns["SoTien"].DefaultCellStyle.Format = "N0";
                }

                if (dataGridView1.Columns.Contains("NgayLap"))
                {
                    dataGridView1.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phiếu thu tiền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDanhSachPhieuThuTienKH();
        }

        private void btnXoaPhieuThuTienKH_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn phiếu thu tiền nào chưa
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu thu tiền cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã phiếu thu tiền từ ô được chọn
            string maPhieuThuTien = dataGridView1.SelectedCells[0].Value.ToString();

            // Hiển thị hộp thoại xác nhận
            decimal soTien = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["SoTien"].Value);
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu thu tiền '{maPhieuThuTien}' với số tiền {soTien:N0} VNĐ không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = $"DELETE FROM PhieuThuTienKH WHERE MaPhieuThuTien = '{maPhieuThuTien}'";
                    int ketQua = db.ExecuteNonQuery(query);

                    if (ketQua > 0)
                    {
                        MessageBox.Show("Xóa phiếu thu tiền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachPhieuThuTienKH();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu thu tiền thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa phiếu thu tiền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInPhieuThuTienKH_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn phiếu thu tiền nào chưa
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu thu tiền cần in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã phiếu thu tiền từ dòng được chọn
            DataGridViewCell cell = dataGridView1.SelectedCells[0];
            DataGridViewRow row = dataGridView1.Rows[cell.RowIndex];
            string maPhieuThuTien = row.Cells["MaPhieuThuTien"].Value.ToString();

            // Hiển thị hộp thoại lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.Title = "Lưu phiếu thu tiền";
            saveFileDialog.FileName = $"PhieuThuTien_{maPhieuThuTien}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                ExportToPdf(maPhieuThuTien, fileName);
            }
        }

        private void ExportToPdf(string maPhieuThuTien, string fileName)
        {
            try
            {
                // Lấy thông tin phiếu thu tiền
                string query = $@"SELECT p.MaPhieuThuTien, p.NgayLap, p.MaKhachHang, kh.TenKhachHang, 
                                  p.SoChungTu, p.DienGiai, p.SoTien, p.HTTT, p.NguoiNop, p.GiaoDich, 
                                  p.TrangThai, p.MaNhanVien, nv.TenNhanVien
                                  FROM PhieuThuTienKH p
                                  LEFT JOIN KhachHang kh ON p.MaKhachHang = kh.MaKhachHang
                                  LEFT JOIN NhanVien nv ON p.MaNhanVien = nv.MaNhanVien
                                  WHERE p.MaPhieuThuTien = '{maPhieuThuTien}'";

                DataTable dt = db.GetData(query);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin phiếu thu tiền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo document PDF
                Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                document.Open();

                // Tạo font cho tiếng Việt
                BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font fontNormal = new Font(baseFont, 12);
                Font fontBold = new Font(baseFont, 12, 1); // 1 = BOLD
                Font fontTitle = new Font(baseFont, 16, 1); // 1 = BOLD
                Font fontSmall = new Font(baseFont, 10);

                // Tiêu đề
                Paragraph title = new Paragraph("PHIẾU THU TIỀN", fontTitle);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                // Số chứng từ
                Paragraph soChungTu = new Paragraph($"Số chứng từ: {dt.Rows[0]["SoChungTu"]}", fontBold);
                soChungTu.Alignment = Element.ALIGN_CENTER;
                document.Add(soChungTu);

                // Thêm khoảng trắng
                document.Add(new Paragraph(" "));

                // Thông tin phiếu thu tiền
                document.Add(new Paragraph("Ngày lập: " + Convert.ToDateTime(dt.Rows[0]["NgayLap"]).ToString("dd/MM/yyyy HH:mm"), fontNormal));
                document.Add(new Paragraph("Khách hàng: " + dt.Rows[0]["TenKhachHang"].ToString(), fontNormal));
                document.Add(new Paragraph("Diễn giải: " + dt.Rows[0]["DienGiai"].ToString(), fontNormal));
                document.Add(new Paragraph("Số tiền: " + string.Format("{0:N0}", Convert.ToDecimal(dt.Rows[0]["SoTien"])) + " VNĐ", fontNormal));
                document.Add(new Paragraph("Hình thức thanh toán: " + dt.Rows[0]["HTTT"].ToString(), fontNormal));
                document.Add(new Paragraph("Người nộp: " + dt.Rows[0]["NguoiNop"].ToString(), fontNormal));
                document.Add(new Paragraph("Loại giao dịch: " + dt.Rows[0]["GiaoDich"].ToString(), fontNormal));
                document.Add(new Paragraph("Trạng thái: " + dt.Rows[0]["TrangThai"].ToString(), fontNormal));
                document.Add(new Paragraph("Nhân viên: " + dt.Rows[0]["TenNhanVien"].ToString(), fontNormal));

                // Thêm khoảng trắng
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));

                // Chữ ký
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;

                PdfPCell cell1 = new PdfPCell();
                cell1.AddElement(new Paragraph("Người nộp tiền", fontNormal));
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell1);

                PdfPCell cell2 = new PdfPCell();
                cell2.AddElement(new Paragraph("Người lập phiếu", fontNormal));
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell2);

                PdfPCell cell3 = new PdfPCell();
                cell3.AddElement(new Paragraph("(Ký, họ tên)", fontSmall));
                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                cell3.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell3);

                PdfPCell cell4 = new PdfPCell();
                cell4.AddElement(new Paragraph("(Ký, họ tên)", fontSmall));
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell4);

                document.Add(table);

                document.Close();

                // Mở file PDF sau khi xuất
                System.Diagnostics.Process.Start(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxPhieuThu_CheckedChanged(object sender, EventArgs e)
        {
            txtPhieuThu.Enabled = checkBoxPhieuThu.Checked;
        }

        private void checkBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = checkBoxDate.Checked;
            dtpTo.Enabled = checkBoxDate.Checked;
        }

        private void checkBoxKH_CheckedChanged(object sender, EventArgs e)
        {
            txtNameKH.Enabled = checkBoxKH.Checked;
        }
    }
}
