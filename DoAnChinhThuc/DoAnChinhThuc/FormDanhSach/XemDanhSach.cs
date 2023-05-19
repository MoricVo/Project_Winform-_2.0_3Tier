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
namespace DoAnChinhThuc.FormDanhSach
{
    public partial class XemDanhSach : Form
    {
        public XemDanhSach()
        {
            InitializeComponent();
        }
        SqlConnection ketnoi = null;
        string strketnoi = "Data Source= DESKTOP-HD4HHJ3\\SQLEXPRESS;  Initial Catalog=CSDL_DoAnQLBNNhaKhoa; Integrated Security=True";


        private void XemDanhSach_Load(object sender, EventArgs e)
        {
            if (ketnoi == null)
                ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Closed)
                ketnoi.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from QueQuan";
            command.Connection = ketnoi;
            lsbDanhMuc.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            int n = 0;
           while (reader.Read())//Có Dữ Liệu
            {
               
                n++;            
                string Line = reader.GetString(0) + "-" + reader.GetString(1);
                lsbDanhMuc.Items.Add("STT."+n);
                lsbDanhMuc.Items.Add( Line);
                
            }
            reader.Close();

        }

        private void lsbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbDanhMuc.SelectedIndex == -1)

                return;

            string line = lsbDanhMuc.SelectedItem.ToString();
            string[] arr = line.Split('-');
            string ma = (arr[0]);
            if (ketnoi == null)
                ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Closed)
                ketnoi.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from ThongTinBenhNhan where MaQueQuan=@mqq";
            command.Connection = ketnoi;
            SqlParameter parameter = new SqlParameter("@mqq", SqlDbType.NVarChar);
            parameter.Value = ma;
            command.Parameters.Add(parameter);
            lvBenhNhan.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            int m = 0;
            while (reader.Read())//Có Dữ Liệu
            {
                string Ma = reader.GetString(0);
                string Ten = reader.GetString(1);
                string HoTen = reader.GetString(2);
                string CMND = reader.GetString(3);
               // byte_GioiTinh = reader.GetSqlByte(4);
                string DanToc = reader.GetString(5);
                string NgheNghiep = reader.GetString(6);
                string NguoiThan = reader.GetString(7);
                string QuanHe = reader.GetString(8);
                string SDT = reader.GetString(9);
                string GhiChu = reader.GetString(10);
                
                string DiaChi = reader.GetString(12);
                string LoaiBenh = reader.GetString(13);
                string BaoHiem = reader.GetString(14);
                string MaQueQuan = reader.GetString(15);             
                ListViewItem lvi = new ListViewItem(Ma + "");
                lvi.SubItems.Add(Ten);
                lvi.SubItems.Add(HoTen);
                lvi.SubItems.Add(CMND);
               // lvi.SubItems.Add(GioiTinh);
                lvi.SubItems.Add(DanToc);
                lvi.SubItems.Add(NgheNghiep);
                lvi.SubItems.Add(NguoiThan);
                lvi.SubItems.Add(QuanHe);
                lvi.SubItems.Add(SDT);
                lvi.SubItems.Add(GhiChu);
                lvi.SubItems.Add(DiaChi);
                lvi.SubItems.Add(LoaiBenh);
                lvi.SubItems.Add(BaoHiem);
                lvi.SubItems.Add(MaQueQuan);
                lvBenhNhan.Items.Add(lvi);
                m++;



            }
            txtTT.Text = "CÓ TẤT CẢ " + m + " BỆNH NHÂN CÓ MÃ QUÊ QUÁN Ở "+ma+" ";
            reader.Close();



        }
        private void lvBenhNhan_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}
