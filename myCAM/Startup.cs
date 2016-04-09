using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(myCAM.Startup))]
namespace myCAM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
