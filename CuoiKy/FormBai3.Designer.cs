namespace CuoiKy
{
    partial class FormBai3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBai3));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Ngat = new System.Windows.Forms.Button();
            this.btn_Ketnoi = new System.Windows.Forms.Button();
            this.btn_Hienthi = new System.Windows.Forms.Button();
            this.quanLyThuVienDataSet = new CuoiKy.QuanLyThuVienDataSet();
            this.spThongtinDausachBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ThongtinDausachTableAdapter = new CuoiKy.QuanLyThuVienDataSetTableAdapters.sp_ThongtinDausachTableAdapter();
            this.dgv_DauSach = new System.Windows.Forms.DataGridView();
            this.txt_isbn = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ssl_Trangthai = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyThuVienDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spThongtinDausachBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DauSach)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "BÀI 3: THÔNG TIN ĐẦU SÁCH\r\n";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(26, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 131);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(728, 119);
            this.label2.TabIndex = 0;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // btn_Ngat
            // 
            this.btn_Ngat.BackColor = System.Drawing.Color.LightCoral;
            this.btn_Ngat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Ngat.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ngat.ForeColor = System.Drawing.Color.Black;
            this.btn_Ngat.Location = new System.Drawing.Point(688, 177);
            this.btn_Ngat.Name = "btn_Ngat";
            this.btn_Ngat.Size = new System.Drawing.Size(74, 35);
            this.btn_Ngat.TabIndex = 8;
            this.btn_Ngat.Text = "Ngắt";
            this.btn_Ngat.UseVisualStyleBackColor = false;
            this.btn_Ngat.Click += new System.EventHandler(this.btn_Ngat_Click);
            // 
            // btn_Ketnoi
            // 
            this.btn_Ketnoi.BackColor = System.Drawing.Color.LightGreen;
            this.btn_Ketnoi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Ketnoi.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ketnoi.Location = new System.Drawing.Point(608, 177);
            this.btn_Ketnoi.Name = "btn_Ketnoi";
            this.btn_Ketnoi.Size = new System.Drawing.Size(74, 35);
            this.btn_Ketnoi.TabIndex = 7;
            this.btn_Ketnoi.Text = "Kết nối";
            this.btn_Ketnoi.UseVisualStyleBackColor = false;
            this.btn_Ketnoi.Click += new System.EventHandler(this.btn_Ketnoi_Click);
            // 
            // btn_Hienthi
            // 
            this.btn_Hienthi.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_Hienthi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Hienthi.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Hienthi.Location = new System.Drawing.Point(468, 177);
            this.btn_Hienthi.Name = "btn_Hienthi";
            this.btn_Hienthi.Size = new System.Drawing.Size(74, 35);
            this.btn_Hienthi.TabIndex = 9;
            this.btn_Hienthi.Text = "Hiển thị";
            this.btn_Hienthi.UseVisualStyleBackColor = false;
            this.btn_Hienthi.Click += new System.EventHandler(this.btn_Hienthi_Click);
            // 
            // quanLyThuVienDataSet
            // 
            this.quanLyThuVienDataSet.DataSetName = "QuanLyThuVienDataSet";
            this.quanLyThuVienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spThongtinDausachBindingSource
            // 
            this.spThongtinDausachBindingSource.DataMember = "sp_ThongtinDausach";
            this.spThongtinDausachBindingSource.DataSource = this.quanLyThuVienDataSet;
            // 
            // sp_ThongtinDausachTableAdapter
            // 
            this.sp_ThongtinDausachTableAdapter.ClearBeforeFill = true;
            // 
            // dgv_DauSach
            // 
            this.dgv_DauSach.AllowUserToAddRows = false;
            this.dgv_DauSach.AllowUserToDeleteRows = false;
            this.dgv_DauSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_DauSach.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_DauSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DauSach.Location = new System.Drawing.Point(26, 218);
            this.dgv_DauSach.Name = "dgv_DauSach";
            this.dgv_DauSach.RowHeadersWidth = 51;
            this.dgv_DauSach.RowTemplate.Height = 24;
            this.dgv_DauSach.Size = new System.Drawing.Size(762, 229);
            this.dgv_DauSach.TabIndex = 0;
            // 
            // txt_isbn
            // 
            this.txt_isbn.BackColor = System.Drawing.SystemColors.Window;
            this.txt_isbn.Enabled = false;
            this.txt_isbn.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_isbn.Location = new System.Drawing.Point(161, 181);
            this.txt_isbn.Name = "txt_isbn";
            this.txt_isbn.Size = new System.Drawing.Size(100, 27);
            this.txt_isbn.TabIndex = 10;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssl_Trangthai});
            this.statusStrip1.Location = new System.Drawing.Point(0, 452);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(813, 26);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ssl_Trangthai
            // 
            this.ssl_Trangthai.Name = "ssl_Trangthai";
            this.ssl_Trangthai.Size = new System.Drawing.Size(92, 20);
            this.ssl_Trangthai.Text = "Chưa kết nối";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nhập ISBN:";
            // 
            // FormBai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 478);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txt_isbn);
            this.Controls.Add(this.dgv_DauSach);
            this.Controls.Add(this.btn_Hienthi);
            this.Controls.Add(this.btn_Ngat);
            this.Controls.Add(this.btn_Ketnoi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FormBai3";
            this.Text = "Bài 3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBai3_FormClosing);
            this.Load += new System.EventHandler(this.FormBai3_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.quanLyThuVienDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spThongtinDausachBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DauSach)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource spThongtinDausachBindingSource;
        private QuanLyThuVienDataSet quanLyThuVienDataSet;
        private System.Windows.Forms.Button btn_Ngat;
        private System.Windows.Forms.Button btn_Ketnoi;
        private System.Windows.Forms.Button btn_Hienthi;
        private QuanLyThuVienDataSetTableAdapters.sp_ThongtinDausachTableAdapter sp_ThongtinDausachTableAdapter;
        private System.Windows.Forms.DataGridView dgv_DauSach;
        private System.Windows.Forms.TextBox txt_isbn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ssl_Trangthai;
        private System.Windows.Forms.Label label3;
    }
}