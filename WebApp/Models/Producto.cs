using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descripcion { get; set; }
        public int? Precio { get; set; }
        public int? Stock { get; set; }

        public string? ImagenUrl { get; set; }

        [NotMapped]
        public IFormFile? ImagenFile { get; set; }


        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

    }
}
