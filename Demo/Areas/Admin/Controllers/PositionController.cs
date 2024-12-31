using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Demo.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class PositionController : Controller
    {
        private readonly DataContext _dataContext;
        public PositionController(DataContext dataContext) {  _dataContext = dataContext; }

        public async Task< IActionResult> Index()
        {
            var Position = await _dataContext.Positions.OrderByDescending(p => p.Id).Include(c=>c.Department).ToListAsync();
            return View(Position);
        }
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_dataContext.Departments, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DepartmentId")] PositionModel position)
        {
            Console.WriteLine($"DepartmentId: {position.DepartmentId}");
            ViewBag.Departments = new SelectList(_dataContext.Departments, "Id", "Name",position.DepartmentId);

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(position);
            }
         
            if (ModelState.IsValid)
            {
                _dataContext.Positions.Add(position);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            // Nếu ModelState không hợp lệ, trả lại view với các lỗi
            return View(position);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _dataContext.Positions.FindAsync(id);
            ViewBag.Departments = new SelectList(_dataContext.Departments, "Id", "Name");

            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }

        // Xử lý sửa category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DepartmentId")] PositionModel position)
        {
            if (id != position.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                ViewBag.Departments = new SelectList(_dataContext.Departments, "Id", "Name",position.DepartmentId);

                var existed_position = await _dataContext.Positions.FindAsync(position.Id); // sửa lại để dùng FindAsync

                try
                {
                    existed_position.Name=position.Name;
                    existed_position.DepartmentId=position.DepartmentId;
                    _dataContext.Update(existed_position);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(position.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(position);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _dataContext.Positions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // Xử lý xóa category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _dataContext.Positions.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }

            _dataContext.Positions.Remove(position);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _dataContext.Positions.Any(e => e.Id == id);
        }
    }
}
