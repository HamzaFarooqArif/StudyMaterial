using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IbmAdmissions2019.Startup))]
namespace IbmAdmissions2019
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
