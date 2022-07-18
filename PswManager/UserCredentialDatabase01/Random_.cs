using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserCredentialDatabase01
{
    internal class Random_
    {
        public static int Num()
        {
            Random rnd = new();
            return rnd.Next();
        }

        public static int Num(int lowerLimit, int upperLimit)
        {
            Random rnd = new();
            return rnd.Next(lowerLimit, upperLimit + 1);
        }

        public static string Salt()
        {
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            byte[] bytes = new byte[8]; //Creates a byte array with the length of 8 int
            randomNumberGenerator.GetBytes(bytes); //Overrides the byte arrray with random bytes
            return Convert.ToBase64String(bytes); //Converts the byte array to a string
        }

    }
}
