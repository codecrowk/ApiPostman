using System;

namespace Payfair.Exceptions
{
    // Excepción personalizada para indicar datos de usuario no válidos
    public class DatosInvalidosException : Exception
    {
        // Constructor que acepta un mensaje personalizado
        public DatosInvalidosException(string message) : base(message)
        {
        }
    }
}
