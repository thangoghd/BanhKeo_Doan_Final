using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Dinh_luong;
using DevExpress.ClipboardSource.SpreadsheetML;

namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Mat_hang
{
    public partial class ThemHangHoa : Form
    {
        private string tenhh;
        private KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
        public void LoadDataGridView(string query)
        {
            dtDl.DataSource = ketnoiCSDL.GetData(query);
        }
        public DataGridViewRow GetSelectedRow()
        {
            if (dtDl.CurrentRow != null)
                return dtDl.CurrentRow;
            else
                return null;
        }
        public ThemHangHoa(string tenhh)
        {
            InitializeComponent();
            this.tenhh = tenhh;
        }

        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtMahh.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtMahh.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenhh.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTenhh.Focus();
                return false;
            }

            if (txtMahh.Text.Contains(" "))
            {
                MessageBox.Show("Vui lòng không để khoảng trắng!", "Thông báo", MessageBoxButtons.OK);
                txtMahh.Focus();
                return false;
            }
            return true;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;
            string query = "INSERT INTO HangHoa (MaHangHoa, TenHangHoa, MaLoaiHang, MaDVT) VALUES ('" + txtMahh.Text + "', N'" + txtTenhh.Text + "', '" + cbLh.SelectedValue + "', " + cbdvt.SelectedValue + ")";


            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Thêm hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT MaHangHoa, TenHangHoa, LoaiHang.TenLoaiHang, DonViTinh.TenDVT FROM HangHoa " +
                    "INNER JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang " +
                    "INNER JOIN DonViTinh ON HangHoa.MaDVT = DonViTinh.MaDVT");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm hàng hóa thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void ThemHangHoa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyBanBanhKeo_DoAnDataSet11.HangHoa' table. You can move, or remove it, as needed.
            this.hangHoaTableAdapter.Fill(this.quanLyBanBanhKeo_DoAnDataSet11.HangHoa);
            // TODO: This line of code loads data into the 'quanLyBanBanhKeo_DoAnDataSet4.DonViTinh' table. You can move, or remove it, as needed.
            this.donViTinhTableAdapter.Fill(this.quanLyBanBanhKeo_DoAnDataSet4.DonViTinh);
            // TODO: This line of code loads data into the 'quanLyBanBanhKeo_DoAnDataSet3.LoaiHang' table. You can move, or remove it, as needed.
            this.loaiHangTableAdapter.Fill(this.quanLyBanBanhKeo_DoAnDataSet3.LoaiHang);

            KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
            string query = "SELECT " +
                "HangHoa.MaHangHoa, " +
                "HangHoa.TenHangHoa " +
                "FROM HangHoa " +
                "INNER JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang " +
                "WHERE LoaiHang.MaNganhHang = 1";
            DataTable dt = ketnoiCSDL.GetData(query);

            cbTendl.DataSource = dt;
            cbTendl.DisplayMember = "TenHangHoa";
            cbTendl.ValueMember = "MaHangHoa";

            foreach (DataRowView rowView in cbTendl.Items)
            {
                if (rowView["TenHangHoa"].ToString() == tenhh)
                {
                    cbTendl.SelectedValue = rowView["MaHangHoa"];
                    break;
                }
            }
        }

        private void Huy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                string query = "SELECT " +
                    "DinhLuong.MaDinhLuong, " +
                    "HangHoaThanhPham.TenHangHoa AS TenHangHoaThanhPham," +
                    "HangHoaNguyenLieu.TenHangHoa AS TenHangHoaNguyenLieu," +
                    "NganhHang.TenNganhHang, " +
                    "DinhLuong.SoLuong, " +
                    "DonViTinh.TenDVT " +
                    "FROM DinhLuong " +
                    "INNER JOIN HangHoa AS HangHoaThanhPham ON HangHoaThanhPham.MaHangHoa = DinhLuong.MaHangHoa " +
                    "INNER JOIN HangHoa AS HangHoaNguyenLieu ON HangHoaNguyenLieu.MaHangHoa = DinhLuong.MaHangHoaNL " +
                    "INNER JOIN LoaiHang ON LoaiHang.MaLoaiHang = HangHoaNguyenLieu.MaLoaiHang " +
                    "INNER JOIN NganhHang ON NganhHang.MaNganhHang = LoaiHang.MaNganhHang " +
                    "INNER JOIN DonViTinh ON DonViTinh.MaDVT = HangHoaNguyenLieu.MaDVT " +
                    "WHERE DinhLuong.MaHangHoa = '"+cbTendl.SelectedValue+"'";

                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    dtDl.DataSource = ketnoiCSDL.GetData(query);
                    dtDl.Columns["MaDinhLuong"].HeaderText = "Mã định lượng";
                    dtDl.Columns["TenHangHoaNguyenLieu"].HeaderText = "Tên nguyên liệu";
                    dtDl.Columns["TenNganhHang"].HeaderText = "Loại";
                    dtDl.Columns["SoLuong"].HeaderText = "Số lượng";
                    dtDl.Columns["TenDVT"].HeaderText = "Đơn vị tính";
                    dtDl.Columns["TenHangHoaThanhPham"].HeaderText = "Tên hàng hóa";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối!" + ex, "Thông báo");
                }
            }
        }

        private void btnThemdl_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string mahh = selectedRow.Cells["MaHangHoa"].Value.ToString();
            string tenhh = selectedRow.Cells["TenHangHoa"].Value.ToString();

            ThemDinhLuong themdinhluong = new ThemDinhLuong(mahh, tenhh);
            themdinhluong.Show();
        }

        private void btnSuadl_Click(object sender, EventArgs e)
        {
            ThemHangHoa mainForm = (ThemHangHoa)Application.OpenForms["ThemHangHoa"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string madl = selectedRow.Cells["MaDinhLuong"].Value.ToString();
            string tenhh = selectedRow.Cells["TenHangHoaThanhPham"].Value.ToString();
            string tennl = selectedRow.Cells["TenHangHoaNguyenLieu"].Value.ToString();
            string sl = selectedRow.Cells["SoLuong"].Value.ToString();

            SuaDinhLuong suadinhluong = new SuaDinhLuong(madl, tenhh, tennl, sl);
            suadinhluong.Show();
        }

        private void btnXoadl_Click(object sender, EventArgs e)
        {
            ThemHangHoa mainForm = (ThemHangHoa)Application.OpenForms["ThemHangHoa"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string madl = selectedRow.Cells["MaDinhLuong"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa định lượng này không!", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM DinhLuong WHERE MaDinhLuong = '" + madl + "'";
                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    ketnoiCSDL.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa định lượng thành công!", "Thông báo", MessageBoxButtons.OK);
                    dtDl.DataSource = ketnoiCSDL.GetData("SELECT " +
                    "DinhLuong.MaDinhLuong, " +
                    "HangHoaThanhPham.TenHangHoa AS TenHangHoaThanhPham," +
                    "HangHoaNguyenLieu.TenHangHoa AS TenHangHoaNguyenLieu," +
                    "NganhHang.TenNganhHang, " +
                    "DinhLuong.SoLuong, " +
                    "DonViTinh.TenDVT " +
                    "FROM DinhLuong " +
                    "INNER JOIN HangHoa AS HangHoaThanhPham ON HangHoaThanhPham.MaHangHoa = DinhLuong.MaHangHoa " +
                    "INNER JOIN HangHoa AS HangHoaNguyenLieu ON HangHoaNguyenLieu.MaHangHoa = DinhLuong.MaHangHoaNL " +
                    "INNER JOIN LoaiHang ON LoaiHang.MaLoaiHang = HangHoaNguyenLieu.MaLoaiHang " +
                    "INNER JOIN NganhHang ON NganhHang.MaNganhHang = LoaiHang.MaNganhHang " +
                    "INNER JOIN DonViTinh ON DonViTinh.MaDVT = HangHoaNguyenLieu.MaDVT");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa định lượng thất bại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!");
            }
        }

        private void cbTendl_SelectedIndexChanged(object sender, EventArgs e)
        {
            KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
            dtDl.DataSource = ketnoiCSDL.GetData("SELECT " +
                    "DinhLuong.MaDinhLuong, " +
                    "HangHoaThanhPham.TenHangHoa AS TenHangHoaThanhPham," +
                    "HangHoaNguyenLieu.TenHangHoa AS TenHangHoaNguyenLieu," +
                    "NganhHang.TenNganhHang, " +
                    "DinhLuong.SoLuong, " +
                    "DonViTinh.TenDVT " +
                    "FROM DinhLuong " +
                    "INNER JOIN HangHoa AS HangHoaThanhPham ON HangHoaThanhPham.MaHangHoa = DinhLuong.MaHangHoa " +
                    "INNER JOIN HangHoa AS HangHoaNguyenLieu ON HangHoaNguyenLieu.MaHangHoa = DinhLuong.MaHangHoaNL " +
                    "INNER JOIN LoaiHang ON LoaiHang.MaLoaiHang = HangHoaNguyenLieu.MaLoaiHang " +
                    "INNER JOIN NganhHang ON NganhHang.MaNganhHang = LoaiHang.MaNganhHang " +
                    "INNER JOIN DonViTinh ON DonViTinh.MaDVT = HangHoaNguyenLieu.MaDVT " +
                    "WHERE DinhLuong.MaHangHoa = '" + cbTendl.SelectedValue+"'");
        }
    }
}
