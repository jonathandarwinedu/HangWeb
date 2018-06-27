using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HangWeb.Startup))]
namespace HangWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
