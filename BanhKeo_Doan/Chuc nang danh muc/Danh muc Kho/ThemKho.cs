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

namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Kho
{
    public partial class ThemKho : Form
    {
        public ThemKho()
        {
            InitializeComponent();
        }
        private bool checkloi()
        {
            if (string.IsNullOrWhiteSpace(txtTenkho.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtTenkho.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtTenkho.Text, @"^[\p{L}\d\s]+$"))
            {
                MessageBox.Show("Tên chỉ được chứa chữ cái và khoảng trắng!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                txtTenkho.Focus();
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!checkloi())
                return;

            string query = "INSERT INTO Kho (TenKho) VALUES (N'" + txtTenkho.Text + "')";

            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Thêm kho thành công!", "Thông báo", MessageBoxButtons.OK);
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM Kho");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm kho thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
