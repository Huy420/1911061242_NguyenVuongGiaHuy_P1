using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(part1.Startup))]
namespace part1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
