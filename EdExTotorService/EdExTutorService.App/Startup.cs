using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EdExTutorService.App.Startup))]
namespace EdExTutorService.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
