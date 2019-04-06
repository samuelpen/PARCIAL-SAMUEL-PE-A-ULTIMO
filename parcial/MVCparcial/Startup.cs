using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCparcial.Startup))]
namespace MVCparcial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
