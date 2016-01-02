namespace Ausgaben.Data
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.OData;

    using Microsoft.Azure.Mobile.Server;
    using Microsoft.Azure.Mobile.Server.Tables;

    public class GuidMappedEntityDomainManager<TData, TModel> : MappedEntityDomainManager<TData, TModel>
        where TData : class, ITableData where TModel : class, ITableEntity
    {
        public GuidMappedEntityDomainManager(DbContext context, HttpRequestMessage request)
            : base(context, request)
        {
        }

        public GuidMappedEntityDomainManager(DbContext context, HttpRequestMessage request, bool enableSoftDelete)
            : base(context, request, enableSoftDelete)
        {
        }
        
        public override Task<bool> DeleteAsync(string id)
        {
            var guid = Mappers.ToGuid(id);
            return this.DeleteItemAsync(guid);
        }

        public override SingleResult<TData> Lookup(string id)
        {
            var guid = Mappers.ToGuid(id);
            return this.LookupEntity(x => x.Id == guid, false);
        }

        public override Task<TData> UpdateAsync(string id, Delta<TData> patch)
        {
            var guid = Mappers.ToGuid(id);
            return this.UpdateEntityAsync(patch, guid);
        }
    }
}