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
    public partial class BenhNhan : Form
    {
        LopDuLieuDungChung dataTable = new LopDuLieuDungChung();
        public BenhNhan()
        {
            InitializeComponent();
            dataTable.OpenConnection();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
         private void BenhNhan_Load(object sender, EventArgs e)
        {
            LayDuLieu(cbQueQuan);
            LayDuLieu(MaQueQuan);
            LayDuLieu();
        }
        public void LayDuLieu()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ThongTinBenhNhan");
            dataTable.Fill(cmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;
            bindingNavigator1.BindingSource = binding;
            dataGridView1.DataSource = binding;
            txtMaBN.DataBindings.Clear();
            txtTenBN.DataBindings.Clear();
            txtTenDayDu.DataBindings.Clear();
            txtCMND.DataBindings.Clear();
            chkGioiTinh.DataBindings.Clear();
            txtDanToc.DataBindings.Clear();
            txtNgheNghiep.DataBindings.Clear();
            txtNguoiThan.DataBindings.Clear();
            txtQuanHe.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtChuanDoan.DataBindings.Clear();
            txtBaoHiem.DataBindings.Clear();
            cbQueQuan.DataBindings.Clear();
            // Liên kết dữ liệu từ DataGridView lên các control
            txtMaBN.DataBindings.Add("Text", binding, "MaBenhNhan");
            txtTenBN.DataBindings.Add("Text", binding, "Ten");
            txtTenDayDu.DataBindings.Add("Text", binding, "HoVaTen");
            txtCMND.DataBindings.Add("Text", binding, "CMND");
            chkGioiTinh.DataBindings.Add("Checked", binding, "GioiTinh");
            txtDanToc.DataBindings.Add("Text", binding, "DanToc");
            txtNgheNghiep.DataBindings.Add("Text", binding, "NgheNghiep");
            txtNguoiThan.DataBindings.Add("Text", binding, "NguoiThan");
            txtQuanHe.DataBindings.Add("Text", binding, "QuanHe");
            txtSDT.DataBindings.Add("Text", binding, "SDT");
            txtGhiChu.DataBindings.Add("Text", binding, "GhiChu");
            dtpNgaySinh.DataBindings.Add("Value", binding, "NgaySinh");
            txtDiaChi.DataBindings.Add("Text", binding, "DiaChi");
            txtChuanDoan.DataBindings.Add("Text", binding, "LoaiBenh");
            txtBaoHiem.DataBindings.Add("Text", binding, "BaoHiem");
            cbQueQuan.DataBindings.Add("SelectedValue", binding, "MaQueQuan");
        }
        public void LayDuLieu1(string Tim)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM ThongTinBenhNhan WHERE CMND LIKE N'%" +Tim + "%'" +
                                                                  "OR MaBenhNhan LIKE N'%" + Tim + "%'");
            dataTable.Fill(cmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;
            bindingNavigator1.BindingSource = binding;
            dataGridView1.DataSource = binding;
            //clear
            txtMaBN.DataBindings.Clear();
            txtTenBN.DataBindings.Clear();
            txtTenDayDu.DataBindings.Clear();
            txtCMND.DataBindings.Clear();
            chkGioiTinh.DataBindings.Clear();
            txtDanToc.DataBindings.Clear();
            txtNgheNghiep.DataBindings.Clear();
            txtNguoiThan.DataBindings.Clear();
            txtQuanHe.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtChuanDoan.DataBindings.Clear();
            txtBaoHiem.DataBindings.Clear();
            cbQueQuan.DataBindings.Clear();
            // Liên kết dữ liệu từ DataGridView lên các control
            txtMaBN.DataBindings.Add("Text", binding, "MaBenhNhan");
            txtTenBN.DataBindings.Add("Text", binding, "Ten");
            txtTenDayDu.DataBindings.Add("Text", binding, "HoVaTen");
            txtCMND.DataBindings.Add("Text", binding, "CMND");
            chkGioiTinh.DataBindings.Add("Checked", binding, "GioiTinh");
            txtDanToc.DataBindings.Add("Text", binding, "DanToc");
            txtNgheNghiep.DataBindings.Add("Text", binding, "NgheNghiep");
            txtNguoiThan.DataBindings.Add("Text", binding, "NguoiThan");
            txtQuanHe.DataBindings.Add("Text", binding, "QuanHe");
            txtSDT.DataBindings.Add("Text", binding, "SDT");
            txtGhiChu.DataBindings.Add("Text", binding, "GhiChu");
            dtpNgaySinh.DataBindings.Add("Value", binding, "NgaySinh");
            txtDiaChi.DataBindings.Add("Text", binding, "DiaChi");
            txtChuanDoan.DataBindings.Add("Text", binding, "LoaiBenh");
            txtBaoHiem.DataBindings.Add("Text", binding, "BaoHiem");
            cbQueQuan.DataBindings.Add("SelectedValue", binding, "MaQueQuan");
        }
        public void LayDuLieu(DataGridViewComboBoxColumn columnName)
        {
            LopDuLieuDungChung dataTable = new LopDuLieuDungChung();
            dataTable.OpenConnection();
            string sql = "SELECT * FROM QueQuan";
            SqlCommand command = new SqlCommand(sql);
           dataTable.Fill(command);
            columnName.DataSource = dataTable;
            columnName.DisplayMember = "TenQueQuan";
            columnName.ValueMember = "MaQueQuan";
            columnName.DataPropertyName = "MaQueQuan";
        }
        public void LayDuLieu(ComboBox comboBox)
        {
            LopDuLieuDungChung dataTable = new LopDuLieuDungChung();
            dataTable.OpenConnection();
            string sql = "SELECT * FROM QueQuan";
            SqlCommand command = new SqlCommand(sql);
           dataTable.Fill(command);
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = "TenQueQuan";
            comboBox.ValueMember = "MaQueQuan";
        }
       
        private void SpThemThongTin_Click_1(object sender, EventArgs e)
        {
            DataRow dataRow = dataTable.NewRow();
            dataRow["MaBenhNhan"] = "";
            dataRow["Ten"] = "";
            dataRow["HoVaTen"] = "";
            dataRow["CMND"] = "";
            dataRow["GioiTinh"] = 0;
            dataRow["DanToc"] = "";
            dataRow["NgheNghiep"] = "";
            dataRow["NguoiThan"] = "";
            dataRow["QuanHe"] = "";
            dataRow["SDT"] = "";
            dataRow["GhiChu"] = "";
            dataRow["NgaySinh"] = DateTime.Today;
            dataRow["DiaChi"] = "";
            dataRow["LoaiBenh"] = "";
            dataRow["BaoHiem"] = "";
            dataRow["MaQueQuan"] = "";
            dataTable.Rows.Add(dataRow);
            bindingNavigator1.BindingSource.MoveLast();
        }

        private void SpLuuThongTin_Click_1(object sender, EventArgs e)
        {
            if (KiemTra("MaBenhNhan") && KiemTra("HoVaTen") && KiemTra("LoaiBenh")&&KiemTra("MaQueQuan"))
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaBN.Clear();
            txtTenBN.Clear();
            txtTenDayDu.Clear();
            txtCMND.Clear();
            txtDanToc.Clear();
            txtDiaChi.Clear();
            txtNgheNghiep.Clear();
            txtNguoiThan.Clear();
            txtQuanHe.Clear();
            txtSDT.Clear();
            txtGhiChu.Clear();
            txtBaoHiem.Clear();
            chkGioiTinh.Checked = false;
            dtpNgaySinh.Value = DateTime.Today;
            cbQueQuan.Text = "";           
            txtMaBN.Focus();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaBN.Text.Trim() == "")
                MessageBox.Show("Mã bệnh nhân không được rỗng!", "Lỗi", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            else if (txtTenBN.Text.Trim() == "")
                MessageBox.Show("Họ và tên không được rỗng!", "Lỗi", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            else
            {
                string sql = @"INSERT INTO ThongTinBenhNhan VALUES(@MaBenhNhan,@Ten, @HoVaTen,@CMND, @GioiTinh,@DanToc,@NgheNghiep,@NguoiThan,@QuanHe,@SDT,@GhiChu, @NgaySinh, @DiaChi,@LoaiBenh,@BaoHiem, @MaQueQuan)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.Add("@MaBenhNhan", SqlDbType.NVarChar, 5).Value = txtMaBN.Text;
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 20).Value = txtTenBN.Text;
                cmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 50).Value = txtTenDayDu.Text;
                cmd.Parameters.Add("@CMND", SqlDbType.NVarChar, 50).Value = txtCMND.Text;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.TinyInt).Value = chkGioiTinh.Checked ? 1 : 0;
                cmd.Parameters.Add("@DanToc", SqlDbType.NVarChar, 20).Value = txtDanToc.Text;
                cmd.Parameters.Add("@NgheNghiep", SqlDbType.NVarChar, 20).Value = txtNgheNghiep.Text;
                cmd.Parameters.Add("@NguoiThan", SqlDbType.NVarChar, 20).Value = txtNguoiThan.Text;
                cmd.Parameters.Add("@QuanHe", SqlDbType.NVarChar, 30).Value = txtQuanHe.Text;
                cmd.Parameters.Add("@SDT", SqlDbType.NVarChar, 50).Value = txtSDT.Text;
                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 50).Value = txtGhiChu.Text;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtpNgaySinh.Value;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                cmd.Parameters.Add("@LoaiBenh", SqlDbType.NVarChar, 20).Value = txtChuanDoan.Text;
                cmd.Parameters.Add("@BaoHiem", SqlDbType.NVarChar, 50).Value = txtBaoHiem.Text;
                cmd.Parameters.Add("@MaQueQuan", SqlDbType.NVarChar, 2).Value = cbQueQuan.SelectedValue.ToString();
                dataTable.Update(cmd);
                LayDuLieu();
                bindingNavigator1.BindingSource.MoveLast();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
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
        public bool KiemTraMaBN(string maBN)
        {
            SqlConnection conn = new SqlConnection(dataTable.ConnectionString());
            conn.Open();
            string sql = "SELECT MaBenhNhanh FROM BenhNhan WHERE MaBenhNhan = '" + maBN + "'";
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
        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (txtMaBN.Text.Trim() == "")
                MessageBox.Show("Mã bệnh nhân không được rỗng!", "Lỗi", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            else if (txtTenBN.Text.Trim() == "")
                MessageBox.Show("Họ và tên không được rỗng!", "Lỗi", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            //else if(KiemTraMaBN(txtMaBN.Text))
            
            //    MessageBox.Show("Mã bệnh nhân không được trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            else
            {
                string sql = @"INSERT INTO ThongTinBenhNhan VALUES(@MaBenhNhan,@Ten, @HoVaTen,@CMND, @GioiTinh,@DanToc,@NgheNghiep,@NguoiThan,@QuanHe,@SDT,@GhiChu, @NgaySinh, @DiaChi,@LoaiBenh,@BaoHiem, @MaQueQuan)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.Add("@MaBenhNhan", SqlDbType.NVarChar, 5).Value = txtMaBN.Text;
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 20).Value = txtTenBN.Text;
                cmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 50).Value = txtTenDayDu.Text;
                cmd.Parameters.Add("@CMND", SqlDbType.NVarChar, 50).Value = txtCMND.Text;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.TinyInt).Value = chkGioiTinh.Checked ? 1 : 0;
                cmd.Parameters.Add("@DanToc", SqlDbType.NVarChar, 20).Value = txtDanToc.Text;
                cmd.Parameters.Add("@NgheNghiep", SqlDbType.NVarChar, 20).Value = txtNgheNghiep.Text;
                cmd.Parameters.Add("@NguoiThan", SqlDbType.NVarChar, 20).Value = txtNguoiThan.Text;
                cmd.Parameters.Add("@QuanHe", SqlDbType.NVarChar, 30).Value = txtQuanHe.Text;
                cmd.Parameters.Add("@SDT", SqlDbType.NVarChar, 50).Value = txtSDT.Text;
                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 50).Value = txtGhiChu.Text;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtpNgaySinh.Value;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                cmd.Parameters.Add("@LoaiBenh", SqlDbType.NVarChar, 20).Value = txtChuanDoan.Text;
                cmd.Parameters.Add("@BaoHiem", SqlDbType.NVarChar, 50).Value = txtBaoHiem.Text;
                cmd.Parameters.Add("@MaQueQuan", SqlDbType.NVarChar, 2).Value = cbQueQuan.SelectedValue.ToString();
                MessageBox.Show("Cập nhật thành công!", "Chúc mừng!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataTable.Update(cmd);
                LayDuLieu();
                bindingNavigator1.BindingSource.MoveLast();
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaBN.Clear();
            txtTenBN.Clear();
            txtTenDayDu.Clear();
            txtCMND.Clear();
            txtDanToc.Clear();
            txtDiaChi.Clear();
            txtNgheNghiep.Clear();
            txtNguoiThan.Clear();
            txtQuanHe.Clear();
            txtChuanDoan.Clear();
            txtSDT.Clear();
            txtGhiChu.Clear();
            txtBaoHiem.Clear();
            chkGioiTinh.Checked = false;
            dtpNgaySinh.Value = DateTime.Today;
            cbQueQuan.Text = "";
            txtMaBN.Focus();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            DialogResult thongbao = MessageBox.Show("Bạn có chắc muốn xóa dòng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(dataTable.ConnectionString());
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM ThongTinBenhNhan WHERE MaBenhNhan = '" + txtMaBN.Text + "'";
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            
            SqlConnection conn = new SqlConnection(dataTable.ConnectionString());
            try
            {
                conn.Open();
                string sql = "UPDATE ThongTinBenhNhan SET Ten = N'" + txtTenBN.Text +
                                                              "', HoVaTen = N'" + txtTenDayDu.Text +
                                                              "', CMND = N'" + txtCMND.Text +
                                                             // "', GioiTinh= '" + chkGioiTinh.Checked +
                                                              "', DanToc = N'" + txtDanToc.Text +
                                                              "', NgheNghiep = N'" + txtNgheNghiep.Text +
                                                              "', NguoiThan = N'" + txtNguoiThan.Text +
                                                              "', QuanHe = N'" + txtQuanHe.Text +
                                                              "', SDT = N'" + txtSDT.Text +
                                                              "', GhiChu = N'" + txtGhiChu.Text +
                                                             "', NgaySinh= '" + dtpNgaySinh.Value+
                                                              "', DiaChi = N'" + txtDiaChi.Text +
                                                              "', LoaiBenh = N'" + txtChuanDoan.Text +
                                                              "',BaoHiem = N'" + txtBaoHiem.Text +                                                           
                                                              "', MaQueQuan = N'" + cbQueQuan.SelectedValue.ToString() +
                                                              "' WHERE MaBenhNhan = N'" + txtMaBN.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                 
                int kq = (int)cmd.ExecuteNonQuery();
                 if (kq > 0)
                {
                    MessageBox.Show("Sửa thành công!", "Chúc mừng!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
            btnLuu.Enabled = true;
           
            this.Refresh();
            BenhNhan_Load(sender, e);
        }
    }
}

