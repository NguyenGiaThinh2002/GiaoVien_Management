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
           //// string tenKhoa = txtKhoaName.Text;
           // _repo.Execute($"INSERT INTO khoa(tenkhoa) VALUES('{tenKhoa}')");
           // LoadKhoa();
        }

        private void EditKhoa()
        {
            ////if (dataGridViewKhoa.CurrentRow == null) return;
            ////int id = Convert.ToInt32(dataGridViewKhoa.CurrentRow.Cells["id"].Value);
            ////string tenKhoa = txtKhoaName.Text;
            //_repo.Execute($"UPDATE khoa SET tenkhoa = '{tenKhoa}' WHERE id = {id}");
            //LoadKhoa();
        }

        private void DeleteKhoa()
        {
            //if (dataGridKhoa.CurrentRow == null) return;
            //int id = Convert.ToInt32(dataGridVKhoa.CurrentRow.Cells["id"].Value);
            //_repo.Execute($"DELETE FROM khoa WHERE id = {id}");
            //LoadKhoa();
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
            //decimal soTien = Convert.ToDecimal(txtLuong.Text);
            //_repo.Execute($"INSERT INTO luong(sotien) VALUES({soTien})");
            //LoadLuong();
        }

        private void EditLuong()
        {
            //if (dataGridViewLuong.CurrentRow == null) return;
            //int id = Convert.ToInt32(dataGridViewLuong.CurrentRow.Cells["id"].Value);
            //decimal soTien = Convert.ToDecimal(txtLuong.Text);
            //_repo.Execute($"UPDATE luong SET sotien = {soTien} WHERE id = {id}");
            //LoadLuong();
        }

        private void DeleteLuong()
        {
            //if (dataGridViewLuong.CurrentRow == null) return;
            //int id = Convert.ToInt32(dataGridViewLuong.CurrentRow.Cells["id"].Value);
            //_repo.Execute($"DELETE FROM luong WHERE id = {id}");
            //LoadLuong();
        }


    }
}
