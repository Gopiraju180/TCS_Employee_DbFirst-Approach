using Microsoft.EntityFrameworkCore;
using TCS_Employee_DbFirst_Approach.DbConnect;
using TCS_Employee_DbFirst_Approach.Interfaces;
using TCS_Employee_DbFirst_Approach.Repository;
using TCS_Employee_DbFirst_Approach.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TcsEmployeeEntityCodeFirstApproachContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TcsConnection")));

builder.Services.AddScoped<IDepartementRepository, DepartementRepository>();
builder.Services.AddScoped<IDepartementService,DepartementService>();

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
