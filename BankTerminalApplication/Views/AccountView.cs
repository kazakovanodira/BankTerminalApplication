using System.Runtime.CompilerServices;
using BankTerminalApplication.Controllers;

namespace BankTerminalApplication.Views;

public class AccountView
{
    UserInputController _userInputController = new();
    
    public void AttemptDeposit()
    {
        Guid accountNumber = _userInputController.GetAccountNumber("your");
        AccountController currentAccController = new AccountController(accountNumber);

        if (!currentAccController.IsValidAccount())
        {
            Console.WriteLine("Invalid account number");
            return;
        }
        
        decimal depositAmount = _userInputController.GetAmount();
        if (currentAccController.TryDeposit(depositAmount)) DepositSuccess();
        else DepositFail();
        
    }

    public void DepositSuccess()
    {
        Console.WriteLine("Money successfully deposited.");
    }

    public void DepositFail()
    {
        Console.WriteLine("Money failed to deposit.");
    }

    public void AttemptWithdraw()
    {
        Guid accountNumber = _userInputController.GetAccountNumber("your");
        AccountController currentAccController = new AccountController(accountNumber);
        
        if (!currentAccController.IsValidAccount())
        {
            Console.WriteLine("Invalid account number");
            return;
        }
        
        decimal withdrawAmount = _userInputController.GetAmount();
        if (currentAccController.TryWithdraw(withdrawAmount)) WithdrawSuccess();
        else WithdrawFail();
    }

    public void WithdrawSuccess()
    {
        Console.WriteLine("Money successfully withdrawn.");
    }

    public void WithdrawFail()
    {
        Console.WriteLine("Money failed to withdraw.");
    }

    public void AttemptTransfer()
    {
        Guid senderAccNum = _userInputController.GetAccountNumber("sender's");
        AccountController senderAccController = new AccountController(senderAccNum);

        if (!senderAccController.IsValidAccount())
        {
            Console.WriteLine("Invalid account number");
            return;
        }
        
        Guid receiverAccNum = _userInputController.GetAccountNumber("receiver's");
        AccountController reveiverAccController = new AccountController(senderAccNum);

        if (!reveiverAccController.IsValidAccount())
        {
            Console.WriteLine("Invalid account number");
            return;
        }
        
        decimal amount = _userInputController.GetAmount();
        if (senderAccController.TryTransferMoney(senderAccNum, receiverAccNum, amount)) TransferSuccess();
        else TransferFail();
    }

    public void TransferSuccess()
    {
        Console.WriteLine("Money transferred successfully.");
    }

    public void TransferFail()
    {
        Console.WriteLine("Money failed to transfer.");
    }

    public void DisplayBalance()
    {
        Guid accountNumber = _userInputController.GetAccountNumber("your");
        AccountController currentAccController = new AccountController(accountNumber);
        
        if (!currentAccController.IsValidAccount())
        {
            Console.WriteLine("Invalid account number");
            return;
        }
        
        Console.WriteLine($"Your current balance is: {currentAccController.GetBalance()}");
    }
}