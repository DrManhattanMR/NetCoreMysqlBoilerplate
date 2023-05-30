namespace Entities;

public class User
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public string Password { get; set; }
    public DateTime FechaAlta { get; set; }
    public bool Verificado { get; set; }
}

