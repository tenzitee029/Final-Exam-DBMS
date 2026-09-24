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
    public partial class FormBai3 : Form
    {
        string strCon = @"Data Source=LAPTOP-DQP9I1OD\SQLEXPRESS;Initial Catalog = QuanLyThuVien; Integrated Security = True";
        SqlConnection sqlCon = null;
        public FormBai3()
        {
            InitializeComponent();
        }

        private void FormBai3_Load(object sender, EventArgs e)
        {

        }

        private void btn_Ketnoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    MessageBox.Show("Kết nối thành công");
                    txt_isbn.Enabled = true;
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
                txt_isbn.Clear();
                dgv_DauSach.DataSource = null;
                txt_isbn.Enabled = false;
                ssl_Trangthai.Text = "Chưa kết nối";
                ssl_Trangthai.ForeColor = Color.Red;
            }
            else
            {
                MessageBox.Show("Chưa tạo kết nối");
            }
        }

        private void btn_Hienthi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_isbn.Text))
            {
                MessageBox.Show("Vui lòng nhập mã ISBN cần tra cứu hợp lệ");
                txt_isbn.Focus();
                return;
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Thongtindausach", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("isbn", txt_isbn.Text.Trim());
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_DauSach.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message);
            }
        }

        private void FormBai3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
        
    }
}
