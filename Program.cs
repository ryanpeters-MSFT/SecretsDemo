using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        // load settings from appsettings.json
        config.AddJsonFile("appsettings.json");

        // load settings from secrets.json
        config.AddUserSecrets<Program>();
    });

var app = builder.Build();

var configuration = app.Services.GetService<IConfiguration>();

Console.WriteLine(configuration["Username"]);
Console.WriteLine(configuration["Password"]);
Console.WriteLine(configuration["PaymentsEnabled"]);

// knows to look for ConnectionStrings section in appsettings/secrets
var connectionString = configuration.GetConnectionString("Default");

Console.WriteLine(connectionString);