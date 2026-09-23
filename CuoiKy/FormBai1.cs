using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace CuoiKy
{
    public partial class FormBai1 : Form
    {
        string strCon = @"Data Source=LAPTOP-DQP9I1OD\SQLEXPRESS;Initial Catalog = TinhToan; Integrated Security = True";
        SqlConnection sqlCon = null;

        public FormBai1()
        {
            InitializeComponent();
        }

        private void FormBai1_Load(object sender, EventArgs e)
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
                txt_Ketqua.Clear();
            }
            else
            {
                MessageBox.Show("Chưa tạo kết nối");
            }
        }

        private void Form_Bai01_FormClosing(object sender, FormClosingEventArgs e)
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
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_GiaiPTB1", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a", a);
                    cmd.Parameters.AddWithValue("@b", b);
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