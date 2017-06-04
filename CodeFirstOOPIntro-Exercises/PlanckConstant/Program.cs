using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanckConstant
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculation.GetReducedPlanck());
        }
    }

    public class Calculation
    {
        static double plankConst = 6.62606896e-34;

        static double pi = 3.14159;

        public static double GetReducedPlanck()
        {
            return plankConst / 2 * pi;
        }
    }
}
