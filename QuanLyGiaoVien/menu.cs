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
        private void ImportBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Title = "Select a file to import";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string[] lines = System.IO.File.ReadAllLines(filePath);
                    DataGridView dataGrid = null;
                    var skippedLines = new System.Collections.Generic.List<string>();

                    try
                    {
                        // Determine the target DataGridView and table name based on the active tab
                        string tableName = "";
                        string idColumn = ""; // ID column name for conflict clause
                        switch (tabControl1.SelectedIndex)
                        {
                            case 0:
                                dataGrid = dataGridKhoa;
                                tableName = "Khoa";
                                idColumn = "khoa_id";
                                break;
                            case 1:
                                dataGrid = dataGridGiaoVien;
                                tableName = "GiaoVien";
                                idColumn = "giaovien_id";
                                break;
                            case 2:
                                dataGrid = dataGridLuong;
                                tableName = "bangluong";
                                idColumn = "bangluong_id";
                                break;
                            default:
                                throw new ArgumentException("Invalid tab index");
                        }

                        // Get or create a DataTable with the existing column structure
                        DataTable dataTable = dataGrid.DataSource as DataTable ?? new DataTable();
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (DataGridViewColumn column in dataGrid.Columns)
                            {
                                dataTable.Columns.Add(column.Name, column.ValueType ?? typeof(string));
                            }
                        }

                        // Clear existing rows but keep columns
                        dataTable.Rows.Clear();

                        // Prepare upsert SQL using ON CONFLICT
                        var columns = dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
                        var parameters = columns.Select(c => $"@{c}").ToArray();
                        string upsertSql = $"INSERT INTO {tableName} ({string.Join(",", columns)}) " +
                                          $"VALUES ({string.Join(",", parameters)}) " +
                                          $"ON CONFLICT ({idColumn}) DO UPDATE SET " +
                                          $"{string.Join(",", columns.Skip(1).Select(c => $"{c} = EXCLUDED.{c}"))}";

                        // Process each line and sync with database
                        foreach (string line in lines)
                        {
                            string[] fields = line.Split(',');
                            if (fields.Length != dataTable.Columns.Count)
                            {
                                skippedLines.Add(line);
                                continue;
                            }

                            var paramsList = new System.Collections.Generic.List<Npgsql.NpgsqlParameter>();
                            var convertedFields = new object[fields.Length];
                            bool skipLine = false;

                            for (int i = 0; i < fields.Length; i++)
                            {
                                object value = fields[i];
                                string errorMessage = null;

                                if (dataTable.Columns[i].DataType == typeof(int))
                                {
                                    if (!int.TryParse(fields[i], out int intValue))
                                    {
                                        errorMessage = $"Invalid integer for {dataTable.Columns[i].ColumnName}: '{fields[i]}'";
                                    }
                                    else
                                    {
                                        value = intValue;
                                    }
                                }
                                else if (dataTable.Columns[i].DataType == typeof(DateTime))
                                {
                                    if (!DateTime.TryParse(fields[i], out DateTime dateValue))
                                    {
                                        errorMessage = $"Invalid date for {dataTable.Columns[i].ColumnName}: '{fields[i]}'";
                                    }
                                    else
                                    {
                                        value = dateValue;
                                    }
                                }
                                else if (dataTable.Columns[i].DataType == typeof(decimal))
                                {
                                    if (!decimal.TryParse(fields[i], out decimal decimalValue))
                                    {
                                        errorMessage = $"Invalid decimal for {dataTable.Columns[i].ColumnName}: '{fields[i]}'";
                                    }
                                    else
                                    {
                                        value = decimalValue;
                                    }
                                }
                                else // Default to string or other types
                                {
                                    value = fields[i] ?? string.Empty;
                                }

                                if (errorMessage != null)
                                {
                                    skippedLines.Add($"{line} (Error: {errorMessage})");
                                    skipLine = true;
                                    break;
                                }

                                convertedFields[i] = value;
                                paramsList.Add(new Npgsql.NpgsqlParameter($"@{dataTable.Columns[i].ColumnName}", value ?? DBNull.Value));
                            }

                            if (skipLine) continue;

                            // Execute upsert
                            _db.Execute(upsertSql, paramsList.ToArray());

                            // Add to DataTable with converted types
                            dataTable.Rows.Add(convertedFields);
                        }

                        // Update DataGridView with the new data
                        dataGrid.DataSource = dataTable;

                        // Show summary of skipped lines
                        if (skippedLines.Count > 0)
                        {
                            MessageBox.Show($"Import completed with {skippedLines.Count} lines skipped due to invalid data:\n{string.Join("\n", skippedLines)}", "Import Summary",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        switch (tabControl1.SelectedIndex)
                        {
                            case 0:
                                LoadKhoa();
                                break;
                            case 1:
                                LoadGiaoVien();
                                break;
                            case 2:
                                LoadBangLuong();
                                break;
                            default:
                                throw new ArgumentException("Invalid tab index");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error during import: {ex.Message}", "Import Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ExportBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Save as";

                // Set default filename based on the active tab
                string fileName = "Data.txt";
                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        fileName = "KhoaData.txt";
                        break;
                    case 1:
                        fileName = "GiaoVienData.txt";
                        break;
                    case 2:
                        fileName = "LuongData.txt";
                        break;
                }
                saveFileDialog.FileName = fileName;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    DataGridView dataGrid = null;

                    // Determine the target DataGridView based on the active tab
                    switch (tabControl1.SelectedIndex)
                    {
                        case 0:
                            dataGrid = dataGridKhoa;
                            break;
                        case 1:
                            dataGrid = dataGridGiaoVien;
                            break;
                        case 2:
                            dataGrid = dataGridLuong;
                            break;
                        default:
                            throw new ArgumentException("Invalid tab index");
                    }

                    // Collect data from DataGridView rows
                    var lines = new System.Collections.Generic.List<string>();
                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            var fields = row.Cells.Cast<DataGridViewCell>()
                                .Select(cell => cell.Value?.ToString() ?? string.Empty);
                            lines.Add(string.Join(",", fields));
                        }
                    }

                    // Write data to the file
                    System.IO.File.WriteAllLines(filePath, lines.ToArray());
                }
            }
        }
        private string GetGiaovienNameById(int? giaovienId)
        {
            if (!giaovienId.HasValue)
            {
                return "N/A";
            }

            try
            {
                var parameters = new[] { new Npgsql.NpgsqlParameter("@id", giaovienId.Value) };
                var query = _db.ExecuteCustomQuery("SELECT ho_ten FROM GiaoVien WHERE giaovien_id = @id", parameters);
                if (query.Rows.Count > 0)
                {
                    return query.Rows[0]["ho_ten"].ToString() ?? "Unknown";
                }
                return "N/A";
            }
            catch (Exception)
            {
                return "N/A";
            }
        }

        private void TotalCoBanBtn_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2 && dataGridLuong != null)
            {
                decimal total = 0;
                int count = 0;
                decimal? minValue = null;
                decimal? maxValue = null;
                int? minRowIndex = null;
                int? maxRowIndex = null;

                try
                {
                    for (int i = 0; i < dataGridLuong.Rows.Count; i++)
                    {
                        var row = dataGridLuong.Rows[i];
                        if (!row.IsNewRow)
                        {
                            var cellValue = row.Cells["luong_coban"].Value;
                            if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal value))
                            {
                                total += value;
                                count++;
                                if (!minValue.HasValue || value < minValue)
                                {
                                    minValue = value;
                                    minRowIndex = i + 1; // 1-based index for user display
                                }
                                if (!maxValue.HasValue || value > maxValue)
                                {
                                    maxValue = value;
                                    maxRowIndex = i + 1; // 1-based index for user display
                                }
                            }
                        }
                    }

                    var avg = count > 0 ? total / count : 0;
                    System.Globalization.CultureInfo vietnameseCulture = new System.Globalization.CultureInfo("vi-VN");
                    var message = new System.Text.StringBuilder();
                    message.AppendLine("Thống Kê Lương Cơ Bản:");
                    message.AppendLine($"Tổng: {total.ToString("N2", vietnameseCulture)}");
                    message.AppendLine($"Trung Bình: {avg.ToString("N2", vietnameseCulture)}");
                    message.AppendLine($"Số Dòng: {count}");

                    // Get teacher names for min and max rows
                    string minTeacherName = "N/A";
                    string maxTeacherName = "N/A";
                    if (minRowIndex.HasValue && maxRowIndex.HasValue)
                    {
                        var minRow = dataGridLuong.Rows[minRowIndex.Value - 1]; // Convert back to 0-based
                        var maxRow = dataGridLuong.Rows[maxRowIndex.Value - 1]; // Convert back to 0-based
                        var minGiaovienId = minRow.Cells["giaovien_id"].Value as int?;
                        var maxGiaovienId = maxRow.Cells["giaovien_id"].Value as int?;
                        minTeacherName = GetGiaovienNameById(minGiaovienId);
                        maxTeacherName = GetGiaovienNameById(maxGiaovienId);
                    }

                    message.AppendLine($"Giáo viên Lương Thấp Nhất: {(minValue.HasValue ? $"{minTeacherName} - {minValue.Value.ToString("N2", vietnameseCulture)} " : "N/A")}");
                    message.AppendLine($"Giáo viên Lương Cao Nhất: {(maxValue.HasValue ? $"{maxTeacherName} - {maxValue.Value.ToString("N2", vietnameseCulture)} " : "N/A")}");

                    if (count == 0)
                    {
                        message.AppendLine("Không có dữ liệu hợp lệ.");
                    }
                    MessageBox.Show(message.ToString(), "Thống Kê Tính Toán",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tính toán: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chuyển đến tab Luong và đảm bảo dữ liệu đã được tải.", "Bối Cảnh Không Hợp Lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TotalPhuCapBtn_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2 && dataGridLuong != null)
            {
                decimal total = 0;
                int count = 0;
                decimal? minValue = null;
                decimal? maxValue = null;
                int? minRowIndex = null;
                int? maxRowIndex = null;

                try
                {
                    for (int i = 0; i < dataGridLuong.Rows.Count; i++)
                    {
                        var row = dataGridLuong.Rows[i];
                        if (!row.IsNewRow)
                        {
                            var cellValue = row.Cells["phucap"].Value;
                            if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal value))
                            {
                                total += value;
                                count++;
                                if (!minValue.HasValue || value < minValue)
                                {
                                    minValue = value;
                                    minRowIndex = i + 1; // 1-based index for user display
                                }
                                if (!maxValue.HasValue || value > maxValue)
                                {
                                    maxValue = value;
                                    maxRowIndex = i + 1; // 1-based index for user display
                                }
                            }
                        }
                    }

                    var avg = count > 0 ? total / count : 0;
                    System.Globalization.CultureInfo vietnameseCulture = new System.Globalization.CultureInfo("vi-VN");
                    var message = new System.Text.StringBuilder();
                    message.AppendLine("Thống Kê Phụ Cấp:");
                    message.AppendLine($"Tổng: {total.ToString("N2", vietnameseCulture)}");
                    message.AppendLine($"Trung Bình: {avg.ToString("N2", vietnameseCulture)}");
                    message.AppendLine($"Số Dòng: {count}");

                    // Get teacher names for min and max rows
                    string minTeacherName = "N/A";
                    string maxTeacherName = "N/A";
                    if (minRowIndex.HasValue && maxRowIndex.HasValue)
                    {
                        var minRow = dataGridLuong.Rows[minRowIndex.Value - 1]; // Convert back to 0-based
                        var maxRow = dataGridLuong.Rows[maxRowIndex.Value - 1]; // Convert back to 0-based
                        var minGiaovienId = minRow.Cells["giaovien_id"].Value as int?;
                        var maxGiaovienId = maxRow.Cells["giaovien_id"].Value as int?;
                        minTeacherName = GetGiaovienNameById(minGiaovienId);
                        maxTeacherName = GetGiaovienNameById(maxGiaovienId);
                    }

                    message.AppendLine($"Giáo viên Lương Thấp Nhất: {(minValue.HasValue ? $"{minTeacherName} - {minValue.Value.ToString("N2", vietnameseCulture)} " : "N/A")}");
                    message.AppendLine($"Giáo viên Lương Cao Nhất: {(maxValue.HasValue ? $"{maxTeacherName} - {maxValue.Value.ToString("N2", vietnameseCulture)} " : "N/A")}");

                    if (count == 0)
                    {
                        message.AppendLine("Không có dữ liệu hợp lệ.");
                    }
                    MessageBox.Show(message.ToString(), "Thống Kê Tính Toán",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tính toán: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chuyển đến tab Luong và đảm bảo dữ liệu đã được tải.", "Bối Cảnh Không Hợp Lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TotalThuNhatBtn_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2 && dataGridLuong != null)
            {
                decimal total = 0;
                int count = 0;
                decimal? minValue = null;
                decimal? maxValue = null;
                int? minRowIndex = null;
                int? maxRowIndex = null;

                try
                {
                    for (int i = 0; i < dataGridLuong.Rows.Count; i++)
                    {
                        var row = dataGridLuong.Rows[i];
                        if (!row.IsNewRow)
                        {
                            var cellValue = row.Cells["thunhap"].Value;
                            if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal value))
                            {
                                total += value;
                                count++;
                                if (!minValue.HasValue || value < minValue)
                                {
                                    minValue = value;
                                    minRowIndex = i + 1; // 1-based index for user display
                                }
                                if (!maxValue.HasValue || value > maxValue)
                                {
                                    maxValue = value;
                                    maxRowIndex = i + 1; // 1-based index for user display
                                }
                            }
                        }
                    }

                    var avg = count > 0 ? total / count : 0;
                    System.Globalization.CultureInfo vietnameseCulture = new System.Globalization.CultureInfo("vi-VN");
                    var message = new System.Text.StringBuilder();
                    message.AppendLine("Thống Kê Thu Nhập:");
                    message.AppendLine($"Tổng: {total.ToString("N2", vietnameseCulture)}");
                    message.AppendLine($"Trung Bình: {avg.ToString("N2", vietnameseCulture)}");
                    message.AppendLine($"Số Dòng: {count}");

                    // Get teacher names for min and max rows
                    string minTeacherName = "N/A";
                    string maxTeacherName = "N/A";
                    if (minRowIndex.HasValue && maxRowIndex.HasValue)
                    {
                        var minRow = dataGridLuong.Rows[minRowIndex.Value - 1]; // Convert back to 0-based
                        var maxRow = dataGridLuong.Rows[maxRowIndex.Value - 1]; // Convert back to 0-based
                        var minGiaovienId = minRow.Cells["giaovien_id"].Value as int?;
                        var maxGiaovienId = maxRow.Cells["giaovien_id"].Value as int?;
                        minTeacherName = GetGiaovienNameById(minGiaovienId);
                        maxTeacherName = GetGiaovienNameById(maxGiaovienId);
                    }

                    message.AppendLine($"Giáo viên Lương Thấp Nhất: {(minValue.HasValue ? $"{minTeacherName} - {minValue.Value.ToString("N2", vietnameseCulture)} " : "N/A")}");
                    message.AppendLine($"Giáo viên Lương Cao Nhất: {(maxValue.HasValue ? $"{maxTeacherName} - {maxValue.Value.ToString("N2", vietnameseCulture)} " : "N/A")}");

                    if (count == 0)
                    {
                        message.AppendLine("Không có dữ liệu hợp lệ.");
                    }
                    MessageBox.Show(message.ToString(), "Thống Kê Tính Toán",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tính toán: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chuyển đến tab Luong và đảm bảo dữ liệu đã được tải.", "Bối Cảnh Không Hợp Lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}
