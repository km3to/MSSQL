using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_to_DB_Apps
{
    class Startup
    {
        static void Main(string[] args)
        {
            string query = File.ReadAllText(@"C:\Users\gyurg\Documents\Visual Studio 2015\Projects\DB-Advanced\Introduction_to_DB_Apps\Introduction_to_DB_Apps\MinionsDB.sql");

            SqlConnection connection = new SqlConnection(@"Server=DESKTOP-FJKSFUG\SQLEXPRESS;Integrated Security=true;");

            connection.Open();
            //string sqlCreateDB = "CREATE DATABASE MinionsDB";
            SqlCommand createTablesCommand = new SqlCommand(query, connection);

            using (connection)
            {
                Console.WriteLine(createTablesCommand.ExecuteNonQuery());
            }            
        }
    }
}
