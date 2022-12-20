using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prjCustumer.Models;

namespace prjCustumer.Controllers
{
    public class HomeController : Controller
    {
        dbCustomerEntities db = new dbCustomerEntities();
        
        // GET: Home
        public ActionResult Index()
        {
            var customer = db.tCustomer.OrderBy(m => m.fId).ToList();
            return View(customer);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tCustomer vCustomer)
        {
            db.tCustomer.Add(vCustomer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int fId)
        {
            var customer = db.tCustomer.Where(m => m.fId == fId).FirstOrDefault();
            db.tCustomer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int fId)
        {
            var customer = db.tCustomer.Where(m => m.fId == fId).FirstOrDefault();
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(tCustomer vCustomer)
        {
            int fId = vCustomer.fId;
            var customer = db.tCustomer.Where(m => m.fId == fId).FirstOrDefault();
            customer.fName = vCustomer.fName;
            customer.fPhone = vCustomer.fPhone;
            customer.fEmail = vCustomer.fEmail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}