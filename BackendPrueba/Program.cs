using BackendPrueba.Data;
using BackendPrueba.Models;
using BackendPrueba.Repository.Interface;
using BackendPrueba.Repository.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddEndpointsApiExplorer()
.AddScoped<IProductRepository, ProductRepository>()
.AddScoped<IStatusRepository, StatusRepository>()
.AddScoped<IUserRepository, UserRepository>();
    //.AddRoles<IdentityRole>();
builder.Services.AddSwaggerGen();
//builder.Services.AddAuthorization();
//builder.Services.AddAuthentication("Bearer").AddBearerToken();

var app = builder.Build();

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
