using BanhKeo_Doan.Chuc_nang_nguoi_dung;
using BanhKeo_Doan.FormBaoCaoThongKe;
using BanhKeo_Doan.FormNghiepVu;
using BanhKeo_Doan.FormVaChucNangNghiepVu;
using BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangHangTon;
using BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangHoaDonXuatHang;
using BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuChiTraNCC;
using BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuThuTienKH;
using BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuXuatChuyen;
using BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuXuatRaSX;
using BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangSoChi;
using BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangSoThu;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string tennd;
        private string tendn;
        private string cv;
        private string mand;

        public RibbonForm1(string tennd, string tendn, string cv, string mand)
        {
            InitializeComponent();
            this.tennd = tennd;
            this.tendn = tendn;
            this.cv = cv;
            this.mand = mand;

        }
        private KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();

        private bool KiemTraQuyen(string mand, int macn)
        {
            string query = "SELECT * FROM QuyenHan WHERE MaChucNang = "+macn+" AND MaNguoiDung = "+mand+"";
            SqlDataReader reader = ketnoiCSDL.ExecuteReader(query);

            bool coQuyen = false;

            if (reader.Read())
            {
                coQuyen = true;
            }
            return coQuyen;
        }
        public static class CheckHienThi
        {
            public static BarItemVisibility ChuyenDoiHienThi(bool condition)
            {
                return condition ? BarItemVisibility.Always : BarItemVisibility.Never;
            }
        }
        private void CheckAllQuyen(string mand)
        {
            btnQlnd.Visibility = CheckHienThi.ChuyenDoiHienThi(KiemTraQuyen(mand, 1));
            btnDoimk.Visibility = CheckHienThi.ChuyenDoiHienThi(KiemTraQuyen(mand, 2));
            btnBackUp.Visibility = CheckHienThi.ChuyenDoiHienThi(KiemTraQuyen(mand, 3));
            btnNCC.Visibility = CheckHienThi.ChuyenDoiHienThi(KiemTraQuyen(mand, 4));
            BtnKhachHang.Visibility = CheckHienThi.ChuyenDoiHienThi(KiemTraQuyen(mand, 5));
            BtnNhanVien.Visibility = CheckHienThi.ChuyenDoiHienThi(KiemTraQuyen(mand, 6));
            BtnKho.Visibility = CheckHienThi.ChuyenDoiHienThi(KiemTraQuyen(mand, 7));
            BtnDVT.Visibility = CheckHienThi.ChuyenDoiHienThi(KiemTraQuyen(mand, 8));
            BtnNganhHang.Visibility = CheckHienThi.ChuyenDoiHienThi(KiemTraQuyen(mand, 9));
            BtnMatHang.Visibility = CheckHienThi.ChuyenDoiHienThi(KiemTraQuyen(mand, 10));
            BtnBangGia.Visibility = CheckHienThi.ChuyenDoiHienThi(KiemTraQuyen(mand, 11));
            BtnLoaiThu.Visibility = CheckHienThi.ChuyenDoiHienThi(KiemTraQuyen(mand, 12));
            BtnLoaiChi.Visibility = CheckHienThi.ChuyenDoiHienThi(KiemTraQuyen(mand, 13));
            BtnLoaiHang.Visibility = CheckHienThi.ChuyenDoiHienThi(KiemTraQuyen(mand, 14));

        }
        private void barButtonItem38_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barDockingMenuItem1_ListItemClick(object sender, ListItemClickEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public DataGridViewRow GetSelectedRow()
        {
            if (dataGridView1.CurrentRow != null)
                return dataGridView1.CurrentRow;
            else
                return null;
        }


        private void ribbon_Click(object sender, EventArgs e)
        {

        }
        private void LoadUserControl(UserControl uc)
        {
            pnlContent.Controls.Clear(); // Xóa nội dung cũ
            uc.Dock = DockStyle.Fill; // Lấp đầy panel
            pnlContent.Controls.Add(uc); // Thêm UserControl mới
        }

        public void LoadDataGridView(string query)
        {
            dataGridView1.DataSource = ketnoiCSDL.GetData(query);
        }
        private void btnNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUserControl(new FormNCC());
            string query = "SELECT * FROM NhaCungCap";
            dataGridView1.DataSource = ketnoiCSDL.GetData(query);
            dataGridView1.Columns["MaNhaCungCap"].HeaderText = "Mã NCC";
            dataGridView1.Columns["TenNhaCungCap"].HeaderText = "Tên nhà cung cấp";
            dataGridView1.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dataGridView1.Columns["Tel"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["MaSoThue"].HeaderText = "Mã số thuế";
            dataGridView1.Columns["SoTaiKhoan"].HeaderText = "Số tài khoản";
            dataGridView1.Columns["TenNganHang"].HeaderText = "Tên ngân hàng";
            dataGridView1.Columns["DiaChiNganHang"].HeaderText = "Địa chỉ ngân hàng";
            dataGridView1.Columns["NoCu"].HeaderText = "Nợ cũ";
        }

        private void BtnNguoiDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUserControl(new FormNguoiDung());
            string query = "SELECT * FROM NguoiDung";
            dataGridView1.DataSource = ketnoiCSDL.GetData(query);
            dataGridView1.Columns["MaNguoiDung"].HeaderText = "Mã người dùng";
            dataGridView1.Columns["TenNguoiDung"].HeaderText = "Tên người dùng";
            dataGridView1.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
            dataGridView1.Columns["MatKhau"].HeaderText = "Mật khẩu";
            dataGridView1.Columns["ChucVu"].HeaderText = "Chức vụ";
        }

        private void BtnKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUserControl(new FormKhachHang());
            string query = "SELECT * FROM KhachHang";
            dataGridView1.DataSource = ketnoiCSDL.GetData(query);
            dataGridView1.Columns["MaKhachHang"].HeaderText = "Mã khách hàng";
            dataGridView1.Columns["TenKhachHang"].HeaderText = "Tên khách hàng";
            dataGridView1.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dataGridView1.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dataGridView1.Columns["Tel"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["MaSoThue"].HeaderText = "Mã số thuế";
            dataGridView1.Columns["SoTaiKhoan"].HeaderText = "Số tài khoản";
            dataGridView1.Columns["TenNganHang"].HeaderText = "Tên ngân hàng";
            dataGridView1.Columns["DiaChiNganHang"].HeaderText = "Địa chỉ ngân hàng";
            dataGridView1.Columns["NoCu"].HeaderText = "Nợ cũ";
        }

        private void BtnNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUserControl(new FormNhanVien());
            string query = "SELECT * FROM NhanVien";
            dataGridView1.DataSource = ketnoiCSDL.GetData(query);
            dataGridView1.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dataGridView1.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            dataGridView1.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dataGridView1.Columns["Tel"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["GioiTinh"].HeaderText = "Giới tính";
            dataGridView1.Columns["SoCMND"].HeaderText = "Số CMND";
            dataGridView1.Columns["LuongCoBan"].HeaderText = "Lương cơ bản";
            dataGridView1.Columns["PhuCap"].HeaderText = "Phụ cấp";
            dataGridView1.Columns["TienTrachNhiem"].HeaderText = "Tiền trách nhiệm";
        }

        private void BtnKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUserControl(new FormKho());
            string query = "SELECT * FROM Kho";
            dataGridView1.DataSource = ketnoiCSDL.GetData(query);
            dataGridView1.Columns["MaKho"].HeaderText = "Mã kho";
            dataGridView1.Columns["TenKho"].HeaderText = "Tên kho";
        }

        private void BtnDVT_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUserControl(new FormDVT());
            string query = "SELECT * FROM DonViTinh";
            dataGridView1.DataSource = ketnoiCSDL.GetData(query);
            dataGridView1.Columns["MaDVT"].HeaderText = "Mã đơn vị tính";
            dataGridView1.Columns["TenDVT"].HeaderText = "Tên đơn vị tính";
        }

        private void BtnNganhHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUserControl(new FormNganhHang());
            string query = "SELECT * FROM NganhHang";
            dataGridView1.DataSource = ketnoiCSDL.GetData(query);
            dataGridView1.Columns["MaNganhHang"].HeaderText = "Mã ngành hàng";
            dataGridView1.Columns["TenNganhHang"].HeaderText = "Tên ngành hàng";
        }

        private void BtnLoaiHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUserControl(new FormLoaiHang());
            string query = "SELECT MaLoaiHang, TenLoaiHang, NganhHang.TenNganhHang FROM LoaiHang" +
                " Inner Join NganhHang on LoaiHang.MaNganhHang = NganhHang.MaNganhHang";
            dataGridView1.DataSource = ketnoiCSDL.GetData(query);
            dataGridView1.Columns["MaLoaiHang"].HeaderText = "Mã loại hàng";
            dataGridView1.Columns["TenLoaiHang"].HeaderText = "Tên loại hàng";
            dataGridView1.Columns["TenNganhHang"].HeaderText = "Tên ngành hàng";
        }

        private void BtnMatHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUserControl(new FormHangHoa());
            string query = "SELECT MaHangHoa, TenHangHoa, LoaiHang.TenLoaiHang, DonViTinh.TenDVT FROM HangHoa" +
                " Inner join LoaiHang on HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang" +
                " Inner join DonViTinh on HangHoa.MaDVT = DonViTinh.MaDVT";
            dataGridView1.DataSource = ketnoiCSDL.GetData(query);
            dataGridView1.Columns["MaHangHoa"].HeaderText = "Mã hàng hóa";
            dataGridView1.Columns["TenHangHoa"].HeaderText = "Tên hàng hóa";
            dataGridView1.Columns["TenLoaiHang"].HeaderText = "Tên loại hàng";
            dataGridView1.Columns["TenDVT"].HeaderText = "Tên đơn vị tính";
        }

        private void BtnBangGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUserControl(new FormBangGia());
            string query = "SELECT MaBangGia, NgayCapNhat, HangHoa.TenHangHoa, LoaiHang.TenLoaiHang, DonViTinh.TenDVT, GiaNhap, GiaBuon, GiaBanLe FROM BangGia" +
                " Inner join HangHoa on HangHoa.MaHangHoa = BangGia.MaHangHoa" +
                " Inner join LoaiHang on HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang" +
                " Inner join DonViTinh on HangHoa.MaDVT = DonViTinh.MaDVT";
            dataGridView1.DataSource = ketnoiCSDL.GetData(query);
            dataGridView1.Columns["MaBangGia"].HeaderText = "Mã bảng giá";
            dataGridView1.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";
            dataGridView1.Columns["TenHangHoa"].HeaderText = "Tên hàng hóa";
            dataGridView1.Columns["TenLoaiHang"].HeaderText = "Tên loại hàng";
            dataGridView1.Columns["TenDVT"].HeaderText = "Tên đơn vị tính";
            dataGridView1.Columns["GiaNhap"].HeaderText = "Giá nhập";
            dataGridView1.Columns["GiaBuon"].HeaderText = "Giá bán buôn";
            dataGridView1.Columns["GiaBanLe"].HeaderText = "Giá bán lẻ";
        }


        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnlContent.Controls.Clear();
            DoiMatKhau f2 = new DoiMatKhau(this.tendn);
            f2.Show();
        }

        private void btnKeHoachSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnlContent.Controls.Clear();
            FormKeHoachSanXuat keHoachSanXuat = new FormKeHoachSanXuat();
            keHoachSanXuat.Show();
        }



        private void btnThanhToanNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnlContent.Controls.Clear();
            FormPhieuChiTraNCC formPhieuChiTraNCC = new FormPhieuChiTraNCC();
            formPhieuChiTraNCC.Show();
        }

        private void btnThanhToanKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnlContent.Controls.Clear();
            FormPhieuThuTienKH formPhieuThuTienKH = new FormPhieuThuTienKH();
            formPhieuThuTienKH.Show();
        }

        private void btnHangTon_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnlContent.Controls.Clear();
            FormHangTon formHangTon = new FormHangTon();
            formHangTon.Show();
        }

        private void btnPhieuNhapKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnlContent.Controls.Clear();
            FormPhieuNhap formPhieuNhap = new FormPhieuNhap();
            formPhieuNhap.Show();
        }

        private void btnPhieuXuatChuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnlContent.Controls.Clear();
            FormPhieuXuatChuyen formPhieuXuatChuyen = new FormPhieuXuatChuyen();
            formPhieuXuatChuyen.Show();
        }

        private void btnPhieuXuatRaSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnlContent.Controls.Clear();
            FormPhieuXuatRaSX formPhieuXuatRaSX = new FormPhieuXuatRaSX();
            formPhieuXuatRaSX.Show();
        }

        private void btnHoaDonXuatHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnlContent.Controls.Clear();
            FormHoaDonXuatHang formHoaDonXuatHang = new FormHoaDonXuatHang();
            formHoaDonXuatHang.Show();
        }

        private void btnDonHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnlContent.Controls.Clear();
            FormDonHang formDonHang = new FormDonHang();
            formDonHang.Show();
        }

        private void BtnLoaiThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUserControl(new FormLoaiThu());
            string query = "SELECT * FROM LoaiThu";
            dataGridView1.DataSource = ketnoiCSDL.GetData(query);
            dataGridView1.Columns["MaLoaiThu"].HeaderText = "Mã loại thu";
            dataGridView1.Columns["TenLoaiThu"].HeaderText = "Tên loại thu";
        }


        // Tải lại Dữ liệu Loại thu
        public void ReloadLoaiThuGrid()
        {
            string query = "SELECT * FROM LoaiThu";
            var dt = ketnoiCSDL.GetData(query);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["MaLoaiThu"].HeaderText = "Mã loại thu";
            dataGridView1.Columns["TenLoaiThu"].HeaderText = "Tên loại thu";
        }

        private void BtnLoaiChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUserControl(new FormLoaiChi());
            string query = "SELECT * FROM LoaiChi";
            dataGridView1.DataSource = ketnoiCSDL.GetData(query);
            dataGridView1.Columns["MaLoaiChi"].HeaderText = "Mã loại chi";
            dataGridView1.Columns["TenLoaiChi"].HeaderText = "Tên loại chi";
        }

        private void btnSoThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormSoThu formSoThu = new FormSoThu();
            formSoThu.Show();
        }

        private void btnSoChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormSoChi formSoChi = new FormSoChi();
            formSoChi.Show();
        }


        private void RibbonForm1_Load_1(object sender, EventArgs e)
        {
            txtChao.Text = tennd;
            CheckAllQuyen(mand);
        }

        private void barButtonItem9_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem6_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            BackUp backup = new BackUp();
            backup.Show();
        }

        private void barButtonItem8_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Close();
        }

        private void barButtonItem40_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormCongNoNCC formCongNoNCC = new FormCongNoNCC();
            formCongNoNCC.Show();
        }

        private void barButtonItem41_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormCongNoKH formCongNoKH = new FormCongNoKH();
            formCongNoKH.Show();
        }
    }
}

