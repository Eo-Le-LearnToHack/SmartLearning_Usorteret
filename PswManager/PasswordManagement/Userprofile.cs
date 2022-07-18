using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public static class InputManager
    {
        public static float ReadLineFloat()
        {
            string answer;
            while (true)
            {
                answer = Console.ReadLine();
                if (answer == null)
                {
                    Console.WriteLine("Answer must be a non-null value");
                    continue;
                }

                if (!float.TryParse(answer, out float value))
                {
                    Console.WriteLine("The input must be a number");
                    continue;
                }
                break;
            }

            return float.Parse(answer);
        }
    }

    public class Userprofile
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Hint { get; set; }

    }

    public class RegisterUser
    {
        public RegisterUser()
        {
            this.CheckForExistingUser();
            this.AddUser();
        }

        private void CheckForExistingUser()
        {
            //Check for existing user in predefined database
            //If user exists in database, add new user.

        }

        private string AddUser()
        {
            //If user is does not exist in database, add new user.
            string Usr = Console.ReadLine();
            return Usr;
        }
    }
}
