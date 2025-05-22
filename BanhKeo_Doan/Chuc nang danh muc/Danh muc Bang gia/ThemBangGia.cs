using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Bang_gia
{
    public partial class ThemBangGia : Form
    {
        public ThemBangGia()
        {
            InitializeComponent();
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtBuon.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtBuon.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLe.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtLe.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtNhap.Focus();
                return false;
            }
            if (!float.TryParse(txtBuon.Text, out float buon))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtBuon.Focus();
                return false;
            }

            if (!float.TryParse(txtLe.Text, out float le))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtLe.Focus();
                return false;
            }

            if (!float.TryParse(txtNhap.Text, out float nhap))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtNhap.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;
            string query = "INSERT INTO BangGia (NgayCapNhat, MaHangHoa, GiaNhap, GiaBuon, GiaBanLe) VALUES ('" + dtcn.Text + "', '" + cbTenhh.SelectedValue.ToString() + "', '" + txtNhap.Text + "', '" + txtBuon.Text + "', '" + txtLe.Text + "')";


            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Thêm bảng giá thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT BangGia.MaBangGia, BangGia.NgayCapNhat, HangHoa.TenHangHoa, LoaiHang.TenLoaiHang, DonViTinh.TenDVT, BangGia.GiaNhap, BangGia.GiaBuon, BangGia.GiaBanLe FROM BangGia " +
                    "INNER JOIN HangHoa ON HangHoa.MaHangHoa = BangGia.MaHangHoa " +
                    "INNER JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang " +
                    "INNER JOIN DonViTinh ON HangHoa.MaDVT = DonViTinh.MaDVT");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm bảng giá thất bại!" + ex, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void ThemBangGia_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyBanBanhKeo_DoAnDataSet9.HangHoa' table. You can move, or remove it, as needed.
            this.hangHoaTableAdapter1.Fill(this.quanLyBanBanhKeo_DoAnDataSet9.HangHoa);

        }
    }
}
