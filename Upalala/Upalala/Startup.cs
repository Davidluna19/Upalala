using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Upalala.Startup))]
namespace Upalala
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
