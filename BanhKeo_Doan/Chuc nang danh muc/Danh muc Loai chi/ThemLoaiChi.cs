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

namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Loai_chi
{
    public partial class ThemLoaiChi : Form
    {
        public ThemLoaiChi()
        {
            InitializeComponent();
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtTenlc.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTenlc.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtTenlc.Text, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Tên chỉ được chứa chữ cái và khoảng trắng!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtTenlc.Focus();
                return false;
            }
            return true;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;

            string query = "INSERT INTO LoaiChi (TenLoaiChi) VALUES (N'" + txtTenlc.Text + "')";

            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Thêm loại chi thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM LoaiChi");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm loại chi thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
