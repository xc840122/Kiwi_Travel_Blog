using Microsoft.EntityFrameworkCore;
using OXL_Assessment2.Data;
using OXL_Assessment2.Interface;
using OXL_Assessment2.Interface.IServices;
using OXL_Assessment2.Src.Repositories;
using OXL_Assessment2.Src.Services;
using NLog;
using NLog.Web;
using OXL_Assessment2.Src.Middlewares;

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

    // database configuration
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // controller, service, repository
    builder.Services.AddControllers();
    builder.Services.AddScoped<ICategoryService, CategoryService>(); //category service
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); //category repository

    var app = builder.Build();

    // Add middlewares
    app.UseMiddleware<RequestIdMiddleware>(); //register middleware

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
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
