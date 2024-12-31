using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class OrderModel
    {
		[Key]
		public int Id { get; set; } // Khóa chính
		public DateTime OrderDate { get; set; }
		public string CustomerName { get; set; }
		public string CustomerPhone { get; set; }
		public ICollection<OrderDetails> OrderDetails { get; set; } // Navigation property
	}
}
