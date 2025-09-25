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
    public partial class KhoaForm : Form
    {
        private readonly DatabaseHelper _db;
        private Khoa _khoa;
        public Khoa EnteredKhoa { get; private set; }

        public KhoaForm(DatabaseHelper db, Khoa khoa = null)
        {
            InitializeComponent();
            _db = db;
            _khoa = khoa ?? new Khoa();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Form setup
            this.Text = _khoa.Id == 0 ? "Add Khoa" : "Edit Khoa";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Bind data to existing controls
            txtTenKhoa.Text = _khoa.TenKhoa;
            txtSDT.Text = _khoa.SoDienThoai;
            txtDiaChi.Text = _khoa.DiaChi;

            // Event handlers
            btnOK.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTenKhoa.Text))
                {
                    MessageBox.Show("Tên Khoa is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                EnteredKhoa = new Khoa
                {
                    Id = _khoa.Id,
                    TenKhoa = txtTenKhoa.Text,
                    SoDienThoai = txtSDT.Text,
                    DiaChi = txtDiaChi.Text
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

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }

}