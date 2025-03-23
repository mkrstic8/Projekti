using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MilanKrstic.Startup))]
namespace MilanKrstic
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
