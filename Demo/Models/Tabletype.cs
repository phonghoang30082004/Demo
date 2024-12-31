using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Demo.Models
{
    public class Tabletype
    {
		[Key]
		public int Id { get; set; } // Khóa chính
		public string Name { get; set; } // Loại bàn: Bida lỗ, Bida băng, v.v.
		public ICollection<Table> Tables { get; set; } // Navigsation property
	}
}
