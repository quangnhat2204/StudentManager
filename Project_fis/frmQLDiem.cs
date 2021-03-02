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
using System.Data.OleDb;

namespace Project_fis
{
    public partial class frmQLDiem : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;
        public frmQLDiem()
        {
            InitializeComponent();
        }

        private void frmQLDiem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlydiemDataSet6.tblKET_QUA' table. You can move, or remove it, as needed.
            this.tblKET_QUATableAdapter.Fill(this.quanlydiemDataSet6.tblKET_QUA);
            conn = cc.Connected();
           // if (conn.State == ConnectionState.Open) ;
            //Add du lieu vao cboKhoaHoc
            string select = "Select MaKhoa from tblKHOA ";
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cboKhoaHoc.Items.Add(reader.GetString(0));
            }
            reader.Dispose();
            cmd.Dispose();


            //Add du lieu vao cboMonhoc
            string selects = "Select MaMon from tblMON ";
            SqlCommand cmd1 = new SqlCommand(selects, conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while(reader1.Read())
            {
                cboMonHoc.Items.Add(reader1.GetString(0));
            }
            reader1.Dispose();
            FillDataGridView_Diem();
        

        }

        private void txtDiemThi1_TextChanged(object sender, EventArgs e)
        {
            double DIEMTHI, DIEMTB, DIEMTK;

            if (txtDiemThi.Text == "")
            {
                this.txtDiemThi.Text = "0";
                DIEMTB = double.Parse(this.txtQuatrinh.Text);

                //Tính điểm TK
                DIEMTK = (0.5 * DIEMTB + 0.5 * 0);
                this.txtDiemTK.Text = Convert.ToString(DIEMTK);
            }
            else if (txtQuatrinh.Text == "")
            {
                this.txtQuatrinh.Text = "0";
                DIEMTHI = double.Parse(this.txtDiemThi.Text);

                //Tính điểm TK
                DIEMTK = (0.5 * 0 + 0.5 * DIEMTHI);
                this.txtDiemTK.Text = Convert.ToString(DIEMTK);
            }

            else
            {
                DIEMTHI = double.Parse(this.txtDiemThi.Text);
                DIEMTB = double.Parse(this.txtQuatrinh.Text);
                //Tính điểm TK
                DIEMTK = (0.5 * DIEMTB + 0.5 * DIEMTHI);
                this.txtDiemTK.Text = Convert.ToString(DIEMTK);
            }
            DIEMTK = double.Parse(this.txtDiemTK.Text);
            if (DIEMTK <= 4.5)
            {
                this.txtGhiChu.Text = "Thi lại";
            }
            else
            {
                this.txtGhiChu.Text = "";
            }

        }

        private void txtDiemTB_TextChanged(object sender, EventArgs e)
        {
            double DIEMTHI, DIEMQT, DIEMTK;
            if (txtQuatrinh.Text == "")
            {
                this.txtQuatrinh.Text = "0";
                DIEMTHI = double.Parse(this.txtDiemThi.Text);

                //Tính điểm TK
                DIEMTK = (0.5 * 0 + 0.5 * DIEMTHI);
                this.txtDiemTK.Text = Convert.ToString(DIEMTK);
            }
            else if (txtDiemThi.Text == "")
            {
                this.txtDiemThi.Text = "0";
                DIEMQT = double.Parse(this.txtQuatrinh.Text);

                //Tính điểm TK
                DIEMTK = (0.5 * DIEMQT + 0.5 * 0);
                this.txtDiemTK.Text = Convert.ToString(DIEMTK);
            }

            else
            {
                DIEMTHI = double.Parse(this.txtDiemThi.Text);
                DIEMQT = double.Parse(this.txtQuatrinh.Text);
                //Tính điểm TK
                DIEMTK = (0.5 * DIEMQT + 0.5 * DIEMTHI);
                this.txtDiemTK.Text = Convert.ToString(DIEMTK);
            }
            DIEMTK = double.Parse(this.txtDiemTK.Text);
            if ((DIEMTK <= 4.5))
            {
                this.txtGhiChu.Text = "Thi lại";
            }
            else
            {
                this.txtGhiChu.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Kiem tra trung ten MonHoc va MASV

            //string select1 = "Select MaSV,TenMon from tblKET_QUA where TenMon=N'" + cboMonHoc.Text + "' ";
            //SqlCommand cmd1 = new SqlCommand(select1, conn);
            //SqlDataReader reader1 = cmd1.ExecuteReader();
            //errorProvider1.Clear();
            if (txtMaSV.Text == "")
            {
                errorProvider1.SetError(txtMaSV, "Mã sinh viên không để trống!");
            }
            //else if (reader1.Read())
            //{
            //    {
            //        MessageBox.Show("Sinh viên này đã được nhập điểm môn: " + cboMonHoc.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        txtMaSV.Focus();

            //    }


            ////Tra tai nguyen 
            //reader1.Dispose();
            //cmd1.Dispose();
            //}
            else
            {

                ////Tra tai nguyen 
                //reader1.Dispose();
                //cmd1.Dispose();

                // Thực hiện truy vấn
                string update = "Update tblKET_QUA Set Hoten=N'" + txtHoTen.Text + "',MaLop='" +
                                cboLop.Text + "',SoDVHT='" + cboTinchi + "',DiemQuaTrinh='" + txtQuatrinh.Text + "',DiemThi='" + txtDiemThi.Text + "' ,DiemTongKet='" +
                                txtDiemTK.Text + "',DiemRenLuyen=N'" + txtDiemRL.Text + "',HocKi=N'" + cboHocKi.Text + "',GhiChu=N'" +
                                txtGhiChu.Text + "',NamHoc'" + cboNamhoc + "' where MaSV='" + txtMaSV.Text + "' and MaMon=N'" + cboMonHoc.Text + "'";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Load lai du lieu
                FillDataGridView_Diem();
                // Trả tài nguyên
                cmd.Dispose();
            }
        }
        public void FillDataGridView_Diem()
        {
            // Thực hiện truy vấn
            string select = "Select * From tblKET_QUA  ";
            SqlCommand cmd = new SqlCommand(select, conn);

            // Tạo đối tượng DataSet
            DataSet ds = new DataSet();

            // Tạo đối tượng điều hợp
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            // Fill dữ liệu từ adapter vào DataSet
            adapter.Fill(ds, "SINHVIEN");

            // Đưa ra DataGridView
            dgrDiem.DataSource = ds;
            dgrDiem.DataMember = "SINHVIEN";
            cmd.Dispose();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Thuc hien xoa du lieu
                string delete = "delete from tblKET_QUA where MaSV='" + txtMaSV.Text + "' and MaMon='" + cboMonHoc.Text + "' ";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");

                // Trả tài nguyên
                cmd.Dispose();
                //Load lai du lieu
                FillDataGridView_Diem();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Kiem tra trung ten MonHoc va MASV

            string select1 = "Select MaSV from tblSINH_VIEN where MaSV=N'" + txtMaSV.Text + "' and Hoten=N'" + txtHoTen.Text + "' ";
            SqlCommand cmd1 = new SqlCommand(select1, conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            errorProvider1.Clear();
            if (txtMaSV.Text == "")
            {
                errorProvider1.SetError(txtMaSV, "Mã sinh viên không để trống!");
                txtMaSV.Focus();
            }
            else if (txtMaSV.Text == dgrDiem.CurrentRow.Cells[0].Value.ToString() && cboMonHoc.Text == dgrDiem.CurrentRow.Cells[3].Value.ToString())
            {
                {
                    MessageBox.Show("Sinh viên này đã được nhập điểm môn: " + cboMonHoc.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSV.Focus();

                }
            }
            else if (cboLop.Text == "")
            {
                errorProvider1.SetError(cboLop, "Mã lớp không để trống!");
                cboLop.Focus();
            }
            else if (cboHocKi.Text == "")
            {
                errorProvider1.SetError(cboHocKi, "Học kỳ không để trống!");
                cboHocKi.Focus();
            }
            else if (cboMonHoc.Text == "")
            {
                errorProvider1.SetError(cboMonHoc, "Mã môn không để trống!");
                cboMonHoc.Focus();
            }
            else if(cboNamhoc.Text == "")
            {
                errorProvider1.SetError(cboNamhoc, "Năm học không để trống!");
            }
            else if (reader1.Read())
            {

                //Tra tai nguyen 
                reader1.Dispose();
                cmd1.Dispose();
                // Thực hiện truy vấn
                string insert = "Insert Into tblKET_QUA(MaSV,HoTen,MaLop,MaMon,SoDVHT,DiemQuaTrinh,DiemThi,DiemTongKet,DiemRenLuyen,HocKi,GhiChu,NamHoc)" +
                "Values('" + txtMaSV.Text + "',N'" + txtHoTen.Text + "',N'" + cboLop.Text + "',N'" + cboMonHoc.Text + "','" + cboTinchi.Text + "','" +
                 txtQuatrinh.Text + "','" + txtDiemThi.Text + "','" + txtDiemTK.Text + "','" + txtDiemRL.Text + "','" + cboHocKi.Text + "',N'" +
                 txtGhiChu.Text + "',N'" + cboNamhoc.Text + "')";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Nhập thông tin thành công", "Thông báo!");

                // Trả tài nguyên
                cmd.Dispose();
            }
            else
            {
                {
                    MessageBox.Show("Nhập mã sinh viên không chính xác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSV.Focus();

                }
                //Tra tai nguyen 
                reader1.Dispose();
                cmd1.Dispose();
            }
            //Tra tai nguyen 
            reader1.Dispose();
            cmd1.Dispose();
            //Load lai du lieu
            FillDataGridView_Diem();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLop.Items.Clear();
            cboLop.Text = "";
            string select = "Select MaLop from tblLOP where  MaKhoa='" + cboKhoaHoc.Text + "'";
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

        private void dgrDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = dgrDiem.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dgrDiem.CurrentRow.Cells[1].Value.ToString();
            cboLop.Text = dgrDiem.CurrentRow.Cells[2].Value.ToString();
            cboMonHoc.Text = dgrDiem.CurrentRow.Cells[3].Value.ToString();
            txtQuatrinh.Text = dgrDiem.CurrentRow.Cells[5].Value.ToString();
            txtDiemThi.Text = dgrDiem.CurrentRow.Cells[6].Value.ToString();
            txtDiemTK.Text = dgrDiem.CurrentRow.Cells[7].Value.ToString();
            cboHocKi.Text = dgrDiem.CurrentRow.Cells[9].Value.ToString();
            txtGhiChu.Text = dgrDiem.CurrentRow.Cells[10].Value.ToString();
            txtDiemRL.Text = dgrDiem.CurrentRow.Cells[8].Value.ToString();
            cboTinchi.Text = dgrDiem.CurrentRow.Cells[4].Value.ToString();
            cboNamhoc.Text = dgrDiem.CurrentRow.Cells[11].Value.ToString();
        }

        private void cboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = "Select SoDVHT from tblMON where MaMon='" + cboMonHoc.Text + "'";
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            //Add vao cboLop
            while (reader.Read())
            {
                cboTinchi.Items.Add(reader.GetInt32(0));
            }
            //Tra tai nguyen 
            reader.Dispose();
            cmd.Dispose();
            string selects = "Select HocKi from tblMON where MaMon='" + cboMonHoc.Text + "'";
            SqlCommand cmd1 = new SqlCommand(selects, conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                cboHocKi.Items.Add(reader1.GetInt32(0));
            }
            reader1.Dispose();
            cmd1.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult a = new DialogResult();
            a = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (a == DialogResult.Yes) Close();
        }
        public DataTable ReadExcelContents(string fileName)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();

                connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;Data Source=" + fileName); //Excel 97-2003, .xls //string excelQuery = @"Select [Day],[Outlook],[temp],[Humidity],[Wind], [PlaySport] // FROM [Sheet1$]";

                string excelQuery = @"Select * FROM [Sheet1$]";
                connection.Open();
                OleDbCommand cmd = new OleDbCommand(excelQuery, connection);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];

                //   dataGridView1.DataSource = dt.DefaultView;
                connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program can't read file. " + ex.Message, "Please Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void ImportIntoDatabase(DataTable data)
        {
            if (data == null || data.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để import", "Thông báo!");
                return;
            }

            QuanlydiemDataSet6TableAdapters.tblKET_QUATableAdapter adapter = new QuanlydiemDataSet6TableAdapters.tblKET_QUATableAdapter();
            string masv = "", hoten = "", malop = "", mamon = "", ghichu = "", namhoc = "";
            int sotc = 0, hocki = 0;
            float diemquatrinh = 0, diemthi = 0, diemtongket = 0, diemrenluyen = 0;
            try
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    masv = data.Rows[i]["MaSv"].ToString().Trim();
                    hoten = data.Rows[i]["HoTen"].ToString().Trim();
                    malop = data.Rows[i]["MaLop"].ToString().Trim();
                    mamon = data.Rows[i]["MaMon"].ToString().Trim();
                    sotc = int.Parse(data.Rows[i]["SoDVHT"].ToString().Trim());
                    diemquatrinh = float.Parse(data.Rows[i]["DiemQuaTrinh"].ToString().Trim());
                    diemthi = float.Parse(data.Rows[i]["DiemThi"].ToString().Trim());
                    diemtongket = float.Parse(data.Rows[i]["DiemTongKet"].ToString().Trim());
                    diemrenluyen = float.Parse(data.Rows[i]["DiemRenLuyen"].ToString().Trim());
                    hocki = int.Parse(data.Rows[i]["HocKi"].ToString().Trim());
                    ghichu = data.Rows[i]["GhiChu"].ToString().Trim();
                    namhoc = data.Rows[i]["NamHoc"].ToString().Trim();
                    QuanlydiemDataSet6.tblKET_QUADataTable sinhvien = adapter.GetDataBy2(masv,mamon);
                    // Nếu nhân viên chưa tồn tại trong DB thì thêm mới
                    if (sinhvien == null || sinhvien.Rows.Count == 0)
                    {
                        adapter.InsertQuery(masv, hoten, malop,mamon,sotc,diemquatrinh,diemthi,diemtongket,diemrenluyen,hocki,ghichu,namhoc);
                    }
                    // Ngược lại, nhân viên đã tồn tại trong DB thì update
                    else
                    {
                        adapter.UpdateQuery(hoten, malop, sotc, diemquatrinh, diemthi, diemtongket, diemrenluyen, hocki, ghichu ,namhoc, masv, mamon);
                    }
                    //MaSV,HoTen,MaLop,MaMon,SoDVHT,DiemQuaTrinh,DiemThi,DiemTongKet,DiểmnLuyen,HocKi,GhiChu,NamHoc
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show("Kết thúc import");
        }
        private void ShowData()
        {
            QuanlydiemDataSet6TableAdapters.tblKET_QUATableAdapter adapter = new QuanlydiemDataSet6TableAdapters.tblKET_QUATableAdapter();
            dgrDiem.DataSource = adapter.GetData();
        }
        private void cboHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng mở tập tin
            OpenFileDialog fopen = new OpenFileDialog();
            //chỉ ra đuôi
            fopen.Filter = "(Tất cả các tệp)|*.*|(Các tệp Excel)|*.xlsx";
            // Đọc dữ liệu từ tập tin excel trả về DataTable
            fopen.ShowDialog();
            if (fopen.FileName != "")
            {
                DataTable a = new DataTable();
                a = ReadExcelContents(fopen.FileName);
                ImportIntoDatabase(a);
                ShowData();

            }
        }
    }
}
