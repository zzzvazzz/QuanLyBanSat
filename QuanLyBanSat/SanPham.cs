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
    public partial class SanPham : Form
    {
        private MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD='';charset=utf8;");
        private bool flag;
        public DataTable dtseach = new DataTable();
        public SanPham()
        {
            InitializeComponent();
        }
        public void cleartext()
        {
            txtma.Text = "";
            txtten.Text = "";
            cbloai.Text = "";
            txtgia.Text = "";
        }
        public void khoabutton(bool f)
        {
            btnhuy.Enabled = btnluu.Enabled = groupBox1.Enabled = f;
            btnthem.Enabled = btnsua.Enabled = btnxoa.Enabled = !f;

        }
        public void bindings()
        {
            txtgia.DataBindings.Clear();
            txtgia.DataBindings.Add("text", dataGridView1.DataSource, "GiaNhap");
            txtma.DataBindings.Clear();
            txtma.DataBindings.Add("text", dataGridView1.DataSource, "MaSP");
            cbloai.DataBindings.Clear();
            cbloai.DataBindings.Add("text", dataGridView1.DataSource, "TenLoai");
            txtten.DataBindings.Clear();
            txtten.DataBindings.Add("text", dataGridView1.DataSource, "TenSP");
        }
        public void hienthi()
        {
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select Masp,GiaNhap,TenSp,TenLoai from SanPham,loaisanpham where sanpham.MaLSP=loaisanpham.MaLSP", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtseach = dt;
            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from Loaisanpham", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cbloai.DataSource = dt1;
            
            cbloai.DisplayMember = "TenLoai";
            cbloai.ValueMember = "MaLSP";
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            hienthi();
            bindings();
            khoabutton(false);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            flag = true;
            khoabutton(true);
            cleartext();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            flag = false;
            khoabutton(true);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM sanpham WHERE MaSP='" + txtma.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công !");
                con.Close();
                hienthi();
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            khoabutton(false);
            bindings();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Sanpham SET TenSP='" + txtten.Text + "',GiaNhap='" + txtgia.Text + "',MaLSP='" + cbloai.SelectedValue + "' WHERE MaSP='" + txtma.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sửa thành công !");
                hienthi();
                khoabutton(false);
            }
            else
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO SanPham (TenSP, GiaNhap,MaLSP) VALUES('" + txtten.Text + "', '" + txtgia.Text + "','" + cbloai.SelectedValue + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thêm thành công !");
                hienthi();
                khoabutton(false);
            }
            bindings();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtseach);
            dv.RowFilter = string.Format("TenSP Like '%{0}%' or TenLoai Like '%{0}%'",  txttimkiem.Text);
            dataGridView1.DataSource = dv;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string nut = dataGridView1.CurrentCell.Value.ToString();
            if (nut == "ĐVT") {
                int ma=Convert.ToInt16(dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString());
                Donvitinh dvt = new Donvitinh(ma);
                dvt.ShowDialog();
            }
        }
        
    }
}
