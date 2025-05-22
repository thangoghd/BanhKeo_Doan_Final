using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.FormVaChucNangNghiepVu.FormVaChucNangSoChi
{
    public partial class FormSoChi : Form
    {
        public FormSoChi()
        {
            InitializeComponent();
        }

        private void btnThemSoChi_Click(object sender, EventArgs e)
        {
            ThemSoChi themSoChi = new ThemSoChi();
            themSoChi.Show();
        }

        private void btnSuaSoChi_Click(object sender, EventArgs e)
        {
            SuaSoChi suaSoChi = new SuaSoChi();
            suaSoChi.Show();
        }
    }
}
