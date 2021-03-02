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
    public partial class Form1 : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;

        public static string UserName = "";
        public Form1()
        {
            InitializeComponent();
        }
        //private void ShowNewForm(object sender, EventArgs e)
        //{
        //    Form childForm = new Form();
        //    childForm.MdiParent = this;
        //    childForm.Text = "Window " + childFormNumber++;
        //    childForm.Show();
        //}       
        private void Form1_Load(object sender, EventArgs e)
        {
            Getinfo();
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            DialogResult a;
            a = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes) this.Close();
         }

        private void đôiMâtKhâuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau a = new frmDoiMatKhau();
            a.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult a;
            a = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (a == DialogResult.Yes) Application.Exit();
        }

        private void đăngXuâtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
            this.Hide();
            menuDN.Enabled = true;
        }

        private void quanLiNgươiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Form1.ActiveForm;
            foreach (Form f in frm.MdiChildren)
            {
                if (f.Name == "frmQuanLyNguoiDung")
                {
                    f.Activate();
                    return;
                }
            }
            frmQuanLyNguoiDung frmGV = new frmQuanLyNguoiDung();
            frmGV.MdiParent = this;
            frmGV.Show();
            frmGV.Top = 0;
            frmGV.Left = 0;
        }
        private void Getinfo()
        {
            try
            {
                conn=cc.Connected();
                string sql = "select *From tblLOGIN where TenDN= '" + UserName + "'";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Name1.Text = "Name: " + dr["HoTen"].ToString();
                        Sex.Text = "Sex: " + dr["GioiTinh"].ToString();
                        Quyen.Text = "User: " + dr["Quyen"].ToString();
                        Email.Text = "Email: " + dr["Email"].ToString();
                        Sdt.Text = "Phone: " + dr["Phone"].ToString();
                    }
                    //họ tên, giới tính, phone, email, quyền
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void mônHocToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = Form1.ActiveForm;
            foreach (Form f in frm.MdiChildren)
            {
                if (f.Name == "frmMonHoc")
                {
                    f.Activate();
                    return;
                }
            }
            frmMonHoc frm1 = new frmMonHoc();
            frm1.MdiParent = this;
            frm1.Show();
            frm1.Top = 0;
            frm1.Left = 0;
        }

        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Form1.ActiveForm;
            foreach (Form f in frm.MdiChildren)
            {
                if (f.Name == "frmKhoa")
                {
                    f.Activate();
                    return;
                }
            }

            Form frmQLK = new frmKhoa();
            frmQLK.MdiParent = this;
            frmQLK.Show();
            frmQLK.Top = 0;
            frmQLK.Left = 0;
        }

        private void lơpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Form1.ActiveForm;
            foreach (Form f in frm.MdiChildren)
            {
                if (f.Name == "frmLop")
                {
                    f.Activate();
                    return;
                }
            }

            Form frmLop = new frmLop();
            frmLop.MdiParent = this;
            frmLop.Show();
            frmLop.Top = 0;
            frmLop.Left = 0;
        }

        private void timKiêmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }           
        private void btl4_Click_1(object sender, EventArgs e)
        {
            khoaToolStripMenuItem_Click(sender, e);
        }

        private void btl5_Click_1(object sender, EventArgs e)
        {
            lơpToolStripMenuItem_Click(sender, e);
        }

        private void btl6_Click_1(object sender, EventArgs e)
        {
            mônHocToolStripMenuItem1_Click(sender, e);
        }


        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Form1.ActiveForm;
            foreach (Form f in frm.MdiChildren)
            {
                if (f.Name == "frmQLSV")
                {
                    f.Activate();
                    return;
                }
            }
            Form frm1 = new frmQLSV();
            frm1.MdiParent = this;
            frm1.Show();
            frm1.Top = 0;
            frm1.Left = 0;
        }

        private void btl1_Click(object sender, EventArgs e)
        {
            sinhViênToolStripMenuItem_Click(sender, e);
        }

        private void thôngTinSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Form1.ActiveForm;
            foreach(Form f in frm.MdiChildren)
            {
                if(f.Name == "frmXemDiem")
                {
                    f.Activate();
                    return;
                }
            }
            Form frm1 = new frmXemDiem();
            frm1.MdiParent = this;
            frm1.Show();
            frm1.Top = 0;
            frm1.Left = 0;
        }

        private void điêmMônHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Form1.ActiveForm;
            foreach(Form f in frm.MdiChildren)
            {
                if (f.Name == "frmQLDiem")
                {
                    f.Activate();
                    return;
                }
            }
            Form frmD = new frmQLDiem();
            frmD.MdiParent = this;
            frmD.Show();
            frmD.Top = 0;
            frmD.Left = 0;
        }

        private void btl3_Click(object sender, EventArgs e)
        {
            điêmMônHocToolStripMenuItem_Click(sender, e);
        }

        private void giangViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Form1.ActiveForm;
            foreach(Form f in frm.MdiChildren)
            {
                if(f.Name=="frmGiangVien")
                {
                    f.Activate();
                    return;
                }
            }
            Form frm1 = new frmGiangVien();
            frm1.MdiParent = this;
            frm1.Show();
            frm1.Top = 0;
            frm1.Left = 0;
        }

        private void btl2_Click(object sender, EventArgs e)
        {
            giangViênToolStripMenuItem_Click(sender, e);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Form1.ActiveForm;
            foreach (Form f in frm.MdiChildren)
            {
                if (f.Name == "Info")
                {
                    f.Activate();
                    return;
                }
            }
            Form frm1 = new Info();
            frm1.MdiParent = this;
            frm1.Show();
            frm1.Top = 0;
            frm1.Left = 0;
        }
    }
}
