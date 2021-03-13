
using System;
using System.Text.RegularExpressions;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        //TODO: Concern Separation: Command Parsing + Args Validation + Business Logic + Presentation

        if (args.Length > 0 && args[0] == "hello")
        {
            Console.WriteLine("What's your name?");
            var name = Console.ReadLine();
            Console.WriteLine($"Hello {name}!");
        }
        else if (args.Length > 0 && args[0] == "account")
        {
            if (args.Length > 1 && args[1] == "open")
            {
                if (args.Length > 2 && (args[2] == "--user-id" || args[2] == "-u"))
                {
                    //TODO: Improve email validation by sending actual email
                    if (args.Length > 3
                        && !string.IsNullOrEmpty(args[3])
                        && Regex.IsMatch(
                                args[3],
                                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                                RegexOptions.IgnoreCase))
                    {
                        var userId = args[3];

                        var result = OpenAccount(userId);
                        Console.WriteLine($"Result: OK, Account: {JsonSerializer.Serialize(result)}");
                    }
                    else
                    {
                        Console.WriteLine("--user-id -u [Required] : User ID (i.e. email)");
                    }
                }
                else
                {
                    Console.WriteLine("Command");
                    Console.Write("\t");
                    Console.WriteLine("MyBank account create : Open (Create) a new account");
                    Console.WriteLine("Arguments");
                    Console.Write("\t");
                    Console.WriteLine("--user-id -u\t[Required] : Unique verifiable User ID (i.e. DNI, CC, email)");
                }
            }
            else if (args.Length > 1 && args[1] == "show")
            {
                Console.WriteLine("TODO");
            }
            else if (args.Length > 1 && args[1] == "deposit")
            {
                Console.WriteLine("TODO");
            }
            else if (args.Length > 1 && args[1] == "withdraw")
            {
                Console.WriteLine("TODO");
            }
            else if (args.Length > 1 && args[1] == "close")
            {
                Console.WriteLine("TODO");
            }
            else
            {
                Console.WriteLine("Group");
                Console.Write("\t");
                Console.WriteLine("MyBank account : Manage MyBank accounts");
                Console.WriteLine("Commands:");
                Console.Write("\t");
                Console.WriteLine("open\t\t: Open (Create) a new account");
                Console.Write("\t");
                Console.WriteLine("show\t\t: Show (Get) account details");
                Console.Write("\t");
                Console.WriteLine("deposit\t\t: Credit account balance");
                Console.Write("\t");
                Console.WriteLine("withdraw\t: Debit account balance");
                Console.Write("\t");
                Console.WriteLine("close\t\t: Close (Deactivate) an existing account");
            }
        }
        else
        {
            Console.WriteLine("Welcome to MyBank!");
            Console.WriteLine("Usage: MyBank hello");
            Console.WriteLine("Usage: MyBank account");
        }

    }

    private static Account OpenAccount(string userId)
    {
        var result = new Account
        {
            Id = Guid.NewGuid(),
            Balance = 0,
            Status = "Active",
            UserId = userId,
            UserSecret = Guid.NewGuid()
        };

        //TODO: Save Result

        return result;
    }

    // Class-less Models?
    private class Account
    {
        public Guid Id { get; set; }
        public int Balance { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public Guid UserSecret { get; set; }
    }
}