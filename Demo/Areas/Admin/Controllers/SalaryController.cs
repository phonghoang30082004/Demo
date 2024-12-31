using Demo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SalaryController : Controller
    {
        private readonly DataContext _dataContext;

        public SalaryController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Hiển thị lương của nhân viên theo Id
        public IActionResult Index(int id)
        {
            // Lấy thông tin lương của nhân viên dựa trên Id
            var salaries = _dataContext.Salaries
                .Include(s => s.Staff)
                .Where(s => s.StaffId == id)
                .ToList();

            // Truyền tên nhân viên để hiển thị
            ViewBag.StaffName = _dataContext.Staffs
                .Where(s => s.Id == id)
                .Select(s => s.Name)
                .FirstOrDefault();

            return View(salaries);
        }
    }
}
