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
    public partial class NhapHinhVuong : Form
    {
        private float DaiCanh;
        private bool IsHinhVuong = true;
        public float DAICANH
        {
            get
            { 
                return DaiCanh;
            }
        }

        public bool ISHINHVUONG
        {
            get
            { 
                return IsHinhVuong;
            }
        }
        public NhapHinhVuong()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IsHinhVuong = true;
            try
            {
                DaiCanh = float.Parse(txtDaiCanh.Text);
            }
            catch
            {
                IsHinhVuong = false;
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDaiCanh.Clear();
                return;
            }
          
                if (DaiCanh > 0)
                {
                    Close();
                }
                else
                {
                    IsHinhVuong = false;
                    MessageBox.Show("Độ dài cạnh không được âm !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDaiCanh.Clear();
                    return;
                }
          }
        private void NhapHinhVuong_Load(object sender, EventArgs e)
        {
            IsHinhVuong = false;
        }

        private void txtDaiCanh_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}
