using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.Controllers;
using Restaurant_Management_System.DTOs.ItemsDTO.Request;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Models;
using Restaurant_Management_System.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IItem, GetItem>();
builder.Services.AddScoped<INotification, GetNotification>();

builder.Services.AddScoped<AuthController>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RMSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
