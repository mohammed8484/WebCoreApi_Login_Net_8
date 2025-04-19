using Microsoft.EntityFrameworkCore;
using WebCoreApi_Login_Net8.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<mydbcontext>(e => e.UseSqlServer(builder.Configuration.GetConnectionString("loginApi")));
builder.Services.AddDbContext<mydbcontext>(options =>
    options.UseInMemoryDatabase("TestDb"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
