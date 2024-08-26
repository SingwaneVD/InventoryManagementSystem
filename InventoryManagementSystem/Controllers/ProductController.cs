using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<Product> list = db.Products.OrderByDescending(x=>x.Id).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();


        }

        [HttpPost]
        public ActionResult CreateProduct(Product prod)
        {
            db.Products.Add(prod);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");

        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            Product pr = db.Products.Where(x=> x.Id == id).SingleOrDefault();
            return View(pr);
        }

        [HttpPost]
        public ActionResult UpdateProduct(int id,Product prod)
        {
            Product pr = db.Products.Where(x => x.Id == id).SingleOrDefault();
            pr.Product_name = prod.Product_name;
            pr.Product_quantity = prod.Product_quantity;
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
    }
}