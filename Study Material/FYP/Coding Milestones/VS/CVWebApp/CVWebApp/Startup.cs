using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CVWebApp.Startup))]
namespace CVWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
