using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WestWindSystem.DAL;
using WestWindSystem.BLL;
#endregion

namespace WestWindSystem
{
    public static class BackendExtensions
    {
        public static void WWBackendDependencies(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            // Within this method, we will register all the services that will be used by the system (context setup)
            // and will be provided by the system

            // Setup the context service
            services.AddDbContext<WestWindContext>(options);

            // Register the service classes

            // Add any business logic layer class to the service collection so our web app has access to the methods (services)
            // within the BLL class

            // The argument for the AddTransient is called a factory
            // Basically what you are adding is a localize method
            services.AddTransient<BuildVersionServices>((serviceProvider) =>
            {
                // Get the dbcontext class that has been registered
                var context = serviceProvider.GetService<WestWindContext>();

                // Create an instance of the service class (BuildVersionServices) supplying
                // the context reference to the service class
                // Return the service class instance
                return new BuildVersionServices(context);
            });
        }
    }
}
