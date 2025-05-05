namespace textilsalas.Models;
public class Subcategoria
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
    public ICollection<Producto> Productos { get; set; }
}