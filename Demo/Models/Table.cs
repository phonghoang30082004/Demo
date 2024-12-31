using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Table
    {
		[Key]
		public int Id { get; set; } // Khóa chính
		public string Name { get; set; } // Tên bàn
		public int TableTypeId { get; set; } // Khóa ngoại đến TableType
		public Tabletype TableType { get; set; } // Navigation property
	}
}
