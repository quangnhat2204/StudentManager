using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Diagnostics;

namespace Project_fis
{
    public partial class frmDangNhap : Form
    {
        private string quyensv, quyengv;

        //Khai báo đối tượng Commonconnect
        private CommonConnect cc = new CommonConnect();
        //Khai báo đối tượng SqlConnection
        private SqlConnection conn = null;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            /*SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VC9NR85\SQLEXPRESS;Initial Catalog=Nguoidung;Integrated Security=True");
            try
            {
                con.Open();
                string tk = txtTaikhoan.Text;
                string mk = txtMatkhau.Text;
                string sql = "select *from Nguoidung where Taikhoan='" + tk + "' and Matkhau='" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read()==true)
                {
                    MessageBox.Show("Đăng nhập thành công","Thông báo!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Form1 a = new Form1();
                    a.Show();
                    a.menuDN.Enabled = false;
                    this.Hide();
                    cmd.Dispose();
                    dta.Close();
                    dta.Dispose();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại","Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }*/                
            string select = "Select * From tbllogin where tendn='" + txtTenDN.Text + "' and matkhau='" + txtMatKhau.Text + "' and Quyen='" + quyengv +"'";
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (radioButton1.Checked == false && radioButton2.Checked == false)
                errorProvider1.SetError(radioButton1, "Chưa chọn quyền đăng nhập");
            if (reader.Read())
            {
                MessageBox.Show("Đăng nhập vào hệ thống !", "Thông báo !");                
                Form1.UserName = txtTenDN.Text;
                Form1 frm = new Form1();
                frm.Show();               
                frm.menuDN.Enabled = false;
                this.Hide();

                cmd.Dispose();
                reader.Close();
                reader.Dispose();
            }

            else
            {
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
                string select1 = "Select * From tbllogin where TenDN='" + txtTenDN.Text + "' and matkhau='" + txtMatKhau.Text + "' and Quyen='" + quyensv + "'";
                SqlCommand cmd1 = new SqlCommand(select1, conn);
                SqlDataReader reader1;
                reader1 = cmd1.ExecuteReader();

                if (reader1.Read())
                {
                    MessageBox.Show("Đăng nhập vào hệ thống !", "Thông báo !");
                    Form1.UserName = txtTenDN.Text;
                    Form1 frm = new Form1();
                    frm.Show();
                    frm.menuDN.Enabled = false;
                    frm.MnuItemDanhMuc.Enabled = false;
                    frm.mnuItemQuanli.Enabled = false;
                    this.Hide();

                    frm.mnuQuanlinguoidung.Enabled = false;

                 //  frm.menuBarToolStripMenuItem.Enabled = false;
                 //   frm.menuBarToolStripMenuItem.Checked = true;

                    frm.pictureBox2.Hide();
                    frm.btl1.Hide();
                    frm.btl2.Hide();
                    frm.btl3.Hide();
                    frm.btl4.Hide();
                    frm.btl5.Hide();
                    frm.btl6.Hide();
                  //**
                    //frm.menuBarToolStripMenuItem.Checked = true;
                    //frm.pictureBox3.Show();
                    //frm.pictureBox2.Show();
                    //frm.btl1.Show();
                    //frm.btl2.Show();
                    //frm.btl3.Show();
                    //frm.btl4.Show();
                    //frm.btl5.Show();
                    //frm.btl6.Show();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
                cmd1.Dispose();
                reader1.Close();
                reader1.Dispose();

            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult a;
            a = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(a==DialogResult.Yes) Application.Exit();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // Mở kết nối
            conn = cc.Connected();
           // if (conn.State == ConnectionState.Open) ;         
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
                quyensv = "SinhVien";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
                quyengv = "GiangVien";
        }
    }
}
