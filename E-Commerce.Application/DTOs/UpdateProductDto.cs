using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.DTOs
{
    public class UpdateProductDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [Url(ErrorMessage = "Image must be a valid URL")]
        public string Image { get; set; }
    }
}
