namespace WebApp.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descripcion { get; set; }
        public bool? Enabled { get; set; }
        public List<Producto>? Productos { get; set; }

    }
}
