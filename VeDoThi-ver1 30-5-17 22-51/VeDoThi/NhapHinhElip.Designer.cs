namespace VeDoThi
{
    partial class NhapHinhElip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhapHinhElip));
            this.txtBanTrucY = new System.Windows.Forms.TextBox();
            this.txtBanTrucX = new System.Windows.Forms.TextBox();
            this.labelBanTrucY = new System.Windows.Forms.Label();
            this.labelBanTrucX = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.labelNhapHinhElip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBanTrucY
            // 
            this.txtBanTrucY.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtBanTrucY.Location = new System.Drawing.Point(90, 72);
            this.txtBanTrucY.Name = "txtBanTrucY";
            this.txtBanTrucY.Size = new System.Drawing.Size(100, 20);
            this.txtBanTrucY.TabIndex = 9;
            this.txtBanTrucY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBanTrucY_KeyDown);
            // 
            // txtBanTrucX
            // 
            this.txtBanTrucX.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtBanTrucX.Location = new System.Drawing.Point(90, 39);
            this.txtBanTrucX.Name = "txtBanTrucX";
            this.txtBanTrucX.Size = new System.Drawing.Size(100, 20);
            this.txtBanTrucX.TabIndex = 8;
            this.txtBanTrucX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBanTrucX_KeyDown);
            // 
            // labelBanTrucY
            // 
            this.labelBanTrucY.AutoSize = true;
            this.labelBanTrucY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelBanTrucY.Location = new System.Drawing.Point(12, 72);
            this.labelBanTrucY.Name = "labelBanTrucY";
            this.labelBanTrucY.Size = new System.Drawing.Size(61, 13);
            this.labelBanTrucY.TabIndex = 7;
            this.labelBanTrucY.Text = "Bán Trục Y";
            // 
            // labelBanTrucX
            // 
            this.labelBanTrucX.AutoSize = true;
            this.labelBanTrucX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelBanTrucX.Location = new System.Drawing.Point(12, 42);
            this.labelBanTrucX.Name = "labelBanTrucX";
            this.labelBanTrucX.Size = new System.Drawing.Size(61, 13);
            this.labelBanTrucX.TabIndex = 6;
            this.labelBanTrucX.Text = "Bán Trục X";
            // 
            // btnOK
            // 
            this.btnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOK.Location = new System.Drawing.Point(90, 106);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelNhapHinhElip
            // 
            this.labelNhapHinhElip.AutoSize = true;
            this.labelNhapHinhElip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelNhapHinhElip.Location = new System.Drawing.Point(29, 11);
            this.labelNhapHinhElip.Name = "labelNhapHinhElip";
            this.labelNhapHinhElip.Size = new System.Drawing.Size(139, 13);
            this.labelNhapHinhElip.TabIndex = 6;
            this.labelNhapHinhElip.Text = "Nhập bán trục X, Y của Elip";
            // 
            // NhapHinhElip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(212, 141);
            this.Controls.Add(this.txtBanTrucY);
            this.Controls.Add(this.txtBanTrucX);
            this.Controls.Add(this.labelBanTrucY);
            this.Controls.Add(this.labelNhapHinhElip);
            this.Controls.Add(this.labelBanTrucX);
            this.Controls.Add(this.btnOK);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NhapHinhElip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.NhapHinhElip_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBanTrucY;
        private System.Windows.Forms.TextBox txtBanTrucX;
        private System.Windows.Forms.Label labelBanTrucY;
        private System.Windows.Forms.Label labelBanTrucX;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label labelNhapHinhElip;
    }
}