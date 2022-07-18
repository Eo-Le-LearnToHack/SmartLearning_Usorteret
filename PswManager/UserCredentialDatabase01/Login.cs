using PasswordManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserCredentialDatabase01
{
    internal class Login
    {
        public static int pswLengthLowerLimit = 6;
        public static int pswLengthUpperLimit = 12;
        private static int loginAttempts = 0; //attempt counter
        public static void Attempts(int NumberOfAllowedAttempts)
        {
            for (int i = 0; i < NumberOfAllowedAttempts; i++)
            {

                Console.WriteLine("What is your master password?");
                string? masterPass = ConsoleInput.PasswordIsMasked();
                DataTable? dt = SQL.getDataTable(SQL.tableMasterPass); //Indhenter data fra tabellen masterPass
                string? hash = dt.Rows[0][SQL.tableMasterPassCol_pass].ToString(); //indhenter masterkode i tabellen masterPass og gemmes i variablen hash

                Console.Write("Verifying the hash...:\t\t");
                if (Compare.InputVsHash(masterPass, hash)) //Verificer indtastede masterPass (master password) over for hash værdien fundet i tabellen masterPass (Rows[0]["pass"]). Hvis sandt returner true og If statement køres.
                {
                    Console.WriteLine("Welcome back.");
                    Program.MainMenu();
                    break;
                }
                else
                {
                    Console.WriteLine(Message.Err2);
                    Console.WriteLine();
                    Console.WriteLine(Message.Msg1);
                    loginAttempts++;
                }
            }
            if (loginAttempts > NumberOfAllowedAttempts-1) //login attempt start ved 0, derfor bliver der brugt n+1 forsøg.
            {
                Console.WriteLine();
                Console.WriteLine($"Your have tried ({NumberOfAllowedAttempts} times). " + Message.Msg3 + Message.Msg2);
            }
        }


    } //class Login
} //namespace UserCredentialDatabase01
