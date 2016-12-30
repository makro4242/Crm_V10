using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crm_v10.Models;

namespace Crm_v10.Controllers
{
    public class SektorsController : Controller
    {
        private Crmv10DB db = new Crmv10DB();

        public ActionResult Index()
        {
            if (Session["KullaniciID"] != null)
            {
                return View(db.Sektor.Where(x => x.GosterimDurumu != "0").ToList());
            }

            else return RedirectToAction("LoginPage", "Home");

        }
        // GET: Sektors/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Sektor sektor = db.Sektor.Find(id);
                if (sektor == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(sektor);
            }

            else return RedirectToAction("LoginPage", "Home");
        }
        // GET: Sektors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sektors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SektorAd")] Sektor sektor)
        {
            if (ModelState.IsValid)
            {
                db.Sektor.Add(sektor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sektor);
        }

        // GET: Sektors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Sektor sektor = db.Sektor.Find(id);
                if (sektor == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(sektor);
            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // POST: Sektors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SektorAd")] Sektor sektor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sektor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sektor);
        }

        // GET: Sektors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Sektor sektor = db.Sektor.Find(id);
                if (sektor == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(sektor);
            }
            else return RedirectToAction("LoginPage", "Home");
        }


        // POST: Sektors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sektor sektor = db.Sektor.Find(id);
            //db.Sektor.Remove(sektor);
            sektor.GosterimDurumu = "0";
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
