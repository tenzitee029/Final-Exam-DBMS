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
    public partial class FormBai5 : Form
    {
        string strCon = @"Data Source=LAPTOP-DQP9I1OD\SQLEXPRESS;Initial Catalog = QuanLyThuVien; Integrated Security = True";
        SqlConnection sqlCon = null;
        public FormBai5()
        {
            InitializeComponent();
        }

        private void FormBai5_Load(object sender, EventArgs e)
        {
            tab.TabPages.Remove(tab_5a);
            tab.TabPages.Remove(tab_5b);
            tab.TabPages.Remove(tab_5c);
            tab.TabPages.Remove(tab_5d);
            tab.TabPages.Remove(tab_5e);
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
                    if (!tab.TabPages.Contains(tab_5a)) tab.TabPages.Add(tab_5a);
                    if (!tab.TabPages.Contains(tab_5b)) tab.TabPages.Add(tab_5b);
                    if (!tab.TabPages.Contains(tab_5c)) tab.TabPages.Add(tab_5c);
                    if (!tab.TabPages.Contains(tab_5d)) tab.TabPages.Add(tab_5d);
                    if (!tab.TabPages.Contains(tab_5e)) tab.TabPages.Add(tab_5e);
                    ssl_Trangthai.Text = "Đã kết nối";
                    ssl_Trangthai.ForeColor = Color.Green;
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
                tab.TabPages.Remove(tab_5a);
                tab.TabPages.Remove(tab_5b);
                tab.TabPages.Remove(tab_5c);
                tab.TabPages.Remove(tab_5d);
                tab.TabPages.Remove(tab_5e);
            }
            else
            {
                MessageBox.Show("Chưa tạo kết nối");
            }
            ssl_Trangthai.Text = "Chưa kết nối";
            ssl_Trangthai.ForeColor = Color.Red;
        }

        private void btn_Hienthi5a_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txt_Madocgia.Text.Trim(), out int maDG))
            {
                MessageBox.Show("Vui lòng nhập Mã độc giả hợp lệ");
                txt_Madocgia.Focus();
                return;
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ThongtinDocGia", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_DocGia", maDG);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_5a.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message);
            }
        }

        private void btn_Hienthi5b_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_isbn.Text))
            {
                MessageBox.Show("Vui lòng nhập mã ISBN cần tra cứu hợp lệ");
                txt_isbn.Focus();
                return;
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Thongtin_DauSach", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("isbn", txt_isbn.Text.Trim());
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_5b.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message);
            }
        }

        private void FormBai5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }

        private void btn_Hienthi_5c_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("sp_ThongtinNguoilonDangmuon", sqlCon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv_5c.DataSource = dt;
                }
            }
        }

        private void btn_Hienthi5d_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("sp_ThongtinNguoilonQuahan", sqlCon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv_5d.DataSource = dt;
                }
            }
        }

        private void btn_Hienthi5e_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("sp_DocGiaCoTreEmMuon", sqlCon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv_5e.DataSource = dt;
                }
            }
        }
    }
}
