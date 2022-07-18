using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCredentialDatabase01
{
    internal class Validation
    {

        public static int Integer()
        {
            int? output = null;
            int outputTemp;
            do
            {
                string? input = Console.ReadLine();
                
                if (int.TryParse(input, out outputTemp))
                {
                    output = outputTemp;
                }
                else
                {
                    Console.WriteLine("The input must be an integer.");
                }

            } while (output == null);
            return (int)output;
        }

        public static int Double()
        {
            double? output = null;
            double outputTemp;
            do
            {
                string? input = Console.ReadLine();

                if (double.TryParse(input, out outputTemp))
                {
                    output = outputTemp;
                }
                else
                {
                    Console.WriteLine("The input must be a number.");
                }

            } while (output == null);
            return (int)output;
        }

    }
}
