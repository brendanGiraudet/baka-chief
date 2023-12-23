using bakaChiefApplication.Configurations;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Services.ProductInfosService;
using bakaChiefApplication.Services.RecipsService;

namespace bakaChiefApplication.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IRecipsService, RecipsService>();
            services.AddTransient<IProductInfosService, ProductInfosService>();
        }

        public static void AddNamedHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            var bakaChiefAPIConfig = new BakaChiefAPI();
            configuration.GetSection("BakaChiefAPI").Bind(bakaChiefAPIConfig);

            services.AddHttpClient(NameHttpClient.BakaChiefAPI, config =>
            {
                config.BaseAddress = new Uri(bakaChiefAPIConfig.BaseUrl);
                config.Timeout = TimeSpan.FromMinutes(5);
            });
        }

        public static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BakaChiefAPI>(options => configuration.GetSection(key: "BakaChiefAPI"));
        }
    }
}