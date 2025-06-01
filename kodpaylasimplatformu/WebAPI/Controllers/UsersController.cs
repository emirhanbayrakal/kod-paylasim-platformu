using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserDbContext _context;

    public UsersController(UserDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        if (_context.Users.Any(u => u.Email == user.Email))
        {
            return BadRequest("Bu e-posta ile daha �nce kay�t olunmu�.");
        }

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash); 
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("Kay�t ba�ar�l�.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash))
        {
            return Unauthorized("E-posta veya �ifre hatal�.");
        }

        return Ok(user); 
    }

    [HttpGet("GetDetail")]
    public async Task<IActionResult> GetDetail(int id)
    {
        var user = await _context.Users.Include(x => x.Codes).FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
        {
            return Ok(new { message = "Giri� yap�lmam��" });
        }

        return Ok(user);
    }
}

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
