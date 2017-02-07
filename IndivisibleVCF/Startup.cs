using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndivisibleVCF.Startup))]
namespace IndivisibleVCF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
