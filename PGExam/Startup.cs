using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DesignTemplate1.Startup))]
namespace DesignTemplate1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
