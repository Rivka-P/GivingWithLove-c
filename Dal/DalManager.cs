using Dal.Api;
using Dal.Models;
using Dal.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Security.Authentication.ExtendedProtection;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalManager:IDal
    {
        public DalVolunteeringInterface Volunteerings { get; }
        public DalVolunteerInterface Volunteer { get; }
        public DalEichudInterface Eichud { get; }
        public DalVolunteerDomainInterface VolunteerDomains { get; }
        public DalSubProjectInterface SubProject { get; }
        public DalPositionInterface Position { get; }
        public DalProjectInterface Project   { get; }

        public DalManager()
        {
            //ServiceCollection services = new ServiceCollection();
            //services.AddSingleton<DbManager>();
            //services.AddSingleton<ICustomer, CustomerService>();
            //services.AddSingleton<ICategory, CategoryService>();
            //services.AddSingleton<ICities, CitiesService>();

            //ServiceProvider serviceP = services.BuildServiceProvider();
            //Customer = serviceP.GetRequiredService<ICustomer>();
            //Category = serviceP.GetRequiredService<ICategory>();
            //cities = serviceP.GetRequiredService<ICities>();


            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<DbManager>();
            services.AddSingleton<DalVolunteeringInterface, DalVolunteeringService>();
            services.AddSingleton<DalVolunteerInterface, DalVolunteerService>();
            services.AddSingleton<DalEichudInterface, DalEichudService>();
            services.AddSingleton<DalVolunteerDomainInterface, DalVolunteerDomainService>();
            services.AddSingleton<DalSubProjectInterface, DalSubProjectService>();
            services.AddSingleton<DalPositionInterface, DalPositionService>();
            services.AddSingleton<DalProjectInterface, DalProjectService>();
            ServiceProvider servicesProvider = services.BuildServiceProvider();

            Volunteerings = servicesProvider.GetRequiredService<DalVolunteeringInterface>();
            Volunteer = servicesProvider.GetRequiredService<DalVolunteerInterface>();
            Eichud = servicesProvider.GetRequiredService<DalEichudInterface>();
            VolunteerDomains = servicesProvider.GetRequiredService<DalVolunteerDomainInterface>();
            SubProject = servicesProvider.GetRequiredService<DalSubProjectInterface>();
            Position = servicesProvider.GetRequiredService<DalPositionInterface>();
            Project = servicesProvider.GetRequiredService<DalProjectInterface>();
        }
    }
}
