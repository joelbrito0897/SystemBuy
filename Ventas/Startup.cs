using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ventas.Startup))]
namespace Ventas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
