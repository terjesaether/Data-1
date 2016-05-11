using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Data_1.Startup))]
namespace Data_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
