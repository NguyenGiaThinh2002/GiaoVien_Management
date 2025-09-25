namespace QuanLyGiaoVien
{
    partial class menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridKhoa = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridGiaoVien = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridLuong = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textFindField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.findButton = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridKhoa)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGiaoVien)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLuong)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ItemSize = new System.Drawing.Size(90, 35);
            this.tabControl1.Location = new System.Drawing.Point(20, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160, 540);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridKhoa);
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(1152, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Khoa";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridKhoa
            // 
            this.dataGridKhoa.BackgroundColor = System.Drawing.Color.White;
            this.dataGridKhoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridKhoa.Location = new System.Drawing.Point(50, 20);
            this.dataGridKhoa.Name = "dataGridKhoa";
            this.dataGridKhoa.RowHeadersWidth = 60;
            this.dataGridKhoa.RowTemplate.Height = 30;
            this.dataGridKhoa.Size = new System.Drawing.Size(1050, 470);
            this.dataGridKhoa.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridGiaoVien);
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage2.Size = new System.Drawing.Size(1152, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Giao Vien";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridGiaoVien
            // 
            this.dataGridGiaoVien.BackgroundColor = System.Drawing.Color.White;
            this.dataGridGiaoVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGiaoVien.Location = new System.Drawing.Point(50, 20);
            this.dataGridGiaoVien.Name = "dataGridGiaoVien";
            this.dataGridGiaoVien.RowHeadersWidth = 60;
            this.dataGridGiaoVien.RowTemplate.Height = 30;
            this.dataGridGiaoVien.Size = new System.Drawing.Size(1050, 470);
            this.dataGridGiaoVien.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridLuong);
            this.tabPage3.Location = new System.Drawing.Point(4, 39);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage3.Size = new System.Drawing.Size(1152, 497);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Luong";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridLuong
            // 
            this.dataGridLuong.BackgroundColor = System.Drawing.Color.White;
            this.dataGridLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLuong.Location = new System.Drawing.Point(50, 20);
            this.dataGridLuong.Name = "dataGridLuong";
            this.dataGridLuong.RowHeadersWidth = 60;
            this.dataGridLuong.RowTemplate.Height = 30;
            this.dataGridLuong.Size = new System.Drawing.Size(1050, 470);
            this.dataGridLuong.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(20, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Nhập";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSalmon;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(130, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Xuất";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DodgerBlue;
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(20, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "Thêm";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.AddBtn);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(130, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 40);
            this.button4.TabIndex = 4;
            this.button4.Text = "Sửa";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.EditBtn);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(240, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 40);
            this.button5.TabIndex = 5;
            this.button5.Text = "Xoá";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.DeleteBtn);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(350, 10);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 40);
            this.button6.TabIndex = 6;
            this.button6.Text = "Làm mới";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // textFindField
            // 
            this.textFindField.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textFindField.Location = new System.Drawing.Point(250, 15);
            this.textFindField.Name = "textFindField";
            this.textFindField.Size = new System.Drawing.Size(300, 30);
            this.textFindField.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(150, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tìm kiếm";
            // 
            // findButton
            // 
            this.findButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.findButton.ForeColor = System.Drawing.Color.Black;
            this.findButton.Location = new System.Drawing.Point(560, 15);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(100, 40);
            this.findButton.TabIndex = 9;
            this.findButton.Text = "Tìm";
            this.findButton.UseVisualStyleBackColor = false;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.LightGray;
            this.panelTop.Controls.Add(this.button1);
            this.panelTop.Controls.Add(this.button2);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.textFindField);
            this.panelTop.Controls.Add(this.findButton);
            this.panelTop.Location = new System.Drawing.Point(20, 20);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1160, 70);
            this.panelTop.TabIndex = 10;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.LightGray;
            this.panelBottom.Controls.Add(this.button3);
            this.panelBottom.Controls.Add(this.button4);
            this.panelBottom.Controls.Add(this.button5);
            this.panelBottom.Controls.Add(this.button6);
            this.panelBottom.Location = new System.Drawing.Point(20, 650);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1160, 60);
            this.panelBottom.TabIndex = 11;
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "menu";
            this.Text = "Quản Lý Giáo Viên";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridKhoa)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGiaoVien)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLuong)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridKhoa;
        private System.Windows.Forms.DataGridView dataGridGiaoVien;
        private System.Windows.Forms.DataGridView dataGridLuong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textFindField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;


    }

}

