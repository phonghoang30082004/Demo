using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace Demo.Models
{
    public class ReservationModel
    {
		[Key]
		public int Id { get; set; } // Khóa chính
		public int TableId { get; set; } // Khóa ngoại đến Table
		public int CustomerId { get; set; } // Khóa ngoại đến AppUserModel (hoặc bảng Customer)
		public DateTime ReservationDate { get; set; } // Ngày đặt bàn
		public TimeSpan StartTime { get; set; } // Thời gian bắt đầu
		public TimeSpan EndTime { get; set; } // Thời gian kết thúc
		public int NumberOfPeople { get; set; } // Số lượng người
		public string Notes { get; set; } // Ghi chú
		public string Status { get; set; } // Trạng thái (Pending, Confirmed, Cancelled)

		// Navigation properties
		public Table Table { get; set; }
		public AppUserModel Customer { get; set; }
	}
}
