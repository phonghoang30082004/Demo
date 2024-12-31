using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class StaffModel
    {
		[Key]
		public int Id { get; set; } // Khóa chính
		public string Name { get; set; }
		public string Phone { get; set; }
		public int DepartmentId { get; set; } // Khóa ngoại đến DepartmentModel
		public int PositionId { get; set; } // Khóa ngoại đến PositionModel
		public DepartmentModel Department { get; set; } // Navigation property
		public PositionModel Position { get; set; } // Navigation property
                                                    // Thêm liên kết hai chiều
 
    }
}
