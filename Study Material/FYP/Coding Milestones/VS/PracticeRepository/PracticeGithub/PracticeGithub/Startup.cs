using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticeGithub.Startup))]
namespace PracticeGithub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
