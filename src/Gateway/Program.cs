using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add Ocelot services
builder.Configuration.AddJsonFile("ocelot.json",
    optional: false,
    reloadOnChange: true);
builder.Services.AddOcelot();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseOcelot().Wait();

await app.RunAsync();