using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lr6.Startup))]
namespace lr6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
