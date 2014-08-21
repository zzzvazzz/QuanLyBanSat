using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace QuanLyBanSat
{
    public partial class Kho : Form
    {
        private MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD='';charset=utf8;");
        public Kho()
        {
            InitializeComponent();
        }
        DataTable dtseach = new DataTable();
        public void hienthi()
        {
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select sanpham.Masp,GiaNhap,TenSp,TenLoai,soluong from SanPham,loaisanpham,khohang where khohang.masp=sanpham.masp and sanpham.MaLSP=loaisanpham.MaLSP", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtseach = dt;
            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from Loaisanpham", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cbLoai.DataSource = dt1;
            cbLoai.DisplayMember = "TenLoai";
            cbLoai.ValueMember = "MaLSP";
            con.Close();
            dataGridView1.DataSource = dt;
        }
        private void Kho_Load(object sender, EventArgs e)
        {
            hienthi();
        }

        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtseach);
            dv.RowFilter = string.Format("TenLoai Like '%{0}%'", cbLoai.Text);
            dataGridView1.DataSource = dv;
        }

        private void txtma_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtseach);
            dv.RowFilter = string.Format("MaSP = {0}", txtma.Text);
            dataGridView1.DataSource = dv;
        }

        private void txtten_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtseach);
            dv.RowFilter = string.Format("TenSP Like '%{0}%'", txtten.Text);
            dataGridView1.DataSource = dv;
        }

      
    }
}
