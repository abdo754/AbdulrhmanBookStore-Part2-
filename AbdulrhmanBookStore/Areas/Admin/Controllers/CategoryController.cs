using Microsoft.AspNetCore.Mvc;
using AbdulrhmanBooks.DataAccess.Repository;
using AbdulrhmanBooks.DataAccess.Repository.IRepository; // Ensure the correct namespace is used for IUnitOfWork
using AbdulrhmanBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbdulrhmanBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork; // Ensure the field name matches the constructor parameter

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; // Correctly assign the parameter to the field

        }

        public IActionResult Index() // Method names in C# are typically PascalCase
        {
            return View();
        }



        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id == null)
            {
                return View(category);
            }
            category = _unitOfWork.Category.Get(id.GetValueOrDefault());
            if(category== null)
            {
                return NotFound();
            }
            return View(category);
        }

        // use HTTP POST to define the post-action method
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(Category category)
        {
 
                if(ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    _unitOfWork.Category.Add(category);
                 
                }
                else
                {
                    _unitOfWork.Category.Update(category);
               
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));

            }
       
        return View(category);
    }

        //API calls here
        #region
        [HttpGet]
        public IActionResult GetAll()
        {
            //return not found
            var allObj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Category.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleteing" });
            }
            _unitOfWork.Category.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
            
        }
        #endregion
    }

}

