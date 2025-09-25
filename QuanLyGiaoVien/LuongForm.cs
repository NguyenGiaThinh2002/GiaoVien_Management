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
    public partial class LuongForm : Form
    {
        private readonly DatabaseHelper _db;
        private Luong _luong;
        public Luong EnteredLuong { get; private set; }

        public LuongForm(DatabaseHelper db, Luong luong = null)
        {
            InitializeComponent();
            _db = db;
            _luong = luong ?? new Luong();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Form setup
            this.Text = _luong.BangLuongId == 0 ? "Add Luong" : "Edit Luong";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Bind data to existing controls
            txtTenGiaoVien.Text = _luong.GiaoVienId.ToString(); // Display giaovien_id or fetch name if needed
            numThang.Value = _luong.Thang;
            numNam.Value = _luong.Nam;
            numLuongCoban.Value = _luong.LuongCoBan;
            numLuongPhuCap.Value = _luong.PhuCap;

            // Event handlers
            btnOK.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTenGiaoVien.Text))
                {
                    MessageBox.Show("Giáo viên ID is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtTenGiaoVien.Text, out int giaovienId))
                {
                    MessageBox.Show("Invalid Giáo viên ID.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                EnteredLuong = new Luong
                {
                    BangLuongId = _luong.BangLuongId,
                    GiaoVienId = giaovienId,
                    Thang = (int)numThang.Value,
                    Nam = (int)numNam.Value,
                    LuongCoBan = numLuongCoban.Value,
                    PhuCap = numLuongPhuCap.Value,
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            // Assuming a Cancel button exists in the designer; if not, remove this
            if (this.Controls.ContainsKey("btnCancel"))
            {
                Button btnCancel = this.Controls["btnCancel"] as Button;
                if (btnCancel != null)
                {
                    btnCancel.Click += (s, e) =>
                    {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    };
                }
            }
        }

    }

}
