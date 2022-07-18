using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCredentialDatabase01
{
    internal class Compare
    {
        

        //_____________________________________________________
        //Creates an instance of StringComparer as stringComparer, which is case sensitive.
        private static StringComparer stringComparerCaseSensitive = StringComparer.Ordinal;
        //_____________________________________________________


        public static bool InputVsHash(string input, string hash) // VERIFFY if string gives the same hash against the hash string
        {
            var hashOfInput = Hash.Generate(input); //Hash the input.
            return stringComparerCaseSensitive.Compare(hashOfInput, hash) == 0;
        }

        public static bool Input1VsInput2(string input1, string input2) // VERIFFY if input1 gives is equals input2
        {
            return stringComparerCaseSensitive.Compare(input1, input2) == 0; //Returns true if equals or else false
        }


    } //class Compare
} //namespace UserCredentialDatabase01
