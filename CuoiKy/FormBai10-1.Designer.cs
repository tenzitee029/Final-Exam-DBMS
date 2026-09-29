namespace CuoiKy
{
    partial class FormBai10_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBai10_1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ssl_Trangthai = new System.Windows.Forms.ToolStripStatusLabel();
            this.tab = new System.Windows.Forms.TabControl();
            this.tab_Ketnoi = new System.Windows.Forms.TabPage();
            this.tab_a = new System.Windows.Forms.TabPage();
            this.tab_b = new System.Windows.Forms.TabPage();
            this.tab_c = new System.Windows.Forms.TabPage();
            this.btn_Ngat = new System.Windows.Forms.Button();
            this.btn_Ketnoi = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Thongkea = new System.Windows.Forms.Button();
            this.dgv_a = new System.Windows.Forms.DataGridView();
            this.dgv_b = new System.Windows.Forms.DataGridView();
            this.btn_Thongkeb = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_c = new System.Windows.Forms.DataGridView();
            this.btn_Thongkec = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.tab.SuspendLayout();
            this.tab_Ketnoi.SuspendLayout();
            this.tab_a.SuspendLayout();
            this.tab_b.SuspendLayout();
            this.tab_c.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_a)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_b)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_c)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssl_Trangthai});
            this.statusStrip1.Location = new System.Drawing.Point(0, 410);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(805, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ssl_Trangthai
            // 
            this.ssl_Trangthai.ForeColor = System.Drawing.Color.Red;
            this.ssl_Trangthai.Name = "ssl_Trangthai";
            this.ssl_Trangthai.Size = new System.Drawing.Size(92, 20);
            this.ssl_Trangthai.Text = "Chưa kết nối";
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tab_Ketnoi);
            this.tab.Controls.Add(this.tab_a);
            this.tab.Controls.Add(this.tab_b);
            this.tab.Controls.Add(this.tab_c);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(805, 410);
            this.tab.TabIndex = 5;
            // 
            // tab_Ketnoi
            // 
            this.tab_Ketnoi.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tab_Ketnoi.Controls.Add(this.label1);
            this.tab_Ketnoi.Controls.Add(this.panel6);
            this.tab_Ketnoi.Controls.Add(this.btn_Ngat);
            this.tab_Ketnoi.Controls.Add(this.btn_Ketnoi);
            this.tab_Ketnoi.Location = new System.Drawing.Point(4, 25);
            this.tab_Ketnoi.Name = "tab_Ketnoi";
            this.tab_Ketnoi.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Ketnoi.Size = new System.Drawing.Size(797, 381);
            this.tab_Ketnoi.TabIndex = 0;
            this.tab_Ketnoi.Text = "Kết nối";
            // 
            // tab_a
            // 
            this.tab_a.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tab_a.Controls.Add(this.dgv_a);
            this.tab_a.Controls.Add(this.btn_Thongkea);
            this.tab_a.Controls.Add(this.label2);
            this.tab_a.Controls.Add(this.panel1);
            this.tab_a.Location = new System.Drawing.Point(4, 25);
            this.tab_a.Name = "tab_a";
            this.tab_a.Padding = new System.Windows.Forms.Padding(3);
            this.tab_a.Size = new System.Drawing.Size(797, 381);
            this.tab_a.TabIndex = 1;
            this.tab_a.Text = "Câu a";
            // 
            // tab_b
            // 
            this.tab_b.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tab_b.Controls.Add(this.dgv_b);
            this.tab_b.Controls.Add(this.btn_Thongkeb);
            this.tab_b.Controls.Add(this.label4);
            this.tab_b.Controls.Add(this.panel2);
            this.tab_b.Location = new System.Drawing.Point(4, 25);
            this.tab_b.Name = "tab_b";
            this.tab_b.Size = new System.Drawing.Size(797, 381);
            this.tab_b.TabIndex = 2;
            this.tab_b.Text = "Câu b";
            // 
            // tab_c
            // 
            this.tab_c.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tab_c.Controls.Add(this.dgv_c);
            this.tab_c.Controls.Add(this.btn_Thongkec);
            this.tab_c.Controls.Add(this.label6);
            this.tab_c.Controls.Add(this.panel3);
            this.tab_c.Location = new System.Drawing.Point(4, 25);
            this.tab_c.Name = "tab_c";
            this.tab_c.Size = new System.Drawing.Size(797, 381);
            this.tab_c.TabIndex = 3;
            this.tab_c.Text = "Câu c";
            // 
            // btn_Ngat
            // 
            this.btn_Ngat.BackColor = System.Drawing.Color.LightCoral;
            this.btn_Ngat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Ngat.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ngat.Location = new System.Drawing.Point(432, 251);
            this.btn_Ngat.Name = "btn_Ngat";
            this.btn_Ngat.Size = new System.Drawing.Size(94, 43);
            this.btn_Ngat.TabIndex = 6;
            this.btn_Ngat.Text = "Ngắt";
            this.btn_Ngat.UseVisualStyleBackColor = false;
            this.btn_Ngat.Click += new System.EventHandler(this.btn_Ngat_Click);
            // 
            // btn_Ketnoi
            // 
            this.btn_Ketnoi.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_Ketnoi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Ketnoi.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ketnoi.Location = new System.Drawing.Point(249, 251);
            this.btn_Ketnoi.Name = "btn_Ketnoi";
            this.btn_Ketnoi.Size = new System.Drawing.Size(94, 43);
            this.btn_Ketnoi.TabIndex = 5;
            this.btn_Ketnoi.Text = "Kết nối";
            this.btn_Ketnoi.UseVisualStyleBackColor = false;
            this.btn_Ketnoi.Click += new System.EventHandler(this.btn_Ketnoi_Click);
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label12);
            this.panel6.Location = new System.Drawing.Point(35, 65);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(725, 165);
            this.panel6.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(688, 136);
            this.label12.TabIndex = 0;
            this.label12.Text = resources.GetString("label12.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(318, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 34);
            this.label1.TabIndex = 8;
            this.label1.Text = "Bài 10.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(347, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 34);
            this.label2.TabIndex = 10;
            this.label2.Text = "10.1a";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(33, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 68);
            this.panel1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(688, 49);
            this.label3.TabIndex = 0;
            this.label3.Text = "Một giáo viên có thể được phân công gác thi nhiều buổi trong một học kỳ, với điều" +
    " kiện các buổi thi đó không liên quan đến môn học do giáo viên đó chủ nhiệm.";
            // 
            // btn_Thongkea
            // 
            this.btn_Thongkea.BackColor = System.Drawing.Color.LightCyan;
            this.btn_Thongkea.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Thongkea.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thongkea.Location = new System.Drawing.Point(624, 123);
            this.btn_Thongkea.Name = "btn_Thongkea";
            this.btn_Thongkea.Size = new System.Drawing.Size(114, 40);
            this.btn_Thongkea.TabIndex = 11;
            this.btn_Thongkea.Text = "Thống kê";
            this.btn_Thongkea.UseVisualStyleBackColor = false;
            this.btn_Thongkea.Click += new System.EventHandler(this.btn_Thongkea_Click);
            // 
            // dgv_a
            // 
            this.dgv_a.AllowUserToAddRows = false;
            this.dgv_a.AllowUserToDeleteRows = false;
            this.dgv_a.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_a.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_a.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_a.Location = new System.Drawing.Point(33, 169);
            this.dgv_a.Name = "dgv_a";
            this.dgv_a.RowHeadersWidth = 51;
            this.dgv_a.RowTemplate.Height = 24;
            this.dgv_a.Size = new System.Drawing.Size(725, 198);
            this.dgv_a.TabIndex = 12;
            // 
            // dgv_b
            // 
            this.dgv_b.AllowUserToAddRows = false;
            this.dgv_b.AllowUserToDeleteRows = false;
            this.dgv_b.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_b.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_b.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_b.Location = new System.Drawing.Point(36, 143);
            this.dgv_b.Name = "dgv_b";
            this.dgv_b.RowHeadersWidth = 51;
            this.dgv_b.RowTemplate.Height = 24;
            this.dgv_b.Size = new System.Drawing.Size(725, 225);
            this.dgv_b.TabIndex = 16;
            // 
            // btn_Thongkeb
            // 
            this.btn_Thongkeb.BackColor = System.Drawing.Color.LightCyan;
            this.btn_Thongkeb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Thongkeb.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thongkeb.Location = new System.Drawing.Point(623, 97);
            this.btn_Thongkeb.Name = "btn_Thongkeb";
            this.btn_Thongkeb.Size = new System.Drawing.Size(114, 40);
            this.btn_Thongkeb.TabIndex = 15;
            this.btn_Thongkeb.Text = "Thống kê";
            this.btn_Thongkeb.UseVisualStyleBackColor = false;
            this.btn_Thongkeb.Click += new System.EventHandler(this.btn_Thongkeb_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(350, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 34);
            this.label4.TabIndex = 14;
            this.label4.Text = "10.1b";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(36, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 41);
            this.panel2.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(160, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(393, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nếu số tiết học là 30 thì thời gian thi là 120 phút";
            // 
            // dgv_c
            // 
            this.dgv_c.AllowUserToAddRows = false;
            this.dgv_c.AllowUserToDeleteRows = false;
            this.dgv_c.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_c.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_c.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_c.Location = new System.Drawing.Point(36, 143);
            this.dgv_c.Name = "dgv_c";
            this.dgv_c.RowHeadersWidth = 51;
            this.dgv_c.RowTemplate.Height = 24;
            this.dgv_c.Size = new System.Drawing.Size(725, 225);
            this.dgv_c.TabIndex = 20;
            // 
            // btn_Thongkec
            // 
            this.btn_Thongkec.BackColor = System.Drawing.Color.LightCyan;
            this.btn_Thongkec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Thongkec.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thongkec.Location = new System.Drawing.Point(623, 97);
            this.btn_Thongkec.Name = "btn_Thongkec";
            this.btn_Thongkec.Size = new System.Drawing.Size(114, 40);
            this.btn_Thongkec.TabIndex = 19;
            this.btn_Thongkec.Text = "Thống kê";
            this.btn_Thongkec.UseVisualStyleBackColor = false;
            this.btn_Thongkec.Click += new System.EventHandler(this.btn_Thongkec_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(350, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 34);
            this.label6.TabIndex = 18;
            this.label6.Text = "10.1c";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(36, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(725, 41);
            this.panel3.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(129, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(494, 27);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nếu số tiết học là 45 tiết trở lên thì thời gian thi là 150 phút";
            // 
            // FormBai10_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 436);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormBai10_1";
            this.Text = "Bài 10.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBai10_1_FormClosing);
            this.Load += new System.EventHandler(this.FormBai10_1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tab.ResumeLayout(false);
            this.tab_Ketnoi.ResumeLayout(false);
            this.tab_Ketnoi.PerformLayout();
            this.tab_a.ResumeLayout(false);
            this.tab_a.PerformLayout();
            this.tab_b.ResumeLayout(false);
            this.tab_b.PerformLayout();
            this.tab_c.ResumeLayout(false);
            this.tab_c.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_a)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_b)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_c)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ssl_Trangthai;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tab_Ketnoi;
        private System.Windows.Forms.TabPage tab_a;
        private System.Windows.Forms.TabPage tab_b;
        private System.Windows.Forms.TabPage tab_c;
        private System.Windows.Forms.Button btn_Ngat;
        private System.Windows.Forms.Button btn_Ketnoi;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Thongkea;
        private System.Windows.Forms.DataGridView dgv_a;
        private System.Windows.Forms.DataGridView dgv_b;
        private System.Windows.Forms.Button btn_Thongkeb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_c;
        private System.Windows.Forms.Button btn_Thongkec;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
    }
}