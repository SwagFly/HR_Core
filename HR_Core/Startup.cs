using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HR_Core.Startup))]
namespace HR_Core
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
