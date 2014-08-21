namespace QuanLyBanSat
{
    partial class QuanLyNhapHang
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
            this.groupdanhsach = new System.Windows.Forms.GroupBox();
            this.datadanhsach = new System.Windows.Forms.DataGridView();
            this.Groupchitet = new System.Windows.Forms.GroupBox();
            this.datachitiet = new System.Windows.Forms.DataGridView();
            this.groupthongtin = new System.Windows.Forms.GroupBox();
            this.cbnhacc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtthanhtien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datengaynhap = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNhap = new System.Windows.Forms.Button();
            this.BtnXacnhan = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.BtnThoat = new System.Windows.Forms.Button();
            this.groupdanhsach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datadanhsach)).BeginInit();
            this.Groupchitet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datachitiet)).BeginInit();
            this.groupthongtin.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupdanhsach
            // 
            this.groupdanhsach.Controls.Add(this.datadanhsach);
            this.groupdanhsach.Location = new System.Drawing.Point(12, 121);
            this.groupdanhsach.Name = "groupdanhsach";
            this.groupdanhsach.Size = new System.Drawing.Size(535, 267);
            this.groupdanhsach.TabIndex = 0;
            this.groupdanhsach.TabStop = false;
            this.groupdanhsach.Text = "Danh sách đơn nhập";
            // 
            // datadanhsach
            // 
            this.datadanhsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datadanhsach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datadanhsach.Location = new System.Drawing.Point(3, 16);
            this.datadanhsach.Name = "datadanhsach";
            this.datadanhsach.Size = new System.Drawing.Size(529, 248);
            this.datadanhsach.TabIndex = 0;
            this.datadanhsach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datadanhsach_CellContentClick);
            // 
            // Groupchitet
            // 
            this.Groupchitet.Controls.Add(this.datachitiet);
            this.Groupchitet.Location = new System.Drawing.Point(553, 121);
            this.Groupchitet.Name = "Groupchitet";
            this.Groupchitet.Size = new System.Drawing.Size(257, 264);
            this.Groupchitet.TabIndex = 1;
            this.Groupchitet.TabStop = false;
            this.Groupchitet.Text = "Chi tiết nhập hàng";
            // 
            // datachitiet
            // 
            this.datachitiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datachitiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datachitiet.Location = new System.Drawing.Point(3, 16);
            this.datachitiet.Name = "datachitiet";
            this.datachitiet.Size = new System.Drawing.Size(251, 245);
            this.datachitiet.TabIndex = 0;
            // 
            // groupthongtin
            // 
            this.groupthongtin.Controls.Add(this.cbnhacc);
            this.groupthongtin.Controls.Add(this.label4);
            this.groupthongtin.Controls.Add(this.txtthanhtien);
            this.groupthongtin.Controls.Add(this.label3);
            this.groupthongtin.Controls.Add(this.datengaynhap);
            this.groupthongtin.Controls.Add(this.label2);
            this.groupthongtin.Controls.Add(this.txtma);
            this.groupthongtin.Controls.Add(this.label1);
            this.groupthongtin.Location = new System.Drawing.Point(15, 12);
            this.groupthongtin.Name = "groupthongtin";
            this.groupthongtin.Size = new System.Drawing.Size(532, 101);
            this.groupthongtin.TabIndex = 2;
            this.groupthongtin.TabStop = false;
            this.groupthongtin.Text = "Thông tin nhập";
            // 
            // cbnhacc
            // 
            this.cbnhacc.FormattingEnabled = true;
            this.cbnhacc.Location = new System.Drawing.Point(358, 24);
            this.cbnhacc.Name = "cbnhacc";
            this.cbnhacc.Size = new System.Drawing.Size(138, 21);
            this.cbnhacc.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nhà CC";
            // 
            // txtthanhtien
            // 
            this.txtthanhtien.Location = new System.Drawing.Point(358, 66);
            this.txtthanhtien.Name = "txtthanhtien";
            this.txtthanhtien.Size = new System.Drawing.Size(138, 20);
            this.txtthanhtien.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thanh toán";
            // 
            // datengaynhap
            // 
            this.datengaynhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datengaynhap.Location = new System.Drawing.Point(98, 66);
            this.datengaynhap.Name = "datengaynhap";
            this.datengaynhap.Size = new System.Drawing.Size(138, 20);
            this.datengaynhap.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày nhập";
            // 
            // txtma
            // 
            this.txtma.Enabled = false;
            this.txtma.Location = new System.Drawing.Point(98, 24);
            this.txtma.Name = "txtma";
            this.txtma.Size = new System.Drawing.Size(138, 20);
            this.txtma.TabIndex = 1;
            this.txtma.TextChanged += new System.EventHandler(this.txtma_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Nhập";
            // 
            // btnNhap
            // 
            this.btnNhap.Location = new System.Drawing.Point(555, 18);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(57, 95);
            this.btnNhap.TabIndex = 3;
            this.btnNhap.Text = "Nhập hàng";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnXacnhan
            // 
            this.BtnXacnhan.Location = new System.Drawing.Point(625, 18);
            this.BtnXacnhan.Name = "BtnXacnhan";
            this.BtnXacnhan.Size = new System.Drawing.Size(57, 95);
            this.BtnXacnhan.TabIndex = 4;
            this.BtnXacnhan.Text = "Xác nhận";
            this.BtnXacnhan.UseVisualStyleBackColor = true;
            this.BtnXacnhan.Click += new System.EventHandler(this.BtnXacnhan_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(694, 18);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(57, 95);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // BtnThoat
            // 
            this.BtnThoat.Location = new System.Drawing.Point(762, 18);
            this.BtnThoat.Name = "BtnThoat";
            this.BtnThoat.Size = new System.Drawing.Size(57, 95);
            this.BtnThoat.TabIndex = 6;
            this.BtnThoat.Text = "Thoát";
            this.BtnThoat.UseVisualStyleBackColor = true;
            this.BtnThoat.Click += new System.EventHandler(this.BtnThoat_Click);
            // 
            // QuanLyNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 400);
            this.Controls.Add(this.BtnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.BtnXacnhan);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.groupthongtin);
            this.Controls.Add(this.Groupchitet);
            this.Controls.Add(this.groupdanhsach);
            this.Name = "QuanLyNhapHang";
            this.Text = "QuanLyNhapHang";
            this.Load += new System.EventHandler(this.QuanLyNhapHang_Load);
            this.groupdanhsach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datadanhsach)).EndInit();
            this.Groupchitet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datachitiet)).EndInit();
            this.groupthongtin.ResumeLayout(false);
            this.groupthongtin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupdanhsach;
        private System.Windows.Forms.DataGridView datadanhsach;
        private System.Windows.Forms.GroupBox Groupchitet;
        private System.Windows.Forms.DataGridView datachitiet;
        private System.Windows.Forms.GroupBox groupthongtin;
        private System.Windows.Forms.ComboBox cbnhacc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtthanhtien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datengaynhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.Button BtnXacnhan;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button BtnThoat;
    }
}