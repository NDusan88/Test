using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UlazniTest.Models;

namespace UlazniTest.Controllers
{
    public class ProizvodController : Controller
    {
        private readonly Test_Baza_Context db = new Test_Baza_Context();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        //Retun a list of product's
        [HttpGet]
        public ActionResult List()
        {
            return View(db.Products.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Create product's
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                    ViewBag.Error = e.InnerException;
                }
            }

            return View("Index");
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product proizvod = db.Products.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod
);
        }


        //Edit Product's
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                    ViewBag.Error = e.InnerException;
                }
            }

            return View("Index");
        }



        //Delete Product's
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }



        //Confirm if you want to delete product
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}