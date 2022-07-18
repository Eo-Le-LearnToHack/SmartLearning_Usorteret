/*
 * using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;

namespace UserCredentialDatabase01
{

    class Program
    {

        //mask user input
        public static string? ReadPassword()
        {
            string password = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        return null;
                    case ConsoleKey.Enter:
                        return password;
                    case ConsoleKey.Backspace:
                        if (password.Length > 0)
                        {
                            password = password.Substring(0, (password.Length - 1));
                            Console.Write("\b \b");
                        }
                        break;
                    default:
                        password += key.KeyChar;
                        Console.Write("*");
                        break;
                }
            }
        }


        //HASH
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }


        // get masterpassword
        public static DataTable? getMasterPw()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection cs = new SqlConnection(cstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from masterpass", cs);
                    cs.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataTable);
                    cs.Close();
                    //
                    //Console.WriteLine("Master password is generated. Please keep it safe.");
                    return dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred when generating master password.");
                    return null;
                }
            }
        }
        //inser service
        public static void insertService(string serviceName)
        {
            using (SqlConnection cs = new SqlConnection(cstring))
            {
                try
                {
                    string hash;
                    using (SHA256 sha256hash = SHA256.Create())
                    {
                        hash = GetHash(sha256hash, serviceName);
                    }

                    var tenDigits = hash.Substring(0, 10);

                    SqlCommand cmd = new SqlCommand("Insert into pwManager (pw, app) values (@pw, @app)", cs);
                    cmd.Parameters.AddWithValue("@pw", tenDigits);
                    cmd.Parameters.AddWithValue("@app", serviceName);
                    cs.Open();
                    cmd.ExecuteNonQuery();
                    cs.Close();
                    //
                    Console.WriteLine($"{serviceName} password created");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred when generating service password.");
                }

            }
        }
        //
        public static void getServiceNamePw(string serviceName)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection cs = new SqlConnection(cstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from pwManager where app = '" + serviceName + "'", cs);
                    cs.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataTable);
                    cs.Close();
                    //
                    if (dataTable.Rows.Count != 0)
                    {
                        Console.WriteLine(serviceName + " password; " + dataTable.Rows[0]["pw"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred when trying to retrieve the password. Please try again.");
                }
            }

        }



        private static string cstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sim8hu\Desktop\Code\cSharp\Eksamen_gitHub\UserCredentialDatabase01\Database\pw.mdf;Integrated Security=True;Connect Timeout=30";
        static void Main(string[] args)
        {
            var dt = getMasterPw();
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("Welcome. Please create a master password. Password must be between 6-12 characters.");
                string? masterPass = ReadPassword();
                Console.WriteLine($"Entered pass {masterPass} length {masterPass.Length}");
                if (masterPass != null && masterPass.Length >= 6 && masterPass.Length <= 12)
                {
                    var bol = generateMasterPassword(masterPass);
                    if (bol)
                    {
                        //we can call on inser service method
                        generateService();
                    }
                    else
                    {
                        Console.WriteLine("Master password cannot be blank. Also, make sure password length is between 6-12 characters.");
                    }
                }
            }
            else
            {
                //attempt counter
                int loginAttempts = 0;

                // Three login tries
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("What is your master password?");
                    string? masterPass = ReadPassword();

                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        string? hash = dt.Rows[0]["pass"].ToString();

                        Console.WriteLine("Verifying the hash...");
                        if (VerifyHash(sha256Hash, masterPass, hash))
                        {
                            Console.WriteLine("Welcome back.");
                            generateService();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The password does not match.");
                            Console.WriteLine("Please try again. What is your master password?");
                            loginAttempts++;
                        }
                    }

                    //Display the result
                    if (loginAttempts > 2)
                    {
                        Console.WriteLine("Max login attempts reached. Please try in again later.");
                    }

                    {

                    }
                }


            }

        }

        //generate master password
        public static bool generateMasterPassword(string masspw)
        {
            var bol = false;
            using (SqlConnection cs = new SqlConnection(cstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into masterPass (pass) values (@pass)", cs);
                    cmd.Parameters.AddWithValue("@pass", masspw);
                    cs.Open();
                    cmd.ExecuteNonQuery();
                    cs.Close();
                    //
                    Console.WriteLine("Master password is generated. Please keep it safe.");
                    bol = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred when generating master password.");
                    bol = false;
                }

            }
            return bol;
        }
        //
        public static void generateService()
        {
            Console.WriteLine("What would you like to do?");
            while (true)
            {
                Console.WriteLine("                          ");
                Console.WriteLine("***************************");
                Console.WriteLine("Available commands: ");
                Console.WriteLine("q : quit program");
                Console.WriteLine("g : get password");
                Console.WriteLine("s : save password");
                Console.WriteLine("***************************");
                Console.WriteLine("What is your service name?");
                string? service = Console.ReadLine();
                switch (service)
                {
                    case "s":
                        string? nameS = Console.ReadLine();
                        insertService(nameS);
                        break;
                    case "g":
                        string? nameG = Console.ReadLine();
                        getServiceNamePw(nameG);
                        break;
                    case "q":
                        break;
                }

                if (service == "q")
                    break;
                {

                }

            }
        }
    }
}


 */