using EmployeeAPI;
using EmployeeAPI.IServices;
using EmployeeAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeAPIConnectionString")));

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Auto Mapper Injection
builder.Services.AddAutoMapper(typeof(Program));

// Services Injection
builder.Services.AddTransient<IEmployeeService,EmployeeService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "TrustedEndpoints",
                      policy =>
                      {
                          //policy.WithOrigins("http://localhost:3000/").AllowAnyHeader().AllowAnyMethod();
                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("TrustedEndpoints");

app.UseAuthorization();

app.MapControllers();

app.Run();
