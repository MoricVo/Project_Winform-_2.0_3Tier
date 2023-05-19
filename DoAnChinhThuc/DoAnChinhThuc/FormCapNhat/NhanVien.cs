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
    public partial class NhanVien : Form
    {
        LopDuLieuDungChung dataTable = new LopDuLieuDungChung();
        public NhanVien()
        {
            InitializeComponent();
            dataTable.OpenConnection();

        }
        public void LayDuLieu()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien");
            dataTable.Fill(cmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;
            dataGridView1.DataSource = binding;
            bindingNavigator1.BindingSource = binding;
            //Liên kết dữ liệu lên các Control
            txtMaNhanVien.DataBindings.Clear();
            txtTenNhanVien.DataBindings.Clear();
            cbChucVu.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtTK.DataBindings.Clear();
            txtMatKhau.DataBindings.Clear();
            txtMaNhanVien.DataBindings.Add("Text", binding, "MaNhanVien");
            txtTenNhanVien.DataBindings.Add("Text", binding, "TenNhanVien");
            cbChucVu.DataBindings.Add("Text", binding, "ChucVu");
            txtSDT.DataBindings.Add("Text", binding, "SDTNhanVien");
            txtTK.DataBindings.Add("Text", binding, "TenTaiKhoan");
            txtMatKhau.DataBindings.Add("Text", binding, "MatKhau");
        }
        public void LayDuLieu1(string Tim)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM NhanVien WHERE MaNhanVien LIKE N'%" + Tim + "%'" + "OR TenNhanVien LIKE N'%" + Tim + "%'");
            dataTable.Fill(cmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;
            dataGridView1.DataSource = binding;
            bindingNavigator1.BindingSource = binding;
            //Clear
            txtMaNhanVien.DataBindings.Clear();
            txtTenNhanVien.DataBindings.Clear();
            cbChucVu.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtTK.DataBindings.Clear();
            txtMatKhau.DataBindings.Clear();
            //Liên kết dữ liệu lên các Control
            txtMaNhanVien.DataBindings.Add("Text", binding, "MaNhanVien");
            txtTenNhanVien.DataBindings.Add("Text", binding, "TenNhanVien");
            cbChucVu.DataBindings.Add("Text", binding, "ChucVu");
            txtSDT.DataBindings.Add("Text", binding, "SDTNhanVien");
            txtTK.DataBindings.Add("Text", binding, "TenTaiKhoan");
            txtMatKhau.DataBindings.Add("Text", binding, "MatKhau");
        }
        
        private void NhanVien_Load(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void SpThemThongTin_Click(object sender, EventArgs e)
        {
            DataRow dataRow = dataTable.NewRow();
            dataRow["MaNhanVien"] = "";
            dataRow["TenNhanVien"] = "";
            dataRow["ChucVu"] = "";
            dataRow["SDTNhanVien"] = "";
            dataRow["TenTaiKhoan"] = "";
            dataRow["MatKhau"] = "";
            dataTable.Rows.Add(dataRow);
            bindingNavigator1.BindingSource.MoveLast();
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

        private void SpLuuThongTin_Click(object sender, EventArgs e)
        {
            if (KiemTra("MaNhanVien") && KiemTra("TenNhanVien"))
            {
                int result = dataTable.Update();
                MessageBox.Show("Đã cập nhật thành công " + result + " dòng dữ liệu!", "Cập nhật",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "MatKhau")
            {
                e.Value = "••••••••••";
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LayDuLieu1(txtTim.Text);
        }
        public bool KiemTraMaQQ(string maNV)
        {
            SqlConnection conn = new SqlConnection(dataTable.ConnectionString());
            conn.Open();
            string sql = "SELECT MaNhanVien FROM NhanVien WHERE MaNhanVien = '" + maNV + "'";
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
            if (txtMaNhanVien.Text.Trim() == "")
                MessageBox.Show("Mã nhân viên không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTenNhanVien.Text.Trim() == "")
                MessageBox.Show("Tên nhân viên không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cbChucVu.Text.Trim() == "")
                MessageBox.Show("Chức vụ không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (KiemTraMaQQ(txtMaNhanVien.Text))
            
                MessageBox.Show("Mã nhân viên không được trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            else
            {
                string sql = @"INSERT INTO NhanVien VALUES(@MaNhanVien, @TenNhanVien,@ChucVu,@SDTNhanVien,@TenTaiKhoan,@MatKhau)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar, 2).Value = txtMaNhanVien.Text;
                cmd.Parameters.Add("@TenNhanVien", SqlDbType.NVarChar, 50).Value = txtTenNhanVien.Text;
                cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar, 50).Value = cbChucVu.Text;
                cmd.Parameters.Add("@SDTNhanVien", SqlDbType.NVarChar, 50).Value = txtSDT.Text;
                cmd.Parameters.Add("@TenTaiKhoan", SqlDbType.NVarChar, 50).Value = txtTK.Text;
                cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).Value = txtMatKhau.Text;
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
                    string sql = "DELETE FROM NhanVien WHERE MaNhanVien = '" + txtMaNhanVien.Text + "'";
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

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            cbChucVu.Text = "";
            txtSDT.Text = "";
            txtTK.Text = "";
            txtMatKhau.Text = "";
            txtMaNhanVien.Focus();


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            SqlConnection conn = new SqlConnection(dataTable.ConnectionString());
            try
            {
                conn.Open();
                string sql = "UPDATE NhanVien SET TenNhanVien = N'" + txtTenNhanVien.Text +
                                                            "', ChucVu = N'" + cbChucVu.Text +
                                                           "', SDTNhanVien = N'" + txtSDT.Text +
                                                             "', TenTaiKhoan = N'" + txtTK.Text +
                                                               "', MatKhau = N'" + txtMatKhau.Text +
                                                              "' WHERE MaNhanVien = N'" + txtMaNhanVien.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);

                int kq = (int)cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thành công!", "Chúc mừng!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Sửa thất bại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayDuLieu();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            NhanVien_Load(sender, e);
            btnLuu.Enabled = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void txtTim_Click(object sender, EventArgs e)
        {

        }
    }
}
