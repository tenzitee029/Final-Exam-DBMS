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
    public partial class FormBai10_2 : Form
    {
        string strCon = @"Data Source=LAPTOP-DQP9I1OD\SQLEXPRESS;Initial Catalog = QLThi; Integrated Security = True";
        SqlConnection sqlCon = null;
        public FormBai10_2()
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
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormBai10_2_Load(object sender, EventArgs e)
        {
            tab.TabPages.Remove(tab_a);
            tab.TabPages.Remove(tab_b);
            tab.TabPages.Remove(tab_c);
            tab.TabPages.Remove(tab_d);
            tab.TabPages.Remove(tab_e);
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
                    if (!tab.TabPages.Contains(tab_d)) tab.TabPages.Add(tab_d);
                    if (!tab.TabPages.Contains(tab_e)) tab.TabPages.Add(tab_e);

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
            }
            tab.TabPages.Remove(tab_a);
            tab.TabPages.Remove(tab_b);
            tab.TabPages.Remove(tab_c);
            tab.TabPages.Remove(tab_d);
            tab.TabPages.Remove(tab_e);
            ssl_Trangthai.Text = "Chưa kết nối";
            ssl_Trangthai.ForeColor = Color.Red;
        }

        private void btn_Thongkea_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_DanhSachGV_DayMon_Tren45Tiet()";
                HienThiDuLieu(sql, dgv_a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Thongkeb_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_DanhSachGV_GacThi_HK1()";
                HienThiDuLieu(sql, dgv_b);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Thongkec_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_DanhSachGV_KhongGacThi_HK1()";
                HienThiDuLieu(sql, dgv_c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Thongked_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_LichThi_MonVan()";
                HienThiDuLieu(sql, dgv_d);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Thongkee_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_BuoiGacThi_GV_ChuNhiemMonVan()";
                HienThiDuLieu(sql, dgv_e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void FormBai10_2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
    }
}
