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
    public partial class XemDanhSachTheoKhoa : Form
    {
        public XemDanhSachTheoKhoa()
        {
            InitializeComponent();
        }
        SqlConnection ketnoi = null;
        string strketnoi = "Data Source= DESKTOP-HD4HHJ3\\SQLEXPRESS;  Initial Catalog=CSDL_DoAnQLBNNhaKhoa; Integrated Security=True";

        private void XemDanhSachTheoKhoa_Load(object sender, EventArgs e)
        {
            if (ketnoi == null)
                ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Closed)
                ketnoi.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from PhongKhoa";
            command.Connection = ketnoi;
            lsbDanhMuc.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            int n = 0;
            while (reader.Read())//Có Dữ Liệu
            {

                n++;
                string Line = reader.GetString(0) + "-" + reader.GetString(1);
                lsbDanhMuc.Items.Add("STT." + n);
                lsbDanhMuc.Items.Add(Line);

            }
            reader.Close();
        }

        private void lvBenhNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            command.CommandText = "select * from PhanPhong where MaKhoa=@MK";
            command.Connection = ketnoi;
            SqlParameter parameter = new SqlParameter("@MK", SqlDbType.NVarChar);
            parameter.Value = ma;
            command.Parameters.Add(parameter);
            lvBenhNhan.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            int m = 0;
            while (reader.Read())//Có Dữ Liệu
            {
                string MaBenhNhan = reader.GetString(0);
                string MaKhoa = reader.GetString(1);
                string LoaiPhong = reader.GetString(2);
                string ThoiGianLuuTru = reader.GetString(3);
                string MucDoBenh = reader.GetString(4);
                string GiaTien = reader.GetString(5);

                ListViewItem lvi = new ListViewItem(MaBenhNhan + "");
                lvi.SubItems.Add(MaKhoa);
                lvi.SubItems.Add(LoaiPhong);
                lvi.SubItems.Add(ThoiGianLuuTru);
                // lvi.SubItems.Add(GioiTinh);
                lvi.SubItems.Add(MucDoBenh);
                lvi.SubItems.Add(GiaTien);

                lvBenhNhan.Items.Add(lvi);
                m++;



            }
            txtTT.Text = "CÓ TẤT CẢ " + m + " BỆNH NHÂN CÓ MÃ KHOA LÀ " + ma + " ";
            reader.Close();


        }
    }
}
