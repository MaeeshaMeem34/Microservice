using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Database;
using ProductMicroservice.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMicroservice.Controllers
{
    [Route("/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        DatabaseContext db;
        public ProductController()
        {
            db = new DatabaseContext();
        }

        
        [HttpGet]
        [Route("/product/list")]
       public IEnumerable<Product> Get()
        {
            return db.products.ToList();
        }
        

      

       
        [HttpPost]
        [Route("/product/add")]
        public  IActionResult Post([FromBody] Product model)
        {
            try
            {
                if (db.products.Any(c => c.name == model.name))
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                else
                {
                    Category category = db.categories.Find(model.categoryId);
                    model.categoryName = category.categoryName;
                    model.averageRating = 0;
                    model.numberOfRaters = 0;
                    db.products.Add(model);
                    db.SaveChanges();
                    return StatusCode(StatusCodes.Status201Created, model);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }


        }

        [HttpPost]
        [Route("product/updateRating")]
        public IActionResult Update([FromBody] Product model)
        {
            try
            {

                Product data = db.products.Find(model.id);
                data.averageRating = model.averageRating;
                data.numberOfRaters = model.numberOfRaters;                  
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }


        }

        [HttpDelete("/product/remove/{id}")]
        public IActionResult Delete(int Id)
        {


            try {
                
                db.products.Remove(db.products.Find(Id));
                db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch(Exception ex) {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("/product/updateCategory")]
        public IActionResult UpdateCategory([FromBody] Product model)
        {
            try
            {

                Product data = db.products.Find(model.id);
                Category category = db.categories.Find(model.categoryId);
                data.categoryId = model.categoryId;
                data.categoryName = category.categoryName;
                data.averageRating = 0;
                data.numberOfRaters = 0;
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }


        }
    }
}
