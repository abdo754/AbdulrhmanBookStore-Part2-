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

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allCategories = _unitOfWork.Category.GetAll();
            return Json(new { data = allCategories }); // Return the data as JSON
        }
        #endregion

    }
}
