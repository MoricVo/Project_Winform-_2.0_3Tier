
namespace DoAnChinhThuc.FormDanhSach
{
    partial class XemDanhSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvBenhNhan = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsbDanhMuc = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTT = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvBenhNhan
            // 
            this.lvBenhNhan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30});
            this.lvBenhNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBenhNhan.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBenhNhan.FullRowSelect = true;
            this.lvBenhNhan.GridLines = true;
            this.lvBenhNhan.HideSelection = false;
            this.lvBenhNhan.Location = new System.Drawing.Point(200, 81);
            this.lvBenhNhan.Name = "lvBenhNhan";
            this.lvBenhNhan.Size = new System.Drawing.Size(1272, 657);
            this.lvBenhNhan.TabIndex = 0;
            this.lvBenhNhan.UseCompatibleStateImageBehavior = false;
            this.lvBenhNhan.View = System.Windows.Forms.View.Details;
            this.lvBenhNhan.SelectedIndexChanged += new System.EventHandler(this.lvBenhNhan_SelectedIndexChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Mã Bênh Nhân";
            this.columnHeader9.Width = 90;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Tên";
            this.columnHeader16.Width = 90;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Họ Và Tên";
            this.columnHeader17.Width = 90;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "CMND";
            this.columnHeader18.Width = 90;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Dân Tộc";
            this.columnHeader20.Width = 90;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Nghề Nghiệp";
            this.columnHeader21.Width = 90;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Người Thân";
            this.columnHeader22.Width = 90;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Quan Hệ";
            this.columnHeader23.Width = 90;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "SDT";
            this.columnHeader24.Width = 90;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Ghi Chú";
            this.columnHeader25.Width = 90;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Địa Chỉ";
            this.columnHeader27.Width = 90;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Loại Bệnh";
            this.columnHeader28.Width = 90;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "Bảo Hiểm";
            this.columnHeader29.Width = 90;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "Quê Quán";
            this.columnHeader30.Width = 90;
            // 
            // lsbDanhMuc
            // 
            this.lsbDanhMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lsbDanhMuc.Dock = System.Windows.Forms.DockStyle.Left;
            this.lsbDanhMuc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbDanhMuc.ForeColor = System.Drawing.Color.White;
            this.lsbDanhMuc.FormattingEnabled = true;
            this.lsbDanhMuc.ItemHeight = 23;
            this.lsbDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.lsbDanhMuc.Name = "lsbDanhMuc";
            this.lsbDanhMuc.Size = new System.Drawing.Size(200, 738);
            this.lsbDanhMuc.TabIndex = 1;
            this.lsbDanhMuc.SelectedIndexChanged += new System.EventHandler(this.lsbDanhMuc_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lsbDanhMuc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 738);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Controls.Add(this.txtTT);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(200, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1272, 81);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin!";
            // 
            // txtTT
            // 
            this.txtTT.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTT.Location = new System.Drawing.Point(63, 30);
            this.txtTT.Multiline = true;
            this.txtTT.Name = "txtTT";
            this.txtTT.Size = new System.Drawing.Size(419, 34);
            this.txtTT.TabIndex = 0;
            // 
            // XemDanhSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 738);
            this.Controls.Add(this.lvBenhNhan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "XemDanhSach";
            this.Text = "Bạn Đang Truy Cập Table Xem Danh Sách";
            this.Load += new System.EventHandler(this.XemDanhSach_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvBenhNhan;
        private System.Windows.Forms.ListBox lsbDanhMuc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTT;
    }
}