using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCredentialDatabase01
{
    internal class Message
    {

        public static string Err1 = $"Master password cannot be blank. Also, make sure password length is between {Login.pswLengthLowerLimit}-{Login.pswLengthUpperLimit} characters.";
        public static string Err2 = $"The password does not match.";
        public static string Err3 = $"Error occurred when retrieving Data Table.";

        



        public static string Msg1 = $"Please try again.";
        public static string Msg2 = $"Please try in again later.";
        public static string Msg3 = $"Max login attempts reached.";




    }
}
