using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanhKeo_Doan.Chuc_nang_nguoi_dung
{
    public partial class BackUp : Form
    {
        public BackUp()
        {
            InitializeComponent();
        }

        private void btnBr_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                txtDd.Text = fb.SelectedPath;
                btnBu.Enabled = true;
            }
        }

        private void btnBu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDd.Text))
            {
                MessageBox.Show("Vui lòng chọn nơi lưu file backup!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string backupFileName = $"QuanLyBanBanhKeo_DoAn_{DateTime.Now:dd-MM-yyyy_HH-mm-ss}.bak";
            string fullPath = System.IO.Path.Combine(txtDd.Text, backupFileName);

            string backupQuery = $@"
                BACKUP DATABASE [QuanLyBanBanhKeo_DoAn]
                TO DISK = N'{fullPath}'
                WITH FORMAT, INIT, NAME = 'Full Backup of QuanLyBanBanhKeo_DoAn';";

            try
            {
                KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                ketnoiCSDL.ExecuteNonQuery(backupQuery);
                MessageBox.Show("Backup thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi backup: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackUp_Load(object sender, EventArgs e)
        {

        }
    }
}
