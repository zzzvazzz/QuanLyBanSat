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
    public partial class DangNhap : Form
    {
        private MySqlConnection con;
        private MySqlDataAdapter da;
        private DataTable dt;
        private string strcon = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD='';charset=utf8;";
        public DangNhap()
        {
            InitializeComponent();
        }
        private void btnDN_Click(object sender, EventArgs e)
        {   
            con=new MySqlConnection(strcon);
            con.Open();
            da = new MySqlDataAdapter("select * from dangnhap where taikhoan='" + txttaikhoan.Text + "'and matkhau='" + txtmatkhau.Text + "'", con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            int kt=dt.Rows.Count;
            if (kt >= 1) { 
                MessageBox.Show("Đăng nhập thanh công");
                Properties.Settings.Default.taikhoan = txttaikhoan.Text;
                Properties.Settings.Default.matkhau = txtmatkhau.Text;
                this.Hide();
                FormMain Form1 = new FormMain();
                Form1.Show();
            }
            else MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
