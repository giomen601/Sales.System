using Microsoft.Extensions.DependencyInjection;
using Sales.Application;
using Sales.Persistence;
using System.Text.Json.Serialization;
using Sales.Identity;
using System.IdentityModel.Tokens.Jwt;


var builder = WebApplication.CreateBuilder(args);

//Clear clamis jwt maps
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

// Add services to the container.

builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("IsAdmin",
    policy =>
    policy.RequireClaim
    ("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Administrator")
  );
});

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors
(
  options => 
  {
    options.AddPolicy("all", builder => 
      builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
    );
  }
);
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

app.UseCors("all");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
