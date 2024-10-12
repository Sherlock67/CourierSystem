using Courier.DataAccess.Data;
using Courier.RepositoryManagement.UnitOfWork.Interfaces;
using Courier.RepositoryManagement.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using API.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configBuilder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
IConfiguration _configuration = configBuilder.Build();
StaticInfos.MsSqlConnectionString = _configuration.GetValue<string>("MSSQLconCF");
StaticInfos.MySqlConnectionString = _configuration.GetValue<string>("MySqlConnectionString");
StaticInfos.PostgreSqlConnectionString = _configuration.GetValue<string>("PostGreSqlConnectionString");
StaticInfos.IsMsSQL = _configuration.GetValue<bool>("IsMsSQL");
StaticInfos.IsMySQL = _configuration.GetValue<bool>("IsMySQL");
StaticInfos.IsPostgreSQL = _configuration.GetValue<bool>("IsPostgreSQL");
StaticInfos.JwtKey = _configuration.GetValue<string>("Jwt:Key");
StaticInfos.JwtIssuer = _configuration.GetValue<string>("Jwt:Issuer");
StaticInfos.JwtAudience = _configuration.GetValue<string>("Jwt:Audience");
StaticInfos.JwtKeyExpireIn = _configuration.GetValue<int>("Jwt:ExpireIn");
StaticInfos.FileUploadPath = _configuration.GetValue<string>("FileUploadPath");
StaticInfos.OpenApiKey = _configuration.GetValue<string>("Open-Api-Key");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();
StaticInfos.WebRootPath = app.Environment.WebRootPath;
StaticInfos.ContentRootPath = app.Environment.ContentRootPath;
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
