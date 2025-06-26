using BankTerminalApplication.Controllers;

namespace BankTerminalApplication.Views;

public class BankView
{
    UserInputController _userInputController = new();

    public void CreateAccount()
    {
        Guid accNum = BankController.Instance.CreateNewAccount(_userInputController.GetName());
        Console.WriteLine($"Account was created successfully.");
        Console.WriteLine($"Your account number is: {accNum}");
    }
}