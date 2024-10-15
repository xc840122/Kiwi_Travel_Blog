using NLog;
using NLog.Web;
using Kiwi_Travel_Blog.Src.Middlewares;
using Kiwi_Travel_Blog.Src.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Identity configuration
    IdentityConfigurationExtension.InjectIdentityServices(builder.Services);
    // Authentication configuration, must follow  Identity services,otherwise, identity is null in middleware
    AuthenticationConfigurationExtension.InjectAuthenticationServices(builder.Services, builder.Configuration);
    // Database configuration
    DatabaseConfigurationExtension.InjectDatabaseServices(builder.Services, builder.Configuration);
    // Controller configuration
    ControllerConfigurationExtension.InjectControllerServices(builder.Services);
    // Business configuration
    BusinessConfigurationExtension.InjectBusinessServices(builder.Services);
    // Repository configuration
    RepositoryConfigurationExtension.InjectRepositoryServices(builder.Services);
    // Utility configuration
    UtilityConfigurationExtension.InjectUtilityServices(builder.Services);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    // app.UseMiddleware<RequestLoggingMiddleware>();
    app.UseMiddleware<RequestIdMiddleware>(); // Add request id middleware, after Swagger, before controller, otherwise run twice middleware
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseMiddleware<UserInfoMiddleware>(); // Fetch user info from request, add to items
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
