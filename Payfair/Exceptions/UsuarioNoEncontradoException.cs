using System;

namespace Payfair.Exceptions
{
    // Excepción personalizada para indicar que un usuario no ha sido encontrado
    public class UsuarioNoEncontradoException : Exception
    {
        // Constructor que acepta un mensaje personalizado
        public UsuarioNoEncontradoException(string message) : base(message)
        {
        }
    }
}
