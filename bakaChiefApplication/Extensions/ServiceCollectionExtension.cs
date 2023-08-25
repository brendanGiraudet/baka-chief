using bakaChiefApplication.Services.NutrimentTypeService;

namespace bakaChiefApplication.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<INutrimentTypeService, NutrimentTypeService>();
        }
    }
}
