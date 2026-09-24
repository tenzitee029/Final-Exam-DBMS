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
    public partial class FormBai4 : Form
    {
        string strCon = @"Data Source=LAPTOP-DQP9I1OD\SQLEXPRESS;Initial Catalog = TinhToan; Integrated Security = True";
        SqlConnection sqlCon = null;
        public FormBai4()
        {
            InitializeComponent();
        }

        private void FormBai4_Load(object sender, EventArgs e)
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
                    pnl_Noidung.Enabled = true;
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
                pnl_Noidung.Enabled = false;
                txt_namsinh.Clear();
                txt_Ketqua.Clear();
                ssl_Trangthai.Text = "Chưa kết nối";
                ssl_Trangthai.ForeColor = Color.Red;
            }
            else
            {
                MessageBox.Show("Chưa tạo kết nối");
            }
        }

        private void btn_Tinh_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txt_namsinh.Text.Trim(), out int Namsinh)) {
                MessageBox.Show("Vui lòng nhập một năm sinh hợp lệ");
                txt_namsinh.Focus();
                return;
            }
            try
            {
                string query = "SELECT dbo.fn_TinhTuoi(@Namsinh)";
                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Namsinh", Namsinh);
                    object result = cmd.ExecuteScalar();
                    txt_Ketqua.Text = result != null ? result.ToString() : "Không có kết quả";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi" + ex.Message);
            }
        }

        private void FormBai4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
    }
}
