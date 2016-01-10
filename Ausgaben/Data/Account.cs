namespace Ausgaben.Data
{
    public class Account : TableEntity, IAccount
    {
        public decimal Balance { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string User { get; set; }
    }
}