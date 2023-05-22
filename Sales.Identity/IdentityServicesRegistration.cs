using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sales.Application.Contracts.Identity;
using Sales.Application.Models.Identity;
using Sales.Identity.DbContext;
using Sales.Identity.Models;
using Sales.Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Identity;
public static class IdentityServicesRegistration
{
  public static IServiceCollection AddIdentityServices
  (
    this IServiceCollection services,
    IConfiguration configuration
  )
  {
    services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

    services.AddDbContext<SalesIdentityDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("SalesDbConnectionString")));

    services.AddIdentity<ApplicationUser, IdentityRole>()
      .AddEntityFrameworkStores<SalesIdentityDbContext>()
      .AddDefaultTokenProviders();

    services.AddTransient<IAuthService, AuthService>();
    services.AddTransient<IUserService, UserServices>();

    services.AddAuthentication
    (
      option =>
      {
        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }
    )
    .AddJwtBearer
    (
      options =>
      {
        options.MapInboundClaims = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero,
          ValidIssuer = configuration["JwtSettings:Issuer"],
          ValidAudience = configuration["JwtSettings:Audience"],
          IssuerSigningKey = new SymmetricSecurityKey
          (Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
        };
      }
    );

    return services;
  }
}
