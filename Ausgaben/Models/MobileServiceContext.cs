namespace Ausgaben.Models
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Interception;
    using System.Web.Http;

    using Ausgaben.Data;

    public class MobileServiceContext : DbContext
    {
        private const string ConnectionStringName = "Name=MS_TableConnectionString";

        public MobileServiceContext(HttpConfiguration configuration)
            : base(ConnectionStringName)
        {
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<MobileServiceContext>(null);
            DbInterception.Add(new SessionContextCommandInterceptor(configuration.GetAppServiceTokenHandler()));
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}