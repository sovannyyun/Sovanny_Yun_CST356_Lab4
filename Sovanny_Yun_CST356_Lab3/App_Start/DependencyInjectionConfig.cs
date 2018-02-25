using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using SimpleInjector;
using Sovanny_Yun_CST356_Lab3.Data;
using Sovanny_Yun_CST356_Lab3.Repository;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Sovanny_Yun_CST356_Lab3.Services;

namespace Sovanny_Yun_CST356_Lab3.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void Register()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<IMajorRepository, MajorRepository>(Lifestyle.Scoped);
            container.Register<IMajorService, MajorService>(Lifestyle.Scoped);
            container.Register<AppDbContext, AppDbContext>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}