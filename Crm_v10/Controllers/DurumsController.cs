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
    public class DurumsController : Controller
    {
        private Crmv10DB db = new Crmv10DB();

        // GET: Durums
        public ActionResult Index()
        {
            return View(db.Durum.Where(x => x.GosterimDurumu != "0").ToList());
        }

        // GET: Durums/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Durum durum = db.Durum.Find(id);
                if (durum == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(durum);
            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // GET: Durums/Create
        public ActionResult Create()
        {
            if (Session["KullaniciID"] != null)
            {
                return View();
            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // POST: Durums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DurumAdi,GosterimDurumu")] Durum durum)
        {
            if (ModelState.IsValid)
            {
                db.Durum.Add(durum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(durum);
        }

        // GET: Durums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Durum durum = db.Durum.Find(id);
                if (durum == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(durum);
            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // POST: Durums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DurumAdi,GosterimDurumu")] Durum durum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(durum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(durum);
        }

        // GET: Durums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Durum durum = db.Durum.Find(id);
                if (durum == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(durum);
            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // POST: Durums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Durum durum = db.Durum.Find(id);
            db.Durum.Remove(durum);
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
