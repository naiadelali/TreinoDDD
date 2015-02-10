using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EstudoDDD.Mvc.Startup))]
namespace EstudoDDD.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
