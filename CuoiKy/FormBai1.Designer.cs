namespace CuoiKy
{
    partial class FormBai1
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
            this.btn_Ketnoi = new System.Windows.Forms.Button();
            this.btn_Ngat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_Noidung = new System.Windows.Forms.Panel();
            this.txt_Ketqua = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_b = new System.Windows.Forms.TextBox();
            this.txt_a = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Giai = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnl_Noidung.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÀI 1: GIẢI PHƯƠNG TRÌNH BẬC 1";
            // 
            // btn_Ketnoi
            // 
            this.btn_Ketnoi.BackColor = System.Drawing.Color.LightGreen;
            this.btn_Ketnoi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Ketnoi.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ketnoi.Location = new System.Drawing.Point(428, 93);
            this.btn_Ketnoi.Name = "btn_Ketnoi";
            this.btn_Ketnoi.Size = new System.Drawing.Size(74, 35);
            this.btn_Ketnoi.TabIndex = 1;
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
            this.btn_Ngat.Location = new System.Drawing.Point(508, 93);
            this.btn_Ngat.Name = "btn_Ngat";
            this.btn_Ngat.Size = new System.Drawing.Size(74, 35);
            this.btn_Ngat.TabIndex = 2;
            this.btn_Ngat.Text = "Ngắt";
            this.btn_Ngat.UseVisualStyleBackColor = false;
            this.btn_Ngat.Click += new System.EventHandler(this.btn_Ngat_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(24, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 47);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(545, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Stored-procedure giải phương trình bậc 1, ax + b = 0 với a, b bất kỳ";
            // 
            // pnl_Noidung
            // 
            this.pnl_Noidung.BackColor = System.Drawing.Color.Gainsboro;
            this.pnl_Noidung.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Noidung.Controls.Add(this.txt_Ketqua);
            this.pnl_Noidung.Controls.Add(this.label5);
            this.pnl_Noidung.Controls.Add(this.txt_b);
            this.pnl_Noidung.Controls.Add(this.txt_a);
            this.pnl_Noidung.Controls.Add(this.label4);
            this.pnl_Noidung.Controls.Add(this.label3);
            this.pnl_Noidung.Enabled = false;
            this.pnl_Noidung.Location = new System.Drawing.Point(38, 134);
            this.pnl_Noidung.Name = "pnl_Noidung";
            this.pnl_Noidung.Size = new System.Drawing.Size(558, 141);
            this.pnl_Noidung.TabIndex = 4;
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
            // txt_b
            // 
            this.txt_b.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_b.Location = new System.Drawing.Point(372, 10);
            this.txt_b.Name = "txt_b";
            this.txt_b.Size = new System.Drawing.Size(125, 32);
            this.txt_b.TabIndex = 3;
            // 
            // txt_a
            // 
            this.txt_a.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_a.Location = new System.Drawing.Point(107, 10);
            this.txt_a.Name = "txt_a";
            this.txt_a.Size = new System.Drawing.Size(125, 32);
            this.txt_a.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(279, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "Hệ số b:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hệ số a:";
            // 
            // btn_Giai
            // 
            this.btn_Giai.BackColor = System.Drawing.Color.Silver;
            this.btn_Giai.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Giai.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Giai.Location = new System.Drawing.Point(508, 283);
            this.btn_Giai.Name = "btn_Giai";
            this.btn_Giai.Size = new System.Drawing.Size(74, 35);
            this.btn_Giai.TabIndex = 5;
            this.btn_Giai.Text = "Giải";
            this.btn_Giai.UseVisualStyleBackColor = false;
            this.btn_Giai.Click += new System.EventHandler(this.btn_Giai_Click);
            // 
            // FormBai1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 330);
            this.Controls.Add(this.btn_Giai);
            this.Controls.Add(this.pnl_Noidung);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Ketnoi);
            this.Controls.Add(this.btn_Ngat);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormBai1";
            this.Text = "Bài 1";
            this.Load += new System.EventHandler(this.FormBai1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_Noidung.ResumeLayout(false);
            this.pnl_Noidung.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Ketnoi;
        private System.Windows.Forms.Button btn_Ngat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_Noidung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_a;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_b;
        private System.Windows.Forms.TextBox txt_Ketqua;
        private System.Windows.Forms.Button btn_Giai;
    }
}