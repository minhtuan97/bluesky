namespace VeDoThi
{
    partial class NhapHinhChuNhat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhapHinhChuNhat));
            this.txbCRong = new System.Windows.Forms.TextBox();
            this.txbCDai = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.labelChieuRong = new System.Windows.Forms.Label();
            this.labelChieuDai = new System.Windows.Forms.Label();
            this.labelNhapHCN = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbCRong
            // 
            this.txbCRong.Location = new System.Drawing.Point(102, 66);
            this.txbCRong.Name = "txbCRong";
            this.txbCRong.Size = new System.Drawing.Size(100, 20);
            this.txbCRong.TabIndex = 14;
            this.txbCRong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbCRong_KeyDown);
            // 
            // txbCDai
            // 
            this.txbCDai.Location = new System.Drawing.Point(102, 34);
            this.txbCDai.Name = "txbCDai";
            this.txbCDai.Size = new System.Drawing.Size(100, 20);
            this.txbCDai.TabIndex = 13;
            this.txbCDai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbCDai_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.ForeColor = System.Drawing.Color.Gold;
            this.btnOK.Location = new System.Drawing.Point(102, 98);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelChieuRong
            // 
            this.labelChieuRong.AutoSize = true;
            this.labelChieuRong.ForeColor = System.Drawing.Color.Gold;
            this.labelChieuRong.Location = new System.Drawing.Point(15, 69);
            this.labelChieuRong.Name = "labelChieuRong";
            this.labelChieuRong.Size = new System.Drawing.Size(58, 13);
            this.labelChieuRong.TabIndex = 11;
            this.labelChieuRong.Text = "Chiều rộng";
            // 
            // labelChieuDai
            // 
            this.labelChieuDai.AutoSize = true;
            this.labelChieuDai.ForeColor = System.Drawing.Color.Gold;
            this.labelChieuDai.Location = new System.Drawing.Point(15, 37);
            this.labelChieuDai.Name = "labelChieuDai";
            this.labelChieuDai.Size = new System.Drawing.Size(51, 13);
            this.labelChieuDai.TabIndex = 10;
            this.labelChieuDai.Text = "Chiều dài";
            // 
            // labelNhapHCN
            // 
            this.labelNhapHCN.AutoSize = true;
            this.labelNhapHCN.ForeColor = System.Drawing.Color.Gold;
            this.labelNhapHCN.Location = new System.Drawing.Point(15, 9);
            this.labelNhapHCN.Name = "labelNhapHCN";
            this.labelNhapHCN.Size = new System.Drawing.Size(205, 13);
            this.labelNhapHCN.TabIndex = 10;
            this.labelNhapHCN.Text = "Nhập chiều dài, chiều rộng Hình chữ nhật";
            // 
            // NhapHinhChuNhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(230, 133);
            this.Controls.Add(this.txbCRong);
            this.Controls.Add(this.txbCDai);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelChieuRong);
            this.Controls.Add(this.labelNhapHCN);
            this.Controls.Add(this.labelChieuDai);
            this.ForeColor = System.Drawing.Color.Gold;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NhapHinhChuNhat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.NhapHinhChuNhat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbCRong;
        private System.Windows.Forms.TextBox txbCDai;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label labelChieuRong;
        private System.Windows.Forms.Label labelChieuDai;
        private System.Windows.Forms.Label labelNhapHCN;
    }
}