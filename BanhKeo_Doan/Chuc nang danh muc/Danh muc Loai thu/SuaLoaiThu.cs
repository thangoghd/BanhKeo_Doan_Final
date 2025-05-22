using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BanhKeo_Doan.Chuc_nang_danh_muc.Danh_muc_Loai_thu
{
    public partial class SuaLoaiThu : Form
    {
        private int maLoaiThu;

        public SuaLoaiThu(int ma, string ten)
        {
            InitializeComponent();
            this.maLoaiThu = ma;
            txtMalt.Text = ma.ToString();
            txtTenlt.Text = ten;
            txtMalt.ReadOnly = true;
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = txtTenlt.Text;
                if (string.IsNullOrWhiteSpace(ten))
                {
                    MessageBox.Show("Tên loại thu không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string query = $"UPDATE LoaiThu SET TenLoaiThu = N'{ten}' WHERE MaLoaiThu = {maLoaiThu}";
                new KetNoiCSDL().GetData(query);
                MessageBox.Show("Cập nhật loại thu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật loại thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
