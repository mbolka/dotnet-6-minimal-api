using Azure.Identity;
using WebApi.Flags;
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAzureAppConfiguration(options =>
                    options.Connect(new Uri("https://bolek-app-configuration.azconfig.io"), new ManagedIdentityCredential()));
// add services to DI container
{
    var services = builder.Services;
    services.Configure<Settings>(builder.Configuration.GetSection("TestApp:Settings"));
    services.AddControllers();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    app.MapControllers();
}

app.Run();