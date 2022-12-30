using Azure.Identity;
using WebApi.Flags;
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAzureAppConfiguration(options =>
                    options.Connect(new Uri("https://bolek-app-configuration.azconfig.io"), new ManagedIdentityCredential()));
// add services to DI container
{
    var services = builder.Services;
    var sett = new Settings(){Message = "TEST"}
    services.Configure<Settings>(sett);
    services.AddControllers();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    app.MapControllers();
}

app.Run();