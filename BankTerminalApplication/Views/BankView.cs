using BankTerminalApplication.Controllers;
using BankTerminalApplication.Utils;

namespace BankTerminalApplication.Views;

public class BankView
{
    private readonly BankController _bankController;
    private readonly InputManager _inputManager = new();

    public BankView(BankController bankController)
    {
        _bankController = bankController;
    }

    public void CreateAccount()
    {
        var accNum = _bankController.CreateNewAccount(_inputManager.GetName());
        Console.WriteLine($"Account was created successfully.");
        Console.WriteLine($"Your account number is: {accNum}");
    }
}