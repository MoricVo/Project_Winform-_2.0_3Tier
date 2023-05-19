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
    public partial class PhongKhoa : Form
    {
        LopDuLieuDungChung dataTable = new LopDuLieuDungChung();
        public PhongKhoa()
        {
            InitializeComponent();
            dataTable.OpenConnection();
        }
       
        public void LayDuLieu()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PhongKhoa");
            dataTable.Fill(cmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;
            dataGridView1.DataSource = binding;
            bindingNavigator1.BindingSource = binding;
            txtMaKhoa.DataBindings.Clear();
            txtTenKhoa.DataBindings.Clear();               
            txtTruongKhoa.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            cboPhanKhu.DataBindings.Clear();
            cbNhanVien.DataBindings.Clear();
            //Liên kết dữ liệu lên các Control
            txtMaKhoa.DataBindings.Add("Text", binding, "MaKhoa");
            txtTenKhoa.DataBindings.Add("Text", binding, "TenKhoa");
            txtTruongKhoa.DataBindings.Add("Text", binding, "TruongKhoa");
            txtSDT.DataBindings.Add("Text", binding, "SDTTruongKhoa");
            cboPhanKhu.DataBindings.Add("Text", binding, "DiaDiem");
            cbNhanVien.DataBindings.Add("SelectedValue", binding, "MaNhanVien");

        }
        public void LayDuLieu1(string tim)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM PhongKhoa WHERE MaKhoa LIKE N'%" + tim + "%'" +
                                                                 "OR TenKhoa LIKE N'%" + tim + "%'");
            dataTable.Fill(cmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;
            dataGridView1.DataSource = binding;
            bindingNavigator1.BindingSource = binding;
            txtMaKhoa.DataBindings.Clear();
            txtTenKhoa.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            cboPhanKhu.DataBindings.Clear();
            txtTruongKhoa.DataBindings.Clear();
            cbNhanVien.DataBindings.Clear();
            //Liên kết dữ liệu lên các Control
            txtMaKhoa.DataBindings.Add("Text", binding, "MaKhoa");
            txtTenKhoa.DataBindings.Add("Text", binding, "TenKhoa");
            txtTruongKhoa.DataBindings.Add("Text", binding, "TruongKhoa");
            txtSDT.DataBindings.Add("Text", binding, "SDTTruongKhoa");
            cboPhanKhu.DataBindings.Add("Text", binding, "DiaDiem");
            cbNhanVien.DataBindings.Add("SelectedValue", binding, "MaNhanVien");
        }
        public void LayDuLieuTableNhanVien(DataGridViewComboBoxColumn columnName)
        {
            LopDuLieuDungChung dataTable = new LopDuLieuDungChung();
            dataTable.OpenConnection();
            string sql = "SELECT * FROM NhanVien";
            SqlCommand command = new SqlCommand(sql);
            dataTable.Fill(command);
            columnName.DataSource = dataTable;
            columnName.DisplayMember = "TenNhanVien";
            columnName.ValueMember = "MaNhanVien";
            columnName.DataPropertyName = "MaNhanVien";
        }
        public void LayDuLieuTableNhanVien(ComboBox comboBox)
        {
            LopDuLieuDungChung dataTable = new LopDuLieuDungChung();
            dataTable.OpenConnection();
            string sql = "SELECT * FROM NhanVien";
            SqlCommand command = new SqlCommand(sql);
            dataTable.Fill(command);
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = "TenNhanVien";
            comboBox.ValueMember = "MaNhanVien";
        }
        private void SpThemThongTin_Click(object sender, EventArgs e)
        {
            DataRow dataRow = dataTable.NewRow();
            dataRow["MaKhoa"] = "";
            dataRow["TenKhoa"] = "";
            dataRow["TruongKhoa"] = "";
            dataRow["SDTTruongKhoa"]="";
            dataRow["DiaDiem"] = "";
            dataRow["MaNhanVien"] = " ";
            dataTable.Rows.Add(dataRow);
            bindingNavigator1.BindingSource.MoveLast();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SpLuuThongTin_Click(object sender, EventArgs e)
        {
            if (KiemTra("MaKhoa") && KiemTra("TenKhoa")&&KiemTra("TruongKhoa")&&KiemTra("DiaDiem"))
            {
                int result = dataTable.Update();
                MessageBox.Show("Đã cập nhật thành công " + result + " dòng dữ liệu!", "Cập nhật",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void PhongKhoa_Load(object sender, EventArgs e)
        {
            LayDuLieuTableNhanVien(MaNhanVien);
            LayDuLieuTableNhanVien(cbNhanVien);        
            LayDuLieu();
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            LayDuLieu1(txtTim.Text);
        }
        public bool KiemTraMaQQ(string MK)
        {
            SqlConnection conn = new SqlConnection(dataTable.ConnectionString());
            conn.Open();
            string sql = "SELECT MaKhoa FROM PhongKhoa WHERE MaKhoa = '" + MK + "'";
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
            if (txtMaKhoa.Text.Trim() == "")
                MessageBox.Show("Mã khoa không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTenKhoa.Text.Trim() == "")
                MessageBox.Show("Tên khoa không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTruongKhoa.Text.Trim() == "")
                MessageBox.Show("Tên trưởng khoa không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (KiemTraMaQQ(txtMaKhoa.Text))
            
                MessageBox.Show("Mã khoa không được trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            else
            {
                string sql = @"INSERT INTO PhongKhoa VALUES(@MaKhoa, @TenKhoa, @TruongKhoa, @SDTTruongKhoa,@DiaDiem,@MaNhanVien)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.Add("@MaKhoa", SqlDbType.NVarChar, 5).Value = txtMaKhoa.Text;
                cmd.Parameters.Add("@TenKhoa", SqlDbType.NVarChar, 50).Value = txtTenKhoa.Text;
                cmd.Parameters.Add("@TruongKhoa", SqlDbType.NVarChar, 50).Value = txtTruongKhoa.Text;
                cmd.Parameters.Add("@SDTTruongKhoa", SqlDbType.NVarChar, 50).Value = txtSDT.Text;
                cmd.Parameters.Add("@DiaDiem", SqlDbType.NVarChar, 50).Value = cboPhanKhu.Text;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar,2).Value = cbNhanVien.SelectedValue;
                MessageBox.Show("Cập nhật thành công!", "Chúc mừng!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataTable.Update(cmd);

                LayDuLieu();
                bindingNavigator1.BindingSource.MoveLast();
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
            txtTruongKhoa.Text = "";
            txtSDT.Text = "";
            cboPhanKhu.Text = "";
            cbNhanVien.Text = "";
            txtMaKhoa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            btnLuu.Enabled = false;
            SqlConnection conn = new SqlConnection(dataTable.ConnectionString());
            try
            {
                conn.Open();
                string sql = "UPDATE PhongKhoa SET TenKhoa = N'" + txtTenKhoa.Text +
                                                              "', TruongKhoa = N'" + txtTruongKhoa.Text +
                                                              "', SDTTruongKhoa = N'" + txtSDT.Text+
                                                              "', DiaDiem = N'" + cboPhanKhu.Text +
                                                               "', MaNhanVien = N'" + cbNhanVien.SelectedValue +
                                                              "' WHERE MaKhoa = N'" + txtMaKhoa.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);

                int kq = (int)cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thành công!", "Chúc mừng!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Xóa thất bại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayDuLieu();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string sql = "DELETE FROM PhongKhoa WHERE MaKhoa = '" + txtMaKhoa.Text + "'";
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            btnLuu.Enabled = true;
            PhongKhoa_Load(sender, e);
        }
    }
}
