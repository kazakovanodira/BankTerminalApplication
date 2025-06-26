namespace BankTerminalApplication;

public class InputManager
{
    public decimal GetAmount()
    {
        while (true)
        {
            Console.Write("Enter transaction amount: ");
            var input = Console.ReadLine();

            if (decimal.TryParse(input, out var amount) && amount >= 0)
            {
                return amount;
            }

            Console.WriteLine("Invalid amount. Please enter a valid positive number.");
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

    public bool TryGetAccountNumber(string owner, out Guid accountNumber)
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