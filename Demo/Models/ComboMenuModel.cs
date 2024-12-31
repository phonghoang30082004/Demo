using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class ComboMenuModel
    {
		[Key]
		public int Id { get; set; } // Khóa chính
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string? ImageCB {  get; set; }
		public ICollection<ProductModel> Products { get; set; } // Sản phẩm trong combo
	}
}
