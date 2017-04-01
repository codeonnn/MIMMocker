using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MIMMocker.WebHost.Startup))]
namespace MIMMocker.WebHost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
