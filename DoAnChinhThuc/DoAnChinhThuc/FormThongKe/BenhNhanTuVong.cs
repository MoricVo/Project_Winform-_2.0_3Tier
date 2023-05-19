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
    public partial class BenhNhanTuVong : Form
    {
        public BenhNhanTuVong()
        {
            InitializeComponent();
        }
        SqlConnection ketnoi = null;
        string strketnoi = "Data Source= DESKTOP-HD4HHJ3\\SQLEXPRESS;  Initial Catalog=CSDL_DoAnQLBNNhaKhoa; Integrated Security=True";
        public void TongBenhNhanAG1()
        {
            if (ketnoi == null)
                ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Closed)
                ketnoi.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select count (*) from NhanVien";
            command.Connection = ketnoi;
            object data = command.ExecuteScalar();
            int n = (int)data;
            txtTongBenhNhanAG.Text = "CÓ TẤT CẢ " + n + " NHÂN VIÊN";
        }
       public void TongNhanVien2()
        {
            if (ketnoi == null)
                ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Closed)
                ketnoi.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from NhanVien where ChucVu=@ma";
            sqlCommand.Connection = ketnoi;

            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.NVarChar);       
            parMa.Value = "QuanTriVien ";
            

            sqlCommand.Parameters.Add(parMa);
           
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            int m = 0;
           
            while (sqlReader.Read())
            {
                
                    m++;
                
                   
                
            }
           
            txt2.Text = " CÓ TẤT CẢ " + m + " NHÂN VIÊN GIỮ CHỨC VỤ QUẢN TRỊ VIÊN";
          


        }
       

      
      
       
        private void txtTongBenhNhanAG_TextChanged(object sender, EventArgs e)
        {

        }

        private void BenhNhanTuVong_Load(object sender, EventArgs e)
        {
            TongBenhNhanAG1();
            TongNhanVien2();
            
        }
    }
}
