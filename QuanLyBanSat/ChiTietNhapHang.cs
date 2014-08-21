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
    public partial class ChiTietNhapHang : Form
    {
        private MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD='';charset=utf8;");
        double tile;
        public ChiTietNhapHang()
        {
            InitializeComponent();
        }
        public ChiTietNhapHang(string ma)
        {
            InitializeComponent();
            labelma.Text = ma;
            labelthanhtoan.Text = "0";
        }
        public void cleartext()
        {
            txtdongia.Text="";
            txtsoluong.Text="";
            txtsoluongchuan.Text="";
        }
        public void htloai()
        {
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from loaisanpham", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            cbloai.DisplayMember = "TenLoai";
            cbloai.ValueMember = "MaLSP";
            cbloai.DataSource = dt;
            
            
        }
        public void hthang()
        {
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from SanPham where malsp="+cbloai.SelectedValue.ToString(), con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            cbhang.DisplayMember = "TenSP";
            cbhang.ValueMember = "MaSP";  
            cbhang.DataSource = dt;
            
            
             
        }
        public void htdvt()
        {
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from donvitinh where masp=" + cbhang.SelectedValue.ToString(), con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            cbdvt.DisplayMember = "TenDVT";
            cbdvt.ValueMember = "MaDVT";
            cbdvt.DataSource = dt;
            
        }
        public void htdata()
        {
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from NhapChiTiet where manhap=" + labelma.Text, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }
        public void bindings()
        {
            textma.DataBindings.Clear();
            textma.DataBindings.Add("Text",dataGridView1.DataSource,"MaNCT");
            txtsl.DataBindings.Clear();
            txtsl.DataBindings.Add("Text", dataGridView1.DataSource, "Soluong");
            txtdg.DataBindings.Clear();
            txtdg.DataBindings.Add("Text", dataGridView1.DataSource, "dongia");
            
        }
        private void ChiTietNhapHang_Load(object sender, EventArgs e)
        {
            htloai();     
        }
        private void cbhang_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
       

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            if (txtsoluong.Text == "") return;
            double soluongchuan = Convert.ToDouble(txtsoluong.Text)*tile;
            txtsoluongchuan.Text = soluongchuan.ToString();
        }

        private void cbdvt_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select tile from donvitinh where madvt=" + cbdvt.SelectedValue.ToString(), con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            tile = Convert.ToDouble(dt.Rows[0]["tile"].ToString());
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO nhapchitiet (soluong, dongia ,MaDVT,masp,manhap) VALUES(" + txtsoluong.Text + "," + txtdongia.Text + "," + cbdvt.SelectedValue.ToString() + "," + cbhang.SelectedValue.ToString() + "," + labelma.Text + ")", con);
            double tien = Convert.ToDouble(txtdongia.Text) * Convert.ToDouble(txtsoluongchuan.Text);
            double thanhtoan = Convert.ToDouble(labelthanhtoan.Text) + tien;
            labelthanhtoan.Text = thanhtoan.ToString();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Thêm thành công !");
            htdata();
            htloai();
            cleartext();
            bindings();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Update nhap set  ThanhToan=" + labelthanhtoan.Text + " where manhap="+labelma.Text, con);            
            cmd.ExecuteNonQuery();
            this.Close();
            QuanLyNhapHang.me.hienthi();
            QuanLyNhapHang.me.bindings();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM nhapchitiet WHERE MaNCT='" + textma.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công !");
                con.Close();
                htdata();
                htloai();
                bindings();
            }
        }

        private void cbloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbloai.SelectedValue == null) return;
            hthang();
            cbhang.Text = "";
            cbdvt.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbhang.SelectedValue == null) return;
            htdvt();
            cbdvt.Text = "";
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select tendvt from donvitinh where tile=1 and masp=" + cbhang.SelectedValue.ToString(), con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            try
            {
                label6.Text = "SL Chuẩn(" + dt.Rows[0]["tendvt"].ToString() + ")";
            }
            catch
            {
                label6.Text = "SL Chuẩn()";
            }
            con.Close();
        }
        
  
    }
}
