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

using System.Data;
namespace MyToDoes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DBClass.connectionstring);
            string query = "insert into ToDOTable(task,start1,end1,status) values('"+textBox1.Text+"','"+ this.dateTimePicker1.Value.Date+"','"+ this.dateTimePicker2.Value.Date + "','"+comboBox1.Text+"')";

            SqlCommand cmd = new SqlCommand(query,con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record is saved successfully! ");


            show();






        }



        private void show()
        {
            SqlConnection con = new SqlConnection(DBClass.connectionstring);
            string query = "select * from ToDOTable";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query,con);

            con.Open();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;

            dataGridView2.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDatabasetest1234567DataSet4.ToDoTable' table. You can move, or remove it, as needed.
            this.toDoTableTableAdapter4.Fill(this.myDatabasetest1234567DataSet4.ToDoTable);

            show();
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DBClass.connectionstring);
            string query = "delete from ToDOTable where id='"+comboBox2.Text+"'";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record is deleted successfully! ");
            show();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(DBClass.connectionstring);
            string query = "select * from ToDOTable where id='" + comboBox2.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            con.Open();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count>0)
            {



                string s1 = dt.Rows[0]["start1"].ToString();
                string s2 = dt.Rows[0]["end1"].ToString();

                System.DateTime firstDate = DateTime.Now.Date;//Convert.ToDateTime(s1);
                System.DateTime secondDate = Convert.ToDateTime(s2); ;

                System.TimeSpan diff = secondDate.Subtract(firstDate);
                System.TimeSpan diff1 = secondDate - firstDate;

                String diff2 = (secondDate - firstDate).TotalDays.ToString();



               // MessageBox.Show(diff1.ToString());

                label5.Text = diff2+" Days are Left";
            }

        }
    }
}
