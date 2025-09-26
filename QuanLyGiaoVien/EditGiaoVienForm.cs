using QuanLyGiaoVien.Helper;
using QuanLyGiaoVien.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGiaoVien
{
    public partial class EditGiaoVienForm : Form
    {
        public GiaoVien EnteredGiaoVien { get; private set; }

        private readonly int? _id;   // will be null for Add
        private readonly DatabaseHelper _db;

        public EditGiaoVienForm(DatabaseHelper db, GiaoVien gv = null)
        {
            InitializeComponent();
            _db = db;

            LoadKhoaToComboBox();
            LoadGiaoVienToComboBox();

            if (gv != null)
            {
                // Editing mode
                _id = gv.Id;
                cbTenGiaoVien.DropDownStyle = ComboBoxStyle.DropDownList; // Selection only
                cbTenGiaoVien.SelectedValue = gv.Id; // Select the existing teacher
                dateTimePickerNS.Value = gv.NgaySinh;
                txtGioiTinh.Text = gv.GioiTinh;
                txtHocVi.Text = gv.HocVi;
                numLuong.Value = gv.Luong;
                cbTenKhoa.SelectedValue = gv.KhoaId;
            }
            else
            {
                // Adding mode
                _id = null;
                cbTenGiaoVien.DropDownStyle = ComboBoxStyle.DropDown; // Allow input
                cbTenGiaoVien.SelectedIndex = -1; // No pre-selection
                cbTenGiaoVien.Text = ""; // Clear text for input
            }
        }

        private void LoadKhoaToComboBox()
        {
            DataTable dt = _db.GetData("SELECT khoa_id, ten_khoa FROM khoa ORDER BY ten_khoa");
            cbTenKhoa.DataSource = dt;
            cbTenKhoa.DisplayMember = "ten_khoa";
            cbTenKhoa.ValueMember = "khoa_id";
        }

        private void LoadGiaoVienToComboBox()
        {
            DataTable dt = _db.GetData("SELECT giaovien_id, ho_ten FROM giaovien ORDER BY ho_ten");
            cbTenGiaoVien.DataSource = dt;
            cbTenGiaoVien.DisplayMember = "ho_ten";
            cbTenGiaoVien.ValueMember = "giaovien_id";
            cbTenGiaoVien.SelectedIndex = -1; // No default selection
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbTenGiaoVien.Text))
            {
                MessageBox.Show("Tên giáo viên không được để trống", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbTenKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khoa", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EnteredGiaoVien = new GiaoVien
            {
                Id = _id ?? 0, // New ID will be assigned later in add mode
                TenGV = cbTenGiaoVien.Text.Trim(), // Use input or selected ho_ten
                NgaySinh = dateTimePickerNS.Value,
                GioiTinh = txtGioiTinh.Text.Trim(),
                HocVi = txtHocVi.Text.Trim(),
                Luong = numLuong.Value,
                KhoaId = Convert.ToInt32(cbTenKhoa.SelectedValue)
            };

            // In edit mode, ensure the ID matches the selected giaovien_id if changed
            if (_id.HasValue && cbTenGiaoVien.SelectedValue != null)
            {
                EnteredGiaoVien.Id = Convert.ToInt32(cbTenGiaoVien.SelectedValue);
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}