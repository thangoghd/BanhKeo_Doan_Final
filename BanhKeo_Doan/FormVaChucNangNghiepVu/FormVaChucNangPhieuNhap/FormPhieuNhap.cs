using BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuNhap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu
{
    public partial class FormPhieuNhap : Form
    {
        public FormPhieuNhap()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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

        private void btnThemPhieuNhap_Click(object sender, EventArgs e)
        {
            ThemPhieuNhap themPhieuNhap = new ThemPhieuNhap();
            themPhieuNhap.Show();
        }
    }
}
