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

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        String str = @"Data Source=LAPTOP-EV312V69;Initial Catalog=ADO_Net_Demo;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from NhanVien";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();

        }
        

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            /*
            txtId.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtId.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtDob.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtSex.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            */

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into NhanVien values('"+txtId.Text+"',N'"+txtName.Text+"','" + txtDob.Text+ "','" + txtSex.Text+"')";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from NhanVien where id = '" + txtId.Text + "'";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update NhanVien set id = '" + txtId.Text + "',name=N'" + txtName.Text + "',DayOfBirth='" + txtDob.Text + "',Sex='" + txtSex.Text + "' where id = '"+txtId.Text+"'";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //MessageBox.Show(row.Cells[2].Value.ToString());

            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtDob.Text = row.Cells[2].Value.ToString();
            txtSex.Text = row.Cells[3].Value.ToString();
            */
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //MessageBox.Show(row.Cells[2].Value.ToString());

            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtDob.Text = row.Cells[2].Value.ToString();
            txtSex.Text = row.Cells[3].Value.ToString();
        }
    }
}
