using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangPhieuThuTienKH
{
    public partial class FormPhieuThuTienKH : Form
    {
        public FormPhieuThuTienKH()
        {
            InitializeComponent();
        }

        private void btnThemPhieuThuTienKH_Click(object sender, EventArgs e)
        {
            ThemPhieuThuTienKH themPhieuThuTienKH = new ThemPhieuThuTienKH();
            themPhieuThuTienKH.Show();
        }

        private void btnSuaPhieuThuTienKH_Click(object sender, EventArgs e)
        {
            SuaPhieuThuTienKH suaPhieuThuTienKH = new SuaPhieuThuTienKH();
            suaPhieuThuTienKH.Show();
        }
    }
}
