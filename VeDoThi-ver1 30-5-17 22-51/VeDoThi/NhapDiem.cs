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
    public partial class NhapDiem : Form
    {
        private float X, Y;
        bool IsDiem = true;
        public float GetX
        {
            get
            {
                return X;
            }
        }
        public float GetY
        {
            get
            {
                return Y;
            }

        }
        public bool ISDIEM
        {
            get
            {
                return IsDiem;
            }
        }
        
        public NhapDiem()
        {
            InitializeComponent();
        }

        private void NhapDiem_Load(object sender, EventArgs e)
        {
            IsDiem = false;
            txtX.Focus();
        }

        private void txtX_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            txtY.Focus();
        }

        private void txtY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK_Click(sender, e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IsDiem = true;
            try
            {
                X = float.Parse(txtX.Text);
                Y = float.Parse(txtY.Text);
            }
            catch
            {
                IsDiem = false;
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtX.Clear();
                txtY.Clear();
                return;
            }
            Close();

        }
    }
}
