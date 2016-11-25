using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Crm_v10.Startup))]
namespace Crm_v10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
