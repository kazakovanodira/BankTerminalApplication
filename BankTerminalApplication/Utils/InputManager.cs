using BankTerminalApplication.Models;
using System.Text.RegularExpressions;

namespace BankTerminalApplication.Utils;

public class InputManager
{
    public decimal GetAmount()
    {
        while (true)
        {
            Console.Write("Enter transaction amount: ");
            var input = Console.ReadLine();
            Regex regex = new Regex(@"^\d+\.\d{2}$"); 
            
            if (decimal.TryParse(input, out var amount) 
                && regex.IsMatch(input)
                && amount >= 0)
            {
                return amount;
            }

            Console.WriteLine("Invalid amount. Please enter a valid positive amount.");
        }
    }

    public string GetName()
    {
        while (true)
        {
            Console.Write("Enter account holder's name: ");
            var name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                return name.Trim();
            }

            Console.WriteLine("Name cannot be empty or just spaces. Please enter a valid name.");
        }
    }

    public bool TryGetAccountNumber(AccountOwner owner, out Guid accountNumber)
    {
        Console.WriteLine($"Enter {owner} account number: ");
        var input = Console.ReadLine();
        
        if (Guid.TryParse(input, out var id))
        {
            accountNumber = id;
            return true;
        }
        accountNumber = default;

        return false;
    }
}