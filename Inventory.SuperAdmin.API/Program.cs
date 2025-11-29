using Inventory.SuperAdmin.API.Middleware;
using Inventory.PersistenceService.Configurations;
using Inventory.Logging.Configure;
using Inventory.InfrastructureServices.Configurations;
using Inventory.Application.Configurations;
using Microsoft.OpenApi.Models;
using Serilog;
using SharedAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

var relativeLogPath = builder.Configuration["Logging:LogFilePath"];
var absoluteLogPath = Path.Combine(AppContext.BaseDirectory, relativeLogPath);
// Get the connection string from the nested configuration
var connectionString = builder.Configuration.GetSection("DatabaseConfig:Inventory:ConnectionString").Value;


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Register logging library with configuration
builder.Services.AddLoggingLibrary(options =>
{
    options.FileLogDirectory = absoluteLogPath;
    options.DatabaseConnectionString = connectionString;
});

// Use Serilog (after it's been configured in AddLoggingLibrary)
builder.Host.UseSerilog();

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "HRA Refuleing API", Version = "v1" });
//    // Define the OAuth2.0 scheme that's in use (i.e., Implicit Flow)

//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
//        Name = "Authorization",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer"
//    });

//    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "Bearer"
//                },
//                Scheme = "oauth2",
//                Name = "Bearer",
//                In = ParameterLocation.Header,
//            },
//            new List<string>()
//        }
//    });
//});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

builder.Services.InjectPersistenceServices(builder.Configuration);
builder.Services.InjectInfrastructureServiceCollection();
builder.Services.InjectBusinessServices();
//builder.Services.SharedAPIServiceCollection();
//builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();

builder.Services.AddExceptionHandler<ExceptionHandlerMiddleware>();

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(o => { });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
