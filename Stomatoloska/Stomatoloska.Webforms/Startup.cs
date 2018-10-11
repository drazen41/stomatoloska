using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stomatoloska.Webforms.Startup))]
namespace Stomatoloska.Webforms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
