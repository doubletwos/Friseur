using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Friseur.Startup))]
namespace Friseur
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
