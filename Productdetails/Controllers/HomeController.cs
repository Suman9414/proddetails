using Productdetails.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Productdetails.Controllers
{
    public class HomeController : Controller
    {
        SignupForm_TestEntities db = new SignupForm_TestEntities();
        //public ActionResult Index()
        //{
        //    var list = db.Products.ToList();
        //    return View(list);
        //}
        public ActionResult Index()
        {
            SignupForm_TestEntities db = new SignupForm_TestEntities();
            List<Product> customers = db.Products.ToList();
            if (customers.Count == 0)
            {
                customers.Add(new Product());
            }

            return View(customers);
        }

    [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult Create(Product pro)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pro);
        }

        // GET: employees/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product pro = db.Products.Find(id);
            if (pro == null)
            {
                return HttpNotFound();
            }
            return View(pro);
        }

        // POST: employees/Edit
        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pro);
        }

        // GET: employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product pro = db.Products.Find(id);
            if (pro == null)
            {
                return HttpNotFound();
            }
            return View(pro);
        }

        // GET: employees/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product pro = db.Products.Find(id);
            if (pro == null)
            {
                return HttpNotFound();
            }
            return View(pro);
        }

        // POST: employees/Delete
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product employee = db.Products.Find(id);
            db.Products.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}