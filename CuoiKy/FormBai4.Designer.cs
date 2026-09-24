namespace CuoiKy
{
    partial class FormBai4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_Noidung = new System.Windows.Forms.Panel();
            this.txt_Ketqua = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_namsinh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Tinh = new System.Windows.Forms.Button();
            this.btn_Ketnoi = new System.Windows.Forms.Button();
            this.btn_Ngat = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ssl_Trangthai = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.pnl_Noidung.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "BÀI 4: TÍNH TUỔI THEO NĂM SINH";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 66);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(576, 49);
            this.label2.TabIndex = 0;
            this.label2.Text = "Viết hàm tính tuổi của người có năm sinh được nhập vào như một tham số của hàm\r\n";
            // 
            // pnl_Noidung
            // 
            this.pnl_Noidung.BackColor = System.Drawing.Color.Gainsboro;
            this.pnl_Noidung.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Noidung.Controls.Add(this.txt_Ketqua);
            this.pnl_Noidung.Controls.Add(this.label5);
            this.pnl_Noidung.Controls.Add(this.txt_namsinh);
            this.pnl_Noidung.Controls.Add(this.label3);
            this.pnl_Noidung.Enabled = false;
            this.pnl_Noidung.Location = new System.Drawing.Point(28, 155);
            this.pnl_Noidung.Name = "pnl_Noidung";
            this.pnl_Noidung.Size = new System.Drawing.Size(558, 141);
            this.pnl_Noidung.TabIndex = 5;
            // 
            // txt_Ketqua
            // 
            this.txt_Ketqua.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Ketqua.Location = new System.Drawing.Point(29, 91);
            this.txt_Ketqua.Name = "txt_Ketqua";
            this.txt_Ketqua.ReadOnly = true;
            this.txt_Ketqua.Size = new System.Drawing.Size(468, 32);
            this.txt_Ketqua.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kết quả: ";
            // 
            // txt_namsinh
            // 
            this.txt_namsinh.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_namsinh.Location = new System.Drawing.Point(126, 10);
            this.txt_namsinh.Name = "txt_namsinh";
            this.txt_namsinh.Size = new System.Drawing.Size(125, 32);
            this.txt_namsinh.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Năm sinh: ";
            // 
            // btn_Tinh
            // 
            this.btn_Tinh.BackColor = System.Drawing.Color.Silver;
            this.btn_Tinh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Tinh.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tinh.Location = new System.Drawing.Point(498, 302);
            this.btn_Tinh.Name = "btn_Tinh";
            this.btn_Tinh.Size = new System.Drawing.Size(74, 35);
            this.btn_Tinh.TabIndex = 8;
            this.btn_Tinh.Text = "Tính";
            this.btn_Tinh.UseVisualStyleBackColor = false;
            this.btn_Tinh.Click += new System.EventHandler(this.btn_Tinh_Click);
            // 
            // btn_Ketnoi
            // 
            this.btn_Ketnoi.BackColor = System.Drawing.Color.LightGreen;
            this.btn_Ketnoi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Ketnoi.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ketnoi.Location = new System.Drawing.Point(432, 112);
            this.btn_Ketnoi.Name = "btn_Ketnoi";
            this.btn_Ketnoi.Size = new System.Drawing.Size(74, 35);
            this.btn_Ketnoi.TabIndex = 6;
            this.btn_Ketnoi.Text = "Kết nối";
            this.btn_Ketnoi.UseVisualStyleBackColor = false;
            this.btn_Ketnoi.Click += new System.EventHandler(this.btn_Ketnoi_Click);
            // 
            // btn_Ngat
            // 
            this.btn_Ngat.BackColor = System.Drawing.Color.LightCoral;
            this.btn_Ngat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Ngat.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ngat.ForeColor = System.Drawing.Color.Black;
            this.btn_Ngat.Location = new System.Drawing.Point(512, 112);
            this.btn_Ngat.Name = "btn_Ngat";
            this.btn_Ngat.Size = new System.Drawing.Size(74, 35);
            this.btn_Ngat.TabIndex = 7;
            this.btn_Ngat.Text = "Ngắt";
            this.btn_Ngat.UseVisualStyleBackColor = false;
            this.btn_Ngat.Click += new System.EventHandler(this.btn_Ngat_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssl_Trangthai});
            this.statusStrip1.Location = new System.Drawing.Point(0, 338);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(614, 26);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ssl_Trangthai
            // 
            this.ssl_Trangthai.Name = "ssl_Trangthai";
            this.ssl_Trangthai.Size = new System.Drawing.Size(92, 20);
            this.ssl_Trangthai.Text = "Chưa kết nối";
            // 
            // FormBai4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 364);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_Tinh);
            this.Controls.Add(this.btn_Ketnoi);
            this.Controls.Add(this.btn_Ngat);
            this.Controls.Add(this.pnl_Noidung);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FormBai4";
            this.Text = "Bài 4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBai4_FormClosing);
            this.Load += new System.EventHandler(this.FormBai4_Load);
            this.panel1.ResumeLayout(false);
            this.pnl_Noidung.ResumeLayout(false);
            this.pnl_Noidung.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_Noidung;
        private System.Windows.Forms.TextBox txt_Ketqua;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_namsinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Tinh;
        private System.Windows.Forms.Button btn_Ketnoi;
        private System.Windows.Forms.Button btn_Ngat;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ssl_Trangthai;
    }
}