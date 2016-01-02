using Microsoft.Owin;

[assembly: OwinStartup(typeof(Ausgaben.Startup))]

namespace Ausgaben
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}