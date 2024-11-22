using System;
using System.Windows;
using System.Windows.Controls;

namespace ATMApplication
{
    public partial class MainWindow : Window
    {
        private BankAccount _account;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Login Button Clicked
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            int accountNumber = int.Parse(AccountNumberTextBox.Text);
            string password = PasswordBox.Password;

            _account = new BankAccount(123456, "Curly Smith", 1000.00, "password1503"); 

            if (_account.VerifyCredentials(accountNumber, password))
            {
                StatusTextBlock.Text = "Login successful!";
                MainMenuPanel.Visibility = Visibility.Visible;
                LoginButton.IsEnabled = false;
                AccountNumberTextBox.IsEnabled = false;
                PasswordBox.IsEnabled = false;
            }
            else
            {
                StatusTextBlock.Text = "Invalid account number or password.";
            }
        }

        // View Bank Statement Button Clicked
        private void ViewStatementButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_account.GetBankStatement());
        }

        // Deposit Button Clicked
        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            double amount = double.Parse(DepositAmountTextBox.Text);
            _account.Deposit(amount);
        }

        // Withdraw Button Clicked
        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            double amount = double.Parse(WithdrawAmountTextBox.Text);
            _account.Withdraw(amount);
        }

        // View Transaction History Button Clicked
        private void TransactionHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            _account.DisplayTransactions();
        }

        // Exit Button Clicked
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you for using the ATM!");
            Close();
        }
    }

    public class BankAccount
    {
        public int AccountNumber { get; private set; }
        public string AccountHolderName { get; private set; }
        public double Balance { get; private set; }
        private string Password { get; set; }
        private List<string> Transactions { get; set; }

        public double InterestRate { get; private set; } = 0.03; // Default interest rate: 3%

        public BankAccount(int accountNumber, string accountHolderName, double initialBalance, string password)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = initialBalance;
            Password = password;
            Transactions = new List<string> { $"Account created with initial balance: ${initialBalance}" };
        }

        // Verify account number and password
        public bool VerifyCredentials(int accountNumber, string password)
        {
            return AccountNumber == accountNumber && Password == password;
        }

        public string GetBankStatement()
        {
            return $"Account Holder: {AccountHolderName}\n" +
                   $"Account Number: {AccountNumber}\n" +
                   $"Balance: ${Balance:F2}\n" +
                   $"Interest Rate: {InterestRate * 100}%";
        }

        // Deposit money
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Transactions.Add($"Deposited: ${amount:F2}");
                MessageBox.Show($"Deposit successful. Current Balance: ${Balance:F2}");
            }
            else
            {
                MessageBox.Show("Invalid deposit amount.");
            }
        }

        // Withdraw money
        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Transactions.Add($"Withdrew: ${amount:F2}");
                MessageBox.Show($"Withdrawal successful. Current Balance: ${Balance:F2}");
            }
            else
            {
                MessageBox.Show("Invalid withdrawal amount or insufficient funds.");
            }
        }

        // Display transaction history
        public void DisplayTransactions()
        {
            string transactionHistory = "\nTransaction History:\n";
            foreach (var transaction in Transactions)
            {
                transactionHistory += transaction + "\n";
            }
            MessageBox.Show(transactionHistory);
        }
    }
}
