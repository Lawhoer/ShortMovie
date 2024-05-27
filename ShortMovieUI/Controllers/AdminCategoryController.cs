﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public AdminCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var movies = _categoryService.TGetList();
            return View(movies);
        }


        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category, IFormFile CategoryImage)
        {
            if (CategoryImage != null && CategoryImage.Length > 0)
            {
                var fileName = Path.GetFileName(CategoryImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    CategoryImage.CopyTo(stream);
                }

                category.CategoryImage = "/images/" + fileName; 
            }

            _categoryService.TAdd(category);
            return RedirectToAction("Index", "AdminCategory");
        }

        public IActionResult DeleteCategory(int id)
        {
            var values = _categoryService.TGetByID(id);
            _categoryService.TDelete(values);
            return RedirectToAction("Index", "AdminCategory");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var values = _categoryService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category, IFormFile CategoryImage)
        {
            var existingCategory = _categoryService.TGetByID(category.CategoryID);

            if (CategoryImage != null && CategoryImage.Length > 0)
            {
                var fileName = Path.GetFileName(CategoryImage.FileName);
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/categories");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    CategoryImage.CopyTo(stream);
                }

                category.CategoryImage = "/images/categories/" + fileName; 
            }
            else
            {
                category.CategoryImage = existingCategory.CategoryImage;
            }

            _categoryService.TUpdate(category);
            return RedirectToAction("Index", "AdminCategory");
        }
    }
}
