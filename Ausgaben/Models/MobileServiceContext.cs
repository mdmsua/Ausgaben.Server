namespace Ausgaben.Models
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Interception;
    using System.Web.Http;

    using Ausgaben.Data;

    public class MobileServiceContext : DbContext
    {
        private const string ConnectionStringName = "Name=MS_TableConnectionString";

        private const string Schema = "dbo";

        public MobileServiceContext(HttpConfiguration configuration)
            : base(ConnectionStringName)
        {
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<MobileServiceContext>(null);
            DbInterception.Add(new SessionContextCommandInterceptor(configuration.GetAppServiceTokenHandler()));
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().MapToStoredProcedures(
                procedures =>
                    {
                        procedures.Insert(procedure => procedure.HasName("InsertAccount", Schema));
                        procedures.Update(procedure => procedure.HasName("UpdateAccount", Schema));
                    });
            modelBuilder.Entity<Payment>().MapToStoredProcedures(
                procedures =>
                    {
                        procedures.Insert(procedure => procedure.HasName("InsertPayment", Schema));
                        procedures.Update(procedure => procedure.HasName("UpdatePayment", Schema));
                    });
        }
    }
}