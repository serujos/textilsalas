using System.ComponentModel.DataAnnotations;
namespace textilsalas.Models;
public class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Celular { get; set; }
    [EmailAddress] public string Correo { get; set; }
    public string Mensaje { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
}