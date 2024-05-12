using System.ComponentModel.DataAnnotations;

namespace UserProductAPI.Data.DTOS
{
    public class ProductDTO
    {
        [Required(ErrorMessage ="O Nome é obrigatório")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "O Preço é obrigatório")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
