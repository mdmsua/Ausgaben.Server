namespace Ausgaben.Models
{
    using System.Data.Entity;

    using Data;

    public class MobileServiceContext : DbContext
    {
        private const string connectionStringName = "Name=MS_TableConnectionString";

        public MobileServiceContext()
            : base(connectionStringName)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}