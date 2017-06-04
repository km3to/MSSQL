using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtilities
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] inputLine = Console.ReadLine().Split(' ');
                string command = inputLine[0];
                if (command == "End")
                {
                    return;
                }
                double firstNumber = double.Parse(inputLine[1]);
                double secondNumber = double.Parse(inputLine[2]);
                switch (command)
                {
                    case "Sum":
                        Console.WriteLine($"{MathUtil.Sum(firstNumber, secondNumber):f2}");
                        break;
                    case "Subtract":
                        Console.WriteLine($"{MathUtil.Substract(firstNumber, secondNumber):f2}");
                        break;
                    case "Multiply":
                        Console.WriteLine($"{MathUtil.Multiply(firstNumber, secondNumber):f2}");
                        break;
                    case "Divide":
                        Console.WriteLine($"{MathUtil.Divide(firstNumber, secondNumber):f2}");
                        break;
                    case "Percentage":
                        Console.WriteLine($"{MathUtil.Percentage(firstNumber, secondNumber):f2}");
                        break;
                }
            }
        }
    }

    public class MathUtil
    {
        public static double Sum(double first, double second)
        {
            return first + second;
        }

        public static double Substract(double first, double second)
        {
            return first - second;
        }

        public static double Multiply(double first, double second)
        {
            return first * second;
        }

        public static double Divide(double first, double second)
        {
            return first / second;
        }

        public static double Percentage(double first, double second)
        {
            return Divide(Multiply(first, second), 100);
        }
    }
}
