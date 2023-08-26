using bakaChiefApplication.Services.NutrimentTypeService;

namespace bakaChiefApplication.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<INutrimentTypeService, NutrimentTypeService>();
        }

        public static void AddNamedHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient("NutrimentTypeClient", config =>
            {
                config.BaseAddress = new Uri("https://localhost:7177");
            });
        }
    }
}
