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
    public partial class Loaisp : Form
    {
        private MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD='';charset=utf8;");
        private bool flag;
        public Loaisp()
        {
            InitializeComponent();
        }
        public void cleartext()
        {
            txtma.Text = "";
            txtten.Text = "";
            txtghichu.Text = ""; 
        }
        public void khoabutton(bool f)
        {
            btnhuy.Enabled = btnluu.Enabled = groupBox2.Enabled = f;
            btnthem.Enabled = btnSua.Enabled = btnxoa.Enabled = !f;

        }
        public void bindings()
        {
            txtghichu.DataBindings.Clear();
            txtghichu.DataBindings.Add("text", dataGridView1.DataSource, "GhiChu");
            txtma.DataBindings.Clear();
            txtma.DataBindings.Add("text", dataGridView1.DataSource, "MaLSP");
            txtten.DataBindings.Clear();
            txtten.DataBindings.Add("text", dataGridView1.DataSource, "TenLoai");
        }
        public void hienthi()
        {
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from loaisanpham", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }
        private void Loaisp_Load(object sender, EventArgs e)
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

        private void btnSua_Click(object sender, EventArgs e)
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
                MySqlCommand cmd = new MySqlCommand("DELETE FROM loaisanpham WHERE MaLSP='" + txtma.Text + "'", con);
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
                MySqlCommand cmd = new MySqlCommand("UPDATE loaisanpham SET TenLoai='" + txtten.Text + "',Ghichu='" + txtghichu.Text + "' WHERE MaLSP='" + txtma.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sửa thành công !");
                hienthi();
                khoabutton(false);
            }
            else
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO loaisanpham (TenLoai,Ghichu) VALUES('" + txtten.Text + "','" + txtghichu.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thêm thành công !");
                hienthi();
                khoabutton(false);

            }
            bindings();
        }
    }
}
