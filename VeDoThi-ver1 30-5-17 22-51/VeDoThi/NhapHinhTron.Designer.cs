namespace VeDoThi
{
    partial class NhapHinhTron
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhapHinhTron));
            this.labelNhapBanKinh = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelNhapHinhTron = new System.Windows.Forms.Label();
            this.txtBanKinh = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelNhapBanKinh
            // 
            this.labelNhapBanKinh.AutoSize = true;
            this.labelNhapBanKinh.ForeColor = System.Drawing.Color.DarkRed;
            this.labelNhapBanKinh.Location = new System.Drawing.Point(12, 38);
            this.labelNhapBanKinh.Name = "labelNhapBanKinh";
            this.labelNhapBanKinh.Size = new System.Drawing.Size(79, 13);
            this.labelNhapBanKinh.TabIndex = 4;
            this.labelNhapBanKinh.Text = "Nhập bán kính";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.DarkRed;
            this.button1.Location = new System.Drawing.Point(72, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelNhapHinhTron
            // 
            this.labelNhapHinhTron.AutoSize = true;
            this.labelNhapHinhTron.ForeColor = System.Drawing.Color.DarkRed;
            this.labelNhapHinhTron.Location = new System.Drawing.Point(38, 9);
            this.labelNhapHinhTron.Name = "labelNhapHinhTron";
            this.labelNhapHinhTron.Size = new System.Drawing.Size(144, 13);
            this.labelNhapHinhTron.TabIndex = 4;
            this.labelNhapHinhTron.Text = "Nhập bán kính của hình tròn";
            // 
            // txtBanKinh
            // 
            this.txtBanKinh.Location = new System.Drawing.Point(107, 35);
            this.txtBanKinh.Name = "txtBanKinh";
            this.txtBanKinh.Size = new System.Drawing.Size(100, 20);
            this.txtBanKinh.TabIndex = 5;
            this.txtBanKinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBanKinh_KeyDown);
            // 
            // NhapHinhTron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(231, 101);
            this.Controls.Add(this.txtBanKinh);
            this.Controls.Add(this.labelNhapHinhTron);
            this.Controls.Add(this.labelNhapBanKinh);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NhapHinhTron";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.NhapHinhTron_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelNhapBanKinh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelNhapHinhTron;
        private System.Windows.Forms.TextBox txtBanKinh;
    }
}