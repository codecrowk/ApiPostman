namespace Payfair.Enums
{
    // Enumeración que representa los posibles resultados de una operación en el sistema
    public enum ResultadoOperacion
    {
        // Operación exitosa
        Exito,
        
        // El usuario no existe en el sistema
        UsuarioNoExiste,
        
        // Los datos proporcionados son inválidos
        DatosInvalidos,
        
        // Error general durante la operación
        Error
    }
}