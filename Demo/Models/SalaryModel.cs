using System.ComponentModel.DataAnnotations;
using System;
namespace Demo.Models
{
    public class SalaryModel
    {
		[Key]
		public int Id { get; set; } // Khóa chính
		public int StaffId { get; set; } // Khóa ngoại đến StaffModel
		public decimal Amount { get; set; }
		public int Shiflt { get; set; }
		public DateTime PaymentDate { get; set; }
        public bool IsPaid { get; set; } // Trạng thái: Đã thanh toán hoặc chưa
        public decimal Bonus { get; set; } = 0;

        public StaffModel Staff { get; set; } // Navigation property
	}
}
