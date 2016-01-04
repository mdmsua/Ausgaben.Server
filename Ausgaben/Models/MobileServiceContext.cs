namespace Ausgaben.Models
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Interception;
    using System.Web.Http;

    using Data;

    public class MobileServiceContext : DbContext
    {
        private const string ConnectionStringName = "Name=MS_TableConnectionString";

        public MobileServiceContext(HttpConfiguration configuration)
            : base(ConnectionStringName)
        {
            DbInterception.Add(new SessionContextCommandInterceptor(configuration.GetAppServiceTokenHandler()));
        }

        public DbSet<Account> Accounts { get; set; }
    }
}