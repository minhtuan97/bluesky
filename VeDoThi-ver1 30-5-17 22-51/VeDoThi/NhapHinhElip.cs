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
    public partial class NhapHinhElip : Form
    {
        private bool IsHinhElip = true;
        private float ex, ey;
        public bool ISHINHELIP
        {
            get
            {
                return IsHinhElip;
            }
        }
        public float EX
        {
            get
            {
                return ex;
            }
        }

        public float EY
        {
            get
            {
                return ey;
            }
        }
        public NhapHinhElip()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IsHinhElip = true;
            try
            {
                ex = float.Parse(txtBanTrucX.Text);
                ey = float.Parse(txtBanTrucY.Text);
            }
            catch
            {
                IsHinhElip = false;
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBanTrucX.Clear();
                txtBanTrucY.Clear();
                return;
            }
            if (ex <= 0 || ey <= 0)
            {
                IsHinhElip = false;
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBanTrucX.Clear();
                txtBanTrucY.Clear();
                return;
            }
            Close();
        }

        private void txtBanTrucX_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            txtBanTrucY.Focus();
        }

        private void txtBanTrucY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK_Click(sender, e);
        }

        private void NhapHinhElip_Load(object sender, EventArgs e)
        {
            IsHinhElip = false;
            txtBanTrucX.Select();
        }
    }
}
