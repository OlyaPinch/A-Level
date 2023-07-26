using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Infrastructure.Extensions;
using Infrastructure.Filters;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var configuration = GetConfiguration();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));




builder.Services.AddTransient(typeof(IEntityService<,>), typeof(EntityService<,>));
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
var s = configuration["ConnectionString"] ?? string.Empty.ToString();

builder.Services.AddDbContextFactory<ApplicationDbContext>(opts => opts.UseNpgsql(s));

builder.Services.AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>();
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
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();