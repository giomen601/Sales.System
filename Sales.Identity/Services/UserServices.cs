using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sales.Application.Contracts.Identity;
using Sales.Application.Models.Identity;
using Sales.Identity.Models;
using System.Security.Claims;

namespace Sales.Identity.Services;
public class UserServices : IUserService
{
  private readonly UserManager<ApplicationUser> userManager;
  private readonly IHttpContextAccessor contextAccessor;

  public UserServices
  (
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor contextAccessor
  )
  {
    this.userManager = userManager;
    this.contextAccessor = contextAccessor;
  }

  public string? UserId
  {
    get => contextAccessor.HttpContext?.User?.FindFirstValue("uid");//uid comes from AuthService //(ClaimTypes.NameIdentifier);
  }

  public async Task<User> GetUser(string userId)
  {
    var user = await userManager.FindByIdAsync(userId);
    return new User
    {
      Email = user.Email,
      Id = user.Id,
    };
  }

  public async Task<List<User>> GetUsers()
  {
    var users = await userManager.GetUsersInRoleAsync("User");
    return users.Select(x => new User
    {
      Email = x.Email,
      Id = x.Id,
    }).ToList();
  }
}
