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
    public partial class QuanLyNhapHang : Form
    {
        public static QuanLyNhapHang me;
        private MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD='';charset=utf8;");
        public QuanLyNhapHang()
        {
            InitializeComponent();
            me = this;
        }
        public void hienthi()
        {
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select MaNhap,NgayNhap,ThanhToan,TenNCC from nhap,Nhacc where nhap.mancc=nhacc.mancc", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from nhacc", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();
            cbnhacc.DataSource = dt1;
            cbnhacc.DisplayMember = "TenNCC";
            cbnhacc.ValueMember = "MaNCC";
            datadanhsach.DataSource = dt;
        
        }
        public void cleartext()
        {
            txtma.Text = "";
            cbnhacc.Text = "";
            datengaynhap.Value = System.DateTime.Today;
            txtthanhtien.Text = "0";
        }

        public void bindings()
        {
            txtthanhtien.DataBindings.Clear();
            txtthanhtien.DataBindings.Add("text", datadanhsach.DataSource, "Thanhtoan");
            txtma.DataBindings.Clear();
            txtma.DataBindings.Add("text", datadanhsach.DataSource, "MaNhap");
            cbnhacc.DataBindings.Clear();
            cbnhacc.DataBindings.Add("text", datadanhsach.DataSource, "TenNCC");
            datengaynhap.DataBindings.Clear();
            datengaynhap.DataBindings.Add("text", datadanhsach.DataSource, "NgayNhap");
        }
        public void khoabutton(bool b)
        {
            Groupchitet.Enabled=BtnXacnhan.Enabled = b;
            btnNhap.Enabled = !b;
        }
        private void QuanLyNhapHang_Load(object sender, EventArgs e)
        {
            hienthi();
            bindings();
            khoabutton(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cleartext();
            khoabutton(true);
           
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void datadanhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtma_TextChanged(object sender, EventArgs e)
        {
            if (txtma.Text == "") return;
            int ma = Convert.ToInt16(txtma.Text);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from NhapChiTiet where manhap=" + ma, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            datachitiet.DataSource = dt;
        }

        private void BtnXacnhan_Click(object sender, EventArgs e)
        {
            con.Open();
            string date = datengaynhap.Value.Year.ToString() + "-" + datengaynhap.Value.Month.ToString() + "-" + datengaynhap.Value.Day.ToString();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO nhap (Ngaynhap, ThanhToan,MaNCC) VALUES('" + date + "', '" + txtthanhtien.Text + "','" + cbnhacc.SelectedValue + "')", con);
            cmd.ExecuteNonQuery();
            MySqlDataAdapter da1 = new MySqlDataAdapter("select manhap from nhap order by MaNhap desc limit 1", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();
            MessageBox.Show("Thêm thành công !");
            hienthi();
            khoabutton(false);
            bindings();

            ChiTietNhapHang frm = new ChiTietNhapHang(dt1.Rows[0]["MaNhap"].ToString());
            frm.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                MySqlCommand cmd1 = new MySqlCommand("DELETE FROM nhapchitiet WHERE Manhap=" + txtma.Text, con);
                cmd1.ExecuteNonQuery();
                
                MySqlCommand cmd = new MySqlCommand(  "DELETE FROM nhap WHERE Manhap=" +txtma.Text , con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công !");
                con.Close();
                hienthi();
                bindings();
            }
        }        
    }
}
