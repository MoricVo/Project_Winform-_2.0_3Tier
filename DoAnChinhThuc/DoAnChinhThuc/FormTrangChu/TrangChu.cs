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
namespace DoAnChinhThuc.FormTrangChu
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }
        SqlConnection ketnoi = null;
        string strketnoi = "Data Source= DESKTOP-HD4HHJ3\\SQLEXPRESS;  Initial Catalog=CSDL_DoAnQuanLyBenhNhan; Integrated Security=True";

        private void mnuChiTiet_Click(object sender, EventArgs e)
        {
            ThongSoKyThuat aboutBox = new ThongSoKyThuat();
            aboutBox.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi = new SqlConnection(strketnoi);
                ketnoi.Open();
                MessageBox.Show("Kết nối với CSDL thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(ketnoi!=null&&ketnoi.State==ConnectionState.Open)
            {
                ketnoi.Close();
                MessageBox.Show("Đã đóng kết nối với CSDL thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
           // lblTg.Text = DateTime.Now.ToLongTimeString();
            //lblYear.Text = DateTime.Now.ToLongDateString();
        }

        private void lblTg_Click(object sender, EventArgs e)
        {

        }
    }
}
