using BilgeAdam.Common.Configuration;
using BilgeAdam.Data.Context;
using BilgeAdam.Services;
using Microsoft.EntityFrameworkCore;

//Environment : Development 
// (ENV) = "Development" => ASPNETCORE_ENVIRONMENT
//launchSettings.json içerisindeki "ASPNETCORE_ENVIRONMENT" deðeri þu an çalýþtýðýnýz ortamý belirler


var builder = WebApplication.CreateBuilder(args);
//Öncelikle appSettings.json ve appSettings.{ENV}.json'a git
var settingSection = builder.Configuration.GetSection("Settings");
var settings = settingSection.Get<Settings>();

builder.Services.Configure<Settings>(settingSection); // DI üzerinden Setting'e eriþebilmek için yazýldý


// Add services to the container. (DI Container) -> Dependency Injection Container
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NorthwindContext>(builder =>
{
    builder.UseSqlServer(settings.Database.ConnectionString);
});
builder.Services.AddCustomServices();

var app = builder.Build();
//-----------------------------------------------------------------------------------
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
