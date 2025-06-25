using BankTerminalApplication.Controllers;

namespace BankTerminalApplication.Views;

public class BankView
{
    UserInputController _userInputController = new();
    
    public char PickTransaction()
    {
        Console.WriteLine("Menu:\n     a. Create Account\n     b. Deposit\n     c. Withdraw\n     d. Check Balance\n     e. Transfer Funds\n     f. Exit\n \n"); 
        char userChoice = Console.ReadKey().KeyChar;
        Console.WriteLine();
        return userChoice;
    }

    public void CreateAccount()
    {
        Guid accNum = BankController.Instance.CreateNewAccount(_userInputController.GetName());
        Console.WriteLine($"Account was created successfully.");
        Console.WriteLine($"Your account number is: {accNum}");
    }
}