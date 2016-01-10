namespace Ausgaben.Data
{
    public interface IAccount
    {
        decimal Balance { get; set; }

        string Description { get; set; }

        string Name { get; set; }

        string User { get; set; }
    }
}