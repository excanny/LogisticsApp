using LogisticsApp.Application.Abstractions;
using LogisticsApp.Application.Services.Concretes;
using LogisticsApp.Application.Services.Interfaces;
using LogisticsApp.Infrastructure.EF;
using LogisticsApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<ApplicationDBContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ITruckService, TruckService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IPositionService, PositionService>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
