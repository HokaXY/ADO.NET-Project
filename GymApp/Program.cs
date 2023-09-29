using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp
{
    class Program
    {
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

        static void Main()
        {
            string conString = @"Data Source =SABA\SQLEXPRESS; Initial Catalog=GymDB; Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                try
                {
                    connection.Open();

                    Console.Write("Enter SubscriptionID To Update: ");
                    int subscriptionId = int.Parse(Console.ReadLine());

                    if (SubscriptionExists(connection, subscriptionId))
                    {
                        Console.Write("Enter new MemberID: ");
                        int newMemberId = int.Parse(Console.ReadLine());

                        Console.Write("Enter new PlanID: ");
                        int newPlanId = int.Parse(Console.ReadLine());

                        Console.Write("Enter new Subscription Start Date (yyyy-MM-dd): ");
                        DateTime newStartDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter new Subscription End Date (yyyy-MM-dd): ");
                        DateTime newEndDate = DateTime.Parse(Console.ReadLine());

                        UpdateSubscription(connection, subscriptionId, newMemberId, newPlanId, newStartDate,
                            newEndDate);
                        Console.WriteLine("Subscription information updated successfully.");

                    }
                    else
                    {
                        Console.WriteLine("subscription not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: "+ ex.Message);
                }
            }
        }

        static bool SubscriptionExists(SqlConnection connection, int subscriptionId)
        {
            using (SqlCommand cmd =
                   new SqlCommand("select count(*) From MemberSubscriptions Where SubscriptionID = @subscriptionID",
                       connection))
            {
                cmd.Parameters.AddWithValue("@SubscriptionID", subscriptionId);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        static void UpdateSubscription(SqlConnection connection, int subscriptionId, int newMemberId, int newPlanId,
            DateTime newStartDate, DateTime newEndDate)
        {
            using (SqlCommand cmd =
                   new SqlCommand(
                       "Update MemberSubscriptions SET MemberID = @MemberID, PlanID = @PlanID, SubscriptionStartDate = @StartDate, SubscriptionEndDate = @EndDate WHERE SubscriptionID = @SubscriptionID",
                       connection))
            {
                cmd.Parameters.AddWithValue("@SubscriptionID", subscriptionId);
                cmd.Parameters.AddWithValue("@memberID", newMemberId);
                cmd.Parameters.AddWithValue("@planID", newPlanId);
                cmd.Parameters.AddWithValue("@StartDate", newStartDate);
                cmd.Parameters.AddWithValue("@EndDate", newEndDate);

                cmd.ExecuteNonQuery();
            }

        }
    }
}
