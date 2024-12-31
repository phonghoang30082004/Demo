using Demo.Models.ViewModel;
using Demo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
        private readonly DataContext _dataContext;
        public AttendanceController (DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task  <IActionResult> Index()
        {
            var attendanceList = await _dataContext.Attendances
                .Include(a => a.Staff)
                .Select(a => new AttendanceViewModel
                {
                    Id = a.Id,
                    StaffName = a.Staff.Name,
                    AttendanceDate = a.AttendanceDate,
                    IsPresent = a.IsPresent
                })
                .ToListAsync();


            return View(attendanceList); // Truyền danh sách đến View

        }
    }
}
