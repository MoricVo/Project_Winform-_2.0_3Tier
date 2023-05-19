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
using Microsoft.Reporting.WinForms;
namespace DoAnChinhThuc.FormDanhSach
{
    public partial class InDanhSach : Form
    {
        public InDanhSach()
        {
            InitializeComponent();
        }

        private void InDanhSach_Load(object sender, EventArgs e)
        {

           
           SqlConnection ketnoi =new SqlConnection
         ( "Data Source= DESKTOP-HD4HHJ3\\SQLEXPRESS;  Initial Catalog=CSDL_DoAnQLBNNhaKhoa; Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("select * from ThongTinBenhNhan",ketnoi);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "ThongTinBenhNhan");
            ReportDataSource report = new ReportDataSource();
            report.Name = "DataSet1";
            report.Value = ds.Tables[0];
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoAnChinhThuc.FormDanhSach.Report1.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(report);
            this.reportViewer1.RefreshReport();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
