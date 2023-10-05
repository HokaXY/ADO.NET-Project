using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GymApp

{
    class Program
    {
        static readonly string connectionString = @"Data Source =SABA\SQLEXPRESS; Initial Catalog=GymDB; Integrated Security=True";

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Create Product");
                Console.WriteLine("2. Read Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateProduct();
                        break;
                    case "2":
                        ReadProducts();
                        break;
                    case "3":
                        UpdateProduct();
                        break;
                    case "4":
                        DeleteProduct();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void UpdateProduct()
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
                    Console.WriteLine("error: " + ex.Message);
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
        static void CreateProduct()
        {
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Category ID: ");
            int categoryId = int.Parse(Console.ReadLine());

            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO products (Name, category_ID, Price) " +
                                         "VALUES (@ProductName, @CategoryId, @Price)";

                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@ProductName", productName);
                        insertCommand.Parameters.AddWithValue("@CategoryId", categoryId);
                        insertCommand.Parameters.AddWithValue("@Price", price);

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Product created successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to create the product.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void ReadProducts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "SELECT p.Name AS ProductName, c.Name AS CategoryName, p.Price " +
                                      "FROM products p " +
                                      "INNER JOIN categories c ON p.category_ID = c.ID";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string productName = (string)reader["ProductName"];
                                string categoryName = (string)reader["CategoryName"];
                                decimal price = (decimal)reader["Price"];

                                string rowData = $"Product Name: {productName}, Category Name: {categoryName}, Price: {price:C}";
                                Console.WriteLine(rowData);
                            }
                        }
                    }

                    connection.Close();
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }



        static void DeleteProduct()
        {
            Console.Write("Enter Product ID to delete: ");
            int productId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM products WHERE ID = @ProductId";

                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@ProductId", productId);

                        int rowsAffected = deleteCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Product deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No product with the given ID found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }


    }
}