using Microsoft.EntityFrameworkCore;
using WebCoreApi_Login_Net8.Models;

var builder = WebApplication.CreateBuilder(args);

// ✳️ إضافة خدمة CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<mydbcontext>(options =>
    options.UseInMemoryDatabase("TestDb"));

var app = builder.Build();

// ✳️ استخدام CORS (قبل UseAuthorization)
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
