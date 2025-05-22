using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangHoaDonXuatHang
{
    public partial class FormHoaDonXuatHang : Form
    {
        public FormHoaDonXuatHang()
        {
            InitializeComponent();
        }

        private void btnThemHangHoa_Click(object sender, EventArgs e)
        {
            ThemHangHoa themHangHoa = new ThemHangHoa();
            themHangHoa.Show();
        }

        private void btnSuaHangHoa_Click(object sender, EventArgs e)
        {
            SuaHangHoa suaHangHoa = new SuaHangHoa();
            suaHangHoa.Show();
        }

        private void btnThemHoaDonXuatHang_Click(object sender, EventArgs e)
        {
            ThemHoaDonXuatHang themHoaDonXuatHang = new ThemHoaDonXuatHang();
            themHoaDonXuatHang.Show();
        }
    }
}
