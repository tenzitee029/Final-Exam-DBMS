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
                    if (!tab.TabPages.Contains(tab_5a)) tab.TabPages.Add(tab_5a);
                    if (!tab.TabPages.Contains(tab_5b)) tab.TabPages.Add(tab_5b);
                    if (!tab.TabPages.Contains(tab_5c)) tab.TabPages.Add(tab_5c);
                    if (!tab.TabPages.Contains(tab_5d)) tab.TabPages.Add(tab_5d);
                    if (!tab.TabPages.Contains(tab_5e)) tab.TabPages.Add(tab_5e);
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
            }
        }
    }
}
