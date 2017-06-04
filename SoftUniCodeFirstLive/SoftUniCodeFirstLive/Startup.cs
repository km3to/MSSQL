namespace SoftUniCodeFirstLive
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            var data = context.Employees.GroupBy(e => e.DepartmentID);

            Console.WriteLine(data);
        }
    }
}
