using BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangDonHang;
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
    public partial class FormDonHang : Form
    {
        public FormDonHang()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
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

        private void btnThemDonHang_Click(object sender, EventArgs e)
        {
            ThemDonHang themDonHang = new ThemDonHang();
            themDonHang.Show();
        }
    }
}
