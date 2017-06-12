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
    public partial class NhapHinhTamGiac : Form
    {
        private float Ax, Ay, Bx, By, Cx, Cy;
        private bool IsHinhTamGiac = true;
        
        public float AX
        {
            get
            {
                return Ax;
            }
        }
        public float AY
        {
            get
            {
                return Ay;
            }
        }
        public float BX
        {
            get
            {
                return Bx;
            }
        }
        public float BY
        {
            get
            {
                return By;
            }
        }
        public float CX
        {
            get
            {
                return Cx;
            }
        }

    

        public float CY
        {
            get
            {
                return Cy;
            }
        }



        public bool ISHINHTAMGIAC
        {
            get
            { 
                return IsHinhTamGiac;
            }
        }

  

        public NhapHinhTamGiac()
        {
            InitializeComponent();
        }

 

        private void NhapHinhTamGiac_Load(object sender, EventArgs e)
        {
            IsHinhTamGiac = false;
            txbAx.Select();
        }

  

        private void btnOK_Click(object sender, EventArgs e)
        {
            IsHinhTamGiac = true;
            try
            {
                Ax = float.Parse(txbAx.Text);
                Ay = float.Parse(txbAy.Text);
                Bx = float.Parse(txtBx.Text);
                By = float.Parse(txtBy.Text);
                Cx = float.Parse(txtCx.Text);
                Cy = float.Parse(txtCy.Text);
                if ((Bx - Ax) * (Cy - Ay) == (Cx - Ay) * (By - Ay))
                {
                    MessageBox.Show("Ba điểm không tạo thành tam giác", "Loi");
                    IsHinhTamGiac = false;
                    txbAx.Clear();
                    txbAy.Clear();
                    txtBx.Clear();
                    txtBy.Clear();
                    txtCx.Clear();
                    txtCy.Clear();
                    return;
                }
                else
                {
                    IsHinhTamGiac = true;
                }
            }
            catch
            {
                IsHinhTamGiac = false;
                MessageBox.Show("Dữ liệu nhập không hợp lệ ");
                txbAx.Clear();
                txbAy.Clear();
                txtBx.Clear();
                txtBy.Clear();
                txtCx.Clear();
                txtCy.Clear();
                return;
            }
            Close();
        }



        private void txbAx_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            txbAy.Focus();
        }
        private void txbAy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBx.Focus();
        }
        private void txtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBy.Focus();
        }

        private void txtBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCx.Focus();
        }

        private void txtCx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCy.Focus();
        }

        private void txtCy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK_Click(sender, e);
        }

    }
}
