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
    public partial class FormBai9 : Form
    {
        string strCon = @"Data Source=LAPTOP-DQP9I1OD\SQLEXPRESS;Initial Catalog = QuanLyGara; Integrated Security = True";
        SqlConnection sqlCon = null;
        public FormBai9()
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

                    if (!tab.TabPages.Contains(tab91)) tab.TabPages.Add(tab91);
                    if (!tab.TabPages.Contains(tab92)) tab.TabPages.Add(tab92);
                    if (!tab.TabPages.Contains(tab93)) tab.TabPages.Add(tab93);
                    if (!tab.TabPages.Contains(tab94)) tab.TabPages.Add(tab94);
                    if (!tab.TabPages.Contains(tab95)) tab.TabPages.Add(tab95);

                    ssl_Trangthai.Text = "Đã kết nối";
                    ssl_Trangthai.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message);
            }
        }

        private void FormBai9_Load(object sender, EventArgs e)
        {
            tab.TabPages.Remove(tab91);
            tab.TabPages.Remove(tab92);
            tab.TabPages.Remove(tab93);
            tab.TabPages.Remove(tab94);
            tab.TabPages.Remove(tab95);
        }

        private void btn_Ngat_Click(object sender, EventArgs e)
        {
            tab.TabPages.Remove(tab91);
            tab.TabPages.Remove(tab92);
            tab.TabPages.Remove(tab93);
            tab.TabPages.Remove(tab94);
            tab.TabPages.Remove(tab95);
            ssl_Trangthai.Text = "Chưa kết nối";
            ssl_Trangthai.ForeColor = Color.Red;
        }

        private void btn_Thongke91_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_DanhSachTho_KhongThamGiaHD()";
                HienThiDuLieu(sql, dgv91);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Thongke92_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_HopDong_ThanhLyChuaTraDu()";
                HienThiDuLieu(sql, dgv92);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Thongke93_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_HopDong_TruocNgay31122002()";
                HienThiDuLieu(sql, dgv93);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Thongke94_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_Tho_LamViecNhieuNhat()";
                HienThiDuLieu(sql, dgv94);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Thongke95_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM dbo.fn_Tho_TongTriGiaCaoNhat()";
                HienThiDuLieu(sql, dgv95);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
