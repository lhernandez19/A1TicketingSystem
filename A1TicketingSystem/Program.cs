using System;
using System.IO;
using System.Collections.Generic;

namespace A1TicketingSystem
{
    class Program
    {           
        static void Main(string[] args)
        {
        // ask user, create a loop to repeat the process multiple time until user stops.
        string choice;
        string file = "Tickets.csv";

        do 
        {
            Questions();
            choice = Console.ReadLine();
            // Create ticket.
            if(choice == "1")
            {
                NewTicket();
            }
            // See tickets.
            else if (choice == "2")
            {
                StreamReader sr = new StreamReader(file);
                Console.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                Console.WriteLine("");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
            }
            // Exit program.
            else
            {
                Console.WriteLine("Closing program...");
            }
        }

        while (choice == "1" || choice == "2");

        }

        //-Method- Main question to be ask to the user 
        static void Questions()
        {
            Console.WriteLine("Do you want to create a new ticket? (1)");
            Console.WriteLine("Do you want to see all the tickets? (2)");
            Console.WriteLine("Enter any other key to exit.");
        }
        
        //-Method- to create new tickets
        static void NewTicket()
        {
            string file = "Tickets.csv";
            int ticketId = 0;
            StreamWriter sw = new StreamWriter(file);

            for (var i = 0; i < 10; i++)
            {
                ticketId++;

                Console.WriteLine("Enter a ticket summary: ");
                string summary = Console.ReadLine();

                Console.WriteLine("Choose status: 1. Open | 2.Closed");
                string status = Console.ReadLine(); 
                switch (status)
                {
                    case "1":
                        status = "Open";
                        break;
                    case "2":
                        status = "Closed";
                        break;
                }

                Console.WriteLine("Choose priority: 1. Low | 2. Medium | 3. High");
                string priority = Console.ReadLine(); 
                switch (priority)
                {
                    case "1":
                        priority = "Low";
                        break;
                    case "2":
                        priority = "Medium";
                        break;
                    case "3":
                        priority = "High";
                        break;
                }

                Console.WriteLine("Submitter: ");
                string submitter = Console.ReadLine();   

                Console.WriteLine("Assigned: ");
                string assigned = Console.ReadLine();  

                // Console.WriteLine("Watch by: ");
                // string watcher = Console.ReadLine();  

                var watchers = new List<string>();
                string watcher;
                string option;

                do
                {
                Console.WriteLine("Watch by: ");
                watcher = Console.ReadLine();
                watchers.Add(watcher);

                Console.WriteLine("Do you want to add a Watcher: (Y/N)");
                option = Console.ReadLine().ToUpper();
                
                } while (option == "Y");
                
                string watchedBy =  string.Join("|", watchers); 

                sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticketId, summary, status, priority , submitter ,assigned, watchedBy);

                Console.WriteLine("Enter a new ticket (Y/N)?");
                string resp = Console.ReadLine().ToUpper();
                if (resp != "Y") { break; }
            }
            sw.Close();

        }

    }
}
