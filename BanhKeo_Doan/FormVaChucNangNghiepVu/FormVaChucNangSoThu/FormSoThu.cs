using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangSoThu
{
    public partial class FormSoThu : Form
    {
        public FormSoThu()
        {
            InitializeComponent();
        }

        private void btnThemSoThu_Click(object sender, EventArgs e)
        {
            ThemSoThu themSoThu = new ThemSoThu();
            themSoThu.Show();
        }

        private void btnSuaSoThu_Click(object sender, EventArgs e)
        {
            SuaSoThu suaSoThu = new SuaSoThu();
            suaSoThu.Show();
        }
    }
}
