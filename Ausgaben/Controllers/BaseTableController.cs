namespace Ausgaben.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.OData;

    using Ausgaben.Data;
    using Ausgaben.Models;

    using Microsoft.Azure.Mobile.Server;
    using Microsoft.Azure.Mobile.Server.Tables;

    public abstract class BaseTableController<TData, TModel> : TableController<TData>
        where TData : class, ITableData where TModel : class, ITableEntity
    {
        [HttpGet]
        public virtual IQueryable<TData> All()
        {
            return this.Query();
        }

        public virtual Task Delete(string id)
        {
            return this.DeleteAsync(id);
        }

        public virtual SingleResult<TData> Get(string id)
        {
            return this.Lookup(id);
        }

        public virtual Task<TData> Patch(string id, Delta<TData> patch)
        {
            return this.UpdateAsync(id, patch);
        }

        public virtual async Task<IHttpActionResult> Post(TData item)
        {
            TData current = await this.InsertAsync(item);
            return this.CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            var context = new MobileServiceContext(this.Configuration);
            this.DomainManager = new GuidMappedEntityDomainManager<TData, TModel>(context, this.Request, true);
        }
    }
}