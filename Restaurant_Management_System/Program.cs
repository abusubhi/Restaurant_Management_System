using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.Controllers;
using Restaurant_Management_System.DTOs.ItemsDTO.Request;
using Restaurant_Management_System.Interfaces;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Models;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Restaurant_Management_System.Helper;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Service;
using Restaurant_Management_System.Interfaces;


using Restaurant_Management_System.Service;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IItem, ItemService>();
builder.Services.AddScoped<INotification, NotificationService>();
builder.Services.AddScoped<IAddPaymentCard, AddPaymentCardService>();
builder.Services.AddScoped<IAddAddress, AddAddressService>();


builder.Services.AddScoped<AuthController>();
// Add services to the container.
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<IItem, ItemService>();
builder.Services.AddScoped<IOrder, OrderService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RMSDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add Authentication and Authorization with JWT



builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





// Register your services




builder.Services.AddDbContext<RMSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
