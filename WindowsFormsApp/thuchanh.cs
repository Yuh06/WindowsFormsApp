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
using System.Configuration;


namespace WindowsFormsApp
{
    public partial class thuchanh : Form
    {
        public thuchanh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String strconn = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = strconn;
            conn.Open();
            //.....
            string s1 = "insert into tbNguoidung(Tennguoidung, Matkhau) values(@Ten, @Matkhau)";
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = s1;

            comm.Parameters.AddWithValue("@Ten", textBox1.Text);
            comm.Parameters.AddWithValue("@Matkhau", textBox2.Text);
            var n = comm.ExecuteNonQuery();

            conn.Close();

        }
    }
}
