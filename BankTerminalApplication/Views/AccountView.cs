using System.Runtime.CompilerServices;
using BankTerminalApplication.Controllers;
using BankTerminalApplication.Utils;
using BankTerminalApplication.Models;

namespace BankTerminalApplication.Views;

public class AccountView
{
    private readonly InputManager _inputManager = new();
    
    public char PickTransaction()
    {
        Console.WriteLine("Menu:\n     a. Create Account\n     b. Deposit\n     c. Withdraw\n     d. Check Balance\n     e. Transfer Funds\n     f. Exit\n \n"); 
        var userChoice = Console.ReadKey().KeyChar;
        Console.WriteLine();
        return userChoice;
    }
    
    public void AttemptDeposit(BankController bankController)
    {
        if (_inputManager.TryGetAccountNumber(AccountOwner.Your, out var id))
        {
            var accountNumber = id;
            var currentAccController = new AccountController(accountNumber, bankController);
            
            if (!currentAccController.IsValidAccount())
            {
                Console.WriteLine("Invalid account number");
                return;
            }
        
            var depositAmount = _inputManager.GetAmount();

            if (depositAmount is 0)
            {
                Console.WriteLine("Transaction cancelled.");
                Console.WriteLine($"Your current balance is: ${currentAccController.GetBalance()}");

                return;
            }
        
            if (currentAccController.TryDeposit(depositAmount))
            {
                DepositSuccess();
                Console.WriteLine($"Your current balance is: ${currentAccController.GetBalance()}");
            }
            else
            {
                DepositFail();
                Console.WriteLine($"Your current balance is: ${currentAccController.GetBalance()}");
            }
        }
        else
        {
            Console.WriteLine("Invalid account number.");
        }
    }

    public void DepositSuccess() => Console.WriteLine("Money successfully deposited.");
    
    public void DepositFail() => Console.WriteLine("Money failed to deposit.");

    public void AttemptWithdraw(BankController bankController)
    {
        if (_inputManager.TryGetAccountNumber(AccountOwner.Your, out var id))
        {
            var accountNumber = id;
            var currentAccController = new AccountController(accountNumber, bankController);
            
            if (!currentAccController.IsValidAccount())
            {
                Console.WriteLine("Invalid account number");
                return;
            }
        
            var withdrawAmount = _inputManager.GetAmount();
        
            if (withdrawAmount is 0)
            {
                Console.WriteLine("Transaction cancelled.");
                Console.WriteLine($"Your current balance is: ${currentAccController.GetBalance()}");

                return;
            }
        
            if (currentAccController.TryWithdraw(withdrawAmount))
            {
                WithdrawSuccess();
                Console.WriteLine($"Your current balance is: ${currentAccController.GetBalance()}");
            }
            else
            {
                WithdrawFail();
                Console.WriteLine($"Your current balance is: ${currentAccController.GetBalance()}");
            }
        }
        else
        {
            Console.WriteLine("Invalid account number.");
        }
    }

    public void WithdrawSuccess() => Console.WriteLine("Money successfully withdrawn.");

    public void WithdrawFail() => Console.WriteLine("Money failed to withdraw.");
    
    public void AttemptTransfer(BankController bankController)
    {
        if (_inputManager.TryGetAccountNumber(AccountOwner.Sender, out var senderID))
        {
            var senderAccNum = senderID;
            var senderAccController = new AccountController(senderAccNum, bankController);

            if (!senderAccController.IsValidAccount())
            {
                Console.WriteLine("Invalid account number");
                return;
            }

            if (_inputManager.TryGetAccountNumber(AccountOwner.Receiver, out var receiverID))
            {
                var receiverAccNum = receiverID;
                var reveiverAccController = new AccountController(senderAccNum, bankController);

                if (!reveiverAccController.IsValidAccount())
                {
                    Console.WriteLine("Invalid account number");
                    return;
                }

                if (receiverAccNum == senderAccNum)
                {
                    Console.WriteLine("Invalid transaction.");
                    return;
                }
                var amount = _inputManager.GetAmount();
        
                if (amount is 0)
                {
                    Console.WriteLine("Transaction cancelled.");

                    return;
                }
        
                if (senderAccController.TryTransferMoney(senderAccNum, receiverAccNum, amount))
                {
                    TransferSuccess();
                }
                else
                {
                    TransferFail();
                }
            }
            else
            {
                Console.WriteLine("Invalid account number");
                return;
            }
        }
        else
        {
            Console.WriteLine("Invalid account number");
        }
    }

    public void TransferSuccess() => Console.WriteLine("Money transferred successfully.");

    public void TransferFail() => Console.WriteLine("Money failed to transfer.");

    public void DisplayBalance(BankController bankController)
    {
        if (_inputManager.TryGetAccountNumber(AccountOwner.Your, out var id))
        {
            var accountNumber = id;
            var currentAccController = new AccountController(accountNumber, bankController);
        
            if (!currentAccController.IsValidAccount())
            {
                Console.WriteLine("Invalid account number.");
                return;
            }
        
            Console.WriteLine($"Your current balance is: ${currentAccController.GetBalance()}");
        }
        else
        {
            Console.WriteLine("Invalid account number.");
        }
    }
}