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
    public class AksiyonsController : Controller
    {
        private Crmv10DB db = new Crmv10DB();

        // GET: Aksiyons
        public ActionResult Index()
        {
            if (Session["KullaniciID"] != null)
            {
                var aksiyon = db.Aksiyon.Include(a => a.GorevEkleme);
                return View(aksiyon.ToList());
            }

            else return RedirectToAction("LoginPage", "Home");
        }
        // GET: Aksiyons/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Aksiyon aksiyon = db.Aksiyon.Find(id);
                if (aksiyon == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(aksiyon);
            }
            else return RedirectToAction("LoginPage", "Home");
        }
        // GET: Aksiyons/Create
        public ActionResult Create()
        {
            if (Session["KullaniciID"] != null)
            {
                var Saat = new[]
                 {
                  new SelectListItem(){Value = "08:00", Text= "08:00"},
                  new SelectListItem(){Value = "08:15", Text= "08:15"},
                  new SelectListItem(){Value = "08:30", Text= "08:30"},
                  new SelectListItem(){Value = "08:45", Text= "08:45"},
                  new SelectListItem(){Value = "09:00", Text= "09:00"},
                  new SelectListItem(){Value = "09:15", Text= "09:15"},
                  new SelectListItem(){Value = "09:30", Text= "08:30"},
                  new SelectListItem(){Value = "09:45", Text= "09:45"},
                  new SelectListItem(){Value = "10:00", Text= "10:00"},
                  new SelectListItem(){Value = "10:15", Text= "10:15"},
                  new SelectListItem(){Value = "10:30", Text= "10:30"},
                  new SelectListItem(){Value = "10:45", Text= "10:45"},
                  new SelectListItem(){Value = "11:00", Text= "11:00"},
                  new SelectListItem(){Value = "11:15", Text= "11:15"},
                  new SelectListItem(){Value = "11:30", Text= "11:30"},
                  new SelectListItem(){Value = "11:45", Text= "11:45"},
                  new SelectListItem(){Value = "12:00", Text= "12:00"},
                  new SelectListItem(){Value = "12:15", Text= "12:15"},
                  new SelectListItem(){Value = "12:30", Text= "12:30"},
                  new SelectListItem(){Value = "12:45", Text= "12:45"},
                  new SelectListItem(){Value = "13:00", Text= "13:00"},
                  new SelectListItem(){Value = "13:15", Text= "13:15"},
                  new SelectListItem(){Value = "13:30", Text= "13:30"},
                  new SelectListItem(){Value = "13:45", Text= "13:45"},
                  new SelectListItem(){Value = "14:00", Text= "14:00"},
                  new SelectListItem(){Value = "14:15", Text= "14:15"},
                  new SelectListItem(){Value = "14:30", Text= "14:30"},
                  new SelectListItem(){Value = "14:45", Text= "14:45"},
                  new SelectListItem(){Value = "15:00", Text= "15:00"},
                  new SelectListItem(){Value = "15:15", Text= "15:15"},
                  new SelectListItem(){Value = "15:30", Text= "15:30"},
                  new SelectListItem(){Value = "15:45", Text= "15:45"},
                  new SelectListItem(){Value = "16:00", Text= "16:00"},
                  new SelectListItem(){Value = "16:15", Text= "16:15"},
                  new SelectListItem(){Value = "16:30", Text= "16:30"},
                  new SelectListItem(){Value = "16:45", Text= "16:45"},
                  new SelectListItem(){Value = "17:00", Text= "17:00"},
                  new SelectListItem(){Value = "17:15", Text= "17:15"},
                  new SelectListItem(){Value = "17:30", Text= "17:30"},
                  new SelectListItem(){Value = "17:45", Text= "17:45"},
                  new SelectListItem(){Value = "18:00", Text= "18:00"},
                  new SelectListItem(){Value = "18:15", Text= "18:15"},
                  new SelectListItem(){Value = "18:30", Text= "18:30"},
                  new SelectListItem(){Value = "18:45", Text= "18:45"},
                  new SelectListItem(){Value = "19:00", Text= "19:00"},
                 };
                var AksiyonSecim = new[]
                 {
                 new SelectListItem(){Value = "Telefon", Text= "Telefon"},
                 new SelectListItem(){Value = "Mail", Text= "Mail"},
                 new SelectListItem(){Value = "Yüzyüze Görüşme", Text= "Yüzyüze Görüşme"},
                 };
                ViewBag.Saat = Saat;
                ViewBag.AksiyonSecim = AksiyonSecim;
                ViewBag.GorevEklemeID = new SelectList(db.GorevEkleme, "ID", "Aciklama");
                return View();
            }

            else return RedirectToAction("LoginPage", "Home");
        }
        // POST: Aksiyons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tarih,Saat,GorevEklemeID,AksiyonSecim,AksiyonNot,Ekler")] Aksiyon aksiyon)
        {
            if (ModelState.IsValid)
            {
                db.Aksiyon.Add(aksiyon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var Saat = new[]
                 {
                  new SelectListItem(){Value = "08:00", Text= "08:00"},
                  new SelectListItem(){Value = "08:15", Text= "08:15"},
                  new SelectListItem(){Value = "08:30", Text= "08:30"},
                  new SelectListItem(){Value = "08:45", Text= "08:45"},
                  new SelectListItem(){Value = "09:00", Text= "09:00"},
                  new SelectListItem(){Value = "09:15", Text= "09:15"},
                  new SelectListItem(){Value = "09:30", Text= "08:30"},
                  new SelectListItem(){Value = "09:45", Text= "09:45"},
                  new SelectListItem(){Value = "10:00", Text= "10:00"},
                  new SelectListItem(){Value = "10:15", Text= "10:15"},
                  new SelectListItem(){Value = "10:30", Text= "10:30"},
                  new SelectListItem(){Value = "10:45", Text= "10:45"},
                  new SelectListItem(){Value = "11:00", Text= "11:00"},
                  new SelectListItem(){Value = "11:15", Text= "11:15"},
                  new SelectListItem(){Value = "11:30", Text= "11:30"},
                  new SelectListItem(){Value = "11:45", Text= "11:45"},
                  new SelectListItem(){Value = "12:00", Text= "12:00"},
                  new SelectListItem(){Value = "12:15", Text= "12:15"},
                  new SelectListItem(){Value = "12:30", Text= "12:30"},
                  new SelectListItem(){Value = "12:45", Text= "12:45"},
                  new SelectListItem(){Value = "13:00", Text= "13:00"},
                  new SelectListItem(){Value = "13:15", Text= "13:15"},
                  new SelectListItem(){Value = "13:30", Text= "13:30"},
                  new SelectListItem(){Value = "13:45", Text= "13:45"},
                  new SelectListItem(){Value = "14:00", Text= "14:00"},
                  new SelectListItem(){Value = "14:15", Text= "14:15"},
                  new SelectListItem(){Value = "14:30", Text= "14:30"},
                  new SelectListItem(){Value = "14:45", Text= "14:45"},
                  new SelectListItem(){Value = "15:00", Text= "15:00"},
                  new SelectListItem(){Value = "15:15", Text= "15:15"},
                  new SelectListItem(){Value = "15:30", Text= "15:30"},
                  new SelectListItem(){Value = "15:45", Text= "15:45"},
                  new SelectListItem(){Value = "16:00", Text= "16:00"},
                  new SelectListItem(){Value = "16:15", Text= "16:15"},
                  new SelectListItem(){Value = "16:30", Text= "16:30"},
                  new SelectListItem(){Value = "16:45", Text= "16:45"},
                  new SelectListItem(){Value = "17:00", Text= "17:00"},
                  new SelectListItem(){Value = "17:15", Text= "17:15"},
                  new SelectListItem(){Value = "17:30", Text= "17:30"},
                  new SelectListItem(){Value = "17:45", Text= "17:45"},
                  new SelectListItem(){Value = "18:00", Text= "18:00"},
                  new SelectListItem(){Value = "18:15", Text= "18:15"},
                  new SelectListItem(){Value = "18:30", Text= "18:30"},
                  new SelectListItem(){Value = "18:45", Text= "18:45"},
                  new SelectListItem(){Value = "19:00", Text= "19:00"},
                 };
            var AksiyonSecim = new[]
             {
                 new SelectListItem(){Value = "Telefon", Text= "Telefon"},
                 new SelectListItem(){Value = "Mail", Text= "Mail"},
                 new SelectListItem(){Value = "Yüzyüze Görüşme", Text= "Yüzyüze Görüşme"},
                 };
            ViewBag.Saat = Saat;
            ViewBag.AksiyonSecim = AksiyonSecim;
            ViewBag.GorevEklemeID = new SelectList(db.GorevEkleme, "ID", "Aciklama", aksiyon.GorevEklemeID);
            return View(aksiyon);
        }

        // GET: Aksiyons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Aksiyon aksiyon = db.Aksiyon.Find(id);
                if (aksiyon == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                var Saat = new[]
                 {
                  new SelectListItem(){Value = "08:00", Text= "08:00"},
                  new SelectListItem(){Value = "08:15", Text= "08:15"},
                  new SelectListItem(){Value = "08:30", Text= "08:30"},
                  new SelectListItem(){Value = "08:45", Text= "08:45"},
                  new SelectListItem(){Value = "09:00", Text= "09:00"},
                  new SelectListItem(){Value = "09:15", Text= "09:15"},
                  new SelectListItem(){Value = "09:30", Text= "08:30"},
                  new SelectListItem(){Value = "09:45", Text= "09:45"},
                  new SelectListItem(){Value = "10:00", Text= "10:00"},
                  new SelectListItem(){Value = "10:15", Text= "10:15"},
                  new SelectListItem(){Value = "10:30", Text= "10:30"},
                  new SelectListItem(){Value = "10:45", Text= "10:45"},
                  new SelectListItem(){Value = "11:00", Text= "11:00"},
                  new SelectListItem(){Value = "11:15", Text= "11:15"},
                  new SelectListItem(){Value = "11:30", Text= "11:30"},
                  new SelectListItem(){Value = "11:45", Text= "11:45"},
                  new SelectListItem(){Value = "12:00", Text= "12:00"},
                  new SelectListItem(){Value = "12:15", Text= "12:15"},
                  new SelectListItem(){Value = "12:30", Text= "12:30"},
                  new SelectListItem(){Value = "12:45", Text= "12:45"},
                  new SelectListItem(){Value = "13:00", Text= "13:00"},
                  new SelectListItem(){Value = "13:15", Text= "13:15"},
                  new SelectListItem(){Value = "13:30", Text= "13:30"},
                  new SelectListItem(){Value = "13:45", Text= "13:45"},
                  new SelectListItem(){Value = "14:00", Text= "14:00"},
                  new SelectListItem(){Value = "14:15", Text= "14:15"},
                  new SelectListItem(){Value = "14:30", Text= "14:30"},
                  new SelectListItem(){Value = "14:45", Text= "14:45"},
                  new SelectListItem(){Value = "15:00", Text= "15:00"},
                  new SelectListItem(){Value = "15:15", Text= "15:15"},
                  new SelectListItem(){Value = "15:30", Text= "15:30"},
                  new SelectListItem(){Value = "15:45", Text= "15:45"},
                  new SelectListItem(){Value = "16:00", Text= "16:00"},
                  new SelectListItem(){Value = "16:15", Text= "16:15"},
                  new SelectListItem(){Value = "16:30", Text= "16:30"},
                  new SelectListItem(){Value = "16:45", Text= "16:45"},
                  new SelectListItem(){Value = "17:00", Text= "17:00"},
                  new SelectListItem(){Value = "17:15", Text= "17:15"},
                  new SelectListItem(){Value = "17:30", Text= "17:30"},
                  new SelectListItem(){Value = "17:45", Text= "17:45"},
                  new SelectListItem(){Value = "18:00", Text= "18:00"},
                  new SelectListItem(){Value = "18:15", Text= "18:15"},
                  new SelectListItem(){Value = "18:30", Text= "18:30"},
                  new SelectListItem(){Value = "18:45", Text= "18:45"},
                  new SelectListItem(){Value = "19:00", Text= "19:00"},
                 };
                var AksiyonSecim = new[]
                 {
                  new SelectListItem(){Value = "Telefon", Text= "Telefon"},
                  new SelectListItem(){Value = "Mail", Text= "Mail"},
                  new SelectListItem(){Value = "Yüzyüze Görüşme", Text= "Yüzyüze Görüşme"},
                 };
                ViewBag.Saat = Saat;
                ViewBag.AksiyonSecim = AksiyonSecim;
                ViewBag.GorevEklemeID = new SelectList(db.GorevEkleme, "ID", "Aciklama", aksiyon.GorevEklemeID);
                return View(aksiyon);
            }

            else return RedirectToAction("LoginPage", "Home");
        }
        // POST: Aksiyons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tarih,Saat,GorevEklemeID,AksiyonSecim,AksiyonNot,Ekler")] Aksiyon aksiyon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aksiyon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var Saat = new[]
                 {
                  new SelectListItem(){Value = "08:00", Text= "08:00"},
                  new SelectListItem(){Value = "08:15", Text= "08:15"},
                  new SelectListItem(){Value = "08:30", Text= "08:30"},
                  new SelectListItem(){Value = "08:45", Text= "08:45"},
                  new SelectListItem(){Value = "09:00", Text= "09:00"},
                  new SelectListItem(){Value = "09:15", Text= "09:15"},
                  new SelectListItem(){Value = "09:30", Text= "08:30"},
                  new SelectListItem(){Value = "09:45", Text= "09:45"},
                  new SelectListItem(){Value = "10:00", Text= "10:00"},
                  new SelectListItem(){Value = "10:15", Text= "10:15"},
                  new SelectListItem(){Value = "10:30", Text= "10:30"},
                  new SelectListItem(){Value = "10:45", Text= "10:45"},
                  new SelectListItem(){Value = "11:00", Text= "11:00"},
                  new SelectListItem(){Value = "11:15", Text= "11:15"},
                  new SelectListItem(){Value = "11:30", Text= "11:30"},
                  new SelectListItem(){Value = "11:45", Text= "11:45"},
                  new SelectListItem(){Value = "12:00", Text= "12:00"},
                  new SelectListItem(){Value = "12:15", Text= "12:15"},
                  new SelectListItem(){Value = "12:30", Text= "12:30"},
                  new SelectListItem(){Value = "12:45", Text= "12:45"},
                  new SelectListItem(){Value = "13:00", Text= "13:00"},
                  new SelectListItem(){Value = "13:15", Text= "13:15"},
                  new SelectListItem(){Value = "13:30", Text= "13:30"},
                  new SelectListItem(){Value = "13:45", Text= "13:45"},
                  new SelectListItem(){Value = "14:00", Text= "14:00"},
                  new SelectListItem(){Value = "14:15", Text= "14:15"},
                  new SelectListItem(){Value = "14:30", Text= "14:30"},
                  new SelectListItem(){Value = "14:45", Text= "14:45"},
                  new SelectListItem(){Value = "15:00", Text= "15:00"},
                  new SelectListItem(){Value = "15:15", Text= "15:15"},
                  new SelectListItem(){Value = "15:30", Text= "15:30"},
                  new SelectListItem(){Value = "15:45", Text= "15:45"},
                  new SelectListItem(){Value = "16:00", Text= "16:00"},
                  new SelectListItem(){Value = "16:15", Text= "16:15"},
                  new SelectListItem(){Value = "16:30", Text= "16:30"},
                  new SelectListItem(){Value = "16:45", Text= "16:45"},
                  new SelectListItem(){Value = "17:00", Text= "17:00"},
                  new SelectListItem(){Value = "17:15", Text= "17:15"},
                  new SelectListItem(){Value = "17:30", Text= "17:30"},
                  new SelectListItem(){Value = "17:45", Text= "17:45"},
                  new SelectListItem(){Value = "18:00", Text= "18:00"},
                  new SelectListItem(){Value = "18:15", Text= "18:15"},
                  new SelectListItem(){Value = "18:30", Text= "18:30"},
                  new SelectListItem(){Value = "18:45", Text= "18:45"},
                  new SelectListItem(){Value = "19:00", Text= "19:00"},
                 };
            var AksiyonSecim = new[]
             {
                 new SelectListItem(){Value = "Telefon", Text= "Telefon"},
                 new SelectListItem(){Value = "Mail", Text= "Mail"},
                 new SelectListItem(){Value = "Yüzyüze Görüşme", Text= "Yüzyüze Görüşme"},
                 };
            ViewBag.Saat = Saat;
            ViewBag.AksiyonSecim = AksiyonSecim;
            ViewBag.GorevEklemeID = new SelectList(db.GorevEkleme, "ID", "Aciklama", aksiyon.GorevEklemeID);
            return View(aksiyon);
        }

        // GET: Aksiyons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("_404", "Home");
            }
            Aksiyon aksiyon = db.Aksiyon.Find(id);
            if (aksiyon == null)
            {
                return RedirectToAction("_404", "Home");
            }
            return View(aksiyon);
        }

        // POST: Aksiyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["KullaniciID"] != null)
            {

                Aksiyon aksiyon = db.Aksiyon.Find(id);
                db.Aksiyon.Remove(aksiyon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else return RedirectToAction("LoginPage", "Home");
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
