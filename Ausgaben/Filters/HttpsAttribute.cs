namespace Ausgaben.Filters
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    internal sealed class HttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}