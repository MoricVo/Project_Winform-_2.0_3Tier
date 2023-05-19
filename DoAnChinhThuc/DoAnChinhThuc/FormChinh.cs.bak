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
    public partial class FormChinh : Form
    {
        FormDangNhap dangNhap = null;
        string hoVaTen = "";
        string TenDangNhap = "";
        public FormChinh()
        {
           
            InitializeComponent();
            DongPanel();
        }
        //Luôn mở tất cả các hàm cha khi chương trình chạy
        private void DongPanel()
        {
            //đóng toàn bộ các panel danh sách
            pnCapNhat.Visible = false;
            pnDanhSach.Visible = false;
            pnTimKiem.Visible = false;
            pnThongKe.Visible = false;
            pnHoTro.Visible = false;
        }
        //Nếu panal 
        private void MoPanel()
        {
            if (pnCapNhat.Visible == true)
                pnCapNhat.Visible = false;
            if (pnDanhSach.Visible == true)
                pnDanhSach.Visible = false;
            if (pnTimKiem.Visible == true)
                pnTimKiem.Visible = false;
            if (pnThongKe.Visible == true)
                pnThongKe.Visible = false;
            if (pnHoTro.Visible == true)
                pnHoTro.Visible = false;
        }
        private void ShowMenu(Panel HienThiMenu)
        {
            if (HienThiMenu.Visible == false)
            {
                MoPanel();
                HienThiMenu.Visible = true;
            }
            else
                HienThiMenu.Visible = false;

        }
        private new Form ActiveForm = null;
        private void OpenShortForm(Form Shortform)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();

            }
            ActiveForm = Shortform;
            Shortform.TopLevel = false;
            Shortform.FormBorderStyle = FormBorderStyle.None;
            Shortform.Dock = DockStyle.Fill;
            this.pnShort.Controls.Add(Shortform);
            this.pnShort.Tag = Shortform;
            Shortform.BringToFront();
            Shortform.Show();
            label1.Text = Shortform.Text;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            chuadangnhap();
            DangNhap();
            FormFlash flash = new FormFlash();
            flash.ShowDialog();
        }
        #region Chức năng cập nhật


        private void btnQueQuan_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormCapNhat.QueQuan());
            MoPanel();
        }

        private void btnPhongKhoa_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormCapNhat.PhongKhoa());
            MoPanel();
        }
        private void btnPhanPhong_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormCapNhat.PhanPhong());
            MoPanel();
        }
        private void btnBenhNhan_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormCapNhat.BenhNhan());
            MoPanel();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {

            ShowMenu(pnCapNhat);
        }
        private void pnCapNhat_Paint(object sender, PaintEventArgs e)
        {
            MoPanel();
        }
        #endregion private void btnSinhVien_Click(object sender, EventArgs e)
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormTrangChu.TrangChu());
            MoPanel();
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {

        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            ShowMenu(pnDanhSach);
        }

        private void btnXemDanhSach_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormDanhSach.XemDanhSach());
            MoPanel();
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormDanhSach.InDanhSach());
            MoPanel();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ShowMenu(pnTimKiem);
        }

        private void btnTimMaBenhNhan_Click(object sender, EventArgs e)
        {

            OpenShortForm(new FormTimKiem.MaBN());
            MoPanel();
        }

        private void btnTimTenBN_Click(object sender, EventArgs e)
        {

            OpenShortForm(new FormTimKiem.TenBN());
            MoPanel();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ShowMenu(pnThongKe);
        }

        private void btnTongBenhNhan_Click(object sender, EventArgs e)
        {

            OpenShortForm(new FormThongKe.TongBenhNhan());
            MoPanel();
        }

        private void btnBenhNhanTuVong_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormThongKe.BenhNhanTuVong());
            MoPanel();
        }

        private void btnHoTro_Click(object sender, EventArgs e)
        {
            ShowMenu(pnHoTro);
        }

        private void btnGoi_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormHoTro.GoiNhaPhatTrien());
            MoPanel();
        }

        private void btnDoccoment_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormHoTro.XemDocoment());
            MoPanel();
        }

        private void btnDanhGia_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormDanhGia.DanhGia());
            MoPanel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult Levi = MessageBox.Show("Bạn có thật sự muốn thoát không?", "Question",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Levi == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
            lable5.Text = DateTime.Now.ToLongDateString();
             txt11.Text= DateTime.Now.ToLongTimeString();
            txt12.Text = DateTime.Now.ToLongDateString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormCapNhat.NhanVien());
            MoPanel();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap();
            
        }

        private void mnuChiTiet_Click(object sender, EventArgs e)
        {
            ThongSoKyThuat aboutBox = new ThongSoKyThuat();
           
            aboutBox.ShowDialog();
        }
        public void chuadangnhap()
        {
            //Open
            mnuTuyChon.Enabled = true;
            mnuXemThongTin.Enabled = true;
            //Close
            btnTrangChu.Enabled = false;
            btnCapNhat.Enabled = false;
            btnDanhSach.Enabled = false;
            btnTimKiem.Enabled = false;
            btnThongKe.Enabled = false;
            btnHoTro.Enabled = false;
            btnDanhGia.Enabled = false;
            lb01.Text = " Rổng";
            lblTTT.Text = "Bạn chưa đăng nhập!";
            //txt13.Text = "Chưa đăng nhập!";
        }
        public void QuanTriVien()
        {
            if (dangNhap == null || dangNhap.IsDisposed)
                dangNhap = new FormDangNhap();
            //Open
            mnuTuyChon.Enabled = true;
            mnuXemThongTin.Enabled = true;
            btnCapNhat.Enabled = true;

            //Close
            btnTrangChu.Enabled = true;
            btnDanhSach.Enabled = false;
            btnTimKiem.Enabled = true;
            btnThongKe.Enabled = false;
            btnHoTro.Enabled = true;
            btnDanhGia.Enabled = true;
            //Close Small
            btnQueQuan.Enabled = false;
            btnPhanPhong.Enabled = false;
            btnBenhNhan.Enabled = false;
            btnPhongKhoa.Enabled = false;
            btnNhanVien.Enabled = true;
            btnTimMaBenhNhan.Enabled = false;
            btnTimTenBN.Enabled = true;
            lb01.Text = " Quản trị viên";
            lb02.Text = " " + hoVaTen.ToString();
            //txt13.Text = "" + hoVaTen.ToString() + " đang đăng nhập!";
            lblTTT.Text = "Bạn đã đăng nhập!";

        }
        public void GiamDoc()
        {
            mnuTuyChon.Enabled = true;
            mnuXemThongTin.Enabled = true;
            btnTrangChu.Enabled = true;
            btnCapNhat.Enabled = true;
            btnQueQuan.Enabled = true;
            btnPhanPhong.Enabled = true;
            btnBenhNhan.Enabled = true;
            btnPhongKhoa.Enabled = true;
            btnNhanVien.Enabled = true;
            btnDanhSach.Enabled = true;
            btnTimKiem.Enabled = true;
            btnTimMaBenhNhan.Enabled = true;
            btnTimTenBN.Enabled = true;
            btnThongKe.Enabled = true;
            btnHoTro.Enabled = true;
            btnDanhGia.Enabled = true;
            lb01.Text = " Giám đốc";
            lb02.Text = " " + hoVaTen.ToString();
            //txt13.Text = "" + hoVaTen.ToString() + " đang đăng nhập!";
            lblTTT.Text = "Bạn đã đăng nhập!";

        }
        public void NhanVien()
        {
            mnuTuyChon.Enabled = true;
            mnuXemThongTin.Enabled = true;
            btnCapNhat.Enabled = true;
            btnQueQuan.Enabled = true;
            btnPhanPhong.Enabled = true;
            btnBenhNhan.Enabled = true;
            btnPhongKhoa.Enabled = true;
            btnNhanVien.Enabled = false;


            btnTrangChu.Enabled = true;
            btnDanhSach.Enabled = true;
            btnTimKiem.Enabled = true;
            btnTimMaBenhNhan.Enabled = true;
            btnTimTenBN.Enabled = false;
            btnThongKe.Enabled = true;
            btnHoTro.Enabled = true;
            btnDanhGia.Enabled = true;
            lb01.Text = " Nhân viên";
            lb02.Text = " " + hoVaTen.ToString();
            //txt13.Text = "" + hoVaTen.ToString() + " đang đăng nhập!";
            lblTTT.Text = "Bạn đã đăng nhập!";

        }
        private void DangNhap()
        {
        LamLai:
            if (dangNhap == null || dangNhap.IsDisposed)
                dangNhap = new FormDangNhap();
            if (dangNhap.ShowDialog() == DialogResult.OK)
            {
                if (dangNhap.txtDangNhap.Text.Trim() == "")
                {
                    MessageBox.Show("Tên đăng nhập không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtDangNhap.Focus();
                    goto LamLai;
                }
                else if (dangNhap.txtMatKhau.Text.Trim() == "")
                {
                    MessageBox.Show("Mật khẩu không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtMatKhau.Focus();
                    goto LamLai;
                }
                else
                {
                    LopDuLieuDungChung dataTable = new LopDuLieuDungChung();
                    dataTable.OpenConnection();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien WHERE TenTaiKhoan = @TTK AND MatKhau = @MK");
                    cmd.Parameters.Add("@TTK", SqlDbType.NVarChar, 50).Value = dangNhap.txtDangNhap.Text;
                    cmd.Parameters.Add("@MK", SqlDbType.NVarChar, 50).Value = dangNhap.txtMatKhau.Text;
                    dataTable.Fill(cmd);
                    if (dataTable.Rows.Count > 0)
                    {
                       
                        hoVaTen = dataTable.Rows[0]["TenNhanVien"].ToString();
                        string ChucVu = dataTable.Rows[0]["ChucVu"].ToString();
                        TenDangNhap = dataTable.Rows[0]["TenTaiKhoan"].ToString();
                        if (ChucVu == "QuanTriVien")
                        {
                            MessageBox.Show("Đăng nhập thành công!Quyền Quản Trị Viên", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                            QuanTriVien();
                        }
                        else if (ChucVu == "NhanVienNhapXuat")
                        {
                            MessageBox.Show("Đăng nhập thành công!Quyền Nhân Viên", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                            NhanVien();
                        }
                        else if(ChucVu =="GiamDoc")
                        {
                            MessageBox.Show("Đăng nhập thành công!Quyền Giám Đốc", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                            GiamDoc();
                        }
                        else
                            chuadangnhap();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dangNhap.txtDangNhap.Focus();
                        goto LamLai;
                    }
                }
            }

        }

        private void đăngXuâtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }
            lb02.Text = "";
            chuadangnhap();           
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void mnuXemThongTin_MouseHover(object sender, EventArgs e)
        {
            mnuXemThongTin.ForeColor = Color.Red;
        }

        private void mnuXemThongTin_MouseLeave(object sender, EventArgs e)
        {
            mnuXemThongTin.ForeColor = Color.White;
        }

        private void mnuTuyChon_MouseHover(object sender, EventArgs e)
        {
            mnuTuyChon.ForeColor = Color.Red;
        }

        private void mnuTuyChon_MouseLeave(object sender, EventArgs e)
        {
            mnuTuyChon.ForeColor = Color.White;
        }

        private void mnuTuyChon_Click(object sender, EventArgs e)
        {

        }

        private void thoátỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult Levi = MessageBox.Show("Bạn có thật sự muốn thoát không?", "Question",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Levi == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormNhacNho.GhiChu());
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormNhacNho.NhacNho());
        }

        private void btnXemTheoKhoa_Click(object sender, EventArgs e)
        {
            OpenShortForm(new FormDanhSach.XemDanhSachTheoKhoa());
            MoPanel();
        }

        private void txt11_Click(object sender, EventArgs e)
        {

        }

        int x = 22, y = 80, a = 1;

        Random random = new Random();

        private void txt13_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau doiMatKhau = new FormDoiMatKhau(TenDangNhap);
            doiMatKhau.ShowDialog();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                x = x + a;
                label5.Location = new Point(x, y);
                if (x > 700)
                {
                    a = -2;
                }
                if (x <= 12)
                {
                    a = 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      

        private void timer2_Tick(object sender, EventArgs e)
        {
           
           
        }
    }
 
}
