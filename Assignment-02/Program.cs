using System;

internal class BankAccount
{
    static int[] accNumbers = new int[10];
    static double[] balances = new double[10];
    static string[] holderNames = new string[10];
    static double[] ratesOfInterest = new double[10];  
    static string[,] logTransactions = new string[10, 100];
    static int[] transactionCounts = new int[10];

    static void Main(string[] args)
    {
        SetupDefaultAccounts();
        DisplayMainMenu();
    }

    // Setup the default accounts with initial data and 3% interest rate
    static void SetupDefaultAccounts()
    {
        for (int i = 0; i < 10; i++)
        {
            accNumbers[i] = 100 + i;
            balances[i] = 100.0;
            holderNames[i] = "Account Holder " + (100 + i);
            ratesOfInterest[i] = 0.03;  
            transactionCounts[i] = 0;
        }

        
        for (int i = 5; i < 10; i++)
        {
            accNumbers[i] = -1;  
        }
    }

    static void DisplayMainMenu()
    {
        bool shouldExit = false;
        while (!shouldExit)
        {
            Console.WriteLine("\nATM Main Menu:");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Access Account");
            Console.WriteLine("3. Quit");
            Console.Write("Enter your choice: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateNewAccount();
                    break;
                case "2":
                    AccessAccount();
                    break;
                case "3":
                    shouldExit = true;
                    Console.WriteLine("Thank you for using the ATM system.");
                    break;
                default:
                    Console.WriteLine("Invalid input, please try again.");
                    break;
            }
        }
    }

    static void CreateNewAccount()
    {
        int availableIndex = FindEmptySlot();

        if (availableIndex == -1)
        {
            Console.WriteLine("No available slots for new accounts.");
            return;
        }
        else
        {
            Console.Write("Enter Account Number: ");
            int accountNum = int.Parse(Console.ReadLine());

            if (FindAccountIndex(accountNum) != -1)
            {
                Console.WriteLine("Account already exists. Please use another account number.");
                return;
            }

            Console.Write("Enter Initial Balance: ");
            double startingBalance = double.Parse(Console.ReadLine());

            Console.Write("Enter Account Holder's Name: ");
            string holderName = Console.ReadLine();

            Console.Write("Enter Interest Rate (as a percentage, e.g., 3 for 3%): ");
            double interestRate = double.Parse(Console.ReadLine()) / 100;  

            accNumbers[availableIndex] = accountNum;
            balances[availableIndex] = startingBalance;
            holderNames[availableIndex] = holderName;
            ratesOfInterest[availableIndex] = interestRate;

            Console.WriteLine("Account successfully created!");
        }
    }

    static int FindEmptySlot()
    {
        for (int i = 0; i < accNumbers.Length; i++)
        {
            if (accNumbers[i] == -1)  
            {
                return i;
            }
        }
        return -1;  // No empty slots available
    }

    static void AccessAccount()
    {
        Console.Write("Enter Account Number: ");
        int accountNum = int.Parse(Console.ReadLine());

        int accountIndex = FindAccountIndex(accountNum);

        if (accountIndex != -1)
        {
            ShowAccountMenu(accountIndex);
        }
        else
        {
            Console.WriteLine("No account found with that number.");
        }
    }

    static int FindAccountIndex(int accountNum)
    {
        for (int i = 0; i < accNumbers.Length; i++)
        {
            if (accNumbers[i] == accountNum)
            {
                return i;
            }
        }
        return -1;  // Account not found
    }

    static void ShowAccountMenu(int accountIndex)
    {
        bool leaveMenu = false;
        while (!leaveMenu)
        {
            Console.WriteLine($"\nAccount Menu for {holderNames[accountIndex]}:");
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw Funds");
            Console.WriteLine("4. Show Transactions");
            Console.WriteLine("5. Compute Interest");
            Console.WriteLine("6. Back to Main Menu");
            Console.Write("Choose an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine($"Current Balance: {balances[accountIndex]:C}");
                    break;
                case "2":
                    DepositFunds(accountIndex);
                    break;
                case "3":
                    WithdrawFunds(accountIndex);
                    break;
                case "4":
                    ListTransactions(accountIndex);
                    break;
                case "5":
                    ComputeInterest(accountIndex);
                    break;
                case "6":
                    leaveMenu = true;
                    break;
                default:
                    Console.WriteLine("Invalid input, please try again.");
                    break;
            }
        }
    }

    static void DepositFunds(int accountIndex)
    {
        Console.Write("Enter deposit amount: ");
        double amount = double.Parse(Console.ReadLine());

        balances[accountIndex] += amount;
        LogTransaction(accountIndex, $"Deposited {amount:C}");
        Console.WriteLine("Deposit successful!");
    }

    static void WithdrawFunds(int accountIndex)
    {
        Console.Write("Enter amount to withdraw: ");
        double amount = double.Parse(Console.ReadLine());

        if (amount <= balances[accountIndex])
        {
            balances[accountIndex] -= amount;
            LogTransaction(accountIndex, $"Withdrew {amount:C}");
            Console.WriteLine("Withdrawal successful!");
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }

    static void ListTransactions(int accountIndex)
    {
        Console.WriteLine($"Transaction history for account {accNumbers[accountIndex]}:");
        for (int i = 0; i < transactionCounts[accountIndex]; i++)
        {
            Console.WriteLine(logTransactions[accountIndex, i]);
        }
    }

    static void LogTransaction(int accountIndex, string message)
    {
        logTransactions[accountIndex, transactionCounts[accountIndex]] = message;
        transactionCounts[accountIndex]++;
    }

    static void ComputeInterest(int accountIndex)
    {
        double interestEarned = balances[accountIndex] * ratesOfInterest[accountIndex];
        Console.WriteLine($"Interest earned: {interestEarned:C}");
        balances[accountIndex] += interestEarned;
        LogTransaction(accountIndex, $"Interest of {interestEarned:C} applied");
        Console.WriteLine("Interest has been added to your balance.");
    }
}