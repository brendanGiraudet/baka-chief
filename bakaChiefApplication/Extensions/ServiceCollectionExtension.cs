﻿using bakaChiefApplication.Configurations;
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
            services.AddTransient<IIngredientsService, IngredientsService >();
            services.AddTransient<IRecipsService, RecipsService >();
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