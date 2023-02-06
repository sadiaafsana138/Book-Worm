using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookWorm.Startup))]
namespace BookWorm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
