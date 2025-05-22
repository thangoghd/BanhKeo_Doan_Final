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
    public partial class SuaLoaiChi : Form
    {
        private string malc;
        private string tenlc;
        public SuaLoaiChi(string malc, string tenlc)
        {
            InitializeComponent();
            this.malc = malc;
            this.tenlc = tenlc;
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

            string query = "UPDATE LoaiChi SET TenLoaiChi = N'" + txtTenlc.Text + "' WHERE MaLoaiChi = '" + txtMalc.Text + "'";

            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Sửa loại chi thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM LoaiChi");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa loại chi thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void SuaLoaiChi_Load(object sender, EventArgs e)
        {
            txtMalc.Text = malc;
            txtTenlc.Text = tenlc;
        }
    }
}
