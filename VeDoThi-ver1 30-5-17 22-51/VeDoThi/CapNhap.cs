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
using System.IO;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.IO.Compression;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace VeDoThi
{
    public partial class CapNhap : Form
    {

        private bool isupdate = false;
        public bool ISCAPNHAP
        {
            get
            {
                return isupdate;
            }
        }
        string nguon         = @"C:\\Update";
        string update_txt    = @"C:\\Update\update.txt";
        string current_txt   = @"C:\\Update\current.txt"; 
        string path_now      = @"C:\\Update\LinkApp.txt";
        string update_zip    = @"C:\\Update\Update.zip";
        string update_path   = @"C:\\Update";
        string update_exe    = @"C:\\Update\Update.exe";
        string VeDoThi_exe = @"C:\\Update\VeDoThi.exe";
        string updatetxtlink = "https://docs.google.com/uc?export=download&id=0Bzt9rmvQT9fmN2FVY25tU0x2Q0E";
        string updateziplink = "https://docs.google.com/uc?export=download&id=0Bzt9rmvQT9fmY1R0aHZmX1pJXzA";
        string VeDoThi_path = Application.StartupPath + @"\VeDoThi.exe";
        public CapNhap()
        {
            InitializeComponent();
        }

        // Load Form
        #region Load Form
        private void CapNhap_Load(object sender, EventArgs e)
        {
            for(int i=0;i<=2;i++)
            {
                IsConnectedToInternet();
            }
            btnUpdate.Enabled = false;
            labelStatus.Text = "Đang kiểm kết nối internet...";
            if (IsConnectedToInternet() == false)
            {
                labelStatus.Text = "Hiện không có kết nối internet vui lòng reset lại internet.";
                btnUpdate.Text = "Thoát";
                btnUpdate.Enabled = true;
            }
            else
            {
                labelStatus.Text = "Đang kiểm tra cập nhập...";
                // tạo thư mục nguồn
                if (Directory.Exists(nguon))
                {
                    if (File.Exists(current_txt))
                        File.Delete(current_txt);
                    if (File.Exists(update_txt))
                        File.Delete(update_txt);
                    if (File.Exists(path_now))
                        File.Delete(path_now);
                    if (File.Exists(update_zip))
                        File.Delete(update_zip);
                    if (File.Exists(VeDoThi_exe))
                        File.Delete(VeDoThi_exe);
                    if (File.Exists(update_exe))
                        File.Delete(update_exe);

                }
                else
                {
                    Directory.CreateDirectory(nguon);
                }
                // tạo mới ghi đè curent.txt để lưu số hiệu phiên bản hiện tại
                StreamWriter st = new StreamWriter(current_txt);
                st.WriteLine(labelVer1.Text);
                st.Close();

                // tải file Update.txt ghi số hiệu của phiên bản mới
                if (IsConnectedToInternet())
                {
                    WebClient ud = new WebClient();
                    Uri update = new Uri(updatetxtlink);
                    ud.DownloadFileAsync(update, update_txt);
                    ud.DownloadFileCompleted += new AsyncCompletedEventHandler(update_complete);
                }
                else
                {
                    labelStatus.Text = "Hiện không có kết nối internet.";
                    btnUpdate.Text = "Thoát";
                    btnUpdate.Enabled = true;
                }
            }
        }
        #endregion
        // Hàm kiểm tra kết nối mạng
        #region Hàm kiểm tra kết nối mạng
        private bool IsConnectedToInternet()
        {
            try
            {
                Ping myPing = new Ping();
                string host = "google.com.vn";
                byte[] buffer = new byte[32];
                int timeout = 100;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        // Tải file update.zip
        #region Tải file update.zip
        private void taiupdate()
        {
            labelStatus.Text = "Đang chuẩn bị cài đặt";
            // tải winrar.zip
            if (IsConnectedToInternet())
            {
                WebClient rar = new WebClient();
                Uri wr = new Uri(updateziplink);
                rar.DownloadFileAsync(wr, update_zip);
                rar.DownloadFileCompleted += new AsyncCompletedEventHandler(updatezip_complete);
            }
            else
            {
                labelStatus.Text = "Mất kết nối internet.";
                btnUpdate.Text = "Thoát";
                btnUpdate.Enabled = true;
            }
        }
        #endregion
        // Tải file update.zip hoàn tất
        #region Tải file update.zip hoàn tất
        private void updatezip_complete(object sender, AsyncCompletedEventArgs e)
        {
            labelStatus.Text = "Tải file cập nhập thành công";
            // xóa file tồn tại trước nếu có
            if (File.Exists(update_exe))
                File.Delete(update_exe);
            // giải nén Update.zip -> Update.exe và VeDoThi.exe
            ZipFile.ExtractToDirectory(update_zip, update_path);
            CaiDat();
        }
        #endregion
        // tải về hoàn tất file update.txt
        #region tải về hoàn tất file update.txt
        private void update_complete(object sender, AsyncCompletedEventArgs e)
        {
            StreamReader st = new StreamReader(update_txt);
            labelVer2.Text = st.ReadLine();
            st.Close();
            // kiểm tra có phiên bản mới không
            if (labelVer1.Text == labelVer2.Text)
            {
                //nếu bằng nhau thì không có bản cập nhật
                labelStatus.Text = "Hiện không có bản cập nhập mới.";
                btnUpdate.Text = "Thoát";
                btnUpdate.Enabled = true;
            }
            else
            {
                //thong báo có bản cập nhật và phiên bản mới
                labelStatus.Text = "Phiên bản cập nhật mới " + labelVer2.Text + " đang hiện có.";
                btnUpdate.Enabled = true;
            }
        }
        #endregion
        // Hàm cài đặt
        #region Hàm cài đặt
        private void CaiDat()
        {
            labelStatus.Text = "Đang tiến hành cài đặt bản cập nhập...";

            if (File.Exists(update_exe))
            {
                isupdate = true;
                Close();
                Process.Start(update_exe);
            }
            else
            {
                labelStatus.Text = "Cập nhập thất bại ...";
                btnUpdate.Text = "Thoát";
            }
        }
        #endregion
        // Bấm nút cập nhập
        #region Bấm nút cập nhập
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Thoát")
                Close();
            if (btnUpdate.Text == "Cập nhập")
            {
                // ghi đường dẫn của chương trình cũ
                btnUpdate.Enabled = false;
                StreamWriter st = new StreamWriter(path_now);
                st.WriteLine(VeDoThi_path);
                st.Close();
                taiupdate();
            }
        }
        #endregion
    }
}
