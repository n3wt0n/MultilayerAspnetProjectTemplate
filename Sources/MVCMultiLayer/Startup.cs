using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCMultiLayer.Startup))]
namespace MVCMultiLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
