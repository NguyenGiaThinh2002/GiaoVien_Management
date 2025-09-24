using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaoVien.Models
{
    public class GiaoVien
    {
        public int Id { get; set; }
        public string TenGV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string HocVi { get; set; }
        public decimal Luong { get; set; }
        public int KhoaId { get; set; }
    }
}
