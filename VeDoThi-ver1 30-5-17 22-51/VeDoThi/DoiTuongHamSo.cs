using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeDoThi
{
    class DoiTuongHamSo
    {
        public string NameDisplay; //Hiển thị ra ngoài màn hình
        public string Name; //dùng thao tác
        public string Type;
        public void ThemDoiTuongHamSo(string na, string nad, string type)
        {
            Name = na;
            NameDisplay = nad;
            Type = type;
        }
    }
}
