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

            if (gv != null)
            {
                // Editing mode
                _id = gv.Id;
                txtTenGiaoVien.Text = gv.TenGV;
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
            }
        }

        private void LoadKhoaToComboBox()
        {
            DataTable dt = _db.GetData("SELECT khoa_id, ten_khoa FROM khoa ORDER BY ten_khoa");
            cbTenKhoa.DataSource = dt;
            cbTenKhoa.DisplayMember = "ten_khoa";
            cbTenKhoa.ValueMember = "khoa_id";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenGiaoVien.Text))
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
                Id = _id ?? 0,
                TenGV = txtTenGiaoVien.Text.Trim(),
                NgaySinh = dateTimePickerNS.Value,
                GioiTinh = txtGioiTinh.Text.Trim(),
                HocVi = txtHocVi.Text.Trim(),
                Luong = numLuong.Value,
                KhoaId = Convert.ToInt32(cbTenKhoa.SelectedValue)
            };

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }


    //public partial class EditGiaoVienForm : Form
    //{
    //    public GiaoVien EnteredGiaoVien { get; private set; }

    //    private readonly int? _id;
    //    private readonly DatabaseHelper _db;

    //    public EditGiaoVienForm(DatabaseHelper db, GiaoVien gv = null)
    //    {
    //        InitializeComponent();
    //        _db = db;
    //        LoadKhoaToComboBox();
    //    }

    //    private void LoadKhoaToComboBox()
    //    {
    //        DataTable dt = _db.GetData("SELECT khoa_id, ten_khoa FROM khoa ORDER BY khoa");
    //        cbTenKhoa.DataSource = dt;
    //        cbTenKhoa.DisplayMember = "ten_khoa";
    //        cbTenKhoa.ValueMember = "khoa_id";
    //    }

    //    private void btnOK_Click(object sender, EventArgs e)
    //    {
    //        if (string.IsNullOrWhiteSpace(txtTenGiaoVien.Text))
    //        {
    //            MessageBox.Show("Tên giáo viên không được để trống", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    //            return;
    //        }

    //        if (cbTenKhoa.SelectedValue == null)
    //        {
    //            MessageBox.Show("Vui lòng chọn Khoa", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    //            return;
    //        }

    //        EnteredGiaoVien = new GiaoVien
    //        {
    //            Id = _id ?? 0,
    //            TenGV = txtTenGiaoVien.Text.Trim(),
    //            NgaySinh = dateTimePickerNS.Value,
    //            GioiTinh = txtGioiTinh.Text.Trim(),
    //            HocVi = txtHocVi.Text.Trim(),
    //            Luong = numLuong.Value,
    //            KhoaId = Convert.ToInt32(cbTenKhoa.SelectedValue)
    //        };

    //        DialogResult = DialogResult.OK;
    //    }

    //    private void btnCancel_Click(object sender, EventArgs e)
    //    {
    //        DialogResult = DialogResult.Cancel;
    //    }
    //}


}
