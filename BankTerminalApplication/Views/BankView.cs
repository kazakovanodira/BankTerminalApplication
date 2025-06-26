using BankTerminalApplication.Controllers;

namespace BankTerminalApplication.Views;

public class BankView
{
    private readonly InputManager _inputManager = new();

    public void CreateAccount()
    {
        var accNum = BankController.Instance.CreateNewAccount(_inputManager.GetName());
        Console.WriteLine($"Account was created successfully.");
        Console.WriteLine($"Your account number is: {accNum}");
    }
}