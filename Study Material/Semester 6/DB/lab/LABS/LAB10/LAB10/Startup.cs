using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LAB10.Startup))]
namespace LAB10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
