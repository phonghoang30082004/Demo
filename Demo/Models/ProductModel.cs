using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demo.Models;
using Demo.Repository.Vadidation; // Đảm bảo có import đúng namespace


namespace Demo.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Slug {  get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price {  get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Yêu cầu chon danh mục")]
        public int CategoryId { get; set; }
    
        public CategoryModel Category { get; set; }

        public string? Image {  get; set; }
        [NotMapped]
        [FileExtension]
        public IFormFile? ImageUpload { get; set; }


	}
}
