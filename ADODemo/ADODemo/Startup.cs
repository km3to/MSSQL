

namespace ADODemo
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Name of town :");
            string townName = Console.ReadLine();

            
            SqlConnection connection = new SqlConnection(@"
    Server=DESKTOP-FJKSFUG\SQLEXPRESS;
    Database=SoftUni;
    Integrated Security=true");
            connection.Open();

            using (connection)
            {
                string query = $@"
insert into Towns(Name) values (@TownName)";

                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@TownName", townName);
                int affectedRows = cmd.ExecuteNonQuery();
                Console.WriteLine($"Affected {affectedRows} rows.");
            }
        }
    }
}
