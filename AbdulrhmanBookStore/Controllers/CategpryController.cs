using Microsoft.AspNetCore.Mvc;
using AbdulrhmanBooks.DataAccess.Repository.IRepository; // Add this if IUnitOfWork is not recognized
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbdulrhmanBookStore.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller // Renamed from CategpryController to CategoryController
    {
        private readonly IUnitOfWork _unitOfWork; // Renamed from unitOfWork to _unitOfWork

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; // Fixed the assignment (use = instead of -)
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj });
        }
        #endregion
    }
}
