

namespace ProjectManagerLive
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FJKSFUG\\SQLEXPRESS;Initial Catalog=SoftUni;Integrated Security=true;"); // DESKTOP-FJKSFUG\SQLEXPRESS

            while (true)
            {
                Console.Write("Enter command: ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "list":
                        ListAllProjects(connection);
                        break;
                    case "details":
                        ShowDetails(connection);
                        break;
                    case "search":
                        SearchByName(connection);
                        break;
                    case "exit":
                        return;
                }
            }
        }

        static void SearchByName(SqlConnection connection)
        {
            Console.Write("Enter search cruteria: ");
            string pattern = Console.ReadLine();

            connection.Open();

            using (connection)
            {
                string query = @"
select  top 1 ProjectId
  from Projects
 where Name like @ProjectName";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProjectName", "%" + pattern + "%");
                int result = (int?) cmd.ExecuteScalar() ?? -1;

                if (result == -1)
                {
                    Console.WriteLine("Project not found!");
                    return;
                }

                Console.WriteLine($"Found project with ID: {result}");
            }
        }

        static void ShowDetails(SqlConnection connection)
        {
            Console.Write("Enter project ID: ");
            int projectId = int.Parse(Console.ReadLine());

            connection.Open();

            using (connection)
            {
                string query = @"select * from Projects where ProjectId = @ProjectId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProjectId", projectId);
                var reader = cmd.ExecuteReader();

                using (reader)
                {
                    if(!reader.Read())
                    {
                        Console.WriteLine("Project not found!");
                        return;
                    }

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine(reader.GetName(i) + ":");
                        Console.WriteLine(reader[i]);
                        Console.WriteLine("------------------------------");
                    }
                }                
            }
        }

        static void ListAllProjects(SqlConnection connection)
        {
            connection.Open();

            using (connection)
            {
                string query = @"select ProjectId, Name from Projects";
                SqlCommand cmd = new SqlCommand(query, connection);
                var reader = cmd.ExecuteReader();

                Console.WriteLine("  ID| Project Name");
                Console.WriteLine("----+--------------------------");
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0],4}| {reader[1]}");
                    }
                }
            }
        }
    }
}
