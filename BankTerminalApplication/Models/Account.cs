namespace BankTerminalApplication.Models
{
    public enum AccountOwner
    {
        Your,
        Sender,
        Receiver
    };

    public class Account
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}