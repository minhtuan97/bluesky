using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeDoThi
{
    class DiemHinh
    {
        public float x, y;// Tọa độ điểm
        string Type = "";// tên loại hình
        public char TenDiem;// Tên của điểm
        public float DaiCanh;// độ dài cạnh hình vuông
        public float BanKinh;// Bán kính hình tròn
        public float Ex, Ey;// Bán trục lớn và bán trụ nhỏ của elip
        public float CDai, CRong;// Chiều dài, chiều rông hình chữ nhật 
        public float Ax, Ay, Bx, By, Cx, Cy;// Tọa độ 3 điểm hình tam giác
        // Hàm lấy loại của đối tượng
        public string GetType()
        {
            return Type;
        }
        // Hàm nhập điểm
        public void NhapDiem(float X, float Y, char Name)
        {
            x = X;
            y = Y;
            TenDiem = Name;
            Type = "Diem";
        }
        // Hàm nhập hình vuông
        public void NhapHinhVuong(float X, float Y, float DCanh)
        {
            x = X;
            y = Y;
            DaiCanh = DCanh;
            Type = "Hinh Vuong";
        }
       // Hàm nhập hình tròn
        public void NhapHinhTron(float X, float Y, float BKinh)
        {
            x = X;
            y = Y;
            BanKinh = BKinh;
            Type = "Hinh Tron";
        }
       // Hàm nhập hình elip
        public void NhapHinhElip(float X, float Y, float ex, float ey)
        {
            x = X;
            y = Y;
            Ex = ex;
            Ey = ey;
            Type = "Hinh Elip";
        }
       // Hàm nhập hình chữ nhât
        public void NhapHinhChuNhat(float X, float Y, float CD, float CR)
        {
            x = X;
            y = Y;
            CDai = CD;
            CRong = CR;
            Type = "Hinh Chu Nhat";
        }
        // Hàm nhập hình tam giác
        public void NhapHinhTamGiac(float ax, float ay, float bx, float by, float cx, float cy)
        {
            Ax = ax;
            Ay = ay;
            Bx = bx;
            By = by;
            Cx = cx;
            Cy = cy;
            Type = "Hinh Tam Giac";
        }
    }   
}
