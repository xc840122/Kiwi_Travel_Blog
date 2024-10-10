using Microsoft.EntityFrameworkCore;
using OXL_Assessment2.Data;
using OXL_Assessment2.Interface;
using OXL_Assessment2.Interface.IServices;
using OXL_Assessment2.Src.Repositories;
using OXL_Assessment2.Src.Services;
using NLog;
using NLog.Web;
using OXL_Assessment2.Src.Middlewares;
using OXL_Assessment2.Src.Data.DbContext;
using OXL_Assessment2.Src.Data.Entities;
using Microsoft.AspNetCore.Identity;
using OXL_Assessment2.Src.Attributes;

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
    // identity db configuration
    builder.Services.AddDbContext<UserIdentityDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

    // Add Identity services
    builder.Services.AddIdentity<NZTUser, NZTRole>()
        .AddEntityFrameworkStores<UserIdentityDbContext>()
        .AddDefaultTokenProviders();

    // protect password, encryption
    builder.Services.AddDataProtection();
    // set the password policies
    builder.Services.AddIdentityCore<NZTUser>(options =>
    {
        options.Password.RequireDigit = false; //Disables the requirement for at least one numeric digit (0-9) in passwords.
        options.Password.RequireLowercase = false; //Disables the requirement for at least one lowercase letter (a-z) in passwords.
        options.Password.RequireNonAlphanumeric = false; //Disables the requirement for non-alphanumeric characters (e.g., @, #, $, etc.) in passwords.
        options.Password.RequireUppercase = false; //Disables the requirement for at least one uppercase letter (A-Z) in passwords.
        options.Password.RequiredLength = 6; //Sets the minimum length for passwords to 6 characters.
        options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider; //Specifies the token provider to be used for generating and validating password reset tokens. In this case, it uses the default email token provider, which generates tokens sent via email.
        options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider; //Specifies the token provider to be used for generating and validating email confirmation tokens, again using the default email provider.
    });

    // Add controller with options (filters...etc.)
    builder.Services.AddControllers(options =>
        {
            options.Filters.Add<ModelStateVerificationAttribute>(); // register the attribute
        });
    // Add services
    builder.Services.AddScoped<ICategoryService, CategoryService>(); //category service
    // Add repositories
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); //category repository

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Add request id middleware, after Swagger, before controller, otherwise run twice middleware
    app.UseMiddleware<RequestIdMiddleware>();

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
