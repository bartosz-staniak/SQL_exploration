using System;
using System.Data.SqlClient;

namespace SQL_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConnStringClass.connString;
            string queryString = "SELECT * FROM dbo.InitialModels";
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SqlCommand insertCommand = new SqlCommand(insertData, connection);
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}", 
                                reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: " + e.Message);
            }
        }

        void insertQuery ()
        {
            string insertDataQuery = "INSERT [dbo].[InitialModels] ([id], [DateAndTime], [Location], [TemperatureC], [RainChance], [Summary], [SubmittedBy]) "
                + "VALUES (1, 2020-11-11 11:11:11.0000000, testLocation, 11, 11, testSummary, testSubmitter)";
        }
    }
}
