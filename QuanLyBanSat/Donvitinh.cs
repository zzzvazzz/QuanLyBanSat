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
    public partial class Donvitinh : Form
    {
        private MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD='';charset=utf8;");
        public Donvitinh()
        {
            InitializeComponent();
        }
        public Donvitinh(int ma)
        {
            InitializeComponent();
            lbma.Text = ma.ToString();
            con.Open();
            MySqlDataAdapter da1 = new MySqlDataAdapter("select TenSP from Sanpham where MaSP=" + ma, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            lbten.Text = dt1.Rows[0]["TenSp"].ToString();
            con.Close();
        }
        public void cleartext()
        {
            txtma.Text = "";
            txtten.Text = "";
            txttile.Text = "";
        }
        public void bindings()
        {
            txttile.DataBindings.Clear();
            txttile.DataBindings.Add("text", dataGridView1.DataSource, "Tile");
            txtma.DataBindings.Clear();
            txtma.DataBindings.Add("text", dataGridView1.DataSource, "MaDVT");
            txtten.DataBindings.Clear();
            txtten.DataBindings.Add("text", dataGridView1.DataSource, "TenDVT");
        }
        public void hienthi()
        {
            
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select MaDVT,TenDVT,TiLe from donvitinh where MaSP=" + lbma.Text, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            
            dataGridView1.DataSource = dt;
        }
        private void Donvitinh_Load(object sender, EventArgs e)
        {    
            hienthi();
            bindings();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO donvitinh (TenDVT,MaSP,TiLe) VALUES('" + txtten.Text + "','"+lbma.Text+"','" + txttile.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Thêm thành công !");
            hienthi();
            bindings();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM donvitinh WHERE MaDVT=" + txtma.Text , con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công !");
                con.Close();
                hienthi();
                bindings();
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
