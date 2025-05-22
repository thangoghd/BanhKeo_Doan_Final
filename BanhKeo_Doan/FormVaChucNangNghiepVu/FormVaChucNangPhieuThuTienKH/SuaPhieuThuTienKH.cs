using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuThuTienKH
{
    public partial class SuaPhieuThuTienKH : Form
    {
        private string maPhieuThuTien;
        public SuaPhieuThuTienKH(string maPhieuThuTien)
        {
            InitializeComponent();
            this.maPhieuThuTien = maPhieuThuTien;
            LoadPhieuThuTien();
        }

        private void LoadPhieuThuTien()
        {
            try
            {
                var db = new KetNoiCSDL();
                string query = $@"SELECT * FROM PhieuThuTienKH WHERE MaPhieuThuTien = '{maPhieuThuTien}'";
                DataTable dt = db.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    cbKhachHang.Text = row["MaKhachHang"].ToString();
                    txtSoChungTu.Text = row["SoChungTu"].ToString();
                    dtpNgayTra.Value = Convert.ToDateTime(row["NgayLap"]);
                    txtSoTien.Text = row["SoTien"].ToString();
                    cbHTTT.Text = row["HTTT"].ToString();
                    txtDienGiai.Text = row["DienGiai"].ToString();
                    txtNguoiNop.Text = row["NguoiNop"].ToString();
                    cbGiaoDich.Text = row["GiaoDich"].ToString();
                    cbNhanVien.Text = row["MaNhanVien"].ToString();
                    txtGhiChu.Text = row["TrangThai"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải phiếu thu tiền: " + ex.Message);
            }
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChapNhan_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new KetNoiCSDL();
                string query = $@"
                        UPDATE PhieuThuTienKH SET 
                            MaKhachHang = '{cbKhachHang.Text}',
                            NgayLap = '{dtpNgayTra.Value.ToString("yyyy-MM-dd HH:mm:ss")}',
                            SoTien = {txtSoTien.Text},
                            HTTT = '{cbHTTT.Text}',
                            DienGiai = '{txtDienGiai.Text}',
                            NguoiNop = '{txtNguoiNop.Text}',
                            GiaoDich = '{cbGiaoDich.Text}',
                            MaNhanVien = '{cbNhanVien.Text}',
                            TrangThai = '{txtGhiChu.Text}'
                        WHERE MaPhieuThuTien = '{maPhieuThuTien}'";

                int result = db.ExecuteNonQuery(query);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật phiếu thu tiền thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }
    }
}
