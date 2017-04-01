using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jsontree.Startup))]
namespace Jsontree
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
