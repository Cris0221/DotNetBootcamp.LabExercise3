using System;

namespace CSharp.LabExercise3
{
    class BankAccount
    {
        public double accountCashBalance { get; set; }

        public BankAccount()
        {
            this.accountCashBalance = 0;
        }

    }

    class BankAccountCurrentBalance
    {
        BankAccount bankAccount;

        public BankAccountCurrentBalance(BankAccount bankAccount)
        {
            this.bankAccount = bankAccount;
        }

        public void PrintCurrentBalance()
        {
            Console.WriteLine($"Your current balance is: {bankAccount.accountCashBalance}");
        }
    }

    class BankAccountDepositor
    {
        BankAccount bankAccount;

        public BankAccountDepositor(BankAccount bankAccount)
        {
            this.bankAccount = bankAccount;
        }

        public void DepositCash()
        {
            Console.WriteLine(" ");
            Console.Write("Enter amount: ");
            double depositAmount = Convert.ToDouble(Console.ReadLine());
            bankAccount.accountCashBalance += depositAmount;

            if (depositAmount <= 0)
            {
                throw new ArgumentException("Please deposit a valid amount");
            }
        }
    }

    class BankAccountWithdrawer
    {
        BankAccount bankAccount;

        public BankAccountWithdrawer(BankAccount bankAccount)
        {
            this.bankAccount = bankAccount;
        }

        public void WithdrawCash()
        {
            Console.WriteLine(" ");
            Console.Write("Enter amount: ");
            int withdrawAmount = Convert.ToInt32(Console.ReadLine());
            bankAccount.accountCashBalance -= withdrawAmount;
            if (withdrawAmount < 0)
            {
                throw new ArgumentException("Enter a valid cash amount");
            }
            if (withdrawAmount % 100 != 0)
            {
                throw new ArgumentException("Amount must be a multiple of 100");
            }
            if (withdrawAmount > bankAccount.accountCashBalance)
            {
                throw new ArgumentException("insufficient balance");
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();
            BankAccountCurrentBalance bankAccountCurrentBalance = new BankAccountCurrentBalance(bankAccount);
            BankAccountWithdrawer bankAccountWithdrawer = new BankAccountWithdrawer(bankAccount);
            BankAccountDepositor bankAccountDepositor = new BankAccountDepositor(bankAccount);


            Console.WriteLine("-~-~-~-~-~--~-~-~-~-~--~-~-~-~-~--~-~-~- Welcome to the Automated Teller Machine -~-~-~--~-~-~-~-~--~-~-~-~-~--~-~-~-~-~");
            Console.WriteLine("\n\n");
            Console.WriteLine("[1] Check current balance ");
            Console.WriteLine("[2] Deposit cash");
            Console.WriteLine("[3] Withdraw cash");
            Console.WriteLine("[4] Quit");
            bool loop = true;
            while (loop)
            {
                Console.WriteLine(" ");
                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        bankAccountCurrentBalance.PrintCurrentBalance();
                        break;
                    case 2:
                        bankAccountDepositor.DepositCash();                       
                        break;
                    case 3:
                        bankAccountWithdrawer.WithdrawCash();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice!");
                        break;

                }
            }

        }
    }
}
