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
namespace DoAnChinhThuc.FormThongKe
{
    public partial class TongBenhNhan : Form
    {
        public TongBenhNhan()
        {
            InitializeComponent();
        }
        SqlConnection ketnoi = null;
        string strketnoi = "Data Source= DESKTOP-HD4HHJ3\\SQLEXPRESS;  Initial Catalog=CSDL_DoAnQLBNNhaKhoa; Integrated Security=True";

        private void btnDem_Click(object sender, EventArgs e)
        {

           
        }
         
        private void txtTongBenhNhan_TextChanged(object sender, EventArgs e)
        {
          
        }
        //public void TongBenhNhan2()
        //{
        //    if (ketnoi == null)
        //        ketnoi = new SqlConnection(strketnoi);
        //    if (ketnoi.State == ConnectionState.Closed)
        //        ketnoi.Open();
        //    SqlCommand command = new SqlCommand();
        //    command.CommandType = CommandType.Text;
        //    command.CommandText = (@"SELECT * FROM ThongTinBenhNhan WHERE MaQueQuan=@Ma ");
        //    command.Connection = ketnoi;
        //    SqlParameter parameter = new SqlParameter("@Ma", SqlDbType.NVarChar);
        //    parameter.Value = "DT"+3;
        //    //SqlCommand.Parameter.Add(parameter);
        //    object data = parameter.ExecuteScalar();
        //    nt n = (int)data;
        //    txtTongBenhNhan2.Text = "CÓ TẤT CẢ " + n + " BỆNH NHÂN";
        //}

        private void TongBenhNhan_Load(object sender, EventArgs e)
        {
            TongBenhNhan1();
            TongBenhNhan2();
            TongBenhNhan3();
            TongBenhNhan4();


        }
        public void TongBenhNhan1()
        { 
            if (ketnoi == null)
                ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Closed)
                ketnoi.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select count (*) from ThongTinBenhNhan  ";
            command.Connection = ketnoi;
            object data = command.ExecuteScalar();
            int n = (int)data;
            txtTongBenhNhan.Text = "CÓ TẤT CẢ " + n + " BỆNH NHÂN";
             
        }
        public void TongBenhNhan2()
        {
            if (ketnoi == null)
                ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Closed)
                ketnoi.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select count (*) from PhongKhoa  ";
            command.Connection = ketnoi;
            object data = command.ExecuteScalar();
            int n = (int)data;
           txt2.Text = "CÓ TẤT CẢ " + n + " PHÒNG KHOA KHÁC NHAU";
        }
        public void TongBenhNhan3()
        {
            if (ketnoi == null)
                ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Closed)
                ketnoi.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select count (*) from QueQuan  ";
            command.Connection = ketnoi;
            object data = command.ExecuteScalar();
            int n = (int)data;
            txt3.Text = "CÓ TẤT CẢ " + n + " TỈNH THÀNH ĐÃ ĐƯỢC CẬP NHẬT";
        }
        public void TongBenhNhan4()
        {
            if (ketnoi == null)
                ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Closed)
                ketnoi.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select count (*) from PhanPhong  ";
            command.Connection = ketnoi;
            object data = command.ExecuteScalar();
            int n = (int)data;
            txt4.Text = "CÓ TẤT CẢ " + n + " BỆNH NHÂN ĐĂNG KÝ Ở LẠI BỆNH VIỆN";
        }

        private void txtDem2_TextChanged(object sender, EventArgs e)
        {
           
           

        }

        private void txtTongBenhNhan_TextChanged_2(object sender, EventArgs e)
        {

           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
