using System.Security.Cryptography.X509Certificates;
using BankTerminalApplication.Controllers;
using BankTerminalApplication.Views;
using BankTerminalApplication.Models;


namespace BankTerminalApplication;

class Program
{
    public static void Main(String[] args)
    {
        BankController  bankController = new BankController();
        var accountView  = new AccountView();
        var bankView = new BankView(bankController);
        
        char userChoice;
        
        do
        {
            userChoice = accountView.PickTransaction();
            switch (userChoice)
            {
                case 'a':
                    bankView.CreateAccount();
                    break;
                case 'b':
                    accountView.AttemptDeposit(bankController);
                    break;
                case 'c':
                    accountView.AttemptWithdraw(bankController);
                    break;
                case 'd':
                    accountView.DisplayBalance(bankController);
                    break;
                case 'e':
                    accountView.AttemptTransfer(bankController);
                    break;
                case 'f':
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            
        } while  (userChoice != 'f');
    }
}