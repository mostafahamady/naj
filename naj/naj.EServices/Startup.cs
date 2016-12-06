using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Naj.EServices.Startup))]
namespace Naj.EServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
