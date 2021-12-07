using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompendiumIdentity.Startup))]
namespace CompendiumIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
