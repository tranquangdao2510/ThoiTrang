using API.Models.Entity;
using API.Responsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTAPI.Controllers
{
   
    public class ProductController : Controller
    {
        private IRepository<Product> product;
        private IRepository<Category> category;
        public ProductController()
        {
            product = new Repository<Product>();
            category = new Repository<Category>();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(product.GetAll());
        }

        // GET: Size/Create
        public ActionResult Create()
        {
            ViewBag.category = category.GetAll();
            return View();
        }

        // POST: Size/Create
        [HttpPost]
        public ActionResult Create(Product input)
        {
            try
            {
                // TODO: Add insert logic here
                product.Add(input);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(input);
            }
        }

        // GET: Size/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.category = category.GetAll();
            return View(product.GetById(id));
        }

        // POST: Size/Edit/5
        [HttpPost]
        public ActionResult Edit(Product input)
        {
            try
            {
                // TODO: Add update logic here
                product.Edit(input);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(input);
            }
        }



        public ActionResult Delete(int id)
        {
            product.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
