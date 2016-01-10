namespace Ausgaben.Data
{
    using Microsoft.Azure.Mobile.Server;

    public class AccountEntity : EntityData, IAccount
    {
        public decimal Balance { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string User { get; set; }
    }
}