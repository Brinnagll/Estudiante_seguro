using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admStudentSecurity1.Startup))]
namespace admStudentSecurity1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
