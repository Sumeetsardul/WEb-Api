using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Car.Models;

namespace Mvc_Car.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            using (mvcar mv = new mvcar())
            {
                return View(mv.Mains.ToList());//it read the data from database
            }
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            using (mvcar mv = new mvcar())
            {
                return View(mv.Mains.Where(x => x.Id == id).FirstOrDefault());//it shows the details
            }
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(Main  mains)
        {
            try
            {
                using (mvcar mv = new mvcar())//this creats the data in the database
                {
                    mv.Mains.Add(mains);
                    mv.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            using (mvcar mv = new mvcar())
            {
                return View(mv.Mains.Where(x => x.Id == id).FirstOrDefault());//this edit the data in the database 
            }
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Main mains)
        {
            try
            {
                using (mvcar mv = new mvcar())
                {
                    mv.Entry(mains).State = EntityState.Modified;
                    mv.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int id)
        {
            using (mvcar mv = new mvcar())
            {
                return View(mv.Mains.Where(x => x.Id == id).FirstOrDefault());//this delete the data in the databse
            }
        }

        // POST: Car/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (mvcar mv = new mvcar())
                {
                    Main  car= mv.Mains.Where(x => x.Id == id).FirstOrDefault();
                    mv.Mains.Remove(car);
                    mv.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
