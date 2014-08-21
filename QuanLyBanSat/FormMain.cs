using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanSat
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void giúpĐỡToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            DangNhap frm = new DangNhap();
            frm.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DoiMatKhau frm1 = new DoiMatKhau();
            frm1.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang frm1 = new KhachHang();
            frm1.ShowDialog();
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhapHang frm1 = new QuanLyNhapHang();
            frm1.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SanPham frm1 = new SanPham();
            frm1.ShowDialog();
        }

        private void thôngTinKhoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kho frm1 = new Kho();
            frm1.ShowDialog();
        }
    }
}
