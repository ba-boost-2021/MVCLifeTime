using BilgeAdam.Api.Extensions;
using BilgeAdam.Api.Middlewares;
using BilgeAdam.Common.Configuration;
using BilgeAdam.Common.Contracts;
using BilgeAdam.Data.Context;
using BilgeAdam.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var settingSection = builder.Configuration.GetSection("Settings");
var settings = settingSection.Get<Settings>();
builder.Services.Configure<Settings>(settingSection);
// Add services to the container.

builder.Services.AddRequestIdentity();
builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.Key)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataServices();
builder.Services.AddDbContext<NorthwindContext>(builder =>
{
    builder.UseSqlServer(settings.Database.ConnectionString);
});
// CROSS ORIGIN RESOURCE SHARING
// Uygulamanın gelen isteğin origin'ine göre (adres) response verip vermeyeceğinin ayarlaması
builder.Services.AddCors(b =>
{
    b.AddPolicy("Development", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddScoped<RegionalParameters>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRequestIdentity();
app.UseMiddleware<RegionalSeparationMiddleware>();
app.UseCustomException();
app.UseHttpsRedirection();
app.UseCors(builder.Environment.EnvironmentName);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();