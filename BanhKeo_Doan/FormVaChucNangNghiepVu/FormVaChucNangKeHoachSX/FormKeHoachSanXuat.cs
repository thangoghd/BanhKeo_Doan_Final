using BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangKeHoachSX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.FormNghiepVu
{
    public partial class FormKeHoachSanXuat : Form
    {
        public FormKeHoachSanXuat()
        {
            InitializeComponent();
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnThemKeHoachSX_Click(object sender, EventArgs e)
        {
            ThemKeHoachSX themKeHoachSX = new ThemKeHoachSX();
            themKeHoachSX.Show();
        }
    }
}
