using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(p2groep11.Net.Startup))]
namespace p2groep11.Net
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
