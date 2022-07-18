using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserCredentialDatabase01;

namespace PasswordManager
{
    class Program
    {
        static void Main(string[] args)
        {

            bool bol = true;
            do
            {
                DataTable? dataTable = SQL.getDataTable(SQL.tableMasterPass); //Indhenter data fra tabellen masterPass
                if (dataTable.Rows.Count == 0) //Hvis ingen data køres If statement.
                {
                    CreateMasterPasswordToUseTheProgram();
                }
                else //Hvis master password findes køres Else statement
                {
                    Login.Attempts(3);
                }
                bol = false;
            } while (bol);
        }


        public static void CreateMasterPasswordToUseTheProgram()
        {
            Console.Clear();
            Console.WriteLine($"Welcome. Please create a master password. Password must be between {Login.pswLengthLowerLimit}-{Login.pswLengthUpperLimit} characters.");
            string? masterPass = ConsoleInput.PasswordIsMasked(); //Returner indtastede password i variablen masterPass og samtidig maskerede indtastning med stjerne, *
            Console.WriteLine($"The enter password: {masterPass} \t length: {masterPass.Length}");
            if (masterPass != null && masterPass.Length >= Login.pswLengthLowerLimit && masterPass.Length <= Login.pswLengthUpperLimit) //Hvis master password opfylder kravet mellem pswLengthLowerLimit-pswLengthUpperLimit karakter køres If statement
            {
                string? hash = Hash.Generate(masterPass);
                bool bol = SQL.InsertValue(SQL.tableMasterPass, SQL.tableMasterPassCol_pass, hash); //Tilføjer hash i SQL tabellen masterPass og returnerer true, hvis lykkedes.
                if (bol) //Hvis lykkes at tilføje den hash i SQL tabellen, køres If statement
                {
                    MainMenu(); //Dette er Hovedmenuen hvor der kan vælges g, getAll, s eller q.
                }
            }
            else
            {
                Console.WriteLine(Message.Err1);
                Console.ReadLine();
            }
        }

        public static void MainMenu()
        {
            bool bol = true;
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("                          ");
                Console.WriteLine("***************************");
                Console.WriteLine("Available commands: ");
                Console.WriteLine("q : quit program");
                Console.WriteLine("g : get the hash");
                Console.WriteLine("s : hash the password and save to database");
                Console.WriteLine("getAll : get all data from database");
                Console.WriteLine("***************************");

                string? usrInput = Console.ReadLine();
                string? psw;
                switch (usrInput)
                {
                    case "s":
                        Console.WriteLine($"Enter the password you want to hash. The password must be between characters {Login.pswLengthLowerLimit}-{Login.pswLengthUpperLimit}.");
                        psw = ConsoleInput.PasswordIsMasked();
                        if (psw != null && psw.Length >= Login.pswLengthLowerLimit && psw.Length <= Login.pswLengthUpperLimit)
                        {
                            string? hash = Hash.Generate(psw);
                            if (SQL.InsertValue(SQL.tablePwManager, SQL.tablePwManagerCol_app, SQL.tablePwManagerCol_pw, psw, hash)) //Hvis lykkes at tilføje den hash i SQL tabellen, køres If statement
                            {
                                MainMenu(); //Dette er Hovedmenuen hvor der kan vælges g, s eller q.
                            }
                        }
                        else
                        {
                            Console.WriteLine(Message.Err1);
                            Console.ReadLine();
                        }
                        break;
                    case "g":
                        Console.WriteLine("Get the hash saved in the Database by entering the raw password.");
                        psw = Console.ReadLine();
                        SQL.getDataTable(SQL.tablePwManager, SQL.tablePwManagerCol_app, psw, SQL.tablePwManagerCol_pw);
                        MainMenu();
                        break;
                    case "getAll":
                        DataTable? dt = SQL.getDataTable(SQL.tablePwManager);
                        foreach (DataRow dataRow in dt.Rows)
                        {
                            foreach (var item in dataRow.ItemArray)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        MainMenu();
                        break;
                    case "q":
                        Console.WriteLine("Exiting program");
                        break;
                }
                bol = false;
            } while (bol);
        }



    } //class Program
} //namespace PasswordManager
