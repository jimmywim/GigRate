using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GigRate.Startup))]
namespace GigRate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
