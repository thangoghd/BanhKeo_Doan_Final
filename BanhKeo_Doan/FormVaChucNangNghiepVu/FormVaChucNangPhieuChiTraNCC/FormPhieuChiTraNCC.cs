using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuChiTraNCC
{
    public partial class FormPhieuChiTraNCC : Form
    {
        public FormPhieuChiTraNCC()
        {
            InitializeComponent();
        }

        private void btnThemPhieuChiTraNCC_Click(object sender, EventArgs e)
        {
            ThemPhieuChiTraNCC themPhieuChiTraNCC = new ThemPhieuChiTraNCC();
            themPhieuChiTraNCC.Show();
        }

        private void btnSuaPhieuChiTraNCC_Click(object sender, EventArgs e)
        {
            SuaPhieuChiTraNCC suaPhieuChiTraNCC = new SuaPhieuChiTraNCC();
            suaPhieuChiTraNCC.Show();
        }
    }
}
