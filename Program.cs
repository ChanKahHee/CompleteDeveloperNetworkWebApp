using CompleteDeveloperNetworkWebApp.Services.Users;
using CompleteDeveloperNetworkWebApp.Models;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using CompleteDeveloperNetworkWebApp.Services.Skills;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ISkillService, SkillService>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Connection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
    app.UseAuthorization();
}

app.MapControllers();

app.Run();
