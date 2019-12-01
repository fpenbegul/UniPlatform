using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniPlatform.Startup))]
namespace UniPlatform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
