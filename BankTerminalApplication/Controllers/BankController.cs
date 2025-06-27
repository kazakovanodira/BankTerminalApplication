using BankTerminalApplication.Models;
using BankTerminalApplication.Utils;

namespace BankTerminalApplication.Controllers;

public class BankController
{
    private readonly Bank _bank = new();
    
    public Guid CreateNewAccount(string name)
    {
        var id = Guid.NewGuid();
        var account = new Account { Name = name };
        _bank.Accounts.Add(id, account);
        
        return id;
    }

    public Account? GetAccount(Guid id)
    {
        if (_bank.Accounts.TryGetValue(id, out var account))
        {
            return account;
        }
        
        return null;
    }
}