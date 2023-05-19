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
    public partial class PhanPhong : Form
    {
        LopDuLieuDungChung dataTable = new LopDuLieuDungChung();
        public PhanPhong()
        {
            InitializeComponent();
            dataTable.OpenConnection();
        }
        public void LayDuLieu()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PhanPhong");
            dataTable.Fill(cmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;
            bindingNavigator1.BindingSource = binding;
            dataGridView1.DataSource = binding;
            cboBenhNhan.DataBindings.Clear();
            cboThuocKhoa.DataBindings.Clear();
            cboLoaiPhong.DataBindings.Clear();
            txtThoiGian.DataBindings.Clear();
            cboMucDoBenh.DataBindings.Clear();
            txtGiaTien.DataBindings.Clear();
            // Liên kết dữ liệu từ DataGridView lên các control
            cboBenhNhan.DataBindings.Add("SelectedValue", binding, "MaBenhNhan");
            cboThuocKhoa.DataBindings.Add("SelectedValue", binding, "MaKhoa");
            cboLoaiPhong.DataBindings.Add("Text", binding, "LoaiPhong");
            txtThoiGian.DataBindings.Add("Text", binding, "ThoiGian");
            cboMucDoBenh.DataBindings.Add("Text", binding, "MucDoBenh");
            txtGiaTien.DataBindings.Add("Text", binding, "GiaTien");
        }
        public void LayDuLieu1(string Tim)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM PhanPhong WHERE MaBenhNhan LIKE N'%" + Tim + "%'" +
                                                                  "OR MaKhoa LIKE N'%" + Tim + "%'");
            dataTable.Fill(cmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;
            bindingNavigator1.BindingSource = binding;
            dataGridView1.DataSource = binding;
            //Clear
            cboBenhNhan.DataBindings.Clear();
            cboThuocKhoa.DataBindings.Clear();
            cboLoaiPhong.DataBindings.Clear();
            txtThoiGian.DataBindings.Clear();
            cboMucDoBenh.DataBindings.Clear();
            txtGiaTien.DataBindings.Clear();
            // Liên kết dữ liệu từ DataGridView lên các control
            cboBenhNhan.DataBindings.Add("SelectedValue", binding, "MaBenhNhan");
            cboThuocKhoa.DataBindings.Add("SelectedValue", binding, "MaKhoa");
            cboLoaiPhong.DataBindings.Add("Text", binding, "LoaiPhong");
            txtThoiGian.DataBindings.Add("Text", binding, "ThoiGian");
            cboMucDoBenh.DataBindings.Add("Text", binding, "MucDoBenh");
            txtGiaTien.DataBindings.Add("Text", binding, "GiaTien");
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        //Đổ dữ liệu từ table bệnh nhân lên Datagridview và comnobox
        public void LayDuLieuTableBenhNhan(DataGridViewComboBoxColumn columnName)
        {
            LopDuLieuDungChung dataTable = new LopDuLieuDungChung();
            dataTable.OpenConnection();
            string sql = "SELECT * FROM ThongTinBenhNhan";
            SqlCommand command = new SqlCommand(sql);
            dataTable.Fill(command);
            columnName.DataSource = dataTable;
            columnName.DisplayMember = "HoVaTen";
            columnName.ValueMember = "MaBenhNhan";
            columnName.DataPropertyName = "MaBenhNhan";
        }
        public void LayDuLieuTableBenhNhan(ComboBox comboBox)
        {
            LopDuLieuDungChung dataTable = new LopDuLieuDungChung();
            dataTable.OpenConnection();
            string sql = "SELECT * FROM ThongTinBenhNhan";
            SqlCommand command = new SqlCommand(sql);
            dataTable.Fill(command);
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = "HoVaTen";
            comboBox.ValueMember = "MaBenhNhan";
        }
        //Đổ dự liệu từ table khoa lên Datagridview và comnobox
        public void LayDuLieuTablePhongKhoa(DataGridViewComboBoxColumn columnName)
        {
            LopDuLieuDungChung dataTable = new LopDuLieuDungChung();
            dataTable.OpenConnection();
            string sql = "SELECT * FROM PhongKhoa";
            SqlCommand command = new SqlCommand(sql);
            dataTable.Fill(command);
            columnName.DataSource = dataTable;
            columnName.DisplayMember = "TenKhoa";
            columnName.ValueMember = "MaKhoa";
            columnName.DataPropertyName = "MaKhoa";
        }
        public void LayDuLieuTablePhongKhoa(ComboBox comboBox)
        {
            LopDuLieuDungChung dataTable = new LopDuLieuDungChung();
            dataTable.OpenConnection();
            string sql = "SELECT * FROM PhongKhoa";
            SqlCommand command = new SqlCommand(sql);
            dataTable.Fill(command);
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = "TenKhoa";
            comboBox.ValueMember = "MaKhoa";
        }
        private void PhanPhong_Load(object sender, EventArgs e)
        {
            LayDuLieuTableBenhNhan(cboBenhNhan);
            LayDuLieuTableBenhNhan(MaBenhNhan);
            LayDuLieuTablePhongKhoa(cboThuocKhoa);
            LayDuLieuTablePhongKhoa(MaKhoa);
            LayDuLieu();
        }

        private void SpThemThongTin_Click(object sender, EventArgs e)
        {
            DataRow dataRow = dataTable.NewRow();
            dataRow["MaBenhNhan"] = "";
            dataRow["MaKhoa"] = "";              
            dataRow["LoaiPhong"] = "";
            dataRow["ThoiGian"] = "";
            dataRow["MucDoBenh"] = "";
            dataTable.Rows.Add(dataRow);
            bindingNavigator1.BindingSource.MoveLast();
        }

        private void SpLuuThongTin_Click(object sender, EventArgs e)
        {
              if (KiemTra("MaBenhNhan") && KiemTra("MaKhoa") && KiemTra("LoaiPhong") && KiemTra("MucDoBenh"))
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
            LayDuLieu1(txtTim.Text);
        }
        public bool KiemTraMaQQ(string MK)
        {
            SqlConnection conn = new SqlConnection(dataTable.ConnectionString());
            conn.Open();
            string sql = "SELECT MaBenhNhan FROM PhanPhong WHERE MaBenhNhan = '" + MK + "'";
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
      
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtGiaTien.Text.Trim()=="")
                MessageBox.Show("Giá tiền không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboLoaiPhong.Text.Trim() == "")
                MessageBox.Show("Loại phòng không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtThoiGian.Text.Trim() == "")
                MessageBox.Show("Thời gian lưu trú không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (KiemTraMaQQ(cboBenhNhan.Text))
            
                MessageBox.Show("Mã bệnh nhân không được trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            else
            {
                string sql = @"INSERT INTO PhanPhong VALUES(@MaBenhNhan, @MaKhoa, @LoaiPhong, @ThoiGian,@MucDoBenh,@GiaTien)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.Add("@MaBenhNhan", SqlDbType.NVarChar, 5).Value = cboBenhNhan.SelectedValue.ToString();
                cmd.Parameters.Add("@MaKhoa", SqlDbType.NVarChar, 5).Value = cboThuocKhoa.SelectedValue.ToString();
                cmd.Parameters.Add("@LoaiPhong", SqlDbType.NVarChar, 12).Value = cboLoaiPhong.Text;
                cmd.Parameters.Add("@ThoiGian", SqlDbType.NVarChar, 50).Value = txtThoiGian.Text;
                cmd.Parameters.Add("@MucDoBenh", SqlDbType.NVarChar, 50).Value = cboMucDoBenh.Text;
                cmd.Parameters.Add("@GiaTien", SqlDbType.NVarChar, 50).Value = txtGiaTien.Text;
                MessageBox.Show("Cập nhật thành công!", "Chúc mừng!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataTable.Update(cmd);

                LayDuLieu();
                bindingNavigator1.BindingSource.MoveLast();
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            cboBenhNhan.Text = "";
            cboThuocKhoa.Text = "";
            cboLoaiPhong.Text = "";
            txtThoiGian.Text = "";
            cboMucDoBenh.Text = "";
            txtGiaTien.Text = "";
            cboBenhNhan.Focus();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult thongbao = MessageBox.Show("Bạn có chắc muốn xóa dòng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(dataTable.ConnectionString());
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM PhanPhong WHERE MaBenhNhan = '" + cboBenhNhan.SelectedValue + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công bệnh nhân có mã "+cboBenhNhan.SelectedValue+"! ");
                    LayDuLieu();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Lỗi kết nối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            SqlConnection conn = new SqlConnection(dataTable.ConnectionString());
            try
            {
                conn.Open();
                string sql = "UPDATE PhanPhong SET MaKhoa = N'" + cboThuocKhoa.SelectedValue +
                                                              "', LoaiPhong = N'" + cboLoaiPhong.Text +
                                                              "', ThoiGian = N'" + txtThoiGian.Text +
                                                              "', MucDoBenh = N'" + cboMucDoBenh.Text +
                                                               "', GiaTien = N'" + txtGiaTien.Text +
                                                              "' WHERE MaBenhNhan = N'" + cboBenhNhan.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);

                int kq = (int)cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thành công!", "Chúc mừng!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Sửa thất bại!", "Chúc mừng!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayDuLieu();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Refresh();
            button1.Enabled = true;
            PhanPhong_Load(sender, e);
        }
    }
}
