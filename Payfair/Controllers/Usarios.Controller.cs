using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payfair.Data;
using Payfair.Models;

namespace Payfair.Controllers
{
  // This line define the end-point in this case: api/todoitems
  [Route("api/[controller]")]
  [ApiController]
  public class UsuariosController : ControllerBase
  {
    private readonly BaseContext _context;

    public UsuariosController (BaseContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
      return await _context.Usuarios.ToListAsync();
    }
  }
}