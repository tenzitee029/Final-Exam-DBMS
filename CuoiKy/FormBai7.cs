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
    public partial class FormBai7 : Form
    {
        string strCon = @"Data Source=LAPTOP-DQP9I1OD\SQLEXPRESS;Initial Catalog = DeAn; Integrated Security = True";
        SqlConnection sqlCon = null;
        public FormBai7()
        {
            InitializeComponent();
        }

        private void FormBai7_Load(object sender, EventArgs e)
        {
            tab.TabPages.Remove(tab71);
            tab.TabPages.Remove(tab72);
            tab.TabPages.Remove(tab73);
            tab.TabPages.Remove(tab74);
            tab.TabPages.Remove(tab75);
            tab.TabPages.Remove(tab76);
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

        string fullnv = @"SELECT nv.MaNV, (nv.HoNV + ' ' + nv.TenLot + ' ' + nv.TenNV) AS HoTen, 
                             pb.MaPB, pb.TenPB, nv.Luong 
                      FROM NHANVIEN nv 
                      JOIN PHONGBAN pb ON nv.MaPB = pb.MaPB";
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

                    if (!tab.TabPages.Contains(tab71)) tab.TabPages.Add(tab71);
                    if (!tab.TabPages.Contains(tab72)) tab.TabPages.Add(tab72);
                    if (!tab.TabPages.Contains(tab73)) tab.TabPages.Add(tab73);
                    if (!tab.TabPages.Contains(tab74)) tab.TabPages.Add(tab74);
                    if (!tab.TabPages.Contains(tab75)) tab.TabPages.Add(tab75);
                    if (!tab.TabPages.Contains(tab76)) tab.TabPages.Add(tab76);

                    ssl_Trangthai.Text = "Đã kết nối";
                    ssl_Trangthai.ForeColor = Color.Green;

                    HienThiDuLieu(fullnv, dgv71);
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
                MessageBox.Show("Đã đóng kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tab.TabPages.Remove(tab71);
                tab.TabPages.Remove(tab72);
                tab.TabPages.Remove(tab73);
                tab.TabPages.Remove(tab74);
                tab.TabPages.Remove(tab75);
                tab.TabPages.Remove(tab76);
            }
            ssl_Trangthai.Text = "Chưa kết nối";
            ssl_Trangthai.ForeColor = Color.Red;
        }

        private void btn_Tinh71_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_mapb71.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phòng ban!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int maPB = int.Parse(txt_mapb71.Text.Trim());
                string sqlFunc = "SELECT dbo.fn_LuongTrungBinh_PhongBan(@MaPB)";
                using (SqlCommand cmd = new SqlCommand(sqlFunc, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@MaPB", maPB);
                    object res = cmd.ExecuteScalar();
                    double luongTB = (res != DBNull.Value) ? Convert.ToDouble(res) : 0;
                    txt_luongtb71.Text = luongTB.ToString("N2") + " $";
                }
                string sqlLoc = @"SELECT nv.MaNV, (nv.HoNV + ' ' + nv.TenLot + ' ' + nv.TenNV) AS HoTen, 
                                          pb.MaPB, pb.TenPB, nv.Luong 
                                   FROM NHANVIEN nv 
                                   JOIN PHONGBAN pb ON nv.MaPB = pb.MaPB 
                                   WHERE nv.MaPB = @MaPB"; ;
                HienThiDuLieu(sqlLoc, dgv71, new SqlParameter("@MaPB", maPB));
            }
            catch (FormatException)
            {
                MessageBox.Show("Mã phòng ban phải là số nguyên hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
