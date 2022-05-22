using BilgeAdam.Common.Configuration;
using BilgeAdam.Data.Context;
using BilgeAdam.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var settingSection = builder.Configuration.GetSection("Settings");
var settings = settingSection.Get<Settings>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataServices();
builder.Services.AddDbContext<NorthwindContext>(builder =>
{
    builder.UseSqlServer(settings.Database.ConnectionString);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
