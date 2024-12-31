using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Demo.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class StaffController : Controller
    {
        private readonly DataContext _dataContext;
        public StaffController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IActionResult> Index()
        {
            var Staff= await _dataContext.Staffs.OrderByDescending(x => x.Id).Include(s => s.Department).Include(p=>p.Position).ToListAsync();
            return View(Staff);
        }

        public IActionResult Create()
        {
            // Lấy danh sách phòng ban (Departments) để hiển thị trong dropdown
            ViewBag.Departments = new SelectList(_dataContext.Departments, "Id", "Name");

            // Mặc định không có chức vụ gì khi chưa chọn phòng ban
            ViewBag.Positions = new SelectList(Enumerable.Empty<SelectListItem>());

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StaffModel staff)
        {
            // Khi chọn phòng ban, lấy danh sách chức vụ của phòng ban đó
            ViewBag.Departments = new SelectList(_dataContext.Departments, "Id", "Name", staff.DepartmentId);

            if (staff.DepartmentId != 0)
            {
                // Lọc danh sách chức vụ theo phòng ban
                ViewBag.Positions = new SelectList(
                    _dataContext.Positions.Where(p => p.DepartmentId == staff.DepartmentId),
                    "Id", "Name", staff.PositionId);
            }
            else
            {
                ViewBag.Positions = new SelectList(Enumerable.Empty<SelectListItem>());
            }

            if (ModelState.IsValid)
            {
                _dataContext.Add(staff);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            TempData["error"] = "Có lỗi xảy ra khi thêm nhân viên!";
            return View(staff);
        }
        public JsonResult GetPositions(int departmentId)
        {
            var positions = _dataContext.Positions
                                        .Where(p => p.DepartmentId == departmentId)
                                        .Select(p => new { p.Id, p.Name })
                                        .ToList();

            return Json(positions);
        }

    }
}
