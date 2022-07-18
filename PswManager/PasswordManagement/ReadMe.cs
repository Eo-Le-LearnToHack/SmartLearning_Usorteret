using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    internal class ReadMe
    {
        /*
        Problematik: 
        Verden bliver mere og mere digitalt. En person har mange digitale profiler og tilhørende logins.
        Det er svært at huske på alle de profiler og logins som man har.
        Nogle gange bliver man nødt til at oprette en hel ny profil for at tilgå den samme tjeneste, 
        dog mister man tidligere historik, kontaktoplysninger, beskeder, bedrifter m.m..

        Løsning:
        Programmet skal hjælpe en med at holde styr på de mange profiler og tilhørende logins.
        Det er ikke anbefalet at have login credentials hardcoded i koden, derfor skal man kunne tilføje profiler og tilhørende logins efter programmet er compiled.
        Programmet skal have en GUI og kode med C#, derfor er der valgt at oprette projektet som "WPF app".
        Programmet er til personligt brug og login credentials skal ikke være krypteret når først brugeren er logget ind.

        Design - Velkomststkærm:
        Gui'en skal indeholde følgende elementer på velkomstskærmen
        Login med username og password
        Maks 1000 forsøg
        Login hint vist efter mislykket login
        Antal login forsøg vist efter mislykket login

        Design - AuditTrail:
        Inspireret af lægemiddellovgivningen på Computerised System (Eudralex Volume 4, Annex 11) skal der være en overordnet Audit Trail
        som logger nødvendige aktiviteter i kronologisk rækkefølge.
        Audit Trail skal være retvisende.
        Audit Trail må ikke kunne ændres i bagudrettet.
        Audit Trail skal logge Dato og tid for hvornår hændelsen er sket.
        Audit Trail skal logge ændringer i form af gammel og ny værdi.
        Audit Trail skal logge hvem der har foretaget ændringen.
        Audit Trail skal logge årsag for ændringen.
        Audit Trail skal navnet på den computer hvor hændelsen er registreret.
        Audit Trail kan fremvises.
        Audit Trail kan sorteres i hvornår, hvem, hvad, hvorfor, hændelsekategori, beskrivelse af hændelsen, gammel værdi, ny værdi, PC navn
        Audit Trail kan udprintes evt. som PDF eller sendes til printerudskrift.
        Audit Trail er tilgængelig for alle brugerne.
        Audit Trail må ikke kompromittere sikkerheden, eks. må den ikke afsløre password eller username.


        Design - Login credentials:
        Username skal gemmes i plain tekst.
        Password skal gemmes i krypteret form, evt. SHA-512 hash og salted

        Design - Brugerprofil
        1) Se dato/tid i real time
        2) Se sin rettighedsrolle
        3) Se PC navn
        4) Tilføj ny profilgruppe
        5) Se eksisterende profilgrupper
        6) I profilgruppen kan oprettes ny
        6a) alias
        6b) brugernavn
        6c) kode
        6d) links
        6e) nøgle op til 5
        6f) værdi op til 5 (tilknyttet nøglen)
        6g) autoudfyld login med mulighed for indtastning af username --> events op til 10 --> kode --> events op til 10 --> nøgle/værdi --> events op til 10 --> ENTER event
        6h) Udskriv elementernes værdier med TAB events imellem.
        7) I profilgruppen kan ses
        7a) Oversigt over alias og tilhørende logins, nøgler og værdier. Gemmer op til 99 tidligere værdier for alle elementerne.
        8) I profilgruppen kan alle elementer ændres.
        9) Ved oprettelse af ny profil kan der genanvende værdier fra eksisterende alias
        10) Ved redigering af elementernes værdier træder dette først i kraft ved tryk på GEM

        Design - Brugerforvaltning
        Overordnet 2 kategorier
        1) Admin
        2) User



        Documentation, references and tutorials:
        Videolist:
        ------------------
        1) XAML Basics Tutorial | WPF: https://www.youtube.com/watch?v=Z0a0QYNlKig
        //Events loaded in MainWindow
        //MessageBox.Show
        //Grid vs stackpanel
        //ColumnDefinition
        //Grid.Column="0", Grid.Column="1" etc.
        //Hold down the "Alt" key to use a square to mark the code.
        //Commenting out <!--<PutYourCommentInHere/>-->
        //Grid size. The asterik * is another way to evenly distributed the size in stars. E.g. *, 0.5*, 5* etc. 
        //Grid border
        //Margin in Grid = Add space around the control. Limits the size of the control.
        //Padding in border = Extends the control. First number left and rigt. Second number top and bottom. Or first = left, second = top, third = right, fourth = bottom
        //Background="color"
        //TextBox TextChanged="TextBox_TextChanged" //EVENT
        //Checkbock Checked and unchecked EVENT
        //ComboBox viewing values in a list
        //IsReadOnly ="True" makes Textbox readonly.
        //<StackPanel> </StackPanel>To insert e.g. one box below another box.


        2) Intro to WPF: Learn the basics and best practices of WPF for C#: https://www.youtube.com/watch?v=gSfMNjWNoX0
        // Installing Visual Studio
        // Creating new project WPF app (.NET Framwork) Visual C#
        //Grid.ColumnSpan ="3" //Tekst må fylde op til 3 kolonner i samme række.
         


        Websites:
        Fit Text in Button: https://social.msdn.microsoft.com/Forums/vstudio/en-US/7b41e03d-be34-4554-b984-7478d444d1de/fit-text-in-button?forum=wpf
        //The button is auto resize depends on the text size
        */




    }
}
