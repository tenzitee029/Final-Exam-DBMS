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
    public partial class FormBai2 : Form
    {
        string strCon = @"Data Source=LAPTOP-DQP9I1OD\SQLEXPRESS;Initial Catalog = TinhToan; Integrated Security = True";
        SqlConnection sqlCon = null;
        public FormBai2()
        {
            InitializeComponent();
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
                txt_a.Clear();
                txt_b.Clear();
                txt_c.Clear();
                txt_Ketqua.Clear();
            }
            else
            {
                MessageBox.Show("Chưa tạo kết nối");
            }
        }

        private void FormBai2_Load(object sender, EventArgs e)
        {

        }

        private void FormBai2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }

        private void btn_Giai_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txt_a.Text, out double a))
            {
                MessageBox.Show("Vui lòng nhập hệ số a hợp lệ");
                txt_a.Focus();
                return;
            }
            if (!double.TryParse(txt_b.Text, out double b))
            {
                MessageBox.Show("Vui lòng nhập hệ số b hợp lệ");
                txt_b.Focus();
                return;
            }
            if (!double.TryParse(txt_c.Text, out double c))
            {
                MessageBox.Show("Vui lòng nhập hệ số c hợp lệ");
                txt_c.Focus();
                return;
            }
            try
            {
                string query = "SELECT dbo.fn_GiaiPTB2(@a, @b, @c)";
                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@a", a);
                    cmd.Parameters.AddWithValue("@b", b);
                    cmd.Parameters.AddWithValue("@c", c);
                    object result = cmd.ExecuteScalar();
                    txt_Ketqua.Text = result != null ? result.ToString() : "Không có kết quả";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi: " + ex.Message);
            }
        }
    }
}
