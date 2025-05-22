using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangHangTon
{
    public partial class FormHangTon : Form
    {
        public FormHangTon()
        {
            InitializeComponent();
        }

        private void btnThemHangTon_Click(object sender, EventArgs e)
        {
            ThemHangTon themHangTon = new ThemHangTon();
            themHangTon.Show();
        }

        private void btnSuaHangTon_Click(object sender, EventArgs e)
        {
            SuaHangTon suaHangTon = new SuaHangTon();
            suaHangTon.Show();
        }
    }
}
