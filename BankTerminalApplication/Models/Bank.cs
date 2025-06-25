namespace BankTerminalApplication.Models;

public class Bank
{
    public Dictionary<Guid, Account> Accounts { get; } = new();
}