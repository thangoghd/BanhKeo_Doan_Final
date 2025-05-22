using BanhKeo_Doan.Chuc_nang_danh_muc;
using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Mat_hang;
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
    public partial class FormHangHoa : DevExpress.XtraEditors.XtraUserControl
    {
        public FormHangHoa()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void FormHangHoa_Load(object sender, EventArgs e)
        {
            ckbten.Checked = true;
            txtten.Enabled = true;

            ckbloai.Checked = false;
            txtloai.Enabled = false;
            
        }

        private void SuaHangHoa_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string mahh = selectedRow.Cells["MaHangHoa"].Value.ToString();
            string tenhh = selectedRow.Cells["TenHangHoa"].Value.ToString();
            string tenlh = selectedRow.Cells["TenLoaiHang"].Value.ToString();
            string tendvt = selectedRow.Cells["TenDVT"].Value.ToString();

            SuaHangHoa suaHangHoa = new SuaHangHoa(mahh, tenhh, tenlh, tendvt);
            suaHangHoa.Show();
        }

        private void btnThemHangHoa_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string tenhh = selectedRow.Cells["TenHangHoa"].Value.ToString();

            ThemHangHoa themHangHoa = new ThemHangHoa(tenhh);
            themHangHoa.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string mahh = selectedRow.Cells["MaHangHoa"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa hàng hóa này không!", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM HangHoa WHERE MaHangHoa = '" + mahh + "'";

                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    ketnoiCSDL.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK);
                    ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT MaHangHoa, TenHangHoa, LoaiHang.TenLoaiHang, DonViTinh.TenDVT FROM HangHoa " +
                    "INNER JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang " +
                    "INNER JOIN DonViTinh ON HangHoa.MaDVT = DonViTinh.MaDVT");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa hàng hóa thất bại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!");
            }
        }

        private void ckbten_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbten.Checked == true)
            {
                txtten.Enabled = true;
                ckbloai.Checked = false;
                txtloai.Enabled = false;
                txtloai.Clear();
            }
        }

        private void ckbloai_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbloai.Checked == true)
            {
                txtloai.Enabled = true;
                ckbten.Checked = false;
                txtten.Enabled = false;
                txtten.Clear();
            }
        }

        private void txtten_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT MaHangHoa, TenHangHoa, LoaiHang.TenLoaiHang, DonViTinh.TenDVT FROM HangHoa " +
                "INNER JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang " +
                "INNER JOIN DonViTinh ON HangHoa.MaDVT = DonViTinh.MaDVT " +
                "WHERE TenHangHoa LIKE N'%" + txtten.Text.Trim()+"%'";
            ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView(query);
        }

        private void txtloai_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT MaHangHoa, TenHangHoa, LoaiHang.TenLoaiHang, DonViTinh.TenDVT FROM HangHoa " +
                "INNER JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang " +
                "INNER JOIN DonViTinh ON HangHoa.MaDVT = DonViTinh.MaDVT " +
                "WHERE LoaiHang.TenLoaiHang LIKE N'%" + txtloai.Text.Trim() + "%'";
            ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView(query);
        }

        private void ckbLoc_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbLoc.Checked == true)
            {
                string query = "SELECT MaHangHoa, TenHangHoa, LoaiHang.TenLoaiHang, DonViTinh.TenDVT FROM HangHoa " +
                "INNER JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang " +
                "INNER JOIN DonViTinh ON HangHoa.MaDVT = DonViTinh.MaDVT " +
                "WHERE LoaiHang.MaNganhHang = 1";
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView(query);
                ckbLocnl.Checked = false;
            }
            else if (ckbLoc.Checked == false && ckbLocnl.Checked == false)
            {
                string query = "SELECT MaHangHoa, TenHangHoa, LoaiHang.TenLoaiHang, DonViTinh.TenDVT FROM HangHoa " +
                "INNER JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang " +
                "INNER JOIN DonViTinh ON HangHoa.MaDVT = DonViTinh.MaDVT";
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView(query);
            }
        }

        private void ckbLocnl_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbLocnl.Checked == true)
            {
                string query = "SELECT MaHangHoa, TenHangHoa, LoaiHang.TenLoaiHang, DonViTinh.TenDVT FROM HangHoa " +
                "INNER JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang " +
                "INNER JOIN DonViTinh ON HangHoa.MaDVT = DonViTinh.MaDVT " +
                "WHERE LoaiHang.MaNganhHang = 2";
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView(query);
                ckbLoc.Checked = false;
            }
            else if (ckbLoc.Checked == false && ckbLocnl.Checked == false)
            {
                string query = "SELECT MaHangHoa, TenHangHoa, LoaiHang.TenLoaiHang, DonViTinh.TenDVT FROM HangHoa " +
                "INNER JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang " +
                "INNER JOIN DonViTinh ON HangHoa.MaDVT = DonViTinh.MaDVT";
                ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView(query);
            }
        }
    }
}
