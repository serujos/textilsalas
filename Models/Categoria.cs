namespace textilsalas.Models;
public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<Subcategoria> Subcategorias { get; set; }
}