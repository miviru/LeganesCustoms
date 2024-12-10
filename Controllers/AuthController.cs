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
    
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        try
        {
            // Cerrar sesión y eliminar cookie de autenticación
            await _signInManager.SignOutAsync();

            // Devolver respuesta exitosa
            return Ok(new { message = "Logged out successfully" });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en el endpoint de logout: {ex.Message}");
            return BadRequest(new { error = "Logout failed", details = ex.Message });
        }
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
