using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using salamAliTask.Data;
using salamAliTask.Models;
using System.Diagnostics;
using System.Text;

namespace salamAliTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
      public enum Lang
        {
            en,
            ar
        }
        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
            
        }



       
       
        //get list of products
        [HttpGet]
        public IActionResult getListOfProducts(Lang language)
        {
            IEnumerable<CustomProduct> customProducts;
            return Json(_db.Products.Where(e => DateTime.Now <= e.StartDate.AddHours(e.Duration)
            ).Select(u => new CustomProduct
            {
                Id=u.Id,
                Name= language==Lang.en?u.EName:u.AName,
                CreationDate=u.CreationDate,
                StartDate=u.StartDate,
                Duration=u.Duration,
                Price=u.Price,
                CatId=u.CatId,
                CustomFields=u.CustomFields
                

            }).ToArray());



            }
           
        

        //Get By id
        [HttpGet]
        public IActionResult getById(int id,Lang language)
        {
            var productFromDb = _db.Products.Where(u => u.Id == id).Select(
                u => new CustomProduct
                {
                    Id = u.Id,
                    Name = language == Lang.en ? u.EName : u.AName,
                    CreationDate = u.CreationDate,
                    StartDate = u.StartDate,
                    Duration = u.Duration,
                    Price = u.Price,
                    CatId = u.CatId,
                    CustomFields=u.CustomFields
                }).Single();

            return Json(productFromDb);
            
        }

        //Post
        
        [HttpPost]
        
        public IActionResult CreateProduct([FromBody]Product obj)
        {
             
            _db.Products.Add(obj);
            _db.SaveChanges();
            return Json(obj);

        }


       
        //edit product
        [HttpPut]
        
        public IActionResult Edit(int id,[FromBody]Product productToEdit)
        {
            var item = _db.Products.Find(id);
            if (item == null)
            {
                return Content("not found");
                
            }
            item.Id = id;
            item.EName = productToEdit.EName;
            item.AName = productToEdit.AName;
            item.CreationDate = DateTime.Now;
            item.StartDate = productToEdit.StartDate;
            item.Duration = productToEdit.Duration;
            item.Price = productToEdit.Price;
            item.CatId = productToEdit.CatId;
            item.CustomFields = productToEdit.CustomFields;


            try
            {
                _db.SaveChanges();

            }

            catch(DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e);
            }
                return Json(item);
            }
           
           
         

        
        //Post
        [HttpDelete]
        
        public IActionResult DeleteProduct(int id)
        {
           var obj= _db.Products.Find(id);
            if (obj != null)
            {
                _db.Products.Remove(obj);
                _db.SaveChanges();
                return Content("the product with id = " + id + " was deleted");
            }
            else
            {
                return Content("product not found");
            }
        }
    }
}
