using Bl.BLApi;
using Bl.BLServices;
using Dal;
using Dal.Api;
using Microsoft.Extensions.DependencyInjection;

namespace Bl
{
    public class BlManager : IBl
    {
        public BlVolunteeringInterface Volunteerings { get; }
        public BlVolunteerInterface Volunteer { get; }
        public BlVolunteerDomainInterface VolunteerDomains { get; }
        public BlEichudInterface Eichud { get; }
        public BlSubProjectInterface SubProject  { get; }


        public BlManager()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDal, DalManager>();
            services.AddSingleton<BlVolunteerInterface, BLVolunteerService>();
            services.AddSingleton<BlEichudInterface, BlEichudService>();
            services.AddSingleton<BlVolunteeringInterface, BlVolunteeringService>();
            services.AddSingleton<BlVolunteerDomainInterface, BlVolunteerDomainService>();




            ServiceProvider service = services.BuildServiceProvider();
            Volunteer = service.GetRequiredService<BlVolunteerInterface>();
            Volunteerings= service.GetRequiredService<BlVolunteeringInterface>();
            Eichud = service.GetRequiredService<BlEichudInterface>();
            VolunteerDomains = service.GetRequiredService<BlVolunteerDomainInterface>();
            SubProject = service.GetRequiredService<BlSubProjectInterface>();
        }
    }
}
