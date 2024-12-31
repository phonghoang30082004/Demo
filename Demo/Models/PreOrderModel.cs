using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
namespace Demo.Models
{
    public class PreOrderModel
    {
		[Key]
		public int Id { get; set; } // Khóa chính
		public int ProductId { get; set; } // Khóa ngoại đến ProductModel
		public int CustomerId { get; set; } // Khóa ngoại đến AppUserModel (hoặc bảng Customer)
		public DateTime PreOrderDate { get; set; } // Ngày đặt hàng trước
		public int Quantity { get; set; } // Số lượng đặt trước
		public decimal TotalPrice { get; set; } // Tổng giá trị
		public string Status { get; set; } // Trạng thái (Pending, Confirmed, Cancelled)

		// Navigation properties
		public ProductModel Product { get; set; }
		public AppUserModel Customer { get; set; }
	}
}
