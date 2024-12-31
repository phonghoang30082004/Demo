using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class AttendanceModel
    {
        [Key]
        public int Id { get; set; } // Khóa chính
        public int StaffId { get; set; } // Khóa ngoại đến StaffModel
        public DateTime AttendanceDate { get; set; } // Ngày điểm danh
        public bool IsPresent { get; set; } // Có mặt hay không
        public StaffModel Staff { get; set; } // Navigation property
    }
}
