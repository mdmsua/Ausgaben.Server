namespace Ausgaben.Data
{
    using Microsoft.Azure.Mobile.Server;

    public class AccountEntity : EntityData, IAccount
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public string User { get; set; }
    }
}