namespace CuoiKy
{
    partial class FormBai10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBai10));
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.grb_bai = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_101 = new System.Windows.Forms.Button();
            this.panel6.SuspendLayout();
            this.grb_bai.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(374, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bài 10";
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.BackColor = System.Drawing.SystemColors.Window;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label12);
            this.panel6.Location = new System.Drawing.Point(29, 46);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(782, 365);
            this.panel6.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(749, 337);
            this.label12.TabIndex = 0;
            this.label12.Text = resources.GetString("label12.Text");
            // 
            // grb_bai
            // 
            this.grb_bai.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grb_bai.Controls.Add(this.button2);
            this.grb_bai.Controls.Add(this.btn_101);
            this.grb_bai.Font = new System.Drawing.Font("Times New Roman", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_bai.Location = new System.Drawing.Point(267, 417);
            this.grb_bai.Name = "grb_bai";
            this.grb_bai.Size = new System.Drawing.Size(309, 85);
            this.grb_bai.TabIndex = 9;
            this.grb_bai.TabStop = false;
            this.grb_bai.Text = "Bài con";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PaleGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(164, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 43);
            this.button2.TabIndex = 11;
            this.button2.Text = "10.2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_101
            // 
            this.btn_101.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_101.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_101.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_101.Location = new System.Drawing.Point(47, 26);
            this.btn_101.Name = "btn_101";
            this.btn_101.Size = new System.Drawing.Size(94, 43);
            this.btn_101.TabIndex = 10;
            this.btn_101.Text = "10.1";
            this.btn_101.UseVisualStyleBackColor = false;
            this.btn_101.Click += new System.EventHandler(this.btn_101_Click);
            // 
            // FormBai10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(837, 514);
            this.Controls.Add(this.grb_bai);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label1);
            this.Name = "FormBai10";
            this.Text = "Bài 10";
            this.Load += new System.EventHandler(this.FormBai10_Load);
            this.panel6.ResumeLayout(false);
            this.grb_bai.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox grb_bai;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_101;
    }
}