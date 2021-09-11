using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TodoWebFormSite.Startup))]
namespace TodoWebFormSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
        }
    }
}
