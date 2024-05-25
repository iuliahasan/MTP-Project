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

namespace MTP_Project
{
    public partial class Gestiune_BD : Form
    {
        public Gestiune_BD()
        {
            InitializeComponent();
            SqlConnection connection;
            string connect = @"Data Source=Iulia_Hasan\SQLEXPRESS;Initial Catalog=IT;Integrated Security=True";
            connection = new SqlConnection(connect);
            connection.Open();
        }

        private void Gestiune_BD_Load(object sender, EventArgs e)
        {

        }

        private void Insertbutton_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty
                && textBox4.Text != string.Empty && textBox5.Text != string.Empty)
            {
                SqlConnection connection;
                string connect = @"Data Source=Iulia_Hasan\SQLEXPRESS;Initial Catalog=IT;Integrated Security=True";
                connection = new SqlConnection(connect);
                connection.Open();
                string tabel_date = "insert into Date_angajat([id],[nume],[prenume],[vechime],[cursuri]) values (@id,@nume,@prenume,@vechime,@cursuri)";
                SqlCommand sqlCommand=new SqlCommand(tabel_date, connection);
                sqlCommand.Parameters.AddWithValue("@id",Convert.ToInt32(textBox1.Text));
                sqlCommand.Parameters.AddWithValue("@nume",textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@prenume", textBox3.Text);
                sqlCommand.Parameters.AddWithValue("@vechime", Convert.ToInt32(textBox4.Text));
                sqlCommand.Parameters.AddWithValue("@cursuri", Convert.ToInt32(textBox5.Text));
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Completati toate campurile");
            }
        }

        private void Showbutton_Click(object sender, EventArgs e)
        {
            SqlConnection connection;
            string connect = @"Data Source=Iulia_Hasan\SQLEXPRESS;Initial Catalog=IT;Integrated Security=True";
            connection = new SqlConnection(connect);
            connection.Open();
            string tabel_date = "select * from Date_angajat";
            SqlDataAdapter da = new SqlDataAdapter(tabel_date, connect);
            DataSet ds = new DataSet();
            da.Fill(ds, "Date_angajat");
            dataGridView1.DataSource = ds.Tables["Date_angajat"].DefaultView;
            connection.Close();
        }

        private void DeleteNamebutton_Click(object sender, EventArgs e)
        {
            if(NametextBox.Text!=string.Empty)
            {
                SqlConnection connection;
                string connect = @"Data Source=Iulia_Hasan\SQLEXPRESS;Initial Catalog=IT;Integrated Security=True";
                connection = new SqlConnection(connect);
                connection.Open();
                string tabel_date = "delete from Date_angajat where nume='" + NametextBox.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(tabel_date, connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Completati campul!");
            }
        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            SqlConnection connection;
            string connect = @"Data Source=Iulia_Hasan\SQLEXPRESS;Initial Catalog=IT;Integrated Security=True";
            connection = new SqlConnection(connect);
            connection.Open();
            string tabel_date = "select * from Date_angajat where vechime="+Convert.ToInt32(VechimetextBox.Text);
            SqlDataAdapter da = new SqlDataAdapter(tabel_date, connect);
            DataSet ds = new DataSet();
            da.Fill(ds, "Date_angajat");
            dataGridView1.DataSource = ds.Tables["Date_angajat"].DefaultView;
            connection.Close();
            da.Dispose();
            ds.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CoursestextBox.Text != string.Empty)
            {
                SqlConnection connection;
                string connect = @"Data Source=Iulia_Hasan\SQLEXPRESS;Initial Catalog=IT;Integrated Security=True";
                connection = new SqlConnection(connect);
                connection.Open();
                string tabel_date = "update Date_angajat set cursuri=" + Convert.ToInt32(CoursestextBox.Text) + " where nume='"+NametextBox.Text+"'";
                SqlCommand sqlCommand = new SqlCommand(tabel_date, connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Completati campul!");
            }
        }
    }
}