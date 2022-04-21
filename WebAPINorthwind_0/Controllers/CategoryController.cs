using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPINorthwind_0.DesignPatterns.SingletonPattern;
using WebAPINorthwind_0.DTOClasses;
using WebAPINorthwind_0.Models;

namespace WebAPINorthwind_0.Controllers
{
    public class CategoryController : ApiController
    {
        //Burada ID'ye göre CategoryDTO ve List<CategoryDTO> döndürme metotları (bu bilgileri veritabanından alacak) ve CategoryCrud işlemlerini saglayacak action'lari yazın...

        NorthwindEntities _db;

        public CategoryController()
        {
            _db = DBTool.DBInstance;
        }

        [HttpGet]
        public List<CategoryDTO> ListCategories()
        {
            return _db.Categories.Select(x => new CategoryDTO
            {
                ID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();

            
        }

        [HttpGet]
        public CategoryDTO BringCategoryByID(int id)
        {
            return _db.Categories.Where(x => x.CategoryID == id).Select(x => new CategoryDTO
            {
                ID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).FirstOrDefault();
        }




    }
}
