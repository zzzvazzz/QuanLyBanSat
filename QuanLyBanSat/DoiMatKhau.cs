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
    public partial class DoiMatKhau : Form
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        private string strcon = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD='';charset=utf8;";
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtmk.Text == "" && txtmkm.Text == "" && txtxnmkm.Text == "") MessageBox.Show("Phải điền tất cả thông tin");
            else if (txtmkm.Text != txtxnmkm.Text) MessageBox.Show("Xác nhận mật khẩu không đúng ");
            else if (txtmk.Text != Properties.Settings.Default.matkhau.ToString()) MessageBox.Show("Mật khẩu hiện tại không đúng ");
            else
            {
                con = new MySqlConnection(strcon);
                con.Open();
                string a=Properties.Settings.Default.taikhoan.ToString();
                cmd = new MySqlCommand("UPDATE dangnhap SET matkhau='"+txtxnmkm.Text+"' WHERE TaiKhoan='"+a+"'", con);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đổi mật khẩu thanh công");
                    con.Close();
                    Close();
                }
                catch
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!!!!!!!!!!!!!");
                    txtmk.Text = "";
                    txtmkm.Text = "";
                    txtxnmkm.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
