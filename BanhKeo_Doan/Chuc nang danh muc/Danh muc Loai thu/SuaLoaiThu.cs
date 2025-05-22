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

namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Loai_thu
{
    public partial class SuaLoaiThu : Form
    {
        private string malt;
        private string tenlt;
        public SuaLoaiThu(string malt, string tenlt)
        {
            InitializeComponent();
            this.malt = malt;
            this.tenlt = tenlt;
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtTenlt.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTenlt.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtTenlt.Text, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Tên chỉ được chứa chữ cái và khoảng trắng!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtTenlt.Focus();
                return false;
            }
            return true;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;

            string query = "UPDATE LoaiThu SET TenLoaiThu = N'" + txtTenlt.Text + "' WHERE MaLoaiThu = '" + txtMalt.Text + "'";

            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Sửa loại thu thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM LoaiThu");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa loại thu thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void SuaLoaiThu_Load(object sender, EventArgs e)
        {
            txtMalt.Text = malt;
            txtTenlt.Text = tenlt;
        }
    }
}
