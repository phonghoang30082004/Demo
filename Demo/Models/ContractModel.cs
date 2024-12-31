using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class ContractModel
    {
		[Key]
		public int Id { get; set; } // Khóa chính
		public int SupplierId { get; set; } // Khóa ngoại đến SupplierModel
		public DateTime StartDate { get; set; } // Ngày bắt đầu hợp đồng
		public DateTime EndDate { get; set; } // Ngày kết thúc hợp đồng
		public string ContractType { get; set; } // Loại hợp đồng: Giao hàng, Cung cấp vật tư, v.v.
		public string Terms { get; set; } // Điều khoản hợp đồng
		public decimal TotalValue { get; set; } // Tổng giá trị hợp đồng
		public SupplierModel Supplier { get; set; } // Navigation property
	}

}
