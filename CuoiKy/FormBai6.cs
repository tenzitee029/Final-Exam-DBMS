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

namespace CuoiKy
{
    public partial class FormBai6 : Form
    {
        string strCon = @"Data Source=LAPTOP-DQP9I1OD\SQLEXPRESS;Initial Catalog = QuanLyThuVien; Integrated Security = True";
        SqlConnection sqlCon = null;
        public FormBai6()
        {
            InitializeComponent();
        }

        private void btn_Ketnoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon == null)
                    sqlCon = new SqlConnection(strCon);

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    MessageBox.Show("Kết nối thành công");
                    if (!tab.TabPages.Contains(tab61)) tab.TabPages.Add(tab61);
                    if (!tab.TabPages.Contains(tab62)) tab.TabPages.Add(tab62);
                    if (!tab.TabPages.Contains(tab63)) tab.TabPages.Add(tab63);
                    if (!tab.TabPages.Contains(tab64)) tab.TabPages.Add(tab64);
                    ssl_Trangthai.Text = "Đã kết nối";
                    ssl_Trangthai.ForeColor = Color.Green;
                    HienThiDuLieu("SELECT * FROM Cuonsach", dgv61);
                    HienThiDuLieu(dulieu62, dgv62);
                    //HienThiDuLieu("SELECT * FROM Dausach", dgv63);
                    //HienThiDuLieu("SELECT * FROM Dausach", dgv64);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message);
            }
        }

        private void FormBai6_Load(object sender, EventArgs e)
        {
            tab.TabPages.Remove(tab61);
            tab.TabPages.Remove(tab62);
            tab.TabPages.Remove(tab63);
            tab.TabPages.Remove(tab64);
        }

        private void btn_Ngat_Click(object sender, EventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
                MessageBox.Show("Đã đóng kết nối");
                tab.TabPages.Remove(tab61);
                tab.TabPages.Remove(tab62);
                tab.TabPages.Remove(tab63);
                tab.TabPages.Remove(tab64);
            }
            else
            {
                MessageBox.Show("Chưa tạo kết nối");
            }
            ssl_Trangthai.Text = "Chưa kết nối";
            ssl_Trangthai.ForeColor = Color.Red;
        }

        string dulieu62 = @"SELECT cs.isbn, cs.ma_cuonsach, cs.tinhtrang, m.ma_DocGia, m.ngay_muon, m.ngay_hethan 
                             FROM Cuonsach cs 
                             LEFT JOIN Muon m ON cs.isbn = m.isbn AND cs.ma_cuonsach = m.ma_cuonsach";
        private void HienThiDuLieu(string sql, DataGridView dgv)
        {
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void btn_Xoa61_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_isbn61.Text) || string.IsNullOrWhiteSpace(txt_masach61.Text))
            {
                MessageBox.Show("Vui lòng nhập mã ISBN và Mã cuốn sách hợp lệ", "Thông báo");
                return;
            }
            SqlTransaction tran = sqlCon.BeginTransaction();
            try
            {
                string sqlDelete = "DELETE FROM Muon WHERE isbn = @isbn AND ma_cuonsach = @macuon";
                using (SqlCommand cmd = new SqlCommand(sqlDelete, sqlCon, tran))
                {
                    cmd.Parameters.AddWithValue("@isbn", txt_isbn61.Text.Trim());
                    cmd.Parameters.AddWithValue("@macuon", int.Parse(txt_masach61.Text.Trim()));
                    cmd.ExecuteNonQuery();
                }
                string sqlSelect = "SELECT isbn, ma_cuonsach, tinhtrang FROM Cuonsach WHERE isbn = @isbn";
                using (SqlCommand cmdSelect = new SqlCommand(sqlSelect, sqlCon, tran))
                {
                    cmdSelect.Parameters.AddWithValue("@isbn", txt_isbn61.Text.Trim());
                    using (SqlDataAdapter da = new SqlDataAdapter(cmdSelect))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgv61.DataSource = dt;
                    }
                }
                tran.Rollback();
                MessageBox.Show("Đã chạy Trigger thành công");
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Them62_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_isbn62.Text) || string.IsNullOrWhiteSpace(txt_masach62.Text) || string.IsNullOrWhiteSpace(txt_madg62.Text))
            {
                MessageBox.Show("Vui lòng nhập mã ISBN, Mã cuốn sách và Mã độc giả hợp lệ");
                return;
            }

            try
            {
                string sql = @"INSERT INTO Muon (isbn, ma_cuonsach, ma_DocGia, ngay_muon, ngay_hethan) 
                               VALUES (@isbn, @macuon, @madg, CAST(GETDATE() AS DATE), DATEADD(day, 14, CAST(GETDATE() AS DATE)))";
                using (SqlCommand cmd = new SqlCommand(sql, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@isbn", txt_isbn62.Text.Trim());
                    cmd.Parameters.AddWithValue("@macuon", int.Parse(txt_masach62.Text.Trim()));
                    cmd.Parameters.AddWithValue("@madg", int.Parse(txt_madg62.Text.Trim()));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm lượt mượn thành công");
                }
                HienThiDuLieu("SELECT * FROM Cuonsach", dgv62);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
