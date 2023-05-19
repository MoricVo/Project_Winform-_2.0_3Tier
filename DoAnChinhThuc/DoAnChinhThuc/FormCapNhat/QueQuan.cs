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
namespace DoAnChinhThuc.FormCapNhat
{
    public partial class QueQuan : Form
    {


        LopDuLieuDungChung dataTable = new LopDuLieuDungChung();
        public QueQuan()
        {
            InitializeComponent();
            dataTable.OpenConnection();

        }
        public void LayDuLieu()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM QueQuan");
            dataTable.Fill(cmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;
            dataGridView1.DataSource = binding;
            bindingNavigator1.BindingSource = binding;
            txtMaQueQuan.DataBindings.Clear();
            txtTenQueQuan.DataBindings.Clear();
            cbVungMien.DataBindings.Clear();
            cbLoaiVung.DataBindings.Clear();
            //Liên kết dữ liệu lên các Control
            txtMaQueQuan.DataBindings.Add("Text", binding, "MaQueQuan");
            txtTenQueQuan.DataBindings.Add("Text", binding, "TenQueQuan");
            cbVungMien.DataBindings.Add("Text", binding, "DiaChiCuThe");
            cbLoaiVung.DataBindings.Add("Text", binding, "LoaiVung");
        }
        public void LayDuLieu1(string Tim)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM QueQuan WHERE MaQueQuan LIKE N'%" + Tim + "%'" +"OR TenQueQuan LIKE N'%" + Tim + "%'");
            dataTable.Fill(cmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;
            dataGridView1.DataSource = binding;
            bindingNavigator1.BindingSource = binding;
            //Liên kết dữ liệu lên các Control
            txtTenQueQuan.DataBindings.Clear();
            txtMaQueQuan.DataBindings.Clear();
            cbVungMien.DataBindings.Clear();
            cbLoaiVung.DataBindings.Clear();
            txtMaQueQuan.DataBindings.Add("Text", binding, "MaQueQuan");
            txtTenQueQuan.DataBindings.Add("Text", binding, "TenQueQuan");
            cbVungMien.DataBindings.Add("Text", binding, "DiaChiCuThe");
            cbLoaiVung.DataBindings.Add("Text", binding, "LoaiVung");
        }



        private void QueQuan_Load(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void lvQueQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void SpThemThongTin_Click(object sender, EventArgs e)
        {

            DataRow dataRow = dataTable.NewRow();
            dataRow["MaQueQuan"] = "";
            dataRow["TenQueQuan"] = "";
            dataRow["DiaChiCuThe"] = "";
            dataRow["LoaiVung"] = "";
            dataTable.Rows.Add(dataRow);
            bindingNavigator1.BindingSource.MoveLast();

        }

        private void SpLuuThongTin_Click(object sender, EventArgs e)
        {
            if (KiemTra("MaQueQuan") && KiemTra("TenQueQuan"))
            {
                int result = dataTable.Update();
                MessageBox.Show("Đã cập nhật thành công " + result + " dòng dữ liệu!", "Cập nhật",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public bool KiemTra(string columnName)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string value = row.Cells[columnName].Value.ToString();
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Giá trị của ô không được rỗng!", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void SpXoaThongTin_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "Xóa",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigator1.BindingSource.RemoveCurrent();
                MessageBox.Show("Xóa thông tin thành công!", "Thông báo",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        private void SpThoat_Click(object sender, EventArgs e)
        {
            DialogResult Levi = MessageBox.Show("Bạn có thật sự muốn thoát không?", "Question",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Levi == DialogResult.Yes)
            {
                this.Close();
            }
           

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LayDuLieu1(txtTimm.Text);
        }
        public bool KiemTraMaQQ(string maQQ)
        {
            SqlConnection conn = new SqlConnection(dataTable.ConnectionString());
            conn.Open();
            string sql = "SELECT MaQueQuan FROM QueQuan WHERE MaQueQuan = '" + maQQ + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read() == true)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }
       
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaQueQuan.Text.Trim() == "")
                MessageBox.Show("Mã quê quán không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTenQueQuan.Text.Trim() == "")
                MessageBox.Show("Tên quê quán không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if  (cbLoaiVung.Text.Trim() == "")
                MessageBox.Show("Loại vùng không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(KiemTraMaQQ(txtMaQueQuan.Text))
                MessageBox.Show("Mã quê quán không được trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
            else
            {
                string sql = @"INSERT INTO QueQuan VALUES(@MaQueQuan, @TenQueQuan, @DiaChiCuThe, @LoaiVung)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.Add("@MaQueQuan", SqlDbType.NVarChar, 2).Value = txtMaQueQuan.Text;
                cmd.Parameters.Add("@TenQueQuan", SqlDbType.NVarChar, 50).Value = txtTenQueQuan.Text;
                cmd.Parameters.Add("@DiaChiCuThe", SqlDbType.NVarChar, 50).Value = cbVungMien.Text;
                cmd.Parameters.Add("@LoaiVung", SqlDbType.NVarChar, 50).Value = cbLoaiVung.Text;
                MessageBox.Show("Cập nhật thành công!", "Chúc mừng!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataTable.Update(cmd);

                LayDuLieu();
                bindingNavigator1.BindingSource.MoveLast();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao = MessageBox.Show("Bạn có chắc muốn xóa dòng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(dataTable.ConnectionString());
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM QueQuan WHERE MaQueQuan = '" + txtMaQueQuan.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!", "Chúc mừng!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayDuLieu();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Lỗi kết nối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void btnThemMoi_Click(object sender, EventArgs e)
        {
            cbVungMien.Text = " ";
            cbLoaiVung.Text = " ";
            txtMaQueQuan.Text = " ";
            txtTenQueQuan.Text = " ";
            txtMaQueQuan.Focus();
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            SqlConnection conn = new SqlConnection(dataTable.ConnectionString());
            try
            {
                conn.Open();
                string sql = "UPDATE QueQuan SET TenQueQuan = N'" + txtTenQueQuan.Text +
                                                            "', DiaChiCuThe = N'" + cbVungMien.Text +
                                                           "', LoaiVung = N'" + cbLoaiVung.Text +                                                           
                                                              "' WHERE MaQueQuan = N'" + txtMaQueQuan.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);

                int kq = (int)cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thành công!");
                }
                else
                    MessageBox.Show("Sửa thất bại!");
                LayDuLieu();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            this.Refresh();
            QueQuan_Load(sender, e);
        }
    }
}
