using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleHomepage.Startup))]
namespace SampleHomepage
{
    public partial class Startup
    {
   
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }

    public interface IServiceCollection
    {
    }
}
