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

namespace GymAppFull
{
    public partial class Form1 : Form
    {
         string conString = @"Data Source =SABA\SQLEXPRESS; Initial Catalog=GymDB; Integrated Security=True";
        private  string  SqlCode;

        public Form1()
        {
            InitializeComponent();
        }


        private void FirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string firstName = textBox1.Text;

            label2.Text = firstName;
        }

        private void BextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("selectMember", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                cmd.ExecuteNonQuery();
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }


        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string queryString = "select * from Equipment";
                SqlCommand cmd = new SqlCommand(queryString, con);
                cmd.ExecuteNonQuery();
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(table);

                dataGridView2.DataSource = table;
            }

        }
     

        private void Button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertMember", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter param1 = new SqlParameter
                {
                    ParameterName = "@FirstName",
                    SqlDbType = SqlDbType.VarChar,
                    Value = textBox3.Text,
                    Direction = ParameterDirection.Input,
                };

                SqlParameter param2 = new SqlParameter
                {
                    ParameterName = "@LastName",
                    SqlDbType = SqlDbType.VarChar,
                    Value = textBox4.Text,
                    Direction = ParameterDirection.Input,
                };

                SqlParameter param3 = new SqlParameter
                {
                    ParameterName = "@Gender",
                    SqlDbType = SqlDbType.VarChar,
                    Value = textBox5.Text,
                    Direction = ParameterDirection.Input,
                }; SqlParameter param4 = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    SqlDbType = SqlDbType.Date,
                    Value = textBox6.Text,
                    Direction = ParameterDirection.Input,
                };

                SqlParameter param5 = new SqlParameter
                {
                    ParameterName = "@Email",
                    SqlDbType = SqlDbType.VarChar,
                    Value = textBox8.Text,
                    Direction = ParameterDirection.Input,
                };

                SqlParameter param6 = new SqlParameter
                {
                    ParameterName = "@Phone",
                    SqlDbType = SqlDbType.VarChar,
                    Value = textBox7.Text,
                    Direction = ParameterDirection.Input,
                };

                SqlParameter sqlParameter = new SqlParameter
                {
                    ParameterName = "@JoinDatedate",
                    SqlDbType = SqlDbType.Date,
                    Value = textBox9.Text,
                    Direction = ParameterDirection.Input,
                };
                SqlParameter param7 = sqlParameter;


                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
                cmd.Parameters.Add(param6);
                cmd.Parameters.Add(param7);

                cmd.ExecuteNonQuery();
            }

            TextBox.Text = SqlCode;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
