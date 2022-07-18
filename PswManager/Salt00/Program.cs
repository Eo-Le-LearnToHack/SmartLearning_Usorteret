using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using UserCredentialDatabase01;

namespace Salt00
{

    

    internal class Program
    {

        private void m_GenSaltSHA256_Button_Click(object sender, EventArgs e)
        {

        }

        public static void Main(string[] args)
        {
            //Program starts here

           

            string CreateSalt(int size) //Create a random salt string
            {
                var rng = RandomNumberGenerator.Create();   //Creates an instance of the default implementation of a cryptographic random number generator that can be used to generate random data.
                var bytes = new byte[size];                 // Creates an instance of onedimensional byte array. The highest number in a byte is 256 = 2^8.
                //foreach (byte item in bytes)
                //{
                //    Console.Write("After creating an instance of a byte array. The array contains following values:\t");
                //    Console.Write(item);
                //    Console.WriteLine();
                //}       
                rng.GetBytes(bytes);                        //Fills an array of bytes with a cryptographically strong random sequence of values.
                //foreach (byte item in bytes)
                //{
                //    Console.Write("After randomization and override the random numbers in the byte array:\t");
                //    Console.Write(item);
                //    Console.WriteLine();
                //}
                return Convert.ToBase64String(bytes);       //Converts the byte array to a string
            }



            string GenerateHash(string input, string salt)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input + salt); //Converting the input+salt to a byte array (max value 255). The length of the array is defined by the length of the input+salt
                //foreach (byte item in bytes)
                //{
                //    Console.Write("After creating an instance of a byte array. The array contains following values:\t");
                //    Console.Write(item);
                //    Console.WriteLine();
                //}

                SHA256 hashAlgorithm = SHA256.Create(); // Creates a SHA256 hashAlgorithm
                byte[] hash = hashAlgorithm.ComputeHash(bytes); //Convertes the bytes array to a hash containing a byte array with a length of 32.
                //foreach (byte item in hash)
                //{
                //    Console.Write("After computing the bytes to hash. The array contains following values:\t");
                //    Console.Write(item);
                //    Console.WriteLine();
                //}

                //return Convert.ToBase64String(bytes);

                var sBuilder = new StringBuilder(); // Creates a new Stringbuilder to collect the bytes and create a string.
                for (int i = 0; i < hash.Length; i++)
                {
                    sBuilder.Append(hash[i].ToString("x2")); // Loop through each byte of the hashed data and format each one as a short hexadecimal string with a length of 2 and use lower case.
                }
                return sBuilder.ToString(); // Return the short hexadecimal string.
            }


            while (true)
            {

                //Console.Write("Enter the byte size in whole numbers:\t");
                //int num = Convert.ToInt32(Console.ReadLine());
                //string salt = CreateSalt(num);
                //Console.WriteLine($"The result is: {salt}");

                //Console.Write("Enter a password to be hashed:\t");
                //string? psw = Console.ReadLine();
                //string hash = GenerateHash(psw, salt);
                //Console.WriteLine($"The hash result is:\t {hash}");
                //Console.WriteLine($"The length of the hash is:\t {hash.Length}");

                string? salt = Hash.CreateSalt();
                Console.WriteLine($"The salt is {salt}");
                string? psw = "Admin123";

                Console.WriteLine($"The hash without salt, 1:\t {Hash.Generate(psw)}");
                Console.WriteLine($"The hash without salt, 2:\t {Hash.Generate(psw)}");
                Console.WriteLine();
                Console.WriteLine($"The hash with salt, 1:\t\t {Hash.Generate(psw, salt)}");
                Console.WriteLine($"The hash with salt, 2:\t\t {Hash.Generate(psw, salt)}");
                Console.WriteLine();

                salt = Hash.CreateSalt();
                Console.WriteLine($"The new salt is {salt}");
                Console.WriteLine($"The hash without salt, 1:\t {Hash.Generate(psw)}");
                Console.WriteLine($"The hash without salt, 2:\t {Hash.Generate(psw)}");
                Console.WriteLine();
                Console.WriteLine($"The hash with salt, 1:\t\t {Hash.Generate(psw, salt)}");
                Console.WriteLine($"The hash with salt, 2:\t\t {Hash.Generate(psw, salt)}");
                

                bool result = Hash.VerifyInput1VsInput2("en", "en");
                bool result2 = Hash.VerifyInput1VsInput2("en", "En");
                bool result3 = Hash.VerifyInput1VsInput2("en", "eN");

                Console.WriteLine($"sammenlignet en vs en, giver:\t {result}");
                Console.WriteLine($"sammenlignet en vs En, giver:\t {result2}");
                Console.WriteLine($"sammenlignet en vs eN, giver:\t {result3}");

                Console.ReadLine();
            }




        }




    }
}
