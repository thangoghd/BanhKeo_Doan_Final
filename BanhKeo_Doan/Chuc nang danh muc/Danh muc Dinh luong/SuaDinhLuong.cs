using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Mat_hang;

namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Dinh_luong
{
    public partial class SuaDinhLuong : Form
    {
        private string madl;
        private string tenhh;
        private string tennl;
        private string sl;
        public SuaDinhLuong(string madl, string tenhh, string tennl, string sl)
        {
            InitializeComponent();
            this.madl = madl;
            this.tenhh = tenhh;
            this.tennl = tennl;
            this.sl = sl;
        }

        private void SuaDinhLuong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyBanBanhKeo_DoAnDataSet8.HangHoa' table. You can move, or remove it, as needed.
            this.hangHoaTableAdapter.Fill(this.quanLyBanBanhKeo_DoAnDataSet8.HangHoa);

            txtMadl.Text = madl;
            txtSl.Text = sl;

            KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();

            string query1 = "SELECT " +
                "HangHoa.MaHangHoa, " +
                "HangHoa.TenHangHoa " +
                "FROM HangHoa " +
                "INNER JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang " +
                "WHERE LoaiHang.MaNganhHang = 1";
            DataTable dttp = ketnoiCSDL.GetData(query1);


            string query2 = "SELECT " +
                "HangHoa.MaHangHoa, " +
                "HangHoa.TenHangHoa " +
                "FROM HangHoa " +
                "INNER JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang " +
                "WHERE LoaiHang.MaNganhHang = 2";
            DataTable dtnl = ketnoiCSDL.GetData(query2);


            cbtp.DataSource = dttp;
            cbtp.DisplayMember = "TenHangHoa";
            cbtp.ValueMember = "MaHangHoa";

            cbnl.DataSource = dtnl;
            cbnl.DisplayMember = "TenHangHoa";
            cbnl.ValueMember = "MaHangHoa";

            foreach (DataRowView rowView in cbtp.Items)
            {
                if (rowView["TenHangHoa"].ToString() == tenhh)
                {
                    cbtp.SelectedValue = rowView["MaHangHoa"];
                    break;
                }
            }

            foreach (DataRowView rowView in cbnl.Items)
            {
                if (rowView["TenHangHoa"].ToString() == tennl)
                {
                    cbnl.SelectedValue = rowView["MaHangHoa"];
                    break;
                }
            }
        }

        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtSl.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtSl.Focus();
                return false;
            }
            if (!float.TryParse(txtSl.Text, out float SDT))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho số lượng!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtSl.Focus();
                return false;
            }

            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;

            string query = "UPDATE DinhLuong SET MaHangHoaNL = '" + cbnl.SelectedValue + "' ,SoLuong = '" + txtSl.Text + "' WHERE MaDinhLuong = '" + txtMadl.Text + "'";

            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Sửa định lượng thành công!", "Thông báo", MessageBoxButtons.OK);
                ((ThemHangHoa)Application.OpenForms["ThemHangHoa"]).LoadDataGridView("SELECT " +
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
                    "WHERE DinhLuong.MaHangHoa = '"+ cbtp.SelectedValue+ "' ");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa định lượng thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
