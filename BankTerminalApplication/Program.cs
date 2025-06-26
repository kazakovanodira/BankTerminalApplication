using BankTerminalApplication.Views;

namespace BankTerminalApplication;

public enum AccountOwner
{
    Your,
    Sender,
    Receiver
};


class Program
{
    public static void Main(String[] args)
    {
        var accountView  = new AccountView();
        var bankView = new BankView();
        
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
                    accountView.AttemptDeposit();
                    break;
                case 'c':
                    accountView.AttemptWithdraw();
                    break;
                case 'd':
                    accountView.DisplayBalance();
                    break;
                case 'e':
                    accountView.AttemptTransfer();
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