using System.ComponentModel.DataAnnotations;
namespace textilsalas.Models;
public class Comentario
{
    public int Id { get; set; }
    public string UsuarioId { get; set; }
    public ApplicationUser Usuario { get; set; }
    [Required] public string Mensaje { get; set; }
    [Range(1,5)] public int Calificacion { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
}
