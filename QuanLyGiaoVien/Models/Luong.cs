using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaoVien.Models
{
    public class Luong
    {
        public int BangLuongId { get; set; }
        public int GiaoVienId { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal PhuCap { get; set; }
        public decimal ThuNhap { get; set; }
    }
}
