using BankTerminalApplication.Models;

namespace BankTerminalApplication.Controllers;

public class AccountController
{
    private readonly BankController _bankController;
    private readonly Account? _account;

    public AccountController(Guid id)
    {
        _bankController = BankController.Instance;
        _account = _bankController.GetAccount(id);
    }
    
    public bool IsValidAccount() => _account is not null;

    public decimal GetBalance() => _account?.Balance ?? 0;

    public bool TryDeposit(decimal amount)
    {
        if (_account is null || amount < 0)
        {
            return false;
        }
        _account.Balance += amount;
        
        return true;
    }

    public bool TryWithdraw(decimal amount)
    {
        if (_account is null 
            || amount < 0 
            || _account.Balance < amount)
        {
            return false;
        }
        _account.Balance -= amount;
        
        return true;
    }

    public bool TryTransferMoney(Guid senderAccNum, Guid receiverAccNum, decimal amount)
    {
        var sender = _bankController.GetAccount(senderAccNum);
        var receiver = _bankController.GetAccount(receiverAccNum);
        if (sender is null 
            || receiver is null 
            || amount <= 0 
            || sender.Balance < amount)
        {
            return false;
        }
        sender.Balance -= amount;
        receiver.Balance += amount;
            
        return true;
    }
}