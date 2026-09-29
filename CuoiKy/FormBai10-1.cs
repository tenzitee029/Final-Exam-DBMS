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
    public partial class FormBai10_1 : Form
    {
        string strCon = @"Data Source=LAPTOP-DQP9I1OD\SQLEXPRESS;Initial Catalog = QLThi; Integrated Security = True";
        SqlConnection sqlCon = null;
        public FormBai10_1()
        {
            InitializeComponent();
        }

        private void FormBai10_1_Load(object sender, EventArgs e)
        {
            tab.TabPages.Remove(tab_a);
            tab.TabPages.Remove(tab_b);
            tab.TabPages.Remove(tab_c);
        }

        private void HienThiDuLieu(string sql, DataGridView dgv, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, sqlCon))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
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

                    if (!tab.TabPages.Contains(tab_a)) tab.TabPages.Add(tab_a);
                    if (!tab.TabPages.Contains(tab_b)) tab.TabPages.Add(tab_b);
                    if (!tab.TabPages.Contains(tab_c)) tab.TabPages.Add(tab_c);

                    ssl_Trangthai.Text = "Đã kết nối";
                    ssl_Trangthai.ForeColor = Color.Green;

                    HienThiDuLieu("SELECT * FROM GV", dgv_dta);
                    HienThiDuLieu("SELECT * FROM PC_COI_THI", dgv_a);
                    HienThiDuLieu("SELECT * FROM MHOC", dgv_dtb);
                    HienThiDuLieu("SELECT * FROM BUOITHI", dgv_b);
                    HienThiDuLieu("SELECT * FROM MHOC", dgv_dtc);
                    HienThiDuLieu("SELECT * FROM BUOITHI", dgv_c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message);
            }
        }

        private void btn_Ngat_Click(object sender, EventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
                MessageBox.Show("Đã đóng kết nối");
            }
            tab.TabPages.Remove(tab_a);
            tab.TabPages.Remove(tab_b);
            tab.TabPages.Remove(tab_c);

            ssl_Trangthai.Text = "Chưa kết nối";
            ssl_Trangthai.ForeColor = Color.Red;
        }

        private void FormBai10_1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }

        private void btn_Kiemtraa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaGV_101a.Text) ||
                string.IsNullOrWhiteSpace(txt_HK_101a.Text) ||
                string.IsNullOrWhiteSpace(txt_Ngay_101a.Text) ||
                string.IsNullOrWhiteSpace(txt_Gio_101a.Text) ||
                string.IsNullOrWhiteSpace(txt_Phg_101a.Text))
            {
                MessageBox.Show("Vui lòng nhập mã dữ liệu hợp lệ");
                return;
            }
            if (!int.TryParse(txt_HK_101a.Text.Trim(), out int hk))
            {
                MessageBox.Show("Học kỳ phải là số nguyên");
                txt_HK_101a.Focus();
                return;
            }
            if (!DateTime.TryParse(txt_Ngay_101a.Text.Trim(), out DateTime ngay))
            {
                MessageBox.Show("Ngày thi không đúng định dạng (YYYY-MM-DD)");
                txt_Ngay_101a.Focus();
                return;
            }
            if (!TimeSpan.TryParse(txt_Gio_101a.Text.Trim(), out TimeSpan gio))
            {
                MessageBox.Show("Giờ thi không đúng định dạng (HH:mm:ss)");
                txt_Gio_101a.Focus();
                return;
            }
            try
            {
                string sql = @"
                    BEGIN TRAN;
                        INSERT INTO PC_COI_THI (MAGV, HK, NGAY, GIO, PHG)
                        VALUES (@magv, @hk, @ngay, @gio, @phg);
                    ROLLBACK TRAN;";
                using (SqlCommand cmd = new SqlCommand(sql, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@magv", txt_MaGV_101a.Text.Trim());
                    cmd.Parameters.AddWithValue("@hk", int.Parse(txt_HK_101a.Text.Trim()));
                    cmd.Parameters.AddWithValue("@ngay", DateTime.Parse(txt_Ngay_101a.Text.Trim()));
                    cmd.Parameters.AddWithValue("@gio", TimeSpan.Parse(txt_Gio_101a.Text.Trim()));
                    cmd.Parameters.AddWithValue("@phg", txt_Phg_101a.Text.Trim());
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

        private void btn_Kiemtrab_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_HK_101b.Text) ||
                string.IsNullOrWhiteSpace(txt_Ngay_101b.Text) ||
                string.IsNullOrWhiteSpace(txt_Gio_101b.Text) ||
                string.IsNullOrWhiteSpace(txt_Phg_101b.Text) ||
                string.IsNullOrWhiteSpace(txt_MaMH_101b.Text) ||
                string.IsNullOrWhiteSpace(txt_TGThi_101b.Text))
            {
                MessageBox.Show("Vui lòng nhập mã dữ liệu hợp lệ");
                return;
            }
            if (!int.TryParse(txt_HK_101b.Text.Trim(), out int hk))
            {
                MessageBox.Show("Học kỳ phải là số nguyên");
                txt_HK_101b.Focus();
                return;
            }
            if (!DateTime.TryParse(txt_Ngay_101b.Text.Trim(), out DateTime ngay))
            {
                MessageBox.Show("Ngày thi không đúng định dạng (YYYY-MM-DD)");
                txt_Ngay_101b.Focus();
                return;
            }
            if (!TimeSpan.TryParse(txt_Gio_101b.Text.Trim(), out TimeSpan gio))
            {
                MessageBox.Show("Giờ thi không đúng định dạng (HH:mm:ss)");
                txt_Gio_101b.Focus();
                return;
            }
            if (!int.TryParse(txt_TGThi_101b.Text.Trim(), out int tgThi) || tgThi <= 0)
            {
                MessageBox.Show("Thời gian thi phải là số nguyên dương");
                txt_TGThi_101b.Focus();
                return;
            }
            {
                try
                {
                    string sql = @"
                    BEGIN TRAN;
                        INSERT INTO BUOITHI (HKY, NGAY, GIO, PHG, MAMH, TGTHI)
                        VALUES (@hk, @ngay, @gio, @phg, @mamh, @tgthi);
                    ROLLBACK TRAN;";
                    using (SqlCommand cmd = new SqlCommand(sql, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@hk", int.Parse(txt_HK_101b.Text.Trim()));
                        cmd.Parameters.AddWithValue("@ngay", DateTime.Parse(txt_Ngay_101b.Text.Trim()));
                        cmd.Parameters.AddWithValue("@gio", TimeSpan.Parse(txt_Gio_101b.Text.Trim()));
                        cmd.Parameters.AddWithValue("@phg", txt_Phg_101b.Text.Trim());
                        cmd.Parameters.AddWithValue("@mamh", txt_MaMH_101b.Text.Trim());
                        cmd.Parameters.AddWithValue("@tgthi", int.Parse(txt_TGThi_101b.Text.Trim()));
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
        }

        private void btn_Kiemtrac_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_HK_101c.Text) ||
                string.IsNullOrWhiteSpace(txt_Ngay_101c.Text) ||
                string.IsNullOrWhiteSpace(txt_Gio_101c.Text) ||
                string.IsNullOrWhiteSpace(txt_Phg_101c.Text) ||
                string.IsNullOrWhiteSpace(txt_MaMH_101c.Text) ||
                string.IsNullOrWhiteSpace(txt_TGThi_101c.Text))
            {
                MessageBox.Show("Dữ liệu hợp lệ");
                return;
            }
            if (!int.TryParse(txt_HK_101c.Text.Trim(), out int hk))
            {
                MessageBox.Show("Học kỳ phải là số nguyên");
                txt_HK_101c.Focus();
                return;
            }
            if (!DateTime.TryParse(txt_Ngay_101c.Text.Trim(), out DateTime ngay))
            {
                MessageBox.Show("Ngày thi không đúng định dạng (YYYY-MM-DD)");
                txt_Ngay_101c.Focus();
                return;
            }
            if (!TimeSpan.TryParse(txt_Gio_101c.Text.Trim(), out TimeSpan gio))
            {
                MessageBox.Show("Giờ thi không đúng định dạng (HH:mm:ss)");
                txt_Gio_101c.Focus();
                return;
            }
            if (!int.TryParse(txt_TGThi_101c.Text.Trim(), out int tgThi) || tgThi <= 0)
            {
                MessageBox.Show("Thời gian thi phải là số nguyên dương");
                txt_TGThi_101c.Focus();
                return;
            }
            try
            {
                string sql = @"
            BEGIN TRAN;
                INSERT INTO BUOITHI (HKY, NGAY, GIO, PHG, MAMH, TGTHI)
                VALUES (@hk, @ngay, @gio, @phg, @mamh, @tgthi);
            ROLLBACK TRAN;";

                using (SqlCommand cmd = new SqlCommand(sql, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@hk", hk);
                    cmd.Parameters.AddWithValue("@ngay", ngay);
                    cmd.Parameters.AddWithValue("@gio", gio);
                    cmd.Parameters.AddWithValue("@phg", txt_Phg_101c.Text.Trim());
                    cmd.Parameters.AddWithValue("@mamh", txt_MaMH_101c.Text.Trim());
                    cmd.Parameters.AddWithValue("@tgthi", tgThi);
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
    }
}
