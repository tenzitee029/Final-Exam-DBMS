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
                    HienThiDuLieu(@"SELECT cs.isbn, cs.ma_cuonsach, cs.tinhtrang, m.ma_DocGia, m.ngay_muon, m.ngay_hethan 
                                    FROM Cuonsach cs 
                                    LEFT JOIN Muon m ON cs.isbn = m.isbn AND cs.ma_cuonsach = m.ma_cuonsach", dgv62);
                    HienThiDuLieu("SELECT * FROM Dausach", dgv63);
                    HienThiDuLieu("SELECT * FROM Tuasach", dgv64);
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
                MessageBox.Show("Vui lòng nhập mã ISBN và Mã cuốn sách hợp lệ");
                return;
            }
            if (!int.TryParse(txt_masach61.Text.Trim(), out int maCuon))
            {
                MessageBox.Show("Mã cuốn sách phải là số nguyên");
                txt_masach61.Focus();
                return;
            }
            try
            {
                string sql = @"
                    BEGIN TRAN;
                        DELETE FROM Muon WHERE isbn = @isbn AND ma_cuonsach = @macuon;
                    ROLLBACK TRAN;";
                using (SqlCommand cmd = new SqlCommand(sql, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@isbn", txt_isbn61.Text.Trim());
                    cmd.Parameters.AddWithValue("@macuon", maCuon);
                    cmd.ExecuteNonQuery();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgv61.DataSource = dt;
                    }
                }
                MessageBox.Show("Dữ liệu hợp lệ");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Them62_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_isbn62.Text) ||
                string.IsNullOrWhiteSpace(txt_masach62.Text) ||
                string.IsNullOrWhiteSpace(txt_madg62.Text))
            {
                MessageBox.Show("Vui lòng nhập mã ISBN, Mã cuốn sách và Mã độc giả hợp lệ");
                return;
            }
            if (!int.TryParse(txt_masach62.Text.Trim(), out int maCuon))
            {
                MessageBox.Show("Mã cuốn sách phải là số nguyên");
                txt_masach62.Focus();
                return;
            }
            if (!int.TryParse(txt_madg62.Text.Trim(), out int maDG))
            {
                MessageBox.Show("Mã độc giả phải là số nguyên");
                txt_madg62.Focus();
                return;
            }
            try
            {
                string sql = @"
                    BEGIN TRAN;
                        INSERT INTO Muon (isbn, ma_cuonsach, ma_DocGia, ngay_muon, ngay_hethan) 
                        VALUES (@isbn, @macuon, @madg, CAST(GETDATE() AS DATE), DATEADD(day, 14, CAST(GETDATE() AS DATE)));
                    ROLLBACK TRAN;";
                using (SqlCommand cmd = new SqlCommand(sql, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@isbn", txt_isbn62.Text.Trim());
                    cmd.Parameters.AddWithValue("@macuon", maCuon);
                    cmd.Parameters.AddWithValue("@madg", maDG);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Dữ liệu hợp lệ");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Capnhat63_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_isbn63.Text) || 
                string.IsNullOrWhiteSpace(txt_masach63.Text))
            {
                MessageBox.Show("Vui lòng nhập mã ISBN và Mã cuốn sách hợp lệ");
                return;
            }
            if (!int.TryParse(txt_masach63.Text.Trim(), out int maCuon))
            {
                MessageBox.Show("Mã cuốn sách phải là số nguyên");
                txt_masach63.Focus();
                return;
            }
            try
            {
                string sql = @"
                    BEGIN TRAN;
                        UPDATE Cuonsach 
                        SET tinhtrang = @tinhtrang 
                        WHERE isbn = @isbn AND ma_cuonsach = @macuon;
                    ROLLBACK TRAN;";
                using (SqlCommand cmd = new SqlCommand(sql, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@tinhtrang", cbo_tinhtrang63.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@isbn", txt_isbn63.Text.Trim());
                    cmd.Parameters.AddWithValue("@macuon", maCuon);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Dữ liệu hợp lệ");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Capnhat64_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_matua64.Text) || 
                string.IsNullOrWhiteSpace(txt_tg64.Text))
            {
                MessageBox.Show("Vui lòng nhập mã dữ liệu hợp lệ");
                return;
            }
            if (!int.TryParse(txt_matua64.Text.Trim(), out int maTua))
            {
                MessageBox.Show("Mã tựa sách phải là số nguyên");
                txt_matua64.Focus();
                return;
            }
            try
            {
                string sql = @"
                    BEGIN TRAN;
                        UPDATE Tuasach 
                        SET tacgia = @tacgia 
                        WHERE ma_tuasach = @matua;
                    ROLLBACK TRAN;";

                using (SqlCommand cmd = new SqlCommand(sql, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@tacgia", txt_tg64.Text.Trim());
                    cmd.Parameters.AddWithValue("@matua", maTua);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Dữ liệu hợp lệ");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void FormBai6_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
    }
}
