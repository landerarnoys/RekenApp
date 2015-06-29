using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wiskunde_App.Startup))]
namespace Wiskunde_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
