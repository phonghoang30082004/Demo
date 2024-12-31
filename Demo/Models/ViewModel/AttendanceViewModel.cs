namespace Demo.Models.ViewModel
{
    public class AttendanceViewModel
    {
        public int Id { get; set; }
        public string StaffName { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool IsPresent { get; set; }
    }
}
