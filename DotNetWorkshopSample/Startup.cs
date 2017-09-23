using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetWorkshopSample.Startup))]
namespace DotNetWorkshopSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
