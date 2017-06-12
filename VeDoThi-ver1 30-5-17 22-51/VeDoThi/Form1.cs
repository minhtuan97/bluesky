using System;
using System.Collections;
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
    public partial class VeDoThi : Form
    {
        public VeDoThi()
        {
            InitializeComponent();
        }

        // Biến 
        #region Biến
        float CD, CR, DC, EX, EY, R, AX, AY, BX, BY, CX, CY;
        bool ishvuong = false;
        bool ishinhtron = false;
        bool ishinhelip = false;
        bool ishcn = false;

        private bool VeOLuoi = false; //biến kiểm tra có vẽ khung lưới không
        public int sodiem = 0;// lưu các điểm đã vẽ
        public float tdX, tdY; //tọa độ thực trên oxy ,phụ thuộc k
        int max_x, max_y; // số pixel chiều dài rộng của khung vẽ picpaint
        Graphics g, g1;//biến đồ thị để hiện thị (g), và lưu bitmap(g1);
        Bitmap bitmap = new Bitmap(880, 661);// tạo ảnh bitmap có số pixel
        HamTinh fn = new HamTinh();//biến sử lý tính hàm số;
        ArrayList arr;// mảng lưu biểu thức lúc sử lý hàm số
        List<DoiTuongHamSo> listpainted = new List<DoiTuongHamSo>(); //mảng lưu danh sách các đồ thị đã vẽ
        List<DiemHinh> listDiemHinh = new List<DiemHinh>();      //mảng lưu danh sách các điểm hình học đã vẽ

        bool stop = false;//biến dừng nếu tính f(x) từ biểu thức bị sai.
        double x, dx, fx1, fx2;// các biến để vẽ đồ thị hàm số
        int x1, y1, x2, y2;// các biến để vẽ các đường thẳng nhỏ để nối thành đồ thị hàm số (pixel) 
        int max, min;//biến lưu giá trị giới hạn trục số thực trong khung vẽ
        int x0, y0;// biến lưu vị trí xo,yo của gốc tọa độ (pixel)
        int k = 30;// độ thu phóng từ tọa độ pixel sang tọa độ thực 60 pixel = 1 thực 
        int m_x, m_y;// lưu vị trí chuột khi click chuột
        bool repaint = false; //Kiểm tra vẽ lại
        public Font font = new Font("Tahoma", 10);// định dạng phông chữ trục số
        Pen pen_0 = new Pen(Brushes.Green,2);// Bút để vẽ đồ thị
        Pen pen_1 = new Pen(Color.Gray);// Bút vẽ lưới
        #endregion
        // * Load Form chính
        #region Load Form chính
        private void VeDoThi_Load(object sender, EventArgs e)
        {
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true) ;
            pen_1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            panelLeft.Enabled = false;
            panelRight.Enabled = false;
            g = PicPaint.CreateGraphics();
            g1 = Graphics.FromImage(bitmap);
            g1.Clear(Color.White);
            label_TiLe.Text = ((k - 15) * 100 / 185).ToString() + "%";
        }
        #endregion

        //############ hàm liên quan ############

        // * Hàm Vẽ trục tọa độ : phụ thuộc biến k toàn cục
        #region Hàm Vẽ trục tọa độ
        private void VeTrucToaDo()
        {
            if (VeOLuoi == true)
            {
                HamVeOLuoi();
            }
            // màu và độ rộng trục số
            Pen pen = new Pen(Color.Black, 2);
            //Vẽ đường ngang cho trục Oy, Ox
            g.DrawLine(pen, 0, y0, max_x, y0);
            g.DrawLine(pen, x0, 0, x0, max_y);
            g1.DrawLine(pen, 0, y0, max_x, y0);
            g1.DrawLine(pen, x0, 0, x0, max_y);
            //Tạo Brush vẽ màu cho Chữ O,X,Y
            Brush br = new SolidBrush(Color.Red);
            //Tạo Brush vẽ màu cho các số dưới trục tọa độ
            Brush br2 = new SolidBrush(Color.DarkBlue);
            //Vẽ chữ cái trên trục: o, x , y
            g.DrawString("O", font, br, x0 - 15, y0);
            g.DrawString("X", font, br, max_x - 20, y0 - 20);
            g.DrawString("Y", font, br, x0 - 12, 0);
            g1.DrawString("O", font, br, x0 - 15, y0);
            g1.DrawString("X", font, br, max_x - 20, y0 - 20);
            g1.DrawString("Y", font, br, x0 - 12, 0);
            // Định dạng bút vẽ đơn vị lên trục số
            Pen pen_x = new Pen(Color.Black, 1);
            // biến t để tính giá trị của trục số
            int t = 1;
            //Vẽ đơn vị lên trục ox theo chiều dương
            for (int i = x0 + k; i < max_x; i += k, t++)
            {
                g.DrawLine(pen_x, i, y0 - 3, i, y0 + 2);
                Point py = new Point(i - 4, y0);
                g.DrawString(t.ToString(), font, br2, py);
                g1.DrawLine(pen_x, i, y0 - 3, i, y0 + 2);
                g1.DrawString(t.ToString(), font, br2, py);
            }
            // vẽ đơn vị lên trục ox theo chiều âm
            t = -1;
            for (int i = x0 - k; i > 0; i -= k, t--)
            {
                g.DrawLine(pen_x, i, y0 - 3, i, y0 + 2);
                Point py = new Point(i - 10, y0 + 2);
                g.DrawString(t.ToString(), font, br2, py);
                g1.DrawLine(pen_x, i, y0 - 3, i, y0 + 2);
                g1.DrawString(t.ToString(), font, br2, py);
            }
            //Vẽ đơn vị lên trục Oy theo chiều âm
            t = -1;
            for (int i = y0 + k; i < max_y; i += k, t--)
            {
                g.DrawLine(pen_x, x0 - 3, i, x0 + 2, i);
                Point py = new Point(x0 + 2, i - 8);
                g.DrawString(t.ToString(), font, br2, py);
                g1.DrawLine(pen_x, x0 - 3, i, x0 + 2, i);
                g1.DrawString(t.ToString(), font, br2, py);
            }
            //Vẽ đơn vị lên trục Oy theo chiều dương
            t = 1;
            for (int i = y0 - k; i > 0; i -= k, t++)
            {
                g.DrawLine(pen_x, x0 - 3, i, x0 + 2, i);
                Point py = new Point(x0 + 2, i - 8);
                g.DrawString(t.ToString(), font, br2, py);
                g1.DrawLine(pen_x, x0 - 3, i, x0 + 2, i);
                g1.DrawString(t.ToString(), font, br2, py);
            }
        }
        #endregion

        // * Vẽ ô lưới : phụ thuộc biến k toàn cục
        #region Vẽ ô lưới
        private void HamVeOLuoi()
        {        
            int i;
            // vẽ trục dọc phía x0 > 0
            for (i = x0 + k; i < max_x; i += k)
            {
                g.DrawLine(pen_1, i, 0, i, max_y);
                g1.DrawLine(pen_1, i, 0, i, max_y);
            }
            // vẽ trục dọc phía x0 < 0
            for (i = x0 - k; i > 0; i -= k)
            {
                g.DrawLine(pen_1, i, 0, i, max_y);
                g1.DrawLine(pen_1, i, 0, i, max_y);
            }
            // vẽ trục ngang phía  yo > 0
            for (i = y0 + k; i < max_y; i += k)
            {
                g.DrawLine(pen_1, 0, i, max_x, i);
                g1.DrawLine(pen_1, 0, i, max_x, i);
            }
            // vẽ trục ngang phía y0 < 0
            for (i = y0 - k; i > 0; i -= k)
            {
                g.DrawLine(pen_1, 0, i, max_x, i);
                g1.DrawLine(pen_1, 0, i, max_x, i);
            }
        }
        #endregion
       
        // * checkBox kiểm tra và vẽ ô lưới hay không
        #region check box kiểm tra vẽ ô lưới
        private void checkBox_VeKhungLuoi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_VeKhungLuoi.Checked == true)
            {
                VeOLuoi = true;
            }
            else VeOLuoi = false;
            VeLaiTatCa();
        }
        #endregion

        // # * Sử lý và kiểm tra chuỗi nhập từ textbox có hợp lệ không : chuẩn hóa , kiểm tra ngoặc, kiểm tra có x không
        #region Sử lý và kiểm tra chuỗi nhập từ textbox có hợp lệ không
        // Định dạng chuỗi : Chuyển thường và xóa khoảng trắng
        #region Định dạng chuỗi : Chuyển thường và xóa khoảng trắng
        private string DinhDangChuoi(string str)
        {
            string a = str.ToLower(); //Chuyển về chữ thường
            a = a.Trim();//Xóa khoảng trắng thừa đầu và cuối chuỗi
            a = System.Text.RegularExpressions.Regex.Replace(a, " ", "");//Thay thế các khoảng trắng : xóa khoảng trắng ở giữa.
            return a;
        }
        #endregion

        // Hàm Kiểm tra việc đóng mở ngoặc 
        #region Kiểm tra việc đóng mở ngoặc
        private bool XuLiNgoac(string str)
        {
            List<char> MoNgoac = new List<char>();
            List<char> DongNgoac = new List<char>();
            foreach (char c in str)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    MoNgoac.Add(c);
                }
            }
            foreach (char c in str)
            {
                if (c == ')' || c == ']' || c == '}')
                {
                    DongNgoac.Add(c);
                }
            }
            int SoDauMo = MoNgoac.Count;
            int SoDauDong = DongNgoac.Count;

            if (SoDauMo != SoDauDong)
            {
                return false;
            }
            for (int i = 0; i < SoDauMo; i++)
            {
                if (MoNgoac[i] == '{')
                {
                    if (DongNgoac[SoDauDong - 1] != '}')
                    {
                        return false;
                    }
                }
                else if (MoNgoac[i] == '(')
                {
                    if (DongNgoac[SoDauDong - 1] != ')')
                    {
                        return false;
                    }
                }
                else
                {
                    if (DongNgoac[SoDauDong - 1] != ']')
                    {
                        return false;
                    }
                }
                SoDauDong--;
            }
            return true;
        }
        #endregion

        //Kiểm tra trong hàm có chứa x
        #region Kiểm tra trong hàm có chứa x
        private bool KiemTraX(string str)
        {
            foreach (char c in str)
            {
                if (c == 'x')
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #endregion

        // * tính giới hạn khung vẽ khi vẽ hàm số của trục số thực : phụ thuộc vào k cục bộ
        #region Giới hạn vẽ hàm số
        private void TinhGioiHanKhungVe()
        {
            min = -x0 / k - 1;
            max = (max_x - x0) / k + 1;
        }
        #endregion

        // * Hàm tính f(x)
        #region Hàm tính f(x)
        private double f(double x)
        {
            Symbol sl;
            sl.m_type = Type.Variable;
            sl.m_name = "x";
            sl.m_value = x;
            arr[0] = sl;
            fn.Variables = arr;
            fn.EvaluatePostfix();
            if (fn.Error)
            {
                MessageBox.Show("Biểu thức nhập bị lỗi cú pháp !", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stop = true;
            }
            return fn.Result;
        }
        #endregion

        // * Hàm Vẽ Đồ Thị hàm số
        #region Hàm Vẽ Đồ Thị
        private void VeDoThiHamSo()
        {
            x = min;
            dx = 1.0f / k * 5;
            fx1 = f(x);// trả về stop = false hoặc giá trị 
            x1 = x0 + (int)(x * k);
            y1 = y0 - (int)(fx1 * k);
            if (stop) return;
            while (x < max)
            {
                x += dx;
                fx2 = f(x);
                x2 = x0 + (int)(x * k);
                y2 = y0 - (int)(fx2 * k);
                try
                {
                    if (!(fx1 * fx2 < 0 && Math.Abs((int)(fx1 - fx2)) > k))
                    {
                        g.DrawLine(pen_0, x1, y1, x2, y2);
                        g1.DrawLine(pen_0, x1, y1, x2, y2);
                    }
                }
                catch { }
                x1 = x2;
                y1 = y2;
                fx1 = fx2;
           }
        }
        #endregion

        // * Hàm Vẽ hình từ hàm số
        #region Vẽ hình từ hàm số
        private void PaintGraph(string str1, string str2)
        {
            string stringfunction = str1;
            string namedisplay = str2;
            try
            {
                fn.Parse(stringfunction);
                fn.Infix2Postfix();
                arr = fn.Variables;
            }
            catch
            {
                MessageBox.Show("Biểu thức không hợp lệ.\n Xin nhập lại !\n", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (arr.Count != 1)
            {
                MessageBox.Show("Biểu thức không hợp lệ.\n Xin nhập lại !\n", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (arr[0].ToString() != "x")
                {
                    MessageBox.Show("Biểu thức không hợp lệ.\n Vui lòng nhập lại !\n", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            btn_Ve.Enabled = false;
            VeDoThiHamSo();
            btn_Ve.Enabled = true;
            if (stop)
            {
                txtHamSo.Clear();
                return;
            }          
            string type = "Do Thi";
            //Kiểm tra xem có phải là vẽ lại hay không để ta tiến hành thêm đối tượng
            if (repaint == false)
            {
                ThemDoiTuong(stringfunction, namedisplay, type);
                txtHamSo.Clear();
            }
        }
        #endregion

        //######## Khối sử lý Chức năng điểm và hình học  #########

        // * Hàm Vẽ điểm
        #region Hàm Vẽ điểm
        private void DrawPoint(Graphics g, Brush br, float x, float y, string name)
        {
            // vẽ tên điểm
            g.DrawString(name, font, pen_0.Brush, x - 3, y - 13);
            // vẽ điểm
            g.FillEllipse(pen_0.Brush, x, y, 5, 5);
        }
        #endregion

        // * Hàm Thêm đối tượng đồ thị hàm số
        #region Hàm Thêm đối tượng hàm số
        private void ThemDoiTuong(string stringfunction, string namedisplay, string mtype)
        {
            //Tạo thực thể kiểm soát các hình vẽ
            DoiTuongHamSo obj = new DoiTuongHamSo();
            obj.ThemDoiTuongHamSo(stringfunction, namedisplay, mtype);
            //Thêm một đối tượng 
            listpainted.Add(obj);
            //Hiển thị lên listbox tên đối tượng
            listBox_DoThiHamSo.Items.Add(" y = " + obj.NameDisplay);
        }
        #endregion

        // # * Thêm Điểm và hình học vào danh sách điểm hình học
        #region Thêm Điểm và hình học vào danh sách điểm hình học

        // Thêm điểm
        #region Thêm điểm
        private void ThemDiem(float x, float y, char name)
        {
            DiemHinh diem = new DiemHinh();
            diem.NhapDiem(x, y, name);
            listDiemHinh.Add(diem);
        }
        #endregion

        // Thêm hình chữ nhật
        #region Thêm hình chữ nhật
        private void ThemHinhChuNhat(float x, float y, float cdai, float crong)
        {
            DiemHinh hcn = new DiemHinh();
            hcn.NhapHinhChuNhat(x, y, cdai, crong);
            listDiemHinh.Add(hcn);
        }
        #endregion

        // Thêm hình Elip
        #region Thêm hình Elip
        private void ThemHinhElip(float x, float y, float ex, float ey)
        {
            DiemHinh he = new DiemHinh();
            he.NhapHinhElip(x, y, ex, ey);
            listDiemHinh.Add(he);
        }
        #endregion

        // Thêm hình vuông
        #region Thêm hình vuông
        private void ThemHinhVuong(float x, float y, float daicanh)
        {
            DiemHinh hv = new DiemHinh();
            hv.NhapHinhVuong(x, y, daicanh);
            listDiemHinh.Add(hv);
        }
        #endregion

        // Thêm hình tròn
        #region Thêm hình tròn
        private void ThemHinhTron(float x, float y, float bankinh)
        {
            DiemHinh ht = new DiemHinh();
            ht.NhapHinhTron(x, y, bankinh);
            listDiemHinh.Add(ht);
        }
        #endregion

        // thêm hình tam giác
        #region Thêm hình tam giac
        private void ThemHinhTamGiac(float ax, float ay, float bx, float by,float cx, float cy)
        {
            DiemHinh htg = new DiemHinh();
            htg.NhapHinhTamGiac(ax, ay, bx, by, cx, cy);
            listDiemHinh.Add(htg);
        }
        #endregion

        #endregion

        // # * Vẽ Điểm Hình
        #region Vẽ Điểm hình
        // Hàm vẽ điềm
        #region Hàm vẽ điềm
        private void VeDiem(int ViTriDiemLuu)
        {
            int i = ViTriDiemLuu;
            float xx = (listDiemHinh[i].x * k) + (float)x0;
            float yy = (float)y0 - (k * listDiemHinh[i].y);
            DrawPoint(g, pen_0.Brush, xx, yy, listDiemHinh[i].TenDiem.ToString());
            DrawPoint(g1, pen_0.Brush, xx, yy, listDiemHinh[i].TenDiem.ToString());
        }
        #endregion

        // Hàm vẽ hình vuông
        #region Hàm vẽ hình vuông
        private void VeHinhVuong(int ViTriHinhLuu)
        {
            int i = ViTriHinhLuu;
            float xx = (listDiemHinh[i].x * k) + (float)x0;
            float yy = (float)y0 - (k * listDiemHinh[i].y);
            g.DrawRectangle(pen_0, xx, yy, listDiemHinh[i].DaiCanh * k, k * listDiemHinh[i].DaiCanh);
            g1.DrawRectangle(pen_0, xx, yy, listDiemHinh[i].DaiCanh * k, k * listDiemHinh[i].DaiCanh);
        }
        #endregion

        // Hàm vẽ hình tròn
        #region Hàm vẽ hình tròn
        private void VeHinhTron(int ViTriHinhLuu)
        {
            int i = ViTriHinhLuu;
            float xx = (listDiemHinh[i].x * k) + (float)x0;
            float yy = (float)y0 - (k * listDiemHinh[i].y);
            g.DrawEllipse(pen_0, xx - listDiemHinh[i].BanKinh * k, yy - listDiemHinh[i].BanKinh * k, listDiemHinh[i].BanKinh * k * 2, 2 * k * listDiemHinh[i].BanKinh);
            g1.DrawEllipse(pen_0, xx - listDiemHinh[i].BanKinh * k, yy - listDiemHinh[i].BanKinh * k, listDiemHinh[i].BanKinh * k * 2, 2 * k * listDiemHinh[i].BanKinh);
        }
        #endregion

        // Hàm vẽ hình elip
        #region Hàm vẽ hình elip
        private void VeHinhElip(int ViTriHinhLuu)
        {
            int i = ViTriHinhLuu;
            float xx = (listDiemHinh[i].x * k) + (float)x0;
            float yy = (float)y0 - (k * listDiemHinh[i].y);
            g.DrawEllipse(pen_0, xx - listDiemHinh[i].Ex * k, yy - listDiemHinh[i].Ey * k, listDiemHinh[i].Ex * k * 2, 2 * k * listDiemHinh[i].Ey);
            g1.DrawEllipse(pen_0, xx - listDiemHinh[i].Ex * k, yy - listDiemHinh[i].Ey * k, listDiemHinh[i].Ex * k * 2, 2 * k * listDiemHinh[i].Ey);
        }
        #endregion

        // Hàm vẽ hình tam giác
        #region Hàm vẽ hình tam giác
        private void VeHinhTamGiac(int ViTriHinhLuu)
        {
            int i = ViTriHinhLuu;
            float ax = (listDiemHinh[i].Ax * k) + (float)x0;
            float ay = (float)y0 - (k * listDiemHinh[i].Ay);
            float bx = (listDiemHinh[i].Bx * k) + (float)x0;
            float by = (float)y0 - (k * listDiemHinh[i].By);
            float cx = (listDiemHinh[i].Cx * k) + (float)x0;
            float cy = (float)y0 - (k * listDiemHinh[i].Cy);
            g.DrawLine(pen_0, ax, ay, bx, by);
            g.DrawLine(pen_0, ax, ay, cx, cy);
            g.DrawLine(pen_0, bx, by, cx, cy);
            g1.DrawLine(pen_0, ax, ay, bx, by);
            g1.DrawLine(pen_0, ax, ay, cx, cy);
            g1.DrawLine(pen_0, bx, by, cx, cy);
        }
        #endregion

        // Hàm vẽ hình chữ nhật
        #region Hàm vẽ hình chữ nhật
        private void VeHinhChuNhat(int ViTriHinhLuu)
        {
            int i = ViTriHinhLuu;
            float xx = (listDiemHinh[i].x * k) + (float)x0;
            float yy = (float)y0 - (k * listDiemHinh[i].y);
            g.DrawRectangle(pen_0, xx, yy, listDiemHinh[i].CDai * k, listDiemHinh[i].CRong * k);
            g1.DrawRectangle(pen_0, xx, yy, listDiemHinh[i].CDai * k, listDiemHinh[i].CRong * k);
        }
        #endregion

        #endregion

        // * Hàm vẽ lại các hàm số
        #region Hàm vẽ lại các đồ thị hàm số
        private void VeCacHamSo()
        {
            int sophantu = listpainted.Count;
            for (int i = 0; i < sophantu; i++)
            {
                repaint = true;
                PaintGraph(listpainted[i].Name, listpainted[i].NameDisplay);
                repaint = false;
            }
        }
        #endregion

        // * Hàm vẽ lại Điểm hình
        #region Hàm vẽ lại Điểm hình
        private void VeDiemHinh()
        {
            int sophantu = listDiemHinh.Count;
            for (int i = 0; i < sophantu; i++)
            {
                repaint = true;
                if (listDiemHinh[i].GetType() == "Diem")
                {
                    VeDiem(i);
                }
                if (listDiemHinh[i].GetType() == "Hinh Vuong")
                {
                    VeHinhVuong(i);
                }
                if (listDiemHinh[i].GetType() == "Hinh Tron")
                {
                    VeHinhTron(i);
                }
                if (listDiemHinh[i].GetType() == "Hinh Elip")
                {
                    VeHinhElip(i);
                }
                if (listDiemHinh[i].GetType() == "Hinh Chu Nhat")
                {
                    VeHinhChuNhat(i);
                }
                if (listDiemHinh[i].GetType() == "Hinh Tam Giac")
                {
                    VeHinhTamGiac(i);
                }
                repaint = false;
            }
        }
        #endregion

        // * Hàm Đặt tên cho điểm mới tạo
        #region Hàm Đặt tên cho điểm mới tạo
        public char DatTenChoDiem(int numdiem)
        {
            sodiem = sodiem + 1;
            return ((char)(numdiem + 65));
        }
        #endregion

        // * Hàm Đặt khởi tạo giá trị Khung vẽ về mặc định
        #region Hàm Đặt lại khung vẽ
        private void PicPaint_MacDinh(object sender, EventArgs e)
        {
            max_x = PicPaint.Width;
            max_y = PicPaint.Height;
            k = 30;
            x0 = (int)(max_x / 2);
            y0 = (int)(max_y / 2);
            min = -x0 / k - 1;
            max = x0 / k + 1;
        }
        #endregion

        /////////////////////////
        // sử lý các sự kiện ///
        ///////////////////////


        //### Thao Tác Panel Left ###

        // * bấm nút vẽ 
        #region bấm nút vẽ
        public void SuKienVe()
        {
            stop = false;
            //Lưu trữ tạm thời textbox nhập hàm số
            string stringfunction = txtHamSo.Text.ToString();
            string stringfunction1 = txtHamSo.Text.ToString();
            //Định dạng lại chuỗi
            stringfunction = DinhDangChuoi(stringfunction);
            //Nếu chuỗi rỗng
            if (stringfunction == "")
            {
                MessageBox.Show("Vui lòng nhập vào hàm số !", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (stringfunction.StartsWith("-"))
            {
                if (KiemTraX(stringfunction) == false)
                    stringfunction = "0*x+0" + stringfunction;
                // stringfunction = stringfunction.Replace("-", "0-");
                else
                {
                    stringfunction = "0" + stringfunction;
                }
            }
            if (KiemTraX(stringfunction) == false)
                stringfunction = "0*x+" + stringfunction;
            stringfunction = stringfunction.Replace("(-", "(0-");
            //Lưu chuỗi đã được định dạng
            string namedisplay = stringfunction1;
            //Xử lí B1 cho các dấu ngoặc
            if (XuLiNgoac(stringfunction) == false || stringfunction.Contains(")x") == true)
            {
                MessageBox.Show("Biểu thức nhập bị lỗi cú pháp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PaintGraph(stringfunction, namedisplay);
            label_SoLuongHamSo.Text = listpainted.Count.ToString();
        }
         private void btn_Ve_Click(object sender, EventArgs e)
         {
            SuKienVe();
         }
         #endregion

        // # * Thao tác với nút mở rộng
        #region  # * Thao tác với nút mở rộng
         private void btn_MoRong_Click(object sender, EventArgs e)
         {
             contextMenuStrip_MoRong.Show(240,120);
         }

        public void DuaConTroVeCuoiChuoi()
        {
            txtHamSo.Focus();
            txtHamSo.SelectionStart = txtHamSo.Text.Length;
        }
         private void logaritTựNhiênToolStripMenuItem_Click(object sender, EventArgs e)
         {
            txtHamSo.Text += "ln(";
            DuaConTroVeCuoiChuoi();
        }

         private void lũyThừaSốEToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "exp(";
            DuaConTroVeCuoiChuoi();
        }

         private void mũNToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "^";
            DuaConTroVeCuoiChuoi();
        }

         private void trịTuyệtĐốiToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "abs(";
            DuaConTroVeCuoiChuoi();
        }

         private void piToolStripMenuItem_Click(object sender, EventArgs e)
         {
            string t = Math.PI.ToString();
             txtHamSo.Text += t;
            DuaConTroVeCuoiChuoi();
        }

         private void eToolStripMenuItem_Click(object sender, EventArgs e)
         {
            string t = Math.E.ToString();  
            txtHamSo.Text += t;
            DuaConTroVeCuoiChuoi();
        }

         private void CanBac2_ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "sqrt(";
            DuaConTroVeCuoiChuoi();
        }

         private void BinhPhuong_ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "sqr(";
            DuaConTroVeCuoiChuoi();
        }

         private void cộngToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "+";
            DuaConTroVeCuoiChuoi();
        }

         private void trừToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "-";
            DuaConTroVeCuoiChuoi();
        }

         private void nhânToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "*";
            DuaConTroVeCuoiChuoi();
        }

         private void chiaToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "/";
            DuaConTroVeCuoiChuoi();
        }

         private void chiaLấyDưToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "%";
            DuaConTroVeCuoiChuoi();
        }

         private void logarit10ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "log(";
            DuaConTroVeCuoiChuoi();
        }

         private void sinToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "sin(";
            DuaConTroVeCuoiChuoi();
        }

         private void cosToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "cos(";
            DuaConTroVeCuoiChuoi();
        }

         private void tanToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "tan(";
            DuaConTroVeCuoiChuoi();
        }

         private void cotToolStripMenuItem_Click(object sender, EventArgs e)
         {
             txtHamSo.Text += "cot(";
            DuaConTroVeCuoiChuoi();
          }
        private void sinHypebolicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtHamSo.Text += "sinh(";
            DuaConTroVeCuoiChuoi();
        }

        private void cosHypebolicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtHamSo.Text += "cosh(";
            DuaConTroVeCuoiChuoi();
        }

        private void tanHypebolicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtHamSo.Text += "tanh(";
            DuaConTroVeCuoiChuoi();
        }

        private void cotangHyperbolicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtHamSo.Text += "coth(";
            DuaConTroVeCuoiChuoi();
        }

        private void arcSinToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtHamSo.Text += "arcsin(";
            DuaConTroVeCuoiChuoi();
        }

        private void arcTanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtHamSo.Text += "arctan(";
            DuaConTroVeCuoiChuoi();
        }

        private void arcCosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtHamSo.Text += "arccos(";
            DuaConTroVeCuoiChuoi();
        }
        #endregion

        // # * Bấm nút điểm và hình học
        #region Vẽ diem hinh
        public bool isVeDiem = false;
        private void veToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isVeDiem = true;
            label_HuongDanVe.Text = "Di chuyển và click để vẽ điểm tại vị trí con trỏ chuột";
        }
        private void vẽTheoTọaĐộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhapDiem f = new NhapDiem();
            f.ShowDialog();
            if (f.ISDIEM)
            {
                if (f != null)
                {
                    tdX = f.GetX * (float)k + x0;
                    tdY = (float)y0 - (float)f.GetY * k;
                }
                char TenDiem = DatTenChoDiem(sodiem);
                DrawPoint(g, Brushes.Blue, tdX, tdY, TenDiem.ToString());
                DrawPoint(g1, Brushes.Blue, tdX, tdY, TenDiem.ToString());
                if (repaint == false)
                {
                    ThemDiem(f.GetX, f.GetY, TenDiem);
                }
                double x, y;
                x = Math.Round(f.GetX, 4);
                y = Math.Round(f.GetY, 4);
                string namediem = "Điểm : " + TenDiem + "(" + x.ToString() + "," + y.ToString() + ")";
                listBox_DiemHinh.Items.Add(namediem);
                label_SoLuongDiemHinh.Text = listDiemHinh.Count.ToString();
            }
        }
        private void btn_Diem_Click(object sender, EventArgs e)
         {
            contextVeDiem.Show(33, 275);
         }

         private void btn_HinhVuong_Click(object sender, EventArgs e)
         {
             NhapHinhVuong f = new NhapHinhVuong();
             f.ShowDialog();
             if (f.ISHINHVUONG)
             {
                 if (f != null)
                 {
                     DC = f.DAICANH;
                     ishvuong = true;
                 }
                 else
                     ishvuong = false;
                 label_HuongDanVe.Text = "Di chuyển và click để vẽ hình tại vị trí con trỏ chuột";
             }
         }

         private void btn_HinhTron_Click(object sender, EventArgs e)
         {
             NhapHinhTron f = new NhapHinhTron();
             f.ShowDialog();
             if (f.ISHINHTRON)
             {
                 if (f != null)
                 {
                     R = f.BANKINH;
                     ishinhtron = true;
                 }
                 else
                     ishinhtron = false;

                 label_HuongDanVe.Text = "Di chuyển và click để vẽ hình tròn với tâm tại vị trí con trỏ chuột";
             }
         }

         private void btn_HinhTamGiac_Click(object sender, EventArgs e)
         {
             NhapHinhTamGiac f = new NhapHinhTamGiac();
             f.ShowDialog();
             if (f.ISHINHTAMGIAC)
             {
                 if (f != null)
                 {
                     AX = f.AX * (float)k + x0;
                     AY = (float)y0 - (float)f.AY * k;
                     BX = f.BX * (float)k + x0;
                     BY = (float)y0 - (float)f.BY * k;
                     CX = f.CX * (float)k + x0;
                     CY = (float)y0 - (float)f.CY * k;
                 }
                 g.DrawLine(pen_0, AX, AY, BX, BY);
                 g.DrawLine(pen_0, AX, AY, CX, CY);
                 g.DrawLine(pen_0, BX, BY, CX, CY);
                 g1.DrawLine(pen_0, AX, AY, BX, BY);
                 g1.DrawLine(pen_0, AX, AY, CX, CY);
                 g1.DrawLine(pen_0, BX, BY, CX, CY);
                 if (repaint == false)
                 {
                     ThemHinhTamGiac(f.AX, f.AY, f.BX, f.BY, f.CX, f.CY);
                 }
                 //double x, y;
                 //x = Math.Round(f.GetX, 4);
                 //y = Math.Round(f.GetY, 4));
                 string namediem = "Tam giác ";
                 listBox_DiemHinh.Items.Add(namediem);
                 label_SoLuongDiemHinh.Text = listDiemHinh.Count.ToString();
             }
         }

         private void btn_HinhElip_Click(object sender, EventArgs e)
         {
             NhapHinhElip f = new NhapHinhElip();
             f.ShowDialog();
             if (f.ISHINHELIP)
             {
                 if (f != null)
                 {
                     EX = f.EX;
                     EY = f.EY;
                     ishinhelip = true;
                 }
                 else
                     ishinhelip = false;
                 label_HuongDanVe.Text = "Di chuyển và click để vẽ hình elip với tâm tại vị trí con trỏ chuột";
             }
         }

         private void btn_HinhChuNhat_Click(object sender, EventArgs e)
         {
             NhapHinhChuNhat f = new NhapHinhChuNhat();
             f.ShowDialog();
             if (f.ISHINHCHUNHAT)
             {
                 if (f != null)
                 {
                     CD = f.CDAI;
                     CR = f.CRONG;
                     ishcn = true;
                 }
                 else
                     ishcn = false;
                 label_HuongDanVe.Text = "Di chuyển và click để vẽ hình tại vị trí con trỏ chuột";
             }
         }       
         #endregion

        // # * Điều khiển
        #region Điều khiển
         // nút phóng to
         #region nút phóng to
         private void btn_PhongTo_Click(object sender, EventArgs e)
         {
             if (k >= 200 )
             {
                 MessageBox.Show("Không thể phóng to thêm", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
             }
             btn_PhongTo.Enabled = false;
             k = k + 5;
             label_TiLe.Text = ((k-15)*100/185).ToString() + "%";
             TinhGioiHanKhungVe();
             VeLaiTatCa();
             btn_PhongTo.Enabled = true;
         }
         #endregion
         // thu nhỏ
         #region Thu Nhỏ
         private void btn_ThuNho_Click(object sender, EventArgs e)
         {
             if (k <= 15)
             {
                 MessageBox.Show("Không thể thu nhỏ thêm", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
             }
             btn_ThuNho.Enabled = false;
             k = k - 5;
             label_TiLe.Text = ((k-15)*100/185).ToString() + "%";
             TinhGioiHanKhungVe();
             VeLaiTatCa();
             btn_ThuNho.Enabled = true;
         }
         #endregion
         // nút mặc định     
         #region Nút mặc định
         private void btn_MacDinh_Click(object sender, EventArgs e)
         {
             x0 = PicPaint.Width / 2;
             y0 = PicPaint.Height / 2;
             k = 30;
             TinhGioiHanKhungVe();
             label_TiLe.Text = ((k - 15) * 100 / 185).ToString() + "%";
             VeLaiTatCa();
         }
         #endregion
         // di chuyển lên
         #region Di chuyển lên
         private void btn_Len_Click(object sender, EventArgs e)
         {
             y0 += 40;
            TinhGioiHanKhungVe();
            VeLaiTatCa();      
         }
         #endregion
         // di chuyển xuống
         #region Di chuyển xuống
         private void btn_Xuong_Click(object sender, EventArgs e)
         {
             y0 -= 40;
             TinhGioiHanKhungVe();
             VeLaiTatCa();          
         }
         #endregion
         // di chuyển sang trái
         #region Di chuyển sang trái
         private void btn_Trai_Click(object sender, EventArgs e)
         {
             x0 += 40;
             TinhGioiHanKhungVe();
             VeLaiTatCa();          
         }
         #endregion
         // di chuyển sang phải
         #region Di chuyển sang phải
         private void btn_Phai_Click(object sender, EventArgs e)
         {
             x0 -= 40;
             TinhGioiHanKhungVe();
             VeLaiTatCa();    
         }
         #endregion

         #endregion

        // # * về chúng tôi
        #region về chúng tôi
         // Thông tin
         #region Thông tin
         private void btn_ThongTin_Click(object sender, EventArgs e)
         {
             ThongTin f = new ThongTin();
             f.ShowDialog();
         }

        private void txtHamSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtHamSo.Text == "")
            {
                return;
            }
            else if(e.KeyCode==Keys.Enter)
            {
                SuKienVe();
            }
        }




        #endregion
        // Phản hồi
        #region Phản hồi
        private void btn_PhanHoi_Click(object sender, EventArgs e)
         {
             PhanHoi f = new PhanHoi();
             f.ShowDialog();
         }
         #endregion
         #endregion
      
        //### Thao Tác ở Giữa ###

        // * Bấm nút Bắt đầu
        #region Bấm nút Bắt đầu
         private void btnBatDau_Click(object sender, EventArgs e)
         {
             panelLeft.Enabled = true;
             panelRight.Enabled = true;
             PicPaint_MacDinh(null, null);
             checkBox_VeKhungLuoi.Checked = true;
             PicStart.Dispose();
             Application.DoEvents();
             btnBatDau.Dispose();
             Application.DoEvents();
             VeTrucToaDo();
         }
        #endregion

        // * Di chuyển chuột trong PicPaint
        #region Di chuyển chuột trong PicPaint
        private void PicPaint_MouseMove(object sender, MouseEventArgs e)
         {
             double x, y;
             x = Math.Round(((float)(e.X - x0) / k), 4);
             y = Math.Round(((float)(-1) * (e.Y - y0) / k), 4);
             label_ViTriChuotX.Text = x.ToString();
             label_ViTriChuotY.Text = y.ToString();
         }
         #endregion 

        // * Di chuyển chuột ra ngoài PicPaint
        #region Di chuyển chuột ra ngoài PicPaint
         private void PicPaint_MouseLeave(object sender, EventArgs e)
         {
             label_ViTriChuotX.Text = 0.ToString();
             label_ViTriChuotY.Text = 0.ToString();
         }
         #endregion

        // * click chuột để kéo thả
        #region click chuột để kéo thả
         private void PicPaint_MouseUp(object sender, MouseEventArgs e)
         {
             PicPaint.Cursor = Cursors.Default;
             int x = e.X - m_x;
             int y = e.Y - m_y;
             if (Math.Abs(x) >= 20 || Math.Abs(y) >= 20)
             {
                 x0 += x;
                 y0 += y;
                 TinhGioiHanKhungVe();
                 VeLaiTatCa();
             }
         }
         private void PicPaint_MouseDown(object sender, MouseEventArgs e)
         {
             PicPaint.Cursor = Cursors.SizeAll;
             m_x = e.X;
             m_y = e.Y;
         }
         #endregion

        // click chuột để vẽ hình
        #region  click để vẽ hinh
         private void PicPaint_MouseClick(object sender, MouseEventArgs e)
         {
             if (ishvuong == true)
             {
                 g.DrawRectangle(pen_0, e.X, e.Y, DC * k, k * DC);
                 g1.DrawRectangle(pen_0, e.X, e.Y, DC * k, k * DC);
                 float X_hienthi = ((float)(e.X - x0) / k);
                 float Y_hienthi = ((float)(-1) * (e.Y - y0) / k);
                 ThemHinhVuong(X_hienthi, Y_hienthi, DC);
                 double a = Math.Round(X_hienthi, 2);
                 double b = Math.Round(Y_hienthi, 2);
                 string HienThiHV = "H.Vuông(" + a.ToString() + ";" + b.ToString() + ")" + " D.Cạnh:" + DC.ToString();
                 listBox_DiemHinh.Items.Add(HienThiHV);
                 label_SoLuongDiemHinh.Text = listDiemHinh.Count.ToString();
                 label_HuongDanVe.Text = "";
                 ishvuong = false;
             }
             if (ishinhelip == true)
             {
                 g.DrawEllipse(pen_0, e.X - EX * k, e.Y - EY * k, 2 * EX * k, 2 * k * EY);
                 g1.DrawEllipse(pen_0, e.X - EX * k, e.Y - EY * k, 2 * EX * k, 2 * k * EY);
                 float X_hienthi = ((float)(e.X - x0) / k);
                 float Y_hienthi = ((float)(-1) * (e.Y - y0) / k);
                 ThemHinhElip(X_hienthi, Y_hienthi, EX, EY);
                 double a = Math.Round(X_hienthi, 2);
                 double b = Math.Round(Y_hienthi, 2);
                 string HienThiHV = "H.Elip(" + a.ToString() + ";" + b.ToString() + ")" + " Ex:" + EX.ToString() + ",Ey:" + EY.ToString();
                 listBox_DiemHinh.Items.Add(HienThiHV);
                 label_SoLuongDiemHinh.Text = listDiemHinh.Count.ToString();
                 label_HuongDanVe.Text = "";
                 ishinhelip = false;
             }
             if (ishinhtron == true)
             {
                 g.DrawEllipse(pen_0, e.X - R * k, e.Y - R * k, 2 * R * k, 2 * k * R);
                 g1.DrawEllipse(pen_0, e.X - R * k, e.Y - R * k, 2 * R * k, 2 * k * R);
                 float X_hienthi = ((float)(e.X - x0) / k);
                 float Y_hienthi = ((float)(-1) * (e.Y - y0) / k);
                 ThemHinhTron(X_hienthi, Y_hienthi, R);
                 double a = Math.Round(X_hienthi, 2);
                 double b = Math.Round(Y_hienthi, 2);
                 string HienThiHV = "H.Tròn(" + a.ToString() + ";" + b.ToString() + ")" + "B.kính:" + R.ToString();
                 listBox_DiemHinh.Items.Add(HienThiHV);
                 label_SoLuongDiemHinh.Text = listDiemHinh.Count.ToString();
                 label_HuongDanVe.Text = "";
                 ishinhtron = false;
             }
             if (ishcn == true)
             {
                 g.DrawRectangle(pen_0, e.X, e.Y, CD * k, k * CR);
                 g1.DrawRectangle(pen_0, e.X, e.Y, CD * k, k * CR);
                 float X_hienthi = ((float)(e.X - x0) / k);
                 float Y_hienthi = ((float)(-1) * (e.Y - y0) / k);
                 ThemHinhChuNhat(X_hienthi, Y_hienthi, CD, CR);
                 double a = Math.Round(X_hienthi, 2);
                 double b = Math.Round(Y_hienthi, 2);
                 string HienThiHCN = "HCN(" + a.ToString() + ";" + b.ToString() + ")" + " C.Dài:" + CD.ToString() + ",C.Rộng:" + CR.ToString();
                 listBox_DiemHinh.Items.Add(HienThiHCN);
                 label_SoLuongDiemHinh.Text = listDiemHinh.Count.ToString();
                 label_HuongDanVe.Text = "";
                 ishcn = false;
             }
             if(isVeDiem==true)
            {
                tdX = (float)(e.X - x0)/k;
                tdY = (float)(y0 - e.Y )/ k;

                char TenDiem = DatTenChoDiem(sodiem);
               DrawPoint(g, Brushes.Blue, e.X, e.Y, TenDiem.ToString());
               DrawPoint(g1, Brushes.Blue, e.X, e.Y, TenDiem.ToString());
                ThemDiem(tdX, tdY, TenDiem);
                double x, y;
                x = Math.Round(tdX, 4);
                y = Math.Round(tdY, 4);
                string namediem = "Điểm : " + TenDiem + "(" + x.ToString() + ";" + y.ToString() + ")";
                listBox_DiemHinh.Items.Add(namediem);
                label_SoLuongDiemHinh.Text = listDiemHinh.Count.ToString();
                label_HuongDanVe.Text="";
                isVeDiem = false;
            }
         }        
         #endregion
        
        //### Thao Tác Panel Right ###

        // # * Click Vào đối tượng trên listBox chứa danh sách
        #region Click Vào đối tượng trên listBox chứa danh sách
        // Danh sách đồ thị hàm số
        #region Danh sách đồ thị hàm số
         private void listBoxDoThiHamSo_SelectedIndexChanged(object sender, EventArgs e)
         {
             //Hiển thị tên đối tượng đang chọn
             if (listBox_DoThiHamSo.SelectedIndex != -1)
             {
                 btn_XoaHamSo.Enabled = true;
                 btn_XoaAllHamSo.Enabled = true;
                 label_DangChonHamSo.Text = listBox_DoThiHamSo.SelectedItem.ToString();
             }
             else
             {
                 btn_XoaHamSo.Enabled = false;
             }
         }
         #endregion

        // Danh sách điểm và hình
        #region Danh sách điểm và hình
         private void listBox_DiemHinh_SelectedIndexChanged(object sender, EventArgs e)
         {
             //Hiển thị tên đối tượng đang chọn
             if (listBox_DiemHinh.SelectedIndex != -1)
             {
                 btn_XoaDiemHinh.Enabled = true;
                 btn_XoaAllDiemHinh.Enabled = true;
                 label_DangChonDiemHinh.Text = listBox_DiemHinh.SelectedItem.ToString();
             }
             else
             {
                 btn_XoaDiemHinh.Enabled = false;
             }
         }
         #endregion

        #endregion

        // * Bấm Các nút xóa
        #region Bấm nút xóa

         // xóa đồ thị hàm số
         #region
         private void btn_XoaHamSo_Click(object sender, EventArgs e)
         {
             int sttObj = listBox_DoThiHamSo.SelectedIndex;
             if (listBox_DoThiHamSo.SelectedIndex != -1)
             {
                 listpainted.RemoveAt(sttObj);
                 VeLaiTatCa();
                 btn_XoaHamSo.Enabled = true;
                 btn_XoaAllHamSo.Enabled = true;
                 //Xóa item đang chọn
                 listBox_DoThiHamSo.Items.Remove(listBox_DoThiHamSo.SelectedItem);
                 //Xóa tên item đang chọn
                 label_DangChonHamSo.Text = "";
                 label_SoLuongHamSo.Text = listpainted.Count.ToString();
             }
         }
         #endregion
         // xóa tất cả đồ thị hàm số
         #region
         private void btn_XoaAllHamSo_Click(object sender, EventArgs e)
         {
             listBox_DoThiHamSo.Items.Clear();
             listpainted.Clear();
             label_SoLuongHamSo.Text = listpainted.Count.ToString();
             label_DangChonHamSo.Text = "";
             VeLaiTatCa();
         }
         #endregion
         // xóa điểm hình
         #region
         private void btn_XoaDiemHinh_Click(object sender, EventArgs e)
         {
             int sttObj = listBox_DiemHinh.SelectedIndex;
             if (listBox_DiemHinh.SelectedIndex != -1)
             {
                 listDiemHinh.RemoveAt(sttObj);
                 VeLaiTatCa();
                 btn_XoaDiemHinh.Enabled = true;
                 btn_XoaAllDiemHinh.Enabled = true;
                 //Xóa item đang chọn
                 listBox_DiemHinh.Items.Remove(listBox_DiemHinh.SelectedItem);
                 //Xóa tên item đang chọn
                 label_DangChonDiemHinh.Text = "";
                 label_SoLuongDiemHinh.Text = listDiemHinh.Count.ToString();
             }
         }
         #endregion
         // xóa tất cả điểm hình
         #region
         private void btn_XoaAllDiemHinh_Click(object sender, EventArgs e)
         {
             listBox_DiemHinh.Items.Clear();
             listDiemHinh.Clear();
             label_SoLuongDiemHinh.Text = listDiemHinh.Count.ToString();
             label_DangChonDiemHinh.Text = "";
             VeLaiTatCa();
         }
         #endregion

         #endregion     

        // Hàm đổi ảnh
        #region Hàm đổi ảnh
        private void DoiAnh(int vitrianh)
         {
            if(vitrianh==-1)
                PicPaint.Image = null;
            else
             PicPaint.Image = imageList_AnhNen.Images[vitrianh];
            VeLaiTatCa();
         }
         #endregion

        // * Đổi ảnh nền
        #region đổi ảnh nền
         private void btn_AnhNen_Click(object sender, EventArgs e)
         {
             contextMenuStrip_AnhNen.Show(960,550);
         }
         private void mặcĐịnhTrắngToolStripMenuItem_Click(object sender, EventArgs e)
         {
             DoiAnh(-1);
             VeLaiTatCa();
         }
         private void blueSkyToolStripMenuItem_Click(object sender, EventArgs e)
         {
             DoiAnh(0);
             VeLaiTatCa();
         }
         private void tímMộngMơToolStripMenuItem_Click(object sender, EventArgs e)
         {
             DoiAnh(1);
             VeLaiTatCa();
         }
         private void vàngLúaToolStripMenuItem_Click(object sender, EventArgs e)
         {
             DoiAnh(2);
             VeLaiTatCa();   
         }
         private void bíMậtBiểnXanhToolStripMenuItem_Click(object sender, EventArgs e)
         {
             DoiAnh(3);
             VeLaiTatCa();
         }
         #endregion

        // Hàm vẽ lại tất cả
        #region Vẽ lại tất cả
        private void VeLaiTatCa()
         {
             PicPaint.Refresh();
             g1.Clear(Color.White);
             VeTrucToaDo();
             VeCacHamSo();
             VeDiemHinh();
         }
        #endregion

        // * đổi màu bút vẽ
        #region đổi màu bút vẽ
         private void btn_DoiMauBut_Click(object sender, EventArgs e)
         {
             ColorDialog colorDlg = new ColorDialog();
             colorDlg.AllowFullOpen = false;
             colorDlg.AnyColor = true;
             colorDlg.SolidColorOnly = false;
             colorDlg.Color = Color.Green;
             if (colorDlg.ShowDialog() == DialogResult.OK)
             {
                 pen_0.Color = colorDlg.Color;
                 VeLaiTatCa();
             }
         }
        #endregion

        // * Lưu hình
        #region Lưu hình
         private void btn_Luu_Click(object sender, EventArgs e)
         {
             SaveFileDialog File = new SaveFileDialog();
             File.Title = "Lưu hình";
             File.RestoreDirectory = true;
             File.InitialDirectory = @"C:\\";
             File.Filter = "Image files (*.jpg)|*.jpg|Image files (*.jpeg)|*.jpeg|Image file (*.bmp)|*.bmp";
             File.FileName = (DateTime.Now).ToString("yyyy-MM-dd hh-mm-ss");
             if (File.ShowDialog() == DialogResult.OK)
             {
                 bitmap.Save(File.FileName);
             }
         }
         #endregion

        // * Cập Nhập
        #region Cập nhập
         private void btn_CapNhap_Click(object sender, EventArgs e)
         {
             CapNhap f = new CapNhap();
             f.ShowDialog();
             if (f.ISCAPNHAP)
             {
                 Close();
             }
         }
        #endregion

        // * Hướng dẫn
        #region Hướng dẫn
        private void label_HuongDan_Click(object sender, EventArgs e)
         {
             HuongDan f = new HuongDan();
             f.ShowDialog();
         }
        #endregion
    }
}