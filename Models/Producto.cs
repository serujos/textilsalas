namespace textilsalas.Models;
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Medida { get; set; }
    public string Gramaje { get; set; }
    public decimal Precio { get; set; }
    public string ImagenUrl { get; set; }
    public int SubcategoriaId { get; set; }
    public Subcategoria Subcategoria { get; set; }
}