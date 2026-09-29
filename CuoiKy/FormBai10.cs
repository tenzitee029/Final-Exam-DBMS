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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CuoiKy
{
    public partial class FormBai10 : Form
    {
        public FormBai10()
        {
            InitializeComponent();
        }

        private void FormBai10_Load(object sender, EventArgs e)
        {

        }

        private void btn_101_Click(object sender, EventArgs e)
        {
            FormBai10_1 f = new FormBai10_1();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormBai10_2 f = new FormBai10_2();
            f.ShowDialog();
        }
    }
}
