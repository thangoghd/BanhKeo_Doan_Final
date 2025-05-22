using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuXuatRaSX
{
    public partial class FormPhieuXuatRaSX : Form
    {
        public FormPhieuXuatRaSX()
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

        private void btnThemPhieuXuatRaSX_Click(object sender, EventArgs e)
        {
            ThemPhieuXuatRaSX themPhieuXuatRaSX = new ThemPhieuXuatRaSX();
            themPhieuXuatRaSX.Show();
        }
    }
}
