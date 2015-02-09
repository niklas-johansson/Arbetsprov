using ConsoleApp.MessageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {            
            String text;
            MessageServiceClient serviceClient = new MessageServiceClient();
            
            Console.WriteLine("Avsluta programmet genom att skriva \"exit\" eller ett tomt meddelande.\n");

            while (true)
            {
                try
                {
                    Console.Write("Skriv ett meddelande: ");
                    text = Console.ReadLine();

                    if (String.Equals(text, "") || String.Equals(text, "exit"))
                    {
                        Environment.Exit(0);
                    }
                    else if (text.Length < 4000)    // SQL nvarchar(MAX)
                    {
                        if (serviceClient.AddNewMessage(text) == true)
                        {
                            Console.WriteLine("Meddelandet \"" + text + "\" har nu sparats i databasen.\n");
                        }
                        else
                        {
                            throw new Exception("Något gick fel och meddelandet kunde inte sparas i databasen.");
                        }
                    }
                    else
                    {
                        throw new Exception("Meddelandet får inte vara mer än 4000 tecken långt.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message + "\n");
                }
            }
        }
    }
}
