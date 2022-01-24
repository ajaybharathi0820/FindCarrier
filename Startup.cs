using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FindCarrier.Startup))]
namespace FindCarrier
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
