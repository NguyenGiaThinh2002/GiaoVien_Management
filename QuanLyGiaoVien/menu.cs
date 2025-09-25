using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using QuanLyGiaoVien.Helper;
using QuanLyGiaoVien.Models;

namespace QuanLyGiaoVien
{
    public partial class menu : Form
    {
        private DatabaseHelper _db;
        private Repository _repo;
        public menu()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            string connString = "Host=localhost;Port=5433;Username=postgres;Password=123456;Database=QLGiaoVien;";
            _db = new DatabaseHelper(connString);
            _repo = new Repository(connString);


            tabPage1.Text = "Khoa";
              tabPage2.Text = "Giáo Viên";
              tabPage3.Text = "Bảng Lương";
            LoadKhoa();
            LoadGiaoVien();
            LoadBangLuong();
        }

        private void LoadKhoa()
        {
            var dt = _db.GetData("SELECT * FROM khoa;");
            dataGridKhoa.DataSource = dt;
        }

        private void LoadGiaoVien()
        {
            var dt = _db.GetData("SELECT * FROM giaovien;");
            dataGridGiaoVien.DataSource = dt;
        }

        private void LoadBangLuong()
        {
            var dt = _db.GetData("SELECT * FROM bangluong;");
            dataGridLuong.DataSource = dt;
        }

        private void AddBtn(object sender, EventArgs e)
        {

            switch (tabControl1.SelectedIndex)
            {
                case 0: AddKhoa(); break;
                case 1: AddGiaoVien(); break;
                case 2: AddLuong(); break;
            }
        }

        private void EditBtn(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: EditKhoa(); break;
                case 1: EditGiaoVien(); break;
                case 2: EditLuong(); break;
            }
        }

        private void DeleteBtn(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: DeleteKhoa(); break;
                case 1: DeleteGiaoVien(); break;
                case 2: DeleteLuong(); break;
            }
        }
        private void AddKhoa()
        {
            using (var form = new KhoaForm(_db))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var khoa = form.EnteredKhoa;

                    string sql = @"INSERT INTO Khoa (ten_khoa, so_dien_thoai, dia_chi)
                           VALUES (@ten_khoa, @so_dien_thoai, @dia_chi)";

                    _db.Execute(sql,
                        new Npgsql.NpgsqlParameter("@ten_khoa", khoa.TenKhoa),
                        new Npgsql.NpgsqlParameter("@so_dien_thoai", khoa.SoDienThoai),
                        new Npgsql.NpgsqlParameter("@dia_chi", khoa.DiaChi)
                    );

                    LoadKhoa();
                }
            }
        }

        private void EditKhoa()
        {
            if (dataGridKhoa.CurrentRow == null) return;

            var khoa = new Khoa
            {
                Id = Convert.ToInt32(dataGridKhoa.CurrentRow.Cells["khoa_id"].Value),
                TenKhoa = dataGridKhoa.CurrentRow.Cells["ten_khoa"].Value.ToString(),
                SoDienThoai = dataGridKhoa.CurrentRow.Cells["so_dien_thoai"].Value.ToString(),
                DiaChi = dataGridKhoa.CurrentRow.Cells["dia_chi"].Value.ToString()
            };

            using (var form = new KhoaForm(_db, khoa))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    khoa = form.EnteredKhoa;

                    string sql = @"UPDATE Khoa
                           SET ten_khoa = @ten_khoa,
                               so_dien_thoai = @so_dien_thoai,
                               dia_chi = @dia_chi
                           WHERE khoa_id = @khoa_id";

                    _db.Execute(sql,
                        new Npgsql.NpgsqlParameter("@khoa_id", khoa.Id),
                        new Npgsql.NpgsqlParameter("@ten_khoa", khoa.TenKhoa),
                        new Npgsql.NpgsqlParameter("@so_dien_thoai", khoa.SoDienThoai),
                        new Npgsql.NpgsqlParameter("@dia_chi", khoa.DiaChi)
                    );

                    LoadKhoa();
                }
            }
        }

        private void DeleteKhoa()
        {
            if (dataGridKhoa.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idKhoa = Convert.ToInt32(dataGridKhoa.CurrentRow.Cells["khoa_id"].Value);

            var confirm = MessageBox.Show("Are you sure you want to delete this record?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string sql = "DELETE FROM Khoa WHERE khoa_id = @khoa_id";

                _db.Execute(sql, new Npgsql.NpgsqlParameter("@khoa_id", idKhoa));

                MessageBox.Show("Record deleted successfully.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadKhoa();
            }
        }

        private void AddGiaoVien()
        {
            using (var form = new EditGiaoVienForm(_db))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var gv = form.EnteredGiaoVien;


                    string sql = @"INSERT INTO GiaoVien (ho_ten, ngay_sinh, gioi_tinh, hoc_vi, luong, khoa_id)
               VALUES (@ho_ten, @ngay_sinh, @gioi_tinh, @hoc_vi, @luong, @khoa_id)";

                    _db.Execute(sql,
                        new NpgsqlParameter("@ho_ten", gv.TenGV),
                        new NpgsqlParameter("@ngay_sinh", gv.NgaySinh),
                        new NpgsqlParameter("@gioi_tinh", gv.GioiTinh),
                        new NpgsqlParameter("@hoc_vi", gv.HocVi),
                        new NpgsqlParameter("@luong", gv.Luong),
                        new NpgsqlParameter("@khoa_id", gv.KhoaId)
                    );


                    LoadGiaoVien();
                }
            }
        }

        private void EditGiaoVien()
        {
            if (dataGridGiaoVien.CurrentRow == null) return;

            var gv = new GiaoVien
            {
                Id = Convert.ToInt32(dataGridGiaoVien.CurrentRow.Cells["giaovien_id"].Value),
                TenGV = dataGridGiaoVien.CurrentRow.Cells["ho_ten"].Value.ToString(),
                NgaySinh = Convert.ToDateTime(dataGridGiaoVien.CurrentRow.Cells["ngay_sinh"].Value),
                GioiTinh = dataGridGiaoVien.CurrentRow.Cells["gioi_tinh"].Value.ToString(),
                HocVi = dataGridGiaoVien.CurrentRow.Cells["hoc_vi"].Value.ToString(),
                Luong = Convert.ToDecimal(dataGridGiaoVien.CurrentRow.Cells["luong"].Value),
                KhoaId = Convert.ToInt32(dataGridGiaoVien.CurrentRow.Cells["khoa_id"].Value)
            };

            using (var f = new EditGiaoVienForm(_db, gv))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    gv = f.EnteredGiaoVien;

                    string sql = @"UPDATE giaovien
                           SET ho_ten = @ho_ten,
                               ngay_sinh = @ngay_sinh,
                               gioi_tinh = @gioi_tinh,
                               hoc_vi = @hoc_vi,
                               luong = @luong,
                               khoa_id = @khoa_id
                           WHERE giaovien_id = @giaovien_id";

                    _db.Execute(sql,
                        new Npgsql.NpgsqlParameter("@giaovien_id", gv.Id),
                        new Npgsql.NpgsqlParameter("@ho_ten", gv.TenGV),
                        new Npgsql.NpgsqlParameter("@ngay_sinh", gv.NgaySinh),
                        new Npgsql.NpgsqlParameter("@gioi_tinh", gv.GioiTinh),
                        new Npgsql.NpgsqlParameter("@hoc_vi", gv.HocVi),
                        new Npgsql.NpgsqlParameter("@luong", gv.Luong),
                        new Npgsql.NpgsqlParameter("@khoa_id", gv.KhoaId)
                    );

                    LoadGiaoVien();
                }
            }
        }

        private void DeleteGiaoVien()
        {
            if (dataGridGiaoVien.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idGiaoVien = Convert.ToInt32(dataGridGiaoVien.CurrentRow.Cells["giaovien_id"].Value);

            var confirm = MessageBox.Show("Are you sure you want to delete this record?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string sql = "DELETE FROM GiaoVien WHERE giaovien_id = @giaovien_id";

                _db.Execute(sql, new Npgsql.NpgsqlParameter("@giaovien_id", idGiaoVien));

                MessageBox.Show("Record deleted successfully.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadGiaoVien(); // refresh grid
            }
        }
        private void AddLuong()
        {
            using (var form = new LuongForm(_db))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var luong = form.EnteredLuong;

                    string sql = @"INSERT INTO bangluong (giaovien_id, thang, nam, luong_coban, phucap)
               VALUES (@giaovien_id, @thang, @nam, @luong_coban, @phucap)";
                    _db.Execute(sql,
                        new NpgsqlParameter("@giaovien_id", luong.GiaoVienId),
                        new NpgsqlParameter("@thang", luong.Thang),
                        new NpgsqlParameter("@nam", luong.Nam),
                        new NpgsqlParameter("@luong_coban", luong.LuongCoBan),
                        new NpgsqlParameter("@phucap", luong.PhuCap)
                    );

                    LoadBangLuong();
                }
            }
        }

        private void EditLuong()
        {
            if (dataGridLuong.CurrentRow == null) return;

            var luong = new Luong
            {
                BangLuongId = Convert.ToInt32(dataGridLuong.CurrentRow.Cells["bangluong_id"].Value),
                GiaoVienId = Convert.ToInt32(dataGridLuong.CurrentRow.Cells["giaovien_id"].Value),
                Thang = Convert.ToInt32(dataGridLuong.CurrentRow.Cells["thang"].Value),
                Nam = Convert.ToInt32(dataGridLuong.CurrentRow.Cells["nam"].Value),
                LuongCoBan = Convert.ToDecimal(dataGridLuong.CurrentRow.Cells["luong_coban"].Value),
                PhuCap = Convert.ToDecimal(dataGridLuong.CurrentRow.Cells["phucap"].Value),
            };

            using (var form = new LuongForm(_db, luong))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    luong = form.EnteredLuong;

                    string sql = @"UPDATE bangluong
                                   SET giaovien_id = @giaovien_id,
                                       thang = @thang,
                                       nam = @nam,
                                       luong_coban = @luong_coban,
                                       phucap = @phucap
                                   WHERE bangluong_id = @bangluong_id";

                    _db.Execute(sql,
                        new NpgsqlParameter("@bangluong_id", luong.BangLuongId),
                        new NpgsqlParameter("@giaovien_id", luong.GiaoVienId),
                        new NpgsqlParameter("@thang", luong.Thang),
                        new NpgsqlParameter("@nam", luong.Nam),
                        new NpgsqlParameter("@luong_coban", luong.LuongCoBan),
                        new NpgsqlParameter("@phucap", luong.PhuCap)
                    );

                    LoadBangLuong();
                }
            }
        }

        private void DeleteLuong()
        {
            if (dataGridLuong.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idLuong = Convert.ToInt32(dataGridLuong.CurrentRow.Cells["bangluong_id"].Value);

            var confirm = MessageBox.Show("Are you sure you want to delete this record?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string sql = "DELETE FROM bangluong WHERE bangluong_id = @bangluong_id";

                _db.Execute(sql, new NpgsqlParameter("@bangluong_id", idLuong));

                MessageBox.Show("Record deleted successfully.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadBangLuong();
            }
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            string searchText = textFindField.Text.Trim();
            if (string.IsNullOrEmpty(searchText)) return;

            switch (tabControl1.SelectedIndex)
            {
                case 0: // Khoa
                    string sqlKhoa = @"SELECT * FROM khoa WHERE ten_khoa ILIKE @searchText";
                    _db.ExecuteQuery(sqlKhoa, new Npgsql.NpgsqlParameter("@searchText", $"%{searchText}%"), dataGridKhoa);
                    break;

                case 1: // GiaoVien
                    string sqlGiaoVien = @"SELECT * FROM giaovien WHERE ho_ten ILIKE @searchText";
                    _db.ExecuteQuery(sqlGiaoVien, new Npgsql.NpgsqlParameter("@searchText", $"%{searchText}%"), dataGridGiaoVien);
                    break;

                case 2: // Luong
                    string sqlLuong = @"SELECT * FROM bangluong WHERE bangluong_id::text ILIKE @searchText";
                    _db.ExecuteQuery(sqlLuong, new Npgsql.NpgsqlParameter("@searchText", $"%{searchText}%"), dataGridLuong);
                    break;

                default:
                    MessageBox.Show("Invalid tab index.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
