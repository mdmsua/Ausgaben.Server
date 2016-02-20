namespace Ausgaben.Models
{
    using System.Data.Common;
    using System.Data.Entity.Infrastructure.Interception;
    using System.Security.Claims;
    using System.Threading;

    using Microsoft.Azure.Mobile.Server.Authentication;

    public class SessionContextCommandInterceptor : IDbCommandInterceptor
    {
        private readonly IAppServiceTokenHandler tokenHandler;

        public SessionContextCommandInterceptor(IAppServiceTokenHandler tokenHandler)
        {
            this.tokenHandler = tokenHandler;
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            var claimsIdentity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            if (claimsIdentity == null)
            {
                return;
            }

            var id = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var provider = claimsIdentity.FindFirst("http://schemas.microsoft.com/identity/claims/identityprovider");
            if (id == null || provider == null)
            {
                return;
            }

            var user = this.tokenHandler.CreateUserId(provider.Value, id.Value);
            using (var cmd = command.Connection.CreateCommand())
            {
                cmd.Transaction = command.Transaction;
                cmd.CommandText = $"exec sp_set_session_context 'User', '{user}'";
                cmd.ExecuteNonQuery();
            }
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
        }
    }
}