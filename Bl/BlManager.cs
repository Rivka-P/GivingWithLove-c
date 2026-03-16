using Bl.BLApi;
using Bl.BLServices;
using Dal;
using Dal.Api;
using Dal.Models;
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
        public BlPositionInterface Position {  get; }
        
        public BlProjectInterface Project  { get; }
        


        public BlManager()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDal, DalManager>();
            services.AddSingleton<BlVolunteerInterface, BLVolunteerService>();
            services.AddSingleton<BlEichudInterface, BlEichudService>();
            services.AddSingleton<BlVolunteeringInterface, BlVolunteeringService>();
<<<<<<< HEAD
            services.AddSingleton<BlVolunteerDomainInterface, BlVolunteerDomainService>();
            services.AddSingleton<BlSubProjectInterface, BlSubProjectService>();
=======
            services.AddSingleton<BlVolunteerDomainInterface, BlVolunteerDomainService>();
            services.AddSingleton<BlSubProjectInterface, BlSubProjectService>();
            services.AddSingleton<BlProjectInterface, BlProjectService>();
            services.AddSingleton<BlPositionInterface , BlPositionService>();
>>>>>>> refs/remotes/origin/main




            ServiceProvider service = services.BuildServiceProvider();
            Volunteer = service.GetRequiredService<BlVolunteerInterface>();
            Volunteerings= service.GetRequiredService<BlVolunteeringInterface>();
            Eichud = service.GetRequiredService<BlEichudInterface>();
            VolunteerDomains = service.GetRequiredService<BlVolunteerDomainInterface>();
            SubProject = service.GetRequiredService<BlSubProjectInterface>();
            Project = service.GetRequiredService<BlProjectInterface>();
            Position = service.GetRequiredService<BlPositionInterface>();
        }
    }
}
