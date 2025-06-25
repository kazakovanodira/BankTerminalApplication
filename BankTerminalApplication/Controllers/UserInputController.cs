namespace BankTerminalApplication;

public class UserInputController
{
    public decimal GetAmount()
    {
        while (true)
        {
            Console.Write("Enter transaction amount: ");
            string? input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal amount) && amount > 0)
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
            string? name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                return name.Trim();
            }

            Console.WriteLine("Name cannot be empty or just spaces. Please enter a valid name.");
        }
    }

    public Guid GetAccountNumber(string owner)
    {
        Guid id;
        Console.WriteLine($"Enter {owner} account number: ");
        string accountNumber = Console.ReadLine();
        if (Guid.TryParse(accountNumber, out id))
            return id;
        Console.WriteLine("Invalid GUID format.");
        return Guid.Empty;
    }
}