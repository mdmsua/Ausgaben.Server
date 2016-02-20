namespace Ausgaben.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Ausgaben.Data;
    using Ausgaben.Models;

    using Microsoft.Azure.Mobile.Server.Config;

    [MobileAppController]
    [AllowAnonymous]
    public class CategoriesController : ApiController
    {
        // GET api/Category
        public async Task<List<Category>> Get()
        {
            List<Category> categories;
            using (var context = new MobileServiceContext(this.Configuration))
            {
                categories = await context.Categories.ToListAsync().ConfigureAwait(false);
            }

            return categories.Where(c => c.Parent == null).ToList();
        }
    }
}