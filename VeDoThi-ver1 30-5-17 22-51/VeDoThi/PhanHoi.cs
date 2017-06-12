using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace VeDoThi
{
    public partial class PhanHoi : Form
    {
        public PhanHoi()
        {
            InitializeComponent();
        }

        private void PhanHoi_Load(object sender, EventArgs e)
        {
            textBoxPhanHoi.Select();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (textBoxPhanHoi.Text.ToString().CompareTo("") != 0 || comboBoxDanhGia.SelectedItem != null)
            {
                btnThoat.Enabled = false;
                btnGui.Enabled = false;
                comboBoxDanhGia.Enabled = false;
                textBoxPhanHoi.Enabled = false;
                string body;
                body = DateTime.Now.ToString() + "\n\n";
                if (textBoxPhanHoi.Text.ToString().CompareTo("") != 0)
                body += textBoxPhanHoi.Text.ToString() + "\n\n";
                if (comboBoxDanhGia.SelectedItem != null)
                body += comboBoxDanhGia.SelectedItem.ToString();

                var fromAddress = "samlanh97@gmail.com";
                var toAddress = "samlanh97@gmail.com";
                const string fromPassword = "Ilovevn97";

                string subject = "FeedBack!";

                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    //smtp.Timeout = 60;
                }
                try
                {
                    smtp.Send(fromAddress, toAddress, subject, body);
                }
                catch
                {
                    MessageBox.Show("Cần có kết nối Internet để gửi phản hồi","Chú ý",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    Close();
                }
                btnThoat.Enabled = true;
                btnGui.Enabled = true;
                comboBoxDanhGia.Enabled = true;
                textBoxPhanHoi.Enabled = true;
            }
            Close();
        }
    }
}
