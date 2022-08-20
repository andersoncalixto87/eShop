using System.ComponentModel.DataAnnotations;

namespace eShop.ProductApi.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The Descrition is Required")]
    public string? Name { get; set; }
    public ICollection<ProductDTO>? Products { get; set; }
}
