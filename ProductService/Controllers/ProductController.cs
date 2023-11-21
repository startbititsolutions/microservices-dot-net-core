using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Model;
using System.Security.Cryptography.X509Certificates;

namespace ProductService.Controllers
{
 
    [ApiController]
    [Route("api/products/")]
    public class ProductController : Controller
    {
        /* private readonly */
        private readonly ApplicationDbContext _context;
        public  ProductController(ApplicationDbContext _context)
        {
           this._context = _context;
        }
        // GET: ProductController
        [HttpGet]
        [Route("All")]
        public IEnumerable<Product> Index()
        {
            return  _context.products.ToList();
        }

        // GET: ProductController/Details/5
        [HttpGet]
       [ Route("Get/{id}")]
        public IActionResult Details(int id)
        {
            return Ok(_context.products.ToList().Where(x => x.Id == id).FirstOrDefault());
        }



        // POST: ProductController/Create
        [Route("Add")]
        [HttpPost]

        public IActionResult Create(Product product)
        {
            try
            {
               _context.products.Add(product);
                _context.SaveChanges();
                return Ok("Product Added Succesfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Ok(ex.ToString());
            }
        }

        // GET: ProductController/Edit/5
      

        // POST: ProductController/Edit/5
        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                var p = _context.products.Where(x => x.Id == id).FirstOrDefault();
                if (p != null)
                {
                    p.Price = product.Price;
                    p.Name= product.Name;
                    p.Id = id;
                    p.Description  = product.Description;
                    p.Type = product.Type;
                    _context.products.Update(p);
                    _context.SaveChanges();
                    return Ok("product updated");
                }
                else
                {
                    return Ok("Product not found");

                }
           
            }
            catch(Exception ex)
            { 
                Console.WriteLine(ex.ToString());
                return Ok(ex.ToString());
            }
        }

        
        [Route("Delete/{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {

            try{
                var p = _context.products.Where(x=>x.Id==id).FirstOrDefault();
                _context.products.Remove(p); _context.SaveChanges();
                return Ok("Product Deleted Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            return Ok(ex.ToString());
            }
        }

     
        
    }
}
