/*
 Password Manager application with c#: https://www.youtube.com/watch?v=MSkFeb7HhiQ
selve github koden: https://github.com/hnawaz007/password-manager

Committing to github error: https://stackoverflow.com/questions/47255844/github-commit-error-permission-denied-fatal-unable-to-process-path-app-data
 
 
SQL Query
----------------
Update masterPass
  Set 
	[pass] = 'Admin123'
  Where 
	[Id] = 1;
----------------

----------------
Select *
From masterPass
---------------- 


----------------
Select *
From masterPass
truncate table masterPass
---------------- 


Select *
From pwManager
truncate table pwManager
Select *
From masterPass
truncate table masterPass





_____________________________
https://stackoverflow.com/questions/15547959/print-contents-of-a-datatable
foreach(DataRow dataRow in Table.Rows)
{
    foreach(var item in dataRow.ItemArray)
    {
        Console.WriteLine(item);
    }
}

Here is another solution which dumps the table to a comma separated string:

using System.Data;

public static string DumpDataTable(DataTable table)
        {
            string data = string.Empty;
            StringBuilder sb = new StringBuilder();

            if (null != table && null != table.Rows)
            {
                foreach (DataRow dataRow in table.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        sb.Append(item);
                        sb.Append(',');
                    }
                    sb.AppendLine();
                }

                data = sb.ToString();
            }
            return data;
        }
____________________________________________




Hashalgorithm: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithm.computehash?view=netcore-3.1


“tostring short hex c#” Code Answer: https://www.codegrepper.com/code-examples/csharp/tostring+short+hex+c%23
int num = 123;
//X can be capital and not capital it specifies if the hex characters should be upper or lowercase
//the number specifies the amount of hex characters
//2X will give you something like A5
string hex = num.ToString("X2");



Brainstorm
masterPass tabellen, OK:
Kolonne[0] = [ID] Skal være unik, dvs. primary key (1, 1), starter med 1 og forøger med 1
Kolonne[1] = [hash]
Kolonne[2] = [tip]

Main loginCredential tabellen?:
Kolonne[0] = [ID] Skal være unik
Kolonne[1] = [usr] Skal være unik
Kolonne[2] = [psw]
Kolonne[3] = [app]
Kolonne[4] = [Optional: BindingPasswordToAnotherAppOrWithinSameApp?]

Opret ny tabel ved angivelse af app navn, herefter generer der en tabel med app som navn som indeholder følgende kolonner:
Kolonne[0] = [ID] 
Kolonne[1] = [usr]
Kolonne[2] = [psw]
Kolonne[3] = [Optional: BindingPasswordToAnotherAppOrWithinSameApp?]
Dvs. en tabel for hver app.

Tilføj værdier til den nyoprettede tabel:
Kolonne[1] = [usr]
Kolonne[2] = [psw]
Kolonne[3] = [Optional: BindingPasswordToAnotherAppOrWithinSameApp?]

Update this value in this table
and update this value in another table
For this to happen we need a table (app) name and ID no.
Column name is psw across all tables.



Main menu after successful log in as Admin
1) Create new application
2) Show list of all applications
	2a) Show all login credential of specified application
		2a.1) Add new login credential
		2a.2) Change login credential
		2a.3) Binding psw to another login
			2a.3.1) Please specify application and username
	2b) Add new login credential of specified application
3) Show all login credential of specified application
4) Delete all login credentials of specified application
	4a) Are you sure: Yes/No
5) Quit

 */