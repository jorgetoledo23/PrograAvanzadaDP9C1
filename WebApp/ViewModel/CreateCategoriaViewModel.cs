using WebApp.Models;

namespace WebApp.ViewModel
{
    public class CreateCategoriaViewModel
    {
        public ICollection<Categoria>? Categorias { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
