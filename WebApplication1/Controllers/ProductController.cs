using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        ProductDbContext db = new ProductDbContext();



        // GET: Product
        public ActionResult Index()
        {
            // return (productList);
            return View(db.products.ToList());
        }

        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            product.id = db.products.Count() + 1;
            db.products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            Product product = db.products.Where(x => x.id == id).FirstOrDefault();
            if (product != null)
            {
                return View(product);
            }
            else
            {
                ViewBag.msg = "Record with " + id.ToString() + " is not found";
                return View();
            } }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            Product tempproduct = db.products.Where(x => x.id == product.id).FirstOrDefault();

            foreach (Product temp in db.products)
            {
                if (temp.id == tempproduct.id)
                {
                    temp.description = product.description;
                    temp.QtyInStock = product.QtyInStock;
                }

            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Product product = db.products.Where(x => x.id == id).FirstOrDefault();
            if (product != null)
            {
                return View(product);
            }
            else
            {
                ViewBag.msg = "Record with " + id.ToString() + " is not found";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            Product tempproduct = db.products.Where(x => x.id == product.id).FirstOrDefault();
            db.products.Remove(tempproduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    } }

