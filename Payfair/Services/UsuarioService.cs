// Ruta: Payfair/Services/UsuarioService.cs

using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payfair.Data;
using Payfair.Enums;
using Payfair.Exceptions;
using Payfair.Interfaces;
using Payfair.Models;
using System.Collections.Generic;

namespace Payfair.Services
{
    // Servicio que implementa la lógica de negocio para la gestión de usuarios
    public class UsuarioService : IUsuarioService
    {
        private readonly BaseContext _context;

        // Constructor que recibe el contexto de la base de datos
        public UsuarioService(BaseContext context)
        {
            _context = context;
        }

        // Método para obtener todos los usuarios
        public async Task<IEnumerable<Usuario>> ObtenerTodosLosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // Método para obtener un usuario por su ID
        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                throw new UsuarioNoEncontradoException($"Usuario con ID {id} no encontrado.");
            }
            return usuario;
        }

        // Método para crear un nuevo usuario
        public async Task<ResultadoOperacion> CrearUsuario(Usuario usuario)
        {
            try
            {
                // Agregar el nuevo usuario al contexto
                _context.Usuarios.Add(usuario);
                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();
                return ResultadoOperacion.Exito;
            }
            catch (DbUpdateException ex)
            {
                // Manejar excepciones de actualización de base de datos (por ejemplo, violación de restricción única)
                Console.WriteLine($"Error al crear usuario: {ex.InnerException?.Message}");
                return ResultadoOperacion.Error;
            }
            catch (Exception ex)
            {
                // Manejar cualquier otra excepción inesperada
                Console.WriteLine($"Error inesperado al crear usuario: {ex.Message}");
                return ResultadoOperacion.Error;
            }
        }

        // Método para editar un usuario existente
        public async Task<ResultadoOperacion> EditarUsuario(int id, Usuario usuario)
        {
            try
            {
                // Buscar el usuario existente por su ID
                var usuarioExistente = await _context.Usuarios.FindAsync(id);
                if (usuarioExistente == null)
                {
                    throw new UsuarioNoEncontradoException($"Usuario con ID {id} no encontrado.");
                }

                // Actualizar las propiedades del usuario existente
                usuarioExistente.Nombre = usuario.Nombre;
                usuarioExistente.Apellido = usuario.Apellido;
                usuarioExistente.Email = usuario.Email;

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();
                return ResultadoOperacion.Exito;
            }
            catch (DbUpdateException ex)
            {
                // Manejar excepciones de actualización de base de datos
                Console.WriteLine($"Error al editar usuario: {ex.InnerException?.Message}");
                return ResultadoOperacion.Error;
            }
            catch (Exception ex)
            {
                // Manejar cualquier otra excepción inesperada
                Console.WriteLine($"Error inesperado al editar usuario: {ex.Message}");
                return ResultadoOperacion.Error;
            }
        }
    }
}
