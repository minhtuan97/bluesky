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
    public partial class NhapHinhChuNhat : Form
    {
        private float CDai, CRong;
        bool IsHinhChuNhat = true;
        public bool ISHINHCHUNHAT
        {
            get
            {
                return IsHinhChuNhat;
            }          
        }
        public float CDAI
        {
            get
            {
                return CDai;
            }
        }
        public float CRONG
        {
            get
            {
                return CRong;
            }
        }

        public NhapHinhChuNhat()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IsHinhChuNhat = true;
            try
            {
                CDai = float.Parse(txbCDai.Text);
                CRong = float.Parse(txbCRong.Text);
            }
            catch
            {
                IsHinhChuNhat = false;
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbCDai.ResetText();
                txbCRong.ResetText();
                return;
            }
            if (CDai <= 0 || CRong <= 0)
            {
                IsHinhChuNhat = false;
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbCDai.ResetText();
                txbCRong.ResetText();
                return;
            }
            Close();
        }

        private void txbCRong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK_Click(sender, e);
        }

        private void txbCDai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbCRong.Focus();
        }

        private void NhapHinhChuNhat_Load(object sender, EventArgs e)
        {
            IsHinhChuNhat = false;
            txbCDai.Select();
        }
    }
}
