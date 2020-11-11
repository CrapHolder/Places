using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(blessrng.Startup))]
namespace blessrng
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
