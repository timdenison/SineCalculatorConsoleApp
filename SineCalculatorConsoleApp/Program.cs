using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Gather user-entered 
            Console.WriteLine("This program will compute the sine of a specified angle.");
            Console.WriteLine(" ");
            Console.WriteLine("Enter Degrees: ");
            double userValue = Convert.ToDouble(Console.ReadLine());
            double value = Sine(userValue);
            Console.WriteLine("The sine of " + userValue + " is approximately " + value);
            string forcewait = Console.ReadLine();
        }

        private static double Sine (double input)
        {
            double result;
            double radians = input*Math.PI/180;
            if (radians < -Math.PI)
            {
                while (radians < -Math.PI)
                {
                    radians += 2*Math.PI;
                }
            }
            else if (radians > Math.PI)
            {
                while(radians > Math.PI)
                {
                    radians -= 2*Math.PI;
                }
            }

            result = Taylor(radians);
            return result;
        }

        private static double Taylor (double origin)
        {
            double approx = 0;
            for(int i = 1; i<=21; i+=2)
            {
                if (i % 4 == 1)
                    approx += Math.Pow(origin, i) / Fact(i);
                else
                    approx -= Math.Pow(origin, i) / Fact(i);
            }
            return approx;
        }

        private static UInt64 Fact (int n)
        {
            UInt64 factorial = new UInt64();
            factorial = 1;
            while (n - 1 > 0)
            {
                factorial *= Convert.ToUInt64(n * (n - 1));
                n = n - 2;
            }
            return factorial;

        }
       
    }
}
