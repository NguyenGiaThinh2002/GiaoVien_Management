using System.Windows.Forms;

namespace QuanLyGiaoVien
{
    partial class LuongForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Button btnOK;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numLuongPhuCap = new System.Windows.Forms.NumericUpDown();
            this.numLuongCoban = new System.Windows.Forms.NumericUpDown();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.cbTenGiaoVien = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numLuongPhuCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuongCoban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 16);
            this.lblTitle.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(511, 339);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Luu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ten Giao Vien";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Thang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nam";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Luong co ban";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Luong phu cap";
            // 
            // numLuongPhuCap
            // 
            this.numLuongPhuCap.Location = new System.Drawing.Point(157, 252);
            this.numLuongPhuCap.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numLuongPhuCap.Name = "numLuongPhuCap";
            this.numLuongPhuCap.Size = new System.Drawing.Size(300, 22);
            this.numLuongPhuCap.TabIndex = 16;
            // 
            // numLuongCoban
            // 
            this.numLuongCoban.Location = new System.Drawing.Point(157, 205);
            this.numLuongCoban.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numLuongCoban.Name = "numLuongCoban";
            this.numLuongCoban.Size = new System.Drawing.Size(300, 22);
            this.numLuongCoban.TabIndex = 17;
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(157, 153);
            this.numNam.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(300, 22);
            this.numNam.TabIndex = 19;
            // 
            // numThang
            // 
            this.numThang.Location = new System.Drawing.Point(157, 100);
            this.numThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numThang.Name = "numThang";
            this.numThang.Size = new System.Drawing.Size(300, 22);
            this.numThang.TabIndex = 20;
            // 
            // cbTenGiaoVien
            // 
            this.cbTenGiaoVien.FormattingEnabled = true;
            this.cbTenGiaoVien.Location = new System.Drawing.Point(157, 53);
            this.cbTenGiaoVien.Name = "cbTenGiaoVien";
            this.cbTenGiaoVien.Size = new System.Drawing.Size(300, 24);
            this.cbTenGiaoVien.TabIndex = 21;
            // 
            // LuongForm
            // 
            this.ClientSize = new System.Drawing.Size(630, 389);
            this.Controls.Add(this.cbTenGiaoVien);
            this.Controls.Add(this.numThang);
            this.Controls.Add(this.numNam);
            this.Controls.Add(this.numLuongCoban);
            this.Controls.Add(this.numLuongPhuCap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnOK);
            this.Name = "LuongForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit";
            ((System.ComponentModel.ISupportInitialize)(this.numLuongPhuCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuongCoban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown numLuongPhuCap;
        private NumericUpDown numLuongCoban;
        private NumericUpDown numNam;
        private NumericUpDown numThang;
        private ComboBox cbTenGiaoVien;
    }
}