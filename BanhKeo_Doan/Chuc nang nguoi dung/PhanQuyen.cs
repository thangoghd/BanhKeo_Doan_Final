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
    public partial class PhanQuyen : Form
    {
        public PhanQuyen()
        {
            InitializeComponent();
        }

        private void PhanQuyen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyBanBanhKeo_DoAnDataSet.NguoiDung' table. You can move, or remove it, as needed.
            this.nguoiDungTableAdapter.Fill(this.quanLyBanBanhKeo_DoAnDataSet.NguoiDung);
            string query1 = "SELECT * FROM ChucNang";
            string query2 = "SELECT MaQuyenHan, ChucNang.TenChucNang, NguoiDung.TenNguoiDung FROM QuyenHan " +
                "INNER JOIN ChucNang ON ChucNang.MaChucNang = QuyenHan.MaChucNang " +
                "INNER JOIN NguoiDung ON NguoiDung.MaNguoiDung = QuyenHan.MaNguoiDung WHERE QuyenHan.MaNguoiDung = '"+cbnd.SelectedValue+"'";
            KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
            dtcn.DataSource = ketnoiCSDL.GetData(query1);
            dtqh.DataSource = ketnoiCSDL.GetData(query2);

            dtcn.Columns["MaChucNang"].HeaderText = "Mã chức năng";
            dtcn.Columns["TenChucNang"].HeaderText = "Tên chức năng";

            dtqh.Columns["MaQuyenHan"].HeaderText = "Mã quyền hạn";
            dtqh.Columns["TenChucNang"].HeaderText = "Tên chức năng";
            dtqh.Columns["TenNguoiDung"].HeaderText = "Tên người dùng";
        }

        private void dtcn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dtcn.CurrentRow.Index;
            txtMacn.Text = dtcn.Rows[i].Cells[0].Value.ToString();
            txtTencn.Text = dtcn.Rows[i].Cells[1].Value.ToString();
        }

        private void btnThemQ_Click(object sender, EventArgs e)
        {
            KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
            string checkquery = "SELECT * FROM QuyenHan WHERE MaChucNang = '"+txtMacn.Text+"' AND MaNguoiDung = '"+cbnd.SelectedValue+"'";
            SqlDataReader reader = ketnoiCSDL.ExecuteReader(checkquery);
            if (reader.Read())
            {
                reader.Close();
                MessageBox.Show("Chức năng này đã được cấp cho người dùng!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            try
            {
                string query = "INSERT INTO QuyenHan(MaChucNang, MaNguoiDung) VALUES (" + txtMacn.Text + ", " + cbnd.SelectedValue + ")";
                ketnoiCSDL.ExecuteNonQuery(query);
                MessageBox.Show("Thêm quyền hạn người dùng thành công!", "Thông báo");
                dtqh.DataSource = ketnoiCSDL.GetData("SELECT MaQuyenHan, ChucNang.TenChucNang, NguoiDung.TenNguoiDung FROM QuyenHan " +
                "INNER JOIN ChucNang ON ChucNang.MaChucNang = QuyenHan.MaChucNang " +
                "INNER JOIN NguoiDung ON NguoiDung.MaNguoiDung = QuyenHan.MaNguoiDung  WHERE QuyenHan.MaNguoiDung = '"+cbnd.SelectedValue+"'");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm quyền hạn người dùng thất bại!", "Thông báo");
            }
        }

        private void btnXoaQ_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thu hồi quyền này không!", "Xác nhận thu hồi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM QuyenHan WHERE MaQuyenHan = '" + txtMaqh.Text + "'";

                try
                {
                    KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
                    ketnoiCSDL.ExecuteNonQuery(query);
                    MessageBox.Show("Thu hồi quyền hạn thành công!", "Thông báo", MessageBoxButtons.OK);
                    dtqh.DataSource = ketnoiCSDL.GetData("SELECT MaQuyenHan, ChucNang.TenChucNang, NguoiDung.TenNguoiDung FROM QuyenHan " +
                "INNER JOIN ChucNang ON ChucNang.MaChucNang = QuyenHan.MaChucNang " +
                "INNER JOIN NguoiDung ON NguoiDung.MaNguoiDung = QuyenHan.MaNguoiDung  WHERE QuyenHan.MaNguoiDung = '"+cbnd.SelectedValue+"'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thu hồi quyền hạn thất bại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để thu hồi!");
            }
        }

        private void dtqh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dtqh.CurrentRow.Index;
            txtMaqh.Text = dtqh.Rows[i].Cells[0].Value.ToString();
        }

        private void cbnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            KetNoiCSDL ketnoiCSDL = new KetNoiCSDL();
            dtqh.DataSource = ketnoiCSDL.GetData("SELECT MaQuyenHan, ChucNang.TenChucNang, NguoiDung.TenNguoiDung FROM QuyenHan " +
                "INNER JOIN ChucNang ON ChucNang.MaChucNang = QuyenHan.MaChucNang " +
                "INNER JOIN NguoiDung ON NguoiDung.MaNguoiDung = QuyenHan.MaNguoiDung WHERE QuyenHan.MaNguoiDung = '"+cbnd.SelectedValue+"'");
        }
    }
}
