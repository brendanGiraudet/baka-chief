using bakaChiefApplication.Constants;
using bakaChiefApplication.Services.IngredientsService;
using bakaChiefApplication.Services.NutrimentsService;
using bakaChiefApplication.Services.RecipsService;

namespace bakaChiefApplication.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<INutrimentsService, NutrimentsService>();
            services.AddTransient<IIngredientsService, IngredientsService>();
            services.AddTransient<IRecipsService, RecipsService>();
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
