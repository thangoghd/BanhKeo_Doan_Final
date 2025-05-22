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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtDn_Click(object sender, EventArgs e)
        {
            string tk = txtTk.Text;
            string mk = txtMk.Text;

            string query = "SELECT * FROM NguoiDung WHERE TenDangNhap = '" + tk + "' and MatKhau = '" + mk + "'";
            try
            {

                if(string.IsNullOrEmpty(txtTk.Text) || string.IsNullOrEmpty(txtMk.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                }
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                SqlDataReader reader = ketnoiCSDL.ExecuteReader(query);


                string tennd = "";
                string tendn = "";
                string cv = "";
                string mand = "";
                if (reader.Read())
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK);

                    this.Hide();
                    tennd = reader["TenNguoiDung"].ToString();
                    tendn = reader["TenDangNhap"].ToString();
                    cv = reader["ChucVu"].ToString();
                    mand = reader["MaNguoiDung"].ToString();
                    RibbonForm1 ribbonForm1 = new RibbonForm1(tennd, tendn, cv, mand);
                    ribbonForm1.Show();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
