using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAzureAppConfiguration(options =>
                    options.Connect(new Uri("https://bolek-app-configuration.azconfig.io"), new ManagedIdentityCredential()));
builder.Services.Configure<WebApi.Flags.Settings>(builder.Configuration.GetSection("TestApp:Settings"));
// add services to DI container
{
    var services = builder.Services;
    services.AddControllers();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    app.MapControllers();
}

app.Run();