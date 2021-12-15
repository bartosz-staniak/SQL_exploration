﻿using System;
using System.Data.SqlClient;

namespace SQL_ConsoleApp
{
    class Program
    {
        static string connectionString = ConnStringClass.connString;

        static void Main(string[] args)
        {
            string queryString = "SELECT * FROM dbo.InitialModels";
            
            try
            {
                insertQuery();

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

        static void insertQuery ()
        {
            string insertDataQuery = "INSERT INTO [dbo].[InitialModels] ([id], [DateAndTime], [Location], [TemperatureC], [RainChance], [Summary], [SubmittedBy]) "
                + "VALUES (137, 2020-11-11 11:11:11.0000000, testLocation, 11, 11, testSummary, testSubmitter)"; // the query may not have worked due to IDENTITY_INSERT set to off

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(insertDataQuery, connection);
                    connection.Open();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: " + e.Message);
            }
        }
    }
}
