using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolReportApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var dataSet = new SchoolDB_Lab07DataSet();
            var adapter = new SchoolDB_Lab07DataSetTableAdapters.CoursesTableAdapter();

            // Đổ dữ liệu từ SQL Server vào bảng Courses
            adapter.Fill(dataSet.Courses);

            // Kiểm tra xem lấy được bao nhiêu dòng từ Database
            MessageBox.Show("Số dòng lấy được từ bảng Courses: " + dataSet.Courses.Rows.Count);

            // Gắn trực tiếp bảng vừa Fill vào ReportViewer (bỏ qua BindingSource rỗng nếu lỡ tạo ở Cách 1)
            this.reportViewer1.LocalReport.DataSources.Clear();
            var rds = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", (System.Data.DataTable)dataSet.Courses);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}
