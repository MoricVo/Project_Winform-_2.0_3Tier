using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnChinhThuc.FormDanhGia
{
    public partial class DanhGia : Form
    {
        public DanhGia()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Cảm ơn bạn đã phản hồi!Hệ thống đã ghi nhận.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cảm ơn bạn đã phản hồi!Hệ thống đã ghi nhận.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
