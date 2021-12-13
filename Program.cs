using System;
using System.Data.SqlClient;

namespace SQL_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConnStringClass.connString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) // SqlConnection not found in the namespace 'System.Data.SqlClient'
                {

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: " + e.Message);
            }
        }
    }
}
