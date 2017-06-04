using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringotts
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new GringottsContext();


        }

        // 19
        private static void OllivanderFamily(GringottsContext context)
        {
            context.WizzardDeposits.Where(w => w.MagicWandCreator == "Ollivander family")
                .GroupBy(w => w.DepositGroup)
                .ToList()
                .ForEach(d =>
                {
                    Console.WriteLine($"{d.Key} - {d.Sum(w => w.DepositAmount)}");
                });
        }

        // 20
        private static void DepositsFilter(GringottsContext context)
        {
            context.WizzardDeposits.Where(w => w.MagicWandCreator == "Ollivander family")
                .GroupBy(w => w.DepositGroup)
                .Where(d => d.Sum(w => w.DepositAmount.Value) < 150000)
                .OrderByDescending(d => d.Sum(w => w.DepositAmount))
                .ToList()
                .ForEach(d =>
                {
                    Console.WriteLine($"{d.Key} - {d.Sum(w => w.DepositAmount)}");
                });
        }
    }
}
