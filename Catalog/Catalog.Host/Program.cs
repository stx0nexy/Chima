using Catalog.Host.Configurations;
using Catalog.Host.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var configuration = GetConfiguration();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Chima- Catalog HTTP API",
        Version = "v1",
        Description = "The Catalog Service HTTP API"
    });
});

builder.Services.Configure<CatalogConfig>(configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContextFactory<ApplicationDbContext>(opts => opts.UseSqlServer(configuration["ConnectionString"]!));

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "CorsPolicy",
        builder => builder
            .SetIsOriginAllowed((host) => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

app.UseSwagger()
    .UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint($"{configuration["PathBase"]}/swagger/v1/swagger.json", "Catalog.API V1");
        setup.OAuthClientId("catalogswaggerui");
        setup.OAuthAppName("Catalog Swagger UI");
    });

app.UseRouting();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapControllers();
});

app.Run();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}