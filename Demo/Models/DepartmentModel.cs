using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace Demo.Models
{
    public class DepartmentModel
    {

        [Key]
        public int Id { get; set; } // Khóa chính
        public string Name { get; set; } // Tên phòng ban
        public ICollection<PositionModel> Positions { get; set; } // Mối quan hệ ngược lại

    }
}
