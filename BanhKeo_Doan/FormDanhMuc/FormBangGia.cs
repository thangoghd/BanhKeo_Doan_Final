using BanhKeo_Doan.Chuc_nang_danh_muc;
using BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Bang_gia;
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
    public partial class FormBangGia : DevExpress.XtraEditors.XtraUserControl
    {
        public FormBangGia()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void FormBangGia_Load(object sender, EventArgs e)
        {

        }

        private void btnSuaBangGia_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string mabg = selectedRow.Cells["MaBangGia"].Value.ToString();
            string ngaycn = selectedRow.Cells["NgayCapNhat"].Value.ToString();
            string tenhh = selectedRow.Cells["TenHangHoa"].Value.ToString();
            string nhap = selectedRow.Cells["GiaNhap"].Value.ToString();
            string buon = selectedRow.Cells["GiaBuon"].Value.ToString();
            string le = selectedRow.Cells["GiaBanLe"].Value.ToString();

            SuaBangGia suaBangGia = new SuaBangGia(mabg, ngaycn, tenhh, nhap, buon, le);
            suaBangGia.Show();
        }

        private void btnThemBangGia_Click(object sender, EventArgs e)
        {
            ThemBangGia themBangGia = new ThemBangGia();
            themBangGia.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RibbonForm1 mainForm = (RibbonForm1)Application.OpenForms["RibbonForm1"];
            DataGridViewRow selectedRow = mainForm.GetSelectedRow();

            string mabg = selectedRow.Cells["MaBangGia"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa bảng giá này không!", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM BangGia WHERE MaBangGia = '" + mabg + "'";
                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    ketnoiCSDL.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa bảng giá thành công!", "Thông báo", MessageBoxButtons.OK);
                    ((RibbonForm1)Application.OpenForms["RibbonForm1"]).LoadDataGridView("SELECT BangGia.MaBangGia, BangGia.NgayCapNhat, HangHoa.TenHangHoa, LoaiHang.TenLoaiHang, DonViTinh.TenDVT, BangGia.GiaNhap, BangGia.GiaBuon, BangGia.GiaBanLe FROM BangGia " +
                    "INNER JOIN HangHoa ON HangHoa.MaHangHoa = BangGia.MaHangHoa " +
                    "INNER JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang " +
                    "INNER JOIN DonViTinh ON HangHoa.MaDVT = DonViTinh.MaDVT");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa bảng giá thất bại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!");
            }
        }
    }
}
