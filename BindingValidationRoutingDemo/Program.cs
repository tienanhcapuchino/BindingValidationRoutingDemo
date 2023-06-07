using BindingValidationRoutingDemo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NorthwindContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("APIConnectStr"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
//app.MapControllers();
app.MapGet("/hello/{name:alpha}", (string name) => $"Hello {name}!");
app.MapGet("/hello/tien/aa", () => "Hello aaa !");
app.MapGet("/", () => "Hello World!");

app.Run();
