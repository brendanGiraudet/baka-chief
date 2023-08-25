using bakaChiefApplication;
using bakaChiefApplication.Extensions;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddServices();

// Add Fluxor
builder.Services.AddFluxor(config =>
{
    config
      .ScanAssemblies(typeof(Program).Assembly)
      .UseReduxDevTools();

});

await builder.Build().RunAsync();
