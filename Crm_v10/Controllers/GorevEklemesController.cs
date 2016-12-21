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
    public class GorevEklemesController : Controller
    {
        private Crmv10DB db = new Crmv10DB();

        // GET: GorevEklemes
        public ActionResult Index()
        {
            var gorevEkleme = db.GorevEkleme.Include(g => g.Potansiyel).Include(g => g.SatisElemanlari);
            return View(gorevEkleme.ToList());
        }

        // GET: GorevEklemes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GorevEkleme gorevEkleme = db.GorevEkleme.Find(id);
            if (gorevEkleme == null)
            {
                return HttpNotFound();
            }
            return View(gorevEkleme);
        }

        // GET: GorevEklemes/Create
        public ActionResult Create()
        {
            var Oncelik = new[]
              {
               new SelectListItem(){Value = "Normal", Text= "Normal"},
               new SelectListItem(){Value = "Düşük", Text= "Düşük"},
               new SelectListItem(){Value = "Yuksek", Text= "Yuksek"},
               new SelectListItem(){Value = "Acil", Text= "Acil"},
            };
            var Durum = new[]
            {
               new SelectListItem(){Value = "Görüşme", Text= "Görüşme"},
               new SelectListItem(){Value = "Teklif", Text= "Teklif"},
               new SelectListItem(){Value = "Revize Teklif", Text= "Revize Teklif"},
               new SelectListItem(){Value = "Satış", Text= "Satış"},
               new SelectListItem(){Value = "Reddedildi", Text= "Reddedildi"},
            };
            ViewBag.Durum = Durum;
            ViewBag.Oncelik = Oncelik;
            ViewBag.PotansiyelID = new SelectList(db.Potansiyel, "ID", "PotansiyelUnvani");
            ViewBag.SatisElemaniID = new SelectList(db.SatisElemanlari, "ID", "SatisElemaniAdiSoyadi");
            return View();
        }

        // POST: GorevEklemes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Aciklama,Tarih,PotansiyelID,SatisElemaniID,TahminiTutar,GorevNot,Durum,Oncelik")] GorevEkleme gorevEkleme)
        {
            if (ModelState.IsValid)
            {
                db.GorevEkleme.Add(gorevEkleme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PotansiyelID = new SelectList(db.Potansiyel, "ID", "PotansiyelUnvani", gorevEkleme.PotansiyelID);
            ViewBag.SatisElemaniID = new SelectList(db.SatisElemanlari, "ID", "SatisElemaniAdiSoyadi", gorevEkleme.SatisElemaniID);
            return View(gorevEkleme);
        }

        // GET: GorevEklemes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GorevEkleme gorevEkleme = db.GorevEkleme.Find(id);
            if (gorevEkleme == null)
            {
                return HttpNotFound();
            }
            var Oncelik = new[]
            {
               new SelectListItem(){Value = "Normal", Text= "Normal"},
               new SelectListItem(){Value = "Düşük", Text= "Düşük"},
               new SelectListItem(){Value = "Yuksek", Text= "Yuksek"},
               new SelectListItem(){Value = "Acil", Text= "Acil"},
            };
            var Durum = new[]
              {
               new SelectListItem(){Value = "Görüşme", Text= "Görüşme"},
               new SelectListItem(){Value = "Teklif", Text= "Teklif"},
               new SelectListItem(){Value = "Revize Teklif", Text= "Revize Teklif"},
               new SelectListItem(){Value = "Satış", Text= "Satış"},
               new SelectListItem(){Value = "Reddedildi", Text= "Reddedildi"},
              };
            ViewBag.Durum = Durum;
            ViewBag.Oncelik = Oncelik;
            ViewBag.PotansiyelID = new SelectList(db.Potansiyel, "ID", "PotansiyelUnvani", gorevEkleme.PotansiyelID);
            ViewBag.SatisElemaniID = new SelectList(db.SatisElemanlari, "ID", "SatisElemaniAdiSoyadi", gorevEkleme.SatisElemaniID);
            return View(gorevEkleme);
        }

        // POST: GorevEklemes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Aciklama,Tarih,PotansiyelID,SatisElemaniID,TahminiTutar,GorevNot,Durum,Oncelik")] GorevEkleme gorevEkleme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gorevEkleme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PotansiyelID = new SelectList(db.Potansiyel, "ID", "PotansiyelUnvani", gorevEkleme.PotansiyelID);
            ViewBag.SatisElemaniID = new SelectList(db.SatisElemanlari, "ID", "SatisElemaniAdiSoyadi", gorevEkleme.SatisElemaniID);
            return View(gorevEkleme);
        }

        // GET: GorevEklemes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GorevEkleme gorevEkleme = db.GorevEkleme.Find(id);
            if (gorevEkleme == null)
            {
                return HttpNotFound();
            }
            return View(gorevEkleme);
        }

        // POST: GorevEklemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GorevEkleme gorevEkleme = db.GorevEkleme.Find(id);
            db.GorevEkleme.Remove(gorevEkleme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        Crmv10DB ctx = new Crmv10DB();
        public JsonResult KoduGetir()
        {
            string veri = "";
           
            var Sonuc = (from p in ctx.GorevEkleme
                         orderby p.ID
                         select p.ID).ToList();
            veri = ((Sonuc[Sonuc.Count - 1]) + 1).ToString();
            return Json(veri, JsonRequestBehavior.AllowGet);
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
