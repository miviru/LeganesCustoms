using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthController(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout(string returnUrl = null)
    {
        await _signInManager.SignOutAsync();
        return LocalRedirect(returnUrl ?? Url.Page("/", new { area = "" }));
    }

    [HttpGet("userinfo")]
    public IActionResult GetUserInfo()
    {
        // Ejemplo de datos de usuario
        var userInfo = new
        {
            IsAuthenticated = true,
            Roles = new[] { "Admin", "User" }
        };

        return Ok(userInfo);
    }
}

