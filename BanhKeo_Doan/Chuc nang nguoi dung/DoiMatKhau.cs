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

namespace BanhKeo_Doan.Chuc_nang_nguoi_dung
{
    public partial class DoiMatKhau : Form
    {
        private string tendn;
        public DoiMatKhau(string tendn)
        {
            InitializeComponent();
            this.tendn = tendn;
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtmkCu.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtmkCu.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtmkMoi1.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtmkMoi1.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtmkMoi2.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtmkMoi2.Focus();
                return false;
            }

            if (txtmkMoi1.Text.Contains(" "))
            {
                MessageBox.Show("Vui lòng không để khoảng trắng!", "Thông báo", MessageBoxButtons.OK);
                txtmkMoi1.Focus();
                return false;
            }

            if (txtmkMoi2.Text.Contains(" "))
            {
                MessageBox.Show("Vui lòng không để khoảng trắng!", "Thông báo", MessageBoxButtons.OK);
                txtmkMoi2.Focus();
                return false;
            }
            return true;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;

            string sql = "SELECT MatKhau FROM NguoiDung WHERE TenDangNhap = '" + txtTk.Text + "'";
            KetNoiCSDL ketnoi = new KetNoiCSDL();
            SqlDataReader reader = ketnoi.ExecuteReader(sql);

            if (reader.Read())
            {
                string MkCu = reader["MatKhau"].ToString();

                if (MkCu != txtmkCu.Text)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng với tên đăng nhập này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtmkMoi1.Text != txtmkMoi2.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            string query = "UPDATE NguoiDung SET MatKhau = '" + txtmkMoi1.Text + "' WHERE TenDangNhap = '" + txtTk.Text + "'";


            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đổi mật khẩu thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void DoiMatKhau_Load_1(object sender, EventArgs e)
        {
            string query = "SELECT * FROM NguoiDung WHERE TenDangNhap = '" + tendn + "'";

            KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
            DataTable dt = ketnoiCSDL.GetData(query);

            if (dt.Rows.Count > 0)
            {
                txtTen.Text = dt.Rows[0]["TenNguoiDung"].ToString();
                txtCv.Text = dt.Rows[0]["ChucVu"].ToString();
                txtTk.Text = dt.Rows[0]["TenDangNhap"].ToString();
            }
        }
    }
}
