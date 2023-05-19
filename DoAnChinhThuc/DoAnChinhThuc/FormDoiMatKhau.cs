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
namespace DoAnChinhThuc
{
    public partial class FormDoiMatKhau : Form
    {
        string TenTaiKhoan = "";
        LopDuLieuDungChung datable = new LopDuLieuDungChung();
        public FormDoiMatKhau(string tk)
        {
            TenTaiKhoan = tk;
            datable.OpenConnection();
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(txtMatKhau.Text==txtMatKhauMoi.Text)
            {
                SqlCommand cmd = new SqlCommand("UPDATE NhanVien SET MatKhau=@mk WHERE TenTaiKhoan=@tk");
                cmd.Parameters.Add("@tk", SqlDbType.NVarChar).Value = TenTaiKhoan;
                cmd.Parameters.Add("@mk", SqlDbType.NVarChar).Value = txtMatKhau.Text;
                datable.Update(cmd);
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                this.Close();

            }    
            else
            {
                MessageBox.Show("Mật khẩu sai!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }    
        }
    }
}
