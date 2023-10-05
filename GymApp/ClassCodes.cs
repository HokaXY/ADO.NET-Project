using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp
{
    class ClassCodes
    {
        // we counct How many ID we have in total in selected* table
        /*static void Main(string[] args)
        {
            string conString = @"Data Source =SABA\SQLEXPRESS; Initial Catalog=GymDB; Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            con.Open();
            string countQuery = "select count (MemberID) from members";
            using (SqlCommand cmd1 = new SqlCommand(countQuery, con))
            {
                int count = (int)cmd1.ExecuteScalar();
                Console.WriteLine(count);
            }

        }*/

        //tables infos ganaxleba ubralod sql injection ro aviridot tavidan
        /*
        static void Main(string[] args)
        {
            string conString = @"Data Source =SABA\SQLEXPRESS; Initial Catalog=GymDB; Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            string insertQuery = "INSERT INTO [dbo]. [members]([firstName],[LastName])Values(@firstName,@lastName)";

            using (SqlCommand cmd1 = new SqlCommand(insertQuery, con))
            {
                cmd1.Parameters.Add("@firstName", SqlDbType.VarChar);
                cmd1.Parameters.Add("@LastName", SqlDbType.VarChar);
                cmd1.Parameters["@firstName"].Value = ";DELETE FROM Student;";
                cmd1.Parameters["@LastName"].Value = "ketelauri2";

                cmd1.ExecuteNonQuery();
                */
        /*static void Main(string[] args)
{
    string conString = @"Data Source =SABA\SQLEXPRESS; Initial Catalog=GymDB; Integrated Security=True";
    SqlConnection con = new SqlConnection(conString);
    con.Open();
    string queryString = "select * from Members";
    SqlCommand cmd = new SqlCommand(queryString, con);
    SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(reader[0].ToString()+":" + reader[1].ToString()+":" +reader[2].ToString());
    }

    Console.ReadKey();
}*/
    }
}
