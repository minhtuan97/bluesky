namespace VeDoThi
{
    partial class PhanHoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhanHoi));
            this.textBoxPhanHoi = new System.Windows.Forms.TextBox();
            this.comboBoxDanhGia = new System.Windows.Forms.ComboBox();
            this.labelDanhGia = new System.Windows.Forms.Label();
            this.btnGui = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.labelPhanHoi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPhanHoi
            // 
            this.textBoxPhanHoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPhanHoi.Location = new System.Drawing.Point(10, 24);
            this.textBoxPhanHoi.Multiline = true;
            this.textBoxPhanHoi.Name = "textBoxPhanHoi";
            this.textBoxPhanHoi.Size = new System.Drawing.Size(257, 100);
            this.textBoxPhanHoi.TabIndex = 18;
            // 
            // comboBoxDanhGia
            // 
            this.comboBoxDanhGia.BackColor = System.Drawing.Color.White;
            this.comboBoxDanhGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDanhGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.comboBoxDanhGia.FormattingEnabled = true;
            this.comboBoxDanhGia.Items.AddRange(new object[] {
            "Tệ",
            "Bình thường",
            "Khá",
            "Tốt",
            "Xuất sắc"});
            this.comboBoxDanhGia.Location = new System.Drawing.Point(146, 137);
            this.comboBoxDanhGia.Name = "comboBoxDanhGia";
            this.comboBoxDanhGia.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDanhGia.TabIndex = 17;
            // 
            // labelDanhGia
            // 
            this.labelDanhGia.AutoSize = true;
            this.labelDanhGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDanhGia.ForeColor = System.Drawing.Color.Magenta;
            this.labelDanhGia.Location = new System.Drawing.Point(12, 140);
            this.labelDanhGia.Name = "labelDanhGia";
            this.labelDanhGia.Size = new System.Drawing.Size(92, 13);
            this.labelDanhGia.TabIndex = 16;
            this.labelDanhGia.Text = "Đánh giá của bạn";
            // 
            // btnGui
            // 
            this.btnGui.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnGui.Location = new System.Drawing.Point(10, 171);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(75, 23);
            this.btnGui.TabIndex = 15;
            this.btnGui.Text = "Gửi";
            this.btnGui.UseVisualStyleBackColor = true;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.ForeColor = System.Drawing.Color.Red;
            this.btnThoat.Location = new System.Drawing.Point(192, 171);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // labelPhanHoi
            // 
            this.labelPhanHoi.AutoSize = true;
            this.labelPhanHoi.ForeColor = System.Drawing.Color.Magenta;
            this.labelPhanHoi.Location = new System.Drawing.Point(13, 4);
            this.labelPhanHoi.Name = "labelPhanHoi";
            this.labelPhanHoi.Size = new System.Drawing.Size(49, 13);
            this.labelPhanHoi.TabIndex = 13;
            this.labelPhanHoi.Text = "Phản hồi";
            // 
            // PhanHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(276, 206);
            this.Controls.Add(this.textBoxPhanHoi);
            this.Controls.Add(this.comboBoxDanhGia);
            this.Controls.Add(this.labelDanhGia);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.labelPhanHoi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PhanHoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PhanHoi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPhanHoi;
        private System.Windows.Forms.ComboBox comboBoxDanhGia;
        private System.Windows.Forms.Label labelDanhGia;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label labelPhanHoi;
    }
}