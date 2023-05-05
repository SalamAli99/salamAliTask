using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using salamAliTask.Data;
using salamAliTask.Models;
using static salamAliTask.Controllers.ProductsController;

namespace salamAliTask.Controllers
{
    public class CategoryController : Controller
    {
        public enum Lang
        {
            en,
            ar
        }

        private readonly ApplicationDbContext _db;
      
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
           

        }
        //get list of categories
        public IActionResult GetAll(Lang language)
        {

            IEnumerable<CustomCat> customCat;
            return Json(_db.Categories.Select(u => new CustomCat
            {
                CatId = u.CatId,
                Name = language == Lang.en ? u.CatEName : u.CatAName,
               


            }).ToArray());
           
        }

        //get category by id
        public IActionResult Index(int catId)
        {

            var categoryFromDb = _db.Products.Where(x => x.CatId==catId);
                
            
           
            return Json(categoryFromDb);
        }


        [HttpDelete]
        
        public IActionResult DeleteCat(int catId)
        {
           
            var categoryFromDb = _db.Products.Where(x => x.CatId==catId);
            if ( categoryFromDb ==null)

            {
                var obj = _db.Categories.Find(catId);
                if (obj == null)
                {
                    return Content("there is no categories!!");
                }
                else
                {
                    _db.Categories.Remove(obj);
                    _db.SaveChanges();
                    return Json(obj);
                }
              

            }
            else
            {
                return Content("can not delete because the category containes products");
            }

        }
    }
}
