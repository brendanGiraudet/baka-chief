using bakaChiefApplication.Repositories;
using bakaChiefApplication.Repositories.NutrimentTypeRepository;
using bakaChiefApplication.Services.NutrimentTypeService;
using bakaChiefApplication.ViewModels.NutrimentTypeViewModel;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<INutrimentTypeRepository, NutrimentTypeRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<INutrimentTypeService, NutrimentTypeService>();
        }

        public static void AddViewModels(this IServiceCollection services)
        {
            services.AddTransient<INutrimentTypeViewModel, NutrimentTypeViewModel>();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            Console.WriteLine($"cccc {connectionString}");
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlite(connectionString));
        }
    }
}
