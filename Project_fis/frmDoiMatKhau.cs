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

namespace Project_fis
{
    public partial class frmDoiMatKhau : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string select2 = "Select * From tblLOGIN where TenDN='" + txtTaikhoan.Text + "' and MatKhau='" + txtMKcu.Text + "' and Quyen='"+ cboQuyen.Text +"'";
            SqlCommand cmd2 = new SqlCommand(select2, conn);//"' and Quyen='"+ cboQuyen.SelectedText
            SqlDataReader reader2;
            reader2 = cmd2.ExecuteReader();

            errorProvider1.Clear();
            if (txtTaikhoan.Text == "")
                errorProvider1.SetError(txtTaikhoan, "Chưa nhập tên tài khoản !");
            else if (txtMKcu.Text == "")
            {
                errorProvider1.SetError(txtMKcu, "!");
                txtMKcu.Focus();
            }
            else if (txtMKmoi.Text == "")
            {
                errorProvider1.SetError(txtMKmoi, "!");
                txtMKmoi.Focus();
            }
            else if (txtConfimMk.Text == "")
            {
                errorProvider1.SetError(txtConfimMk, "!");
                txtConfimMk.Focus();
            }
            else if (txtConfimMk.Text != txtMKmoi.Text)
                MessageBox.Show("Bạn nhập lại password không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (reader2.Read())
            {
                cmd2.Dispose();
                reader2.Dispose();
                // Thực hiện truy vấn
                string update = "Update tblLOGIN Set MatKhau='" + txtMKmoi.Text + "' where TenDN='" + txtTaikhoan.Text + "'";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!");

                // Trả tài nguyên
                cmd.Dispose();
            }

            else
            {
                MessageBox.Show("Tên tài khoản không tồn tại hoặc mật khẩu sai! ", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaikhoan.Focus();

            }
            cmd2.Dispose();
            reader2.Dispose();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            conn = cc.Connected();
           // if (conn.State == ConnectionState.Open) ;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult a;
            a = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (a == DialogResult.Yes) Close();
        }
    }   
}
