using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserCredentialDatabase01
{


    public class Hash

    {

        //_____________________________________________________
        //Creates an instance of StringBuilder as stringBuilder 
        private static StringBuilder stringBuilder = new StringBuilder();
        //_____________________________________________________

        //_____________________________________________________
        //Creates an instance of SHA256 hashAlgorithm as sha256 
        private static SHA256 sha256 = SHA256.Create();
        //_____________________________________________________

        //_____________________________________________________
        //Creates an instance of RandomNumberGenerator as randomNumberGenerator 
        private static RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
        //_____________________________________________________




        //Creates a random salt string as salt
        public static string CreateSalt() //Creates a random salt string with a byte array with length of 8 int.
        {
            byte[] bytes = new byte[8]; //Creates a byte array with the length of 8 int
            randomNumberGenerator.GetBytes(bytes); //Overrides the byte arrray with random bytes
            return Convert.ToBase64String(bytes); //Converts the byte array to a string
        }


        //Computes hash string
        public static string Generate(string input)
        {
            try
            {
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(input)); // Convert to a byte array and compute the hash to a byte array with length of 32.
                for (int i = 0; i < data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2")); // Loop through each byte of the hashed data and format each one as a short hexadecimal string.
                }
                return stringBuilder.ToString(); // Return the hexadecimal string with a total length of 64 characters.
            }
            catch (Exception)
            {
                return "Error occurred when generating a hash string.";
            }
        }

        public static string Generate(string input, int outputLengthOfHash)
        {
            try
            {
                string? hashOutputTemp = Generate(input); //HASHER password og gemmes i variablen hashOutputTemp
                var hashOutput = hashOutputTemp.Substring(0, outputLengthOfHash); //Afkorte hash til outputLengthOfHash karakterer lang.
                return hashOutput;
            }
            catch (Exception)
            {
                return "Error occurred when generating UserDefinedLengthOfHash.";
            }
        }

        public static string Generate(string input, string salt)
        {
            try
            {
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(input + salt)); // Convert the input+salt string to a byte array and compute the hash.
                for (int i = 0; i < data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2")); // Loop through each byte of the hashed data and format each one as a short hexadecimal string.
                }
                return stringBuilder.ToString(); // Return the hexadecimal string.
            }
            catch (Exception)
            {
                return "Error occurred when generating a hash string.";
            }
        }

        public static string Generate(string input, string salt, int outputLengthOfHash)
        {
            try
            {
                string? hashOutputTemp = Generate(input + salt); //HASHER password+salt og gemmes i variablen hashOutputTemp
                var hashOutput = hashOutputTemp.Substring(0, outputLengthOfHash); //Afkorte hash til outputLengthOfHash karakterer lang.
                return hashOutput;
            }
            catch (Exception)
            {
                return "Error occurred when generating UserDefinedLengthOfHash.";
            }
        }


        


    } //Class Hash
} //Namespace UserCredentialDatabase01
