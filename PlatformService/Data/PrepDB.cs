using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDBContext>());
            }
        }

        private static void SeedData(AppDBContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding the data");
                context.Platforms.AddRange(
                    new Platform() {Name = "Dotnet", Publisher = "Microsoft", Cost = "free"}
                );

                context.SaveChanges();
            } else 
            {
                Console.WriteLine("--> Already have data, no need to seed!");
            }
        }
    }
}