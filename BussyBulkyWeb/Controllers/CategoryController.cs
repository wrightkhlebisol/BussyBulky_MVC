using BussyBulkyWeb.Data;
using BussyBulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BussyBulkyWeb.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
		{
			List<Category> objCategoryList = _db.Categories.ToList();
			return View(objCategoryList);
		}
		public IActionResult Create() 
		{ 
			return View();
		}
		[HttpPost, ActionName("Create")]
		public IActionResult Create(Category obj)
		{ 
			if (obj.Name == obj.DisplayOrder.ToString()) 
			{
				ModelState.AddModelError("name", "The Display Order cannot exactly match the Name");
			}
			if (ModelState.IsValid) 
			{
				_db.Categories.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Category created successfully";
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Edit(int? id)
		{
			if(id==null || id == 0) 
			{
				return NotFound();
			}

			//Category? categoryFromDb = _db.Categories.Find(id);
			Category? categoryFromDb = _db.Categories.FirstOrDefault(u=>u.Id == id);
			//Category? categoryFromDb = _db.Categories.Where(u=>u.Id == id).FirstOrDefault();

			if (categoryFromDb == null)
			{
				return NotFound();
			}
			
			return View(categoryFromDb);
		}
		[HttpPost, ActionName("Edit")]
		public IActionResult Edit(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "The Display Order cannot exactly match the Name");
			}
			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Category update dsuccessfully";
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Category? categoryFromDb = _db.Categories.FirstOrDefault(u => u.Id == id);
			
			if (categoryFromDb == null)
			{
				return NotFound();
			}

			return View(categoryFromDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? id)
		{
			Category? obj = _db.Categories.FirstOrDefault(c => c.Id == id);
			if (obj == null) 
			{ 
				return NotFound();
			}
			_db.Categories.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index");
		}
	}
}
