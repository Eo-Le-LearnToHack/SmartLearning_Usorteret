using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool loopProgramMain = true;
            do
            {
                //CheckIfMasterPswExistOrNotInDatabase
                //IfMasterPswNotExist ThenCreateNewMasterPsw
                //IfMasterPswExist ThenAskForPsw LoginAttempt3Times
                //IfCorrectMasterPswEnteren ThenEnterTheProgramPasswordManager

                //CheckIfAnySQLTableOtherThanMasterPswExist
                //IfNotExist ThenAskForCreateOfNewTable/Service
                //IfExist ThenListAllTheServices and options available



            } while (loopProgramMain);







        }//Main(string[] args)
    }//class Program
}//namespace PasswordManager