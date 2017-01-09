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
    public class AksiyonSecimsController : Controller
    {
        private Crmv10DB db = new Crmv10DB();

        // GET: AksiyonSecims
        public ActionResult Index()
        {
            return View(db.AksiyonSecim.Where(x => x.GosterimDurumu != "0").ToList());
        }

        // GET: AksiyonSecims/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                AksiyonSecim aksiyonSecim = db.AksiyonSecim.Find(id);
                if (aksiyonSecim == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(aksiyonSecim);
            }

            else return RedirectToAction("LoginPage", "Home");
        }
        // GET: AksiyonSecims/Create
        public ActionResult Create()
        {
            if (Session["KullaniciID"] != null)
            {
                return View();
            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // POST: AksiyonSecims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AksiyonAdi,GosterimDurumu")] AksiyonSecim aksiyonSecim)
        {
            if (ModelState.IsValid)
            {
                db.AksiyonSecim.Add(aksiyonSecim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aksiyonSecim);
        }

        // GET: AksiyonSecims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                AksiyonSecim aksiyonSecim = db.AksiyonSecim.Find(id);
                if (aksiyonSecim == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(aksiyonSecim);
            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // POST: AksiyonSecims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AksiyonAdi,GosterimDurumu")] AksiyonSecim aksiyonSecim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aksiyonSecim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aksiyonSecim);
        }

        // GET: AksiyonSecims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                AksiyonSecim aksiyonSecim = db.AksiyonSecim.Find(id);
                if (aksiyonSecim == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(aksiyonSecim);
            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // POST: AksiyonSecims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AksiyonSecim aksiyonSecim = db.AksiyonSecim.Find(id);
            aksiyonSecim.GosterimDurumu = "0";
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
