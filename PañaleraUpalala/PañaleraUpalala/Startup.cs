using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PañaleraUpalala.Startup))]
namespace PañaleraUpalala
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
