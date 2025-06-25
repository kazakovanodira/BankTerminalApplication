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
    
    public bool IsValidAccount()
    {
        return _account != null;
    }

    public decimal GetBalance()
    {
        return _account?.Balance ?? 0;
    }

    public bool TryDeposit(decimal amount)
    {
        if (_account == null || amount <= 0) return false;
        _account.Balance += amount;
        
        return true;
    }

    public bool TryWithdraw(decimal amount)
    {
        if (_account == null || amount <= 0 || _account.Balance < amount) return false;
        _account.Balance -= amount;
        
        return true;
    }

    public bool TryTransferMoney(Guid senderAccNum, Guid receiverAccNum, decimal amount)
    {
        Account? sender = _bankController.GetAccount(senderAccNum);
        Account? receiver = _bankController.GetAccount(receiverAccNum);
        if (sender == null || receiver == null || amount <= 0 || sender.Balance < amount) return false;
        sender.Balance -= amount;
        receiver.Balance += amount;
            
        return true;
    }
    
   
}