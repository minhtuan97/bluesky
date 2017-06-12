namespace VeDoThi
{
    partial class NhapHinhVuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhapHinhVuong));
            this.btnOK = new System.Windows.Forms.Button();
            this.labelDaiCanh = new System.Windows.Forms.Label();
            this.txtDaiCanh = new System.Windows.Forms.TextBox();
            this.labelNhapHinhVuong = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.ForeColor = System.Drawing.Color.Crimson;
            this.btnOK.Location = new System.Drawing.Point(104, 70);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelDaiCanh
            // 
            this.labelDaiCanh.AutoSize = true;
            this.labelDaiCanh.ForeColor = System.Drawing.Color.Crimson;
            this.labelDaiCanh.Location = new System.Drawing.Point(12, 45);
            this.labelDaiCanh.Name = "labelDaiCanh";
            this.labelDaiCanh.Size = new System.Drawing.Size(65, 13);
            this.labelDaiCanh.TabIndex = 4;
            this.labelDaiCanh.Text = "Độ dài cạnh";
            // 
            // txtDaiCanh
            // 
            this.txtDaiCanh.ForeColor = System.Drawing.Color.Crimson;
            this.txtDaiCanh.Location = new System.Drawing.Point(104, 42);
            this.txtDaiCanh.Name = "txtDaiCanh";
            this.txtDaiCanh.Size = new System.Drawing.Size(100, 20);
            this.txtDaiCanh.TabIndex = 3;
            this.txtDaiCanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDaiCanh_KeyDown);
            // 
            // labelNhapHinhVuong
            // 
            this.labelNhapHinhVuong.AutoSize = true;
            this.labelNhapHinhVuong.ForeColor = System.Drawing.Color.Crimson;
            this.labelNhapHinhVuong.Location = new System.Drawing.Point(22, 9);
            this.labelNhapHinhVuong.Name = "labelNhapHinhVuong";
            this.labelNhapHinhVuong.Size = new System.Drawing.Size(170, 13);
            this.labelNhapHinhVuong.TabIndex = 4;
            this.labelNhapHinhVuong.Text = "Nhập độ dài cạnh của hình vuông";
            // 
            // NhapHinhVuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(221, 105);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelNhapHinhVuong);
            this.Controls.Add(this.labelDaiCanh);
            this.Controls.Add(this.txtDaiCanh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NhapHinhVuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.NhapHinhVuong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label labelDaiCanh;
        private System.Windows.Forms.TextBox txtDaiCanh;
        private System.Windows.Forms.Label labelNhapHinhVuong;
    }
}