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
    public partial class FormBai8 : Form
    {
        string strCon = @"Data Source=LAPTOP-DQP9I1OD\SQLEXPRESS;Initial Catalog = DeAn; Integrated Security = True";
        SqlConnection sqlCon = null;
        public FormBai8()
        {
            InitializeComponent();
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

        private void FormBai8_Load(object sender, EventArgs e)
        {
            tab.TabPages.Remove(tab81);
            tab.TabPages.Remove(tab82);
            tab.TabPages.Remove(tab83);
            tab.TabPages.Remove(tab84);
            tab.TabPages.Remove(tab85);
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

                    if (!tab.TabPages.Contains(tab81)) tab.TabPages.Add(tab81);
                    if (!tab.TabPages.Contains(tab82)) tab.TabPages.Add(tab82);
                    if (!tab.TabPages.Contains(tab83)) tab.TabPages.Add(tab83);
                    if (!tab.TabPages.Contains(tab84)) tab.TabPages.Add(tab84);
                    if (!tab.TabPages.Contains(tab85)) tab.TabPages.Add(tab85);

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

                tab.TabPages.Remove(tab81);
                tab.TabPages.Remove(tab82);
                tab.TabPages.Remove(tab83);
                tab.TabPages.Remove(tab84);
                tab.TabPages.Remove(tab85);
            }
            ssl_Trangthai.Text = "Chưa kết nối";
            ssl_Trangthai.ForeColor = Color.Red;
        }

        private void btn_Thongke81_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_DuAn_Tren2NV()";
                HienThiDuLieu(sql, dgv81);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Thongke82_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_Phong_Tren2NV_LuongTren25000()";
                HienThiDuLieu(sql, dgv82);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Thongke83_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_Phong_LuongTB_Tren30000()";
                HienThiDuLieu(sql, dgv83);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Thongke84_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_Phong_LuongTB_Tren30000_NVNam()";
                HienThiDuLieu(sql, dgv84);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Thongke85_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_DuAn_SoLuongNV_Phong5()";
                HienThiDuLieu(sql, dgv85);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void FormBai8_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
    }
}
