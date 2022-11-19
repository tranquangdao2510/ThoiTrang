using API.Models.Entity;
using API.Responsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTAPI.Controllers
{
    public class ProductDetailController : Controller
    {
        private IRepository<ProductDetail> productDetail;
        private IRepository<Product> product;
        private IRepository<Size> size;
        private IRepository<Color> colol;

        public ProductDetailController()
        {
            product = new Repository<Product>();
            size = new Repository<Size>();
            colol = new Repository<Color>();
            productDetail = new Repository<ProductDetail>();

        }
        // GET: Size
        public ActionResult Index()
        {
            return View(productDetail.GetAll());
        }

        // GET: Size/Create
        public ActionResult Create()
        {
            ViewBag.size = size.GetAll();
            ViewBag.colol = colol.GetAll();
            ViewBag.product = product.GetAll();
            return View();
        }

        // POST: Size/Create
        [HttpPost]
        public ActionResult Create(ProductDetail input)
        {
            try
            {
                // TODO: Add insert logic here
                productDetail.Add(input);
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
            ViewBag.size = size.GetAll();
            ViewBag.colol = colol.GetAll();
            ViewBag.product = product.GetAll();
            return View(productDetail.GetById(id));
        }

        // POST: Size/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductDetail input)
        {
            try
            {
                // TODO: Add update logic here
                productDetail.Edit(input);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(input);
            }
        }



        public ActionResult Delete(int id)
        {
            productDetail.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
