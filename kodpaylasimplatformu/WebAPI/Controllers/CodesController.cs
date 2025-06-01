using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CodesController : ControllerBase
{
    private readonly UserDbContext _context;

    public CodesController(UserDbContext context)
    {
        _context = context;
    }

    [HttpGet("Get")]   
    public async Task<IActionResult> Get(int id)
    {
        var result = _context.Codes.Include(x => x.Comments).FirstOrDefault(x => x.Id == id);
        result.Comments = _context.Comments.Where(x => x.CodeId == id).ToList();
        return Ok(result);
    }
    [HttpGet("GetLast")]
    public async Task<IActionResult> GetLast()
    {
        var result = _context.Codes.OrderByDescending(x => x.Id).Take(3).ToList();
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> ShareCode([FromBody] Code code)
    {
        if (code == null)
        {
            return BadRequest(new { message = "Kod verileri geçersiz. Lütfen tüm alanları kontrol edin." });
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = "Kod verileri eksik veya hatalı." });
        }


        try
        {
            _context.Codes.Add(code); 
            await _context.SaveChangesAsync(); 

            return Ok(new { message = "Kod başarıyla paylaşıldı." });
        }
        catch (Exception ex)
        {
            
            return StatusCode(500, new { message = $"Kod paylaşılırken bir hata oluştu: {ex.Message}" });
        }
    }

    
    [HttpGet]
    public async Task<IActionResult> GetCodes()
        {
        try
        {
            var codes = await _context.Codes.Include(x => x.Comments).ToListAsync();
            return Ok(codes); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Kodlar alınırken bir hata oluştu: {ex.Message}" });
        }
    }

    [HttpPost("AddComment")]
    public async Task<IActionResult> AddComment(Comment comment)
    {
        if (comment == null || string.IsNullOrEmpty(comment.Username) || string.IsNullOrEmpty(comment.Content))
        {
            return BadRequest(new { message = "Geçersiz veri" });
        }

        var code = await _context.Codes.FirstOrDefaultAsync(c => c.Id == comment.CodeId);

        if (code == null)
        {
            return NotFound(new { message = "Kod bulunamadı" });
        }
        
        _context.Comments.Add(comment);
        
        await _context.SaveChangesAsync();

        return Ok(new { message = "Yorum başarıyla eklendi" });
    }


    
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveCode(int id)
    {
        try
        {
            var code = await _context.Codes.FindAsync(id);
            if (code == null)
            {
                return NotFound(new { message = "Kod bulunamadı." });
            }

            _context.Codes.Remove(code); 
            await _context.SaveChangesAsync(); 

            return Ok(new { message = "Kod başarıyla silindi." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = $"Kod paylaşılırken bir hata oluştu: {ex.Message}",
                details = ex.InnerException?.Message 
            });
        }
    }
}

