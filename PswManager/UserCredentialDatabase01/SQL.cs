using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserCredentialDatabase01
{
    internal class SQL
    {

        //_____________________________________________________
        //Tables and column names
        public static string tableMasterPass = "masterPass";
        public static string tableMasterPassCol_Id = "Id";
        public static string tableMasterPassCol_pass = "pass";
        

        public static string tablePwManager = "pwManager";
        public static string tablePwManagerCol_Id = "Id";
        public static string tablePwManagerCol_pw = "pw";
        public static string tablePwManagerCol_app = "app";
        public static string tablePwManagerCol_modified = "modified";
        //_____________________________________________________



        //_____________________________________________________
        //Reference to the database pw.mdf in the folder C:\Users\sim8hu\Desktop\Code\cSharp\Eksamen_gitHub\UserCredentialDatabase01\Database
        public static string cstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sim8hu\Desktop\Code\cSharp\Eksamen_gitHub\UserCredentialDatabase01\Database\pw.mdf;Integrated Security=True;Connect Timeout=30";

        public static SqlConnection connection = SQL.SQLConnectionOn();
        public static SqlConnection SQLConnectionOn()
        {
            string cstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sim8hu\Desktop\Code\cSharp\Eksamen_gitHub\UserCredentialDatabase01\Database\pw.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection cs = new SqlConnection(cstring);
            return cs;
        }
        //_____________________________________________________



        ///RETRIEVING data from SQL table
        public static DataTable? getDataTable(string tableName) 
        {
            DataTable dataTable = new DataTable();
                try
                {
                    SqlCommand cmd = new SqlCommand($"Select * from {tableName}", SQL.connection);
                    SQL.connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataTable);
                    SQL.connection.Close();
                    return dataTable;
                }
                catch (Exception)
                {
                    Console.WriteLine(Message.Err3);
                    return null;
                }
        }


        ///RETRIEVING data from SQL table based on searchCondition1 containing in tableColumn1
        public static DataTable? getDataTable(string tableName, string tableColumn1, string searchCondition1, string tableColumnOutput)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand($"Select * from {tableName} where app = '" + searchCondition1 + "'", SQL.connection);
                SQL.connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
                SQL.connection.Close();
                Console.WriteLine($"The password for {searchCondition1} is:\t {dataTable.Rows[0][tableColumnOutput]}");
                return dataTable;
            }
            catch (Exception)
            {
                Console.WriteLine(Message.Err3);
                return null;
            }
        }



        //ADDING 1 value to SQL table and return true
        public static bool InsertValue(string tableName, string tableColumn1, string input1) 
        {
            var bol = false;
            try
            {  
                SqlCommand cmd = new SqlCommand($"Insert into {tableName} ({tableColumn1}) values (@value1)", SQL.connection); //indsættes  værdien (fra variablen @value1) i tableColumn1 i tabellen tableName
                cmd.Parameters.AddWithValue("@value1", input1);
                SQL.connection.Open();
                cmd.ExecuteNonQuery();
                SQL.connection.Close();
                //
                Console.WriteLine($"Password has been add SQL Table {tableName} in column {tableColumn1}");
                bol = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Error occurred when inserting password to SQL table");
                bol = false;
            }
            return bol;
        }


        //ADDING 2 values to SQL table and return true
        public static bool InsertValue(string tableName, string tableColumn1, string tableColumn2, string input1, string input2)
        {
            var bol = false;
            try
            {
                SqlCommand cmd = new SqlCommand($"Insert into {tableName} ({tableColumn1}, {tableColumn2}) values (@col1, @col2)", SQL.connection); //Indsættes @pw and @app i kolonne tableColumn1 og tableColumn2
                cmd.Parameters.AddWithValue("@col1", input1); //Indsæt input1 i col1
                cmd.Parameters.AddWithValue("@col2", input2); //Indsæt input1 i col2
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                //
                Console.WriteLine($"Successful inserting values into SQL table {tableName}. Value {input1} is inserted in column {tableColumn1} and value {input2} is inserted in column {tableColumn2}");
                bol = true;
            } 
            catch (Exception)
            {
                Console.WriteLine("Error occurred when generating service password.");
                bol = false;
            }
            return bol;
        }

    } //class SQL
} //namespace UserCredentialDatabase01
