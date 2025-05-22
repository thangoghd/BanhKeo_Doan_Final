using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuXuatHuy
{
    public partial class FormPhieuXuatHuy : Form
    {
        public FormPhieuXuatHuy()
        {
            InitializeComponent();
        }

        private void btnThemPhieuXuatHuy_Click(object sender, EventArgs e)
        {
            ThemPhieuXuatHuy themPhieuXuatHuy = new ThemPhieuXuatHuy();
            themPhieuXuatHuy.Show();
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
    }
}
