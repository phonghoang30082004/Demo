using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProductController(DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = dataContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async  Task<IActionResult> Index()
        {
            return View(await _dataContext.Products.OrderByDescending(p => p.Id).Include(p => p.Category).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories,"Id","Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModel product)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);
            if (ModelState.IsValid)
            {
                product.Slug = product.Name.Replace(" ", "-");
                var slug = await _dataContext.Products.FirstOrDefaultAsync(p => p.Slug == product.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Sản phẩm đã có trong database");
                    return View(product);
                }


                if (product.ImageUpload != null)
                {
                    //detele
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");

                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;

                    string filepath = Path.Combine(uploadDir, imageName);

                    FileStream fs = new FileStream(filepath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    product.Image = imageName;

                }



                _dataContext.Add(product);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Thêm sản phẩm thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "CÓ một vài thứ đang bị lỗi !";
                List<String> errors = new List<String>();
                foreach (var value in ModelState.Values)
                {

                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }

                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }
            return View(product);

        }

        public async Task<IActionResult> Edit(int Id)
        {

            ProductModel product = await _dataContext.Products.FindAsync(Id);
ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, ProductModel product)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);
            var existed_product = await _dataContext.Products.FindAsync(product.Id); // sửa lại để dùng FindAsync


            if (ModelState.IsValid)
            {
                product.Slug = product.Name.Replace(" ", "-");
                var slug = await _dataContext.Products.FirstOrDefaultAsync(p => p.Slug == product.Slug);



                if (product.ImageUpload != null)
                {

                    //update anh moi
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");

                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;

                    string filepath = Path.Combine(uploadDir, imageName);

                    //xoa anh cu
                    string oldfileImage = Path.Combine(uploadDir, existed_product.Image);
                    try
                    {
                        if (System.IO.File.Exists(oldfileImage))
                        {
                            System.IO.File.Delete(oldfileImage);

                        }
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Bi loi");
                    }


                    FileStream fs = new FileStream(filepath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    existed_product.Image = imageName;




                }

                existed_product.Name = product.Name;
                existed_product.Description = product.Description;
                existed_product.Price = product.Price;
                existed_product.CategoryId = product.CategoryId; 




                _dataContext.Update(existed_product);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Cập nhật sản phẩm thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "CÓ một vài thứ đang bị lỗi !";
                List<String> errors = new List<String>();
                foreach (var value in ModelState.Values)
                {

                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }

                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }


            return View(product);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            ProductModel product = await _dataContext.Products.FindAsync(Id);
            if (product != null && !string.Equals(product.Image, "noname.jpg"))
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
                string oldfileImage = Path.Combine(uploadDir, product.Image ?? string.Empty); // Kiểm tra null cho product.Image
                if (!string.IsNullOrEmpty(product.Image) && System.IO.File.Exists(oldfileImage))
                {
                    System.IO.File.Delete(oldfileImage);
                }
            }
            if (product != null)
            {
                _dataContext.Products.Remove(product);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Xóa sản phẩm thành công";
            }
            else
            {
                TempData["error"] = "Không tìm thấy sản phẩm";
            }
            return RedirectToAction("Index");
        }
    }
}
