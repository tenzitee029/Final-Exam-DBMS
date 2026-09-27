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

        string dt71 = @"SELECT nv.MaNV, (nv.HoNV + ' ' + nv.TenLot + ' ' + nv.TenNV) AS HoTen, 
                             pb.MaPB, pb.TenPB, nv.Luong 
                      FROM NHANVIEN nv 
                      JOIN PHONGBAN pb ON nv.MaPB = pb.MaPB";
        string dt72 = @"SELECT nv.MaNV, 
                                   (nv.HoNV + ' ' + nv.TenLot + ' ' + nv.TenNV) AS HoTen, 
                                   da.MaDA, da.TenDA, 
                                   nv.Luong, 
                                   pc.ThoiGian 
                            FROM PHANCONG pc
                            JOIN NHANVIEN nv ON pc.MaNV = nv.MaNV
                            JOIN DEAN da ON pc.MaDA = da.MaDA";
        string dt73 = @"SELECT pb.MaPB, pb.TenPB, 
                                  nv.MaNV, 
                                  (nv.HoNV + ' ' + nv.TenLot + ' ' + nv.TenNV) AS HoTen, 
                                  nv.Luong 
                           FROM PHONGBAN pb
                           JOIN NHANVIEN nv ON pb.MaPB = nv.MaPB";
        string dt74 = @"SELECT pc.MaNV, 
                       (nv.HoNV + ' ' + nv.TenLot + ' ' + nv.TenNV) AS HoTen, 
                       pc.MaDA, da.TenDA, 
                       pc.ThoiGian 
                FROM PHANCONG pc
                JOIN NHANVIEN nv ON pc.MaNV = nv.MaNV
                JOIN DEAN da ON pc.MaDA = da.MaDA";
        string dt75 = @"SELECT pb.MaPB, pb.TenPB, da.MaDA, da.TenDA, da.DiaDiemDA 
                FROM PHONGBAN pb 
                JOIN DEAN da ON pb.MaPB = da.MaPB";
        string dt76 = @"SELECT nv.MaNV, nv.HoNV, nv.TenLot, nv.TenNV, nv.NgaySinh, nv.Phai, nv.DiaChi, nv.Luong, nv.MaPB 
                FROM NHANVIEN nv";
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

                    HienThiDuLieu(dt71, dgv71);
                    HienThiDuLieu(dt72, dgv72);
                    HienThiDuLieu(dt73, dgv_full73);
                    HienThiDuLieu(dt74, dgv74);
                    HienThiDuLieu(dt75, dgv_full75);
                    HienThiDuLieu(dt76, dgv76);
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
                MessageBox.Show("Vui lòng nhập mã phòng ban hợp lệ");
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
                    txt_luongtb71.Text = luongTB.ToString();
                }
                string sqlLoc = @"SELECT nv.MaNV, (nv.HoNV + ' ' + nv.TenLot + ' ' + nv.TenNV) AS HoTen, 
                                          pb.MaPB, pb.TenPB, nv.Luong 
                                   FROM NHANVIEN nv 
                                   JOIN PHONGBAN pb ON nv.MaPB = pb.MaPB 
                                   WHERE nv.MaPB = @MaPB"; ;
                HienThiDuLieu(sqlLoc, dgv71, new SqlParameter("@MaPB", maPB));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Tinh72_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_manv72.Text) || string.IsNullOrWhiteSpace(txt_mada72.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã nhân viên và Mã dự án hợp lệ");
                return;
            }
            try
            {
                string maNV = txt_manv72.Text.Trim();
                int maDA = int.Parse(txt_mada72.Text.Trim());
                string sqlFunc = "SELECT dbo.fn_TongLuongNV_TheoDuAn(@MaNV, @MaDA)";
                using (SqlCommand cmd = new SqlCommand(sqlFunc, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@MaDA", maDA);
                    object res = cmd.ExecuteScalar();
                    double tongLuong = (res != DBNull.Value) ? Convert.ToDouble(res) : 0;
                    txt_tongluong72.Text = tongLuong.ToString();
                }
                string sqlLoc = @"SELECT nv.MaNV, 
                                 (nv.HoNV + ' ' + nv.TenLot + ' ' + nv.TenNV) AS HoTen, 
                                 da.MaDA, da.TenDA, 
                                 nv.Luong, 
                                 pc.ThoiGian 
                          FROM PHANCONG pc
                          JOIN NHANVIEN nv ON pc.MaNV = nv.MaNV
                          JOIN DEAN da ON pc.MaDA = da.MaDA
                          WHERE pc.MaNV = @MaNV AND pc.MaDA = @MaDA";
                HienThiDuLieu(sqlLoc, dgv72, new SqlParameter("@MaNV", maNV), new SqlParameter("@MaDA", maDA));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Thongke73_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlTableFunc = "SELECT * FROM dbo.fn_LuongTrungBinh_CacPhongBan()";
                HienThiDuLieu(sqlTableFunc, dgv_tb73);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Tinh74_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_giolam74.Text))
            {
                MessageBox.Show("Vui lòng nhập số giờ hợp lệ");
                return;
            }
            try
            {
                double gio = double.Parse(txt_giolam74.Text.Trim());
                string sqlFunc = "SELECT dbo.fn_TinhTienThuong(@Gio)";
                using (SqlCommand cmd = new SqlCommand(sqlFunc, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Gio", gio);
                    object res = cmd.ExecuteScalar();
                    int tienThuong = (res != DBNull.Value) ? Convert.ToInt32(res) : 0;
                    txt_thuong74.Text = tienThuong.ToString();
                }
                string sqlLoc = @"SELECT pc.MaNV, 
                                 (nv.HoNV + ' ' + nv.TenLot + ' ' + nv.TenNV) AS HoTen, 
                                 pc.MaDA, da.TenDA, 
                                 pc.ThoiGian 
                          FROM PHANCONG pc
                          JOIN NHANVIEN nv ON pc.MaNV = nv.MaNV
                          JOIN DEAN da ON pc.MaDA = da.MaDA
                          WHERE pc.ThoiGian = @Gio";
                HienThiDuLieu(sqlLoc, dgv74, new SqlParameter("@Gio", gio));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_thongke74_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlTableFunc = "SELECT * FROM dbo.fn_TongSoDuAn_MoiPhongBan()";
                HienThiDuLieu(sqlTableFunc, dgv_tk75);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Hienthi76_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlFunc = "";
                if (rad_inline.Checked)
                {
                    sqlFunc = "SELECT * FROM dbo.fn_ThongTinNhanVien_Inline()";
                }
                else
                {
                    sqlFunc = "SELECT * FROM dbo.fn_ThongTinNhanVien_MultiStatement()";
                }

                HienThiDuLieu(sqlFunc, dgv76);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void FormBai7_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
    }
}
