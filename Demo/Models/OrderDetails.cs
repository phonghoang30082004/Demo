using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class OrderDetails
    {
		[Key]
		public int Id { get; set; } // Khóa chính
		public int OrderId { get; set; } // Khóa ngoại đến OrderModel
		public int ProductId { get; set; } // Khóa ngoại đến ProductModel
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public OrderModel Order { get; set; } // Navigation property
		public ProductModel Product { get; set; } // Navigation property
	}
}
