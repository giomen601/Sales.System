using Microsoft.AspNetCore.Mvc;
using Sales.Application.Contracts.Identity;
using Sales.Application.Models.Identity;

namespace Sales.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly IAuthService authService;

  public AuthController
  (
    IAuthService authService
  )
  {
    this.authService = authService;
  }

  [HttpPost("login")]
  public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
  {
    return Ok(await authService.Login(request));
  }

  [HttpPost("register")]
  public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
  {
    return Ok(await authService.Register(request));
  }
}
