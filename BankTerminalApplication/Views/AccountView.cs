using System.Runtime.CompilerServices;
using BankTerminalApplication.Controllers;

namespace BankTerminalApplication.Views;

public class AccountView
{
    UserInputController _userInputController = new();
    
    public char PickTransaction()
    {
        Console.WriteLine("Menu:\n     a. Create Account\n     b. Deposit\n     c. Withdraw\n     d. Check Balance\n     e. Transfer Funds\n     f. Exit\n \n"); 
        char userChoice = Console.ReadKey().KeyChar;
        Console.WriteLine();
        return userChoice;
    }
    
    public void AttemptDeposit()
    {
        if (_userInputController.TryGetAccountNumber("your", out Guid id))
        {
            Guid accountNumber = id;
            AccountController currentAccController = new AccountController(accountNumber);
            
            if (!currentAccController.IsValidAccount())
            {
                Console.WriteLine("Invalid account number");
                return;
            }
        
            decimal depositAmount = _userInputController.GetAmount();

            if (depositAmount == 0)
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
        if (_userInputController.TryGetAccountNumber("your", out Guid id))
        {
            Guid accountNumber = id;
            AccountController currentAccController = new AccountController(accountNumber);
            
            if (!currentAccController.IsValidAccount())
            {
                Console.WriteLine("Invalid account number");
                return;
            }
        
            decimal withdrawAmount = _userInputController.GetAmount();
        
            if (withdrawAmount == 0)
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
        if (_userInputController.TryGetAccountNumber("sender's", out Guid senderID))
        {
            Guid senderAccNum = senderID;
            AccountController senderAccController = new AccountController(senderAccNum);

            if (!senderAccController.IsValidAccount())
            {
                Console.WriteLine("Invalid account number");
                return;
            }

            if (_userInputController.TryGetAccountNumber("receiver's", out Guid receiverID))
            {
                Guid receiverAccNum = receiverID;
                AccountController reveiverAccController = new AccountController(senderAccNum);

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
                decimal amount = _userInputController.GetAmount();
        
                if (amount == 0)
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
        if (_userInputController.TryGetAccountNumber("your", out Guid id))
        {
            Guid accountNumber = id;
            AccountController currentAccController = new AccountController(accountNumber);
        
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