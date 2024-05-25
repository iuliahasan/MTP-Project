using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MTP_Project
{
    public partial class Autentificare : Form
    {
        SqlCommand cmd;
        SqlDataReader dr;
        public Autentificare()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connect = @"Data Source=Iulia_Hasan\SQLEXPRESS;Initial Catalog=IT;Integrated Security=True";
            using(SqlConnection connection=new SqlConnection(connect))
            {
                try
                {
                    connection.Open();
                    string query="select COUNT(1) from Date_angajat where Nume=@Nume and Prenume=@Prenume";
                    SqlCommand cmd=new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Nume", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Prenume", textBox2.Text);
                    int nr=Convert.ToInt32(cmd.ExecuteScalar());

                    if(nr==1)
                    {
                        MessageBox.Show("Autentificare reusita!");
                        Gestiune_BD gestiune_BD = new Gestiune_BD();
                        gestiune_BD.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Date incorecte! Mai incercati!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Autentificare_Load(object sender, EventArgs e)
        {
               
        }
    }
}
