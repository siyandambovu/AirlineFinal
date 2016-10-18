using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Air_Line_Flight.Startup))]
namespace Air_Line_Flight
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
