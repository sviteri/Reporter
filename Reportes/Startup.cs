using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reportes.Startup))]
namespace Reportes
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
