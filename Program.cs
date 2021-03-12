/*
    MyBank CLI: simple console toy app to teach information technologies 
    aimed to Banking Industry, specially CxOs to desmitify IT thru a business competitive advantage lens.
    MyBank is an example on how DX can disrupt traditional Banking based on following assumptions:
    Macrotrends:
        * R&D + Marketing $ over Production + Distribution $ 
        * Demand Aggregation over Offer Aggregation

    Company Imperatives:
        * Customer Experience (CX) over Any Else
        * Data + Internet over Physical
        * Trust + Agility over Control
        * Culture + People over Processes + Machines
    
    MyBank v1.0.0
    Services:
        - OpenAccount(<email>) : creates a new Account 
            { 
                Id: <guid>, //[auto-generated]
                Balance: 0, //Default
                Status: Active, //Default
                UserId: <email>, //[given]
                UserKey: <secret> //[auto-generated]
            }
        - ShowAccount(<accountId>, <secret>) : gets Account's details
            { 
                Id: <accountId>, 
                Balance: 0, 
                Status: Active, 
                UserId: <email>
            }
        - DepositToAccount(<accountId>, <ammount>, <secret>, <token>): credits Account's balance by given ammount
            { 
                Id: <accountId>, 
                Balance: <currentBalance> + <ammount>
            }
        - WithdrawFromAccount(<accountId>, <ammount>, <secret>): debits Account's balance by given ammount
            { 
                Id: <accountId>, 
                Balance: <currentBalance> - <ammount>
                Token: <token>
            }
        - CloseAccount(<accountId>, <secret>) : deactivate an existing Account
            { 
                Id: <accountId>, 
                Status: Inactive //set Status to Inactive
            }
        
    Concepts:
        - Account:
            - Id: <guid>
            - Balance : 0 (default) | <number> > 0
            - Status : Active (defult) | Inactive
            - UserId : <guid> | <email>
            - UserKey : <secret>
        - Token: Unique authenticable value representation (i.e. Bank Check)

    Business Critical Assumptions:
        - MyBank is able to authenticate all user's request using a secret
            - The secret is known exclusively by the User
        - Cannot withdraw > Balance
        - Deposit requires a valid Token representing the Credited ammount
        - Withdraw returns a valid Token representing the Debited ammount
        - Tokens are Payable and Receivable goods for MyBank
        - Tokens are unique and cannot be duplicated
    
*/
using System;
using System.Text.RegularExpressions;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
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
        return new Account
        {
            Id = Guid.NewGuid(),
            Balance = 0,
            Status = "Active",
            UserId = userId,
            UserSecret = Guid.NewGuid()
        };
    }

    private class Account
    {
        public Guid Id { get; set; }
        public int Balance { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public Guid UserSecret { get; set; }
    }
}