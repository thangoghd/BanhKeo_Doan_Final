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

namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_DVT
{
    public partial class ThemDVT : Form
    {
        public ThemDVT()
        {
            InitializeComponent();
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtTendvt.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTendvt.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtTendvt.Text, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Tên chỉ được chứa chữ cái và khoảng trắng!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtTendvt.Focus();
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;

            string query = "INSERT INTO DonViTinh (TenDVT) VALUES (N'" + txtTendvt.Text + "')";

            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Thêm đơn vị tính thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM DonViTinh");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm đơn vị tính thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
