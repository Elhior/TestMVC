using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UsersMVC.Startup))]
namespace UsersMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
