using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace Demo.Models
{
    public class PositionModel
    {

		[Key]
		public int Id { get; set; } // Khóa chính
		public string Name { get; set; } // Tên chức vụ
        [Required(ErrorMessage = "Vui lòng chọn phòng ban.")]
        public int DepartmentId { get; set; }

        // Mối quan hệ: mỗi chức vụ thuộc một phòng ban
        public DepartmentModel Department { get; set; }
    }
}
