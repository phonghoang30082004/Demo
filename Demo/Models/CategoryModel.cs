using System.ComponentModel.DataAnnotations;
using Demo.Models; 
namespace Demo.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; } // Khóa chính
		public string Name { get; set; } // Tên danh mục
	}
}
