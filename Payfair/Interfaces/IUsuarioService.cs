using System.Collections.Generic;
using System.Threading.Tasks;
using Payfair.Models;
using Payfair.Enums;

namespace Payfair.Interfaces
{
    // Interfaz que define los métodos para gestionar usuarios
    public interface IUsuarioService
    {
        // Método para obtener un usuario por su ID
        Task<Usuario> ObtenerUsuarioPorId(int id);
        
        // Método para obtener todos los usuarios
        Task<IEnumerable<Usuario>> ObtenerTodosLosUsuarios();
        
        // Método para crear un nuevo usuario
        Task<ResultadoOperacion> CrearUsuario(Usuario usuario);
        
        // Método para editar un usuario existente
        Task<ResultadoOperacion> EditarUsuario(int id, Usuario usuario);
    }
}
