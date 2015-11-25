using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ICEMS_WebManagement.Startup))]
namespace ICEMS_WebManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
