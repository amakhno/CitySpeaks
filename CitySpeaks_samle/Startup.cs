using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CitySpeaks_samle.Startup))]
namespace CitySpeaks_samle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
