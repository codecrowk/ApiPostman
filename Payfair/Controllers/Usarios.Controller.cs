using Microsoft.AspNetCore.Mvc;
using Payfair.Exceptions;
using Payfair.Models;
using Payfair.Interfaces;
using Payfair.Enums;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Payfair.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsuariosController : ControllerBase
  {
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
      _usuarioService = usuarioService;
    }

    // Método para obtener todos los usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
      try
      {
        var usuarios = await _usuarioService.ObtenerTodosLosUsuarios();
        return Ok(usuarios);
      }
      catch (Exception ex)
      {
        // Manejo de errores internos del servidor
        return StatusCode(500, ex.Message);
      }
    }

    // Método para obtener un usuario por su ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
      try
      {
        var usuario = await _usuarioService.ObtenerUsuarioPorId(id);
        return Ok(usuario);
      }
      catch (UsuarioNoEncontradoException ex)
      {
        // Usuario no encontrado
        return NotFound(ex.Message);
      }
    }

    // Método para crear un nuevo usuario
    [HttpPost]
    public async Task<ActionResult<ResultadoOperacion>> PostUsuario(Usuario usuario)
    {
      try
      {
        var resultado = await _usuarioService.CrearUsuario(usuario);
        return Ok(resultado);
      }
      catch (DatosInvalidosException ex)
      {
        // Datos del usuario no válidos
        return BadRequest(ex.Message);
      }
    }

    // Método para actualizar un usuario existente
    [HttpPut("{id}")]
    public async Task<ActionResult<ResultadoOperacion>> PutUsuario(int id, Usuario usuario)
    {
      try
      {
        var resultado = await _usuarioService.EditarUsuario(id, usuario);
        return Ok(resultado);
      }
      catch (UsuarioNoEncontradoException ex)
      {
        // Usuario no encontrado
        return NotFound(ex.Message);
      }
      catch (DatosInvalidosException ex)
      {
        // Datos del usuario no válidos
        return BadRequest(ex.Message);
      }
    }
  }
}
