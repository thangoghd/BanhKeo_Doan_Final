using BanhKeo_Doan.Chuc_nang_nguoi_dung;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan
{
    public partial class FormNguoiDung : DevExpress.XtraEditors.XtraUserControl
    {
        public FormNguoiDung()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void FormNguoiDung_Load(object sender, EventArgs e)
        {
            ckbTen.Checked = true;
            txtTen.Enabled = true;

            ckbtk.Checked = false;
            txttk.Enabled = false;
        }

        private void btnSuaNguoiDung_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string mand = selectedRow.Cells["MaNguoiDung"].Value.ToString();
            string tennd = selectedRow.Cells["TenNguoiDung"].Value.ToString();
            string tendn = selectedRow.Cells["TenDangNhap"].Value.ToString();
            string cv = selectedRow.Cells["ChucVu"].Value.ToString();
            string mk = selectedRow.Cells["MatKhau"].Value.ToString();

            SuaNguoiDung suaNguoiDung = new SuaNguoiDung(mand, tennd, tendn, cv, mk);
            suaNguoiDung.Show();
        }

        private void btnThemNguoiDung_Click(object sender, EventArgs e)
        {
            ThemNguoiDung themNguoiDung = new ThemNguoiDung();
            themNguoiDung.Show();
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            PhanQuyen phanQuyen = new PhanQuyen();
            phanQuyen.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string mand = selectedRow.Cells["MaNguoiDung"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa người dùng này không!", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM NguoiDung WHERE MaNguoiDung = '" + mand + "'";

                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    ketnoiCSDL.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK);
                    ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT * FROM NguoiDung");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa người dùng thất bại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!");
            }
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM NguoiDung WHERE TenNguoiDung LIKE N'%"+txtTen.Text.Trim()+"%'";
            ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView(query);
        }

        private void txttk_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM NguoiDung WHERE TenDangNhap LIKE '%" + txttk.Text.Trim() + "%'";
            ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView(query);
        }

        private void ckbTen_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTen.Checked == true)
            {
                txtTen.Enabled = true;
                ckbtk.Checked = false;
                txttk.Enabled = false;
                txttk.Clear();
            }
        }

        private void ckbtk_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbtk.Checked == true)
            {
                txttk.Enabled = true;
                ckbTen.Checked = false;
                txtTen.Enabled = false;
                txtTen.Clear();
            }
        }
    }
}
