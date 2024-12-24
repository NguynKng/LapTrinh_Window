using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai2
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
            KetnoiCSDL();
        }

        SqlConnection sqlConn;		//khai báo biến connection
        SqlDataAdapter da;		 //khai báo biến dataAdapter
        DataSet ds = new DataSet();	//khai báo 1 dataset
        public string srvName = "DESKTOP-TD8CQJG";	 //chỉ định tên server
        public string dbName = "QLTHUVIEN";	//chỉ định tên CSDL
        void KetnoiCSDL()	//thực hiện kết nối bằng chuỗi kết nối
        {
            string connStr = "Data source=" + srvName + ";database=" + dbName + ";Integrated Security = True";
            sqlConn = new SqlConnection(connStr);
        }
        DataTable layDanhSachNhanVien()
        {
            string sql = "Select * from NhanVien";
            da = new SqlDataAdapter(sql, sqlConn);
            da.Fill(ds);
            return ds.Tables[0];
        }
        void LoadListview()
        {
            lsvNhanVien.FullRowSelect = true;	//cho phép chọn 1 dòng
            lsvNhanVien.View = View.Details; 	//cho phép hiển thị thông tin chi tiết dạng bảng
            DataTable dt = layDanhSachNhanVien();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvNhanVien.Items.Add(dt.Rows[i]["Hotennhanvien"].ToString());
                //dòng thứ i, tên cột là nhân viên
                lvi.SubItems.Add(dt.Rows[i][2].ToString()); //dùng chỉ số cột : dòng thứ i,cột thứ 1
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string sql = string.Format(@"insert into NhanVien values({ 0},{ 1},{ 2},{ 3},{ 4},{ 5})",
               txtName.Text, txtBirth.Value.ToShortDateString(), txtAddress.Text, txtPhone.Text, 1);
            SqlCommand cmd = new SqlCommand(sql, sqlConn);
            cmd.ExecuteNonQuery();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadListview();
        }
    }
}
