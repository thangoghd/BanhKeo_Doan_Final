using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_DVT;

namespace BanhKeo_Doan.Chuc_nang_danh_muc
{
    public partial class SuaHangHoa : Form
    {
        private string mahh;
        private string tenhh;
        private string tenlh;
        private string tendvt;
        public SuaHangHoa(string mahh, string tenhh, string tenlh, string tendvt)
        {
            InitializeComponent();
            this.mahh = mahh;
            this.tenhh = tenhh;
            this.tenlh = tenlh;
            this.tendvt = tendvt;
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SuaHangHoa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyBanBanhKeo_DoAnDataSet6.DonViTinh' table. You can move, or remove it, as needed.
            this.donViTinhTableAdapter.Fill(this.quanLyBanBanhKeo_DoAnDataSet6.DonViTinh);
            // TODO: This line of code loads data into the 'quanLyBanBanhKeo_DoAnDataSet5.LoaiHang' table. You can move, or remove it, as needed.
            this.loaiHangTableAdapter.Fill(this.quanLyBanBanhKeo_DoAnDataSet5.LoaiHang);

            txtMahh.Text = mahh;
            txtTenhh.Text = tenhh;

            foreach (DataRowView rowView in cbLh.Items)
            {
                if (rowView["TenLoaiHang"].ToString() == tenlh)
                {
                    cbLh.SelectedValue = rowView["MaLoaiHang"];
                    break;
                }
            }

            foreach (DataRowView rowView in cbdvt.Items)
            {
                if (rowView["TenDVT"].ToString() == tendvt)
                {
                    cbdvt.SelectedValue = rowView["MaDVT"];
                    break;
                }
            }
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
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;
            string query = "UPDATE HangHoa SET TenHangHoa = N'" + txtTenhh.Text + "', MaLoaiHang = '" + cbLh.SelectedValue + "', MaDVT = " + cbdvt.SelectedValue + " WHERE MaHangHoa = '" + txtMahh.Text + "'";


            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Sửa hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT MaHangHoa, TenHangHoa, LoaiHang.TenLoaiHang, DonViTinh.TenDVT FROM HangHoa " +
                    "INNER JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang " +
                    "INNER JOIN DonViTinh ON HangHoa.MaDVT = DonViTinh.MaDVT");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa hàng hóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Huy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
