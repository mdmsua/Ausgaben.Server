namespace Ausgaben.Data
{
    public class Account : TableEntity, IAccount
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public string User { get; set; }
    }
}