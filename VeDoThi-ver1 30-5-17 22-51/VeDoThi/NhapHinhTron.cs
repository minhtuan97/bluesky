using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeDoThi
{
    public partial class NhapHinhTron : Form
    {
        private bool IsHinhTron = true ;
        private float BanKinh;
        public bool ISHINHTRON
        {
            get
            {
                return IsHinhTron;
            }
        }
        public float BANKINH
        {
            get
            {
                return BanKinh;
            }
        }
        public NhapHinhTron()
        {
            InitializeComponent();
        }

        private void NhapHinhTron_Load(object sender, EventArgs e)
        {
            IsHinhTron = false;
            txtBanKinh.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsHinhTron = true;
            try
            {
                BanKinh = float.Parse(txtBanKinh.Text);
            }
            catch
            {
                IsHinhTron = false;
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBanKinh.Clear();
                return;
            }
            if (BanKinh <= 0)
            {
                IsHinhTron = false;
                MessageBox.Show("Bán kính không được âm !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBanKinh.Clear();
                return;
            }
            Close();
        }

        private void txtBanKinh_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode==Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
