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
            //Gather user-entered number of degrees to calculate the sine of.
            Console.WriteLine("This program will compute the sine of a specified angle.");
            Console.WriteLine(" ");
            Console.WriteLine("Enter Degrees: ");
            double userValue = Convert.ToDouble(Console.ReadLine());
            //Pass user-entered value to the Sine function to approximate the sine.
            double value = Sine(userValue);
            Console.WriteLine("The sine of " + userValue + " is approximately " + value);

            //wait for user to hit enter before closing.
            string forcewait = Console.ReadLine();
        }

        private static double Sine (double input)
        {
            
            double result;
            //convert userValue to radians
            double radians = input*Math.PI/180;
            
            //If user entered a value not between -180 and 180 degrees, add or subtract
            //2Pi radians until corresponding radian value is between -Pi and Pi.
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

            //Pass normalized radian measure to Taylor function for Taylor Series approximation.
            result = Taylor(radians);
            return result;
        }

        private static double Taylor (double origin)
        {
            double approx = 0;

            //Taylor Series up to the 21st order. I was getting bizarre results going any higher than
            //this. I'm guessing due to the size of the factorial.
            for(int i = 1; i<=21; i+=2)
            {
                //every other term is negative. mod4 checks for this.
                if (i % 4 == 1)
                    //Fact is a factorial computation, defined below.
                    approx += Math.Pow(origin, i) / Fact(i);
                else
                    approx -= Math.Pow(origin, i) / Fact(i);
            }
            return approx;
        }

        private static UInt64 Fact (int n)
        {
            //factorial needs to be able to be enormous.
            UInt64 factorial = new UInt64();
            //must initialize to 1 or else *= in the while loop will result to 0.
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
