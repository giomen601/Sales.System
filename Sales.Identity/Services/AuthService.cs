using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sales.Application.Contracts.Identity;
using Sales.Application.Models.Identity;
using Sales.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Identity.Services;
public class AuthService : IAuthService
{
  private readonly UserManager<ApplicationUser> userManager;
  private readonly SignInManager<ApplicationUser> signInManager;
  private readonly JwtSettings jwtSettings;

  public AuthService
  (
    UserManager<ApplicationUser> userManager,
    IOptions<JwtSettings> jwtSettings,
    SignInManager<ApplicationUser> signInManager

  )
  {
    this.userManager = userManager;
    this.signInManager = signInManager;
    this.jwtSettings = jwtSettings.Value;
  }

  public Task<AuthResponse> Login(AuthRequest request)
  {
    throw new NotImplementedException();
  }

  public Task<RegistrationResponse> Register(RegistrationRequest request)
  {
    throw new NotImplementedException();
  }

  private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
  {
    var userClaims = await userManager.GetClaimsAsync(user);
    var roles = await userManager.GetRolesAsync(user);

    var rolesClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

    var claims = new[]
    {
      new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
      new Claim(JwtRegisteredClaimNames.Email, user.Email),
      new Claim("uid", user.Id)
    }
    .Union(userClaims)
    .Union(rolesClaims);

    var symmetricSecurityKey =
    new SymmetricSecurityKey
    (
      Encoding.UTF8.GetBytes(jwtSettings.Key)
    );

    var signingCredentials =
    new SigningCredentials
    (
      symmetricSecurityKey,
      SecurityAlgorithms.HmacSha256
    );

    var jwtSecurityToken =
    new JwtSecurityToken
    (
      issuer: jwtSettings.Issuer,
      audience: jwtSettings.Audience,
      claims: claims,
      expires: DateTime.UtcNow.AddMinutes(jwtSettings.DurationInMinutes),
      signingCredentials: signingCredentials
    );

    return jwtSecurityToken;
  }
}
