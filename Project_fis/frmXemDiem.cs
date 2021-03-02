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
    public partial class frmXemDiem : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;
        public frmXemDiem()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmXemDiem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlydiemDataSet5.tblKET_QUA' table. You can move, or remove it, as needed.
            //this.tblKET_QUATableAdapter.Fill(this.quanlydiemDataSet5.tblKET_QUA);
            conn = cc.Connected();
         //   if (conn.State == ConnectionState.Open) ;
            //Add du lieu vao cboKhoaHoc
            string select = "Select MaKhoa from tblKHOA ";
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cboKhoa.Items.Add(reader.GetString(0));
            }
            reader.Dispose();
            cmd.Dispose();
        }
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string select = "Select * From tblKET_QUA  where MaSV='" + txtMaSV.Text + "' and HocKi='" + cboHocKy.Text + "' and NamHoc=N'" + cboNamHoc.Text + "'";
            SqlCommand cmd = new SqlCommand(select, conn);

            // Tạo đối tượng DataSet
            DataSet ds = new DataSet();

            // Tạo đối tượng điều hợp
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            // Fill dữ liệu từ adapter vào DataSet
            adapter.Fill(ds, "SINHVIEN");

            // Đưa ra DataGridView
            dgrDIEMSV.DataSource = ds;
            dgrDIEMSV.DataMember = "SINHVIEN";

            
            cmd.Dispose();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult a = new DialogResult();
            a = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (a == DialogResult.Yes) Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLop.Items.Clear();
            string select = "Select MaLop from tblLOP where MaKhoa='" + cboKhoa.Text + "'";
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            //Add vao cboLop
            while (reader.Read())
            {
                cboLop.Items.Add(reader.GetString(0));
            }
            //Tra tai nguyen 
            reader.Dispose();
            cmd.Dispose();
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            Export.Export2Excel(dgrDIEMSV);
        }
    }
}
