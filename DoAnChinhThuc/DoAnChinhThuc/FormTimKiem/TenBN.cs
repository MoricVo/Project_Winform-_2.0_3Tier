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
namespace DoAnChinhThuc.FormTimKiem
{
    public partial class TenBN : Form
    {
        public TenBN()
        {
            InitializeComponent();
        }
        SqlConnection ketnoi = null;
        string strketnoi = "Data Source= DESKTOP-HD4HHJ3\\SQLEXPRESS;  Initial Catalog=CSDL_DoAnQLBNNhaKhoa; Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            txtMaNv.Text = "";         
            txtTenNv.Text = "";
            txtChucVu.Text = "";
            txtSdtt.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtMaMuonTim.Text = "";
            txtTenMuonTim.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            TimTenNV();
            TimMaNV();
            MessageBox.Show("Đã tìm thấy nhân viên" + " mà bạn muốn tìm","Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        public void TimTenNV()
        {
            if (ketnoi == null)
                ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Closed)
                ketnoi.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from NhanVien where  TenNhanVien =@TNV ";
            command.Connection = ketnoi;
            SqlParameter parameter = new SqlParameter("@TNV", SqlDbType.NVarChar);
            parameter.Value = txtTenMuonTim.Text;
            command.Parameters.Add(parameter);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {           
                txtMaNv.Text = reader.GetString(0);              
                txtTenNv.Text = reader.GetString(1);
                txtChucVu.Text = reader.GetString(2);
                txtSdtt.Text = reader.GetString(3);
                txtTaiKhoan.Text = reader.GetString(4);
                txtMatKhau.Text = reader.GetString(5);               
            }
            reader.Close();
        }
        public void TimMaNV()
        {
            if (ketnoi == null)
                ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Closed)
                ketnoi.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from NhanVien where  MaNhanVien =@MNV ";
            command.Connection = ketnoi;
            SqlParameter parameter = new SqlParameter("@MNV", SqlDbType.NVarChar);
            parameter.Value = txtMaMuonTim.Text;
            command.Parameters.Add(parameter);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtMaNv.Text = reader.GetString(0);
                txtTenNv.Text = reader.GetString(1);
                txtChucVu.Text = reader.GetString(2);
                txtSdtt.Text = reader.GetString(3);
                txtTaiKhoan.Text = reader.GetString(4);
                txtMatKhau.Text = reader.GetString(5);
            }
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Levi = MessageBox.Show("Bạn có thật sự muốn thoát không?", "Question",
          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Levi == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
