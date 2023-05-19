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
    public partial class MaBN : Form
    {
        public MaBN()
        {
            InitializeComponent();
        }
        SqlConnection ketnoi = null;
        string strketnoi = "Data Source= DESKTOP-HD4HHJ3\\SQLEXPRESS;  Initial Catalog=CSDL_DoAnQLBNNhaKhoa; Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            TimMaBN();
            TimTenBN();
            MessageBox.Show("Đã tìm thấy bệnh nhân"   + " mà bạn muốn tìm", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            
        }
        public void TimMaBN()
        {
            if (ketnoi == null)
                ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Closed)
                ketnoi.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from ThongTinBenhNhan where  MaBenhNhan =@MBN ";
            command.Connection = ketnoi;
            SqlParameter parameter = new SqlParameter("@MBN", SqlDbType.NVarChar);
            parameter.Value = txtMaMuonTim.Text;
            command.Parameters.Add(parameter);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtMaBenhNhan.Text = reader.GetString(0);
                txtTenBN.Text = reader.GetString(1);            
                txtTenBenhNhan.Text = reader.GetString(2);
                txtCMND.Text = reader.GetString(3);
                txtDanToc.Text = reader.GetString(5);
                txtNgheNghiep.Text = reader.GetString(6);
                txtNguoiThan.Text = reader.GetString(7);
                txtQuanHe.Text = reader.GetString(8);
                txtSDT.Text = reader.GetString(9);
                txtGhiChu.Text = reader.GetString(10);
                txtNgaySinh.Text = reader.GetDateTime(11) + "";
                txtDiaChi.Text = reader.GetString(12);
                txtLoaiBenh.Text = reader.GetString(13);
                txtBaoHiem.Text = reader.GetString(14);
                txtQueQuan.Text = reader.GetString(15);
            }
            reader.Close();
        }
        public void TimTenBN()
        {
            if (ketnoi == null)
                ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Closed)
                ketnoi.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from ThongTinBenhNhan where  HoVaTen =@HVT ";
            command.Connection = ketnoi;
            SqlParameter parameter = new SqlParameter("@HVT", SqlDbType.NVarChar);
            parameter.Value = txtTenMuonTim.Text;
            command.Parameters.Add(parameter);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtMaBenhNhan.Text = reader.GetString(0);
                txtTenBN.Text = reader.GetString(1);
                txtTenBenhNhan.Text = reader.GetString(2);
                txtCMND.Text = reader.GetString(3);
                txtDanToc.Text = reader.GetString(5);
                txtNgheNghiep.Text = reader.GetString(6);
                txtNguoiThan.Text = reader.GetString(7);
                txtQuanHe.Text = reader.GetString(8);
                txtSDT.Text = reader.GetString(9);
                txtGhiChu.Text = reader.GetString(10);
                txtNgaySinh.Text = reader.GetDateTime(11) + "";
                txtDiaChi.Text = reader.GetString(12);
                txtLoaiBenh.Text = reader.GetString(13);
                txtBaoHiem.Text = reader.GetString(14);
                txtQueQuan.Text = reader.GetString(15);
            }
            reader.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaBenhNhan.Text = "";
            txtTenBN.Text = "";
            txtTenBenhNhan.Text = "";
            txtCMND.Text = "";
            txtDanToc.Text = "";
            txtNgheNghiep.Text = "";
            txtNguoiThan.Text = "";
            txtQuanHe.Text = "";
            txtSDT.Text = "";
            txtGhiChu.Text = "";
            txtNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtLoaiBenh.Text = "";
            txtBaoHiem.Text = "";
            txtQueQuan.Text = "";
            txtTenMuonTim.Text = "";
            txtMaMuonTim.Text = " ";
            txtMaBenhNhan.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
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
