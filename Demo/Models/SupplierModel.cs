using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Demo.Models
{
    public class SupplierModel
    {
		[Key]
		public int Id { get; set; } // Khóa chính
		public string Name { get; set; } // Tên nhà cung cấp
		public string Phone { get; set; } // Số điện thoại nhà cung cấp
		public string Email { get; set; } // Email nhà cung cấp
		public ICollection<ProductModel> Products { get; set; } // Sản phẩm của nhà cung cấp
		public ICollection<ContractModel> Contracts { get; set; } // Hợp đồng của nhà cung cấp
	}
}
