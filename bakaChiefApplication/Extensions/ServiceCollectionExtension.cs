using bakaChiefApplication.Constants;
using bakaChiefApplication.Services.IngredientService;
using bakaChiefApplication.Services.NutrimentTypeService;

namespace bakaChiefApplication.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<INutrimentTypeService, NutrimentTypeService>();
            services.AddTransient<IIngredientService, IngredientService>();
        }

        public static void AddNamedHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient(NameHttpClient.BakaChiefAPI, config =>
            {
                config.BaseAddress = new Uri("https://localhost:7177");
            });
        }
    }
}
