using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;

namespace Ausgaben.Models
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration;
    using System.Net.Http;

    using Ausgaben.Data;

    public class MobileServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        //
        // To enable Entity Framework migrations in the cloud, please ensure that the 
        // service name, set by the 'MS_MobileServiceName' AppSettings in the local 
        // Web.config, is the same as the service name when hosted in Azure.

        private const string connectionStringName = "Name=MS_TableConnectionString";

        public MobileServiceContext() : base(connectionStringName)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Add(
            //    new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
            //        "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
            //modelBuilder.Entity<Account>().ToTable("Accounts");
            //modelBuilder.Types<TableData>().Configure(x => x.Property(y => y.Id).HasColumnType("uniqueidentifier"));
            //modelBuilder.Types<TableData>().Configure(x => x.Property(y => y.Id).HasColumnType("bigint"));
            //modelBuilder.Types<TableData>().Configure(y => y.Property(a => a.Id).HasColumnType("varchar"));
        }

        
    }
    
}
