namespace VeDoThi
{
    partial class NhapDiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhapDiem));
            this.labelNhapDiem = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtY = new System.Windows.Forms.TextBox();
            this.labelToaDoY = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.labelToaDoX = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNhapDiem
            // 
            this.labelNhapDiem.AutoSize = true;
            this.labelNhapDiem.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelNhapDiem.Location = new System.Drawing.Point(48, 9);
            this.labelNhapDiem.Name = "labelNhapDiem";
            this.labelNhapDiem.Size = new System.Drawing.Size(114, 13);
            this.labelNhapDiem.TabIndex = 11;
            this.labelNhapDiem.Text = "Nhập vào tọa độ điểm";
            // 
            // btnOK
            // 
            this.btnOK.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnOK.Location = new System.Drawing.Point(85, 90);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtY
            // 
            this.txtY.ForeColor = System.Drawing.Color.OrangeRed;
            this.txtY.Location = new System.Drawing.Point(86, 63);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(100, 20);
            this.txtY.TabIndex = 9;
            this.txtY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtY_KeyDown);
            // 
            // labelToaDoY
            // 
            this.labelToaDoY.AutoSize = true;
            this.labelToaDoY.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelToaDoY.Location = new System.Drawing.Point(12, 66);
            this.labelToaDoY.Name = "labelToaDoY";
            this.labelToaDoY.Size = new System.Drawing.Size(58, 13);
            this.labelToaDoY.TabIndex = 8;
            this.labelToaDoY.Text = "Tọa độ Y :";
            // 
            // txtX
            // 
            this.txtX.ForeColor = System.Drawing.Color.OrangeRed;
            this.txtX.Location = new System.Drawing.Point(85, 37);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 20);
            this.txtX.TabIndex = 7;
            this.txtX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtX_KeyDown);
            // 
            // labelToaDoX
            // 
            this.labelToaDoX.AutoSize = true;
            this.labelToaDoX.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelToaDoX.Location = new System.Drawing.Point(11, 40);
            this.labelToaDoX.Name = "labelToaDoX";
            this.labelToaDoX.Size = new System.Drawing.Size(58, 13);
            this.labelToaDoX.TabIndex = 6;
            this.labelToaDoX.Text = "Tọa độ X :";
            // 
            // NhapDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(210, 127);
            this.Controls.Add(this.labelNhapDiem);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.labelToaDoY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.labelToaDoX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NhapDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.NhapDiem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNhapDiem;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label labelToaDoY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label labelToaDoX;
    }
}