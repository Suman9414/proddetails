using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Productdetails.Startup))]
namespace Productdetails
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
